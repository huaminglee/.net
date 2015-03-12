Imports Platform.eHR.Core
Imports Platform.eAuthorize

Partial Public Class BusOppDetail
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
    Private _BussOppInfo As BuinessOpportunntitesInfo
    Private Property BussOppInfo() As BuinessOpportunntitesInfo
        Get
            If _BussOppInfo Is Nothing Then
                If PKID <> 0 Then
                    _BussOppInfo = BuinessOpportunntitesDAL.GetInfoByPKID(PKID)
                Else
                    _BussOppInfo = New BuinessOpportunntitesInfo()
                End If
            End If
            Return _BussOppInfo
        End Get
        Set(ByVal value As BuinessOpportunntitesInfo)
            _BussOppInfo = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            BindDPL()
            BindControlData()
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = CInt(Request.QueryString("pkid"))
            HiddenPKID.Value = PKID
        End If
        If Not Request.QueryString("MarkplanPKID") Then
            ViewState("MarkplanPKID") = Request.QueryString("MarkplanPKID")
        End If
    End Sub
    Private Sub BindDPL()
        Dim exworker As List(Of AccountInfo) = RoleManage.LoadAccountCollection("EXTERNALWORKER")
        Me.DPLOppOwoner.DataSource = exworker
        Me.DPLOppOwoner.DataTextField = "UserName"
        Me.DPLOppOwoner.DataValueField = "UserSID"
        Me.DPLOppOwoner.DataBind()

        Dim ds As DataSet = UserSetCategoryDAL.GetInfoByType(3)
        If Not ds Is Nothing Then
            Me.DPLCategory.DataSource = ds
            Me.DPLCategory.DataTextField = "CategoryName"
            Me.DPLCategory.DataValueField = "StateOrder"
            Me.DPLCategory.DataBind()
        End If

        Dim ds2 As DataSet = UserSetCategoryDAL.GetInfoByType(3)
        If Not ds2 Is Nothing Then
            Me.DPLNextCategory.DataSource = ds2
            Me.DPLNextCategory.DataTextField = "CategoryName"
            Me.DPLNextCategory.DataValueField = "StateOrder"
            Me.DPLNextCategory.DataBind()
        End If
    End Sub
    Private Sub BindControlData()
        If PKID <> 0 Then
            BussoppEdit.Visible = False
            BussoppShow.Visible = True
            markplan.Visible = True
            sysinfo.Visible = True
            Me.TxtAmounts.Text = BussOppInfo.Amounts
            Me.TxtCustomerName.Text = BussOppInfo.CustomerName
            Me.TxtCustomerSources.Text = BussOppInfo.CustomerSources
            Me.TxtEndDate.Text = BussOppInfo.EndDate
            Me.TxtOpportName.Text = BussOppInfo.OpportName
            Me.LbTitle.Text = BussOppInfo.OpportName
            Me.TxtPossibility.Text = BussOppInfo.Possibility
            Me.TxtExcepIncome.Text = BussOppInfo.ExcepedIncome
            Me.TxtRemark.Text = BussOppInfo.Remark
            Me.DPLCategory.SelectedIndex = Me.DPLCategory.Items.IndexOf(Me.DPLCategory.Items.FindByText(BussOppInfo.Category))
            Me.DPLOppOwoner.SelectedIndex = Me.DPLOppOwoner.Items.IndexOf(Me.DPLOppOwoner.Items.FindByText(BussOppInfo.OppOwoner))
            Me.DPLType.SelectedIndex = Me.DPLType.Items.IndexOf(Me.DPLType.Items.FindByText(BussOppInfo.Type))
            Me.LbAmounts.Text = BussOppInfo.Amounts
            Me.LbCategory.Text = BussOppInfo.Category
            Me.LbCustomerName.Text = BussOppInfo.CustomerName
            Me.LbCustomerSources.Text = BussOppInfo.CustomerSources
            Me.LbEndDate.Text = BussOppInfo.EndDate
            Me.LbNextCategory.Text = ""
            Me.LbOpportName.Text = BussOppInfo.OpportName
            Me.LbOppOwoner.Text = BussOppInfo.OppOwoner
            Me.LbPossibility.Text = BussOppInfo.Possibility
            Me.LbType.Text = BussOppInfo.Type
            Me.LbExceptionIncome.Text = BussOppInfo.ExcepedIncome
            Me.LbRemark.Text = BussOppInfo.Remark
            Me.LbInsertPerson.Text = BussOppInfo.InserPerson
            Me.LbLastChange.Text = BussOppInfo.LastChange
            BindGrid()
        Else
            BussoppShow.Visible = False
            BussoppEdit.Visible = True
            markplan.Visible = False
            sysinfo.Visible = False
            Me.TxtEndDate.Text = DateTime.MaxValue.ToShortDateString
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        BussOppInfo.PKID = PKID
        BussOppInfo.Amounts = Me.TxtAmounts.Text
        BussOppInfo.Category = Me.DPLCategory.SelectedItem.Text
        BussOppInfo.CustomerName = Me.TxtCustomerName.Text
        BussOppInfo.CustomerSources = Me.TxtCustomerSources.Text
        BussOppInfo.EndDate = Me.TxtEndDate.Text
        BussOppInfo.ExcepedIncome = Me.TxtExcepIncome.Text
        If PKID = 0 Then
            BussOppInfo.InserPerson = UserInfo.CurrentUserCHName + "_" + UserInfo.CurrentUserID + "_" + DateTime.Now.ToString
        End If
        BussOppInfo.LastChange = UserInfo.CurrentUserCHName + "_" + UserInfo.CurrentUserID + "_" + DateTime.Now.ToString
        BussOppInfo.OpportName = Me.TxtOpportName.Text
        BussOppInfo.OppOwoner = Me.DPLOppOwoner.SelectedItem.Text
        BussOppInfo.Possibility = Me.TxtPossibility.Text
        BussOppInfo.RecordCreated = DateTime.Now
        BussOppInfo.RecordDeleted = 0
        BussOppInfo.Remark = Me.TxtRemark.Text
        BussOppInfo.Type = Me.DPLType.SelectedItem.Text

        Dim bussoppdal As BuinessOpportunntitesDAL = New BuinessOpportunntitesDAL(BussOppInfo)
        bussoppdal.Save()
        PKID = BussOppInfo.PKID
        If Not ViewState("MarkplanPKID") Is Nothing Then
            Dim markcontact As MarkOppContactInfo = New MarkOppContactInfo()
            markcontact.PKID = 0
            markcontact.MarkPlanPKID = CInt(ViewState("MarkplanPKID"))
            markcontact.BusOppPKID = PKID
            markcontact.RecordCreated = DateTime.Now
            markcontact.RecordDeleted = 0
            Dim markcondal As MarkOppContactDAL = New MarkOppContactDAL(markcontact)
            markcondal.Save()
            Response.Redirect("../Forms/MarketPlanDetail.aspx?pkid=" + ViewState("MarkplanPKID").ToString)
        End If
        Response.Redirect("../Forms/BusOppDetail.aspx?pkid=" + PKID.ToString)
    End Sub

    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        BussoppShow.Visible = False
        BussoppEdit.Visible = True
        markplan.Visible = False
    End Sub

    Protected Sub LinkBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkBack.Click
        Response.Redirect("../Forms/BusOppList.aspx")
    End Sub
    Private Sub BindGrid()
        Dim ds As DataSet = MarkOppContactDAL.GetDSByBussOPPpkid(PKID)
        If Not ds Is Nothing Then
            Me.busemptyinfo.Visible = False
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"pkid"}
            Me.GridView1.DataBind()
        Else
            Me.busemptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        BindGrid()
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        If PKID <> 0 Then
            Response.Redirect("../Forms/BusOppDetail.aspx?pkid=" + PKID.ToString)
        Else
            Response.Redirect("../Forms/BusOppList.aspx")
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000';this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim LbMarkPlanpkid As Label = CType(e.Row.FindControl("LbMarkPlanpkid"), Label)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            HLDetail.NavigateUrl = "../Forms/MarketPlanDetail.aspx?pkid=" + LbMarkPlanpkid.Text.ToString
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該客戶嗎?');")
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = CInt(Me.GridView1.DataKeys(e.RowIndex).Value)
        MarkOppContactDAL.Delete(mpkid)
        BindGrid()
    End Sub
End Class