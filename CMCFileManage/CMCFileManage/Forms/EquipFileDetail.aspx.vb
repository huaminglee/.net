Imports Platform.eAuthorize
Imports eWorkFlow.eFlowDoc

Partial Public Class EquipFileDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo

#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private ReadOnly HIDE_ParentID = "ViewState:ParentID"
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
    Public Property ParentID() As Integer
        Get
            If ViewState(HIDE_ParentID) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentID))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentID) = Value
        End Set
    End Property
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
    Private _EquipFiles As EquipFileInfo
    Private Property EquipFileInfo() As EquipFileInfo
        Get
            If _EquipFiles Is Nothing Then
                If PKID <> 0 Then
                    _EquipFiles = EquipFileDAL.GetInfoByPKID(PKID)
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                    _EquipFiles = EquipFileDAL.GetInfoByeFlowDocID(DocUniqueID)
                Else
                    _EquipFiles = New EquipFileInfo()
                End If
            End If
            Return _EquipFiles
        End Get
        Set(ByVal value As EquipFileInfo)
            _EquipFiles = value
        End Set
    End Property
    Public Property Qy() As String
        Get
            If ViewState("qy") Is Nothing Then
                Return "華南檢測中心"
            Else
                Return ViewState("qy").ToString
            End If
        End Get
        Set(ByVal value As String)
            ViewState("qy") = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            BindDPL()
            BindControlData()
            If UserInfo.CurrentUserInstance Is Nothing OrElse Not UserInfo.IsInRoles("LabFileManager") Then
                Me.CtlWFActionList1.Visible = False
            End If
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
        End If

        Dim changqu As String = "LH"
        Dim curneefaround As Integer = 0
        If Not Request.Cookies("changqu") Is Nothing Then
            changqu = Server.HtmlEncode(Request.Cookies("changqu").Value)
        End If
        Select Case changqu
            Case "TY"
                Qy = "太原檢測中心"
            Case "NN"
                Qy = "南寧檢測中心"
            Case "LH"
                Qy = "華南檢測中心"
            Case "YT"
                Qy = "煙台檢測中心"
            Case "WH"
                Qy = "武漢檢測中心"
            Case "CD"
                Qy = "成都檢測中心"
            Case "WSJ"
                Qy = "吳淞江檢測中心"
            Case "GL"
                Qy = "觀瀾檢測中心"
            Case "CQ"
                Qy = "重慶檢測中心"
            Case "ZZ"
                Qy = "鄭州檢測中心"
            Case "NN"
                Qy = "南寧檢測中心"
            Case "TY"
                Qy = "太原檢測中心"
        End Select
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
            Me.DPLQuLocation.DataSource = dt2
            Me.DPLQuLocation.DataTextField = "ParameterText"
            Me.DPLQuLocation.DataValueField = "ParameterText"
            Me.DPLQuLocation.DataBind()
        End If
        Dim Searchcondition As String = " RecordDeleted=0 and QyLocation ='" + Qy + "'"
        

        Dim dt3 As DataTable = EquipFileDAL.GetEquipInfobySearchcondition(Searchcondition)
        If Not dt3 Is Nothing Then
            Me.DPLEquipname.DataSource = dt3
            Me.DPLEquipcontrolno.DataSource = dt3
            Me.DPLEquipname.DataTextField = "EquipName"
            Me.DPLEquipname.DataValueField = "EquipName"
            Me.DPLEquipname.DataBind()
            Me.DPLEquipcontrolno.DataTextField = "ControlNO"
            Me.DPLEquipcontrolno.DataValueField = "ControlNO"
            Me.DPLEquipcontrolno.DataBind()
            Me.DPLEquipname.Items.Add("--請選擇--")
            Me.DPLEquipcontrolno.Items.Add("--請選擇--")
            Me.DPLEquipcontrolno.SelectedIndex = Me.DPLEquipcontrolno.Items.IndexOf(Me.DPLEquipcontrolno.Items.FindByText("--請選擇--"))
            Me.DPLEquipname.SelectedIndex = Me.DPLEquipname.Items.IndexOf(Me.DPLEquipname.Items.FindByText("--請選擇--"))

        End If

    End Sub
    Private Sub BindControlData()
        If PKID <> 0 Then
            Me.DPLDept.SelectedItem.Text = EquipFileInfo.EquipDept
            Me.DPLEquipname.SelectedItem.Text = EquipFileInfo.EquipName
            Me.DPLQuLocation.SelectedItem.Text = EquipFileInfo.QyLocation
            Me.DPLEquipcontrolno.SelectedItem.Text = EquipFileInfo.ControlNO
            Me.TXTSerialNumber.Text = EquipFileInfo.SerialNumber
            Me.TXTRemark.Text = EquipFileInfo.Extend5
            Me.TXTManuFacturer.Text = EquipFileInfo.ManuFacturer
            Me.TXTMainSpecification.Text = EquipFileInfo.MainSpecification
            Me.TXTKeepUser.Text = EquipFileInfo.KeepUser
            Me.TXTEquipNum.Text = EquipFileInfo.EquipNum
            Me.TXTEquipModel.Text = EquipFileInfo.EquipModel
            Me.TXTEquipLocation.Text = EquipFileInfo.EquipLocation
            Me.TXTDetailName.Text = EquipFileInfo.DetailName
            Me.TXTDetailControlNO.Text = EquipFileInfo.DetailControlNO

            BindHisGrid(PKID)
            Me.DPLDept.Enabled = False
            Me.DPLEquipname.Enabled = False
            Me.DPLQuLocation.Enabled = False
            Me.DPLEquipcontrolno.Enabled = False
            Me.TXTSerialNumber.Enabled = False
            Me.TXTRemark.Enabled = False
            Me.TXTManuFacturer.Enabled = False
            Me.TXTMainSpecification.Enabled = False
            Me.TXTKeepUser.Enabled = False
            Me.TXTEquipNum.Enabled = False
            Me.TXTEquipModel.Enabled = False
            Me.TXTEquipLocation.Enabled = False
            Me.TXTDetailName.Enabled = False
            Me.TXTDetailControlNO.Enabled = False
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 1)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub DPLEquipcontrolno_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DPLEquipcontrolno.SelectedIndexChanged

        Dim equipmanageinfo As EquipManageInfo = New EquipManageInfo()
        equipmanageinfo = EquipManageDAL.GetEquipInfoByControlNOandQy(Me.DPLEquipcontrolno.SelectedItem.Text, Qy)
        If Not equipmanageinfo Is Nothing Then
            ParentID = equipmanageinfo.PKID
            If equipmanageinfo.EquipName <> Me.DPLEquipname.SelectedItem.Text Then
                Me.DPLEquipname.SelectedIndex = Me.DPLEquipname.Items.IndexOf(Me.DPLEquipname.Items.FindByText(equipmanageinfo.EquipName))
            End If
        End If
    End Sub

    Protected Sub DPLEquipname_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DPLEquipname.SelectedIndexChanged
        Dim equipmanageinfo As EquipManageInfo = New EquipManageInfo()
        equipmanageinfo = EquipManageDAL.GetEquipInfoByEquipNameandqy(Me.DPLEquipname.SelectedItem.Text, Qy)
        If Not equipmanageinfo Is Nothing Then
            ParentID = equipmanageinfo.PKID
            If equipmanageinfo.ControlNO <> Me.DPLEquipcontrolno.SelectedItem.Text Then
                Me.DPLEquipcontrolno.SelectedIndex = Me.DPLEquipcontrolno.Items.IndexOf(Me.DPLEquipcontrolno.Items.FindByText(equipmanageinfo.ControlNO))
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
            Dim Returnurl As String = "../Forms/EquipFileDetail.aspx?pkid=" + PKID.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Forms/EquipFileList.aspx")
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
        If EquipFileInfo.IsFinish = 1 Then
            Me.CtlWFActionList1.IsUseFlow = False
        End If
        If CurDocInfo.CurStateOrder = 1 Then
            Me.DPLDept.Enabled = True
            Me.DPLEquipname.Enabled = True
            Me.DPLQuLocation.Enabled = True
            Me.DPLEquipcontrolno.Enabled = True
            Me.TXTSerialNumber.Enabled = True
            Me.TXTRemark.Enabled = True
            Me.TXTManuFacturer.Enabled = True
            Me.TXTMainSpecification.Enabled = True
            Me.TXTKeepUser.Enabled = True
            Me.TXTEquipNum.Enabled = True
            Me.TXTEquipModel.Enabled = True
            Me.TXTEquipLocation.Enabled = True
            Me.TXTDetailName.Enabled = True
            Me.TXTDetailControlNO.Enabled = True
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=equipmanagefile", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        EquipFileInfo.PKID = PKID
        DocUniqueID = CurDocInfo.DocUniqueID
        EquipFileInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        EquipFileInfo.ParentPKID = ParentID
        EquipFileInfo.ControlNO = Me.DPLEquipcontrolno.SelectedItem.Text
        EquipFileInfo.DetailControlNO = Me.TXTDetailControlNO.Text
        EquipFileInfo.DetailName = Me.TXTDetailName.Text
        EquipFileInfo.EquipDept = Me.DPLDept.SelectedItem.Text
        EquipFileInfo.EquipLocation = Me.TXTEquipLocation.Text
        EquipFileInfo.EquipModel = Me.TXTEquipModel.Text
        EquipFileInfo.EquipName = Me.DPLEquipname.SelectedItem.Text
        EquipFileInfo.EquipNum = Me.TXTEquipNum.Text
        EquipFileInfo.KeepUser = Me.TXTKeepUser.Text
        EquipFileInfo.MainSpecification = Me.TXTMainSpecification.Text
        EquipFileInfo.ManuFacturer = Me.TXTManuFacturer.Text
        EquipFileInfo.QyLocation = Me.DPLQuLocation.SelectedItem.Text
        EquipFileInfo.RecordCreated = DateTime.Now
        EquipFileInfo.SerialNumber = Me.TXTSerialNumber.Text
        EquipFileInfo.Extend5 = Me.TXTRemark.Text
        Dim equipdal As EquipFileDAL = New EquipFileDAL(EquipFileInfo)
        equipdal.Save()
        PKID = EquipFileInfo.PKID
        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 1
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()
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
            EquipFileInfo.StateName = CurDocInfo.NextStateName
            EquipFileInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            EquipFileInfo.StateName = CurDocInfo.CurStateName
            EquipFileInfo.StateOrder = CurDocInfo.CurStateOrder

        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            EquipFileInfo.IsFinish = 1
        End If
    End Sub
End Class