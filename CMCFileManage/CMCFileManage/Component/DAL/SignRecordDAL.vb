#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  SignRecordDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的SignRecordInfo實例
        ''' </summary>
        ''' <param name="SignRecordInstance">要操作的SignRecordInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SignRecordInstance As SignRecordInfo)
            _SignRecordInstance = SignRecordInstance
        End Sub
#End Region

#Region "屬性"
        Private _SignRecordInstance As SignRecordInfo

        ''' <summary>
        ''' SignRecordInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>SignRecordInfo</returns>
        ''' <remarks></remarks>
        Public Property SignRecordInstance() As SignRecordInfo
            Get
                Return _SignRecordInstance
            End Get
            Set(ByVal Value As SignRecordInfo)
                _SignRecordInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SignRecord_Update", _
           				SignRecordInstance.pkid, _
		SignRecordInstance.RecordNo, _
		SignRecordInstance.Singer, _
		SignRecordInstance.SignTime, _
		SignRecordInstance.Signremark, _
		SignRecordInstance.activity, _
		SignRecordInstance.Extend1, _
		SignRecordInstance.Extend2, _
		SignRecordInstance.Extend3))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _SignRecordInstance.pkid= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SignRecord_Insert", _
           				SignRecordInstance.pkid, _
		SignRecordInstance.RecordNo, _
		SignRecordInstance.Singer, _
		SignRecordInstance.SignTime, _
		SignRecordInstance.Signremark, _
		SignRecordInstance.activity, _
		SignRecordInstance.Extend1, _
		SignRecordInstance.Extend2, _
		SignRecordInstance.Extend3))
	 	Return  (_SignRecordInstance.pkid> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As SignRecordInfo
		
			 Dim mInfo AS  new SignRecordInfo
			mInfo.pkid = IIf(dr.IsNull("pkid"), 0, Convert.ToInt32(dr.Item("pkid")))
			mInfo.RecordNo = IIf(dr.IsNull("RecordNo"), String.Empty, Convert.ToString(dr.Item("RecordNo")))
 			mInfo.Singer = IIf(dr.IsNull("Singer"), String.Empty, Convert.ToString(dr.Item("Singer")))
 			mInfo.SignTime = IIf(dr.IsNull("SignTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("SignTime")))
			mInfo.Signremark = IIf(dr.IsNull("Signremark"), String.Empty, Convert.ToString(dr.Item("Signremark")))
 			mInfo.activity = IIf(dr.IsNull("activity"), String.Empty, Convert.ToString(dr.Item("activity")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _SignRecordInstance Is Nothing Then 
            If _SignRecordInstance.pkid=0  Then
                Return Insert()
            ElseIf _SignRecordInstance.pkid > 0 Then
                    Return Update()
                Else
                   _SignRecordInstance.pkid= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the SignRecordInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"SignRecord_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As SignRecordInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"SignRecord_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of SignRecordInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SignRecord_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mSignRecord As New list(of SignRecordinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mSignRecord.Add(TransformDr(dr))
            Next

            Return mSignRecord
		
    End Function
    Public Shared Function GetInfoByRecordNo(ByVal RecordNo As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SignRecord_GetInfoByRecordNo", RecordNo)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
#End Region
#End Region
End Class

