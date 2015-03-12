Imports Platform.eHR.Core

Partial Public Class Inteauditperson
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.Image2.Attributes.Add("onclick", "GetUserDialog('#BGDialog','#CodeUserInfo','" + HiddenUserPKID.ClientID + "','" + Me.LbUserSid.ClientID + "','" + Me.LbUserName.ClientID + "','" + Me.LbUserEmail.ClientID + "','" + Me.LbUserName.ClientID + "');")
            Bindgrid()
        End If
    End Sub

    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdd.Click
        If Not Me.HiddenUserPKID.Value = "" Then
            Dim acountinfolist As List(Of Integer) = New List(Of Integer)
            acountinfolist.Add(86)
            'If Me.RadioButtonList1.SelectedValue = 1 Then
            '    acountinfolist.Add(98)
            'End If
            RoleManage.CreateAccountRoleRelation(Me.HiddenUserPKID.Value, acountinfolist)
            Dim curroleinfo As RoleManageInfo = New RoleManageInfo()
            Dim curacountinfo As AccountInfo = AccountDAL.LoadAccountInfoByAccountPKID(Me.HiddenUserPKID.Value)
            curroleinfo.PKID = 0
            curroleinfo.RolePKID = 86
            curroleinfo.RoleName = "AuditMan"
            curroleinfo.UserEmail = curacountinfo.Email1
            curroleinfo.UserName = curacountinfo.UserName
            curroleinfo.UserSid = curacountinfo.UserSID
            curroleinfo.UserPhone = curacountinfo.Telphone
            curroleinfo.Userpkid = Me.HiddenUserPKID.Value
            curroleinfo.IsCanEdit = Me.RadioButtonList1.SelectedValue

            Dim curroledal = New RoleManageDAL(curroleinfo)
            curroledal.Save()
            Me.HiddenUserPKID.Value = ""
            Bindgrid()
        End If
    End Sub
    Private Sub Bindgrid()
        Dim rolemanagelist As List(Of RoleManageInfo) = RoleManageDAL.GetInfoBySearchCondtion("")
        If Not rolemanagelist Is Nothing Then
            Me.GridView1.DataSource = rolemanagelist
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbIscanedit As Label = CType(e.Row.FindControl("LbIscanedit"), Label)
            Dim RdoIscanedit As RadioButtonList = CType(e.Row.FindControl("RdoIscanedit"), RadioButtonList)
            RdoIscanedit.SelectedIndex = RdoIscanedit.Items.IndexOf(RdoIscanedit.Items.FindByValue(LbIscanedit.Text))
            If LbIscanedit.Text = "1" Then
                LbIscanedit.Text = "能編輯"
            ElseIf LbIscanedit.Text = "0" Then
                LbIscanedit.Text = "不能編輯"
            End If
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim LBpkid As Label = CType(DateRow.FindControl("LBpkid"), Label)
        Dim LinkSave As LinkButton = CType(DateRow.FindControl("LinkSave"), LinkButton)
        Dim LinkCancle As LinkButton = CType(DateRow.FindControl("LinkCancle"), LinkButton)
        Dim LinkEdit As LinkButton = CType(DateRow.FindControl("LinkEdit"), LinkButton)
        Dim LbIscanedit As Label = CType(DateRow.FindControl("LbIscanedit"), Label)
        Dim RdoIscanedit As RadioButtonList = CType(DateRow.FindControl("RdoIscanedit"), RadioButtonList)
        Select Case e.CommandName
            Case "editup"
                DateRow.BackColor = System.Drawing.Color.Gray
                LinkEdit.Visible = False
                LinkSave.Visible = True
                LinkCancle.Visible = True
                LbIscanedit.Visible = False
                RdoIscanedit.Visible = True
            Case "saveup"
                Dim rolemainfo As RoleManageInfo = RoleManageDAL.GetInfoByPKID(CInt(LBpkid.Text))
                rolemainfo.IsCanEdit = RdoIscanedit.SelectedValue
                Dim rilemadal As RoleManageDAL = New RoleManageDAL(rolemainfo)
                rilemadal.Save()
                Bindgrid()
            Case "cancleed"
                Bindgrid()
        End Select
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Value)
        Dim CurDatarow As GridViewRow = Me.GridView1.Rows(e.RowIndex)
        Dim LbUserpkid As Label = CType(CurDatarow.FindControl("LbUserpkid"), Label)
        Dim LbRolePKID As Label = CType(CurDatarow.FindControl("LbRolePKID"), Label)
        RoleManageDAL.Delete(mpkid)
        RoleManage.DeleteAccountRoleRelation(CInt(LbUserpkid.Text), CInt(LbRolePKID.Text))
        Bindgrid()
    End Sub
End Class