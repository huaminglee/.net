Public Class SearchExtHelper
    ''' <summary>
    ''' 採用分頁的方式取回數據集
    ''' </summary>
    ''' <param name="TableName">數據集來源的表名</param>
    ''' <param name="PK">表的主鍵名</param>
    ''' <param name="SortExpression">排序表達式(eg: "ColumnName DESC")</param>
    ''' <param name="PageNumber">第幾頁</param>
    ''' <param name="Filter">查詢的Filter條件，默認為:Nothing</param>
    ''' <param name="Fields">查詢返回的欄位列表，默認為"*" 全部</param>
    ''' <param name="Group">查詢的Group條件，默認為:Nothing</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SearchDataWithCustomPaging(ByVal Conn As String, _
        ByVal TableName As String, _
        ByVal PK As String, _
        ByVal SortExpression As String, _
        ByVal PageNumber As Integer, _
        ByVal PageSize As Integer, _
        Optional ByVal Filter As String = Nothing, _
        Optional ByVal Fields As String = "*", _
        Optional ByVal Group As String = Nothing) As DataSet

        Return SqlHelper.ExecuteDataset(Conn, _
                                        "Paging_RowCount", _
                                        TableName, _
                                        PK, _
                                        SortExpression, _
                                        PageNumber, _
                                        PageSize, _
                                        Fields, _
                                        Filter, _
                                        Group)
    End Function

End Class
