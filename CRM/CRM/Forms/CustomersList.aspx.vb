Imports Platform.eAuthorize

Partial Public Class CustomersList
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
#End Region
#Region "屬性"
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
                If IsManage = 1 Then
                    SearchCondition = " RecordDeleted=0"
                Else
                    SearchCondition = String.Format(" RecordDeleted=0 and CHARINDEX (N'{0}',PersonInCharge)>0  ", StrConv(UserInfo.CurrentUserCHName, VbStrConv.SimplifiedChinese, 2052))
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
    Private Property IsManage() As String
        Get
            If ViewState("IsManage") Is Nothing Then
                Return "0"
            End If
            Return ViewState("IsManage")
        End Get
        Set(ByVal value As String)
            ViewState("IsManage") = value
        End Set
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
                ViewState(HIDE_SORTFIELD) = "CustomerName"
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
            If Not Request.QueryString("IsManage") Is Nothing Then
                IsManage = Request.QueryString("IsManage").ToString
            End If
            If Not Request.QueryString("pageindex") Is Nothing Then
                PagerControl1.CurrentPage = CInt(Request.QueryString("pageindex"))
            End If
            BindGridData(InitSearch)

        End If
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("Customers", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If ds Is Nothing Then
            Me.PagerControl1.Visible = False
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
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
                Dim HlCusvisits As HyperLink = CType(e.Row.FindControl("HlCusvisits"), HyperLink)
                Dim ReturnURL As String = "../Forms/CustomerDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
                ReturnURL += "&pageindex=" + PageIndex.ToString + "&ismanage=" + IsManage.ToString
                HLDetail.NavigateUrl = ReturnURL
                HlCusvisits.NavigateUrl = "../Forms/CustomerVisitDetail.aspx?CustomerPKID=" + mPKID.ToString
                Dim LbCategory As Label = CType(e.Row.FindControl("LbCategory"), Label)
                Dim LbCategoryShow As Label = CType(e.Row.FindControl("LbCategoryShow"), Label)
                If LbCategory.Text = "1" Then
                    LbCategoryShow.Text = "內部客戶"
                ElseIf LbCategory.Text = "2" Then
                    LbCategoryShow.Text = "外部客戶"
                End If
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該客戶嗎?');")
                Dim HLGetQuotation As HyperLink = CType(e.Row.FindControl("HLGetQuotation"), HyperLink)
                Dim tourl As String = "../Quotation/QuotationDetail.aspx?CustomerPKID=" + mPKID.ToString
                HLGetQuotation.NavigateUrl = tourl
            End If
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(e.RowIndex).Value)
        If IsManage = 1 Then
            CustomersDAL.Delete(mpkid)
        Else
            CustomersDAL.SetPersoninchargenull(mpkid)
        End If
       
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        Dim NewSearchCondition As String = InitSearch
        If Me.InpSearch.Value <> String.Empty Then
            NewSearchCondition += String.Format(" and (CustomerName like N'%{0}%' or CustomerID like N'%{0}%')", Me.InpSearch.Value.Trim.ToString)
        End If
        ViewState("SearchCondition") = NewSearchCondition
        BindGridData(SearchCondition)
    End Sub
End Class