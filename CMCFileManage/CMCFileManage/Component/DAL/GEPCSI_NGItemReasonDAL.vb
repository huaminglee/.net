#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  GEPCSI_NGItemReasonDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的GEPCSI_NGItemReasonInfo實例
        ''' </summary>
        ''' <param name="GEPCSI_NGItemReasonInstance">要操作的GEPCSI_NGItemReasonInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal GEPCSI_NGItemReasonInstance As GEPCSI_NGItemReasonInfo)
            _GEPCSI_NGItemReasonInstance = GEPCSI_NGItemReasonInstance
        End Sub
#End Region

#Region "屬性"
        Private _GEPCSI_NGItemReasonInstance As GEPCSI_NGItemReasonInfo

        ''' <summary>
        ''' GEPCSI_NGItemReasonInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>GEPCSI_NGItemReasonInfo</returns>
        ''' <remarks></remarks>
        Public Property GEPCSI_NGItemReasonInstance() As GEPCSI_NGItemReasonInfo
            Get
                Return _GEPCSI_NGItemReasonInstance
            End Get
            Set(ByVal Value As GEPCSI_NGItemReasonInfo)
                _GEPCSI_NGItemReasonInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "GEPCSI_NGItemReason_Update", _
           				GEPCSI_NGItemReasonInstance.PKID, _
		GEPCSI_NGItemReasonInstance.DeptItemPKID, _
		GEPCSI_NGItemReasonInstance.NGItemNO, _
		GEPCSI_NGItemReasonInstance.NGItemName, _
		GEPCSI_NGItemReasonInstance.IsWithTextBox, _
		GEPCSI_NGItemReasonInstance.DisplayOrder, _
		GEPCSI_NGItemReasonInstance.Extend1, _
		GEPCSI_NGItemReasonInstance.Extend2, _
		GEPCSI_NGItemReasonInstance.Extend3, _
		GEPCSI_NGItemReasonInstance.Extend4, _
		GEPCSI_NGItemReasonInstance.Extend5, _
		GEPCSI_NGItemReasonInstance.RecordDeleted, _
		GEPCSI_NGItemReasonInstance.RecordCreated, _
		GEPCSI_NGItemReasonInstance.RecordVersion))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _GEPCSI_NGItemReasonInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "GEPCSI_NGItemReason_Insert", _
           				GEPCSI_NGItemReasonInstance.PKID, _
		GEPCSI_NGItemReasonInstance.DeptItemPKID, _
		GEPCSI_NGItemReasonInstance.NGItemNO, _
		GEPCSI_NGItemReasonInstance.NGItemName, _
		GEPCSI_NGItemReasonInstance.IsWithTextBox, _
		GEPCSI_NGItemReasonInstance.DisplayOrder, _
		GEPCSI_NGItemReasonInstance.Extend1, _
		GEPCSI_NGItemReasonInstance.Extend2, _
		GEPCSI_NGItemReasonInstance.Extend3, _
		GEPCSI_NGItemReasonInstance.Extend4, _
		GEPCSI_NGItemReasonInstance.Extend5, _
		GEPCSI_NGItemReasonInstance.RecordDeleted, _
		GEPCSI_NGItemReasonInstance.RecordCreated, _
		GEPCSI_NGItemReasonInstance.RecordVersion))
	 	Return  (_GEPCSI_NGItemReasonInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_NGItemReasonInfo
		
			 Dim mInfo AS  new GEPCSI_NGItemReasonInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.DeptItemPKID = IIf(dr.IsNull("DeptItemPKID"), 0, Convert.ToInt32(dr.Item("DeptItemPKID")))
			mInfo.NGItemNO = IIf(dr.IsNull("NGItemNO"), 0, Convert.ToInt32(dr.Item("NGItemNO")))
			mInfo.NGItemName = IIf(dr.IsNull("NGItemName"), String.Empty, Convert.ToString(dr.Item("NGItemName")))
 			mInfo.IsWithTextBox = IIf(dr.IsNull("IsWithTextBox"), 0, Convert.ToInt32(dr.Item("IsWithTextBox")))
			mInfo.DisplayOrder = IIf(dr.IsNull("DisplayOrder"), String.Empty, Convert.ToString(dr.Item("DisplayOrder")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordVersion = IIf(dr.IsNull("RecordVersion"), String.Empty, Convert.ToString(dr.Item("RecordVersion")))
 		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _GEPCSI_NGItemReasonInstance Is Nothing Then 
            If _GEPCSI_NGItemReasonInstance.PKID=0  Then
                Return Insert()
            ElseIf _GEPCSI_NGItemReasonInstance.PKID > 0 Then
                    Return Update()
                Else
                   _GEPCSI_NGItemReasonInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the GEPCSI_NGItemReasonInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"GEPCSI_NGItemReason_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_NGItemReasonInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"GEPCSI_NGItemReason_GetInfoByPKID", PKID)
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
    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_NGItemReason_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If


        Return ds

    End Function
    Public Shared Function GetReportInfoBySearchCondtion(ByVal SearchString As String, ByVal DeptItemPKID As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailReport_GetNGItemBySearchCondition", SearchString, DeptItemPKID)

        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If
    End Function
	#End Region
#End Region
End Class

