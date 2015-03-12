Imports Platform.eAuthorize

Partial Public Class ContactManage
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
#End Region
#Region "Properties"
    ''' <summary>
    ''' 當前客戶PKID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal value As Integer)
            ViewState("CustomerPKID") = value
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
    Private Property Type() As Integer
        Get
            If ViewState("Type") Is Nothing Then
                Return 1
            End If
            Return Convert.ToInt32(ViewState("Type"))
        End Get
        Set(ByVal value As Integer)
            ViewState("Type") = value
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
    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String
                If Type = 1 Then           '客戶的聯繫人
                    SearchCondition = " Type=1 and RecordDeleted=0  and CustomerPKID=" + CustomerPKID.ToString

                ElseIf Type = 2 Then        '業務員的聯繫人

                    SearchCondition = String.Format(" PKID IN (select ContactPKID from ContactManage where Type=2 and RecordDeleted=0  and CustomerPKID={0} union select pkid from contact where  CustomerPKID in (select PKID from Customers where RecordDeleted=0 and PersonInCharge=N'{1}'))", ContactPKID.ToString, StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
                End If

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
                ViewState(HIDE_SORTFIELD) = "PKID"
                ViewState(HIDE_SortOrder) = "DESC"
            End If
            Return ViewState(HIDE_SORTFIELD).ToString
        End Get
        Set(ByVal Value As String)
            ViewState(HIDE_SORTFIELD) = Value
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
            BindGridData(InitSearch)
            Me.TxtSID.Attributes.Add("readonly", True)
            Me.TxtName.Attributes.Add("readonly", True)
            Me.TxtCustomerName.Attributes.Add("readonly", True)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("Type") Is Nothing Then
            Type = Convert.ToInt32(Request.QueryString("Type"))
        End If
        If Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = ContactDAL.GetCustomerPKIDByUserSID(UserInfo.CurrentUserID)
        Else
            CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
        End If
        If CustomerPKID = 0 AndAlso Type = 1 Then
            Response.Write("<script > alert('您還未填寫公司信息，請先填寫');window.location.href ='../Manage/UserADVInfo.aspx' </script>")
        End If
        If Not Request.QueryString("pageindex") Is Nothing Then
            PagerControl1.CurrentPage = CInt(Request.QueryString("pageindex"))
        End If
        Dim CurContactInfo As ContactInfo = ContactDAL.GetInfoByUserSID(UserInfo.CurrentUserID)
        ContactPKID = CurContactInfo.PKID

    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("Contact", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If ds Is Nothing Then
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
            Me.PagerControl1.Visible = False
        Else
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
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
                ReturnURL += "&pageindex=" + PagerControl1.CurrentPage.ToString
                Dim title = e.Row.Cells(1).Text
                HLDetail.NavigateUrl = ReturnURL
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該聯繫人嗎?');")
            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim lbPKID As Label = CType(Me.GridView1.Rows(e.RowIndex).FindControl("lbPKID"), Label)
        Dim mpkid As Integer = CInt(lbPKID.Text)
        ContactManageDAL.DeleteByContactPKIDandCuspkid(ContactPKID, mpkid)
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
        If Me.HiddenContactPKID.Value <> "0" Then


            Dim newcontactmanage As ContactManageInfo = New ContactManageInfo()
            newcontactmanage.PKID = 0
            newcontactmanage.Type = Type
            newcontactmanage.ContactPKID = Me.HiddenContactPKID.Value
            If Type = 1 Then
                newcontactmanage.CustomerPKID = CustomerPKID
            ElseIf Type = 2 Then
                newcontactmanage.CustomerPKID = ContactPKID
            End If
            newcontactmanage.RecordCreated = DateTime.Now
            newcontactmanage.InsertPerson = UserInfo.CurrentUserCHName
            Dim newcontactdal As ContactManageDAL = New ContactManageDAL(newcontactmanage)
            newcontactdal.Save()
            BindGridData(SearchCondition)

            Me.HiddenContactPKID.Value = "0"
            Me.TxtCustomerName.Text = ""
            Me.TxtName.Text = ""
            Me.TxtSID.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim isincontactmanage As Integer = 0
            Dim DS As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ContactManage_IsinByContactPKID", ContactPKID, mPKID)
            If DS.Tables(0).Rows.Count > 0 Then
                isincontactmanage = CInt(DS.Tables(0).Rows(0).Item("isin"))
            End If
            If isincontactmanage > 0 Then
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Visible = True
            End If
        End If
    End Sub
End Class