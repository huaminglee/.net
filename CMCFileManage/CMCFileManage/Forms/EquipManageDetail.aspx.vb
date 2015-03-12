Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize

Partial Public Class EquipManageDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
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
    Private _EquipManage As EquipManageInfo
    Private Property EquipManage() As EquipManageInfo
        Get
            If _EquipManage Is Nothing Then
                If PKID <> 0 Then
                    _EquipManage = EquipManageDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _EquipManage.eFlowDocID.ToString
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                    _EquipManage = EquipManageDAL.GetInfoByeFlowDocID(DocUniqueID)
                    PKID = _EquipManage.PKID
                Else
                    _EquipManage = New EquipManageInfo()
                End If
            End If
            Return _EquipManage
        End Get
        Set(ByVal value As EquipManageInfo)
            _EquipManage = value
        End Set
    End Property
    '流程控制文件ID
    Private Property DocUniqueID() As String
        Get
            If ViewState(HIDE_DOCUNIQUEID_KEY) Is Nothing Then
                Return String.Empty
            End If

            Return ViewState(HIDE_DOCUNIQUEID_KEY).ToString()
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_DOCUNIQUEID_KEY) = Value

        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Me.UcFileDetail1.CanUpload = False
            If UserInfo.CurrentUserInstance Is Nothing OrElse Not UserInfo.IsInRoles("LabFileManager") Then
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail2.CanRemove = False
                Me.UcFileDetail2.CanUpload = False
                HidCanEdit.Value = 0
            Else
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail2.CanUpload = True
                HidCanEdit.Value = 1
            End If
           
            BindDPL()
            BindControlData()


        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
        Me.UcFileDetail1.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail1.ParentCategory = 1
        Me.UcFileDetail1.ParentSubCategory = 6
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail2.ParentCategory = 1
        Me.UcFileDetail2.ParentSubCategory = 6
    End Sub
    Private Sub BindDPL()
        Dim dt1 As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt1 Is Nothing Then
            Me.DPLDept.DataSource = dt1
            Me.DPLDept.DataTextField = "ParameterText"
            Me.DPLDept.DataValueField = "ParameterText"
            Me.DPLDept.DataBind()
        End If
        Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
        If Not dt2 Is Nothing Then
            Me.DPLqyulocation.DataSource = dt2
            Me.DPLqyulocation.DataTextField = "ParameterText"
            Me.DPLqyulocation.DataValueField = "ParameterText"
            Me.DPLqyulocation.DataBind()
        End If
    End Sub
    Private Sub BindControlData()
        If Not EquipManage Is Nothing Then
            If PKID <> 0 Then

                Me.UcFileDetail1.IsOld = 1
                Me.UcFileDetail1.FileType = "Other"

                Me.DPLDept.SelectedItem.Text = EquipManage.EquipDept
                Me.DPLqyulocation.SelectedItem.Text = EquipManage.QyLocation
                Me.TXTControlNO.Text = EquipManage.ControlNO
                Me.TXTEquipLocation.Text = EquipManage.EquipLocation
                Me.TXTEquipModel.Text = EquipManage.EquipModel
                Me.TXTEquipName.Text = EquipManage.EquipName
                Me.TXTKeepUser.Text = EquipManage.KeepUser
                Me.TXTManuFacturer.Text = EquipManage.ManuFacturer
                Me.TXTRemark.Text = EquipManage.Remark
                Me.TXTSpecification.Text = EquipManage.Specification
                If EquipManage.IsHasDetail = 1 Then
                    Me.RDOIsHasDetail.SelectedIndex = Me.RDOIsHasDetail.Items.IndexOf(Me.RDOIsHasDetail.Items.FindByText("有"))
                Else
                    Me.RDOIsHasDetail.SelectedIndex = Me.RDOIsHasDetail.Items.IndexOf(Me.RDOIsHasDetail.Items.FindByText("無"))
                End If
                If Me.HidCanEdit.Value = 0 Then
                    Me.DPLDept.Enabled = False
                    Me.DPLqyulocation.Enabled = False
                    Me.TXTControlNO.Enabled = False
                    Me.TXTEquipLocation.Enabled = False
                    Me.TXTEquipModel.Enabled = False
                    Me.TXTEquipName.Enabled = False
                    Me.TXTKeepUser.Enabled = False
                    Me.TXTManuFacturer.Enabled = False
                    Me.TXTRemark.Enabled = False
                    Me.TXTSpecification.Enabled = False
                    Me.RDOIsHasDetail.Enabled = False
                Else
                    Me.DPLDept.Enabled = True
                    Me.DPLqyulocation.Enabled = True
                    Me.TXTControlNO.Enabled = True
                    Me.TXTEquipLocation.Enabled = True
                    Me.TXTEquipModel.Enabled = True
                    Me.TXTEquipName.Enabled = True
                    Me.TXTKeepUser.Enabled = True
                    Me.TXTManuFacturer.Enabled = True
                    Me.TXTRemark.Enabled = True
                    Me.TXTSpecification.Enabled = True
                    Me.RDOIsHasDetail.Enabled = True

                End If
                BindGrid()
                BindHisGrid(PKID)
            End If
        End If
    End Sub
    Private Sub BindGrid()
        Dim dt As DataTable = EquipFileDAL.GetInfoByParentID(PKID)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 2)
        If Not dt Is Nothing Then
            Me.GridView2.DataSource = dt
            Me.GridView2.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Alternate OrElse e.Row.RowState = DataControlRowState.Normal Then
                Dim pkid As Integer = CType(e.Row.FindControl("LblPKID"), Label).Text
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim returnurl As String = "../Forms/EquipFileDetail.aspx?pkid=" + pkid.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.NavigateUrl = returnurl

            End If
        End If
    End Sub




    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "儀器設備清單"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo

    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.CtlWFActionList1.DisplayDeleteButton(False)
                Me.CtlWFActionList1.DisplaySaveButton(False)
                Return False
            End If
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Forms/EquipManageList.aspx?pkid=" + PKID.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Forms/EquipManageList.aspx")
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If CurDocInfo.IsFinishFlag = True Then
            Me.CtlWFActionList1.DisplaySaveButton(True)
        End If
        If UserInfo.CurrentUserInstance Is Nothing Then
            Me.CtlWFActionList1.DisplayDeleteButton(False)
            Me.CtlWFActionList1.DisplaySaveButton(False)
        End If

        CtlWFActionList1.CurURL = String.Format("{0}?PageType=equipmanage", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        EquipManage.PKID = PKID
        DocUniqueID = CurDocInfo.DocUniqueID
        EquipManage.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        EquipManage.ControlNO = Me.TXTControlNO.Text
        EquipManage.EquipDept = Me.DPLDept.SelectedItem.Text
        EquipManage.EquipLocation = Me.TXTEquipLocation.Text
        EquipManage.EquipModel = Me.TXTEquipModel.Text
        EquipManage.EquipName = Me.TXTEquipName.Text
        If Me.RDOIsHasDetail.SelectedItem.Text = "有" Then
            EquipManage.IsHasDetail = 1
        Else
            EquipManage.IsHasDetail = 0
        End If
        EquipManage.KeepUser = Me.TXTKeepUser.Text
        EquipManage.ManuFacturer = Me.TXTManuFacturer.Text
        EquipManage.QyLocation = Me.DPLqyulocation.SelectedItem.Text
        EquipManage.RecordDeleted = 0
        EquipManage.Remark = Me.TXTRemark.Text
        EquipManage.Specification = Me.TXTSpecification.Text
        Dim equipmanagedal As EquipManageDAL = New EquipManageDAL(EquipManage)
        PKID = equipmanagedal.Save()

        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 2
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()

        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail2.SaveDatatoDataBase()
    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "儀器設備清單"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 3
        End Get
    End Property

   
    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
            OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            EquipManage.StateName = CurDocInfo.NextStateName
            EquipManage.StateOrder = CurDocInfo.NextStateOrder

        Else
            EquipManage.StateName = CurDocInfo.CurStateName
            EquipManage.StateOrder = CurDocInfo.CurStateOrder

        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            EquipManage.IsFinish = 1
        End If
    End Sub
End Class