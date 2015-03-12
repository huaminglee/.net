Imports Platform.eAuthorize

Partial Public Class ImportantGoodsDetail
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
#End Region
#Region "Properties"
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
    Private _CurImportantGoodsInfo As ImportantGoodsInfo
    Private Property CurImportantGoodsInfo() As ImportantGoodsInfo
        Get
            If _CurImportantGoodsInfo Is Nothing Then
                If PKID <> 0 Then
                    _CurImportantGoodsInfo = ImportantGoodsDAL.GetInfoByPKID(PKID)
                Else
                    _CurImportantGoodsInfo = New ImportantGoodsInfo()
                End If
            End If
            Return _CurImportantGoodsInfo
        End Get
        Set(ByVal value As ImportantGoodsInfo)
            _CurImportantGoodsInfo = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParan()
            BindDPL()
            BindControlData()
            If UserInfo.IsInRoles("LabFileManager") Then
                Me.BtnSave.Visible = True
            Else
                Me.BtnSave.Visible = False
            End If
        End If
    End Sub
    Private Sub GetParan()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = Convert.ToInt32(Request.QueryString("pkid"))
        End If
    End Sub
    Private Sub BindDPL()
        Dim dt As DataTable = QC_UserParameterDAL.GetInfoByCategory("Dept")
        If Not dt Is Nothing Then
            Me.DplLab.DataSource = dt
            Me.DplLab.DataTextField = "ParameterText"
            Me.DplLab.DataValueField = "ParameterValue1"
            Me.DplLab.DataBind()
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
        If Not CurImportantGoodsInfo Is Nothing Then
            If PKID <> 0 Then
                Me.TxtBrands.Text = CurImportantGoodsInfo.Brands
                Me.TxtGoodsName.Text = CurImportantGoodsInfo.GoodsName
                Me.TxtRemark.Text = CurImportantGoodsInfo.Remark
                Me.TxtStandars.Text = CurImportantGoodsInfo.Standars
                Me.TxtSupplier.Text = CurImportantGoodsInfo.Supplier
                Me.TxtTecRequire.Text = CurImportantGoodsInfo.TecRequir
                Me.DplLab.SelectedIndex = Me.DplLab.Items.IndexOf(Me.DplLab.Items.FindByText(CurImportantGoodsInfo.LabName))
                Me.DplQulocation.SelectedIndex = Me.DplQulocation.Items.IndexOf(Me.DplQulocation.Items.FindByText(CurImportantGoodsInfo.Qulocation))
                BindHisGrid(PKID)
            End If
        End If
    End Sub
    Public Sub BindHisGrid(ByVal RecordPKID As Integer)
        Dim dt As DataTable = Record_ChangeHistoryDAL.GetInfoByRecordPKID(PKID, 5)
        If Not dt Is Nothing Then
            Me.GridView1.DataSource = dt
            Me.GridView1.DataBind()
        Else
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        CurImportantGoodsInfo.PKID = PKID
        CurImportantGoodsInfo.Standars = Me.TxtStandars.Text
        CurImportantGoodsInfo.Remark = Me.TxtRemark.Text
        CurImportantGoodsInfo.Supplier = Me.TxtSupplier.Text
        CurImportantGoodsInfo.TecRequir = Me.TxtTecRequire.Text
        CurImportantGoodsInfo.Qulocation = Me.DplQulocation.SelectedItem.Text
        CurImportantGoodsInfo.LabName = Me.DplLab.SelectedItem.Text
        CurImportantGoodsInfo.GoodsName = Me.TxtGoodsName.Text
        CurImportantGoodsInfo.Brands = Me.TxtBrands.Text
        CurImportantGoodsInfo.RecordDeleted = 0
        If PKID = 0 Then
            CurImportantGoodsInfo.RecordCreated = DateTime.Now
        End If
        Dim curimportantdal As ImportantGoodsDAL = New ImportantGoodsDAL(CurImportantGoodsInfo)
        curimportantdal.Save()
        PKID = CurImportantGoodsInfo.PKID

        Dim recordchangehis As Record_ChangeHistoryInfo = New Record_ChangeHistoryInfo()
        recordchangehis.PKID = 0
        recordchangehis.RecordPKID = PKID
        recordchangehis.ChangeTime = DateTime.Now
        recordchangehis.ChangeUser = UserInfo.CurrentUserCHName
        recordchangehis.ChangeCategory = 5
        recordchangehis.RecordDeleted = 0
        recordchangehis.RecordCreated = DateTime.Now
        Dim recorddal As Record_ChangeHistoryDAL = New Record_ChangeHistoryDAL(recordchangehis)
        recorddal.Save()
        Response.Redirect("../Suppliers/ImportantGoodsDetail.aspx?PKID=" + PKID.ToString)
    End Sub
End Class