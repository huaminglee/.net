Imports Platform.eAuthorize

Partial Public Class SendSampleList
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
    Private Const _RequestType As String = "ViewState:Type"
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
                Dim SearchCondition As String = "  (RecordDeleted=0 or RecordDeleted=3) "
                If CurType Is Nothing Then
                    SearchCondition = " 1>2"
                Else
                    If UserInfo.IsInRoles("storekeeper") OrElse UserInfo.IsInRoles("Sys_Administrator ") Then
                        Select Case CurType
                            Case 1
                                SearchCondition += " and SampleCategory='9999-12-31 23:59:59.997' "
                            Case 2
                                SearchCondition += " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend='9999-12-31 23:59:59.997' "
                            Case 10
                                SearchCondition += " and SampleCategory!='9999-12-31 23:59:59.997' "
                            Case 20
                                SearchCondition += " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend!='9999-12-31 23:59:59.997' "
                        End Select
                    ElseIf UserInfo.IsInRoles("EXTERNALWORKER") OrElse UserInfo.IsInRoles("CRMTECSUPPORT") Then
                        Select Case CurType
                            Case 1
                                SearchCondition += " and SampleCategory='9999-12-31 23:59:59.997' and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                            Case 2
                                SearchCondition += " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend='9999-12-31 23:59:59.997' and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                            Case 10
                                SearchCondition += " and SampleCategory!='9999-12-31 23:59:59.997' and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                            Case 20
                                SearchCondition += " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend!='9999-12-31 23:59:59.997' and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                        End Select

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
                ViewState(HIDE_SORTFIELD) = "QuotationNO"
                ViewState(HIDE_SortOrder) = "ASC"
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
            BindGrid(InitSearch)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("Type") Is Nothing Then
            CurType = Convert.ToInt32(Request.QueryString("Type"))
        End If
    End Sub
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("View_QuotationAndReport", SearchCondition, "*,dbo.concatquo_SampleInfo(PKID) AS Sample,dbo.concatquo_TestNosInfo(PKID) as TestNos", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
        If ds Is Nothing Then
            Me.emptyinfo.Visible = True
            Me.PagerControl1.Visible = False
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = False
            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"ReportPKID"}
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF';this.style.cursor='hand'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)

                Dim ReturnURL As String = "../Quotation/SendSamples.aspx?PKID=" + mPKID.ToString
                HLDetail.NavigateUrl = ReturnURL

                e.Row.Attributes.Add("onclick", "window.location.href='" + ReturnURL + "';")
            End If
        End If


    End Sub
    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim NewSearchCondition As String = InitSearch
        If Me.TxtSearchCondition.Text <> String.Empty Then
            NewSearchCondition += String.Format(" and (CustomerName like N'%{0}%' or QuotationNO like N'%{0}%')", Me.TxtSearchCondition.Text.Trim.ToString)
        End If
        ViewState("SearchCondition") = NewSearchCondition
        BindGrid(SearchCondition)
    End Sub
End Class