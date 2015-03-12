Imports Platform.eAuthorize

Partial Public Class TestApplyList
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
                Dim SearchCondition As String = String.Empty
                If CurType Is Nothing Then
                    SearchCondition = " 1>2"
                Else
                    If UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                        Select Case CurType
                            Case 3, 4, 5
                                SearchCondition = SearchCondition + " StatusType=" + CurType.ToString + " AND IsFinished=0 "
                            Case 6           '已結案
                                SearchCondition = SearchCondition + " IsFinished>0 "
                        End Select
                    ElseIf UserInfo.IsInRoles("EXTERNALWORKER ") Then
                        Select Case CurType
                            Case 3, 4, 5
                                SearchCondition = SearchCondition + " StatusType=" + CurType.ToString + " AND IsFinished=0 " + " and Extend03='" + UserInfo.CurrentUserID + "' "
                            Case 6           '已結案
                                SearchCondition = SearchCondition + " IsFinished>0 " + " and Extend03='" + UserInfo.CurrentUserID + "' "
                        End Select
                    Else                                      '客戶

                        Select Case CurType
                            Case 3, 4, 5
                                SearchCondition = SearchCondition + " StatusType= " + CurType.ToString + " AND IsFinished=0 " + " and Extend01='" + UserInfo.CurrentUserID + "' "
                            Case 6                           '報告處理中
                                SearchCondition = SearchCondition + "  IsFinished=1 " + " and Extend01='" + UserInfo.CurrentUserID + "' "
                           
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
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("View_TestApplyInfo", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
        If ds Is Nothing Then
            Me.PagerControl1.Visible = False
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        Else

            Me.PagerControl1.Visible = True
            Me.PagerControl1.TotalRecords = CInt(ds.Tables(1).Rows(0)("TotalRecord"))
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"ApplyPKID"}
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then

                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text

                Dim ReturnURL As String = Global_asax.UrlHost + "/TestApplyManage/Frameset/Index.aspx?PageType=apply"
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.Target = "_blank"
                HLDetail.NavigateUrl = ReturnURL
                If e.Row.Cells(5).Text.Length > 20 Then
                    e.Row.Cells(5).ToolTip = e.Row.Cells(5).Text
                    e.Row.Cells(5).Text = e.Row.Cells(5).Text.Substring(0, 20) + "..."
                End If
                If e.Row.Cells(2).Text.Length > 20 Then
                    e.Row.Cells(2).ToolTip = e.Row.Cells(2).Text
                    e.Row.Cells(2).Text = e.Row.Cells(2).Text.Substring(0, 20) + "..."
                End If
            End If
        End If

    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
    End Sub
End Class