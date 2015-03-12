#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ReportDetailDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ReportDetailInfo實例
        ''' </summary>
        ''' <param name="ReportDetailInstance">要操作的ReportDetailInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ReportDetailInstance As ReportDetailInfo)
            _ReportDetailInstance = ReportDetailInstance
        End Sub
#End Region

#Region "屬性"
        Private _ReportDetailInstance As ReportDetailInfo

        ''' <summary>
        ''' ReportDetailInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ReportDetailInfo</returns>
        ''' <remarks></remarks>
        Public Property ReportDetailInstance() As ReportDetailInfo
            Get
                Return _ReportDetailInstance
            End Get
            Set(ByVal Value As ReportDetailInfo)
                _ReportDetailInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ReportDetail_Update", _
           				ReportDetailInstance.PKID, _
		ReportDetailInstance.QuotationPKID, _
		ReportDetailInstance.eFlowDocID, _
		ReportDetailInstance.StateOrder, _
		ReportDetailInstance.StateName, _
		ReportDetailInstance.IsFinished, _
		ReportDetailInstance.FinishTime, _
		ReportDetailInstance.Extend01, _
		ReportDetailInstance.Extend02, _
		ReportDetailInstance.Extend03, _
		ReportDetailInstance.Extend04, _
		ReportDetailInstance.Extend05, _
		ReportDetailInstance.Extend06, _
		ReportDetailInstance.Extend07, _
		ReportDetailInstance.Extend08, _
		ReportDetailInstance.Extend09, _
		ReportDetailInstance.Extend10, _
		ReportDetailInstance.RecordCreated, _
		ReportDetailInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _ReportDetailInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ReportDetail_Insert", _
           				ReportDetailInstance.PKID, _
		ReportDetailInstance.QuotationPKID, _
		ReportDetailInstance.eFlowDocID, _
		ReportDetailInstance.StateOrder, _
		ReportDetailInstance.StateName, _
		ReportDetailInstance.IsFinished, _
		ReportDetailInstance.FinishTime, _
		ReportDetailInstance.Extend01, _
		ReportDetailInstance.Extend02, _
		ReportDetailInstance.Extend03, _
		ReportDetailInstance.Extend04, _
		ReportDetailInstance.Extend05, _
		ReportDetailInstance.Extend06, _
		ReportDetailInstance.Extend07, _
		ReportDetailInstance.Extend08, _
		ReportDetailInstance.Extend09, _
		ReportDetailInstance.Extend10, _
		ReportDetailInstance.RecordCreated, _
		ReportDetailInstance.RecordDeleted))
	 	Return  (_ReportDetailInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ReportDetailInfo
		
			 Dim mInfo AS  new ReportDetailInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.QuotationPKID = IIf(dr.IsNull("QuotationPKID"), 0, Convert.ToInt32(dr.Item("QuotationPKID")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.IsFinished = IIf(dr.IsNull("IsFinished"), 0, Convert.ToInt32(dr.Item("IsFinished")))
			mInfo.FinishTime = IIf(dr.IsNull("FinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishTime")))
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
	If Not _ReportDetailInstance Is Nothing Then 
            If _ReportDetailInstance.PKID=0  Then
                Return Insert()
            ElseIf _ReportDetailInstance.PKID > 0 Then
                    Return Update()
                Else
                   _ReportDetailInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the ReportDetailInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"ReportDetail_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ReportDetailInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"ReportDetail_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ReportDetailInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReportDetail_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mReportDetail As New list(of ReportDetailinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mReportDetail.Add(TransformDr(dr))
            Next

            Return mReportDetail
		
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFLowdocID As String) As ReportDetailInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReportDetail_GetInfoByeFLowdocID", eFLowdocID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByQuotationPKID(ByVal QuotationPKID As Integer) As ReportDetailInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReportDetail_GetInfoByQuotationPKID", QuotationPKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Sub UPsendsample(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "ReportDetail_UPsendsamle", PKID)
    End Sub
    Public Shared Sub UPsendinvoice(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "ReportDetail_UPsendinvoice", PKID)
    End Sub
    Public Shared Sub UPdoinvoice(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "ReportDetail_UPdoinvoice", PKID)
    End Sub
#End Region
#End Region
End Class

