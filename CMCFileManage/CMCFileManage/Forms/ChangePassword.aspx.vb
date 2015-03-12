Imports Platform.eAuthorize
Imports Platform.eHR.Core

Partial Public Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not UserInfo.CurrentUserInstance Is Nothing Then
                Me.TxtOldPass.Focus()
                Me.Label1.Text = UserInfo.CurrentUserID
            End If
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Try
            Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = Server.HtmlEncode(Request.Cookies("changqu").Value)
            If AccountManage.Login(UserInfo.CurrentUserID, Me.TxtOldPass.Text.Trim) Then
                AccountManage.PasswordReset(UserInfo.CurrentUserID, Me.TxtNewPass.Text.Trim)
                Response.Write("<script>alert('修改成功'); </script>")
                Response.Write("<script>window.opener=null;window.close(); </script>")
            Else
                Me.LbError.Visible = True
                Me.TxtOldPass.Focus()
                Me.TxtOldPass.Text = String.Empty
            End If
        Catch ex As Exception

        Finally
            Platform.eFlowConfiguration.ConfigurationInfo._ChangQU = ""
        End Try
       
    End Sub
End Class