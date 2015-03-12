Imports Platform.eHR.Core
Imports Platform.eAuthorize
Imports System.Web.UI.DataVisualization.Charting

Partial Public Class Statistics
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
                Dim SearchCondition As String = " RecordDeleted=0 and IsFinished=1"
                If Me.DPLQuoter.SelectedItem.Text = "ALL" Then
                Else
                    SearchCondition += String.Format(" and QuotaerName =N'{0}'", StrConv(Me.DPLQuoter.SelectedItem.Text, VbStrConv.SimplifiedChinese, 2052))
                End If
                If Me.TxtStartDate.Text <> String.Empty Then
                    SearchCondition += " and QuoteDate>='" + CDate(Me.TxtStartDate.Text) + "'"
                End If
                If Me.TxtEndDate.Text <> String.Empty Then
                    SearchCondition += " and QuoteDate<='" + CDate(Me.TxtEndDate.Text) + "'"
                End If
                'If UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then

                'ElseIf UserInfo.IsInRoles("EXTERNALWORKER") Then
                '    SearchCondition += " and Extend03='" + UserInfo.CurrentUserID + "'"
                'Else
                '    SearchCondition = "1>2"
                'End If
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
            If UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
            ElseIf UserInfo.IsInRoles("EXTERNALWORKER") Then
                Me.GridView1.Columns(8).Visible = False
                Me.GridView1.Columns(9).Visible = False
            Else
                Me.GridView1.Columns(6).Visible = False
                Me.GridView1.Columns(7).Visible = False
                Me.GridView1.Columns(8).Visible = False
                Me.GridView1.Columns(9).Visible = False
            End If
            Me.TxtStartDate.Attributes.Add("readonly", True)
            Me.TxtStartDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")

            Me.TxtEndDate.Attributes.Add("readonly", True)
            Me.TxtEndDate.Attributes.Add("onclick", "javascript:WdatePicker({startDate:'%y-%M-01',dateFmt:'yyyy-MM-dd'});")
            Me.TxtStartDate.Text = DateTime.Now.Year.ToString + "-" + DateTime.Now.Month.ToString + "-" + "1"
            Me.TxtEndDate.Text = DateTime.Now.ToShortDateString
            BindDPL()
            BindGrid(InitSearch)
        End If
        BindChart2(SearchCondition)
        BindChart3(SearchCondition)
        BindChart4(SearchCondition)
        BindChart1(SearchCondition)
    End Sub
    Private Sub BindDPL()
        Dim exworker As List(Of AccountInfo) = RoleManage.LoadAccountCollection("EXTERNALWORKER")
        Me.DPLQuoter.DataSource = exworker
        Me.DPLQuoter.DataTextField = "UserName"
        Me.DPLQuoter.DataValueField = "UserSID"
        Me.DPLQuoter.DataBind()
        Me.DPLQuoter.Items.Insert(0, New ListItem("ALL", "0"))

       
        If UserInfo.IsInRoles("EXTERNALWORKER") Then
            Me.DPLQuoter.Enabled = False
            Me.DPLQuoter.SelectedIndex = Me.DPLQuoter.Items.IndexOf(Me.DPLQuoter.Items.FindByText(UserInfo.CurrentUserCHName))
        ElseIf UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("TEDINGSHENHE") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
        Else
            Me.DPLQuoter.Enabled = False
            Me.BtnSearch.Visible = False
        End If
    End Sub
    Private Sub BindGrid(ByVal Searchcondition As String)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GetInfoBySearchCondition", Searchcondition)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.emptyinfo.Visible = False
            Me.GridView1.DataSource = ds
            Me.GridView1.DataKeyNames = New String() {"PKID"}
            Me.GridView1.DataBind()
        Else
            Me.emptyinfo.Visible = True
            Me.GridView1.DataSource = Nothing
            Me.GridView1.DataBind()
        End If
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearch.Click
        Dim Searchcondition As String = InitSearch
        If Me.TxtStartDate.Text <> String.Empty Then
            Searchcondition += " and QuoteDate >'" + Me.TxtStartDate.Text + "'"
        End If
        If Me.TxtEndDate.Text <> String.Empty Then
            Searchcondition += " and QuoteDate<'" + Me.TxtEndDate.Text + "'"
        End If
        If Me.TxtCustomers.Text <> String.Empty Then
            Searchcondition += String.Format(" and CustomerName like '%{0}%' ", Me.TxtCustomers.Text)
        End If
        ViewState("Searchcondition") = Searchcondition
        BindGrid(Searchcondition)
        BindChart2(Searchcondition)
        BindChart3(Searchcondition)
        BindChart4(Searchcondition)
        BindChart1(Searchcondition)
    End Sub
    Dim zongjia As Integer = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim mPKID As Integer = CInt(GridView1.DataKeys(e.Row.RowIndex).Value)
            Dim HLDetail As HyperLink = CType(e.Row.FindControl("HLDetail"), HyperLink)
            Dim DocUniqueID As String = CType(e.Row.FindControl("lblDocUniqueID"), Label).Text
            Dim ReturnURL As String = "../Quotation/QuotationDetail.aspx?" & Global_asax.QUERY_APPLICANTIDX & "=" + mPKID.ToString
            If (DocUniqueID <> String.Empty AndAlso DocUniqueID <> Guid.Empty.ToString) Then
                ReturnURL = ReturnURL + "&" + Global_asax.QUERY_DOCUNIQUEID + "=" + DocUniqueID
            End If
            HLDetail.NavigateUrl = ReturnURL

            'Dim Paijia As Integer = CInt(e.Row.Cells(6).Text)
            'Dim baojia As Integer = CInt(e.Row.Cells(5).Text)
            'Dim LbYouhui As Label = CType(e.Row.FindControl("LbYouhui"), Label)
            'LbYouhui.Text = (baojia / Paijia * 100).ToString("0.00") + "%"
            'If UserInfo.IsInRoles("CRM經管") OrElse UserInfo.IsInRoles("SYS_ADMINISTRATOR ") OrElse UserInfo.IsInRoles("ZHONGXINZHUGUAN") OrElse UserInfo.IsInRoles("XINGZHENGZHUGUAN") OrElse UserInfo.IsInRoles("Yewuzhuguan") Then
            '    Dim chengben As Integer = CInt(e.Row.Cells(8).Text)
            '    Dim LbProfit As Label = CType(e.Row.FindControl("LbProfit"), Label)
            '    LbProfit.Text = ((baojia - chengben) / chengben * 100).ToString("0.00") + "%"
            'End If
            zongjia += CInt(e.Row.Cells(5).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(5).ForeColor = System.Drawing.Color.Red
            e.Row.Cells(5).Text = "合計:" + zongjia.ToString
        End If
    End Sub
#Region "BindChart"
    Protected Sub BindChart2(ByVal SearchCondition As String)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByCustomerName", SearchCondition)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            Dim yValues As Double() = New Double(dt.Rows.Count - 1) {}
            Dim xValues As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                xValues(i) = dr.Item("CustomerName").ToString
                yValues(i) = CDbl(dr.Item("TotalMoney"))
            Next

            Dim series1 As Series = Me.Chart2.Series(0)

            series1.ToolTip = "#LEGENDTEXT: #VALY ￥"
            series1.LegendToolTip = "#PERCENT"
            series1.PostBackValue = "#INDEX"
            series1.LegendPostBackValue = "#INDEX"
            series1.ShadowOffset = 2


            series1.Points.DataBindY(yValues)
            For i As Integer = 0 To series1.Points.Count - 1
                series1.Points(i).LegendText = xValues(i)
            Next
            If Not Page.IsPostBack Then
                series1.Points(0).CustomProperties += "Exploded=true"
            End If
        Else
            Me.Chart2.Visible = False
        End If
    End Sub

    Private Sub Chart2_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart2.Click
        Dim pointIndex As Int32 = Int32.Parse(e.PostBackValue)
        Dim series1 As Series = Chart2.Series(0)
        If (pointIndex >= 0 AndAlso pointIndex < series1.Points.Count) Then
            series1.Points(pointIndex).CustomProperties += "Exploded=true"
        End If
    End Sub
    Protected Sub BindChart3(ByVal Searchcondition As String)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByTesItemName", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            Dim yValues As Double() = New Double(dt.Rows.Count - 1) {}
            Dim xValues As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                xValues(i) = dr.Item("TestItemName").ToString
                yValues(i) = CDbl(dr.Item("TotalMoney"))
            Next

            Dim series1 As Series = Me.Chart3.Series(0)

            series1.ToolTip = "#LEGENDTEXT: #VALY ￥"
            series1.LegendToolTip = "#PERCENT"
            series1.PostBackValue = "#INDEX"
            series1.LegendPostBackValue = "#INDEX"
            series1.ShadowOffset = 2


            series1.Points.DataBindY(yValues)
            For i As Integer = 0 To series1.Points.Count - 1
                series1.Points(i).LegendText = xValues(i)
            Next
            If Not Page.IsPostBack Then
                series1.Points(0).CustomProperties += "Exploded=true"
            End If
        Else
            Me.Chart3.Visible = False
        End If
    End Sub

    Private Sub Chart3_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart3.Click
        Dim pointIndex As Int32 = Int32.Parse(e.PostBackValue)
        Dim series1 As Series = Chart3.Series(0)
        If (pointIndex >= 0 AndAlso pointIndex < series1.Points.Count) Then
            series1.Points(pointIndex).CustomProperties += "Exploded=true"
        End If
    End Sub
    Protected Sub BindChart4(ByVal Searchcondition As String)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByQuoterName", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
            Dim yValues As Double() = New Double(dt.Rows.Count - 1) {}
            Dim xValues As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                xValues(i) = dr.Item("QuotaerName").ToString
                yValues(i) = CDbl(dr.Item("TotalMoney"))
            Next

            Dim series1 As Series = Me.Chart4.Series(0)

            series1.ToolTip = "#LEGENDTEXT: #VALY ￥"
            series1.LegendToolTip = "#PERCENT"
            series1.PostBackValue = "#INDEX"
            series1.LegendPostBackValue = "#INDEX"
            series1.ShadowOffset = 2


            series1.Points.DataBindY(yValues)
            For i As Integer = 0 To series1.Points.Count - 1
                series1.Points(i).LegendText = xValues(i)
            Next
            If Not Page.IsPostBack Then
                series1.Points(0).CustomProperties += "Exploded=true"
            End If
        Else
            Me.Chart4.Visible = False
        End If
    End Sub
    Private Sub Chart4_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ImageMapEventArgs) Handles Chart4.Click
        Dim pointIndex As Int32 = Int32.Parse(e.PostBackValue)
        Dim series1 As Series = Chart4.Series(0)
        If (pointIndex >= 0 AndAlso pointIndex < series1.Points.Count) Then
            series1.Points(pointIndex).CustomProperties += "Exploded=true"
        End If
    End Sub
    Protected Sub BindChart1(ByVal Searchcondition As String)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByMonth", Searchcondition)
        Chart1.DataSource = ds
        If ds.Tables(0).Rows.Count > 0 Then
            Chart1.Series("Series 1").XValueMember = "tunit"
            Chart1.Series("Series 1").YValueMembers = "TotalMoney"
            Chart1.DataBind()
            Chart1.Series("Series 1").ToolTip = _
       "月份：#VALX" + ControlChars.Lf + _
       "報價金額：#VALY ￥"
        Else
            Me.Chart1.Visible = False
        End If
    End Sub
#End Region
    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExcel.Click
        If GridView1.Rows.Count > 0 Then
            Dim filename As String = CDate(Me.TxtStartDate.Text).ToString("yyMMdd") + "To" + CDate(Me.TxtEndDate.Text).ToString("yyMMdd") + "報價信息"
            Dim dg As GridViewRow
            For Each dg In Me.GridView1.Rows

                dg.Cells(5).Attributes.Add("style", "vnd.ms-excel.numberformat: @;")
                dg.Cells(6).Attributes.Add("style", "vnd.ms-excel.numberformat: @;")
                dg.Cells(8).Attributes.Add("style", "vnd.ms-excel.numberformat: @;")
            Next

            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) + ".xls")
            Response.ContentEncoding = System.Text.Encoding.UTF7
            Response.ContentType = "applicationshlnd.xls"
            Dim oStringWriter As System.IO.StringWriter = New System.IO.StringWriter()
            Dim oHtmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(oStringWriter)
            Me.Panel1.RenderControl(oHtmlTextWriter)
            Response.Write(oStringWriter.ToString())
            Response.Flush()
            Response.End()
        End If
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

End Class