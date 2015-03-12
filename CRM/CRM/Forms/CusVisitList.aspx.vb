Imports Platform.eAuthorize

Partial Public Class CusVisitList
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
    Private Const _RequestType As String = "ViewState:Type"
#End Region
#Region "Properties"
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
                SearchCondition = "  RecordDeleted=0"
                If UserInfo.IsInRoles("cusvisitmanage") Then
                    If CurType = 1 Then   '业务员未完成
                        SearchCondition += " and  IsFinished=0"
                    ElseIf CurType = 2 Then '业务员已完
                        SearchCondition += " and  IsFinished=1"
                    ElseIf CurType = 3 Then  '主管未完成
                        SearchCondition += " and  StateOrder=2"
                    ElseIf CurType = 4 Then  '主管已完成
                        SearchCondition += " and  IsFinished=1"
                    End If
                Else
                    If CurType = 1 Then   '业务员未完成
                        SearchCondition += String.Format(" and QuoterName=N'{0}' and IsFinished=0 ", UserInfo.CurrentUserCHName)
                    ElseIf CurType = 2 Then '业务员已完
                        SearchCondition += String.Format(" and QuoterName=N'{0}' and IsFinished=1 ", UserInfo.CurrentUserCHName)
                    ElseIf CurType = 3 Then  '主管未完成
                        SearchCondition += " and  StateOrder=2"
                    ElseIf CurType = 4 Then  '主管已完成
                        SearchCondition += " and  IsFinished=1"
                    End If
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


    Private Property SortField() As String
        Get
            If ViewState(HIDE_SORTFIELD) Is Nothing Then
                ViewState(HIDE_SORTFIELD) = "VisitDate"
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
    '''<summary>
    '''當前請求狀態
    '''</summary>
    Private Property CurType() As String
        Get
            Return CStr(ViewState(_RequestType))
        End Get
        Set(ByVal Value As String)
            ViewState(_RequestType) = Value
        End Set
    End Property
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            GetParam()
            BindVisits(InitSearch)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
        If Not Request.QueryString("pageindex") Is Nothing Then
            PageIndex = CInt(Request.QueryString("pageindex"))
        End If
    End Sub
    Private Sub BindVisits(ByVal SearchCondition As String)

        Dim TotalRecord2 As Integer = 0
        Dim ds2 As DataSet = GridViewPage.GetPageInfoBySearchCondition("CustomerVisits", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord2)
        If ds2 Is Nothing Then
            Me.emptyinfo.Visible = True
            Me.GridView2.DataSource = Nothing
            Me.GridView2.DataBind()
            Me.PagerControl1.Visible = False
        Else
            Me.emptyinfo.Visible = False
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds2.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView2.DataSource = ds2
            Me.GridView2.DataKeyNames = New String() {"PKID"}
            Me.GridView2.DataBind()
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim NewSearchCondition As String = InitSearch
        If Me.TxtSearchCondition.Text <> String.Empty Then
            NewSearchCondition += String.Format(" and (CustomerName like '%{0}%')", Me.TxtSearchCondition.Text.Trim.ToString)
        End If
        ViewState("SearchCondition") = NewSearchCondition
        BindVisits(SearchCondition)
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

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(Me.GridView2.DataKeys(e.RowIndex).Value)
        CustomerVisitsDAL.Delete(mpkid)
        BindVisits(SearchCondition)
    End Sub
End Class