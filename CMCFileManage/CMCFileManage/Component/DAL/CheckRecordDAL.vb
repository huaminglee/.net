#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  CheckRecordDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的CheckRecordInfo實例
        ''' </summary>
        ''' <param name="CheckRecordInstance">要操作的CheckRecordInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal CheckRecordInstance As CheckRecordInfo)
            _CheckRecordInstance = CheckRecordInstance
        End Sub
#End Region

#Region "屬性"
        Private _CheckRecordInstance As CheckRecordInfo

        ''' <summary>
        ''' CheckRecordInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>CheckRecordInfo</returns>
        ''' <remarks></remarks>
        Public Property CheckRecordInstance() As CheckRecordInfo
            Get
                Return _CheckRecordInstance
            End Get
            Set(ByVal Value As CheckRecordInfo)
                _CheckRecordInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CheckRecord_Update", _
           				CheckRecordInstance.PKID, _
		CheckRecordInstance.ParentPKID, _
		CheckRecordInstance.Type, _
		CheckRecordInstance.CheckDate, _
		CheckRecordInstance.Quality, _
		CheckRecordInstance.Service, _
		CheckRecordInstance.Delivery, _
		CheckRecordInstance.Others, _
		CheckRecordInstance.IsOK, _
		CheckRecordInstance.CheckPerson, _
		CheckRecordInstance.Remark, _
		CheckRecordInstance.Extend1, _
		CheckRecordInstance.Extend2, _
		CheckRecordInstance.Extend3, _
		CheckRecordInstance.Extend4, _
		CheckRecordInstance.Extend5, _
		CheckRecordInstance.Extend6, _
		CheckRecordInstance.Extend7, _
		CheckRecordInstance.Extend8, _
		CheckRecordInstance.Extend9, _
		CheckRecordInstance.Extend10, _
		CheckRecordInstance.RecordCreated, _
		CheckRecordInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _CheckRecordInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CheckRecord_Insert", _
           				CheckRecordInstance.PKID, _
		CheckRecordInstance.ParentPKID, _
		CheckRecordInstance.Type, _
		CheckRecordInstance.CheckDate, _
		CheckRecordInstance.Quality, _
		CheckRecordInstance.Service, _
		CheckRecordInstance.Delivery, _
		CheckRecordInstance.Others, _
		CheckRecordInstance.IsOK, _
		CheckRecordInstance.CheckPerson, _
		CheckRecordInstance.Remark, _
		CheckRecordInstance.Extend1, _
		CheckRecordInstance.Extend2, _
		CheckRecordInstance.Extend3, _
		CheckRecordInstance.Extend4, _
		CheckRecordInstance.Extend5, _
		CheckRecordInstance.Extend6, _
		CheckRecordInstance.Extend7, _
		CheckRecordInstance.Extend8, _
		CheckRecordInstance.Extend9, _
		CheckRecordInstance.Extend10, _
		CheckRecordInstance.RecordCreated, _
		CheckRecordInstance.RecordDeleted))
	 	Return  (_CheckRecordInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As CheckRecordInfo
		
			 Dim mInfo AS  new CheckRecordInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.ParentPKID = IIf(dr.IsNull("ParentPKID"), 0, Convert.ToInt32(dr.Item("ParentPKID")))
			mInfo.Type = IIf(dr.IsNull("Type"), 0, Convert.ToInt32(dr.Item("Type")))
			mInfo.CheckDate = IIf(dr.IsNull("CheckDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("CheckDate")))
			mInfo.Quality = IIf(dr.IsNull("Quality"), 0, Convert.ToInt32(dr.Item("Quality")))
			mInfo.Service = IIf(dr.IsNull("Service"), 0, Convert.ToInt32(dr.Item("Service")))
			mInfo.Delivery = IIf(dr.IsNull("Delivery"), 0, Convert.ToInt32(dr.Item("Delivery")))
			mInfo.Others = IIf(dr.IsNull("Others"), String.Empty, Convert.ToString(dr.Item("Others")))
 			mInfo.IsOK = IIf(dr.IsNull("IsOK"), 0, Convert.ToInt32(dr.Item("IsOK")))
			mInfo.CheckPerson = IIf(dr.IsNull("CheckPerson"), String.Empty, Convert.ToString(dr.Item("CheckPerson")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.Extend6 = IIf(dr.IsNull("Extend6"), String.Empty, Convert.ToString(dr.Item("Extend6")))
 			mInfo.Extend7 = IIf(dr.IsNull("Extend7"), String.Empty, Convert.ToString(dr.Item("Extend7")))
 			mInfo.Extend8 = IIf(dr.IsNull("Extend8"), String.Empty, Convert.ToString(dr.Item("Extend8")))
 			mInfo.Extend9 = IIf(dr.IsNull("Extend9"), String.Empty, Convert.ToString(dr.Item("Extend9")))
 			mInfo.Extend10 = IIf(dr.IsNull("Extend10"), String.Empty, Convert.ToString(dr.Item("Extend10")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _CheckRecordInstance Is Nothing Then 
            If _CheckRecordInstance.PKID=0  Then
                Return Insert()
            ElseIf _CheckRecordInstance.PKID > 0 Then
                    Return Update()
                Else
                   _CheckRecordInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the CheckRecordInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"CheckRecord_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As CheckRecordInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"CheckRecord_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of CheckRecordInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CheckRecord_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mCheckRecord As New list(of CheckRecordinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mCheckRecord.Add(TransformDr(dr))
            Next

            Return mCheckRecord
		
    End Function
    Public Shared Function GetdsByParentID(ByVal ParentID As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CheckRecord_GetInfoByParentID", ParentID)
        If (ds.Tables(0).Rows.Count = 0) Then
            Return Nothing
        End If
        Return ds
    End Function
	#End Region
#End Region
End Class

