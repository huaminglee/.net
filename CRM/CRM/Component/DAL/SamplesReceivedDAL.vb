#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  SamplesReceivedDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的SamplesReceivedInfo實例
        ''' </summary>
        ''' <param name="SamplesReceivedInstance">要操作的SamplesReceivedInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SamplesReceivedInstance As SamplesReceivedInfo)
            _SamplesReceivedInstance = SamplesReceivedInstance
        End Sub
#End Region

#Region "屬性"
        Private _SamplesReceivedInstance As SamplesReceivedInfo

        ''' <summary>
        ''' SamplesReceivedInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>SamplesReceivedInfo</returns>
        ''' <remarks></remarks>
        Public Property SamplesReceivedInstance() As SamplesReceivedInfo
            Get
                Return _SamplesReceivedInstance
            End Get
            Set(ByVal Value As SamplesReceivedInfo)
                _SamplesReceivedInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SamplesReceived_Update", _
           				SamplesReceivedInstance.PKID, _
		SamplesReceivedInstance.CustomerPKID, _
		SamplesReceivedInstance.CustomerName, _
		SamplesReceivedInstance.SampleName, _
		SamplesReceivedInstance.SampleNums, _
		SamplesReceivedInstance.ReceivedAddress, _
		SamplesReceivedInstance.Remark, _
		SamplesReceivedInstance.ReachTime, _
		SamplesReceivedInstance.AcceptUser, _
		SamplesReceivedInstance.InformUser, _
		SamplesReceivedInstance.InformEmail, _
		SamplesReceivedInstance.IsTakeaway, _
		SamplesReceivedInstance.TakeawayUser, _
		SamplesReceivedInstance.TakeawayTime, _
		SamplesReceivedInstance.Extend01, _
		SamplesReceivedInstance.Extend02, _
		SamplesReceivedInstance.Extend03, _
		SamplesReceivedInstance.Extend04, _
		SamplesReceivedInstance.Extend05, _
		SamplesReceivedInstance.Extend06, _
		SamplesReceivedInstance.Extend07, _
		SamplesReceivedInstance.Extend08, _
		SamplesReceivedInstance.Extend09, _
		SamplesReceivedInstance.Extend10, _
		SamplesReceivedInstance.RecordCreated, _
		SamplesReceivedInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _SamplesReceivedInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SamplesReceived_Insert", _
           				SamplesReceivedInstance.PKID, _
		SamplesReceivedInstance.CustomerPKID, _
		SamplesReceivedInstance.CustomerName, _
		SamplesReceivedInstance.SampleName, _
		SamplesReceivedInstance.SampleNums, _
		SamplesReceivedInstance.ReceivedAddress, _
		SamplesReceivedInstance.Remark, _
		SamplesReceivedInstance.ReachTime, _
		SamplesReceivedInstance.AcceptUser, _
		SamplesReceivedInstance.InformUser, _
		SamplesReceivedInstance.InformEmail, _
		SamplesReceivedInstance.IsTakeaway, _
		SamplesReceivedInstance.TakeawayUser, _
		SamplesReceivedInstance.TakeawayTime, _
		SamplesReceivedInstance.Extend01, _
		SamplesReceivedInstance.Extend02, _
		SamplesReceivedInstance.Extend03, _
		SamplesReceivedInstance.Extend04, _
		SamplesReceivedInstance.Extend05, _
		SamplesReceivedInstance.Extend06, _
		SamplesReceivedInstance.Extend07, _
		SamplesReceivedInstance.Extend08, _
		SamplesReceivedInstance.Extend09, _
		SamplesReceivedInstance.Extend10, _
		SamplesReceivedInstance.RecordCreated, _
		SamplesReceivedInstance.RecordDeleted))
	 	Return  (_SamplesReceivedInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As SamplesReceivedInfo
		
			 Dim mInfo AS  new SamplesReceivedInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.SampleName = IIf(dr.IsNull("SampleName"), String.Empty, Convert.ToString(dr.Item("SampleName")))
 			mInfo.SampleNums = IIf(dr.IsNull("SampleNums"), 0, Convert.ToInt32(dr.Item("SampleNums")))
			mInfo.ReceivedAddress = IIf(dr.IsNull("ReceivedAddress"), String.Empty, Convert.ToString(dr.Item("ReceivedAddress")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.ReachTime = IIf(dr.IsNull("ReachTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ReachTime")))
			mInfo.AcceptUser = IIf(dr.IsNull("AcceptUser"), String.Empty, Convert.ToString(dr.Item("AcceptUser")))
 			mInfo.InformUser = IIf(dr.IsNull("InformUser"), String.Empty, Convert.ToString(dr.Item("InformUser")))
 			mInfo.InformEmail = IIf(dr.IsNull("InformEmail"), String.Empty, Convert.ToString(dr.Item("InformEmail")))
 			mInfo.IsTakeaway = IIf(dr.IsNull("IsTakeaway"), 0, Convert.ToInt32(dr.Item("IsTakeaway")))
			mInfo.TakeawayUser = IIf(dr.IsNull("TakeawayUser"), String.Empty, Convert.ToString(dr.Item("TakeawayUser")))
 			mInfo.TakeawayTime = IIf(dr.IsNull("TakeawayTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("TakeawayTime")))
			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 			mInfo.Extend06 = IIf(dr.IsNull("Extend06"), String.Empty, Convert.ToString(dr.Item("Extend06")))
 			mInfo.Extend07 = IIf(dr.IsNull("Extend07"), String.Empty, Convert.ToString(dr.Item("Extend07")))
 			mInfo.Extend08 = IIf(dr.IsNull("Extend08"), String.Empty, Convert.ToString(dr.Item("Extend08")))
 			mInfo.Extend09 = IIf(dr.IsNull("Extend09"), String.Empty, Convert.ToString(dr.Item("Extend09")))
 			mInfo.Extend10 = IIf(dr.IsNull("Extend10"), String.Empty, Convert.ToString(dr.Item("Extend10")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _SamplesReceivedInstance Is Nothing Then 
            If _SamplesReceivedInstance.PKID=0  Then
                Return Insert()
            ElseIf _SamplesReceivedInstance.PKID > 0 Then
                    Return Update()
                Else
                   _SamplesReceivedInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the SamplesReceivedInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"SamplesReceived_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As SamplesReceivedInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"SamplesReceived_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of SamplesReceivedInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SamplesReceived_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mSamplesReceived As New list(of SamplesReceivedinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mSamplesReceived.Add(TransformDr(dr))
            Next

            Return mSamplesReceived
		
 	End Function
	#End Region
#End Region
End Class

