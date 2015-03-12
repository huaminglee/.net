Imports Platform.eAuthorize

Partial Public Class leftq
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not UserInfo.IsInRoles("QA") AndAlso Not UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                Me.qa1.Visible = False
                Me.qa2.Visible = False
                Me.qa3.Visible = False
                Me.qa5.Visible = False
            End If
        End If
    End Sub

End Class