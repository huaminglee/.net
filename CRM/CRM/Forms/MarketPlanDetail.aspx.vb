Imports Platform.eHR.Core
Imports Platform.eAuthorize

Partial Public Class MarketPlanDetail
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
    Private _MarketPlant As MarketingPlanInfo
    Private Property MarketPlan() As MarketingPlanInfo
        Get
            If _MarketPlant Is Nothing Then
                If PKID <> 0 Then
                    _MarketPlant = MarketingPlanDAL.GetInfoByPKID(PKID)
                Else
                    _MarketPlant = New MarketingPlanInfo()
                End If
            End If
            Return _MarketPlant
        End Get
        Set(ByVal value As MarketingPlanInfo)
            _MarketPlant = value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({isShowClear:false,startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            GetParam()
            BindDPL()
            BindControlData()
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("pkid") Is Nothing Then
            PKID = CInt(Request.QueryString("pkid"))
            HiddenPKID.Value = PKID
        End If
    End Sub
    Private Sub BindDPL()
        Dim exworker As List(Of AccountInfo) = RoleManage.LoadAccountCollection("EXTERNALWORKER")
        Me.DPLOwoner.DataSource = exworker
        Me.DPLOwoner.DataTextField = "UserName"
        Me.DPLOwoner.DataValueField = "UserSID"
        Me.DPLOwoner.DataBind()

        Dim ds As DataSet = UserSetCategoryDAL.GetInfoByType(4)
        If Not ds Is Nothing Then
            Me.DPLCategory.DataSource = ds
            Me.DPLCategory.DataTextField = "CategoryName"
            Me.DPLCategory.DataValueField = "StateOrder"
            Me.DPLCategory.DataBind()
        End If

    End Sub
    Private Sub BindControlData()
        If PKID <> 0 Then
            planedit.Visible = False
            planshow.Visible = True
            Me.sysinfo.Visible = True
            Me.TxtActualCosts.Text = MarketPlan.ActualCosts
            Me.TxtBudgetCost.Text = MarketPlan.BudgetCost
            Me.TxtEndDate.Text = MarketPlan.EndDate
            Me.TxtExceptedIncome.Text = MarketPlan.ExcepedIncome
            Me.TxtExceptedResPercent.Text = MarketPlan.ExpectedRePercent
            Me.TxtPlanName.Text = MarketPlan.MarkPlanName
            Me.TxtResponseNums.Text = MarketPlan.ResponseNums
            Me.TxtSendNums.Text = MarketPlan.SendNums
            Me.TxtStartDate.Text = MarketPlan.StartDate
            Me.TxtRemark.Text = MarketPlan.Remark
            Me.DPLCategory.SelectedIndex = Me.DPLCategory.Items.IndexOf(Me.DPLCategory.Items.FindByText(MarketPlan.Category))
            Me.DPLOwoner.SelectedIndex = Me.DPLOwoner.Items.IndexOf(Me.DPLOwoner.Items.FindByText(MarketPlan.Owner))
            Me.DplType.SelectedIndex = Me.DplType.Items.IndexOf(Me.DplType.Items.FindByText(MarketPlan.Type))
            Me.RdoIsStarted.SelectedIndex = Me.RdoIsStarted.Items.IndexOf(Me.RdoIsStarted.Items.FindByValue(MarketPlan.IsStarted))

            Me.LbActualCosts.Text = MarketPlan.ActualCosts
            Me.LbBudgetCost.Text = MarketPlan.BudgetCost
            Me.LbEndDate.Text = MarketPlan.EndDate
            Me.LbExceptedIncome.Text = MarketPlan.ExcepedIncome
            Me.LbExpectedRePercent.Text = MarketPlan.ExpectedRePercent
            Me.LbmarketName.Text = MarketPlan.MarkPlanName
            Me.MarketPlanName.Text = MarketPlan.MarkPlanName
            Me.LbResponseNums.Text = MarketPlan.ResponseNums
            Me.LbSendNums.Text = MarketPlan.SendNums
            Me.LbStartDate.Text = MarketPlan.StartDate
            Me.LbCategory.Text = MarketPlan.Category
            Me.LbOwoner.Text = MarketPlan.Owner
            Me.LbRemark.Text = MarketPlan.Remark
            Me.LbType.Text = MarketPlan.Type
            Me.LbInsertPerson.Text = MarketPlan.InsertPerson
            Me.LbLastChange.Text = MarketPlan.Lastchange
            If MarketPlan.IsStarted = 1 Then
                Me.LbIsstarted.Text = "已啟動"
            Else
                Me.LbIsstarted.Text = "未啟動"
            End If
            BindGridPlanmember()
            BindGridyewujihui()
           
        Else
            Me.TxtStartDate.Text = DateTime.Now.ToShortDateString
            Me.TxtEndDate.Text = DateTime.MaxValue.ToShortDateString
            planedit.Visible = True
            planshow.Visible = False
            yewujihui.Visible = False
            jihuaMember.Visible = False
            sysinfo.Visible = False
        End If
    End Sub
    Private Sub BindGridyewujihui()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Market_GetBusOppByMarketPlanPKID", PKID)
        DealBussValue = 0
        AllBussValie = 0
        If ds.Tables(0).Rows.Count > 0 Then
            Me.busemptyinfo.Visible = False
            Me.GridBussOpp.DataSource = ds
            Me.GridBussOpp.DataKeyNames = New String() {"pkid"}
            Me.GridBussOpp.DataBind()
        Else
            Me.busemptyinfo.Visible = True
            Me.GridBussOpp.DataSource = Nothing
            Me.GridBussOpp.DataBind()
        End If
    End Sub
    Private Sub BindGridPlanmember()
        changecustomers = 0
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarketMember_GetInfoByPlanPKID", PKID)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.menberemptyinfo.Visible = False
            Me.GridPlanMember.DataSource = ds
            Me.GridPlanMember.DataKeyNames = New String() {"pkid"}
            Me.GridPlanMember.DataBind()
        Else
            Me.menberemptyinfo.Visible = True
            Me.GridPlanMember.DataSource = Nothing
            Me.GridPlanMember.DataBind()
        End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        MarketPlan.PKID = PKID
        MarketPlan.ActualCosts = Me.TxtActualCosts.Text
        MarketPlan.BudgetCost = Me.TxtBudgetCost.Text
        MarketPlan.Category = Me.DPLCategory.SelectedItem.Text
        MarketPlan.EndDate = Me.TxtEndDate.Text
        MarketPlan.ExcepedIncome = Me.TxtExceptedIncome.Text
        MarketPlan.ExpectedRePercent = Me.TxtExceptedResPercent.Text
        If PKID = 0 Then
            MarketPlan.InsertPerson = UserInfo.CurrentUserID + "_" + UserInfo.CurrentUserCHName + "_" + DateTime.Now.ToString()
            MarketPlan.RecordCreated = DateTime.Now
        End If
        MarketPlan.IsStarted = Me.RdoIsStarted.SelectedValue
        MarketPlan.Lastchange = UserInfo.CurrentUserID + "_" + UserInfo.CurrentUserCHName + "_" + DateTime.Now.ToString
        MarketPlan.MarkPlanName = Me.TxtPlanName.Text
        MarketPlan.Owner = Me.DPLOwoner.SelectedItem.Text
        MarketPlan.RecordDeleted = 0
        MarketPlan.Remark = Me.TxtRemark.Text
        MarketPlan.ResponseNums = Me.TxtResponseNums.Text
        MarketPlan.SendNums = Me.TxtSendNums.Text
        MarketPlan.StartDate = Me.TxtStartDate.Text
        MarketPlan.Type = Me.DplType.SelectedItem.Text

        Dim markdal As MarketingPlanDAL = New MarketingPlanDAL(MarketPlan)
        markdal.Save()
        PKID = MarketPlan.PKID
        HiddenPKID.Value = PKID

        Response.Redirect("../Forms/MarketPlanDetail.aspx?pkid=" + PKID.ToString)
    End Sub

 

    Protected Sub GridBussOpp_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridBussOpp.RowCommand
        Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim bussopppkid As Integer = CInt(CType(DateRow.Cells(1).FindControl("LBpkid"), Label).Text)
        Dim LbCategory As Label = CType(DateRow.FindControl("LbCategory"), Label)
        Dim DPLCategory As DropDownList = CType(DateRow.FindControl("DPLCategory"), DropDownList)
        Dim lBPossibility As Label = CType(DateRow.FindControl("lBPossibility"), Label)
        Dim TxtPossibility As TextBox = CType(DateRow.FindControl("TxtPossibility"), TextBox)
        Dim LinkSave As LinkButton = CType(DateRow.FindControl("LinkSave"), LinkButton)
        Dim LinkCancle As LinkButton = CType(DateRow.FindControl("LinkCancle"), LinkButton)
        Dim LinkEdit As LinkButton = CType(DateRow.FindControl("LinkEdit"), LinkButton)
        Select Case e.CommandName
            Case "editup"
                DateRow.BackColor = System.Drawing.Color.Gray
                LinkEdit.Visible = False
                LinkSave.Visible = True
                LinkCancle.Visible = True
                LbCategory.Visible = False
                DPLCategory.Visible = True
                lBPossibility.Visible = False
                TxtPossibility.Visible = True
                Dim ds As DataSet = UserSetCategoryDAL.GetInfoByType(3)
                If ds.Tables(0).Rows.Count > 0 Then
                    DPLCategory.DataSource = ds
                    DPLCategory.DataTextField = "CategoryName"
                    DPLCategory.DataValueField = "StateOrder"
                    DPLCategory.DataBind()
                    DPLCategory.SelectedIndex = DPLCategory.Items.IndexOf(DPLCategory.Items.FindByText(LbCategory.Text))
                End If
            Case "saveup"
                Dim busoppinfo As BuinessOpportunntitesInfo = BuinessOpportunntitesDAL.GetInfoByPKID(bussopppkid)
                busoppinfo.Category = DPLCategory.SelectedItem.Text
                busoppinfo.Possibility = TxtPossibility.Text
                Dim bussdal As BuinessOpportunntitesDAL = New BuinessOpportunntitesDAL(busoppinfo)
                bussdal.Save()
                BindGridyewujihui()

            Case "cancleed"
                BindGridyewujihui()
        End Select
    End Sub
    Dim DealBussValue = 0
    Dim AllBussValie = 0
    Protected Sub GridBussOpp_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridBussOpp.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000';this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim HYLinkSee As HyperLink = CType(e.Row.FindControl("HYLinkSee"), HyperLink)
            Dim buspkid As Integer = CInt(Me.GridBussOpp.DataKeys(e.Row.RowIndex).Value)
            HYLinkSee.NavigateUrl = "../Forms/BusOppDetail.aspx?pkid=" + buspkid.ToString
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該客戶嗎?');")
            Dim lBPossibility As Label = CType(e.Row.FindControl("lBPossibility"), Label)
            Dim LbCategory As Label = CType(e.Row.FindControl("LbCategory"), Label)
            AllBussValie += CInt(e.Row.Cells(6).Text)
            If lBPossibility.Text = "100" OrElse LbCategory.Text = "中標已結業務" Then
                DealBussValue += CInt(e.Row.Cells(6).Text)
            End If
        End If
    End Sub

    Protected Sub GridBussOpp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridBussOpp.RowDeleting
        Dim buspkid As Integer = CInt(Me.GridBussOpp.DataKeys(e.RowIndex).Value)
        MarkOppContactDAL.DeleteByBusPKID(buspkid)
        BindGridyewujihui()
    End Sub
    Dim changecustomers As Integer = 0
    Dim customersnum As Integer = 0
    Protected Sub GridPlanMember_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridPlanMember.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000';this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
            BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該客戶嗎?');")
            If e.Row.Cells(1).Text = "潛在客戶" Then
                customersnum += 1
                If CType(e.Row.FindControl("LbMemberCategory"), Label).Text = "已轉化" Then
                    changecustomers += 1
                End If
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        BindGridyewujihui()
    End Sub

  

  

    Protected Sub GridPlanMember_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridPlanMember.RowCommand
        Dim DateRow As GridViewRow = CType(CType(e.CommandSource, Control).Parent.Parent, GridViewRow)
        Dim LBpkid As Label = CType(DateRow.FindControl("LBpkid"), Label)

        Select Case e.CommandName
            Case "editup"
                DateRow.BackColor = System.Drawing.Color.Gray

                Dim LbMemberCategory As Label = CType(DateRow.FindControl("LbMemberCategory"), Label)
                Dim DPLmembercategory As DropDownList = CType(DateRow.FindControl("DPLmembercategory"), DropDownList)
                Dim LinkEdit As LinkButton = CType(DateRow.FindControl("LinkEdit"), LinkButton)
                Dim LinkSave As LinkButton = CType(DateRow.FindControl("LinkSave"), LinkButton)
                Dim LinkCancle As LinkButton = CType(DateRow.FindControl("LinkCancle"), LinkButton)
                LinkEdit.Visible = False
                LinkSave.Visible = True
                LinkCancle.Visible = True
                LbMemberCategory.Visible = False
                DPLmembercategory.Visible = True
                If DateRow.Cells(1).Text = "聯繫人" Then
                    Dim ds As DataSet = UserSetCategoryDAL.GetInfoByType(1)
                    If ds.Tables(0).Rows.Count > 0 Then
                        DPLmembercategory.DataSource = ds
                        DPLmembercategory.DataTextField = "CategoryName"
                        DPLmembercategory.DataValueField = "StateOrder"
                        DPLmembercategory.DataBind()
                        DPLmembercategory.SelectedIndex = DPLmembercategory.Items.IndexOf(DPLmembercategory.Items.FindByText(LbMemberCategory.Text))
                    End If
                ElseIf DateRow.Cells(1).Text = "潛在客戶" Then
                    Dim ds As DataSet = UserSetCategoryDAL.GetInfoByType(2)
                    If ds.Tables(0).Rows.Count > 0 Then
                        DPLmembercategory.DataSource = ds
                        DPLmembercategory.DataTextField = "CategoryName"
                        DPLmembercategory.DataValueField = "StateOrder"
                        DPLmembercategory.DataBind()
                        DPLmembercategory.SelectedIndex = DPLmembercategory.Items.IndexOf(DPLmembercategory.Items.FindByText(LbMemberCategory.Text))
                    End If
                End If
            Case "saveup"
                Dim DPLmembercategory As DropDownList = CType(DateRow.FindControl("DPLmembercategory"), DropDownList)
                Dim markplanmemberinfo As MarketMemberInfo = MarketMemberDAL.GetInfoByPKID(CInt(LBpkid.Text))
                Dim LbCustomerPKID As Label = CType(DateRow.FindControl("LbCustomerPKID"), Label)
                Dim LbContactPKID As Label = CType(DateRow.FindControl("LbContactPKID"), Label)

                markplanmemberinfo.MemberCategory = DPLmembercategory.SelectedItem.Text
                Dim mamemdal As MarketMemberDAL = New MarketMemberDAL(markplanmemberinfo)
                mamemdal.Save()
                BindGridPlanmember()
            Case "cancleed"
                BindGridPlanmember()
        End Select

    End Sub

    Protected Sub GridPlanMember_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridPlanMember.RowDeleting
        Dim mpkid As Integer = CInt(Me.GridPlanMember.DataKeys(e.RowIndex).Value)
        MarketMemberDAL.Delete(mpkid)
        BindGridPlanmember()
    End Sub

   
    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.planedit.Visible = True
        Me.planshow.Visible = False
        Me.jihuaMember.Visible = False
        Me.yewujihui.Visible = False
    End Sub

    Protected Sub LinkNewContact_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkNewContact.Click
        Response.Redirect("../Forms/UserADVInfo.aspx?IsAdd=1&Markplanpkid=" + PKID.ToString)
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("../Forms/CustomerDetail.aspx?add=1&Markplanpkid=" + PKID.ToString)
    End Sub

    Protected Sub LinkBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkBack.Click
        Response.Redirect("../Forms/MarketPlanList.aspx")
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        If PKID <> 0 Then
            Response.Redirect("../Forms/MarketPlanDetail.aspx?pkid=" + PKID.ToString)
        Else
            Response.Redirect("../Forms/MarketPlanList.aspx")
        End If

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        BindGridPlanmember()
    End Sub

    Protected Sub LinkNewBussOpp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkNewBussOpp.Click
        Response.Redirect("../Forms/BusOppDetail.aspx?MarkplanPKID=" + PKID.ToString)
    End Sub

    Protected Sub GridBussOpp_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles GridBussOpp.DataBound
        Me.LbBusOppCGValue.Text = DealBussValue
        Me.LbBusOppTotalvalue.Text = AllBussValie
        Me.LbBusOppNums.Text = Me.GridBussOpp.Rows.Count
        If Me.LbActualCosts.Text <> "" AndAlso Me.LbResponseNums.Text <> "" Then
            Me.LbPerResponseCB.Text = (Me.LbActualCosts.Text / Me.LbResponseNums.Text).ToString("0.00")
            Dim prof As Double = (DealBussValue - Me.LbActualCosts.Text) * 100
            Dim basic As Double = Me.LbActualCosts.Text
            Me.LbTZHBL.Text = (prof / basic).ToString("0.00") + "%"
            Me.LbPerCusCB.Text = (Me.LbActualCosts.Text / Me.LbContactNums.Text).ToString("0.00")
          
        End If

    End Sub

    Protected Sub GridPlanMember_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles GridPlanMember.DataBound
        Me.LbContactNums.Text = Me.GridPlanMember.Rows.Count
        If Me.LbActualCosts.Text <> "" AndAlso Me.LbResponseNums.Text <> "" Then
            Me.LbPerCusCB.Text = (Me.LbActualCosts.Text / Me.LbContactNums.Text).ToString("0.00")
            Me.LbChangeCusNums.Text = changecustomers
            Me.LbQCustomersNums.Text = customersnum
        End If
    End Sub
End Class