#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  CustomerGradeChangeRecordDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的CustomerGradeChangeRecordInfo實例
        ''' </summary>
        ''' <param name="CustomerGradeChangeRecordInstance">要操作的CustomerGradeChangeRecordInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal CustomerGradeChangeRecordInstance As CustomerGradeChangeRecordInfo)
            _CustomerGradeChangeRecordInstance = CustomerGradeChangeRecordInstance
        End Sub
#End Region

#Region "屬性"
        Private _CustomerGradeChangeRecordInstance As CustomerGradeChangeRecordInfo

        ''' <summary>
        ''' CustomerGradeChangeRecordInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>CustomerGradeChangeRecordInfo</returns>
        ''' <remarks></remarks>
        Public Property CustomerGradeChangeRecordInstance() As CustomerGradeChangeRecordInfo
            Get
                Return _CustomerGradeChangeRecordInstance
            End Get
            Set(ByVal Value As CustomerGradeChangeRecordInfo)
                _CustomerGradeChangeRecordInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CustomerGradeChangeRecord_Update", _
           				CustomerGradeChangeRecordInstance.PKID, _
		CustomerGradeChangeRecordInstance.CustomerPKID, _
		CustomerGradeChangeRecordInstance.ChangePerson, _
		CustomerGradeChangeRecordInstance.OldGrade, _
		CustomerGradeChangeRecordInstance.NewGrade, _
		CustomerGradeChangeRecordInstance.Reason, _
		CustomerGradeChangeRecordInstance.Extend1, _
		CustomerGradeChangeRecordInstance.Extend2, _
		CustomerGradeChangeRecordInstance.Extend3, _
		CustomerGradeChangeRecordInstance.Extend4, _
		CustomerGradeChangeRecordInstance.Extend5, _
		CustomerGradeChangeRecordInstance.RecordCreated, _
		CustomerGradeChangeRecordInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _CustomerGradeChangeRecordInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CustomerGradeChangeRecord_Insert", _
           				CustomerGradeChangeRecordInstance.PKID, _
		CustomerGradeChangeRecordInstance.CustomerPKID, _
		CustomerGradeChangeRecordInstance.ChangePerson, _
		CustomerGradeChangeRecordInstance.OldGrade, _
		CustomerGradeChangeRecordInstance.NewGrade, _
		CustomerGradeChangeRecordInstance.Reason, _
		CustomerGradeChangeRecordInstance.Extend1, _
		CustomerGradeChangeRecordInstance.Extend2, _
		CustomerGradeChangeRecordInstance.Extend3, _
		CustomerGradeChangeRecordInstance.Extend4, _
		CustomerGradeChangeRecordInstance.Extend5, _
		CustomerGradeChangeRecordInstance.RecordCreated, _
		CustomerGradeChangeRecordInstance.RecordDeleted))
	 	Return  (_CustomerGradeChangeRecordInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As CustomerGradeChangeRecordInfo
		
			 Dim mInfo AS  new CustomerGradeChangeRecordInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.ChangePerson = IIf(dr.IsNull("ChangePerson"), String.Empty, Convert.ToString(dr.Item("ChangePerson")))
 			mInfo.OldGrade = IIf(dr.IsNull("OldGrade"), String.Empty, Convert.ToString(dr.Item("OldGrade")))
 			mInfo.NewGrade = IIf(dr.IsNull("NewGrade"), String.Empty, Convert.ToString(dr.Item("NewGrade")))
 			mInfo.Reason = IIf(dr.IsNull("Reason"), String.Empty, Convert.ToString(dr.Item("Reason")))
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
	If Not _CustomerGradeChangeRecordInstance Is Nothing Then 
            If _CustomerGradeChangeRecordInstance.PKID=0  Then
                Return Insert()
            ElseIf _CustomerGradeChangeRecordInstance.PKID > 0 Then
                    Return Update()
                Else
                   _CustomerGradeChangeRecordInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the CustomerGradeChangeRecordInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"CustomerGradeChangeRecord_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As CustomerGradeChangeRecordInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"CustomerGradeChangeRecord_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetDsByCustomerPKID(ByVal CustomerPKID As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CustomerGradeChangeRecord_GetDsByCustomerPKID", CustomerPKID)
        Dim dt As DataTable = ds.Tables(0)
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return ds
    End Function
	    ''' <summary>
    ''' 獲取指定條件的記錄
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of CustomerGradeChangeRecordInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CustomerGradeChangeRecord_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mCustomerGradeChangeRecord As New list(of CustomerGradeChangeRecordinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mCustomerGradeChangeRecord.Add(TransformDr(dr))
            Next

            Return mCustomerGradeChangeRecord
		
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFLowdocID As String) As CustomerGradeChangeRecordInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CustomerGradeChangeRecord_GetInfoByeeFLowdocID", eFLowdocID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
	#End Region
#End Region
End Class

