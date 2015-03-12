Imports System.Web.Services
Imports Platform.eAuthorize

Partial Public Class ErrorReportDetail
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
    Private _ErrorReportinfo As ErrorReportInfo
    Private Property ErrorReport() As ErrorReportInfo
        Get
            If _ErrorReportinfo Is Nothing Then
                If PKID <> 0 Then
                    _ErrorReportinfo = ErrorReportDAL.GetInfoByPKID(PKID)
                Else
                    _ErrorReportinfo = New ErrorReportInfo()
                End If
            End If
            Return _ErrorReportinfo
        End Get
        Set(ByVal value As ErrorReportInfo)
            _ErrorReportinfo = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetRequestParam()
            BindDPL()
            Me.TxtFinishTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtReportTime.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.TxtYzFinishdate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true});")
            Me.UcFileDetail1.CanUpload = False
            Me.UcFileDetail2.CanUpload = False
            Me.UcFileDetail3.CanUpload = False

            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail2.ParentID = PKID
            Me.UcFileDetail3.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 3
            Me.UcFileDetail2.ParentCategory = 3
            Me.UcFileDetail3.ParentCategory = 3
            Me.UcFileDetail1.ParentSubCategory = 1
            Me.UcFileDetail2.ParentSubCategory = 2
            Me.UcFileDetail3.ParentSubCategory = 3
            Me.UcFileDetail4.ParentID = PKID
            Me.UcFileDetail5.ParentID = PKID
            Me.UcFileDetail6.ParentID = PKID
            Me.UcFileDetail4.ParentCategory = 3
            Me.UcFileDetail5.ParentCategory = 3
            Me.UcFileDetail6.ParentCategory = 3
            Me.UcFileDetail4.ParentSubCategory = 1
            Me.UcFileDetail5.ParentSubCategory = 2
            Me.UcFileDetail6.ParentSubCategory = 3
            BindControlData()
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
            Me.DPLDept.DataSource = dt
            Me.DPLDept.DataTextField = "ParameterText"
            Me.DPLDept.DataValueField = "ParameterText"
            Me.DPLDept.DataBind()
        End If
    End Sub
    Private Sub BindControlData()
        If Not ErrorReport Is Nothing Then
            If UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("QALEADER") Then
                Me.LinkEdit.Visible = True
                Me.UcFileDetail1.CanRemove = True
                Me.UcFileDetail2.CanRemove = True
                Me.UcFileDetail3.CanRemove = True
                Me.UcFileDetail4.CanRemove = True
                Me.UcFileDetail5.CanRemove = True
                Me.UcFileDetail6.CanRemove = True
                Me.UcFileDetail4.CanUpload = True
                Me.UcFileDetail5.CanUpload = True
                Me.UcFileDetail6.CanUpload = True
            Else
                Me.LinkEdit.Visible = False
                Me.UcFileDetail1.CanRemove = False
                Me.UcFileDetail2.CanRemove = False
                Me.UcFileDetail3.CanRemove = False
                Me.UcFileDetail4.CanUpload = False
                Me.UcFileDetail5.CanUpload = False
                Me.UcFileDetail6.CanUpload = False
            End If
            If PKID <> 0 Then


                Me.UcFileDetail1.IsOld = 1
                Me.UcFileDetail2.IsOld = 1
                Me.UcFileDetail3.IsOld = 1
                Me.UcFileDetail3.FileType = "Errorreport"
                Me.UcFileDetail2.FileType = "Errorreport"
                Me.UcFileDetail1.FileType = "Errorreport"

                Me.TxtQulocation.Text = ErrorReport.Qulocation
                Me.HidQulocation.Value = ErrorReport.Qulocation
                Me.TxtFinishAduit.Text = ErrorReport.FinishAduit
                Me.TxtAduiter.Text = ErrorReport.Aduiter
                Me.TxtApproved.Text = ErrorReport.Approved
                Me.TxtApprovedzg.Text = ErrorReport.Approvedzg
                Me.TxtBH.Text = ErrorReport.ReportBH
                Me.TxtDescription.Text = ErrorReport.Description
                Me.TxtFindOut.Text = ErrorReport.FindOut
                Me.TxtFinishTime.Text = ErrorReport.FinishTime
                Me.TxtFolwer.Text = ErrorReport.Follower
                Me.TxtQulocation.Text = ErrorReport.Qulocation
                Me.TxtReady.Text = ErrorReport.Ready
                Me.TxtReason.Text = ErrorReport.Reason
                Me.TxtReportTime.Text = ErrorReport.ReportDate
                Me.TxtResult.Text = ErrorReport.Result
                Me.TxtSpecTitle.Text = ErrorReport.SpecTitle
                Me.TxtSpecVersion.Text = ErrorReport.SpecVersion
                Me.TxtVertigyer.Text = ErrorReport.Vertigyer
                Me.DPLDept.SelectedItem.Text = ErrorReport.Dept
                Me.TxtYzFinishdate.Text = ErrorReport.Extend1
                Me.RDOAppsec.SelectedValue = ErrorReport.AppSec
                Me.RDOVertifyResult.SelectedValue = ErrorReport.VertifyResult

                Me.TxtQulocation.Enabled = False
                Me.TxtFinishAduit.Enabled = False
                Me.TxtAduiter.Enabled = False
                Me.TxtApproved.Enabled = False
                Me.TxtApprovedzg.Enabled = False
                Me.TxtBH.Enabled = False
                Me.TxtDescription.Enabled = False
                Me.TxtFindOut.Enabled = False
                Me.TxtFinishTime.Enabled = False
                Me.TxtFolwer.Enabled = False
                Me.TxtQulocation.Enabled = False
                Me.TxtReady.Enabled = False
                Me.TxtReason.Enabled = False
                Me.TxtReportTime.Enabled = False
                Me.TxtResult.Enabled = False
                Me.TxtSpecTitle.Enabled = False
                Me.TxtSpecVersion.Enabled = False
                Me.TxtVertigyer.Enabled = False
                Me.DPLDept.Enabled = False
                Me.RDOAppsec.Enabled = False
                Me.RDOVertifyResult.Enabled = False
            ElseIf PKID = 0 Then
                If UserInfo.IsInRoles("QA") OrElse UserInfo.IsInRoles("QALEADER") Then
                    Me.LinkEdit.Visible = False
                    Me.LinkSave.Visible = True
                Else
                    Me.LinkEdit.Visible = False
                End If

            End If
        End If
    End Sub
    <WebMethod()> _
    Public Shared Function GetQuloctionList() As List(Of DictionaryEntry)
        Dim mLocations As List(Of DictionaryEntry) = QC_UserParameterDAL.GetDicInfoByCategory("CQ")

        Return mLocations

    End Function

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.LinkSave.Visible = True
        Me.LinkEdit.Visible = False

        Me.TxtQulocation.Enabled = True
        Me.TxtFinishAduit.Enabled = True
        Me.TxtAduiter.Enabled = True
        Me.TxtApproved.Enabled = True
        Me.TxtApprovedzg.Enabled = True
        Me.TxtBH.Enabled = True
        Me.TxtDescription.Enabled = True
        Me.TxtFindOut.Enabled = True
        Me.TxtFinishTime.Enabled = True
        Me.TxtFolwer.Enabled = True
        Me.TxtQulocation.Enabled = True
        Me.TxtReady.Enabled = True
        Me.TxtReason.Enabled = True
        Me.TxtReportTime.Enabled = True
        Me.TxtResult.Enabled = True
        Me.TxtSpecTitle.Enabled = True
        Me.TxtSpecVersion.Enabled = True
        Me.TxtVertigyer.Enabled = True
        Me.DPLDept.Enabled = True
        Me.RDOVertifyResult.Enabled = True
        Me.RDOAppsec.Enabled = True
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        ErrorReport.PKID = PKID
        ErrorReport.Aduiter = Me.TxtAduiter.Text
        ErrorReport.Approved = Me.TxtApproved.Text
        ErrorReport.Approvedzg = Me.TxtApprovedzg.Text
        ErrorReport.AppSec = Me.RDOAppsec.SelectedValue
        ErrorReport.Dept = Me.DPLDept.SelectedItem.Text
        ErrorReport.Description = Me.TxtDescription.Text
        ErrorReport.FindOut = Me.TxtFindOut.Text
        ErrorReport.FinishAduit = Me.TxtFinishAduit.Text
        ErrorReport.FinishTime = Me.TxtFinishTime.Text
        ErrorReport.Follower = Me.TxtFolwer.Text
        ErrorReport.Qulocation = Me.HidQulocation.Value
        ErrorReport.Ready = Me.TxtReady.Text
        ErrorReport.Reason = Me.TxtReason.Text
        ErrorReport.RecordCreated = DateTime.Now
        ErrorReport.RecordDeleted = 0
        ErrorReport.ReportBH = Me.TxtBH.Text
        ErrorReport.ReportDate = Me.TxtReportTime.Text
        ErrorReport.Result = Me.TxtResult.Text
        ErrorReport.SpecTitle = Me.TxtSpecTitle.Text
        ErrorReport.SpecVersion = Me.TxtSpecVersion.Text
        ErrorReport.VertifyResult = Me.RDOVertifyResult.SelectedValue
        ErrorReport.Vertigyer = Me.TxtVertigyer.Text
        ErrorReport.Extend1 = Me.TxtYzFinishdate.Text
        Dim errordal As ErrorReportDAL = New ErrorReportDAL(ErrorReport)
        PKID = errordal.Save()

        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail2.ParentID = PKID
        Me.UcFileDetail3.ParentID = PKID
        Me.UcFileDetail1.SaveDatatoDataBase()
        Me.UcFileDetail2.SaveDatatoDataBase()
        Me.UcFileDetail3.SaveDatatoDataBase()
        Me.UcFileDetail4.ParentID = PKID
        Me.UcFileDetail5.ParentID = PKID
        Me.UcFileDetail6.ParentID = PKID
        Me.UcFileDetail4.SaveDatatoDataBase()
        Me.UcFileDetail5.SaveDatatoDataBase()
        Me.UcFileDetail6.SaveDatatoDataBase()

    End Sub

    Protected Sub LinkLeave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkLeave.Click
        Response.Redirect("ErrorReportList.aspx")
    End Sub


End Class