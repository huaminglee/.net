Imports Platform.eAuthorize

Partial Public Class TransactionRecord
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
    Private Const HIDE_SortOrder As String = "ViewState:SortOrder"
#End Region
#Region "屬性"
    Private Property CustomerPKID() As Integer
        Get
            If ViewState("CustomerPKID") Is Nothing Then
                Return 0
            End If

            Return Convert.ToInt32(ViewState("CustomerPKID"))
        End Get
        Set(ByVal Value As Integer)
            ViewState("CustomerPKID") = Value
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
                Dim SearchCondition As String = " IsFinished =1 and CustomerPKID='" + CustomerPKID.ToString + "'"

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
            If Not Request.QueryString("CustomerPKID") Is Nothing Then
                CustomerPKID = CInt(Request.QueryString("CustomerPKID"))
            End If
            If UserInfo.IsInRoles("EXTERNALWORKER") OrElse UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
                Me.GridView1.Columns(5).Visible = True
            End If

            GetCount()
            BindGrid(InitSearch)
        End If
    End Sub
    Protected Sub GetCount()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetCountByCustomerPKID", CustomerPKID)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.LbQuotationNums.Text = ds.Tables(0).Rows(0).Item("quotationnums").ToString
            Me.LbTotalMoney.Text = ds.Tables(0).Rows(0).Item("totalmoney").ToString
            Me.LbSamoleNums.Text = ds.Tables(1).Rows(0).Item("samplenums").ToString
            Me.LbTestItemNums.Text = ds.Tables(2).Rows(0).Item("testitemnums").ToString
        End If
    End Sub
    Protected Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("View_TestHistory", SearchCondition, "*", SortField, PageSize, PageIndex, TotalRecord)
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
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If UserInfo.IsInRoles("EXTERNALWORKER") Then
                Dim rowindex As String = (e.Row.RowIndex + 2).ToString("00")
                Dim aname As String = "GridView1_ctl" + rowindex + "_HLCopy"
                e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; document.getElementById('" + aname + "').style.display = 'inline'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
                e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; document.getElementById('" + aname + "').style.display = 'none'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            Else
                e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
                e.Row.Attributes.Add("onmouseout", "this.style.color='#000000';this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            End If
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim ReturnURL As String = "../Quotation/QuotationDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                HLDetail.NavigateUrl = ReturnURL
                Dim HLCopy As HyperLink = CType(e.Row.FindControl("HLCopy"), HyperLink)
                Dim copyurl As String = "../Quotation/QuotationDetail.aspx?C=1&PKID=" + mPKID.ToString
                HLCopy.NavigateUrl = "#"
                HLCopy.Attributes.Add("onclick", "if (confirm('確定要以該報價單為副本生成新的報價單嗎??')){window.location='" + copyurl + "'}")

            End If
        End If
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim NewSearchCondition As String = InitSearch
        If Me.TxtSearchCondition.Text <> String.Empty Then
            NewSearchCondition += String.Format(" and (TestItemName like '%{0}%' or QuotationNO like '%{0}%' or ServiceType like '%{0}%' or SampleName like '%{0}%')", Me.TxtSearchCondition.Text.Trim.ToString)
        End If
        ViewState("SearchCondition") = NewSearchCondition
        BindGrid(SearchCondition)
    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBack.Click
        If CustomerPKID <> 0 Then
            Response.Redirect("../Forms/CustomerDetail.aspx?PKID=" + CustomerPKID.ToString)
        Else
            Response.Redirect("../Forms/CustomerDetail.aspx")
        End If
    End Sub
End Class