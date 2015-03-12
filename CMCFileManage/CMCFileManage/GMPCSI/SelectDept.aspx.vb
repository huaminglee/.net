Imports Platform.eAuthorize

Partial Public Class SelectDept
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDataList()
        End If
    End Sub
    Protected Sub BindDataList()
        Dim Alist As ArrayList = GEPCSI_Result.GetallDeptInfo()
        If Not Alist Is Nothing Then
            Me.DataList1.DataSource = Alist
            Me.DataList1.DataBind()
        End If
    End Sub
    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Select Case e.CommandName
            Case "SearchDeptName"

                If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                    Dim DeptPKID As Integer = Convert.ToInt32(e.CommandArgument)
                    Me.DataList1.SelectedIndex = e.Item.ItemIndex
                    Dim SelectedMachine As String = CType(Me.DataList1.SelectedItem.FindControl("linkDeptName"), LinkButton).Text
                    Dim isSubmit As Boolean = GEPCSI_Result.IsSubmit(DeptPKID, UserInfo.CurrentUserCHName)
                    If isSubmit Then
                        ClientScript.RegisterStartupScript(Me.GetType, "", "alert('您已經做過該實驗室此次調查了');", True)
                    Else

                        Response.Redirect("../GMPCSI/GMPCSIMoudle.aspx?DeptPKID=" + DeptPKID.ToString)
                    End If

                End If
        End Select
    End Sub
End Class