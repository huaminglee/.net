Imports Platform.eAuthorize
Imports Platform.eHR.Core
Partial Public Class UCtlLogin
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoginButton.Click
        If Page.IsValid = True Then
            Authorization.Logout()
            If AccountManage.Login(Me.UserName.Text.ToUpper, Me.Password.Text) Then
                FormsAuthentication.RedirectFromLoginPage(UserName.Text.ToUpper, RememberMe.Checked)
                If Context.Request("ReturnUrl") Is Nothing Then
                    Response.Redirect("Default.aspx")
                Else
                    Response.Redirect(Context.Request("ReturnUrl"))
                End If
            Else
                Response.Write("Invalid Credentials.")
            End If

        End If
    End Sub
End Class