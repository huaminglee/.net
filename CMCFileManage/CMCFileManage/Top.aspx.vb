Imports Platform.eAuthorize
Imports System.Web.Services

Partial Public Class Top
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Session("username") Is Nothing Then
                Me.LbUserName.Text = Session("username").ToString
            End If

            Dim changqu As String = "LH"
            Dim curneefaround As Integer = 0
            If Not Request.Cookies("changqu") Is Nothing Then
                changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
            End If
            Me.LbQy.Text = changqu
        End If
    End Sub

    Protected Sub Linkout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Linkout.Click
        Authorization.Logout()
        Response.Cookies("dt_cookie_user_name_remember").Expires = DateTime.Now.AddDays(-1)
        Response.Write("<script>window.parent.location.href='Login.aspx'; </script>")

    End Sub

    Protected Sub LinkUserinfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkUserinfo.Click

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), DateTime.Now.ToString, " window.open('" + Global_asax.UrlHost + "/eflownet/Forms/HR/HumanDetail.aspx?C=1'); ", True)

    End Sub
End Class
