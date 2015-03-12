#Region "導入命名空間"
Imports System
Imports Platform.eWorkFlow.Core.DAL
Imports Platform.eWorkFlow.Model
Imports Platform.Framework
Imports Platform.eFlowConfiguration

#End Region

Namespace DAL


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
    Partial Public Class AttachFileInfoDAL

#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的AttachFileInfoInfo實例
        ''' </summary>
        ''' <param name="AttachFileInfoInstance">要操作的AttachFileInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal AttachFileInfoInstance As AttachFileInfoInfo)
            _AttachFileInfoInstance = AttachFileInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _AttachFileInfoInstance As AttachFileInfoInfo

        ''' <summary>
        ''' AttachFileInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>AttachFileInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property AttachFileInfoInstance() As AttachFileInfoInfo
            Get
                Return _AttachFileInfoInstance
            End Get
            Set(ByVal Value As AttachFileInfoInfo)
                _AttachFileInfoInstance = Value
            End Set
        End Property
#End Region

#Region "方法"
#Region "私有方法"
        Private Function Insert() As Object
            If VerifyParameter() Then
                AttachFileInfoInstance.FileID = CType(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                "WF_InsertAttachFileInfo", _
                AttachFileInfoInstance.ParentID, _
                AttachFileInfoInstance.ParentCategory, _
                AttachFileInfoInstance.ParentSubCategory, _
                AttachFileInfoInstance.FileGuID, _
                AttachFileInfoInstance.FileName, _
                AttachFileInfoInstance.FileExtension, _
                AttachFileInfoInstance.FileSize, _
                AttachFileInfoInstance.FileClientName, _
                AttachFileInfoInstance.Extend1, _
                AttachFileInfoInstance.Extend2, _
                AttachFileInfoInstance.Extend3, _
                AttachFileInfoInstance.Extend4, _
                AttachFileInfoInstance.Extend5, _
                AttachFileInfoInstance.RecordVersion, _
                AttachFileInfoInstance.RecordCreateTime, _
                AttachFileInfoInstance.RecordDeleted), Integer)
                Return AttachFileInfoInstance.FileID
            Else
                Return Nothing
            End If
        End Function

        Private Function Update() As Integer
            If VerifyParameter() Then
                Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                "WF_UpdateAttachFileInfo", _
                AttachFileInfoInstance.FileID, _
                AttachFileInfoInstance.ParentID, _
                AttachFileInfoInstance.ParentCategory, _
                AttachFileInfoInstance.ParentSubCategory, _
                AttachFileInfoInstance.FileGuID, _
                AttachFileInfoInstance.FileName, _
                AttachFileInfoInstance.FileExtension, _
                AttachFileInfoInstance.FileSize, _
                AttachFileInfoInstance.FileClientName, _
                AttachFileInfoInstance.Extend1, _
                AttachFileInfoInstance.Extend2, _
                AttachFileInfoInstance.Extend3, _
                AttachFileInfoInstance.Extend4, _
                AttachFileInfoInstance.Extend5, _
                AttachFileInfoInstance.RecordVersion, _
                AttachFileInfoInstance.RecordCreateTime, _
                AttachFileInfoInstance.RecordDeleted))
                Return Result
            Else
                Return 0
            End If
        End Function

        Private Function VerifyParameter() As Boolean
            If AttachFileInfoInstance.FileName.Length > AttachFileInfoInfo.ColumnLengthForFileName Then
                Return False
            End If
            If AttachFileInfoInstance.FileExtension.Length > AttachFileInfoInfo.ColumnLengthForFileExtension Then
                Return False
            End If
            If AttachFileInfoInstance.FileClientName.Length > AttachFileInfoInfo.ColumnLengthForFileClientName Then
                Return False
            End If
            If AttachFileInfoInstance.Extend1.Length > AttachFileInfoInfo.ColumnLengthForExtend1 Then
                Return False
            End If
            If AttachFileInfoInstance.Extend2.Length > AttachFileInfoInfo.ColumnLengthForExtend2 Then
                Return False
            End If
            If AttachFileInfoInstance.Extend3.Length > AttachFileInfoInfo.ColumnLengthForExtend3 Then
                Return False
            End If
            If AttachFileInfoInstance.Extend4.Length > AttachFileInfoInfo.ColumnLengthForExtend4 Then
                Return False
            End If
            If AttachFileInfoInstance.Extend5.Length > AttachFileInfoInfo.ColumnLengthForExtend5 Then
                Return False
            End If
            If AttachFileInfoInstance.RecordVersion.Length > AttachFileInfoInfo.ColumnLengthForRecordVersion Then
                Return False
            End If
            Return True
        End Function

        Private Shared Function TransformDr(ByVal dr As DataRow) As AttachFileInfoInfo
            Dim mInfo As New AttachFileInfoInfo
            If dr.IsNull("FileID") Then
                mInfo.FileID = 0
            Else
                mInfo.FileID = Convert.ToInt32(dr.Item("FileID"))
            End If

            If dr.IsNull("ParentID") Then
                mInfo.ParentID = 0
            Else
                mInfo.ParentID = Convert.ToInt32(dr.Item("ParentID"))
            End If

            If dr.IsNull("ParentCategory") Then
                mInfo.ParentCategory = 0
            Else
                mInfo.ParentCategory = Convert.ToInt32(dr.Item("ParentCategory"))
            End If

            If dr.IsNull("ParentSubCategory") Then
                mInfo.ParentSubCategory = 0
            Else
                mInfo.ParentSubCategory = Convert.ToInt32(dr.Item("ParentSubCategory"))
            End If

            If dr.IsNull("FileGuID") Then
                mInfo.FileGuID = Guid.Empty
            Else
                mInfo.FileGuID = New Guid(dr.Item("FileGuID").ToString)
            End If

            If dr.IsNull("FileName") Then
                mInfo.FileName = ""
            Else
                mInfo.FileName = Convert.ToString(dr.Item("FileName"))
            End If

            If dr.IsNull("FileExtension") Then
                mInfo.FileExtension = ""
            Else
                mInfo.FileExtension = Convert.ToString(dr.Item("FileExtension"))
            End If

            If dr.IsNull("FileSize") Then
                mInfo.FileSize = 0
            Else
                mInfo.FileSize = Convert.ToInt32(dr.Item("FileSize"))
            End If

            If dr.IsNull("FileClientName") Then
                mInfo.FileClientName = ""
            Else
                mInfo.FileClientName = Convert.ToString(dr.Item("FileClientName"))
            End If

            If dr.IsNull("Extend1") Then
                mInfo.Extend1 = ""
            Else
                mInfo.Extend1 = Convert.ToString(dr.Item("Extend1"))
            End If

            If dr.IsNull("Extend2") Then
                mInfo.Extend2 = ""
            Else
                mInfo.Extend2 = Convert.ToString(dr.Item("Extend2"))
            End If

            If dr.IsNull("Extend3") Then
                mInfo.Extend3 = ""
            Else
                mInfo.Extend3 = Convert.ToString(dr.Item("Extend3"))
            End If

            If dr.IsNull("Extend4") Then
                mInfo.Extend4 = ""
            Else
                mInfo.Extend4 = Convert.ToString(dr.Item("Extend4"))
            End If

            If dr.IsNull("Extend5") Then
                mInfo.Extend5 = ""
            Else
                mInfo.Extend5 = Convert.ToString(dr.Item("Extend5"))
            End If

            If dr.IsNull("RecordVersion") Then
                mInfo.RecordVersion = ""
            Else
                mInfo.RecordVersion = Convert.ToString(dr.Item("RecordVersion"))
            End If

            If dr.IsNull("RecordCreateTime") Then
                mInfo.RecordCreateTime = DateTime.Now
            Else
                mInfo.RecordCreateTime = Convert.ToDateTime(dr.Item("RecordCreateTime"))
            End If

            If dr.IsNull("RecordDeleted") Then
                mInfo.RecordDeleted = 0
            Else
                mInfo.RecordDeleted = Convert.ToInt32(dr.Item("RecordDeleted"))
            End If

            Return mInfo
        End Function

        Private Shared Function LoadAllAttachFileInfoInfoCollectionBySearchCondition(ByVal SearchCondition As String) As List(Of AttachFileInfoInfo)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadAttachFileInfoBySearchCondition", SearchCondition)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer
            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If
            Dim mInfos As New List(Of AttachFileInfoInfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mInfos.Add(TransformDr(dr))
            Next
            Return mInfos
        End Function

#End Region

#Region "公有方法"
        ''' <summary>保存數據</summary>
        ''' <returns>True/False</returns>
        ''' <remarks></remarks>
        Public Function Save() As Boolean
            If Not _AttachFileInfoInstance Is Nothing Then
                If _AttachFileInfoInstance.FileID = 0 Then
                    Return (Not Insert() Is Nothing)
                ElseIf _AttachFileInfoInstance.FileID > 0 Then
                    Return Update()
                Else
                    _AttachFileInfoInstance.FileID = 0
                    Return False
                End If
            Else
                Dim ex As New Exception("Please set the AttachFileInfoInstance Property !")
                Throw ex
            End If
        End Function

        ''' <summary>依主鍵刪除記錄</summary>
        ''' <param name="FileID">附件PKID</param>
        ''' <remarks></remarks>
        Public Shared Sub Delete(ByVal FileID As Integer)
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_DeleteAttachFileInfoByPrimaryKey", FileID)
        End Sub

        ''' <summary>刪除記錄</summary>
        ''' <param name="DeleteWhereClauseForAttachFileInfoInfo">刪除條件表達式</param>
        ''' <remarks></remarks>
        Public Shared Sub Delete(ByVal DeleteWhereClauseForAttachFileInfoInfo As SearchWhereClause)
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_DeleteAttachFileInfoByCondition", DeleteWhereClauseForAttachFileInfoInfo.WhereClause)
        End Sub

        ''' <summary>載入指定主鍵對應的AttachFileInfoInfo對象</summary>
        ''' <param name="FileID">FileID</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function LoadAttachFileInfoInfoByFileID(ByVal FileID As Integer) As AttachFileInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadAttachFileInfoByPrimaryKey", FileID)
            Dim dt As DataTable = ds.Tables(0)
            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If
            Dim dr As DataRow = dt.Rows(0)
            Return TransformDr(dr)
        End Function



        ''' <summary>
        ''' 依查詢取得指定的實例個數
        ''' </summary>
        ''' <param name="SearchWhereClauseForAttachFileInfoInfo">查詢表達式類</param>
        ''' <param name="IsUserInputSearchClause">查詢表達式是否通過用戶輸入創建</param>
        ''' <returns>實例個數</returns>
        ''' <remarks></remarks>
        Public Shared Function LoadAllAttachFileInfoInfoCountBySearchCondition(ByVal SearchWhereClauseForAttachFileInfoInfo As SearchWhereClause, _
                      Optional ByVal IsUserInputSearchClause As Boolean = False) As Integer
            Dim SearchCondition As String = ""
            If Not IsUserInputSearchClause Then
                SearchCondition = SearchWhereClauseForAttachFileInfoInfo.WhereClause
            Else
                SearchCondition = SearchWhereClauseForAttachFileInfoInfo.UserInputWhereClause
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_LoadAttachFileInfoBySearchCondition", SearchCondition)
            If (Not ds Is Nothing) AndAlso (ds.Tables.Count > 0) Then
                Return ds.Tables(0).Rows.Count
            Else
                Return 0
            End If
        End Function

        ''' <summary>
        ''' 依查詢取得指定的實例
        ''' </summary>
        ''' <param name="SearchWhereClauseForAttachFileInfoInfo">查詢表達式類</param>
        ''' <param name="IsUserInputSearchClause">查詢表達式是否通過用戶輸入創建</param>
        ''' <returns>AttachFileInfoInfoCollection</returns>
        ''' <remarks></remarks>
        Public Shared Function LoadAllAttachFileInfoInfoCollectionBySearchCondition(ByVal SearchWhereClauseForAttachFileInfoInfo As SearchWhereClause, _
                      Optional ByVal IsUserInputSearchClause As Boolean = False) As List(Of AttachFileInfoInfo)
            Dim SearchConditionStr As String = ""
            If Not IsUserInputSearchClause Then
                SearchConditionStr = SearchWhereClauseForAttachFileInfoInfo.WhereClause
            Else
                SearchConditionStr = SearchWhereClauseForAttachFileInfoInfo.UserInputWhereClause
            End If
            Return LoadAllAttachFileInfoInfoCollectionBySearchCondition(SearchConditionStr)
        End Function

        ''' <summary>
        ''' 分頁取得數據集
        ''' </summary>
        ''' <param name="Filter">條件過濾表達式</param>
        ''' <param name="SortExpression">排序表達式</param>
        ''' <param name="PageNumber">第幾頁</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function LoadInstanceCollectionByCustomPaging(ByVal Filter As String, _
                   ByVal SortExpression As String, ByVal PageNumber As Integer) As List(Of AttachFileInfoInfo)

            Dim ds As DataSet = SearchExtHelper.SearchDataWithCustomPaging(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo", _
      "FileID", SortExpression, PageNumber, 20, Filter)

            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer
            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If
            Dim mInfos As New List(Of AttachFileInfoInfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mInfos.Add(TransformDr(dr))
            Next
            Return mInfos
        End Function

        Public Shared Function LoadAllDirtyAttachFileInfo() As List(Of AttachFileInfoInfo)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_GetAllDirtyAttachFileInfo")

            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer
            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If
            Dim mInfos As New List(Of AttachFileInfoInfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mInfos.Add(TransformDr(dr))
            Next
            Return mInfos
        End Function

        Public Shared Sub DeleteAllDirtyAttachFileInfo()
            SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_DeleteAllDirtyAttachFileInfo")
        End Sub

#End Region

#Region "Collection Method"
        ''' <summary>
        ''' 將實體的泛型集合轉換成Datatable
        ''' </summary>
        ''' <param name="EntityList">實體的泛型集合</param>
        ''' <returns>Datatable</returns>
        ''' <remarks></remarks>
        Public Shared Function EntityList2Datatable(ByVal EntityList As List(Of AttachFileInfoInfo)) As DataTable
            Return ADONetHelper.ToDataTable(EntityList)
        End Function

        ''' <summary>
        ''' 合並對象集合
        ''' </summary>
        ''' <param name="MergeTO">合並到對象集合</param>
        ''' <param name="MergeFrom">合並從對象集合</param>
        ''' <param name="FilterDuplication">是否過濾重復記錄</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Merge(ByVal MergeTO As List(Of AttachFileInfoInfo), ByVal MergeFrom As List(Of AttachFileInfoInfo), Optional ByVal FilterDuplication As Boolean = True) As List(Of AttachFileInfoInfo)
            If (MergeFrom Is Nothing) OrElse (MergeFrom.Count = 0) Then
                Return MergeTO
            End If
            If MergeTO Is Nothing Then
                MergeTO = New List(Of AttachFileInfoInfo)
            End If

            Dim TmpStringList1 As New ArrayList
            Dim TmpStringList2 As New ArrayList

            If FilterDuplication Then '屏蔽重復項
                If MergeTO.Count > 0 Then
                    For Each m As AttachFileInfoInfo In MergeTO
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        If Not TmpStringList1.Contains(SerializationStr) Then
                            TmpStringList1.Add(SerializationStr)
                        End If
                    Next
                End If
                If MergeFrom.Count > 0 Then
                    For Each m As AttachFileInfoInfo In MergeFrom
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        If Not TmpStringList1.Contains(SerializationStr) Then
                            TmpStringList1.Add(SerializationStr)
                            TmpStringList2.Add(SerializationStr)
                        End If
                    Next
                End If
            Else '不做重復處理
                If MergeTO.Count > 0 Then
                    For Each m As AttachFileInfoInfo In MergeTO
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        TmpStringList1.Add(SerializationStr)
                    Next
                End If
                If MergeFrom.Count > 0 Then
                    For Each m As AttachFileInfoInfo In MergeFrom
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        TmpStringList2.Add(SerializationStr)
                    Next
                End If
            End If

            For Each SerializationStr As String In TmpStringList2
                MergeTO.Add(CType(SerializationHelper.DeserializeFromString(SerializationStr), AttachFileInfoInfo))
            Next
            Return MergeTO
        End Function '合並對象集合

        ''' <summary>
        ''' 過濾相同的對象，保留不同的對象
        ''' </summary>
        ''' <param name="Collection1">比對對象集1</param>
        ''' <param name="Collection2">比對對象集2</param>
        ''' <remarks></remarks>
        Public Shared Sub Diff(ByRef Collection1 As List(Of AttachFileInfoInfo), ByRef Collection2 As List(Of AttachFileInfoInfo))
            If ((Collection1 Is Nothing) OrElse (Collection1.Count = 0)) AndAlso ((Collection2 Is Nothing) OrElse (Collection2.Count = 0)) Then
                Dim ex As New ArgumentException("Argument Objects are nothing")
                Throw ex
            Else
                Dim TmpStringList1 As ArrayList = Nothing
                Dim TmpStringList2 As ArrayList = Nothing
                If (Collection1 Is Nothing) OrElse (Collection1.Count = 0) Then
                    Exit Sub
                Else
                    TmpStringList1 = New ArrayList
                    For i As Integer = Collection1.Count - 1 To 0 Step -1
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(CType(Collection1.Item(i), AttachFileInfoInfo))
                        TmpStringList1.Add(SerializationStr)
                    Next
                End If
                If (Collection2 Is Nothing) OrElse (Collection2.Count = 0) Then
                    Exit Sub
                Else
                    TmpStringList2 = New ArrayList
                    For i As Integer = Collection2.Count - 1 To 0 Step -1
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(CType(Collection2.Item(i), AttachFileInfoInfo))
                        TmpStringList2.Add(SerializationStr)
                    Next
                End If

                Dim RemoveIndex1 As New ArrayList
                Dim RemoveIndex2 As New ArrayList

                For i As Integer = TmpStringList1.Count - 1 To 0 Step -1
                    For j As Integer = TmpStringList2.Count - 1 To 0 Step -1
                        If TmpStringList1(i).ToString.ToLower = TmpStringList2(j).ToString.ToLower Then
                            RemoveIndex1.Add(i)
                            RemoveIndex2.Add(j)
                        End If
                    Next
                Next
                For i As Integer = Collection1.Count - 1 To 0 Step -1
                    For j As Integer = RemoveIndex1.Count - 1 To 0 Step -1
                        If i = j Then
                            Collection1.RemoveAt(i)
                        End If
                    Next
                Next
                For i As Integer = Collection2.Count - 1 To 0 Step -1
                    For j As Integer = RemoveIndex2.Count - 1 To 0 Step -1
                        If i = j Then
                            Collection2.RemoveAt(i)
                        End If
                    Next
                Next
            End If
        End Sub '過濾相同的對象，保留不同的對象

        ''' <summary>
        ''' 清減對象集合
        ''' </summary>
        ''' <param name="MinuendCollection">被減數對象集合</param>
        ''' <param name="SubtrahendCollection">減數對象集合</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Subtract(ByVal MinuendCollection As List(Of AttachFileInfoInfo), ByVal SubtrahendCollection As List(Of AttachFileInfoInfo)) As List(Of AttachFileInfoInfo)
            Dim mCollection As List(Of AttachFileInfoInfo) = Nothing
            If (MinuendCollection Is Nothing) OrElse (MinuendCollection.Count = 0) Then
                Dim ex As New ArgumentException("Argument Objects are nothing")
                Throw ex
            Else
                If (SubtrahendCollection Is Nothing) OrElse (SubtrahendCollection.Count = 0) Then
                    Return MinuendCollection
                Else
                    Dim TmpStringList As New ArrayList
                    For Each m As AttachFileInfoInfo In MinuendCollection
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        If Not TmpStringList.Contains(SerializationStr) Then
                            TmpStringList.Add(SerializationStr)
                        End If
                    Next
                    For Each m As AttachFileInfoInfo In SubtrahendCollection
                        Dim SerializationStr As String = SerializationHelper.SerializeToString(m)
                        If TmpStringList.Contains(SerializationStr) Then
                            TmpStringList.Remove(SerializationStr)
                        End If
                    Next
                    If TmpStringList.Count > 0 Then
                        mCollection = New List(Of AttachFileInfoInfo)
                        For Each SerializationStr As String In TmpStringList
                            mCollection.Add(CType(SerializationHelper.DeserializeFromString(SerializationStr), AttachFileInfoInfo))
                        Next
                    End If
                    Return mCollection
                End If
            End If
        End Function '清減對象集合
#End Region

#End Region

    End Class


End Namespace