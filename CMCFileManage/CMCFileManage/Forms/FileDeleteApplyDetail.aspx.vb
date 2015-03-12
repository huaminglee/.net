Imports eWorkFlow.eFlowDoc
Imports Platform.eAuthorize

Partial Public Class FileDeleteApplyDetail
    Inherits System.Web.UI.Page
    Implements IDocInfo
#Region "Const"
    Private Const _RequestType As String = "ViewState:Type"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const HIDE_DOCUNIQUEID_KEY As String = "ViewState:DocUniqueID"
    Private ReadOnly HIDE_ParentID = "ViewState:ParentID"
    Private ReadOnly HIDE_ParentCategory = "ViewState:ParentCategory"
    Private ReadOnly HIDE_ParentSubCategory = "ViewState:ParentSubCategory"
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
    Private _DeleteFileInfo As QC_FileDeleteInfoInfo
    Private Property DeleteFileInfo() As QC_FileDeleteInfoInfo
        Get
            If _DeleteFileInfo Is Nothing Then
                If PKID <> 0 Then
                    _DeleteFileInfo = QC_FileDeleteInfoDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _DeleteFileInfo.eFlowDocID.ToString
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                    _DeleteFileInfo = QC_FileDeleteInfoDAL.GetInfoByeFlowDocID(DocUniqueID)
                    PKID = _DeleteFileInfo.PKID
                Else
                    _DeleteFileInfo = New QC_FileDeleteInfoInfo()
                End If
            End If
            Return _DeleteFileInfo
        End Get
        Set(ByVal value As QC_FileDeleteInfoInfo)
            _DeleteFileInfo = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
            If Not dt Is Nothing Then
                Me.DPLDepth.DataSource = dt
                Me.DPLDepth.DataTextField = "ParameterText"
                Me.DPLDepth.DataValueField = "ParameterText"
                Me.DPLDepth.DataBind()
            End If
            BindConttrolData()
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))
        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If

    End Sub
    Private Sub BindConttrolData()
        If Not DeleteFileInfo Is Nothing Then
            If PKID <> 0 Then
                Me.TxtApplyer.Text = DeleteFileInfo.ApplyUser
                Me.TxtFileBH.Text = DeleteFileInfo.FileBH
                Me.TxtFilename.Text = DeleteFileInfo.FileName
                Me.TxtReason.Text = DeleteFileInfo.DeleteReason
                Me.DPLDepth.SelectedItem.Text = DeleteFileInfo.FileDept
                Me.DPLFileCategory.SelectedItem.Text = DeleteFileInfo.FileType
                Me.LBshenhe.Text = DeleteFileInfo.AduitUser
                Me.LBpinbao.Text = DeleteFileInfo.QuanlityUser
                Me.LBApplyDate.Text = DeleteFileInfo.RecordCreated
                Me.TxtRemark.Text = DeleteFileInfo.Extend1
                If DeleteFileInfo.Extend10 <> "" Then
                    Me.ctlWFHistory1.Visible = False
                    Me.GridView1.Visible = True
                    Dim dt1 As DataTable = SignRecordDAL.GetInfoByRecordNo(DeleteFileInfo.Extend10)
                    Me.GridView1.DataSource = dt1
                    Me.GridView1.DataBind()
                End If
            End If
        Else
            Me.LBApplyDate.Text = DateTime.Now.ToShortDateString()
        End If
    End Sub
#Region "Eflow"
    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "QC文件刪除流程"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        QC_FileDeleteInfoDAL.Delete(PKID)
    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Forms/FileDeleteApplyDetail.aspx?pkid=" + PKID.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Forms/FileDeleteApplyList.aspx")
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If DeleteFileInfo.IsFinish = 1 Then
            Me.CtlWFActionList1.DisplayDeleteButton(False)
            Me.CtlWFActionList1.DisplaySaveButton(False)
            Me.CtlWFActionList1.DisplayManagerButton(False)
            Me.CtlWFActionList1.IsUseFlow = False
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=filedelete", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        DeleteFileInfo.PKID = PKID
        DeleteFileInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)

        DeleteFileInfo.ApplyUser = Me.TxtApplyer.Text
        DeleteFileInfo.DeleteReason = Me.TxtReason.Text
        DeleteFileInfo.FileBH = Me.TxtFileBH.Text
        DeleteFileInfo.FileDept = Me.DPLDepth.SelectedItem.Text
        DeleteFileInfo.FileName = Me.TxtFilename.Text
        DeleteFileInfo.FileType = Me.DPLFileCategory.SelectedItem.Text
        DeleteFileInfo.Extend1 = Me.TxtRemark.Text
        If PKID = 0 Then
            DeleteFileInfo.RecordCreated = DateTime.Now
        Else
            DeleteFileInfo.RecordCreated = Me.LBApplyDate.Text
        End If

        DeleteFileInfo.RecordNO = 1                '未用
        Dim DeleteFileDal As New QC_FileDeleteInfoDAL(DeleteFileInfo)
        DeleteFileDal.Save()
    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "QC文件刪除流程"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 1
        End Get
    End Property
#End Region
#Region "CtlWFActionList"
    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            DeleteFileInfo.StateName = CurDocInfo.NextStateName
            DeleteFileInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            DeleteFileInfo.StateName = CurDocInfo.CurStateName
            DeleteFileInfo.StateOrder = CurDocInfo.CurStateOrder
        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            DeleteFileInfo.IsFinish = 1
        ElseIf e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve Then
            Select Case CurDocInfo.CurStateName
                Case "審核"
                    DeleteFileInfo.AduitUser = UserInfo.CurrentUserCHName
                Case "品保結案"
                    DeleteFileInfo.QuanlityUser = UserInfo.CurrentUserCHName + DateTime.Now.ToShortDateString
            End Select
        End If
    End Sub
#End Region


   
End Class