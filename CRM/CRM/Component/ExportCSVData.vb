Imports System.Text
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Reflection

        Public Class ExportCSVData

    Public Shared Function ExportCSV(ByVal grid As System.Web.UI.WebControls.GridView, ByVal notDisplayedCloumns As List(Of String)) As String

        Dim data As StringBuilder = New StringBuilder


        For i As Integer = 0 To grid.Columns.Count - 1

            If grid.Columns(i).Visible AndAlso grid.Columns(i).AccessibleHeaderText <> "No" Then
                data.Append(grid.Columns(i).HeaderText + ",")
            End If

        Next
        Dim CellInfo As String = String.Empty
        data.Append(vbCrLf)
        For i As Integer = 0 To grid.Rows.Count - 1
            For j As Integer = 0 To grid.Columns.Count - 1

                If grid.Columns(j).Visible AndAlso grid.Columns(j).AccessibleHeaderText <> "No" Then
                    If grid.Rows(i).Cells(j).ToolTip <> "" Then
                        CellInfo = grid.Rows(i).Cells(j).ToolTip
                    Else

                        CellInfo = grid.Rows(i).Cells(j).Text
                        '  Else '為序號
                        '  CellInfo = DirectCast(DirectCast(DirectCast(grid.Rows(i).Cells(j), System.Web.UI.WebControls.TableCell).Controls(1), System.Web.UI.Control), System.Web.UI.WebControls.Label).Text
                    End If
                    CellInfo = CellInfo.Replace("&nbsp;", "").Replace(",", ";")
                    data.Append(CellInfo + ",")
                End If
            Next
            data.Append(vbCrLf)
        Next



        If grid.ShowFooter Then
            For i As Integer = 0 To grid.Columns.Count - 1
                If grid.Columns(i).Visible AndAlso grid.Columns(i).AccessibleHeaderText <> "No" Then
                    CellInfo = grid.FooterRow.Cells(i).Text
                    CellInfo = CellInfo.Replace("&nbsp;", "")
                    data.Append(CellInfo + ",")
                End If
            Next

        End If
        data.Append(vbCrLf)


        Return data.ToString
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 将DataTable导出成CSV格式,根據Datagrid設定導出數據的Header
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ExportCSV(ByVal dt As DataTable, ByVal grid As System.Web.UI.WebControls.DataGrid) As String

        Dim data As StringBuilder = New StringBuilder

        Dim column As DataGridColumn
        For Each column In grid.Columns
            If column.GetType().Name = "TemplateColumn" Or column.GetType().Name = "HyperLinkColumn" Or column.GetType().Name = "BoundColumn" Then
                If column.FooterText <> "No" AndAlso column.Visible Then
                    data.Append(column.HeaderText + ",")
                End If
                'data += ControlChars.Tab
            End If
        Next

        data.Append(vbCrLf)
        '写出数据
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1 Step i + 1
            Dim k As Integer
            For k = 0 To grid.Columns.Count - 1 Step k + 1
                If grid.Columns(k).FooterText <> "No" AndAlso grid.Columns(k).Visible Then
                    data.Append(dt.Rows(i)(dt.Columns(k)).ToString() + ",")
                End If
            Next
            k = 0
            data.Append(vbCrLf)
        Next
        data.Append(vbCrLf)
        Return data.ToString
    End Function

    ''' <summary>
    ''' 将GridView导出成CSV格式
    ''' </summary>
    ''' <param name="HeaderList"></param>
    ''' <param name="dt"></param>
    ''' <param name="HeaderTextList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExportCSV(ByVal HeaderList As String(), ByVal dt As DataTable, ByVal HeaderTextList As String()) As String

        If HeaderList.Length <> HeaderTextList.Length Then
            Return String.Empty
        Else
            Dim strbData As StringBuilder = New StringBuilder
            Dim i As Integer
            '寫出表頭
            For i = 0 To HeaderTextList.Length - 1
                strbData.Append(HeaderTextList(i) + ",")
            Next
            strbData.Append(vbCrLf)
            '寫出數據
            Dim row As DataRow
            For Each row In dt.Rows
                Dim j As Integer
                For j = 0 To HeaderList.Length - 1
                    strbData.Append(row(HeaderList(j)).ToString() + ",")
                Next
                strbData.Append(vbCrLf)
            Next
            strbData.Append("以下空白" + DateTime.Now.ToString)
            strbData.Append(vbCrLf)
            Return strbData.ToString
        End If
    End Function


    ''' <summary>
    ''' 將DataSet數據導出為csv格式
    ''' </summary>
    ''' <param name="HeaderList"></param>
    ''' <param name="dt"></param>
    ''' <param name="HeaderTextList"></param>
    ''' <param name="TypeCell"></param>
    ''' <param name="TypeList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExportCSV(ByVal HeaderList As String(), ByVal dt As DataTable, ByVal HeaderTextList As String(), ByVal TypeCell As String, ByVal TypeList As ArrayList) As String

        If HeaderList.Length <> HeaderTextList.Length Then
            Return String.Empty
        Else
            Dim strbData As StringBuilder = New StringBuilder
            Dim i As Integer
            '寫出表頭
            For i = 0 To HeaderTextList.Length - 1
                strbData.Append(HeaderTextList(i) + ",")
            Next
            strbData.Append(vbCrLf)
            '寫出數據
            Dim row As DataRow
            For Each row In dt.Rows
                Dim j As Integer
                For j = 0 To HeaderList.Length - 1
                    If HeaderList(j) = TypeCell Then
                        If row(HeaderList(j)) = "0" Then
                            strbData.Append(String.Empty + ",")
                        Else
                            If Not TypeList Is Nothing AndAlso TypeList.Count > 0 Then
                                Dim h As Integer
                                For h = 0 To TypeList.Count
                                    If row(HeaderList(j)) = TypeList.Item(h).Value Then
                                        'row(HeaderList(j)) = TypeList.Item(h).Key
                                        strbData.Append(TypeList.Item(h).Key.ToString() + ",")
                                        Exit For
                                    End If
                                Next
                            End If
                        End If

                    Else
                        strbData.Append(row(HeaderList(j)).ToString() + ",")
                    End If
                Next
                strbData.Append(vbCrLf)
            Next
            strbData.Append(vbCrLf)
            Return strbData.ToString
        End If
    End Function

    Public Shared Function ExportCSV(ByVal HeaderList As String(), ByVal ds As DataSet, ByVal HeaderTextList As String()) As String

        If HeaderList.Length <> HeaderTextList.Length Then
            Return String.Empty
        Else
            Dim dt As DataTable = ds.Tables(0)
            Return ExportCSV(HeaderList, dt, HeaderTextList)
        End If
    End Function

    ''' <summary>
    ''' 将Collection导出成CSV格式
    ''' </summary>
    ''' <param name="HeaderList"></param>
    ''' <param name="mInfoList"></param>
    ''' <param name="HeaderTextList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExportCSV(ByVal HeaderList As String(), ByVal mInfoList As Object, ByVal HeaderTextList As String()) As String
        If HeaderList.Length <> HeaderTextList.Length Then
            Return String.Empty
        Else
            Dim ObjtctType As String = mInfoList.GetType.Name
            Dim strbData As StringBuilder = New StringBuilder
            Dim i As Integer
            '寫出表頭
            For i = 0 To HeaderTextList.Length - 1
                strbData.Append(HeaderTextList(i) + ",")
            Next
            strbData.Append(vbCrLf)
            '寫出數據
            Dim j As Integer
            For j = 0 To mInfoList.Count - 1 Step j + 1
                Dim k As Integer
                For k = 0 To HeaderList.Length - 1 Step k + 1

                    Dim infos As PropertyInfo() = mInfoList(j).GetType().GetProperties()
                    Dim info As PropertyInfo
                    For Each info In infos

                        Dim ss As String = HeaderList(k)
                        strbData.Append(mInfoList(j).ss)
                    Next
                    strbData.Append(vbCrLf)
                Next
            Next

            strbData.Append(vbCrLf)
            Return strbData.ToString
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 刪除非法字符
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Private Function DelQuota(ByVal str As String) As String
        Dim result As String = str
        Dim strQuota As String() = {"~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?"}
        Dim i As Integer

        For i = 0 To strQuota.Length - 1
            If (result.IndexOf(strQuota(i)) > -1) Then
                result = result.Replace(strQuota(i), "")
            End If
        Next
        Return result
    End Function

End Class


