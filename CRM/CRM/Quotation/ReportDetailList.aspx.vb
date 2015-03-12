Imports Platform.eAuthorize

Partial Public Class ReportDetailList
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
                Dim SearchCondition As String = " RecordDeleted!=1 and RecordDeleted!=2 "
                If CurType Is Nothing Then
                    SearchCondition = " 1>2"
                Else


                    If UserInfo.IsInRoles("EXTERNALWORKER ") OrElse UserInfo.IsInRoles("CRMTECSUPPORT") Then
                        If UserInfo.IsInRoles("OperationsAssistant") Then
                            Select Case CurType
                                Case 99
                                    SearchCondition = " ReportRecordDeleted=2"
                                Case 0
                                    SearchCondition = SearchCondition
                                Case 1, 3
                                    SearchCondition = SearchCondition + "and StateOrder=" + CurType.ToString + " AND IsFinished=0 "
                                                              Case 2  '主管審核
                                    If UserInfo.IsInRoles("Yewuzhuguan") Then
                                        SearchCondition = SearchCondition + "and StateOrder=2 AND IsFinished=0 "
                                    ElseIf UserInfo.IsInRoles("TEDINGSHENHE") Then
                                        SearchCondition = SearchCondition + "and StateOrder=4 AND IsFinished=0 "
                                    ElseIf UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                                        SearchCondition = SearchCondition + "and ( StateOrder=4 or StateOrder=2 ) AND IsFinished=0 "
                                    End If

                                Case 55             '待寄樣品
                                    SearchCondition = SearchCondition + " and SampleCategory='9999-12-31 23:59:59.997' "
                                    Me.BtnSendSample.Visible = True
                                Case 66              '待開發票
                                    SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo='9999-12-31 23:59:59.997' and(( TypeofPay=2 and DuizhangTime!='9999-12-31 23:59:59.997') or  (TypeofPay =1 and TestCategory=1 and DuizhangTime!='9999-12-31 23:59:59.997')  or (TypeofPay =1 and  TestCategory=0)   )"
                                    Me.BtnDoInvoice.Visible = True
                                Case 77              '待寄發票
                                    SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend='9999-12-31 23:59:59.997' "
                                    Me.BtnSendInvoice.Visible = True
                                Case 70
                                    Me.GridView1.Columns(2).Visible = True
                            End Select
                        Else
                            Select Case CurType
                                Case 99         '關聯測試申請系統 ，測試案件待處理
                                    SearchCondition = "ReportRecordDeleted=2 and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                Case 0
                                    SearchCondition = SearchCondition + " and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                Case 1, 3
                                    SearchCondition = SearchCondition + " and StateOrder=" + CurType.ToString + " AND IsFinished=0 " + " and ( Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                  
                                Case 2
                                    SearchCondition = SearchCondition + "and (StateOrder=4 or StateOrder=2) AND IsFinished=0 and (Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"

                                Case 55             '待寄樣品
                                    SearchCondition = SearchCondition + " and  SampleCategory='9999-12-31 23:59:59.997' and (Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                    Me.BtnSendSample.Visible = True
                                Case 66              '待開發票
                                    If UserInfo.IsInRoles("CRM經管") Then
                                        SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo='9999-12-31 23:59:59.997' and(( TypeofPay=2 and DuizhangTime!='9999-12-31 23:59:59.997') or  (TypeofPay =1 and TestCategory=1 and DuizhangTime!='9999-12-31 23:59:59.997')  or (TypeofPay =1 and  TestCategory=0)   )"
                                        Me.BtnDoInvoice.Visible = True
                                    Else
                                        SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo='9999-12-31 23:59:59.997' and(( TypeofPay=2 and DuizhangTime!='9999-12-31 23:59:59.997') or (TypeofPay =1 and TestCategory=1 and DuizhangTime!='9999-12-31 23:59:59.997')  or (TypeofPay =1 and  TestCategory=0)) and (Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                        Me.BtnDoInvoice.Visible = True
                                    End If
                                  
                                Case 77              '待寄發票
                                    SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend='9999-12-31 23:59:59.997' and (Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "')"
                                    Me.BtnSendInvoice.Visible = True
                                Case 70
                                    Me.GridView1.Columns(2).Visible = True
                                    SearchCondition = SearchCondition + " and Extend03='" + UserInfo.CurrentUserID + "' or TecSupport='" + UserInfo.CurrentUserID + "'"
                            End Select
                        End If



                    End If
                    If UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse UserInfo.IsInRoles("OperationsAssistant") OrElse UserInfo.IsInRoles("CRM經管") Then
                        SearchCondition = " RecordDeleted!=1 and RecordDeleted!=2 "
                        Select Case CurType
                            Case 99
                                SearchCondition = " ReportRecordDeleted=2"
                            Case 0
                                SearchCondition = SearchCondition
                            Case 1, 3
                                SearchCondition = SearchCondition + "and StateOrder=" + CurType.ToString + " AND IsFinished=0 "
                                'Case 10             '已結案
                                '    Select Case Me.RadioButtonList1.SelectedValue
                                '        Case 1   '全部
                                '            SearchCondition = SearchCondition + " and IsFinished=1 and Invoicesend!='9999-12-31 23:59:59.997' "
                                '        Case 2   '正常結案
                                '            SearchCondition = SearchCondition + " and IsFinished=1 and Invoicesend!='9999-12-31 23:59:59.997' and pkid not in(select quotationpkid from InvalidQuotation where status=2) "
                                '        Case 3    '異常結案
                                '            SearchCondition = SearchCondition + " and IsFinished=1 and Invoicesend!='9999-12-31 23:59:59.997' and pkid  in(select quotationpkid from InvalidQuotation where status=2) "
                                '    End Select
                            Case 2  '主管審核
                                If UserInfo.IsInRoles("Yewuzhuguan") Then
                                    SearchCondition = SearchCondition + "and StateOrder=2 AND IsFinished=0 "
                                ElseIf UserInfo.IsInRoles("TEDINGSHENHE") Then
                                    SearchCondition = SearchCondition + "and StateOrder=4 AND IsFinished=0 "
                                ElseIf UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                                    SearchCondition = SearchCondition + "and ( StateOrder=4 or StateOrder=2 ) AND IsFinished=0 "
                                End If

                            Case 55             '待寄樣品
                                SearchCondition = SearchCondition + " and SampleCategory='9999-12-31 23:59:59.997' "
                                Me.BtnSendSample.Visible = True
                            Case 66              '待開發票
                                SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo='9999-12-31 23:59:59.997' and(( TypeofPay=2 and DuizhangTime!='9999-12-31 23:59:59.997') or  (TypeofPay =1 and TestCategory=1 and DuizhangTime!='9999-12-31 23:59:59.997')  or (TypeofPay =1 and  TestCategory=0)   )"
                                Me.BtnDoInvoice.Visible = True
                            Case 77              '待寄發票
                                SearchCondition = SearchCondition + " and IsFinished=1 and Invociedo!='9999-12-31 23:59:59.997' and Invoicesend='9999-12-31 23:59:59.997' "
                                Me.BtnSendInvoice.Visible = True
                            Case 70
                                Me.GridView1.Columns(2).Visible = True
                        End Select

                        'Else                                      '客戶

                        '    Select Case CurType
                        '        Case 10
                        '            SearchCondition += " and IsFinished=1 and  Extend01='" + UserInfo.CurrentUserID + "' "
                        '        Case Else
                        '            SearchCondition = "  1>2"

                        '    End Select
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
                ViewState(HIDE_SORTFIELD) = "INshoukuandate"
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
           
            Me.BtnSendInvoice.Attributes.Add("onclick", "return DeleteConfirm('確定對所選記錄已寄送發票！');")
            Me.BtnDoInvoice.Attributes.Add("onclick", "return DeleteConfirm('確定已對所選記錄開發票！');")
            Me.BtnSendSample.Attributes.Add("onclick", "return DeleteConfirm('確定已對所選記錄寄送樣品！');")
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
        Dim ds As DataSet = GridViewPage.GetPageInfoBySearchCondition("View_QuotationAndReport", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
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
            e.Row.Attributes.Add("onmouseover", "this.style.color='#FFFFFF'; currentcolor=this.style.backgroundColor;this.style.backgroundColor='#808080',this.style.fontWeight='';")
            e.Row.Attributes.Add("onmouseout", "this.style.color='#000000'; this.style.backgroundColor=currentcolor,this.style.fontWeight='';")
            If e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate Then
                Dim ChkSelect As CheckBox = CType(e.Row.FindControl("ChkSelect"), CheckBox)
                If CurType <> 55 AndAlso CurType <> 66 AndAlso CurType <> 77 Then
                    ChkSelect.Visible = False
                End If
                Dim lbPKID As Label = CType(e.Row.FindControl("lbPKID"), Label)
                Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
                Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
                Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
                Dim ReturnURL As String = "../Quotation/ReportDetailDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
                If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                    ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
                End If
                ReturnURL += "&Type=" + CurType.ToString
                HLDetail.NavigateUrl = ReturnURL
                'If CurType = 6 Then
                '    Dim bedate As DateTime = CDate(ReportDetailDAL.GetInfoByPKID(mPKID).Extend02)
                '    Dim days As Integer = DateDiff(DateInterval.Day, bedate, DateTime.Now)
                '    If days > 2 Then
                '        e.Row.BackColor = System.Drawing.Color.Salmon
                '    End If
                'ElseIf CurType = 4 Then
                '    Dim bedate As DateTime = CDate(ReportDetailDAL.GetInfoByPKID(mPKID).Extend03)
                '    Dim days As Integer = DateDiff(DateInterval.Day, bedate, DateTime.Now)
                '    If days > 2 Then
                '        e.Row.BackColor = System.Drawing.Color.Salmon
                '    End If
                'End If
                If CurType = 3 Then         '收款逾期
                    Dim bedate As DateTime = CDate(ReportDetailDAL.GetInfoByPKID(mPKID).Extend03)
                    Dim days As Integer = DateDiff(DateInterval.Hour, bedate, DateTime.Now)
                    If days > 48 Then
                        Dim Imagetiomeout As Image = CType(e.Row.FindControl("iMGTimeOut"), Image)
                        Imagetiomeout.Visible = True
                        Dim lbtimeout As Label = CType(e.Row.FindControl("LbTimeOut"), Label)
                        lbtimeout.Text = (days - 48).ToString + "小時"
                    End If
                ElseIf CurType = 99 Then
                    Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_IsHasNoSent", CInt(lbPKID.Text))
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim nosentnum As Integer = CInt(ds.Tables(0).Rows(0).Item(0))
                        If nosentnum > 0 Then
                            Dim Imagetiomeout As Image = CType(e.Row.FindControl("iMGTimeOut"), Image)
                            Imagetiomeout.Visible = True
                            Dim lbtimeout As Label = CType(e.Row.FindControl("LbTimeOut"), Label)
                            lbtimeout.Text = nosentnum.ToString + "份單未送審"
                        End If
                    End If
                End If
                If CurType = 70 AndAlso e.Row.Cells(2).Text = "&nbsp;" Then
                    e.Row.Cells(2).Text = "測試案件待處理狀態"
                End If
            End If
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            Dim CheckAll As CheckBox = CType(e.Row.FindControl("CheckAll"), CheckBox)
            If CurType <> 55 AndAlso CurType <> 66 AndAlso CurType <> 77 Then
                CheckAll.Visible = False
            End If
        End If

    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
    End Sub

    Protected Sub BtnSendSample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendSample.Click
        Dim rowcount As Integer = Me.GridView1.Rows.Count
        If rowcount > 0 Then
            For i As Integer = 0 To rowcount - 1
                Dim mdatagrid As GridViewRow = GridView1.Rows(i)
                If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
                    Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
                    ReportDetailDAL.UPsendsample(mpkid)
                End If
            Next
            BindGrid(SearchCondition)
        End If
    End Sub

    Protected Sub BtnSendInvoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSendInvoice.Click
        Dim rowcount As Integer = Me.GridView1.Rows.Count
        If rowcount > 0 Then
            For i As Integer = 0 To rowcount - 1
                Dim mdatagrid As GridViewRow = GridView1.Rows(i)
                If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
                    Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
                    ReportDetailDAL.UPsendinvoice(mpkid)
                End If
            Next
            BindGrid(SearchCondition)
        End If
    End Sub

    Protected Sub BtnDoInvoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDoInvoice.Click
        Dim rowcount As Integer = Me.GridView1.Rows.Count
        If rowcount > 0 Then
            For i As Integer = 0 To rowcount - 1
                Dim mdatagrid As GridViewRow = GridView1.Rows(i)
                If CType(mdatagrid.FindControl("ChkSelect"), CheckBox).Checked Then
                    Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(mdatagrid.RowIndex).Value)
                    ReportDetailDAL.UPdoinvoice(mpkid)
                End If
            Next
            BindGrid(SearchCondition)
        End If
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim SortFieldName As String = e.SortExpression
        If SortFieldName <> String.Empty Then
            Me.SortField = SortFieldName
        End If
        If Me.SortOrder = "ASC" Then
            Me.SortOrder = "DESC"
        ElseIf Me.SortOrder = "DESC" Then
            Me.SortOrder = "ASC"
        Else
            Me.SortOrder = "DESC"
        End If
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