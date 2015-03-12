Imports Platform.eAuthorize
Imports eWorkFlow.eFlowDoc

Partial Public Class OutFileDetail
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

    Private _OutFileInfo As OutFileManageInfo
    Private Property OutFileInfo() As OutFileManageInfo
        Get
            If _OutFileInfo Is Nothing Then
                If PKID <> 0 Then
                    _OutFileInfo = OutFileManageDAL.GetInfoByPKID(PKID)
                    DocUniqueID = _OutFileInfo.eFlowDocID.ToString
                ElseIf DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                    _OutFileInfo = OutFileManageDAL.GetInfoByeFlowDocID(DocUniqueID)
                    PKID = _OutFileInfo.PKID
                Else
                    _OutFileInfo = New OutFileManageInfo()

                End If
            End If
            Return _OutFileInfo
        End Get
        Set(ByVal value As OutFileManageInfo)
            _OutFileInfo = value
        End Set
    End Property
    ''' <summary>
    ''' 附件主表PKID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 附件父類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentCategory() As Integer
        Get
            If ViewState(HIDE_ParentCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentCategory) = Value
        End Set
    End Property
    ''' <summary>
    ''' 附件子類別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentSubCategory() As Integer
        Get
            If ViewState(HIDE_ParentSubCategory) Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState(HIDE_ParentSubCategory))
            End If
        End Get
        Set(ByVal Value As Integer)
            ViewState(HIDE_ParentSubCategory) = Value
        End Set
    End Property
    ''' <summary>
    ''' 是否變更 1為變更
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ischange() As Integer
        Get
            If ViewState("ischange") Is Nothing Then
                Return 0
            Else
                Return Convert.ToInt32(ViewState("ischange"))
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState(ischange) = value.ToString
        End Set
    End Property
    '''<summary>
    '''當前請求狀態
    '''</summary>
    Private Property CurType() As String
        Get
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail3.CanUpload = False
            If UserInfo.CurrentUserInstance Is Nothing Then
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail4.CanUpload = False
            End If
            If UserInfo.IsInRoles("LabFileManager") OrElse UserInfo.IsInRoles("qa") Then
                Me.CtlWFActionList1.Visible = True
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail3.CanRemove = True
                Me.UcFileDetail1.CanUpload = True
                Me.UcFileDetail4.CanUpload = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail4.CanRemove = True
            Else
                Me.CtlWFActionList1.Visible = False
                Me.UcFileDetail1.CanUpload = False
                Me.UcFileDetail4.CanUpload = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail4.CanRemove = False

            End If
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail3.ParentID = PKID
          
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 1
            Me.UcFileDetail4.ParentCategory = 1

            Me.UcFileDetail2.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
            Me.UcFileDetail3.FileSize = ConfigurationManager.AppSettings("UploadMaxSize")
            Me.UcFileDetail2.ParentCategory = 1
            Me.UcFileDetail3.ParentCategory = 1
            Select Case CurType
                Case "2"
                    Me.UcFileDetail3.ParentSubCategory = 22
                    Me.UcFileDetail2.ParentSubCategory = 12
                    Me.UcFileDetail1.ParentSubCategory = 12
                    Me.UcFileDetail4.ParentSubCategory = 22
                    Me.Label1.Text = "客戶規格/測試計劃編號管理"
                    Me.Label2.Text = "客戶規格/測試計劃編號"
                    Me.Label3.Text = "名稱"
                    Me.Label14.Text = "規格計劃狀態"
                    Me.yeshu.Visible = False
                    Me.zhangshu.Visible = False
                    Me.laiyuan.Visible = False
                    Me.remark.Visible = False
                Case "3"
                    Me.UcFileDetail3.ParentSubCategory = 23
                    Me.UcFileDetail2.ParentSubCategory = 13

                    Me.UcFileDetail4.ParentSubCategory = 23
                    Me.UcFileDetail1.ParentSubCategory = 13
                    Me.Label1.Text = "軟體管理"
                    Me.biaohao.Visible = False
                    Me.Label3.Text = "軟體名稱"
                    Me.yeshu.Visible = False
                    Me.zhangshu.Visible = False
                    Me.laiyuan.Visible = False
                    Me.syyq.Visible = True
                    Me.yongtu.Visible = True
                    Me.beifendizhi.Visible = True
                    Me.buytime.Visible = True

                Case "4"
                    Me.UcFileDetail3.ParentSubCategory = 24
                    Me.UcFileDetail2.ParentSubCategory = 14
                    Me.UcFileDetail4.ParentSubCategory = 24
                    Me.UcFileDetail1.ParentSubCategory = 14
                    Me.Label1.Text = "說明書管理"
                    Me.biaohao.Visible = False
                    Me.banci.Visible = False
                    Me.yeshu.Visible = False
                    Me.laiyuan.Visible = False
                    Me.ccfangshi.Visible = False

                Case "5"
                    Me.UcFileDetail3.ParentSubCategory = 25
                    Me.UcFileDetail2.ParentSubCategory = 15
                    Me.UcFileDetail4.ParentSubCategory = 25
                    Me.UcFileDetail1.ParentSubCategory = 15
                    Me.Label1.Text = "外來文件管理"
                    Me.ccfangshi.Visible = False

            End Select
            Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
            If Not dt Is Nothing Then
                Me.DPLDepth.DataSource = dt
                Me.DPLDepth.DataTextField = "ParameterText"
                Me.DPLDepth.DataValueField = "ParameterValue1"
                Me.DPLDepth.DataBind()
            End If
            Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("QY")
            If Not dt Is Nothing Then
                Me.DplQuyuLocation.DataSource = dt2
                Me.DplQuyuLocation.DataTextField = "ParameterText"
                Me.DplQuyuLocation.DataValueField = "ParameterValue2"
                Me.DplQuyuLocation.DataBind()
            End If
            BindControlData()
            Me.TxtBuyTime.Attributes.Add("readonly", True)
            Me.TxtBuyTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
        End If
    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))


        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Request.QueryString("Type").ToString
        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
    End Sub
    Private Sub BindControlData()
        If Not OutFileInfo Is Nothing Then
            If PKID <> 0 Then
                'If OutFileInfo.IsFinish = 1 Then
                '    Me.UcFileDetail2.CanUpload = False
                '    Me.UcFileDetail3.CanUpload = False
                '    Me.UcFileDetail2.CanRemove = False
                '    Me.UcFileDetail3.CanRemove = False
                'End If

                Me.UcFileDetail2.FileType = "Other"
                Me.UcFileDetail3.FileType = "Other"
                Me.UcFileDetail3.IsOld = 1
                Me.UcFileDetail2.IsOld = 1

                Me.TxtBackupadd.Text = OutFileInfo.BackAddress
                Me.TxtBuyTime.Text = OutFileInfo.BuyTime
                Me.TxtFenshu.Text = OutFileInfo.FileNum
                Me.TxtFileBH.Text = OutFileInfo.FileBH
                Me.TxtFileName.Text = OutFileInfo.FileName
                Me.TxtLaiyuan.Text = OutFileInfo.FileSource
                Me.TxtRemark.Text = OutFileInfo.Remark
                Me.TxtStandardVersion.Text = OutFileInfo.FileVersion
                Me.TxtUseEquip.Text = OutFileInfo.UseForEquip
                Me.TxtUseFor.Text = OutFileInfo.UseFor
                Me.Txtyeshu.Text = OutFileInfo.FilePageNum
                Me.DPLDepth.SelectedItem.Text = OutFileInfo.FileDept
                Me.DplQuyuLocation.SelectedItem.Text = OutFileInfo.QyLocation
                Select Case OutFileInfo.SaveType
                    Case 0
                        Me.CHBccdzd.Checked = False
                        Me.CHBcczd.Checked = False
                    Case 2
                        Me.CHBccdzd.Checked = True
                    Case 1
                        Me.CHBcczd.Checked = True
                    Case 3
                        Me.CHBcczd.Checked = True
                        Me.CHBccdzd.Checked = True
                End Select

            ElseIf PKID = 0 Then

            End If

            BindHisGrid(PKID)
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 3)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        End If
    End Sub

    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "其他文件發佈流程"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo

    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            If UserInfo.CurrentUserInstance Is Nothing Then
                Return False
            End If
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        If CtlWFActionList1.OnlySave Then
            Dim Returnurl As String = "../Forms/OutFileDetail.aspx?pkid=" + PKID.ToString + "&Type=" + CurType.ToString
            If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
                Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            Response.Redirect(Returnurl)
        Else
            Response.Redirect("../Forms/OutFileList.aspx?Type=" + CurType.ToString)
        End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        If CurDocInfo.IsFinishFlag = True Then
            Me.CtlWFActionList1.DisplaySaveButton(True)
        End If
        If UserInfo.CurrentUserInstance Is Nothing Then
            Me.CtlWFActionList1.DisplaySaveButton(False)
            Me.CtlWFActionList1.DisplayDeleteButton(False)
        End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=outfile&Type={1}", Global_asax.URL_INDEX, CurType)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo
        DocUniqueID = CurDocInfo.DocUniqueID
        OutFileInfo.PKID = PKID
        OutFileInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        OutFileInfo.BackAddress = Me.TxtBackupadd.Text
        If Me.TxtBuyTime.Text <> "" Then
            OutFileInfo.BuyTime = Me.TxtBuyTime.Text
        End If
        OutFileInfo.FileNum = Me.TxtFenshu.Text
        OutFileInfo.QyLocation = Me.DplQuyuLocation.SelectedItem.Text
        OutFileInfo.RecordCreated = DateTime.Now
        OutFileInfo.RecordDeleted = 0
        OutFileInfo.Remark = Me.TxtRemark.Text
        OutFileInfo.FileDept = Me.DPLDepth.SelectedItem.Text
        OutFileInfo.FileName = Me.TxtFileName.Text
        OutFileInfo.FileBH = Me.TxtFileBH.Text
        OutFileInfo.FileSource = Me.TxtLaiyuan.Text

        If CHBccdzd.Checked = False AndAlso CHBcczd.Checked = False Then
            OutFileInfo.SaveType = 3
        End If
        If Me.CHBccdzd.Checked = True Then
            OutFileInfo.SaveType = 2
        End If
        If CHBcczd.Checked = True Then
            OutFileInfo.SaveType = 1
        End If
        If CHBccdzd.Checked = True AndAlso CHBcczd.Checked = True Then
            OutFileInfo.SaveType = 3
        End If
        OutFileInfo.FileVersion = Me.TxtStandardVersion.Text
        OutFileInfo.UseFor = Me.TxtUseFor.Text
        OutFileInfo.UseForEquip = Me.TxtUseEquip.Text
        OutFileInfo.FilePageNum = Me.Txtyeshu.Text
        OutFileInfo.RecordStype = Convert.ToInt32(CurType)
        OutFileInfo.RecordCreated = DateTime.Now
        Dim otherfiledal As OutFileManageDAL = New OutFileManageDAL(OutFileInfo)
        PKID = otherfiledal.Save()


        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 3
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()


        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail3.ParentID = PKID
        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail4.SaveDatatoDataBase()
        Me.UcFileDetail1.SaveDatatoDataBase()
        UcFileDetail2.SaveDatatoDataBase()                  '附加檔案
        UcFileDetail3.SaveDatatoDataBase()                  '文件內容
    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "其他文件發佈流程"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 1
        End Get
    End Property

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            OutFileInfo.StateName = CurDocInfo.NextStateName
            OutFileInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            OutFileInfo.StateName = CurDocInfo.CurStateName
            OutFileInfo.StateOrder = CurDocInfo.CurStateOrder

        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            OutFileInfo.IsFinish = 1
        End If
    End Sub
End Class