Imports Platform.eAuthorize

Partial Public Class jinguantongji
    Inherits System.Web.UI.Page
#Region "Const"
    Private Const _SearchConditon As String = "ViewState:SearchConditon"
#End Region
#Region "屬性"
    Private ReadOnly Property InitSearch() As String
        Get
            If ViewState("InitSearch") IsNot Nothing Then
                Return CStr(ViewState("InitSearch"))
            Else
                Dim SearchCondition As String = String.Format(" CONVERT(datetime, TongjiTime)<='{0}' and CONVERT(datetime, TongjiTime)>='{1}' ", Me.TxtEndDate.Text, Me.TxtStartDate.Text)
                If Me.DPLServiceType.SelectedItem.Text = "ALL" Then
                Else
                    SearchCondition += "  and ServiceType ='" + Me.DPLServiceType.SelectedItem.Text + "'"
                End If
                If UserInfo.IsInRoles("EXTERNALWORKER") Then
                    SearchCondition += " and QuoterID ='" + UserInfo.CurrentUserID + "'"
                Else

                End If
                If Not Me.TxtSearch.Text.Trim = String.Empty AndAlso Me.TxtStartDate.Text <> String.Empty Then
                    SearchCondition += String.Format(" and ( QuotationNO like N'%{0}%' or CustomerName like N'%{0}%' or SampleName like N'%{0}%' or TestNO like N'%{0}%' )", Me.TxtSearch.Text.Trim)
                ElseIf Me.TxtStartDate.Text = String.Empty AndAlso Me.TxtEndDate.Text = String.Empty AndAlso Me.TxtSearch.Text <> String.Empty Then
                    SearchCondition = String.Format("  ( QuotationNO like N'%{0}%' or CustomerName like N'%{0}%' or SampleName like N'%{0}%' or TestNO like N'%{0}%' )", Me.TxtSearch.Text.Trim)
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
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.TxtEndDate.Attributes.Add("readonly", True)
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")

            Me.TxtStartDate.Attributes.Add("readonly", True)
            Me.TxtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtStartDate.Text = DateTime.Now.Year.ToString + "-" + DateTime.Now.Month.ToString + "-" + "1"
            Me.TxtEndDate.Text = DateTime.Now.ToShortDateString
            If UserInfo.CurrentUserID = "F2163735" OrElse UserInfo.CurrentUserID = "F2141961" Then
                Me.DPLchangqu.SelectedIndex = Me.DPLchangqu.Items.IndexOf(Me.DPLchangqu.Items.FindByValue("GL"))
            Else
                Me.DPLchangqu.SelectedIndex = Me.DPLchangqu.Items.IndexOf(Me.DPLchangqu.Items.FindByValue(ConfigurationManager.AppSettings("CQ")))
            End If
            If UserInfo.IsInRoles("LHCENTEREM") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR") Then
                Me.DPLchangqu.Enabled = True
            Else
                Me.DPLchangqu.Enabled = False
            End If
            BindDPL()
        End If
    End Sub
    Private Sub BindDPL()
        Dim ds2 As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllServiceType")
        If ds2.Tables(0).Rows.Count > 0 Then

            Me.DPLServiceType.DataSource = ds2
            Me.DPLServiceType.DataTextField = "LbServiceName"
            Me.DPLServiceType.DataValueField = "LbServiceName"
            Me.DPLServiceType.DataBind()
        Else
            Me.DPLServiceType.DataSource = Nothing
            Me.DPLServiceType.DataBind()
        End If
        Me.DPLServiceType.Items.Insert(0, New ListItem("ALL", "0"))

    End Sub
    Private Sub BindGrid(ByVal Searchcondition As String)
        count = 0
        count2 = 0
        Dim ds As DataSet = New DataSet()
        Select Case Me.DPLchangqu.SelectedValue
            Case "GL"
                Searchcondition += " and quotaername in(N'童剛') "
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "LH"
                Searchcondition += " and quotaername not in(N'童剛') "
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "WH"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringWH, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "CD"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringCD, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "CQ"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringCQ, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "YT"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringYT, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "KS"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringWSJ, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "ZZ"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringZZ, "View_TestHistory_jingguantongjiByCondition", Searchcondition)
            Case "NN"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringNN, "View_TestHistory_jingguantongjiByCondition", Searchcondition)

        End Select

        If ds.Tables(0).Rows.Count > 0 Then
            Me.emptyinfo.Visible = False
            Me.GridView1.DataSource = ds
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub
    Dim count As Double = 0
    Dim count2 As Double = 0
    Dim count3 As Double = 0
    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        BindGrid(SearchCondition)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim LbReportPKID As Label = CType(e.Row.FindControl("LbReportPKID"), Label)
            Dim LbEflowdocid As Label = CType(e.Row.FindControl("LbEflowdocid"), Label)
            Dim LbHanshui As Label = CType(e.Row.FindControl("LbHanshui"), Label)
            Dim LbIsneedfapiao As Label = CType(e.Row.FindControl("LbIsneedfapiao"), Label)
            Dim LbIsneedfapiaoshow As Label = CType(e.Row.FindControl("LbIsneedfapiaoshow"), Label)
            Dim LbFinal As Label = CType(e.Row.FindControl("LbFinal"), Label)
            If LbIsneedfapiao.Text = "1" Then
                LbIsneedfapiaoshow.Text = "是"
                LbHanshui.Text = (CDbl(e.Row.Cells(9).Text) * 1.06).ToString("0.00")
                LbFinal.Text = e.Row.Cells(9).Text
            ElseIf LbIsneedfapiao.Text = "2" Then
                LbIsneedfapiaoshow.Text = "否"
                LbHanshui.Text = CDbl(e.Row.Cells(9).Text).ToString
                LbFinal.Text = (CDbl(LbHanshui.Text) / 1.06).ToString("0.00")
            End If
            count3 += CDbl(LbFinal.Text)
            count2 += CDbl(LbHanshui.Text)
            Dim curmoney As Double = CDbl(e.Row.Cells(9).Text)
            count += curmoney
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';")
            Dim returnurl As String = "ReportDetailDetail.aspx?pkid=" + LbReportPKID.Text
            If (LbEflowdocid.Text <> String.Empty AndAlso LbEflowdocid.Text <> Guid.Empty.ToString) Then
                returnurl = returnurl + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + LbEflowdocid.Text
            End If

            e.Row.Attributes.Add("onclick", "window.location.href='" + returnurl + "';")

            Dim LbCurState As Label = CType(e.Row.FindControl("LbCurState"), Label)
            Dim LbStateName As Label = CType(e.Row.FindControl("LbStateName"), Label)

            If e.Row.Cells(3).Text.Length > 10 Then
                e.Row.Cells(3).ToolTip = e.Row.Cells(3).Text
                e.Row.Cells(3).Text = e.Row.Cells(3).Text.Substring(0, 9) + "..."
            End If
            If e.Row.Cells(5).Text.Length > 10 Then
                e.Row.Cells(5).ToolTip = e.Row.Cells(5).Text
                e.Row.Cells(5).Text = e.Row.Cells(5).Text.Substring(0, 9) + "..."
            End If
            If e.Row.Cells(6).Text.Length > 10 Then
                e.Row.Cells(6).ToolTip = e.Row.Cells(6).Text
                e.Row.Cells(6).Text = e.Row.Cells(6).Text.Substring(0, 9) + "..."
            End If

            Dim LbDuizhang As Label = CType(e.Row.FindControl("LbDuizhang"), Label)
            Dim LbInvoiceDotime As Label = CType(e.Row.FindControl("LbInvoiceDotime"), Label)
            If LbStateName.Text = "完成狀態" Then
                If LbDuizhang.Text = "9999-12-31 23:59:59.997" Then
                    LbCurState.Text = "待對賬"
                ElseIf LbInvoiceDotime.Text = "9999-12-31 23:59:59.997" Then
                    LbCurState.Text = "待開發票"
                Else
                    LbCurState.Text = "已結案"
                End If
            Else
                LbCurState.Text = LbStateName.Text
            End If




        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Text = "合計：" + count.ToString
            e.Row.Cells(11).Text = "合計：" + count2.ToString
            e.Row.Cells(12).Text = "合計：" + count3.ToString
        End If
    End Sub

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExcel.Click

        Dim newSearchcondition As String = SearchCondition
        Dim excelds As DataSet = New DataSet()
        Select Case Me.DPLchangqu.SelectedValue
            Case "GL"
                newSearchcondition += " and quotaername in(N'童剛') "
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "LH"
                newSearchcondition += " and quotaername not in(N'童剛') "
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "WH"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringWH, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "CD"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringCD, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "CQ"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringCQ, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "YT"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringYT, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "KS"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringWSJ, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "ZZ"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringZZ, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)
            Case "NN"
                excelds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringNN, "View_TestHistory_jingguantongjiByCondition", newSearchcondition)

        End Select
        If excelds IsNot Nothing Then
            If excelds.Tables(0).Rows.Count > 0 Then
                Const StartRow As Integer = 2
                Dim oBook As New C1.C1Excel.C1XLBook
                Dim oSheet As C1.C1Excel.XLSheet
                Dim oStyle As New C1.C1Excel.XLStyle(oBook)
                Dim oStyledel As New C1.C1Excel.XLStyle(oBook)
                Dim sTemplate As String
                Dim summoney2 As Double = 0
                Dim summoney3 As Double = 0
                sTemplate = Server.MapPath(Request.ApplicationPath) & "\Reports\EquipmentInfoReport.xls"
                Try
                    oBook.Load(sTemplate)
                Catch ex As Exception

                    Exit Sub
                End Try

                Dim row As Integer = StartRow
                'Dim NO As Integer = 0

                oSheet = oBook.Sheets(0)
                Dim exceltitle As String = "報價信息"

                oSheet(0, 0).Value = exceltitle
                oSheet(0, 7).Value = "統計時間段:" + Me.TxtStartDate.Text.ToString + "到" + Me.TxtEndDate.Text.ToString
                oSheet(1, 0).Value = "序號"
                oSheet(1, 1).Value = "報價單號"
                oSheet(1, 2).Value = "測試編號"
                oSheet(1, 3).Value = "服務類別"
                oSheet(1, 4).Value = "測試項目"
                oSheet(1, 5).Value = "客戶名稱"
                oSheet(1, 6).Value = "報價人"
                oSheet(1, 7).Value = "測試完成日期"
                oSheet(1, 8).Value = "未含稅報價"
                oSheet(1, 9).Value = "发票"
                oSheet(1, 10).Value = "已含稅報價"
                oSheet(1, 11).Value = "經管統計"

                For j As Integer = 0 To excelds.Tables(0).Rows.Count - 1
                    Dim dr As DataRow = excelds.Tables(0).Rows(j)
                    oSheet(j + 2, 0).Value = dr.Item("XH")
                    oSheet(j + 2, 1).Value = dr.Item("QuotationNO")
                    oSheet(j + 2, 2).Value = dr.Item("TestNO")
                    oSheet(j + 2, 3).Value = dr.Item("ServiceType")
                    oSheet(j + 2, 4).Value = dr.Item("TestItemName")
                    oSheet(j + 2, 5).Value = dr.Item("CustomerName")
                    oSheet(j + 2, 6).Value = dr.Item("QuotaerName")
                    oSheet(j + 2, 7).Value = CDate(dr.Item("TongjiTime")).ToShortDateString
                    oSheet(j + 2, 8).Value = dr.Item("ItemShijizongjia")
                    If dr.Item("ISneedFapiao") = "2" Then
                        Dim curfinal As Double = CDbl(dr.Item("ItemShijizongjia")) / 1.06
                        oSheet(j + 2, 9).Value = "否"
                        oSheet(j + 2, 10).Value = CDbl(dr.Item("ItemShijizongjia")).ToString("0.00")
                        oSheet(j + 2, 11).Value = curfinal.ToString("0.00")
                        summoney2 += CDbl(dr.Item("ItemShijizongjia"))
                        summoney3 += CDbl(curfinal.ToString("0.00"))
                    ElseIf (dr.Item("ISneedFapiao") = "1") Then

                        oSheet(j + 2, 9).Value = "是"
                        oSheet(j + 2, 10).Value = (CDbl(dr.Item("ItemShijizongjia")) * 1.06).ToString("0.00")
                        oSheet(j + 2, 11).Value = CDbl(dr.Item("ItemShijizongjia")).ToString("0.00")
                        summoney2 += (CDbl(dr.Item("ItemShijizongjia")) * 1.06).ToString("0.00")
                        summoney3 += CDbl(dr.Item("ItemShijizongjia"))
                    End If
                    row += 1

                Next
                oSheet(excelds.Tables(0).Rows.Count + 2, 8).Value = "合計:" + excelds.Tables(1).Rows(0).Item("summoney").ToString
                oSheet(excelds.Tables(0).Rows.Count + 2, 10).Value = "合計:" + summoney2.ToString
                oSheet(excelds.Tables(0).Rows.Count + 2, 11).Value = "合計:" + summoney3.ToString
                oStyle.AlignHorz = C1.C1Excel.XLAlignHorzEnum.Center
                oStyle.SetBorderStyle(C1.C1Excel.XLLineStyleEnum.Thin)
                oStyledel.AlignHorz = C1.C1Excel.XLAlignHorzEnum.Center
                oStyledel.SetBorderStyle(C1.C1Excel.XLLineStyleEnum.Thin)
                oStyledel.BackColor = Drawing.Color.Red

                Try
                    Dim PS As New C1.C1Excel.XLPrintSettings
                    PS.AutoScale = True
                    PS.CenterHorizontal = True
                    PS.Landscape = True
                    PS.PaperKind = Drawing.Printing.PaperKind.A4 ' Printing.PaperKind.A4
                    oSheet.PrintSettings = PS
                    oBook.Save(Server.MapPath(Request.ApplicationPath) & "\Reports\QuotationStatistics.xls")
                    Response.Redirect("..\Reports\QuotationStatistics.xls")
                Catch ex As Exception
                    Response.Write(ex.ToString)
                End Try
            End If
        Else
            '沒有數據,無需導出
        End If
    End Sub
End Class