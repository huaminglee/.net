#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  TestItemManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的TestItemManageInfo實例
        ''' </summary>
        ''' <param name="TestItemManageInstance">要操作的TestItemManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal TestItemManageInstance As TestItemManageInfo)
            _TestItemManageInstance = TestItemManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _TestItemManageInstance As TestItemManageInfo

        ''' <summary>
        ''' TestItemManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>TestItemManageInfo</returns>
        ''' <remarks></remarks>
        Public Property TestItemManageInstance() As TestItemManageInfo
            Get
                Return _TestItemManageInstance
            End Get
            Set(ByVal Value As TestItemManageInfo)
                _TestItemManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionStringAllcq, _
                         "TestItemManage_Update", _
               TestItemManageInstance.PKID, _
  TestItemManageInstance.TestItemPKID, _
  TestItemManageInstance.LbServicePKID, _
  TestItemManageInstance.LbServiceName, _
  TestItemManageInstance.TestItemName, _
  TestItemManageInstance.CBbootfee, _
  TestItemManageInstance.CBunitfee, _
  TestItemManageInstance.DWPJbootfee, _
  TestItemManageInstance.DWPJunitfee, _
  TestItemManageInstance.DWDJbootfee, _
  TestItemManageInstance.DWDJunitfee, _
  TestItemManageInstance.Extend1, _
  TestItemManageInstance.Extend2, _
  TestItemManageInstance.Extend3, _
  TestItemManageInstance.Extend4, _
  TestItemManageInstance.Extend5, _
  TestItemManageInstance.Extend6, _
  TestItemManageInstance.RecordCreated, _
  TestItemManageInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Boolean
        _TestItemManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionStringAllcq, _
                            "TestItemManage_Insert", _
                  TestItemManageInstance.PKID, _
     TestItemManageInstance.TestItemPKID, _
     TestItemManageInstance.LbServicePKID, _
     TestItemManageInstance.LbServiceName, _
     TestItemManageInstance.TestItemName, _
     TestItemManageInstance.CBbootfee, _
     TestItemManageInstance.CBunitfee, _
     TestItemManageInstance.DWPJbootfee, _
     TestItemManageInstance.DWPJunitfee, _
     TestItemManageInstance.DWDJbootfee, _
     TestItemManageInstance.DWDJunitfee, _
     TestItemManageInstance.Extend1, _
     TestItemManageInstance.Extend2, _
     TestItemManageInstance.Extend3, _
     TestItemManageInstance.Extend4, _
     TestItemManageInstance.Extend5, _
     TestItemManageInstance.Extend6, _
     TestItemManageInstance.RecordCreated, _
     TestItemManageInstance.RecordDeleted))
        Return (_TestItemManageInstance.PKID > 0)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As TestItemManageInfo

        Dim mInfo As New TestItemManageInfo
        mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
        mInfo.TestItemPKID = IIf(dr.IsNull("TestItemPKID"), 0, Convert.ToInt32(dr.Item("TestItemPKID")))
        mInfo.LbServicePKID = IIf(dr.IsNull("LbServicePKID"), 0, Convert.ToInt32(dr.Item("LbServicePKID")))
        mInfo.LbServiceName = IIf(dr.IsNull("LbServiceName"), String.Empty, Convert.ToString(dr.Item("LbServiceName")))
        mInfo.TestItemName = IIf(dr.IsNull("TestItemName"), String.Empty, Convert.ToString(dr.Item("TestItemName")))
        mInfo.CBbootfee = IIf(dr.IsNull("CBbootfee"), 0, Convert.ToInt32(dr.Item("CBbootfee")))
        mInfo.CBunitfee = IIf(dr.IsNull("CBunitfee"), 0, Convert.ToInt32(dr.Item("CBunitfee")))
        mInfo.DWPJbootfee = IIf(dr.IsNull("DWPJbootfee"), 0, Convert.ToInt32(dr.Item("DWPJbootfee")))
        mInfo.DWPJunitfee = IIf(dr.IsNull("DWPJunitfee"), 0, Convert.ToInt32(dr.Item("DWPJunitfee")))
        mInfo.DWDJbootfee = IIf(dr.IsNull("DWDJbootfee"), 0, Convert.ToInt32(dr.Item("DWDJbootfee")))
        mInfo.DWDJunitfee = IIf(dr.IsNull("DWDJunitfee"), 0, Convert.ToInt32(dr.Item("DWDJunitfee")))
        mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        mInfo.Extend6 = IIf(dr.IsNull("Extend6"), String.Empty, Convert.ToString(dr.Item("Extend6")))
        mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
        mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
        Return mInfo
    End Function


#End Region

#Region " Public method"
    Public Function Save() As Boolean
        If Not _TestItemManageInstance Is Nothing Then
            If _TestItemManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _TestItemManageInstance.PKID > 0 Then
                Return Update()
            Else
                _TestItemManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the TestItemManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_Delete", PKID)
    End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As TestItemManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByPKIDAllqy(ByVal PKID As Integer) As TestItemManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetAllItem() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllItem")
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetAllService() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllService")
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetAllServiceallqy() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetAllService")
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetAllServiceDic() As List(Of DictionaryEntry)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllService")
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        Dim dr As DataRow
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("LbServicePKID"), dr.Item("LbServiceName").ToString))
        Next
        Return mList

    End Function
    Public Shared Function GetTestItemBySeviceName(ByVal ServiceName As String) As List(Of DictionaryEntry)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllItemByLbServiceName", ServiceName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        Dim dr As DataRow
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("TestItemPKID").ToString + "$" + dr.Item("CBunitfee").ToString + "&" + dr.Item("DWPJbootfee").ToString + "#" + dr.Item("DWPJunitfee").ToString + "*" + dr.Item("Extend1").ToString, dr.Item("TestItemName").ToString))
        Next
        Return mList

    End Function
    Public Shared Function GetVIPTestItemBySeviceName(ByVal ServiceName As String) As List(Of DictionaryEntry)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "VIPTestItemManage_GetAllItemByLbServiceName", ServiceName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        Dim dr As DataRow
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("TestItemPKID").ToString + "$" + dr.Item("CBunitfee").ToString + "&" + dr.Item("DWPJbootfee").ToString + "#" + dr.Item("DWPJunitfee").ToString + "*" + dr.Item("Extend1").ToString, dr.Item("TestItemName").ToString))
        Next
        Return mList

    End Function
    Public Shared Function GetAllItemByTestServicePKID(ByVal TestServicePKID As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllItemByTestServicePKID", Convert.ToInt32(TestServicePKID))
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetAllItemByTestLbServiceName(ByVal LbServiceName As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetAllItemByLbServiceName", LbServiceName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function

    ''' <summary>
    ''' 獲取指定條件的記錄
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As List(Of TestItemManageInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mTestItemManage As New List(Of TestItemManageInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mTestItemManage.Add(TransformDr(dr))
        Next

        Return mTestItemManage

    End Function
    Public Shared Function GetInfoByItemPKID(ByVal ItemPKID As Integer) As TestItemManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemManage_GetInfoByItemPKID", ItemPKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetMinItemPKID() As Integer
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionStringAllcq, "TestItemManage_GetMinItempkid")
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return -1
        End If
        Return CInt(dt.Rows(0).Item("MinItemPKID"))
    End Function
#End Region
#End Region
End Class

