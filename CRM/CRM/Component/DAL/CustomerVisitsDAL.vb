#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  CustomerVisitsDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的CustomerVisitsInfo實例
        ''' </summary>
        ''' <param name="CustomerVisitsInstance">要操作的CustomerVisitsInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal CustomerVisitsInstance As CustomerVisitsInfo)
            _CustomerVisitsInstance = CustomerVisitsInstance
        End Sub
#End Region

#Region "屬性"
        Private _CustomerVisitsInstance As CustomerVisitsInfo

        ''' <summary>
        ''' CustomerVisitsInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>CustomerVisitsInfo</returns>
        ''' <remarks></remarks>
        Public Property CustomerVisitsInstance() As CustomerVisitsInfo
            Get
                Return _CustomerVisitsInstance
            End Get
            Set(ByVal Value As CustomerVisitsInfo)
                _CustomerVisitsInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CustomerVisits_Update", _
           				CustomerVisitsInstance.PKID, _
		CustomerVisitsInstance.VisitsNO, _
		CustomerVisitsInstance.eFlowDocID, _
		CustomerVisitsInstance.StateName, _
		CustomerVisitsInstance.IsFinished, _
		CustomerVisitsInstance.FinishTime, _
		CustomerVisitsInstance.StateOrder, _
		CustomerVisitsInstance.QuoterID, _
		CustomerVisitsInstance.QuoterName, _
		CustomerVisitsInstance.VisitDate, _
		CustomerVisitsInstance.IsFirstVisits, _
		CustomerVisitsInstance.CustomerPKID, _
		CustomerVisitsInstance.CustomerName, _
		CustomerVisitsInstance.CustomerSources, _
		CustomerVisitsInstance.CustomerScale, _
		CustomerVisitsInstance.CustomerNature, _
		CustomerVisitsInstance.ProductRange, _
		CustomerVisitsInstance.TestAmountPerYeay, _
		CustomerVisitsInstance.CooperationAgen, _
		CustomerVisitsInstance.TypeofPay, _
		CustomerVisitsInstance.CooperationProj, _
		CustomerVisitsInstance.CustomerAddress, _
		CustomerVisitsInstance.Remark, _
		CustomerVisitsInstance.Conversationmatters, _
		CustomerVisitsInstance.Result, _
		CustomerVisitsInstance.Mattertracked, _
		CustomerVisitsInstance.Extend01, _
		CustomerVisitsInstance.Extend02, _
		CustomerVisitsInstance.Extend03, _
		CustomerVisitsInstance.Extend04, _
		CustomerVisitsInstance.Extend05, _
		CustomerVisitsInstance.Extend06, _
		CustomerVisitsInstance.Extend07, _
		CustomerVisitsInstance.Extend08, _
		CustomerVisitsInstance.Extend09, _
		CustomerVisitsInstance.Extend10, _
		CustomerVisitsInstance.RecordCreated, _
		CustomerVisitsInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _CustomerVisitsInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "CustomerVisits_Insert", _
           				CustomerVisitsInstance.PKID, _
		CustomerVisitsInstance.VisitsNO, _
		CustomerVisitsInstance.eFlowDocID, _
		CustomerVisitsInstance.StateName, _
		CustomerVisitsInstance.IsFinished, _
		CustomerVisitsInstance.FinishTime, _
		CustomerVisitsInstance.StateOrder, _
		CustomerVisitsInstance.QuoterID, _
		CustomerVisitsInstance.QuoterName, _
		CustomerVisitsInstance.VisitDate, _
		CustomerVisitsInstance.IsFirstVisits, _
		CustomerVisitsInstance.CustomerPKID, _
		CustomerVisitsInstance.CustomerName, _
		CustomerVisitsInstance.CustomerSources, _
		CustomerVisitsInstance.CustomerScale, _
		CustomerVisitsInstance.CustomerNature, _
		CustomerVisitsInstance.ProductRange, _
		CustomerVisitsInstance.TestAmountPerYeay, _
		CustomerVisitsInstance.CooperationAgen, _
		CustomerVisitsInstance.TypeofPay, _
		CustomerVisitsInstance.CooperationProj, _
		CustomerVisitsInstance.CustomerAddress, _
		CustomerVisitsInstance.Remark, _
		CustomerVisitsInstance.Conversationmatters, _
		CustomerVisitsInstance.Result, _
		CustomerVisitsInstance.Mattertracked, _
		CustomerVisitsInstance.Extend01, _
		CustomerVisitsInstance.Extend02, _
		CustomerVisitsInstance.Extend03, _
		CustomerVisitsInstance.Extend04, _
		CustomerVisitsInstance.Extend05, _
		CustomerVisitsInstance.Extend06, _
		CustomerVisitsInstance.Extend07, _
		CustomerVisitsInstance.Extend08, _
		CustomerVisitsInstance.Extend09, _
		CustomerVisitsInstance.Extend10, _
		CustomerVisitsInstance.RecordCreated, _
		CustomerVisitsInstance.RecordDeleted))
	 	Return  (_CustomerVisitsInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As CustomerVisitsInfo
		
			 Dim mInfo AS  new CustomerVisitsInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.VisitsNO = IIf(dr.IsNull("VisitsNO"), String.Empty, Convert.ToString(dr.Item("VisitsNO")))
 			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.IsFinished = IIf(dr.IsNull("IsFinished"), 0, Convert.ToInt32(dr.Item("IsFinished")))
			mInfo.FinishTime = IIf(dr.IsNull("FinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishTime")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.QuoterID = IIf(dr.IsNull("QuoterID"), String.Empty, Convert.ToString(dr.Item("QuoterID")))
 			mInfo.QuoterName = IIf(dr.IsNull("QuoterName"), String.Empty, Convert.ToString(dr.Item("QuoterName")))
 			mInfo.VisitDate = IIf(dr.IsNull("VisitDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("VisitDate")))
			mInfo.IsFirstVisits = IIf(dr.IsNull("IsFirstVisits"), 0, Convert.ToInt32(dr.Item("IsFirstVisits")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.CustomerSources = IIf(dr.IsNull("CustomerSources"), String.Empty, Convert.ToString(dr.Item("CustomerSources")))
 			mInfo.CustomerScale = IIf(dr.IsNull("CustomerScale"), String.Empty, Convert.ToString(dr.Item("CustomerScale")))
 			mInfo.CustomerNature = IIf(dr.IsNull("CustomerNature"), String.Empty, Convert.ToString(dr.Item("CustomerNature")))
 			mInfo.ProductRange = IIf(dr.IsNull("ProductRange"), String.Empty, Convert.ToString(dr.Item("ProductRange")))
 			mInfo.TestAmountPerYeay = IIf(dr.IsNull("TestAmountPerYeay"), 0, Convert.ToInt32(dr.Item("TestAmountPerYeay")))
			mInfo.CooperationAgen = IIf(dr.IsNull("CooperationAgen"), String.Empty, Convert.ToString(dr.Item("CooperationAgen")))
 			mInfo.TypeofPay = IIf(dr.IsNull("TypeofPay"), 0, Convert.ToInt32(dr.Item("TypeofPay")))
			mInfo.CooperationProj = IIf(dr.IsNull("CooperationProj"), String.Empty, Convert.ToString(dr.Item("CooperationProj")))
 			mInfo.CustomerAddress = IIf(dr.IsNull("CustomerAddress"), String.Empty, Convert.ToString(dr.Item("CustomerAddress")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Conversationmatters = IIf(dr.IsNull("Conversationmatters"), String.Empty, Convert.ToString(dr.Item("Conversationmatters")))
 			mInfo.Result = IIf(dr.IsNull("Result"), String.Empty, Convert.ToString(dr.Item("Result")))
 			mInfo.Mattertracked = IIf(dr.IsNull("Mattertracked"), String.Empty, Convert.ToString(dr.Item("Mattertracked")))
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
	If Not _CustomerVisitsInstance Is Nothing Then 
            If _CustomerVisitsInstance.PKID=0  Then
                Return Insert()
            ElseIf _CustomerVisitsInstance.PKID > 0 Then
                    Return Update()
                Else
                   _CustomerVisitsInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the CustomerVisitsInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"CustomerVisits_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As CustomerVisitsInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"CustomerVisits_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of CustomerVisitsInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CustomerVisits_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mCustomerVisits As New list(of CustomerVisitsinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mCustomerVisits.Add(TransformDr(dr))
            Next

            Return mCustomerVisits
		
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFLowdocID As String) As CustomerVisitsInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "CustomerVisits_GetInfoByeFLowdocID", eFLowdocID)
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

