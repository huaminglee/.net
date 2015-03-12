#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  SampleInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的SampleInfoInfo實例
        ''' </summary>
        ''' <param name="SampleInfoInstance">要操作的SampleInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SampleInfoInstance As SampleInfoInfo)
            _SampleInfoInstance = SampleInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _SampleInfoInstance As SampleInfoInfo

        ''' <summary>
        ''' SampleInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>SampleInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property SampleInfoInstance() As SampleInfoInfo
            Get
                Return _SampleInfoInstance
            End Get
            Set(ByVal Value As SampleInfoInfo)
                _SampleInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SampleInfo_Update", _
           				SampleInfoInstance.PKID, _
		SampleInfoInstance.QuotationPKID, _
		SampleInfoInstance.SampleName, _
		SampleInfoInstance.IsNeedBack, _
		SampleInfoInstance.Numbers, _
		SampleInfoInstance.Extend01, _
		SampleInfoInstance.Extend02, _
		SampleInfoInstance.Extend03, _
		SampleInfoInstance.Extend04, _
		SampleInfoInstance.Extend05, _
		SampleInfoInstance.RecordCreated, _
		SampleInfoInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _SampleInfoInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SampleInfo_Insert", _
           				SampleInfoInstance.PKID, _
		SampleInfoInstance.QuotationPKID, _
		SampleInfoInstance.SampleName, _
		SampleInfoInstance.IsNeedBack, _
		SampleInfoInstance.Numbers, _
		SampleInfoInstance.Extend01, _
		SampleInfoInstance.Extend02, _
		SampleInfoInstance.Extend03, _
		SampleInfoInstance.Extend04, _
		SampleInfoInstance.Extend05, _
		SampleInfoInstance.RecordCreated, _
		SampleInfoInstance.RecordDeleted))
	 	Return  (_SampleInfoInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As SampleInfoInfo
		
			 Dim mInfo AS  new SampleInfoInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.QuotationPKID = IIf(dr.IsNull("QuotationPKID"), 0, Convert.ToInt32(dr.Item("QuotationPKID")))
			mInfo.SampleName = IIf(dr.IsNull("SampleName"), String.Empty, Convert.ToString(dr.Item("SampleName")))
 			mInfo.IsNeedBack = IIf(dr.IsNull("IsNeedBack"), 0, Convert.ToInt32(dr.Item("IsNeedBack")))
			mInfo.Numbers = IIf(dr.IsNull("Numbers"), 0, Convert.ToInt32(dr.Item("Numbers")))
			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _SampleInfoInstance Is Nothing Then 
            If _SampleInfoInstance.PKID=0  Then
                Return Insert()
            ElseIf _SampleInfoInstance.PKID > 0 Then
                    Return Update()
                Else
                   _SampleInfoInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the SampleInfoInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"SampleInfo_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As SampleInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"SampleInfo_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of SampleInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mSampleInfo As New list(of SampleInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mSampleInfo.Add(TransformDr(dr))
            Next

            Return mSampleInfo
		
    End Function
    Public Shared Function GetdByPKID(ByVal PKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleInfo_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If



        Return dt
    End Function

   
    Public Shared Function GetSampleAndTestItemByQuotationPKID(ByVal QuotationPKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleInfoAndTestItem_GetInfoByQuotationPKID", QuotationPKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt

    End Function

    Public Shared Function GetSampleInfoByQuotationPKID(ByVal QuotationPKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleInfo_GetInfoByQuotationPKID", QuotationPKID)


        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt

    End Function

    Public Shared Function GetSampleAndTestItem(ByVal SamplePKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleAndTestItem_GetInfoBySamplePKID", SamplePKID)


        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetSampleInfoByPKID(ByVal SamplePKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SampleInfo_GetInfoByPKID", SamplePKID)


        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
	#End Region
#End Region
End Class

