Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize

Partial Public Class SuppliersDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo
#Region "Const"
    Private Const _RequestType As String = "ViewState:Type"
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

    Private Property CurType() As String
        Get
            If Not ViewState(_RequestType) Is Nothing Then
                Return CStr(ViewState(_RequestType))
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
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
    Private _CurSupplierInfo As SupplierInfo
    Private Property CurSupplierInfo() As SupplierInfo
        Get
            If _CurSupplierInfo Is Nothing Then
                If PKID <> 0 Then
                    _CurSupplierInfo = SupplierDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _CurSupplierInfo.eFlowDocID.ToString
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.NewGuid().ToString Then
                    _CurSupplierInfo = SupplierDAL.GetInfoByeFlowDocID(DocUniqueID)
                    PKID = _CurSupplierInfo.PKID
                    HiddenPKID.Value = PKID
                Else
                    _CurSupplierInfo = New SupplierInfo()
                End If
            End If
            Return _CurSupplierInfo
        End Get
        Set(ByVal value As SupplierInfo)
            _CurSupplierInfo = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtISOdate.Attributes.Add("readonly", True)
            Me.TxtISOdate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtBIdate.Attributes.Add("readonly", True)
            Me.TxtBIdate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtAssessDate.Attributes.Add("readonly", True)
            Me.TxtAssessDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            GetParan()
            If CurType = 3 Then
                Me.checkrecord.Visible = False
            End If
            BindDPL()
            BindControlData()
            Me.UcFileDetail1.CanUpload = False
            If UserInfo.IsInRoles("qcStockGroup") OrElse (CurType = 3 AndAlso UserInfo.IsInRoles("LabFileManager")) Then
                Me.CtlWFActionList1.Visible = True
                Me.addcheck.Visible = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail2.CanUpload = True
                Me.UcFileDetail2.CanRemove = True
            Else
                Me.CtlWFActionList1.Visible = False
                Me.addcheck.Visible = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail2.CanUpload = False
                Me.UcFileDetail2.CanRemove = False
            End If
        End If
    End Sub
    Private Sub BindDPL()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DplBelongLab.DataSource = dt
            Me.DplBelongLab.DataTextField = "ParameterText"
            Me.DplBelongLab.DataValueField = "ParameterValue1"
            Me.DplBelongLab.DataBind()
            Me.DplBelongLab.Items.Add(New ListItem("All", "All"))
        End If
    End Sub
    Private Sub GetParan()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("pkid"))
            HiddenPKID.Value = PKID
        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
            Select Case CurType
                Case 1
                    Me.LbTitle.Text = "關鍵物品合格供應商"
                Case 2
                    Me.LbTitle.Text = "設備合格供應商"
                Case 3
                    Me.LbTitle.Text = "校準服務供應商"
            End Select
        End If
    End Sub
    Private Sub BindControlData()
        If Not CurSupplierInfo Is Nothing Then
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 6
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.ParentCategory = 6
            Me.UcFileDetail2.ParentSubCategory = 1

            If PKID <> 0 Then

                Me.UcFileDetail1.FileType = "Supplier"
                Me.UcFileDetail1.IsOld = 1

                Me.addcheck.Visible = True
                Me.TxtAddress.Text = CurSupplierInfo.Address
                Me.TxtAssessCycle.Text = CurSupplierInfo.AssessCycle
                If CurSupplierInfo.AssessDate <> DateTime.MaxValue AndAlso CurSupplierInfo.AssessDate <> "9999-12-31 23:59:59.997" Then
                    Me.TxtAssessDate.Text = CurSupplierInfo.AssessDate
                End If
                Me.TxtAssessor.Text = CurSupplierInfo.Assessor
                Me.TxtAssessResult.Text = CurSupplierInfo.AssessResult
                If CurSupplierInfo.BIdate <> DateTime.MaxValue AndAlso CurSupplierInfo.BIdate <> "9999-12-31 23:59:59.997" Then
                    Me.TxtBIdate.Text = CurSupplierInfo.BIdate
                End If
                Me.TxtContactName.Text = CurSupplierInfo.ContactName
                Me.TxtContactPhone.Text = CurSupplierInfo.ContactPhone
                Me.TxtIndustry.Text = CurSupplierInfo.Industry
                If CurSupplierInfo.ISOdate <> DateTime.MaxValue AndAlso CurSupplierInfo.ISOdate <> "9999-12-31 23:59:59.997" Then
                    Me.TxtISOdate.Text = CurSupplierInfo.ISOdate
                End If
                Me.TxtRemark.Text = CurSupplierInfo.Remark
                Me.TxtSupplierName.Text = CurSupplierInfo.SupplierName
                Me.TxtSupplierShortName.Text = CurSupplierInfo.SupplierShortName
                Me.RdoStatus.SelectedIndex = Me.RdoStatus.Items.IndexOf(Me.RdoStatus.Items.FindByValue(CurSupplierInfo.Status))
                Me.DplBelongLab.SelectedIndex = Me.DplBelongLab.Items.IndexOf(Me.DplBelongLab.Items.FindByText(CurSupplierInfo.BelongLab))
                BindHisGrid(PKID)
                BindCheckHis()
            End If
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 4)
        If Not dt Is Nothing Then
            Me.GridView2.DataSource = dt
            Me.GridView2.DataBind()
        Else
            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()
        End If
    End Sub
    Private Sub BindCheckHis()
        Dim ds As DataSet = CheckRecordDAL.GetdsByParentID(PKID)
        If Not ds Is Nothing Then
            Me.GridView1.DataSource = ds
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
#Region "IDOC"
    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "供應商管理"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo

    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Suppliers/SuppliersDetail.aspx?pkid=" + PKID.ToString + "&Type=" + CurType.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Suppliers/SuppliersList.aspx?Type=" + CurType.ToString)
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=supplier&Type={1}", Global_asax.URL_INDEX, CurType)
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        CurSupplierInfo.PKID = PKID
        CurSupplierInfo.eFlowDocID = New Guid(DocUniqueID)
        CurSupplierInfo.Address = Me.TxtAddress.Text
        CurSupplierInfo.AssessCycle = Me.TxtAssessCycle.Text

        CurSupplierInfo.Assessor = Me.TxtAssessor.Text
        CurSupplierInfo.AssessResult = Me.TxtAssessResult.Text
        CurSupplierInfo.BelongLab = Me.DplBelongLab.SelectedItem.Text

        CurSupplierInfo.ContactName = Me.TxtContactName.Text
        CurSupplierInfo.ContactPhone = Me.TxtContactPhone.Text
        CurSupplierInfo.Industry = Me.TxtIndustry.Text
        If Not Me.TxtBIdate.Text = String.Empty Then
            CurSupplierInfo.BIdate = Me.TxtBIdate.Text
        End If
        If Not Me.TxtISOdate.Text = String.Empty Then
            CurSupplierInfo.ISOdate = Me.TxtISOdate.Text
        End If
        If Not Me.TxtAssessDate.Text = String.Empty Then
            CurSupplierInfo.AssessDate = Me.TxtAssessDate.Text
        End If
        CurSupplierInfo.RecordDeleted = 0
        CurSupplierInfo.Remark = Me.TxtRemark.Text
        CurSupplierInfo.Status = Me.RdoStatus.SelectedValue
        CurSupplierInfo.SupplierName = Me.TxtSupplierName.Text
        CurSupplierInfo.SupplierShortName = Me.TxtSupplierShortName.Text
        CurSupplierInfo.Type = CurType


        Dim CurSupplierDal As SupplierDAL = New SupplierDAL(CurSupplierInfo)
        CurSupplierDal.Save()
        PKID = CurSupplierInfo.PKID

        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 4
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
#End Region

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CurSupplierInfo.StateName = CurDocInfo.NextStateName
            CurSupplierInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            CurSupplierInfo.StateName = CurDocInfo.CurStateName
            CurSupplierInfo.StateOrder = CurDocInfo.CurStateOrder
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CurSupplierInfo.IsFinish = 1

        End If
        If CurDocInfo.CurStateName = "開始狀態" Then
            CurSupplierInfo.RecordCreated = DateTime.Now
        End If
    End Sub

    Protected Sub btn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn1.Click
        BindCheckHis()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), DateTime.Now.ToString(), "<script>parent.iFrameHeight();</script>", False)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbQuality As Label = CType(e.Row.FindControl("LbQuality"), Label)
            If LbQuality.Text = "1" Then
                LbQuality.Text = "OK"
            Else
                LbQuality.Text = "NG"
            End If
            Dim LbService As Label = CType(e.Row.FindControl("LbService"), Label)
            If LbService.Text = "1" Then
                LbService.Text = "OK"
            Else
                LbService.Text = "NG"
            End If
            Dim LbDelivery As Label = CType(e.Row.FindControl("LbDelivery"), Label)
            If LbDelivery.Text = "1" Then
                LbDelivery.Text = "OK"
            Else
                LbDelivery.Text = "NG"
            End If
            Dim LbIsOK As Label = CType(e.Row.FindControl("LbIsOK"), Label)
            If LbIsOK.Text = "1" Then
                LbIsOK.Text = "OK"
            Else
                LbIsOK.Text = "NG"
            End If
        End If
    End Sub
End Class