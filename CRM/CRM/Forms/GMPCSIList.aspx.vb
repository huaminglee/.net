Public Partial Class GMPCSIList
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
                Dim SearchCondition As String = " SubmitMan in ( select  UserName  from Contact where CusTomerPKID =' " + CustomerPKID.ToString + "')"

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
                ViewState(HIDE_SORTFIELD) = "ResultPKID"
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
    Private Property CustomerPKID()
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If
            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal value)
            ViewState("CustomerPKID") = value
        End Set
    End Property

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindGridData(InitSearch)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
        End If
    End Sub
    Private Sub BindGridData(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("View_GEPCSI", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If ds Is Nothing Then
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
            Me.PagerControl1.Visible = False
        Else
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"ResultPKID"}
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then

                Dim LbResultPKID As Label = CType(e.Row.FindControl("LbResultPKID"), Label)
                Dim LbCSITime As Label = CType(e.Row.FindControl("LbCSITime"), Label)
                Dim LbDeptPKID As Label = CType(e.Row.FindControl("LbDeptPKID"), Label)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim ReturnURL As String = String.Format("{3}/CMCFileManage/GMPCSI/GMPCSIMoudle.aspx?DeptPKID={0}&ClientPKID={1}&CSITime={2}", LbDeptPKID.Text.ToString, LbResultPKID.Text.ToString, LbCSITime.Text.ToString, Global_asax.UrlHost)
                Dim title = e.Row.Cells(1).Text
                HLDetail.NavigateUrl = ReturnURL
               
            End If
        End If
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
    End Sub
End Class