Public Partial Class AddNewNGItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Protected Sub BtnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOK.Click
        If Not Me.TextBox1.Text = "" Then

            If Not Request.QueryString("DeptItemPKID") Is Nothing Then
                Dim newngitem As GEPCSI_NGItemReasonInfo = New GEPCSI_NGItemReasonInfo()
                newngitem.PKID = 0
                newngitem.DeptItemPKID = Convert.ToInt32(Request.QueryString("DeptItemPKID"))
                newngitem.NGItemName = Me.TextBox1.Text
                newngitem.RecordCreated = DateTime.Now
                newngitem.RecordDeleted = 0
                If Me.Chbistextbox.Checked = True Then
                    newngitem.IsWithTextBox = 1
                Else
                    newngitem.IsWithTextBox = 0
                End If
                Dim ngitemdal As GEPCSI_NGItemReasonDAL = New GEPCSI_NGItemReasonDAL(newngitem)
                ngitemdal.Save()
                Response.Write("<script>window.opener.refreshview();window.close(); </script>")
            End If

        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub
End Class