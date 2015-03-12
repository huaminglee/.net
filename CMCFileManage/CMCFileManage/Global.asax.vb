Imports System.Web.SessionState
Imports System.Text
Imports System.IO

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Public Shared QUERY_APPLICANTIDX As String = "PKID"               '通用狀況下的文件ID
    Public Shared QUERY_DOCUNIQUEID As String = "eFlowDocID"        'eFlow流程控制的ID
    Public Shared QUERY_ReturnIndex As String = "Index"        'eFLow選中狀態Index
    Public Shared QUERY_RETURNCATEGORY As String = "rc"             '返回選中類別
    Public Shared _strerrormessage As String
    Public Shared _ErrorMessage As String
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 在應用程式啟動時引發
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' 在工作階段啟動時引發
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 在每個要求開頭引發
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 在一開始嘗試驗證使用時引發
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' 在錯誤發生時引發
        Dim StrTime As String = String.Empty
        Dim StrErrorMessage As String = String.Empty
        Dim StrStackTrace As String = String.Empty
        Dim StrFunName As String = String.Empty
        Dim StrClassName As String = String.Empty
        Dim ex As Exception = Server.GetLastError.GetBaseException()
        StrTime = DateTime.Now.ToString
        If Not ex Is Nothing Then
            StrErrorMessage = ex.Message
            StrStackTrace = ex.StackTrace
            StrFunName = ex.TargetSite.Name
            StrClassName = ex.TargetSite.DeclaringType.FullName
            Dim UplodaPathLog As String = String.Format("{0}\ErrorLog\Log.txt", Server.MapPath(Request.ApplicationPath))
            If Not File.Exists(UplodaPathLog) Then
                Try
                    Dim stream As FileStream = New FileStream(UplodaPathLog, FileMode.Create, FileAccess.ReadWrite)
                    stream.Close()
                Catch otherex As Exception
                    Return  '可以發Mail提示權限配置
                End Try
            End If
            _ErrorMessage = String.Format("錯誤發生的時間：{1}{0}錯誤信息為：{2}{0}錯誤的堆棧信息為：{3}{0}出錯的方法為：{4}{0}" & _
            "出錯的類為：{5}{0}URL:{6}{0}主機地址:{7}{0}{8}", System.Environment.NewLine, StrTime, StrErrorMessage, StrStackTrace, _
            StrFunName, StrClassName, Request.CurrentExecutionFilePath, Request.UserHostAddress, _
            "===================================================================================================")

            Dim swMyFile As StreamWriter = New StreamWriter(UplodaPathLog, True)
            _strerrormessage = StrErrorMessage
            swMyFile.WriteLine(_ErrorMessage)
            swMyFile.Flush()
            swMyFile.Close()
        End If
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在工作階段結束時引發
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' 在應用程式結束時引發
    End Sub
    Public Shared ReadOnly Property UrlBase() As String
        Get
            Return "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath
        End Get
    End Property

    Public Shared ReadOnly Property UrlHost() As String
        Get
            Return "http://" + HttpContext.Current.Request.Url.Authority
        End Get
    End Property

    Public Shared ReadOnly Property URL_INDEX() As String
        Get
            Return "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "/default.aspx"
        End Get
    End Property

End Class