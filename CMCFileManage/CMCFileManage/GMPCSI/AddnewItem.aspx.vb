Public Partial Class AddnewItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If Not Me.TxtItem.Text = "" Then
            Dim newitem As GEPCSI_DeptItem = New GEPCSI_DeptItem()
            If Not Request.QueryString("DeptPKID") Is Nothing Then
                newitem.DeptItemPKID = 0
                newitem.DeptPKID = Convert.ToInt32(Request.QueryString("DeptPKID"))

            End If
            If Not Request.QueryString("Type") Is Nothing Then
                If Convert.ToInt32(Request.QueryString("Type")) = 1 Then
                    newitem.ItemCategory = 1
                ElseIf Convert.ToInt32(Request.QueryString("Type")) = 2 Then
                    newitem.ItemCategory = 3
                End If


            End If
            If newitem.DeptPKID <> 0 Then
                newitem.ItemName = Me.TxtItem.Text
                newitem.Save()
                Response.Write("<script>window.opener.refreshview();window.close(); </script>")
            End If
        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub
End Class