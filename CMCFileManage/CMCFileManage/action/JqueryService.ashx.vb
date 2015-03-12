Imports Platform.eHR.Core
Imports System.Web
Imports System.Web.Services
Imports System.Reflection
Imports System.IO

Public Class JqueryService
    Implements System.Web.IHttpHandler
    Dim Request As HttpRequest
    Dim Response As HttpResponse

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        context.Response.ContentType = "text/plain"
        context.Response.Write("Hello World!")

    End Sub
    Public Sub CodeUder()
        Dim row As Integer = CInt(Request("rows").ToString())
        Dim page As Integer = CInt(Request("page").ToString())
        Dim UserID As String = Request("UserID").ToString
        Dim SearchCondition As String = " "

        If UserID <> String.Empty Then
            SearchCondition = SearchCondition + " UserName='" + UserID + "'"
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
    Public Sub GetQCFileInfo1()

    End Sub
End Class