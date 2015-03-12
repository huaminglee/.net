Imports Platform.eAuthorize
Imports System.Web.Services

Partial Public Class PersonTecFileDetail
    Inherits System.Web.UI.Page
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Property PKID() As Integer
        Get
            If ViewState(HIDE_APPLICANTIDX_KEY) Is Nothing Then
                Return 0

            End If

            Return Convert.ToInt32(ViewState(HIDE_APPLICANTIDX_KEY))
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_APPLICANTIDX_KEY) = Value
        End Set
    End Property
    Private _PersonTecinfo As PersonTecInfo
    Private Property PersonTecinfo() As PersonTecInfo
        Get
            If _PersonTecinfo Is Nothing Then
                If PKID <> 0 Then
                    _PersonTecinfo = PersonTecDAL.GetInfoByPKID(PKID)
                Else
                    _PersonTecinfo = New PersonTecInfo()
                End If

            End If
            Return _PersonTecinfo
        End Get
        Set(ByVal value As PersonTecInfo)
            _PersonTecinfo = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("pkid") Is Nothing Then
                PKID = CInt(Request.QueryString("pkid"))
            End If
            Me.TxtIntime.Attributes.Add("readonly", True)
            Me.TxtPostsTime.Attributes.Add("readonly", True)
            Me.TxtPostsTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtIntime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail2.CanUpload = False

            Me.UcFileDetail1.ParentCategory = 7
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.FileType = "Person"
            Me.UcFileDetail2.ParentCategory = 7
            Me.UcFileDetail2.ParentSubCategory = 2
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.FileType = "Person"
            Me.UcFileDetail3.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail3.ParentCategory = 7
            Me.UcFileDetail4.ParentCategory = 7
            Me.UcFileDetail3.ParentSubCategory = 1
            Me.UcFileDetail4.ParentSubCategory = 2
            BindDpl()
            BindControlData()

        End If
    End Sub
    Private Sub BindDpl()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DplDept.DataSource = dt
            Me.DplDept.DataTextField = "ParameterText"
            Me.DplDept.DataValueField = "ParameterValue1"
            Me.DplDept.DataBind()
        End If

        Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
        If Not dt Is Nothing Then
            Me.DplQulocation.DataSource = dt2
            Me.DplQulocation.DataTextField = "ParameterText"
            Me.DplQulocation.DataValueField = "ParameterValue2"
            Me.DplQulocation.DataBind()
        End If
    End Sub
    Private Sub BindControlData()
        If Not PersonTecinfo Is Nothing Then
            If PKID > 0 Then
                If UserInfo.IsInRoles("LabFileManager") OrElse UserInfo.IsInRoles("qa") Then
                    Me.LinkEdit.Visible = True
                    Me.UcFileDetail1.CanRemove = True
                    Me.UcFileDetail2.CanRemove = True
                    Me.UcFileDetail3.CanRemove = True
                    Me.UcFileDetail3.CanUpload = True
                    Me.UcFileDetail4.CanRemove = True
                    Me.UcFileDetail4.CanUpload = True
                Else
                    Me.LinkEdit.Visible = False
                    Me.UcFileDetail1.CanRemove = False
                    Me.UcFileDetail2.CanRemove = False
                    Me.UcFileDetail3.CanRemove = False
                    Me.UcFileDetail3.CanUpload = False
                    Me.UcFileDetail4.CanRemove = False
                    Me.UcFileDetail4.CanUpload = False
                End If
                BindHisGrid(PKID)

                Me.btnSave.Visible = False
                Me.TxtUserSid.Enabled = False
                Me.TxtUserName.Enabled = False
                Me.TxtRemark.Enabled = False
                Me.TxtPostsTime.Enabled = False
                Me.TxtPostsRemark.Enabled = False
                Me.TxtPosition.Enabled = False
                Me.TxtOtherRemark.Enabled = False
                Me.TxtJobType.Enabled = False
                Me.TxtIntime.Enabled = False
                Me.DplQulocation.Enabled = False
                Me.DplDept.Enabled = False
                Me.RDOCurType.Enabled = False


                Me.UcFileDetail1.IsOld = 1
                Me.UcFileDetail2.IsOld = 1

                Me.TxtIntime.Text = PersonTecinfo.Intime
                Me.TxtJobType.Text = PersonTecinfo.JobType
                Me.TxtOtherRemark.Text = PersonTecinfo.OtherRemark
                Me.TxtPosition.Text = PersonTecinfo.Position
                Me.TxtPostsRemark.Text = PersonTecinfo.PostsRemark
                Me.TxtPostsTime.Text = PersonTecinfo.PostsTime
                Me.TxtRemark.Text = PersonTecinfo.Remark
                Me.TxtUserName.Text = PersonTecinfo.UserName
                Me.TxtUserSid.Text = PersonTecinfo.UserSid
                Me.LbCerNo.Text = PersonTecinfo.CerNO
                Me.DplDept.SelectedIndex = Me.DplDept.Items.IndexOf(Me.DplDept.Items.FindByText(PersonTecinfo.Dept))
                Me.DplQulocation.SelectedIndex = Me.DplQulocation.Items.IndexOf(Me.DplQulocation.Items.FindByText(PersonTecinfo.QuLocation))
                Me.RDOCurType.SelectedIndex = Me.RDOCurType.Items.IndexOf(Me.RDOCurType.Items.FindByValue(PersonTecinfo.CurType))
            Else
                Me.TxtUserSid.Attributes.Add("validType", "remote['PersonTecFileDetail.aspx/CheckUserSid','UserSID']")

                If UserInfo.IsInRoles("LabFileManager") Then
                    Me.btnSave.Visible = True
                End If
                Me.LinkEdit.Visible = False

            End If
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 6)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.btnSave.Visible = True
        Me.LinkEdit.Visible = False

        Me.TxtUserSid.Enabled = True
        Me.TxtUserName.Enabled = True
        Me.TxtRemark.Enabled = True
        Me.TxtPostsTime.Enabled = True
        Me.TxtPostsRemark.Enabled = True
        Me.TxtPosition.Enabled = True
        Me.TxtOtherRemark.Enabled = True
        Me.TxtJobType.Enabled = True
        Me.TxtIntime.Enabled = True
        Me.DplQulocation.Enabled = True
        Me.DplDept.Enabled = True
        Me.RDOCurType.Enabled = True

    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        PersonTecinfo.PKID = PKID
        If Me.LbCerNo.Text = "" Then
            Dim lsm As Integer = TableBMHDAL.GetMaxlsmbyCategory("QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DplQulocation.SelectedValue.ToString() + "-CER") + 1
            Dim curNo As String = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DplQulocation.SelectedValue.ToString() + "-CER" + lsm.ToString("000")
            PersonTecinfo.CerNO = curNo
            Dim tableInfo As TableBMHInfo = New TableBMHInfo()
            tableInfo.PKID = 0
            tableInfo.Category = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DplQulocation.SelectedValue.ToString() + "-CER"
            tableInfo.BMH = lsm
            tableInfo.RecordPKID = PKID
            tableInfo.YMD = DateTime.Now.ToString

            Dim tabledal As TableBMHDAL = New TableBMHDAL(tableInfo)
            tabledal.Save()
        Else
            PersonTecinfo.CerNO = Me.LbCerNo.Text
        End If
        PersonTecinfo.CurType = Me.RDOCurType.SelectedValue
        PersonTecinfo.Dept = Me.DplDept.SelectedItem.Text
        PersonTecinfo.Intime = Me.TxtIntime.Text
        PersonTecinfo.JobType = Me.TxtJobType.Text
        PersonTecinfo.OtherRemark = Me.TxtOtherRemark.Text
        PersonTecinfo.Position = Me.TxtPosition.Text
        PersonTecinfo.PostsRemark = Me.TxtPostsRemark.Text
        PersonTecinfo.PostsTime = Me.TxtPostsTime.Text
        PersonTecinfo.UserName = Me.TxtUserName.Text
        PersonTecinfo.UserSid = Me.TxtUserSid.Text
        PersonTecinfo.Remark = Me.TxtRemark.Text
        PersonTecinfo.QuLocation = Me.DplQulocation.SelectedItem.Text
        If PKID = 0 Then
            PersonTecinfo.RecordCreated = DateTime.Now
        End If
        Dim persondal As PersonTecDAL = New PersonTecDAL(PersonTecinfo)
        persondal.Save()

        PKID = PersonTecinfo.PKID

        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 6
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()
        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.SaveDatatoDataBase()
        Me.UcFileDetail3.ParentID = PKID
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail3.SaveDatatoDataBase()
        Me.UcFileDetail4.SaveDatatoDataBase()
        Response.Redirect("../Forms/PersonTecFileDetail.aspx?pkid=" + PKID.ToString)
    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("../Forms/PersonTecFileList.aspx")
    End Sub
    <WebMethod()> _
Public Shared Function CheckUserSid(ByVal UserSID As String) As Boolean
        If PersonTecDAL.GetDsBySearchcontition(" RecordDeleted=0 and UserSid='" + UserSID.ToString + "'") Is Nothing Then
            Return True
        End If
        Return False
    End Function

End Class