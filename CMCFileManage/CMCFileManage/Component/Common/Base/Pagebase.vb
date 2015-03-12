Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Reflection
Imports System.Text
Imports System.IO


Public Class BasePage
    Inherits System.Web.UI.Page

    Public Sub New()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        MyBase.OnInit(e)

        CancelFormControlEnterKey(Me.Page.Form.Controls)  '取消页面文本框的enter key
        'AddHeaderJs()                                        '向网页头部添加js等文件 

    End Sub

#Region "取消页面文本控件的enter key功能"

    ''' <summary>
    ''' 在这里我们给Form中的服务器控件添加客户端onkeydown脚步事件，防止服务器控件按下enter键直接回发
    ''' </summary>
    ''' <param name="controls"></param>
    Public Overridable Sub CancelFormControlEnterKey(ByVal controls As ControlCollection)
        '向页面注册脚本 用来取消input的enter key功能
        RegisterUndoEnterKeyScript()

        For Each item As Control In controls
            '服务器TextBox
            If item.[GetType]() Is GetType(System.Web.UI.WebControls.TextBox) Then
                Dim webControl As WebControl = TryCast(item, WebControl)
                webControl.Attributes.Add("onkeydown", "return forbidInputKeyDown(event)")
                'html控件
            ElseIf item.[GetType]() Is GetType(System.Web.UI.HtmlControls.HtmlInputText) Then
                Dim htmlControl As HtmlInputControl = TryCast(item, HtmlInputControl)
                htmlControl.Attributes.Add("onkeydown", "return forbidInputKeyDown(event)")
                '用户控件
            ElseIf TypeOf item Is System.Web.UI.UserControl Then
                '递归调用
                CancelFormControlEnterKey(item.Controls)
            End If
        Next
    End Sub

    ''' <summary>
    ''' 向页面注册forbidInputKeyDown脚本
    ''' </summary>
    Private Sub RegisterUndoEnterKeyScript()
        Dim js As String = String.Empty
        Dim sb As New System.Text.StringBuilder()
        sb.Append("function forbidInputKeyDown(ev) {")
        sb.Append("  if (typeof (ev) != ""undefined"") {")

        sb.Append("  if (ev.keyCode || ev.which) {")
        sb.Append("   if (ev.keyCode == 13 || ev.which == 13) { return false; }")
        sb.Append("  } } }")
        js = sb.ToString()
        If Not Me.Page.ClientScript.IsClientScriptBlockRegistered("forbidInput2KeyDown") Then
            Me.Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "forbidInput2KeyDown", js, True)
        End If
    End Sub

#End Region

#Region "日志处理"

    ''' <summary>
    ''' 出错处理:写日志,导航到公共出错页面
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnError(ByVal e As EventArgs)
        Dim ex As Exception = Me.Server.GetLastError()
        Dim [error] As String = Me.DealException(ex)
        SimpleLogger.WriteFileLog([error], HttpContext.Current.Request.PhysicalApplicationPath & "LogFile")
        If ex.InnerException IsNot Nothing Then
            [error] = Me.DealException(ex)
            SimpleLogger.WriteFileLog([error], HttpContext.Current.Request.PhysicalApplicationPath & "LogFile")
        End If
        Me.Server.ClearError()
        Me.Response.Redirect("/Error.aspx")
    End Sub

    ''' <summary>
    ''' 处理异常，用来将主要异常信息写入文本日志
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <returns></returns>
    Private Function DealException(ByVal ex As Exception) As String
        Me.Application("StackTrace") = ex.StackTrace
        Me.Application("MessageError") = ex.Message
        Me.Application("SourceError") = ex.Source
        Me.Application("TargetSite") = ex.TargetSite.ToString()
        Dim [error] As String = String.Format("URl：{0}" & vbLf & "引发异常的方法：{1}" & vbLf & "错误信息：{2}" & vbLf & "错误堆栈：{3}" & vbLf, Me.Request.RawUrl, ex.TargetSite, ex.Message, ex.StackTrace)
        Return [error]
    End Function

#End Region

#Region "网页头添加通用统一js文件"

    Private Sub AddHeaderJs()
        Dim jsPath As String = "~/Scripts/"
        Dim filePath As String = Server.MapPath(jsPath)
        Dim lit As New Literal()
        Dim sb As New StringBuilder()

        If Not Directory.Exists(filePath) Then
            Throw New Exception("路径不存在")
        End If
        Dim listJs As New List(Of String)()
        For Each item As String In Directory.GetFiles(filePath, "*.js", SearchOption.TopDirectoryOnly)
            listJs.Add(Path.GetFileName(item))
        Next

        For Each jsName As String In listJs
            sb.Append(ScriptInclude(jsPath & jsName))
        Next
        lit.Text = sb.ToString()
        Header.Controls.AddAt(1, lit)
    End Sub

    Private Function ResolveHeaderUrl(ByVal relativeUrl As String) As String
        Dim url As String = Nothing
        If String.IsNullOrEmpty(relativeUrl) Then
            url = String.Empty
        ElseIf Not relativeUrl.StartsWith("~") Then
            url = relativeUrl
        Else
            Dim basePath = HttpContext.Current.Request.ApplicationPath
            url = basePath & relativeUrl.Substring(1)
            url = url.Replace("//", "/")
        End If
        Return url
    End Function

    Private Function ScriptInclude(ByVal url As String) As String

        If String.IsNullOrEmpty(url) Then
            Throw New Exception("路径不存在")
        End If

        Dim path As String = ResolveHeaderUrl(url)
        Return String.Format("<script src='{0}' type='text/javascript'></script>", path)
    End Function

#End Region

    ''' <summary>
    ''' 禁止重複提交按鈕
    ''' </summary>
    ''' <param name="SubmitControl"></param>
    ''' <param name="AlertText"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' 在Page_Load事件中加入下面的代碼
    ''' <code>
    ''' Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '''    ClientScript.GetPostBackEventReference(Me.Button1, "")  '保证 __doPostBack(eventTarget, eventArgument) 正确注册
    '''    If Not IsPostBack Then
    '''        Button1.Attributes.Add("onclick", DisableSubmitButton(Me.Button1, ""))
    '''    End If
    ''' End Sub
    ''' </code>
    '''</remarks>
    Protected Function DisableSubmitButton(ByVal SubmitControl As Control, ByVal AlertText As String) As String
        Dim sb As New System.Text.StringBuilder()
        sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }}")
        '保证验证函数的执行
        ' sb.Append("if(window.confirm('" + AlertText + "?')==false) return false;")
        '自定义客户端脚本
        sb.Append("disableTheSubmit();") ' disable所有submit按钮
        Dim mPage As New System.Web.UI.Page
        sb.Append(mPage.ClientScript.GetPostBackEventReference(SubmitControl, "")) '用__doPostBack来提交，保证按钮的服务器端click事件执行
        sb.Append(";")
        Return sb.ToString
    End Function

End Class

