Public Partial Class TestItemManageAdd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim dt As DataTable = TestItemManageDAL.GetAllServiceallqy()          '關聯測試申請系統數據源則修改
            If dt.Rows.Count > 0 Then
                Me.DPLlabserviceName.DataSource = dt
                Me.DPLlabserviceName.DataTextField = "LbServiceName"
                Me.DPLlabserviceName.DataValueField = "LbServicePKID"
                Me.DPLlabserviceName.DataBind()
            End If
            If Me.CheckBox1.Checked = False Then
                Me.TxtTestItemName.Enabled = False
                Me.DPLlabserviceName.Enabled = False
            Else
                Me.DPLlabserviceName.Enabled = True
                Me.TxtTestItemName.Enabled = True
            End If
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        If Me.TxtTestItemName.Text.Trim <> "" Then
            Dim NewItemPKID As Integer = 0
            If Me.HiddenTestItemPKID.Value = 0 OrElse Me.CheckBox1.Checked = True Then               '手動加入測試申請系統中不存在的測試項目
                NewItemPKID = TestItemManageDAL.GetMinItemPKID() - 1
            Else
                NewItemPKID = CInt(Me.HiddenTestItemPKID.Value)
            End If
            Dim NewIitemInfo As TestItemManageInfo = New TestItemManageInfo()
            NewIitemInfo.PKID = 0
            NewIitemInfo.LbServiceName = StrConv(Me.DPLlabserviceName.SelectedItem.Text, VbStrConv.SimplifiedChinese, 2052)
            NewIitemInfo.LbServicePKID = Me.DPLlabserviceName.SelectedItem.Value
            NewIitemInfo.TestItemName = StrConv(Me.TxtTestItemName.Text, VbStrConv.SimplifiedChinese, 2052)
            NewIitemInfo.TestItemPKID = NewItemPKID
            NewIitemInfo.DWPJbootfee = CInt(Me.TxtPJbasic.Text)
            NewIitemInfo.DWPJunitfee = CInt(Me.TxtPJunit.Text)
            NewIitemInfo.CBunitfee = CInt(Me.TxtCBunit.Text)
            NewIitemInfo.Extend1 = StrConv(Me.Txtdanwei.Text, VbStrConv.SimplifiedChinese, 2052)
            NewIitemInfo.DWDJbootfee = 0
            NewIitemInfo.DWDJunitfee = 0
            NewIitemInfo.CBbootfee = 0
            NewIitemInfo.Extend2 = ""
            NewIitemInfo.Extend3 = ""
            NewIitemInfo.Extend4 = ""
            NewIitemInfo.Extend5 = ""
            NewIitemInfo.Extend6 = ""
            NewIitemInfo.RecordCreated = DateTime.Now
            NewIitemInfo.RecordDeleted = 0

            Dim newitemdal As TestItemManageDAL = New TestItemManageDAL(NewIitemInfo)
            newitemdal.Save()
            Response.Write("<script>window.opener.utree();window.close(); </script>")
        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        Response.Write("<script>window.opener=null;window.close(); </script>")
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.DPLlabserviceName.Enabled = True
            Me.TxtTestItemName.Enabled = True
        Else
            Me.DPLlabserviceName.Enabled = False
            Me.TxtTestItemName.Enabled = False
        End If
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        If Me.TxtSearchItemName.Text.Trim <> "" Then
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestApplyManage_GetTestItemInfoNotIN", Me.TxtSearchItemName.Text)
            Dim dt As DataTable = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                Me.HiddenTestItemPKID.Value = CInt(dr.Item("TestItemPKID"))
                Me.DPLlabserviceName.SelectedIndex = Me.DPLlabserviceName.Items.IndexOf(Me.DPLlabserviceName.Items.FindByValue(CInt(dr.Item("TestServicePKID"))))
                Me.TxtTestItemName.Text = dr.Item("ItemName").ToString
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), DateTime.Now.ToString, "alert('測試項目不存在于測試申請系統或者已存在本系統，請檢查！');", True)
            End If
        End If
        
    End Sub
End Class