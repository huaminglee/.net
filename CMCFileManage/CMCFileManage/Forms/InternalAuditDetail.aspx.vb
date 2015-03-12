Imports Platform.eAuthorize

Partial Public Class InternalAuditDetail
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _RequestType As String = "ViewState:Type"
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
    Private Property CurType() As String
        Get
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
        End Set
    End Property
    Private _InternalPlanandReport As InternalAuditPlanandReportInfo
    Private Property InternalPlanandReport() As InternalAuditPlanandReportInfo
        Get
            If _InternalPlanandReport Is Nothing Then
                If PKID <> 0 Then
                    _InternalPlanandReport = InternalAuditPlanandReportDAL.GetInfoByPKID(PKID)
                Else
                    _InternalPlanandReport = New InternalAuditPlanandReportInfo()
                End If
            End If
            Return _InternalPlanandReport
        End Get
        Set(ByVal value As InternalAuditPlanandReportInfo)
            _InternalPlanandReport = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            Select Case CurType
                Case "1"
                    Me.LBTitle.Text = "內審計劃"
                Case "2"
                    Me.LBTitle.Text = "內審報告"
                Case "3"
                    Me.LBTitle.Text = "管理評審"
                    Me.qulocation.Visible = False
            End Select
            BindDPL()
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 2
            Me.UcFileDetail1.ParentSubCategory = 0
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail2.ParentCategory = 2
            Me.UcFileDetail2.ParentSubCategory = 0
            BindControlData()
            Me.TXTdate.Attributes.Add("readonly", True)
            Me.TXTdate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
        End If

    End Sub
    Private Sub GetRequestParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString(Global_asax.QUERY_APPLICANTIDX))


        End If
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Request.QueryString("Type").ToString
        End If
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
            Me.DPLqyulocation.DataValueField = "DispalyOrder"
            Me.DPLqyulocation.DataBind()
            Me.DPLqyulocation.SelectedValue = "2"
        End If
    End Sub
    Private Sub BindControlData()
        If UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("QALEADER") Then
            Me.LinkEdit.Visible = True
            Me.UcFileDetail1.CanRemove = True
            Me.UcFileDetail2.CanRemove = True
            Me.UcFileDetail2.CanUpload = True
        Else
            Me.LinkEdit.Visible = False
            Me.UcFileDetail1.CanRemove = False
            Me.UcFileDetail2.CanRemove = False
            Me.UcFileDetail2.CanUpload = False
        End If
        If PKID <> 0 Then

            Me.UcFileDetail1.IsOld = 1
            Me.UcFileDetail1.FileType = "Internam"
            Me.LbRecordNO.Text = InternalPlanandReport.RecordNO
            Me.TXTdate.Text = InternalPlanandReport.FormulDate
            Me.TXTname.Text = InternalPlanandReport.Name
            Me.TXTUser.Text = InternalPlanandReport.FprmilUser
            Me.DPLDept.SelectedItem.Text = InternalPlanandReport.FormulDept
            Me.DPLqyulocation.SelectedItem.Text = InternalPlanandReport.Qulocation

            Me.TXTdate.Enabled = False
            Me.TXTname.Enabled = False
            Me.TXTUser.Enabled = False
            Me.DPLDept.Enabled = False
            Me.DPLqyulocation.Enabled = False
        Else
            Select Case CurType
                Case "1"
                    Me.LbRecordNO.Text = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + "-PLN??"
                    Me.LbdoDate.Text = "制定日期"
                Case "2"
                    Me.LbRecordNO.Text = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + "-REP??"
                Case "3"
                    Me.LbRecordNO.Text = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + "-MA???"
                    Me.LbdoDate.Text = "制定日期"
            End Select

            Me.LinkEdit.Visible = False
            Me.LinkSave.Visible = True
        End If
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.LinkSave.Visible = True
        Me.LinkEdit.Visible = False
        Me.TXTdate.Enabled = True
        Me.TXTname.Enabled = True
        Me.TXTUser.Enabled = True
        Me.DPLDept.Enabled = True
        Me.DPLqyulocation.Enabled = True
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        InternalPlanandReport.PKID = PKID
        InternalPlanandReport.Name = Me.TXTname.Text

        InternalPlanandReport.Qulocation = Me.DPLqyulocation.SelectedItem.Text
        If CurType = 3 Then
            InternalPlanandReport.Qulocation = "華南檢測中心"
        End If
        InternalPlanandReport.RecordDeleted = 0
        InternalPlanandReport.FprmilUser = Me.TXTUser.Text
        If Me.LbRecordNO.Text.Contains("?") Then
            Dim lsm As Integer
            Dim CATE As String = String.Empty
            If CurType = 1 Then
                CATE = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DPLqyulocation.SelectedValue.ToString + "-PLN"
            ElseIf CurType = 2 Then
                CATE = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + Me.DPLqyulocation.SelectedValue.ToString + "-REP"
            ElseIf CurType = 3 Then
                CATE = "QQ" + DateTime.Now.Year.ToString.Substring(2, 2) + "2-MA"
            End If

            lsm = TableBMHDAL.GetMaxlsmbyCategory(CATE) + 1

            Dim tableInfo As TableBMHInfo = New TableBMHInfo()
            tableInfo.PKID = 0
            tableInfo.Category = CATE   'QQ類別年碼區域
            tableInfo.BMH = lsm
            tableInfo.RecordPKID = PKID
            tableInfo.YMD = DateTime.Now.ToString

            Dim tabledal As TableBMHDAL = New TableBMHDAL(tableInfo)
            tabledal.Save()
            If CurType = 3 Then
                InternalPlanandReport.RecordNO = Me.LbRecordNO.Text.Substring(0, LbRecordNO.Text.Length - 6) + "2" + "-MA" + (lsm).ToString("000")
            ElseIf CurType = 2 Then
                InternalPlanandReport.RecordNO = Me.LbRecordNO.Text.Substring(0, LbRecordNO.Text.Length - 6) + Me.DPLqyulocation.SelectedValue.ToString + "-REP" + (lsm).ToString("00")
            ElseIf CurType = 1 Then

                InternalPlanandReport.RecordNO = Me.LbRecordNO.Text.Substring(0, LbRecordNO.Text.Length - 6) + Me.DPLqyulocation.SelectedValue.ToString + "-PLN" + (lsm).ToString("00")
            End If


        Else
            InternalPlanandReport.RecordNO = Me.LbRecordNO.Text
        End If
        InternalPlanandReport.RecordType = CurType
        InternalPlanandReport.FormulDept = Me.DPLDept.SelectedItem.Text
        InternalPlanandReport.FormulDate = Me.TXTdate.Text
        If PKID = 0 Then
            InternalPlanandReport.RecordCreated = DateTime.Now
        End If

        Dim internaldal As InternalAuditPlanandReportDAL = New InternalAuditPlanandReportDAL(InternalPlanandReport)
        PKID = internaldal.Save()

        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail1.ParentCategory = 2
        Me.UcFileDetail1.ParentSubCategory = 0
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail2.SaveDatatoDataBase()
        Response.Redirect("../Forms/InternalAuditList.aspx?Type=" + CurType)
    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("../Forms/InternalAuditList.aspx?Type=" + CurType)
    End Sub
End Class