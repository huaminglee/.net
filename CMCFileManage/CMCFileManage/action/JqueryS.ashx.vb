Imports Platform.eHR.Core
Imports System.Web
Imports System.Web.Services
Imports System.Reflection
Imports System.IO

Public Class JqueryS
    Implements System.Web.IHttpHandler
    Dim Request As HttpRequest
    Dim Response As HttpResponse

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Request = context.Request
        Response = context.Response
        Dim Method As String = context.Request("Method").ToString()
        Dim methodInfo As MethodInfo = Me.GetType().GetMethod(Method)
        methodInfo.Invoke(Me, Nothing)
        context.Response.Flush()
        context.Response.End()


    End Sub
    Public Sub GetFile()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim TotalRecord As Integer = 0
        Dim Searchcondition As String = "IsFinish =1  AND   RecordDeleted=0 and FileStatus=0"
        Dim ds As DataSet
        Dim FileName As String = Request("FileName")
        If FileName <> String.Empty Then
            Searchcondition += " and( FileName Like '%" + FileName + "%' OR FileBH Like '%" + FileName + "%' or ApplyDept like '%" + FileName + "%')"
            'ds = QC_FileInfoDAL.Get34dsByeFileName(FileName)
        End If
        ds = TableBMHDAL.GetPageInfoBySearchCondition("QC_FileInfo", Searchcondition, "PKID,ApplyDept,	FileName,FileLayer,	FileBH, EffectDate", "EffectDate", row, page, TotalRecord)

        Dim FileList As List(Of String) = New List(Of String)
        FileList.Add("PKID")
        FileList.Add("ApplyDept")
        FileList.Add("FileName")
        FileList.Add("FileLayer")
        FileList.Add("FileBH")
        FileList.Add("EffectDate")
        If Not ds Is Nothing Then
            Dim AllCount As Integer = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Dim text As String = Json.ToJson(AllCount, ds.Tables(0), FileList)
            Response.Write(text)
        Else
            Response.Write("{""rows"":[""]}")
        End If
    End Sub
    Public Sub GetApplydeptByfilelayer()
        Dim Returnstring = "{""rows"":[""]}"
        Dim filelayer As String = Request("filelayer").ToString
        Dim DT As DataTable = QC_FileInfoDAL.GetApplydeptByfilelayer(filelayer)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetFilecategoryByapplydepts()
        Dim Returnstring = "{""rows"":[""]}"
        Dim applydepts As String = HttpUtility.UrlDecode(Request("applydepts").ToString)
        Dim DT As DataTable = QC_FileInfoDAL.GetFilecategoryByapplydepts(applydepts)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetFilebyfilelayerandfilecategory()
        Dim Returnstring = "{""rows"":[""]}"
        Dim applydepts As String = HttpUtility.UrlDecode(Request("applydepts").ToString)
        Dim filecategory As String = HttpUtility.UrlDecode(Request("filecategore").ToString)
        Dim DT As DataTable = QC_FileInfoDAL.GetFilebyapplydeptandfilecategory(applydepts, filecategory)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetFourFileByApplyDept()
        Dim Returnstring = "{""rows"":[""]}"
        Dim applydepts As String = HttpUtility.UrlDecode(Request("applydepts").ToString)
        Dim DT As DataTable = QC_FileInfoDAL.GetFourFileByApplyDept(applydepts)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetZT()
        Dim Returnstring = "{""rows"":[""]}"

        '   Dim DT As DataTable = QC_UserParameterDAL.GetAllZT()
        Dim DT As DataTable = QC_FileInfoDAL.GetZT()
       
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetDeptByZT()
        Dim Returnstring = "{""rows"":[""]}"
        Dim IsFinished As String = Request("IsFinished").ToString
        Dim RecordType As String = Request("RecordType").ToString
        Dim DT As DataTable = QC_FileInfoDAL.GetDeptByIsfinishedandrecordtype(IsFinished, RecordType)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub GetFileByApplydeptandType()
        Dim Returnstring = "{""rows"":[""]}"
        Dim Type As String = Request("Type").ToString
        Dim IsFinished As String = Request("IsFinished").ToString
        Dim applydepts As String = HttpUtility.UrlDecode(Request("applydepts").ToString)
        Dim DT As DataTable = QC_FileInfoDAL.GetFileBydeptandtype(IsFinished, applydepts, Type)
        If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
            Dim text As String = Json.ToJson(DT)
            Response.Write(text)
        Else
            Response.Write(Returnstring)
        End If
    End Sub
    Public Sub CodeUder()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim UserID As String = Request("UserID").ToString
        Dim SearchCondition As String = " RecordDeleteFlag=0"

        If UserID <> String.Empty Then
            SearchCondition = SearchCondition + " and UserName='" + UserID + "'"
        End If


        Dim Ds As DataSet = AccountManage.LoadAccountByPaging(row, page, 0, "AccountPKID,UserSID,UserName,Email1,Telphone", SearchCondition)
        Dim UserInfo As List(Of String) = New List(Of String)
        UserInfo.Add("AccountPKID")
        UserInfo.Add("UserSID")
        UserInfo.Add("UserSID")
        UserInfo.Add("UserName")
        UserInfo.Add("Email1")
        UserInfo.Add("Telphone")
        If Not Ds Is Nothing Then
            Dim AllCount As Integer = CInt(Ds.Tables(1).Rows(0)("TotalRecord"))
            Dim text As String = Json.ToJson(AllCount, Ds.Tables(0), UserInfo)
            Response.Write(text)
        Else
            Response.Write("{""rows"":[""]}")
        End If

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class