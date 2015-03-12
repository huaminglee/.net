Imports System.Web.UI.DataVisualization.Charting
Imports Platform.eAuthorize

Partial Public Class LeaderReport
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
                Dim SearchCondition As String = String.Format(" QuoteDate<='{0}' and QuoteDate>='{1}' ", Me.TxtEndDate.Text, Me.TxtStartDate.Text)
               
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
            'BindChart1andchart2(InitSearch)
            'BindGrid(InitSearch)
        End If
    End Sub
    Protected Sub BindChart1andchart2(ByVal Searchcondition As String)
        Dim ds As DataSet = New DataSet()
        Select Case Me.RadioButtonList1.SelectedItem.Text
            Case "年"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByyear", Searchcondition)
                Chart1.ChartAreas(0).AxisX.Title = "統計單位：年"
                Chart2.ChartAreas(0).AxisX.Title = "統計單位：年"
            Case "季"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByji", Searchcondition)
                Chart1.ChartAreas(0).AxisX.Title = "統計單位：季"
                Chart2.ChartAreas(0).AxisX.Title = "統計單位：季"
            Case "月"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByMonth", Searchcondition)
                Chart1.ChartAreas(0).AxisX.Title = "統計單位：月"
                Chart2.ChartAreas(0).AxisX.Title = "統計單位：月"
            Case "周"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByweek", Searchcondition)
                Chart1.ChartAreas(0).AxisX.Title = "統計單位：周"
                Chart2.ChartAreas(0).AxisX.Title = "統計單位：周"
            Case "日"
                ds = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_QuotationAndReport_GroupByday", Searchcondition)
                Chart1.ChartAreas(0).AxisX.Title = "統計單位：日"
                Chart2.ChartAreas(0).AxisX.Title = "統計單位：日"
        End Select
        If Not ds Is Nothing AndAlso ds.Tables(0).Rows.Count > 0 Then
            Me.Chart1.Visible = True
            Me.Chart2.Visible = True
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim yValues As Double() = New Double(dt.Rows.Count - 1) {}
            Dim y2Value As Double() = New Double(dt.Rows.Count - 1) {}
            Dim xValues As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                xValues(i) = dr.Item("tunit").ToString
                yValues(i) = CDbl(dr.Item("TotalMoney"))
                y2Value(i) = CDbl(dr.Item("nums"))
            Next

            Dim series1 As Series = Me.Chart1.Series(0)
            Dim series2 As Series = Me.Chart2.Series(0)


            series1.ToolTip = "#LEGENDTEXT: #VALY ￥"
            series1.LegendToolTip = "#PERCENT"
            'series1.PostBackValue = "#INDEX"
            'series1.LegendPostBackValue = "#INDEX"
            series1.ShadowOffset = 2

            series2.ToolTip = "#LEGENDTEXT: #VALY 件"
            series2.LegendToolTip = "#PERCENT"
            'series2.PostBackValue = "#INDEX"
            'series2.LegendPostBackValue = "#INDEX"
            series2.ShadowOffset = 2

            series1.Points.DataBindXY(xValues, yValues)
            series2.Points.DataBindXY(xValues, y2Value)

            For i As Integer = 0 To series1.Points.Count - 1
                series1.Points(i).LegendText = xValues(i)
                series2.Points(i).LegendText = xValues(i)
            Next
        Else
            Me.Chart2.DataSource = Nothing
            Me.Chart1.DataSource = Nothing
            Me.Chart1.DataBind()
            Me.Chart2.DataBind()
            Me.Chart1.Visible = False
            Me.Chart2.Visible = False
        End If
    End Sub
    Private Sub BindGrid(ByVal Searchcondition As String)
        zongjia = 0
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
    
    Dim zongjia As Integer = 0
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            zongjia += CInt(e.Row.Cells(5).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(5).ForeColor = System.Drawing.Color.Red
            e.Row.Cells(5).Text = "合計:" + zongjia.ToString
        End If
    End Sub
    Protected Sub BtnGet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGet.Click
        BindChart1andchart2(InitSearch)
        BindGrid(InitSearch)
    End Sub

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