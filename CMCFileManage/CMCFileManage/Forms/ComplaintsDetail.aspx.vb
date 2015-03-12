Imports Platform.eAuthorize
Imports eWorkFlow.eFlowDoc

Partial Public Class ComplaintsDetail
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
    Private _CurComplaintsInfo As ComplaintsInfo
    Private Property CurComplaintsInfo() As ComplaintsInfo
        Get
            If _CurComplaintsInfo Is Nothing Then
                If Not PKID = 0 Then
                    _CurComplaintsInfo = ComplaintsDAL.GetInfoByPKID(PKID)
                ElseIf DocUniqueID <> "" AndAlso DocUniqueID <> Guid.NewGuid().ToString Then
                    _CurComplaintsInfo = ComplaintsDAL.GetInfoByDocUniqueID(DocUniqueID)
                    PKID = _CurComplaintsInfo.PKID
                Else
                    _CurComplaintsInfo = New ComplaintsInfo()
                End If
            End If
            Return _CurComplaintsInfo
        End Get
        Set(ByVal value As ComplaintsInfo)

        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            Me.TxtHopeFinishTime.Attributes.Add("readonly", True)
            Me.TxtHopeFinishTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtComplaintsDate.Attributes.Add("readonly", True)
            Me.TxtComplaintsDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtComplaintsDate.Text = DateTime.Now.ToShortDateString
            Me.TxtHopeFinishTime.Text = DateTime.Now.AddDays(2).ToShortDateString
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail3.CanUpload = False
            Me.UcFileDetail4.CanUpload = False
            Me.UcFileDetail5.CanUpload = False

            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail3.ParentID = PKID
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail5.ParentID = PKID
            Me.UcFileDetail1.FileType = "Complaints"
            Me.UcFileDetail2.FileType = "Complaints"
            Me.UcFileDetail3.FileType = "Complaints"
            Me.UcFileDetail4.FileType = "Complaints"
            Me.UcFileDetail5.FileType = "Complaints"
            Me.UcFileDetail1.ParentCategory = 5
            Me.UcFileDetail2.ParentCategory = 5
            Me.UcFileDetail3.ParentCategory = 5
            Me.UcFileDetail4.ParentCategory = 5
            Me.UcFileDetail5.ParentCategory = 5
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail2.ParentSubCategory = 2
            Me.UcFileDetail3.ParentSubCategory = 3
            Me.UcFileDetail4.ParentSubCategory = 4
            Me.UcFileDetail5.ParentSubCategory = 5

            Me.UcFileDetail6.ParentID = PKID
            Me.UcFileDetail7.ParentID = PKID
            Me.UcFileDetail8.ParentID = PKID
            Me.UcFileDetail9.ParentID = PKID
            Me.UcFileDetail10.ParentID = PKID
           
            Me.UcFileDetail6.ParentCategory = 5
            Me.UcFileDetail7.ParentCategory = 5
            Me.UcFileDetail8.ParentCategory = 5
            Me.UcFileDetail9.ParentCategory = 5
            Me.UcFileDetail10.ParentCategory = 5
            Me.UcFileDetail6.ParentSubCategory = 1
            Me.UcFileDetail7.ParentSubCategory = 2
            Me.UcFileDetail8.ParentSubCategory = 3
            Me.UcFileDetail9.ParentSubCategory = 4
            Me.UcFileDetail10.ParentSubCategory = 5
            BindDept()
            BindControlData()

        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("PKID") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("PKID"))
        End If
        If Not Request.QueryString("eFlowDocID") Is Nothing Then
            DocUniqueID = Request.QueryString("eFlowDocID").ToString
        End If
    End Sub
    Private Sub BindControlData()
        If Not UserInfo.CurrentUserInstance Is Nothing Then
            If Not CurComplaintsInfo Is Nothing Then
                If PKID = 0 Then
                    Me.UcFileDetail6.CanRemove = True
                    Me.UcFileDetail7.CanRemove = True
                    Me.UcFileDetail8.CanRemove = True
                    Me.UcFileDetail9.CanRemove = True
                    Me.UcFileDetail10.CanRemove = True

                    Me.LbRecordNO.Text = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + "-TS???"
                    Me.TxtComplaintsPerson.Text = UserInfo.CurrentUserCHName
                    Me.TxtEmail.Text = UserInfo.CurrentEmail
                    Me.TxtPhone.Text = UserInfo.CurrentUserInstance.Telphone
                Else

                    Me.UcFileDetail1.IsOld = 1
                    Me.UcFileDetail2.IsOld = 1
                    Me.UcFileDetail3.IsOld = 1
                    Me.UcFileDetail4.IsOld = 1
                    Me.UcFileDetail5.IsOld = 1

                    If UserInfo.IsInRoles("QA") Then
                        Me.UcFileDetail6.CanRemove = True
                        Me.UcFileDetail7.CanRemove = True
                        Me.UcFileDetail8.CanRemove = True
                        Me.UcFileDetail9.CanRemove = True
                        Me.UcFileDetail10.CanRemove = True
                    End If
                    Me.LbRecordNO.Text = CurComplaintsInfo.RecordNO
                    Me.TxtApproved.Text = CurComplaintsInfo.Approved
                    Me.TxtComplaintsDate.Text = CurComplaintsInfo.ComplaintsDate
                    Me.TxtComplaintsDept.Text = CurComplaintsInfo.ComplaintsDept
                    Me.TxtComplaintsDesc.Text = CurComplaintsInfo.ComplaintsDesc
                    Me.TxtComplaintsDetailed.Text = CurComplaintsInfo.ComplaintsDetailed
                    Me.TxtComplaintsPerson.Text = CurComplaintsInfo.ComlaintsPerson
                    Me.TxtComplaintsPosition.Text = CurComplaintsInfo.ComplaintsPosition
                    Me.TxtEmail.Text = CurComplaintsInfo.Email
                    Me.TxtFindings.Text = CurComplaintsInfo.Findings
                    Me.TxtHinding.Text = CurComplaintsInfo.Hinding
                    Me.TxtHopeFinishTime.Text = CurComplaintsInfo.HopeFinishTime
                    Me.TxtImprove.Text = CurComplaintsInfo.Improve
                    Me.TxtPhone.Text = CurComplaintsInfo.Phone
                    Me.TxtReasons.Text = CurComplaintsInfo.Reasons
                    Me.TxtUnderTake.Text = CurComplaintsInfo.UnderTake
                    Me.DPLQuLocation.SelectedIndex = Me.DPLQuLocation.Items.IndexOf(Me.DPLQuLocation.Items.FindByText(CurComplaintsInfo.QyuLocation))
                    Dim bedepindex As Integer = Me.DPLBeComplaintsDept.Items.IndexOf(Me.DPLBeComplaintsDept.Items.FindByText(CurComplaintsInfo.BeComplaintsDept))
                    If bedepindex > -1 Then
                        Me.DPLBeComplaintsDept.SelectedIndex = bedepindex
                    Else
                        Me.DPLBeComplaintsDept.SelectedItem.Text = CurComplaintsInfo.BeComplaintsDept
                    End If

                    Me.RdoIsfinished.SelectedValue = Me.RdoIsfinished.Items.IndexOf(Me.RdoIsfinished.Items.FindByValue(CurComplaintsInfo.IsFinished))

                End If
            End If
        End If

    End Sub
    Private Sub BindDept()
        Dim dt1 As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt1 Is Nothing Then
            Me.DPLBeComplaintsDept.DataSource = dt1
            Me.DPLBeComplaintsDept.DataTextField = "ParameterText"
            Me.DPLBeComplaintsDept.DataValueField = "ParameterText"
            Me.DPLBeComplaintsDept.DataBind()
        End If
        Dim dt2 As DataTable = QC_UserParameterDAL.GetInfoByCategory("CQ")
        If Not dt2 Is Nothing Then
            Me.DPLQuLocation.DataSource = dt2
            Me.DPLQuLocation.DataTextField = "ParameterText"
            Me.DPLQuLocation.DataValueField = "DispalyOrder"
            Me.DPLQuLocation.DataBind()
        End If
    End Sub

  
#Region "Eflow"

    Public ReadOnly Property BusniessName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.BusniessName
        Get
            Return "QCComplaints"
        End Get
    End Property

    Public Sub DeleteDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.DeleteDocInfo
        ComplaintsDAL.Delete(PKID)
    End Sub

    Public ReadOnly Property IsUseFlow() As Boolean Implements eWorkFlow.eFlowDoc.IDocInfo.IsUseFlow
        Get
            Return True
        End Get
    End Property

    Public Sub LeaveDocInfo() Implements eWorkFlow.eFlowDoc.IDocInfo.LeaveDocInfo
        'If CtlWFActionList1.OnlySave Then
        '    Dim Returnurl As String = "../Forms/ComplaintsDetail.aspx?pkid=" + PKID.ToString
        '    If DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString Then
        '        Returnurl += "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
        '    End If
        '    Response.Redirect(Returnurl)
        'Else
        Response.Redirect("../Forms/ComplaintsList.aspx")
        'End If
    End Sub

    Public Sub LoadDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem) Implements eWorkFlow.eFlowDoc.IDocInfo.LoadDocInfo
        CtlWFActionList1.IsUseFlow = False
        'If CurDocInfo.CurStateOrder > 1 Then
        '    For i As Integer = 1 To 5
        '        Dim ctr As HtmlControls.HtmlTableRow = CType(Me.FindControl("cb" + i.ToString), HtmlControls.HtmlTableRow)
        '        ctr.Visible = True
        '    Next
        'End If
        CtlWFActionList1.CurURL = String.Format("{0}?PageType=complaints", Global_asax.URL_INDEX)  '往框架中跳
    End Sub

    Public Sub SaveDocInfo(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal CommandName As Platform.eWorkFlow.Model.Enm_ActionType) Implements eWorkFlow.eFlowDoc.IDocInfo.SaveDocInfo

        CurComplaintsInfo.PKID = PKID
        DocUniqueID = CurDocInfo.DocUniqueID
        CurComplaintsInfo.eFlowDocID = New Guid(CurDocInfo.DocUniqueID)
        CurComplaintsInfo.Approved = Me.TxtApproved.Text
        CurComplaintsInfo.BeComplaintsDept = Me.DPLBeComplaintsDept.SelectedItem.Text
        CurComplaintsInfo.ComlaintsPerson = Me.TxtComplaintsPerson.Text
        CurComplaintsInfo.ComplaintsDate = Me.TxtComplaintsDate.Text
        CurComplaintsInfo.ComplaintsDept = Me.TxtComplaintsDept.Text
        CurComplaintsInfo.ComplaintsDesc = Me.TxtComplaintsDesc.Text
        CurComplaintsInfo.ComplaintsDetailed = Me.TxtComplaintsDetailed.Text
        CurComplaintsInfo.ComplaintsPosition = Me.TxtComplaintsPosition.Text
        CurComplaintsInfo.Email = Me.TxtEmail.Text
        CurComplaintsInfo.Findings = Me.TxtFindings.Text
        CurComplaintsInfo.Hinding = Me.TxtHinding.Text
        CurComplaintsInfo.HopeFinishTime = Me.TxtHopeFinishTime.Text
        CurComplaintsInfo.Improve = Me.TxtImprove.Text
        CurComplaintsInfo.Phone = Me.TxtPhone.Text
        CurComplaintsInfo.QyuLocation = Me.DPLQuLocation.SelectedItem.Text
        CurComplaintsInfo.Reasons = Me.TxtReasons.Text
        CurComplaintsInfo.RecordCreated = DateTime.Now
        CurComplaintsInfo.RecordDeleted = 0
        CurComplaintsInfo.IsFinished = Me.RdoIsfinished.SelectedValue
        CurComplaintsInfo.UnderTake = Me.TxtUnderTake.Text
        If Me.LbRecordNO.Text.Contains("?") Then
            Dim lsm As Integer = TableBMHDAL.GetMaxlsmbyCategory("QQTS" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DPLQuLocation.SelectedValue.ToString) + 1

            Dim tableInfo As TableBMHInfo = New TableBMHInfo()
            tableInfo.PKID = 0
            tableInfo.Category = "QQTS" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DPLQuLocation.SelectedValue.ToString  'QQ類別年碼區域
            tableInfo.BMH = lsm
            tableInfo.RecordPKID = PKID
            tableInfo.YMD = DateTime.Now.ToString

            Dim tabledal As TableBMHDAL = New TableBMHDAL(tableInfo)
            tabledal.Save()
            CurComplaintsInfo.RecordNO = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DPLQuLocation.SelectedValue.ToString + "-TS" + lsm.ToString("000")
        Else
            CurComplaintsInfo.RecordNO = Me.LbRecordNO.Text
        End If
        Dim CurComplaintsDal As ComplaintsDAL = New ComplaintsDAL(CurComplaintsInfo)
        PKID = CurComplaintsDal.Save()

        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail3.ParentID = PKID
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail5.ParentID = PKID
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.SaveDatatoDataBase()
        Me.UcFileDetail3.SaveDatatoDataBase()
        Me.UcFileDetail4.SaveDatatoDataBase()
        Me.UcFileDetail5.SaveDatatoDataBase()

    End Sub

    Public ReadOnly Property TemplateName() As String Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateName
        Get
            Return "QCComplaints"
        End Get
    End Property

    Public ReadOnly Property TemplateVersion() As Integer Implements eWorkFlow.eFlowDoc.IDocInfo.TemplateVersion
        Get
            Return 1
        End Get
    End Property
#End Region

    Private Sub CtlWFActionList1_Postopen(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.BaseEventArgs) Handles CtlWFActionList1.Postopen
        Dim SaveScript As StringBuilder = New StringBuilder()

        SaveScript.Append("if( $('#TxtComplaintsDept').val()==''){ alert('請填寫投訴單位');return false;}")
        SaveScript.Append("if( $('#TxtComplaintsPerson').val()==''){ alert('請填寫投訴人');return false;}")
        SaveScript.Append("if( $('#TxtComplaintsDate').val()==''){ alert('請填投訴時間');return false;}")
        SaveScript.Append("if( $('#TxtHopeFinishTime').val()==''){ alert('請填寫希望完成時間');return false;}")
        SaveScript.Append("if( $('#TxtComplaintsDesc').val()==''){ alert('請填寫投訴事項簡述');return false;}")
        CtlWFActionList1.AduitScript = SaveScript.ToString
        CtlWFActionList1.SaveScript = SaveScript.ToString
        Me.CtlWFActionList1.IsMergeUser = True
    End Sub

    Private Sub CtlWFActionList1_Querysave(ByVal CurDocInfo As eWorkFlow.eFlowDoc.DocInfoSystem, ByVal e As eWorkFlow.eFlowDoc.QuerySaveDocEventArgs) Handles CtlWFActionList1.Querysave
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Approve _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Rejection _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Revoke _
           OrElse e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CurComplaintsInfo.StateName = CurDocInfo.NextStateName
            CurComplaintsInfo.StateOrder = CurDocInfo.NextStateOrder

        Else
            CurComplaintsInfo.StateName = CurDocInfo.CurStateName
            CurComplaintsInfo.StateOrder = CurDocInfo.CurStateOrder

        End If
        If e.CommandName = Platform.eWorkFlow.Model.Enm_ActionType.Finish Then
            CurComplaintsInfo.IsFinished = 1
        Else
            CurComplaintsInfo.IsFinished = 0
        End If
    End Sub
End Class