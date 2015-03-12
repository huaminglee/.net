#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  TestItemDetailDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的TestItemDetailInfo實例
        ''' </summary>
        ''' <param name="TestItemDetailInstance">要操作的TestItemDetailInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal TestItemDetailInstance As TestItemDetailInfo)
            _TestItemDetailInstance = TestItemDetailInstance
        End Sub
#End Region

#Region "屬性"
        Private _TestItemDetailInstance As TestItemDetailInfo

        ''' <summary>
        ''' TestItemDetailInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>TestItemDetailInfo</returns>
        ''' <remarks></remarks>
        Public Property TestItemDetailInstance() As TestItemDetailInfo
            Get
                Return _TestItemDetailInstance
            End Get
            Set(ByVal Value As TestItemDetailInfo)
                _TestItemDetailInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "TestItemDetail_Update", _
                    TestItemDetailInstance.PKID, _
       TestItemDetailInstance.QuotationPKID, _
       TestItemDetailInstance.SamplePKID, _
       TestItemDetailInstance.ServiceType, _
       TestItemDetailInstance.ServicePKID, _
       TestItemDetailInstance.TestItemPKID, _
       TestItemDetailInstance.TestItemName, _
       TestItemDetailInstance.Numbers, _
       TestItemDetailInstance.BasicMoney, _
       TestItemDetailInstance.Paijia, _
       TestItemDetailInstance.Shijidanjia, _
       TestItemDetailInstance.Shijizongjia, _
       TestItemDetailInstance.TestStandard, _
       TestItemDetailInstance.Remark, _
       TestItemDetailInstance.Extend01, _
       TestItemDetailInstance.Extend02, _
       TestItemDetailInstance.Extend03, _
       TestItemDetailInstance.Extend04, _
       TestItemDetailInstance.Extend05, _
             TestItemDetailInstance.Extend06, _
       TestItemDetailInstance.Extend07, _
       TestItemDetailInstance.Extend08, _
       TestItemDetailInstance.Extend09, _
       TestItemDetailInstance.Extend10, _
       TestItemDetailInstance.RecordCreated, _
       TestItemDetailInstance.RecordDeleted))
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
        _TestItemDetailInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "TestItemDetail_Insert", _
                  TestItemDetailInstance.PKID, _
     TestItemDetailInstance.QuotationPKID, _
     TestItemDetailInstance.SamplePKID, _
     TestItemDetailInstance.ServiceType, _
     TestItemDetailInstance.ServicePKID, _
     TestItemDetailInstance.TestItemPKID, _
     TestItemDetailInstance.TestItemName, _
     TestItemDetailInstance.Numbers, _
     TestItemDetailInstance.BasicMoney, _
     TestItemDetailInstance.Paijia, _
     TestItemDetailInstance.Shijidanjia, _
     TestItemDetailInstance.Shijizongjia, _
     TestItemDetailInstance.TestStandard, _
     TestItemDetailInstance.Remark, _
     TestItemDetailInstance.Extend01, _
     TestItemDetailInstance.Extend02, _
     TestItemDetailInstance.Extend03, _
     TestItemDetailInstance.Extend04, _
     TestItemDetailInstance.Extend05, _
           TestItemDetailInstance.Extend06, _
     TestItemDetailInstance.Extend07, _
     TestItemDetailInstance.Extend08, _
     TestItemDetailInstance.Extend09, _
     TestItemDetailInstance.Extend10, _
     TestItemDetailInstance.RecordCreated, _
     TestItemDetailInstance.RecordDeleted))
	 	Return  (_TestItemDetailInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As TestItemDetailInfo
		
			 Dim mInfo AS  new TestItemDetailInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.QuotationPKID = IIf(dr.IsNull("QuotationPKID"), 0, Convert.ToInt32(dr.Item("QuotationPKID")))
			mInfo.SamplePKID = IIf(dr.IsNull("SamplePKID"), 0, Convert.ToInt32(dr.Item("SamplePKID")))
			mInfo.ServiceType = IIf(dr.IsNull("ServiceType"), String.Empty, Convert.ToString(dr.Item("ServiceType")))
 			mInfo.ServicePKID = IIf(dr.IsNull("ServicePKID"), 0, Convert.ToInt32(dr.Item("ServicePKID")))
			mInfo.TestItemPKID = IIf(dr.IsNull("TestItemPKID"), 0, Convert.ToInt32(dr.Item("TestItemPKID")))
			mInfo.TestItemName = IIf(dr.IsNull("TestItemName"), String.Empty, Convert.ToString(dr.Item("TestItemName")))
 			mInfo.Numbers = IIf(dr.IsNull("Numbers"), 0, Convert.ToInt32(dr.Item("Numbers")))
			mInfo.BasicMoney = IIf(dr.IsNull("BasicMoney"), 0, Convert.ToInt32(dr.Item("BasicMoney")))
			mInfo.Paijia = IIf(dr.IsNull("Paijia"), 0, Convert.ToInt32(dr.Item("Paijia")))
			mInfo.Shijidanjia = IIf(dr.IsNull("Shijidanjia"), 0, Convert.ToInt32(dr.Item("Shijidanjia")))
        mInfo.Shijizongjia = IIf(dr.IsNull("Shijizongjia"), 0, CDbl(dr.Item("Shijizongjia")))
			mInfo.TestStandard = IIf(dr.IsNull("TestStandard"), String.Empty, Convert.ToString(dr.Item("TestStandard")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
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
	If Not _TestItemDetailInstance Is Nothing Then 
            If _TestItemDetailInstance.PKID=0  Then
                Return Insert()
            ElseIf _TestItemDetailInstance.PKID > 0 Then
                    Return Update()
                Else
                   _TestItemDetailInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the TestItemDetailInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"TestItemDetail_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As TestItemDetailInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"TestItemDetail_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of TestItemDetailInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemDetail_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mTestItemDetail As New list(of TestItemDetailinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mTestItemDetail.Add(TransformDr(dr))
            Next

            Return mTestItemDetail
		
    End Function
    Public Shared Function GetInfoSamplePKID(ByVal SamplePKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemDetail_GetInfoSamplePKID", SamplePKID)
        Dim dt As DataTable = ds.Tables(0)
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetDsByQuotationPKID(ByVal QuotationPKID As Integer) As DataSet
        Dim DS As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestItemDetail_GetInfoByQuotationPKID", QuotationPKID)
        Dim DT As DataTable = DS.Tables(0)
        If (DT.Rows.Count = 0) Then
            Return Nothing
        End If
        Return DS
    End Function
    Public Shared Sub UpTestNoByQuotationPKIDandServicetype(ByVal QuotationPKID As Integer, ByVal ServiceType As String, ByVal TestNo As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "TestItemDetail_UpTestNoByQuotationPKIDandServicetype", QuotationPKID, ServiceType, TestNo)

    End Sub
    Public Shared Function GetSamplesAndTestNoByQuotationPKID(ByVal pkid As Integer) As String()
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetSamplesAndTestNOByQuotationPKID", pkid)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow = dt.Rows(0)
        If Not dr.IsNull("Sample") AndAlso Not dr.IsNull("TestNos") Then
            Dim SampleandTestno(2) As String
            SampleandTestno(0) = dr.Item("Sample")
            SampleandTestno(1) = dr.Item("TestNos")
            Return SampleandTestno
        End If
        Return Nothing
    End Function
	#End Region
#End Region
End Class

