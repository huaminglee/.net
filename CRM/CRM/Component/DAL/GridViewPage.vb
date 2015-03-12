Public Class GridViewPage
    Public Shared Function GetPageInfoBySearchCondition(ByVal TableName As String, ByVal SearchCondition As String, ByVal Fields As String, _
                                                       ByVal OrderField As String, Optional ByVal PageSize As Integer = 20, _
                                                       Optional ByVal pageIndex As Integer = 1, Optional ByVal TotalRecord As Integer = 0) As DataSet

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "up_Page2005V2", TableName, Fields, OrderField, SearchCondition, PageSize, pageIndex, TotalRecord)
        Dim dt As DataTableCollection = ds.Tables()
        If dt(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If

    End Function
End Class
