Imports System.Web
Imports System.Web.Services
Imports System.Web.SessionState

Public Class FileUPHandler
    Implements System.Web.IHttpHandler, IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        context.Response.ContentType = "text/plain"
        Dim postedFile As HttpPostedFile = context.Request.Files("Filedata")
        Dim filepath As String = context.Session("currentPath")
        Dim FileName As String = postedFile.FileName
        postedFile.SaveAs(filepath + "/" + FileName)
        context.Response.Write("1")

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class