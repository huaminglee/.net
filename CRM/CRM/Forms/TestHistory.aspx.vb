Imports Platform.eAuthorize

Partial Public Class TestHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse UserInfo.IsInRoles("EXTERNALWORKER") Then
            Else
                Me.GridView1.Columns(5).Visible = False
            End If
            If Not Request.QueryString("TestItemName") Is Nothing Then
                Dim ds As DataSet = CustomersDAL.GetTestHistoryByTestItemName(Server.UrlDecode(Request.QueryString("TestItemName")))
                If Not ds Is Nothing Then
                    Me.emptyinfo.Visible = False
                    Me.Title = ds.Tables(0).Rows(0).Item("TestItemName").ToString() + "歷史報價"
                    Me.GridView1.DataSource = ds
                    Me.GridView1.DataBind()
                Else
                    Me.emptyinfo.Visible = True
                    Me.GridView1.DataSource = Nothing
                    Me.GridView1.DataBind()
                End If
            End If
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
    '    Response.Write("<script>window.opener=null;window.close(); </script>")
    'End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.Cells(3).Text.Length > 10 Then
                e.Row.Cells(3).ToolTip = e.Row.Cells(3).Text
                e.Row.Cells(3).Text = e.Row.Cells(3).Text.Substring(0, 9)
            End If
        End If
    End Sub
End Class