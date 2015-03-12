Imports Platform.eAuthorize
Imports Platform.eHR.Core

Partial Public Class CustomerDetail
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SORTFIELD2 As String = "ViewState:SortField2"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
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
    Private _Customer As CustomersInfo
    Private Property Customer() As CustomersInfo
        Get
            If _Customer Is Nothing Then
                If PKID <> 0 Then
                    _Customer = CustomersDAL.GetInfoByPKID(PKID)
                Else
                    _Customer = New CustomersInfo()
                End If
            End If
            Return _Customer
        End Get
        Set(ByVal value As CustomersInfo)
            _Customer = value
        End Set
    End Property
   
    ''' <summary>
    ''' 當前人員聯繫人表PKID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property ContactPKID() As Integer
        Get
            If ViewState("ContactPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("ContactPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("ContactPKID") = value
        End Set
    End Property
   
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageIndex() As Integer
        Get
            Return Me.PagerControl1.CurrentPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.CurrentPage = Value + 1
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的行
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageSize() As Integer
        Get
            Return Me.PagerControl1.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl1.RecordsPerPage = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的索引
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageIndex2() As Integer
        Get
            Return Me.PagerControl2.CurrentPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl2.CurrentPage = Value + 1
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 當前頁的行
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Property PageSize2() As Integer
        Get
            Return Me.PagerControl2.RecordsPerPage
        End Get
        Set(ByVal Value As Integer)
            Me.PagerControl2.RecordsPerPage = Value
        End Set
    End Property
    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String

                SearchCondition = "  RecordDeleted=0  and CusTomerPKID=" + PKID.ToString
                Return SearchCondition
            End If
        End Get

    End Property

    Private ReadOnly Property SearchCondition() As String
        Get
            If ViewState("SearchCondition") Is Nothing Then
                Return InitSearch
            Else
                Return ViewState("SearchCondition").ToString

            End If
        End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序字段
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortField() As String
        Get
            If ViewState(HIDE_SORTFIELD) Is Nothing Then
                ViewState(HIDE_SORTFIELD) = "UserName"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD) = Value
        End Set
    End Property
    Private Property SortField2() As String
        Get
            If ViewState(HIDE_SORTFIELD2) Is Nothing Then
                ViewState(HIDE_SORTFIELD2) = "VisitDate"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD2).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD2) = Value
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 排序方式
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Property SortOrder() As String
        Get
            If ViewState(HIDE_SortOrder) Is Nothing Then
                ViewState(HIDE_SortOrder) = "DESC"
            Else
            End If
            Return ViewState(HIDE_SortOrder).ToString.Trim
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SortOrder) = Value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindDPL()
            If UserInfo.IsInRoles("EXTERNALWORKER") Then
                Me.LinkLevelChange.Visible = True
            End If
            Me.UcFileDetail1.ParentID = PKID
            Me.UcFileDetail1.ParentCategory = 9
            Me.UcFileDetail1.ParentSubCategory = 1
            BindControlData()
            Me.LinkDelete.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
            Me.TxtCity.Attributes.Add("onclick", "if (this.value=='請填寫市級行政區域') this.value='';")
            BindLinkComplaints()
            'BindLinkContactManage()
            BindLinkGMPCSI()
            BindLinkLevelChange()
            BindLinkTransacTions()
            BindGridData(InitSearch)
            BindVisits(InitSearch)
        End If
    End Sub

    Private Sub GetParam()
        If Request.QueryString("pkid") Is Nothing Then
            If Request.QueryString("add") Is Nothing Then
                PKID = ContactDAL.GetCustomerPKIDByUserSID(UserInfo.CurrentUserID)
            Else
                PKID = 0
            End If
        Else
            PKID = Convert.ToInt32(Request.QueryString("pkid"))
        End If
        If Request.QueryString("add") Is Nothing AndAlso PKID = 0 Then
            Response.Write("<script > alert('您還未填寫公司信息，請先填寫');window.location.href ='../Forms/UserADVInfo.aspx' </script>")
        End If
        If Not Request.QueryString("Markplanpkid") Is Nothing Then
            ViewState("Markplanpkid") = Request.QueryString("Markplanpkid")
        End If
    End Sub
#Region "聯繫人管理"
    Private Sub BindGridData(ByVal SearchCondition As String)
        If PKID = 0 Then
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
            Me.PagerControl1.Visible = False
           

        Else
            Dim TotalRecord As Integer = 0
            Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("Contact", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
            If ds Is Nothing Then
                Me.emptyinfo.Visible = True
                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
                Me.PagerControl1.Visible = False
            Else
                Me.emptyinfo.Visible = False
                Me.PagerControl1.Visible = True
                Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
                Me.GridView1.DataSource = ds
                Me.GridView1.DataKeyNames = New String() {"PKID"}
                Me.GridView1.DataBind()
            End If
          
        End If
       
    End Sub
    Private Sub BindVisits(ByVal SearchCondition As String)
        If PKID = 0 Then
            Me.emptyinfo2.Visible = True
            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()
            Me.PagerControl2.Visible = False
        Else
            Dim TotalRecord2 As Integer = 0
            Dim ds2 As DataSet = GridViewPage.GetPageInfoBySearchCondition("CustomerVisits", SearchCondition, "*", SortField2 + " " + SortOrder, PageSize2, PageIndex2, TotalRecord2)
            If ds2 Is Nothing Then
                Me.emptyinfo2.Visible = True
                Me.GridView2.DataSource = Nothing
                Me.GridView2.DataBind()
                Me.PagerControl2.Visible = False
            Else
                Me.emptyinfo2.Visible = False
                Me.PagerControl2.Visible = True
                Me.PagerControl2.TotalRecords = CInt(ds2.Tables(1).Rows(0)("TotalRecord"))
                Me.GridView2.DataSource = ds2
                Me.GridView2.DataKeyNames = New String() {"PKID"}
                Me.GridView2.DataBind()
            End If
        End If
       
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then

                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)

                Dim ReturnURL As String = "../Forms/UserADVInfo.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
                ReturnURL += "&CustomerPKID=" + PKID.ToString
                Dim title = e.Row.Cells(1).Text
                HLDetail.NavigateUrl = ReturnURL
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim lbPKID As Label = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lbPKID"), Label)
        Dim mPKID As Integer = CInt(lbPKID.Text)
        ContactDAL.Delete(mPKID)
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click

        Dim curSearchCondition As String = InitSearch
        If Me.InpSearch.Value <> String.Empty Then
            curSearchCondition += String.Format(" and( UserName like '%{0}%' or UserSID like '%{0}%' or CustomerName Like '%{0}%' or Major like '%{0}%' or Position like '%{0}%')", Me.InpSearch.Value.ToString)
        End If
        ViewState("SearchCondition") = curSearchCondition
        BindGridData(SearchCondition)
    End Sub

    Protected Sub LinkAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkAdd.Click
        If Not PKID = 0 Then
            Response.Redirect("../Forms/UserADVInfo.aspx?isadd=1&CustomerPKID=" + PKID.ToString)
        End If
    End Sub
#End Region
    Private Sub BindDPL()
        Dim DT As DataTable = IndustryDAL.GetAllInfo()
        If Not DT Is Nothing Then
            Me.DPLIndustry.DataSource = DT
            Me.DPLIndustry.DataTextField = "IndustryName"
            Me.DPLIndustry.DataValueField = "Extend1"
            Me.DPLIndustry.DataBind()
        End If
        Dim accountlist As List(Of AccountInfo) = RoleManage.LoadAccountCollection("ExternalWorker") '綁定所有負責人
        Me.DPLPersonincharge.DataSource = accountlist
        Me.DPLPersonincharge.DataTextField = "UserName"
        Me.DPLPersonincharge.DataValueField = "UserSID"
        Me.DPLPersonincharge.DataBind()
        Me.DPLPersonincharge.SelectedIndex = Me.DPLPersonincharge.Items.IndexOf(Me.DPLPersonincharge.Items.FindByText(StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052)))

        Dim sourcexmlpath As String = Server.MapPath("~") + "\XMLData\CustomerSorces.xml"
        Dim ds As DataSet = New DataSet
        ds.ReadXml(sourcexmlpath)
        Me.DPLSource.DataSource = ds
        Me.DPLSource.DataTextField = "value"
        Me.DPLSource.DataValueField = "key"
        Me.DPLSource.DataBind()

    End Sub
    Private Sub BindControlData()
        If Not Customer Is Nothing Then
            If PKID <> 0 Then

                Me.LbPaywarning.Text = Customer.Extend1
                Me.TxtPaywarning.Text = Customer.Extend1
                Me.LbTitle.Text = Customer.CustomerName + "基本信息"
                Me.TxtCity.Text = Customer.City
                Me.LbCity.Text = Customer.City
                Me.TxtCustomerAlias.Text = Customer.CustomerAlias
                Me.LbCustomerAlias.Text = Customer.CustomerAlias
                Me.TxtCustomerEnglishName.Text = Customer.CustomerEnglishName
                Me.LbCustomerEnglishName.Text = Customer.CustomerEnglishName
                Me.TxtCustomerName.Text = Customer.CustomerName
                Me.LbCustomerName.Text = Customer.CustomerName
                Me.LbCustomerNO.Text = Customer.CustomerID
                Me.DPLPersonincharge.SelectedIndex = Me.DPLPersonincharge.Items.IndexOf(Me.DPLPersonincharge.Items.FindByText(StrConv(Customer.PersonInCharge, VbStrConv.TraditionalChinese, 2052)))

                Me.TxtEmail.Text = Customer.Email
                Me.LbEmail.Text = Customer.Email
                Me.TxtEmployeeNum.Text = Customer.EmployeeNum
                LbEmployeeNum.Text = Customer.EmployeeNum
                Me.TxtFax.Text = Customer.Fax
                Me.LbFax.Text = Customer.Fax

                'Me.LbManagers.Text = Customer.Managers

                'Me.LbPersonInCharge.Text = Customer.PersonInCharge
                Me.TxtPhone.Text = Customer.Phone
                Me.LbPhone.Text = Customer.Phone
                Me.TxtRemark.Text = Customer.Remark
                Me.LbRemark.Text = Customer.Remark
                Me.TxtVATNum.Text = Customer.VATNum
                Me.LbVATNum.Text = Customer.VATNum
                Me.TxtWebAddress.Text = Customer.WebAddress
                Me.LbWebAddress.Text = Customer.WebAddress
                Me.TxtZhuceCapital.Text = Customer.ZhuceCapital
                Me.LbZhuceCapital.Text = Customer.ZhuceCapital
                Me.TxtZipCode.Text = Customer.ZipCode
                Me.LbZipCode.Text = Customer.ZipCode
                Me.TxtAddress.Text = Customer.Address
                Me.LbAddress.Text = Customer.Address
                Me.TxtBank.Text = Customer.Bank
                Me.LbBank.Text = Customer.Bank
                Me.TxtAccountName.Text = Customer.AccountName
                Me.LbAccountName.Text = Customer.AccountName
                Me.TxtBankAccount.Text = Customer.BankAccount
                Me.LbBankAccount.Text = Customer.BankAccount
                Me.TxtBillingName.Text = Customer.BillingName
                Me.LbBillingName.Text = Customer.BillingName
                Me.DPLIndustry.SelectedIndex = Me.DPLIndustry.Items.IndexOf(Me.DPLIndustry.Items.FindByText(Customer.Industry))
                Me.LbIndustry.Text = Customer.Industry
                Me.DPLCategory.SelectedIndex = Me.DPLCategory.Items.IndexOf(Me.DPLCategory.Items.FindByValue(Customer.Category))
                Me.LbCategory.Text = Me.DPLCategory.SelectedItem.Text
                Me.DPLSource.SelectedIndex = Me.DPLSource.Items.IndexOf(Me.DPLSource.Items.FindByText(Customer.Source))
                Me.LbSource.Text = Me.DPLSource.SelectedItem.Text
                Me.DPLStatus.SelectedIndex = Me.DPLStatus.Items.IndexOf(Me.DPLStatus.Items.FindByValue(Customer.Status))
                Me.LbStatus.Text = Me.DPLStatus.SelectedItem.Text
                Me.DPLTypeofPay.SelectedIndex = Me.DPLTypeofPay.Items.IndexOf(Me.DPLTypeofPay.Items.FindByValue(Customer.TypeofPay))
                Me.LbTypeofPay.Text = Me.DPLTypeofPay.SelectedItem.Text
                Me.LbCreater.Text = Customer.InsertPsrson
                Me.LbCreateDate.Text = Customer.RecordCreated.ToShortDateString
                BindDatalist()
            Else
                Me.CusPerson.Visible = False
                'Me.Image1.Visible = True
                'Me.Image2.Visible = True
                Me.LbPaywarning.Visible = False
                Me.DPLPersonincharge.Visible = True
                Me.LinkDelete.Visible = False
                ' Me.LinkContactManage.Visible = False
                Me.LinkLevelChange.Visible = False
                Me.LinkTransacTions.Visible = False
                Me.LinkGMPCSI.Visible = False
                Me.LinkComplaints.Visible = False
                Me.LinkEdit.Visible = False
                Me.LinkSave.Visible = True
                Me.TxtAddress.Visible = True
                Me.TxtCity.Visible = True
                Me.TxtCustomerAlias.Visible = True
                Me.TxtCustomerEnglishName.Visible = True
                Me.TxtCustomerName.Visible = True
                Me.TxtEmail.Visible = True
                Me.TxtEmployeeNum.Visible = True
                Me.TxtFax.Visible = True

                Me.TxtPaywarning.Visible = True
                Me.TxtPhone.Visible = True
                Me.TxtRemark.Visible = True
                Me.TxtBank.Visible = True
                Me.TxtBankAccount.Visible = True
                Me.TxtBillingName.Visible = True
                Me.TxtAccountName.Visible = True
                Me.TxtVATNum.Visible = True
                Me.TxtVATNum.Visible = True
                Me.TxtWebAddress.Visible = True
                Me.TxtZhuceCapital.Visible = True
                Me.TxtZipCode.Visible = True
                Me.DPLCategory.Visible = True
                Me.DPLIndustry.Visible = True
                Me.DPLSource.Visible = True
                Me.DPLStatus.Visible = True
                Me.DPLTypeofPay.Visible = True
                Me.LbAccountName.Visible = False
                Me.LbAddress.Visible = False
                Me.LbBank.Visible = False
                Me.LbBankAccount.Visible = False
                Me.LbBillingName.Visible = False
                Me.LbCategory.Visible = False
                Me.LbCity.Visible = False
                Me.LbCustomerAlias.Visible = False
                Me.LbCustomerEnglishName.Visible = False
                Me.LbCustomerName.Visible = False
                Me.LbEmail.Visible = False
                Me.LbEmployeeNum.Visible = False
                Me.LbFax.Visible = False
                Me.LbIndustry.Visible = False
                'Me.LbPersonInCharge.Visible = False
                Me.DataList1.Visible = False
                Me.LbPhone.Visible = False
                Me.LbRemark.Visible = False
                Me.LbSource.Visible = False
                Me.LbStatus.Visible = False
                Me.LbTypeofPay.Visible = False
                Me.LbVATNum.Visible = False
                Me.LbWebAddress.Visible = False
                Me.LbZhuceCapital.Visible = False
                Me.LbZipCode.Visible = False
                Me.LbNotice.Visible = True
            End If
        End If
    End Sub
    Protected Sub BindDatalist()
        Dim personincharge As String() = Customer.PersonInCharge.ToString.Split("、")
        Me.DataList1.DataSource = personincharge
        Me.DataList1.DataBind()

    End Sub
    Protected Sub LinkEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkEdit.Click
        Me.LinkSave.Visible = True
        Me.LinkEdit.Visible = False
        Me.TxtCity.Visible = True


        'Me.Image2.Visible = True
        'Me.Image1.Visible = True
        Me.DPLPersonincharge.Visible = True
        Me.TxtAddress.Visible = True
        Me.TxtCustomerAlias.Visible = True
        Me.TxtCustomerEnglishName.Visible = True
        Me.TxtCustomerName.Visible = True
        Me.TxtEmail.Visible = True
        Me.TxtEmployeeNum.Visible = True
        Me.TxtFax.Visible = True
        Me.LbPaywarning.Visible = False
        Me.TxtPaywarning.Visible = True

        Me.TxtPhone.Visible = True
        Me.TxtRemark.Visible = True
        Me.TxtBank.Visible = True
        Me.TxtBankAccount.Visible = True
        Me.TxtAccountName.Visible = True
        Me.TxtBillingName.Visible = True
        Me.TxtVATNum.Visible = True
        Me.TxtWebAddress.Visible = True
        Me.TxtZhuceCapital.Visible = True
        Me.TxtZipCode.Visible = True
        Me.DPLCategory.Visible = True
        Me.DPLIndustry.Visible = True
        Me.DPLSource.Visible = True
        Me.DPLStatus.Visible = True
        Me.DPLTypeofPay.Visible = True
        Me.LbAccountName.Visible = False
        Me.LbAddress.Visible = False
        Me.LbBank.Visible = False
        Me.LbBankAccount.Visible = False
        Me.LbBillingName.Visible = False
        Me.LbCategory.Visible = False
        Me.LbCity.Visible = False
        'Me.LbManagers.Visible = False

        Me.LbCustomerAlias.Visible = False
        Me.LbCustomerEnglishName.Visible = False
        Me.LbCustomerName.Visible = False
        Me.LbEmail.Visible = False
        Me.LbEmployeeNum.Visible = False
        Me.LbFax.Visible = False
        Me.LbIndustry.Visible = False
        'Me.LbPersonInCharge.Visible = False
        Me.DataList1.Visible = False
        Me.LbBank.Visible = False
        Me.LbBankAccount.Visible = False
        Me.LbAccountName.Visible = False
        Me.LbPhone.Visible = False
        Me.LbRemark.Visible = False
        Me.LbSource.Visible = False
        Me.LbStatus.Visible = False
        Me.LbTypeofPay.Visible = False
        Me.LbVATNum.Visible = False
        Me.LbWebAddress.Visible = False
        Me.LbZhuceCapital.Visible = False
        Me.LbZipCode.Visible = False
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        Me.LinkSave.Visible = False
        Me.LinkEdit.Visible = True
        Customer.PKID = PKID
        Customer.AccountName = Me.TxtAccountName.Text.Trim()
        ' Me.LbAccountName.Text = Me.TxtAccountName.Text
        Customer.Address = Me.TxtAddress.Text.Trim()
        'Me.LbAddress.Text = Me.TxtAddress.Text
        Customer.Bank = Me.TxtBank.Text
        'Me.LbBank.Text = Me.TxtBank.Text
        Customer.BankAccount = Me.TxtBankAccount.Text
        'Me.LbBankAccount.Text = Me.TxtBankAccount.Text
        Customer.BillingName = Me.TxtBillingName.Text
        'Me.LbBillingName.Text = Me.TxtBillingName.Text
        'Me.LbCategory.Text = Me.DPLCategory.SelectedItem.Text
        Customer.Category = Me.DPLCategory.SelectedItem.Value
        Customer.City = Me.TxtCity.Text
        'Me.LbCity.Text = Me.TxtCity.Text
        Customer.Extend1 = Me.TxtPaywarning.Text
        Customer.CustomerAlias = Me.TxtCustomerAlias.Text.Trim()
        'Me.LbCustomerAlias.Text = Me.TxtCustomerAlias.Text
        Customer.CustomerEnglishName = Me.TxtCustomerEnglishName.Text
        'Me.LbCustomerEnglishName.Text = Me.TxtCustomerEnglishName.Text
        Customer.PersonInCharge = StrConv(Me.DPLPersonincharge.SelectedItem.Text, VbStrConv.SimplifiedChinese, 2052)
        If LbCustomerNO.Text = "" Then
            Dim lsm As Integer
            lsm = CustomersDAL.GetMaxIDByType(Me.DPLIndustry.SelectedValue.ToString + Me.DPLCategory.SelectedValue.ToString) + 1
            Customer.CustomerID = Me.DPLIndustry.SelectedItem.Value.ToString + Me.DPLCategory.SelectedItem.Value.ToString + lsm.ToString("000000")
            Me.LbCustomerNO.Text = Me.DPLIndustry.SelectedItem.Value.ToString + Me.DPLCategory.SelectedItem.Value.ToString + lsm.ToString("000000")
        Else
            Customer.CustomerID = Me.LbCustomerNO.Text
        End If
        Customer.CustomerName = Me.TxtCustomerName.Text.Trim()
        'Me.LbCustomerName.Text = Me.TxtCustomerName.Text
        Customer.Email = Me.TxtEmail.Text.Trim()
        'Me.LbEmail.Text = Me.TxtEmail.Text
        If TxtEmployeeNum.Text = "" Then
            Customer.EmployeeNum = 0
        Else
            Customer.EmployeeNum = Me.TxtEmployeeNum.Text
        End If
        'Me.LbEmployeeNum.Text = Me.TxtEmployeeNum.Text
        Customer.Fax = Me.TxtFax.Text
        'Me.LbFax.Text = Me.TxtFax.Text
        Customer.Industry = Me.DPLIndustry.SelectedItem.Text
        Customer.InsertPsrson = UserInfo.CurrentUserCHName
        Customer.Managers = ""
        'Me.LbManagers.Text = Me.TxtManagers.Text

        'Me.LbPersonInCharge.Text =  Me.TxtPersonInCharge.Text
        Customer.Phone = Me.TxtPhone.Text
        'Me.LbPhone.Text = Me.TxtPhone.Text
        If PKID = 0 Then
            Customer.Grade = "D5"
            If Not ViewState("Markplanpkid") Is Nothing Then
                Customer.Grade = "P"
            End If
            Customer.InsertPsrson = UserInfo.CurrentUserCHName
            Customer.RecordCreated = DateTime.Now
        End If
        Customer.Remark = Me.TxtRemark.Text
        'Me.LbRemark.Text = Me.TxtRemark.Text
        Customer.Source = Me.DPLSource.SelectedItem.Text
        'Me.LbSource.Text = Me.DPLSource.SelectedItem.Text
        'Me.LbStatus.Text = Me.DPLStatus.SelectedItem.Text
        Customer.Status = Me.DPLStatus.SelectedValue
        Customer.TypeofPay = Me.DPLTypeofPay.SelectedValue
        'Me.LbTypeofPay.Text = Me.DPLTypeofPay.SelectedItem.Text
        Customer.VATNum = Me.TxtVATNum.Text
        'Me.LbVATNum.Text = Me.TxtVATNum.Text
        Customer.WebAddress = Me.TxtWebAddress.Text
        'Me.LbWebAddress.Text = Me.TxtWebAddress.Text
        If Me.TxtZipCode.Text = "" Then
            Customer.ZipCode = 0
        Else
            Customer.ZipCode = Me.TxtZipCode.Text
        End If

        'Me.LbZipCode.Text = Me.TxtZipCode.Text
        If TxtZhuceCapital.Text = "" Then
            Customer.ZhuceCapital = 0
        Else
            Customer.ZhuceCapital = Me.TxtZhuceCapital.Text
        End If
        'Me.LbZhuceCapital.Text = Me.TxtZhuceCapital.Text
        Dim customerDal As CustomersDAL = New CustomersDAL(Customer)
        PKID = customerDal.Save()
        Me.UcFileDetail1.ParentID = PKID
        Me.UcFileDetail1.ParentCategory = 9
        Me.UcFileDetail1.ParentSubCategory = 1
        Me.UcFileDetail1.SaveDatatoDataBase()

        If Not ViewState("Markplanpkid") Is Nothing Then   '從營銷活動而來
            Dim markmember As MarketMemberInfo = New MarketMemberInfo()
            markmember.PKID = 0
            markmember.ContactName = ""
            markmember.ContactPKID = 0
            markmember.CustomerName = Customer.CustomerName
            markmember.CustomerPKID = Customer.PKID
            markmember.MemberCategory = UserSetCategoryDAL.GetInfoByType(2).Tables(0).Rows(0).Item("CategoryName").ToString
            markmember.PlanPKID = CInt(ViewState("Markplanpkid"))
            markmember.Type = "潛在客戶"

            Dim markmenberdal As MarketMemberDAL = New MarketMemberDAL(markmember)
            markmenberdal.Save()
            Response.Redirect("../Forms/MarketPlanDetail.aspx?pkid=" + ViewState("Markplanpkid").ToString)
        End If

        If Not Request.QueryString("pageindex") Is Nothing And Not Request.QueryString("ismanage") Is Nothing Then
            Response.Redirect("../Forms/CustomerDetail.aspx?pkid=" + PKID.ToString + "&pageindex=" + Request.QueryString(PageIndex).ToString + "&ismanage=" + Request.QueryString("ismanage").ToString)
        Else
            Response.Redirect("../Forms/CustomerDetail.aspx?pkid=" + PKID.ToString)
        End If

    End Sub

    Protected Sub LinkDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkDelete.Click
        CustomersDAL.Delete(PKID)
        Response.Redirect("../Forms/CustomersList.aspx")
    End Sub
#Region "BindLinkButton"
    'Protected Sub BindLinkContactManage()
    '    Dim returnurl As String = "../Forms/ContactManage.aspx?Type=1&CustomerPKID=" + PKID.ToString
    '    Dim title As String = Customer.CustomerName + "聯繫人管理"
    '    LinkContactManage.PostBackUrl = returnurl

    'End Sub

    Protected Sub BindLinkTransacTions()
        Dim returnurl As String = "../Forms/TransactionRecord.aspx?CustomerPKID=" + PKID.ToString
        Dim title As String = Customer.CustomerName + "交易記錄"
        Me.LinkTransacTions.PostBackUrl = returnurl
    End Sub

    Protected Sub BindLinkComplaints()
        Dim returnurl As String = "http://10.162.197.5/cmcfilemanage/Forms/ComplaintsList.aspx"
        Dim title As String = Customer.CustomerName + "投訴記錄"
        Me.LinkComplaints.PostBackUrl = returnurl
    End Sub

    Protected Sub BindLinkGMPCSI()
        Dim returnurl As String = "../Forms/GMPCSIList.aspx?CustomerPKID=" + PKID.ToString
        Dim title As String = Customer.CustomerName + "滿意度調查"
        Me.LinkGMPCSI.PostBackUrl = returnurl
    End Sub

    Protected Sub BindLinkLevelChange()
        Dim returnurl As String = "../Forms/CustomerLevelChange.aspx?CustomerPKID=" + PKID.ToString
        Dim title As String = Customer.CustomerName + "等級變更"
        Me.LinkLevelChange.PostBackUrl = returnurl
    End Sub
#End Region
#Region "BindDatalist"
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        Dim LinkButton1 As LinkButton = CType(e.Item.FindControl("LinkButton1"), LinkButton)
        Dim userpkid As String = ContactDAL.GetContactPKIDByContactName(LinkButton1.Text)
        If Not userpkid.Contains("、") AndAlso userpkid <> 0 Then   '該名字為唯一
            Dim returnurl As String = "../Forms/UserADVinfo.aspx?PKID=" + userpkid.ToString
            Dim title As String = LinkButton1.Text
            LinkButton1.PostBackUrl = returnurl
        Else
            LinkButton1.Attributes.Add("onclick", "alert('該人員未填寫基本資料')")
        End If
    End Sub

#End Region

    Protected Sub LinkBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkBack.Click
        If Not Request.QueryString("pageindex") Is Nothing And Not Request.QueryString("ismanage") Is Nothing Then
            Response.Redirect("../Forms/CustomersList.aspx?pageindex=" + Request.QueryString("pageindex").ToString + "&ismanage=" + Request.QueryString("ismanage").ToString)
        Else
            Response.Redirect("../Forms/CustomersList.aspx")
        End If
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then

                Dim mPKID As Integer = CInt(GridView2.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim ReturnURL As String = "../Forms/CustomerVisitDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                Dim title = e.Row.Cells(1).Text
                HLDetail.NavigateUrl = ReturnURL
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
            End If
        End If
    End Sub

    Protected Sub LinkAddVisits_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkAddVisits.Click
        Response.Redirect("../Forms/CustomerVisitDetail.aspx?CustomerPKID=" + PKID.ToString)
    End Sub
End Class