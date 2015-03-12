Imports Platform.eAuthorize

Partial Public Class QuotationList
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
                    SearchCondition = "  1>2"
                Else
                    If UserInfo.IsInRoles("EXTERNALWORKER") Then                                     '業務員
                        Select Case CurType
                            Case 90
                                Me.GridView1.Columns(1).Visible = True
                                SearchCondition = SearchCondition + " and ( IsFinished =0 or (IsFinished=1 and pkid in (select quotationpkid from reportdetail where Extend05='9999-12-31 23:59:59.997')) ) "
                            Case 0                 '我申請的案件

                                Me.GridView1.Columns(1).Visible = True
                                SearchCondition = SearchCondition + " and  Extend03='" + UserInfo.CurrentUserID + "' "
                            Case 1, 2, 4
                                SearchCondition = SearchCondition + " and StateOrder=" + CurType.ToString + " AND IsFinished=0 " + " and Extend03='" + UserInfo.CurrentUserID + "' "
                            Case 3             '待審核
                                SearchCondition = SearchCondition + "and ( StateOrder=3 or StateOrder=5 or StateOrder=6 ) AND IsFinished=0 and Extend03='" + UserInfo.CurrentUserID + "' "
                            Case 99             '已生成申請單
                                SearchCondition = SearchCondition + " and IsFinished>0 and PKID not in(select QuotationPKID FROM ReportDetail) " + " and Extend03='" + UserInfo.CurrentUserID + "' "
                            Case 88              '異常結案 業務員看到自己申請的未核准和已駁回的
                                Select Case Me.RadioButtonList2.SelectedValue
                                    Case 1        '待處理
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=1 and AddUserID='{0}' and ConfirmDate='9999-12-31 23:59:59.997' )", UserInfo.CurrentUserID)
                                    Case 2         '已核准
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=2 and AddUserID='{0}')", UserInfo.CurrentUserID)
                                    Case 3         '已駁回
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=3 and AddUserID='{0}' )", UserInfo.CurrentUserID)
                                End Select
                            Case 10              '已結案
                                Select Case Me.RadioButtonList1.SelectedValue
                                    Case 1
                                        SearchCondition = SearchCondition + " and  Extend03='" + UserInfo.CurrentUserID + "' "
                                    Case 2     '正常結案
                                        SearchCondition = SearchCondition + " and PKID in ( select quotationpkid from ReportDetail where Extend05 !='9999-12-31 23:59:59.997') and pkid not in (select quotationpkid from InvalidQuotation where Recorddeleted =0 and Status =2)" + " and  Extend03='" + UserInfo.CurrentUserID + "' "
                                    Case 3     '異常結案
                                        SearchCondition = SearchCondition + " and pkid in (select quotationpkid from InvalidQuotation where Recorddeleted =0 and Status =2 ) " + " and  Extend03='" + UserInfo.CurrentUserID + "' "
                                End Select

                        End Select
                    ElseIf UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") OrElse UserInfo.IsInRoles("TEDINGSHENHE") Then
                        Select Case CurType
                            Case 90
                                Me.GridView1.Columns(1).Visible = True
                                SearchCondition = SearchCondition + " and ( IsFinished =0 or (IsFinished=1 and pkid in (select quotationpkid from reportdetail where Extend05='9999-12-31 23:59:59.997')) ) "

                            Case 0                 '所有進行中案件
                                Me.GridView1.Columns(1).Visible = True
                                SearchCondition = SearchCondition + " and ( IsFinished =0 or (IsFinished=1 and pkid in (select quotationpkid from reportdetail where Extend05='9999-12-31 23:59:59.997')) ) "
                            Case 1, 2, 4
                                SearchCondition = SearchCondition + "and StateOrder=" + CurType.ToString + " AND IsFinished=0 "
                            Case 3
                                SearchCondition = SearchCondition + "and ( StateOrder=3 or StateOrder=5 or StateOrder=6 ) AND IsFinished=0 "
                            Case 99             '已生成申請單
                                SearchCondition = SearchCondition + "and IsFinished>0 and PKID not in(select QuotationPKID FROM ReportDetail) "
                            Case 88              '異常結案  主管看到待自己審核的
                                Select Case Me.RadioButtonList2.SelectedValue
                                    Case 1        '待處理
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=1 and ConfirmUserID='{0}' and ConfirmDate='9999-12-31 23:59:59.997' )", UserInfo.CurrentUserID)
                                    Case 2         '已核准
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=2 and ConfirmUserID='{0}')", UserInfo.CurrentUserID)
                                    Case 3         '已駁回
                                        SearchCondition = SearchCondition + String.Format(" and PKID in(select QuotationPKID FROM InvalidQuotation where Status=3 and ConfirmUserID='{0}' )", UserInfo.CurrentUserID)
                                End Select
                            Case 10              '已結案
                                Select Case Me.RadioButtonList1.SelectedValue
                                    Case 1
                                    Case 2
                                        SearchCondition = SearchCondition + " and PKID in ( select quotationpkid from ReportDetail where Extend05 !='9999-12-31 23:59:59.997')"
                                    Case 3
                                        SearchCondition = SearchCondition + " and  FinishTime !='9999-12-31 23:59:59.997' and PKID not in (select quotationpkid from ReportDetail )"
                                End Select
                            Case 77              '待我審核案件
                                If UserInfo.IsInRoles("ZHONGXINZHUGUAN") Then
                                    SearchCondition = SearchCondition + " and StateOrder=6 AND IsFinished=0"
                                ElseIf UserInfo.IsInRoles("Yewuzhuguan") Then
                                    SearchCondition = SearchCondition + " and StateOrder=3 AND IsFinished=0"
                                ElseIf UserInfo.IsInRoles("TEDINGSHENHE") Then
                                    SearchCondition = SearchCondition + " and StateOrder=5 AND IsFinished=0"
                                Else
                                    SearchCondition = SearchCondition + " AND 1>2"
                                End If


                        End Select
                    Else                                                                                 '客戶
                        Select Case CurType
                            Case 10 ' 我的所有報價單
                                Select Case Me.RadioButtonList1.SelectedValue
                                    Case 1
                                        SearchCondition = SearchCondition + " and  Extend01='" + UserInfo.CurrentUserID + "' "
                                    Case 2     '正常結案
                                        SearchCondition = SearchCondition + " and PKID in ( select quotationpkid from ReportDetail where Extend05 !='9999-12-31 23:59:59.997') and pkid not in (select quotationpkid from InvalidQuotation where Recorddeleted =0 and Status =2)" + " and  Extend01='" + UserInfo.CurrentUserID + "' "
                                    Case 3     '異常結案
                                        SearchCondition = SearchCondition + " and pkid in (select quotationpkid from InvalidQuotation where Recorddeleted =0 and Status =2 ) " + " and  Extend01='" + UserInfo.CurrentUserID + "' "
                                End Select
                            Case 55      '所有案件進度
                                SearchCondition = SearchCondition + " and Extend01='" + UserInfo.CurrentUserID + "' "
                            Case 54        '待回傳報價單
                                SearchCondition = SearchCondition + " and StateOrder=4 and Extend01='" + UserInfo.CurrentUserID + "' "
                            Case Else
                                SearchCondition = "  1>2"
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
           
            If CurType = 10 Then         '已結案
                Me.GridView1.Columns(6).Visible = False
                Me.BtnExcel.Visible = True
                Me.RadioButtonList1.Visible = True
                Me.GridView1.Columns(7).Visible = True
            ElseIf CurType = 88 Then          '異常結案處理
                Me.RadioButtonList2.Visible = True
            ElseIf CurType = 55 Then   '用戶
                Me.GridView1.Columns(0).Visible = False
                Me.GridView1.Columns(1).Visible = True
            End If
            BindGrid(InitSearch)
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
    Private Sub BindGrid(ByVal SearchCondition As String)
        Dim TotalRecord As Integer = 0
        Dim ds As DataSet = New DataSet()
        If CurType = 10 Then
            Select Case Me.RadioButtonList1.SelectedValue
                Case 1
                    ds = GridViewPage.GetPageInfoBySearchCondition("View_QuotationAllfinished", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
                Case 2
                    ds = GridViewPage.GetPageInfoBySearchCondition("Quotation", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
                Case 3
                    ds = GridViewPage.GetPageInfoBySearchCondition("View_QuotationAllfinished", SearchCondition, "*", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
            End Select
        Else
            ds = GridViewPage.GetPageInfoBySearchCondition("Quotation", SearchCondition, "*,dbo.concatquo_SampleInfo(PKID) AS Sample", SortField + " " + SortOrder, PageSize, PageIndex, TotalRecord)
        End If
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
                ReturnURL += "&Type=" + CurType.ToString
                HLDetail.NavigateUrl = ReturnURL
                If CurType = 0 OrElse CurType = 55 Then
                    Dim curquotation As QuotationInfo = QuotationDAL.GetInfoByPKID(mPKID)
                    Dim curcustomer As CustomersInfo = CustomersDAL.GetInfoByPKID(curquotation.CustomerPKID)
                    Dim LbCurrentState As Label = CType(e.Row.FindControl("LbCurrentState"), Label)
                    If LbCurrentState.Text = "完成狀態" Then
                        Dim reportinfo As ReportDetailInfo = ReportDetailDAL.GetInfoByQuotationPKID(mPKID)
                        If reportinfo Is Nothing Then
                            LbCurrentState.Text = "測試中"
                        ElseIf reportinfo.IsFinished = 0 AndAlso reportinfo.StateName <> String.Empty Then
                            LbCurrentState.Text = reportinfo.StateName
                        ElseIf reportinfo.IsFinished = 0 AndAlso reportinfo.StateName = String.Empty Then
                            LbCurrentState.Text = "測試中"
                        ElseIf (reportinfo.IsFinished = 1 AndAlso curquotation.FinishTime = "9999-12-31 23:59:59.997" AndAlso curcustomer.TypeofPay = 2) OrElse (reportinfo.IsFinished = 1 AndAlso curquotation.FinishTime = "9999-12-31 23:59:59.997" AndAlso curquotation.TestCategory = 1) Then
                            LbCurrentState.Text = "待對賬"
                        ElseIf reportinfo.IsFinished = 1 AndAlso reportinfo.Extend05 = "9999-12-31 23:59:59.997" Then
                            LbCurrentState.Text = "待開發票中"
                        ElseIf reportinfo.IsFinished = 1 AndAlso reportinfo.Extend05 <> "9999-12-31 23:59:59.997" AndAlso reportinfo.Extend06 = "9999-12-31 23:59:59.997" Then
                            LbCurrentState.Text = "待寄送發票中"
                        ElseIf reportinfo.IsFinished = 1 AndAlso reportinfo.Extend05 <> "9999-12-31 23:59:59.997" AndAlso reportinfo.Extend06 <> "9999-12-31 23:59:59.997" AndAlso reportinfo.Extend04 = "9999-12-31 23:59:59.997" Then
                            LbCurrentState.Text = "待寄送樣品中"
                        ElseIf (reportinfo.IsFinished = 1 AndAlso reportinfo.Extend05 <> "9999-12-31 23:59:59.997" AndAlso reportinfo.Extend06 <> "9999-12-31 23:59:59.997" AndAlso reportinfo.Extend04 <> "9999-12-31 23:59:59.997") OrElse reportinfo.RecordDeleted = 2 Then
                            LbCurrentState.Text = "已結案"

                        End If
                    ElseIf LbCurrentState.Text = "客戶回傳報價單狀態" AndAlso QuotationDAL.GetInfoByPKID(mPKID).FinishTime <> "9999-12-31 23:59:59.997" Then
                        LbCurrentState.Text = "已結案"
                    ElseIf LbCurrentState.Text = "開始狀態" AndAlso QuotationDAL.GetInfoByPKID(mPKID).FinishTime <> "9999-12-31 23:59:59.997" Then
                        LbCurrentState.Text = "已結案"
                    End If
                    Dim hooefinifhdate As DateTime = CDate(e.Row.Cells(7).Text)
                    Dim hous As Integer = DateDiff(DateInterval.Hour, hooefinifhdate, DateTime.Now)
                    If hous > 48 AndAlso LbCurrentState.Text <> "已結案" Then
                        Dim iMGTimeOut As Image = CType(e.Row.FindControl("iMGTimeOut"), Image)
                        Dim LbTimeOut As Label = CType(e.Row.FindControl("LbTimeOut"), Label)
                        iMGTimeOut.Visible = True
                        LbTimeOut.Text = (hous).ToString + "小時"
                    End If


                End If
                Dim BtnCancel As ImageButton = TryCast(e.Row.FindControl("BtnDelete"), ImageButton)
                BtnCancel.Attributes.Add("onclick", " return confirm('確定要刪除該記錄嗎?');")
                Dim HLCopy As HyperLink = CType(e.Row.FindControl("HLCopy"), HyperLink)
                Dim copyurl As String = "../Quotation/QuotationDetail.aspx?C=1&PKID=" + mPKID.ToString
                HLCopy.NavigateUrl = "#"
                HLCopy.Attributes.Add("onclick", "if (confirm('確定要以該報價單為副本生成新的報價單嗎??')){window.location='" + copyurl + "'}")
                If e.Row.Cells(6).Text.Length > 20 Then
                    e.Row.Cells(6).ToolTip = e.Row.Cells(6).Text
                    e.Row.Cells(6).Text = e.Row.Cells(6).Text.Substring(0, 19) + "..."

                End If

                If CurType = 6 Then            '客戶回傳
                    Dim quotatedate As DateTime = CDate(e.Row.Cells(5).Text)
                    Dim daylast As Integer = DateDiff(DateInterval.Day, quotatedate, DateTime.Now)
                    If daylast > 10 Then
                        e.Row.BackColor = System.Drawing.Color.Red
                    End If
                End If
            End If
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim mpkid As Integer = Convert.ToInt32(Me.GridView1.DataKeys(e.RowIndex).Value)
        QuotationDAL.Delete(mpkid)
        BindGrid(SearchCondition)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim NewSearchCondition As String = InitSearch
        If Me.TxtSearchCondition.Text <> String.Empty Then
            NewSearchCondition += String.Format(" and (CustomerName like '%{0}%' or QuotationNO like '%{0}%')", Me.TxtSearchCondition.Text.Trim.ToString)
        End If
        ViewState("SearchCondition") = NewSearchCondition
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageChanged
        BindGrid(SearchCondition)
    End Sub

    Private Sub PagerControl1_PageSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PagerControl1.PageSizeChanged
        BindGrid(SearchCondition)
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

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExcel.Click
        If GridView1.Rows.Count > 0 Then
            Dim data As String
            data = ExportCSVData.ExportCSV(Me.GridView1, Nothing)
            If data = String.Empty Then
            Else
                Dim temp As String = String.Format("attachment;filename={0}", "EquipUseRecord.csv")
                Response.ClearHeaders()
                Response.ContentEncoding = System.Text.Encoding.Default '取得系統目前 ANSI 字碼頁的編碼方式。
                Response.Charset = "UTF-8"
                Response.ContentType = "application/csv"
                Response.AppendHeader("Content-disposition", temp)
                Response.Write(data)
                Response.End()
            End If
        End If
    End Sub
End Class