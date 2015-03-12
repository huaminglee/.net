Public Partial Class ShowPDF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("pdfname") Is Nothing Then
            Me.Literal1.Text = Server.UrlDecode(Request.QueryString("pdfname"))
        End If
    End Sub

End Class