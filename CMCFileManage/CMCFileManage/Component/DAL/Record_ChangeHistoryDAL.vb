#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  Record_ChangeHistoryDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的Record_ChangeHistoryInfo實例
        ''' </summary>
        ''' <param name="Record_ChangeHistoryInstance">要操作的Record_ChangeHistoryInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Record_ChangeHistoryInstance As Record_ChangeHistoryInfo)
            _Record_ChangeHistoryInstance = Record_ChangeHistoryInstance
        End Sub
#End Region

#Region "屬性"
        Private _Record_ChangeHistoryInstance As Record_ChangeHistoryInfo

        ''' <summary>
        ''' Record_ChangeHistoryInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>Record_ChangeHistoryInfo</returns>
        ''' <remarks></remarks>
        Public Property Record_ChangeHistoryInstance() As Record_ChangeHistoryInfo
            Get
                Return _Record_ChangeHistoryInstance
            End Get
            Set(ByVal Value As Record_ChangeHistoryInfo)
                _Record_ChangeHistoryInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Record_ChangeHistory_Update", _
           				Record_ChangeHistoryInstance.PKID, _
		Record_ChangeHistoryInstance.RecordPKID, _
		Record_ChangeHistoryInstance.ChangeCategory, _
		Record_ChangeHistoryInstance.ChangeUser, _
		Record_ChangeHistoryInstance.ChangeTime, _
		Record_ChangeHistoryInstance.ChangeReason, _
		Record_ChangeHistoryInstance.Extend1, _
		Record_ChangeHistoryInstance.Extend2, _
		Record_ChangeHistoryInstance.Extend3, _
		Record_ChangeHistoryInstance.Extend4, _
		Record_ChangeHistoryInstance.Extend5, _
		Record_ChangeHistoryInstance.RecordCreated, _
		Record_ChangeHistoryInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _Record_ChangeHistoryInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Record_ChangeHistory_Insert", _
           				Record_ChangeHistoryInstance.PKID, _
		Record_ChangeHistoryInstance.RecordPKID, _
		Record_ChangeHistoryInstance.ChangeCategory, _
		Record_ChangeHistoryInstance.ChangeUser, _
		Record_ChangeHistoryInstance.ChangeTime, _
		Record_ChangeHistoryInstance.ChangeReason, _
		Record_ChangeHistoryInstance.Extend1, _
		Record_ChangeHistoryInstance.Extend2, _
		Record_ChangeHistoryInstance.Extend3, _
		Record_ChangeHistoryInstance.Extend4, _
		Record_ChangeHistoryInstance.Extend5, _
		Record_ChangeHistoryInstance.RecordCreated, _
		Record_ChangeHistoryInstance.RecordDeleted))
	 	Return  (_Record_ChangeHistoryInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As Record_ChangeHistoryInfo
		
			 Dim mInfo AS  new Record_ChangeHistoryInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordPKID = IIf(dr.IsNull("RecordPKID"), String.Empty, Convert.ToString(dr.Item("RecordPKID")))
 			mInfo.ChangeCategory = IIf(dr.IsNull("ChangeCategory"), 0, Convert.ToInt32(dr.Item("ChangeCategory")))
			mInfo.ChangeUser = IIf(dr.IsNull("ChangeUser"), String.Empty, Convert.ToString(dr.Item("ChangeUser")))
 			mInfo.ChangeTime = IIf(dr.IsNull("ChangeTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ChangeTime")))
			mInfo.ChangeReason = IIf(dr.IsNull("ChangeReason"), String.Empty, Convert.ToString(dr.Item("ChangeReason")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _Record_ChangeHistoryInstance Is Nothing Then 
            If _Record_ChangeHistoryInstance.PKID=0  Then
                Return Insert()
            ElseIf _Record_ChangeHistoryInstance.PKID > 0 Then
                    Return Update()
                Else
                   _Record_ChangeHistoryInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the Record_ChangeHistoryInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Record_ChangeHistory_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As Record_ChangeHistoryInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Record_ChangeHistory_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
        End Function
	    ''' <summary>
    ''' 獲取指定條件的記錄
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of Record_ChangeHistoryInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Record_ChangeHistory_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mRecord_ChangeHistory As New list(of Record_ChangeHistoryinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mRecord_ChangeHistory.Add(TransformDr(dr))
            Next

            Return mRecord_ChangeHistory
		
    End Function
    Public Shared Function GetInfoByRecordPKID(ByVal RecordPKID As Integer, ByVal type As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Record_ChangeHistory_GetInfoByRecordPKID", RecordPKID, type)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Return dt
    End Function
	#End Region
#End Region
End Class

