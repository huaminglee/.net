Imports Platform.eAuthorize

Partial Public Class CustomerLevelChange
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const HIDE_APPLICANTIDX_KEY As String = "ViewState:PKID"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
    Private Const HIDE_SORTFIELD As String = "ViewState:SortField"
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
    Private _CustomerInfo As CustomersInfo
    Private Property CustomerInfo() As CustomersInfo
        Get
            If _CustomerInfo Is Nothing Then
                If CustomerPKID <> 0 Then
                    _CustomerInfo = CustomersDAL.GetInfoByPKID(CustomerPKID)
                Else
                    _CustomerInfo = New CustomersInfo()
                End If
            End If
            Return _CustomerInfo
        End Get
        Set(ByVal value As CustomersInfo)
            _CustomerInfo = value
        End Set
    End Property
    Private _CustomerGradeChangeInfo As CustomerGradeChangeRecordInfo
    Private Property CustomerGradeChangeInfo() As CustomerGradeChangeRecordInfo
        Get
            If _CustomerGradeChangeInfo Is Nothing Then
                If PKID <> 0 Then
                    _CustomerGradeChangeInfo = CustomerGradeChangeRecordDAL.GetInfoByPKID(PKID)
                Else
                    _CustomerGradeChangeInfo = New CustomerGradeChangeRecordInfo()
                End If
            End If
            Return _CustomerGradeChangeInfo
        End Get
        Set(ByVal value As CustomerGradeChangeRecordInfo)
            _CustomerGradeChangeInfo = value
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
                Dim SearchCondition As String = " RecordDeleted=0  and CustomerPKID=" + CustomerPKID.ToString

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
            BindControlData()
            BindGridData(InitSearch)
        End If
    End Sub
    Private Sub GetParam()
        If Not Request.QueryString("CustomerPKID") Is Nothing Then
            CustomerPKID = Convert.ToInt32(Request.QueryString("CustomerPKID"))
        End If
    End Sub
    Private Sub BindControlData()
        If Not CustomerInfo Is Nothing Then
            If Not CustomerPKID = 0 Then

                Me.LbCustomerID.Text = CustomerInfo.CustomerID
                Me.LbInserDate.Text = CustomerInfo.RecordCreated
                Me.LbInsertPerson.Text = CustomerInfo.InsertPsrson
                Me.LbCustomerName.Text = CustomerInfo.CustomerName
                Select Case CustomerInfo.Grade.ToString.Substring(0, 1)
                    Case "P"
                        Me.LbOldGrade.Text = "潛在客戶"
                    Case "N"
                        Me.LbOldGrade.Text = "洽談中"
                    Case "D"
                        Me.LbOldGrade.Text = "交易客戶" + CustomerInfo.Grade.ToString.Substring(1, CustomerInfo.Grade.ToString.Length - 1) + "級"
                    Case "F"
                        Me.LbOldGrade.Text = "凍結客戶"
                    Case "O"
                        Me.LbOldGrade.Text = "流失客戶"

                End Select

            End If
        End If
    End Sub
    Private Sub BindGridData(ByVal SearchCondotion As String)

        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("CustomerGradeChangeRecord", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
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
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                Dim LbOldGrade As Label = CType(e.Row.FindControl("LbOldGrade"), Label)
                Dim LbOldGradeShow As Label = CType(e.Row.FindControl("LbOldGradeShow"), Label)

                Dim LbNewGrade As Label = CType(e.Row.FindControl("LbNewGrade"), Label)
                Dim LbNewGradeShow As Label = CType(e.Row.FindControl("LbNewGradeShow"), Label)
                Select Case LbOldGrade.Text.ToString.Substring(0, 1)
                    Case "P"
                        LbOldGradeShow.Text = "潛在客戶"
                    Case "N"
                        LbOldGradeShow.Text = "洽談中"
                    Case "D"
                        LbOldGradeShow.Text = "交易客戶" + LbOldGrade.Text.ToString.Substring(1, LbOldGrade.Text.ToString.Length - 1) + "級"
                    Case "F"
                        LbOldGradeShow.Text = "凍結客戶"
                    Case "O"
                        LbOldGradeShow.Text = "流失客戶"
                End Select
                Select Case LbNewGrade.Text.ToString.Substring(0, 1)
                    Case "P"
                        LbNewGradeShow.Text = "潛在客戶"
                    Case "N"
                        LbNewGradeShow.Text = "洽談中"
                    Case "D"
                        LbNewGradeShow.Text = "交易客戶" + LbNewGrade.Text.ToString.Substring(1, LbNewGrade.Text.ToString.Length - 1) + "級"
                    Case "F"
                        LbNewGradeShow.Text = "凍結客戶"
                    Case "O"
                        LbNewGradeShow.Text = "流失客戶"
                End Select
                Dim LbReason As Label = CType(e.Row.FindControl("LbReason"), Label)
                If LbReason.Text.Length > 10 Then
                    LbReason.ToolTip = LbReason.Text
                    LbReason.Text = LbReason.Text.Substring(0, 10) + "..."
                End If
            End If
        End If
    End Sub

    Protected Sub LinkSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkSave.Click
        CustomerGradeChangeInfo.PKID = PKID
        CustomerGradeChangeInfo.CustomerPKID = CustomerPKID
        CustomerGradeChangeInfo.OldGrade = CustomerInfo.Grade
        CustomerGradeChangeInfo.NewGrade = Me.DPLNewGrade.SelectedValue + Me.Txtlevel.Text
        CustomerGradeChangeInfo.Reason = Me.TxtChangeReason.Text
        CustomerGradeChangeInfo.RecordCreated = DateTime.Now
        CustomerGradeChangeInfo.RecordDeleted = 0
        CustomerGradeChangeInfo.ChangePerson = UserInfo.CurrentUserCHName + "/" + UserInfo.CurrentUserID

        Dim customerChangedal As CustomerGradeChangeRecordDAL = New CustomerGradeChangeRecordDAL(CustomerGradeChangeInfo)
        customerChangedal.Save()

        If Me.DPLNewGrade.SelectedValue = "D" Then
            CustomerInfo.Grade = Me.DPLNewGrade.SelectedValue + Me.Txtlevel.Text
        Else
            CustomerInfo.Grade = Me.DPLNewGrade.SelectedValue
        End If

        Dim CustomerDal As CustomersDAL = New CustomersDAL(CustomerInfo)
        CustomerDal.Save()
        BindControlData()
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGridData(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGridData(SearchCondition)
    End Sub

    Protected Sub LinkBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkBack.Click
        If CustomerPKID <> 0 Then
            Response.Redirect("../Forms/CustomerDetail.aspx?PKID=" + CustomerPKID.ToString)
        Else
            Response.Redirect("../Forms/CustomerDetail.aspx")
        End If
    End Sub
End Class