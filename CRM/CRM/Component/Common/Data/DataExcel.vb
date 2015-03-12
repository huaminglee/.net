Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Drawing
Imports System.IO
Imports System.Reflection
''' <summary>
''' Excel匯出
''' </summary>
''' <remarks></remarks>
Public Class DataExcel

    Private _sheetname As String
    ''' <summary>
    ''' 表單名稱
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SheetName() As String
        Get
            If _sheetname = Nothing Or _sheetname = "" Then
                _sheetname = "sheet"
            End If
            Return _sheetname
        End Get
        Set(ByVal value As String)
            _sheetname = value
        End Set
    End Property
    ''' <summary>
    ''' <para>匯出帶有圖表的Excel</para>
    ''' <para>dt圖表數據源（一行多列）</para>
    ''' <para>Title圖表名稱</para>
    ''' <para>XTitle圖表X軸名稱</para>
    ''' <para>YTitle圖表Y軸名稱</para>
    ''' <para>Color不同含義圖表不同邊框顏色</para>
    ''' </summary>
    ''' <remarks></remarks>
    Structure ChartSource
        Dim dt As Data.DataTable
        Dim Title As String
        Dim XTitle As String
        Dim YTitle As String
        Dim Color As Integer
    End Structure
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 匯出Excel
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="saveFileName"></param>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Sub ToExcel(ByVal dt As Data.DataTable, ByVal saveFileName As String)
        Dim sheet As Worksheet
        Dim Wbooks As Workbooks
        Dim Wbook As Workbook
        Dim range As Excel.Range
        Dim total As Integer
        Dim fileSaved As Boolean = False
        'Dim rowread As Long
        '  Dim percent As Single
        Dim app As Excel.Application = New Excel.Application
        Dim saveFile As String = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\Reports\" + saveFileName
        Dim obj(,) As Object = New Object(dt.Rows.Count, dt.Columns.Count) {}
        If app Is Nothing Then
            '    Request.Write("<script>alert('無法創建Excel對象，可能您的機器未安裝Excel！')</script>")
            Exit Sub
        End If
        Wbooks = app.Workbooks
        Wbook = Wbooks.Open(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\Reports\Report1.xls") ' Wbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet) 

        sheet = CType(Wbook.Worksheets(1), Excel.Worksheet)


        total = dt.Rows.Count

        For r As Integer = 0 To dt.Rows.Count - 1
            For c As Integer = 0 To dt.Columns.Count - 1
                Dim CellText As String = dt.Rows(r).Item(c).ToString()
                obj(r, c) = CellText
            Next
        Next
        range = sheet.Range(sheet.Cells(3, 1), sheet.Cells(dt.Rows.Count + 2, dt.Columns.Count))
        range.Value2 = obj



        If saveFileName <> "" Then
            Try
                Wbook.Saved = True
                Wbook.SaveCopyAs(saveFile)

                fileSaved = True
            Catch ex As Exception
                fileSaved = False

            Finally
                Wbook.Close(Nothing, Nothing, Nothing)
                app.Quit()
                If Not range Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(range)
                    range = Nothing
                End If
                If Not sheet Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet)
                    sheet = Nothing
                End If
                If Not Wbook Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Wbook)
                    Wbook = Nothing
                End If
                If Not Wbooks Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Wbooks)
                    Wbooks = Nothing
                End If
                If Not app Is Nothing Then
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
                    app = Nothing
                End If
                GC.Collect()

            End Try
        Else
            fileSaved = False
        End If

        If fileSaved And File.Exists(saveFile) Then
            HttpContext.Current.Response.Redirect("Reports/" + saveFileName)
        End If
    End Sub
    ''' <summary>
    ''' 匯出帶有圖表的Excel
    ''' </summary>
    ''' <param name="ChartSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DataExcelReport(ByVal ChartSource() As ChartSource) As Boolean


        'Dim dt() As Data.DataTable = New Data.DataTable(ChartSource.Length-1) {}
        'For i As Integer = 0 To ds.Tables.Count - 1
        '    dt(i) = ds.Tables(i)
        'Next
        Dim saveFileName As String = "Report.xls"
        Dim saveFile As String = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) & "\Reports\" + saveFileName

        Dim charts As ChartObjects
        Dim app As Excel.Application = New Excel.Application
        Dim Wbooks As Workbooks = app.Workbooks
        Dim Wbook As Workbook = Wbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet)

        Dim sheet As Worksheet = CType(Wbook.Worksheets(1), Excel.Worksheet)

        Dim ActiveChart As Chart
        Dim Ochart As ChartObject
        Dim range As Excel.Range
        Try
            For i As Integer = 0 To ChartSource.Length - 1
                If ChartSource(i).dt.Rows.Count > 0 Then
                    Dim dt As Data.DataTable = ChartSource(i).dt
                    Dim Title As String = ChartSource(i).Title

                    range = sheet.Range(sheet.Cells((i * 22) + 1, 1), sheet.Cells(i * 22 + 2, dt.Rows.Count))
                    Dim rang As Excel.Range = sheet.Range(sheet.Cells((i * 22) + 3, 2), sheet.Cells((i * 22) + 4, 3))
                    Dim obj(,) As Object = New Object(2, dt.Rows.Count) {}

                    For r As Integer = 0 To dt.Rows.Count - 1
                        obj(0, r) = dt.Rows(r).Item(0).ToString
                    Next
                    For r As Integer = 0 To dt.Rows.Count - 1
                        obj(1, r) = dt.Rows(r).Item(1).ToString
                    Next
                    range.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Nothing)
                    range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                    range.Borders(Excel.XlBordersIndex.xlInsideHorizontal).Weight = Excel.XlBorderWeight.xlThin
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    range.Value2 = obj
                    sheet.Name = SheetName
                    charts = sheet.ChartObjects
                    Dim width As Integer = IIf(dt.Rows.Count * 50 < 400, 400, dt.Rows.Count * 50)
                    Ochart = charts.Add(rang.Left, rang.Top, width, 300)
                    ActiveChart = Ochart.Chart

                    ActiveChart.SetSourceData(range, Excel.XlRowCol.xlRows)
                    '  Dim ob As ChartObjects        
                    ActiveChart.ChartType = XlChartType.xlColumnClustered 'xlColumnClustered

                    With ActiveChart
                        .HasTitle = True
                        .ChartTitle.Characters.Text = Title
                        .Axes(Excel.XlAxisType.xlCategory, XlAxisGroup.xlPrimary).HasTitle = True
                        .Axes(Excel.XlAxisType.xlCategory, XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = ChartSource(i).XTitle
                        .Axes(Excel.XlAxisType.xlValue, XlAxisGroup.xlPrimary).HasTitle = True
                        .Axes(Excel.XlAxisType.xlValue, XlAxisGroup.xlPrimary).AxisTitle.Characters.Text = ChartSource(i).YTitle
                    End With
                    ActiveChart.HasDataTable = False
                    If ChartSource(i).Color = 1 Then
                        ActiveChart.ChartArea.Border.Weight = 2
                        ActiveChart.ChartArea.Border.LineStyle = 1
                        ActiveChart.ChartArea.Border.ColorIndex = 3
                    ElseIf ChartSource(i).Color = 2 Then
                        ActiveChart.ChartArea.Border.Weight = 2
                        ActiveChart.ChartArea.Border.LineStyle = 1
                        ActiveChart.ChartArea.Border.ColorIndex = 6
                    ElseIf ChartSource(i).Color = 3 Then
                        ActiveChart.ChartArea.Border.Weight = 2
                        ActiveChart.ChartArea.Border.LineStyle = 1
                        ActiveChart.ChartArea.Border.ColorIndex = 5
                    End If



                    Dim Selection As Object = ActiveChart.SeriesCollection(1)

                    With Selection.Border
                        .Weight = XlBorderWeight.xlThin
                        .LineStyle = Excel.Constants.xlAutomatic
                    End With
                    Selection.Shadow = False
                    Selection.InvertIfNegative = False
                    ActiveChart.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowValue)

                    Selection.Fill.OneColorGradient(Style:=Microsoft.Office.Core.MsoGradientStyle.msoGradientVertical, Variant:=4, _
                        Degree:=0.231372549019608)
                    With Selection
                        .Fill.Visible = True
                        .Fill.ForeColor.SchemeColor = 17
                    End With
                    Dim SelectionP As Object = ActiveChart.PlotArea
                    With SelectionP.Border
                        .ColorIndex = 16
                        .Weight = XlBorderWeight.xlThin
                        .LineStyle = XlLineStyle.xlContinuous
                    End With
                    SelectionP.Fill.OneColorGradient(Style:=Microsoft.Office.Core.MsoGradientStyle.msoGradientHorizontal, Variant:=2, _
                        Degree:=0.231372549019608)
                    With SelectionP
                        .Fill.Visible = True
                        .Fill.ForeColor.SchemeColor = 15
                    End With
                    ActiveChart.Axes(Excel.XlAxisType.xlValue).TickLabels.AutoScaleFont = True
                    With ActiveChart.Axes(Excel.XlAxisType.xlCategory).TickLabels.Font
                        .Name = "新細明體"
                        .FontStyle = "標準"
                        .Size = 10
                        .Strikethrough = False
                        .Superscript = False
                        .Subscript = False
                        .OutlineFont = False
                        .Shadow = False
                        .Underline = Excel.XlUnderlineStyle.xlUnderlineStyleNone
                        .ColorIndex = Excel.Constants.xlAutomatic
                        .Background = Excel.Constants.xlAutomatic
                    End With
                    ActiveChart.HasLegend = False
                End If
            Next

            Wbook.Saved = True
            Wbook.SaveCopyAs(saveFile)
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            ''''''''''殺死進程，只保留一個EXCEL進程''''''''''''''''''''''''''''''''''''''''''''''''
            Wbook.Close(Nothing, Nothing, Nothing)
            app.Quit()
            If Not range Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range)
                range = Nothing
            End If
            If Not sheet Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet)
                sheet = Nothing
            End If
            If Not Wbook Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Wbook)
                Wbook = Nothing
            End If
            If Not Wbooks Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Wbooks)
                Wbooks = Nothing
            End If
            If Not app Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
                app = Nothing
            End If
            GC.Collect()
        End Try




    End Function


End Class
