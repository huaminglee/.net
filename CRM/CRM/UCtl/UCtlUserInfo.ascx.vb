Imports Platform.eAuthorize

Partial Public Class UCtlUserInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then          
            Ctl_BD()
        End If
    End Sub
    Sub Ctl_BD()
        If HttpContext.Current.Request.IsAuthenticated Then

            Me.LabName.Text = "歡迎你，" + UserInfo.CurrentUserCHName
            LnkLogIO.Text = "註銷"
            Lnk.Text = "個人信息"
        Else
            Me.LabName.Text = "匿名用戶"
            LnkLogIO.Text = "登錄"
        End If
    End Sub

    Protected Sub LnkLogIO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LnkLogIO.Click
        FormsAuthentication.SignOut()
        Response.Redirect("Login.aspx")
    End Sub
End Class