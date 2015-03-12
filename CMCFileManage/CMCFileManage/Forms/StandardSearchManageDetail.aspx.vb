Imports Platform.eAuthorize

Partial Public Class StandardSearchManageDetail
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
#End Region
#Region "Properties"
    '當前文件惟一ID
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
    Private _StandardSearchManageInfo As StandardSearchManageInfo
    Private Property StandardSearchManageInfo() As StandardSearchManageInfo
        Get
            If _StandardSearchManageInfo Is Nothing Then
                If PKID <> 0 Then
                    _StandardSearchManageInfo = StandardSearchManageDAL.GetInfoByPKID(PKID)
                Else
                    _StandardSearchManageInfo = New StandardSearchManageInfo()
                End If
            End If
            Return _StandardSearchManageInfo
        End Get
        Set(ByVal value As StandardSearchManageInfo)
            _StandardSearchManageInfo = value
        End Set
    End Property

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 4
            Me.UcFileDetail1.ParentSubCategory = 2
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.ParentCategory = 4
            Me.UcFileDetail2.ParentSubCategory = 2
            Me.UcFileDetail1.CanUpload = False


            BindDPL()
            ' Me.TxtSearchTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtSearchTime.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtSearchTime.Attributes.Add("readonly", True)
            BindConttrolData()
            If UserInfo.CurrentUserInstance Is Nothing OrElse Not UserInfo.IsInRoles("LabFileManager") Then
                Me.LinkEdit.Visible = False
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail2.CanUpload = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail2.CanRemove = False
            Else
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail2.CanUpload = True
            End If
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))

        End If

    End Sub
    Private Sub BindDPL()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DPLSearchDept.DataSource = dt
            Me.DPLSearchDept.DataTextField = "ParameterText"
            Me.DPLSearchDept.DataValueField = "ParameterValue2"
            Me.DPLSearchDept.DataBind()
        End If
        Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("QY")
        If Not dt2 Is Nothing Then
            Me.DPLQyLocation.DataSource = dt2
            Me.DPLQyLocation.DataTextField = "ParameterText"
            Me.DPLQyLocation.DataValueField = "ParameterValue2"
            Me.DPLQyLocation.DataBind()
        End If
    End Sub
    Private Sub BindConttrolData()
        If PKID <> 0 Then
            Me.DPLQyLocation.Enabled = False
            Me.DPLSearchDept.Enabled = False
            Me.DPLSearchJD.Enabled = False
            Me.TxtRemark.Enabled = False
            Me.TxtSearchTime.Enabled = False
            Me.TxtSearchUser.Enabled = False

            Me.UcFileDetail1.IsOld = 1
            Me.UcFileDetail1.FileType = "Stand"

            Me.LinkEdit.Visible = True
            Me.LinkSave.Visible = False
            Me.TxtSearchTime.Text = StandardSearchManageInfo.SearchTime
            Me.DPLQyLocation.SelectedIndex = Me.DPLQyLocation.Items.IndexOf(Me.DPLQyLocation.Items.FindByText(StandardSearchManageInfo.QyLocation))
            Me.DPLSearchDept.SelectedIndex = Me.DPLSearchDept.Items.IndexOf(Me.DPLSearchDept.Items.FindByText(StandardSearchManageInfo.SearchDept))
            Me.DPLSearchJD.SelectedItem.Text = StandardSearchManageInfo.SearchJD
            Me.TxtRemark.Text = StandardSearchManageInfo.Remark
            Me.TxtSearchUser.Text = StandardSearchManageInfo.SearchUser
            BindHisGrid(PKID)

        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 7)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        StandardSearchManageInfo.PKID = PKID
        StandardSearchManageInfo.SearchUser = Me.TxtSearchUser.Text
        StandardSearchManageInfo.QyLocation = Me.DPLQyLocation.SelectedItem.Text
        StandardSearchManageInfo.RecordCreated = DateTime.Now
        StandardSearchManageInfo.Remark = Me.TxtRemark.Text
        StandardSearchManageInfo.SearchDept = Me.DPLSearchDept.SelectedItem.Text
        StandardSearchManageInfo.SearchJD = Me.DPLSearchJD.SelectedItem.Text
        StandardSearchManageInfo.SearchTime = Me.TxtSearchTime.Text
        Dim standarsearchdal As StandardSearchManageDAL = New StandardSearchManageDAL(StandardSearchManageInfo)
        PKID = standarsearchdal.Save()


        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()                  '保存變更歷史
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 7
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail2.SaveDatatoDataBase()
        Me.UcFileDetail1.ParentID = PKID                                              '保存附件
        Me.UcFileDetail1.SaveDatatoDataBase()

        Response.Redirect("../Forms/StandardSearchManageList.aspx")
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click

        Me.LinkSave.Visible = True
        Me.LinkEdit.Visible = False
        Me.DPLQyLocation.Enabled = True
        Me.DPLSearchDept.Enabled = True
        Me.DPLSearchJD.Enabled = True
        Me.TxtRemark.Enabled = True
        Me.TxtSearchTime.Enabled = True
        Me.TxtSearchUser.Enabled = True
        Me.UcFileDetail1.CanUpload = True
        
    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("../Forms/StandardSearchManageList.aspx")
    End Sub
End Class