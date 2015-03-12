#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  MarketingPlanDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的MarketingPlanInfo實例
        ''' </summary>
        ''' <param name="MarketingPlanInstance">要操作的MarketingPlanInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal MarketingPlanInstance As MarketingPlanInfo)
            _MarketingPlanInstance = MarketingPlanInstance
        End Sub
#End Region

#Region "屬性"
        Private _MarketingPlanInstance As MarketingPlanInfo

        ''' <summary>
        ''' MarketingPlanInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>MarketingPlanInfo</returns>
        ''' <remarks></remarks>
        Public Property MarketingPlanInstance() As MarketingPlanInfo
            Get
                Return _MarketingPlanInstance
            End Get
            Set(ByVal Value As MarketingPlanInfo)
                _MarketingPlanInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarketingPlan_Update", _
           				MarketingPlanInstance.PKID, _
		MarketingPlanInstance.InsertPerson, _
		MarketingPlanInstance.Owner, _
		MarketingPlanInstance.MarkPlanName, _
		MarketingPlanInstance.Type, _
		MarketingPlanInstance.Category, _
		MarketingPlanInstance.StartDate, _
		MarketingPlanInstance.ExcepedIncome, _
		MarketingPlanInstance.ActualCosts, _
		MarketingPlanInstance.SendNums, _
		MarketingPlanInstance.IsStarted, _
		MarketingPlanInstance.ResponseNums, _
		MarketingPlanInstance.EndDate, _
		MarketingPlanInstance.BudgetCost, _
		MarketingPlanInstance.ExpectedRePercent, _
		MarketingPlanInstance.Remark, _
		MarketingPlanInstance.Lastchange, _
		MarketingPlanInstance.Extend1, _
		MarketingPlanInstance.Extend2, _
		MarketingPlanInstance.Extend3, _
		MarketingPlanInstance.Extend4, _
		MarketingPlanInstance.Extend5, _
		MarketingPlanInstance.Extend6, _
		MarketingPlanInstance.Extend7, _
		MarketingPlanInstance.Extend8, _
		MarketingPlanInstance.Extend9, _
		MarketingPlanInstance.Extend10, _
		MarketingPlanInstance.Extend11, _
		MarketingPlanInstance.Extend12, _
		MarketingPlanInstance.Extend13, _
		MarketingPlanInstance.Extend14, _
		MarketingPlanInstance.Extend15, _
		MarketingPlanInstance.RecordCreated, _
		MarketingPlanInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _MarketingPlanInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarketingPlan_Insert", _
           				MarketingPlanInstance.PKID, _
		MarketingPlanInstance.InsertPerson, _
		MarketingPlanInstance.Owner, _
		MarketingPlanInstance.MarkPlanName, _
		MarketingPlanInstance.Type, _
		MarketingPlanInstance.Category, _
		MarketingPlanInstance.StartDate, _
		MarketingPlanInstance.ExcepedIncome, _
		MarketingPlanInstance.ActualCosts, _
		MarketingPlanInstance.SendNums, _
		MarketingPlanInstance.IsStarted, _
		MarketingPlanInstance.ResponseNums, _
		MarketingPlanInstance.EndDate, _
		MarketingPlanInstance.BudgetCost, _
		MarketingPlanInstance.ExpectedRePercent, _
		MarketingPlanInstance.Remark, _
		MarketingPlanInstance.Lastchange, _
		MarketingPlanInstance.Extend1, _
		MarketingPlanInstance.Extend2, _
		MarketingPlanInstance.Extend3, _
		MarketingPlanInstance.Extend4, _
		MarketingPlanInstance.Extend5, _
		MarketingPlanInstance.Extend6, _
		MarketingPlanInstance.Extend7, _
		MarketingPlanInstance.Extend8, _
		MarketingPlanInstance.Extend9, _
		MarketingPlanInstance.Extend10, _
		MarketingPlanInstance.Extend11, _
		MarketingPlanInstance.Extend12, _
		MarketingPlanInstance.Extend13, _
		MarketingPlanInstance.Extend14, _
		MarketingPlanInstance.Extend15, _
		MarketingPlanInstance.RecordCreated, _
		MarketingPlanInstance.RecordDeleted))
	 	Return  (_MarketingPlanInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As MarketingPlanInfo
		
			 Dim mInfo AS  new MarketingPlanInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.InsertPerson = IIf(dr.IsNull("InsertPerson"), String.Empty, Convert.ToString(dr.Item("InsertPerson")))
 			mInfo.Owner = IIf(dr.IsNull("Owner"), String.Empty, Convert.ToString(dr.Item("Owner")))
 			mInfo.MarkPlanName = IIf(dr.IsNull("MarkPlanName"), String.Empty, Convert.ToString(dr.Item("MarkPlanName")))
 			mInfo.Type = IIf(dr.IsNull("Type"), String.Empty, Convert.ToString(dr.Item("Type")))
 			mInfo.Category = IIf(dr.IsNull("Category"), String.Empty, Convert.ToString(dr.Item("Category")))
 			mInfo.StartDate = IIf(dr.IsNull("StartDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("StartDate")))
			mInfo.ExcepedIncome = IIf(dr.IsNull("ExcepedIncome"), 0, Convert.ToInt32(dr.Item("ExcepedIncome")))
			mInfo.ActualCosts = IIf(dr.IsNull("ActualCosts"), 0, Convert.ToInt32(dr.Item("ActualCosts")))
			mInfo.SendNums = IIf(dr.IsNull("SendNums"), 0, Convert.ToInt32(dr.Item("SendNums")))
			mInfo.IsStarted = IIf(dr.IsNull("IsStarted"), 0, Convert.ToInt32(dr.Item("IsStarted")))
			mInfo.ResponseNums = IIf(dr.IsNull("ResponseNums"), 0, Convert.ToInt32(dr.Item("ResponseNums")))
			mInfo.EndDate = IIf(dr.IsNull("EndDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndDate")))
			mInfo.BudgetCost = IIf(dr.IsNull("BudgetCost"), 0, Convert.ToInt32(dr.Item("BudgetCost")))
			mInfo.ExpectedRePercent = IIf(dr.IsNull("ExpectedRePercent"), 0, Convert.ToInt32(dr.Item("ExpectedRePercent")))
			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Lastchange = IIf(dr.IsNull("Lastchange"), String.Empty, Convert.ToString(dr.Item("Lastchange")))
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
 			mInfo.Extend11 = IIf(dr.IsNull("Extend11"), String.Empty, Convert.ToString(dr.Item("Extend11")))
 			mInfo.Extend12 = IIf(dr.IsNull("Extend12"), String.Empty, Convert.ToString(dr.Item("Extend12")))
 			mInfo.Extend13 = IIf(dr.IsNull("Extend13"), String.Empty, Convert.ToString(dr.Item("Extend13")))
 			mInfo.Extend14 = IIf(dr.IsNull("Extend14"), String.Empty, Convert.ToString(dr.Item("Extend14")))
 			mInfo.Extend15 = IIf(dr.IsNull("Extend15"), String.Empty, Convert.ToString(dr.Item("Extend15")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _MarketingPlanInstance Is Nothing Then 
            If _MarketingPlanInstance.PKID=0  Then
                Return Insert()
            ElseIf _MarketingPlanInstance.PKID > 0 Then
                    Return Update()
                Else
                   _MarketingPlanInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the MarketingPlanInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"MarketingPlan_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As MarketingPlanInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"MarketingPlan_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of MarketingPlanInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarketingPlan_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mMarketingPlan As New list(of MarketingPlaninfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mMarketingPlan.Add(TransformDr(dr))
            Next

            Return mMarketingPlan
		
    End Function
    Public Shared Function GetAllCanAddMarketPlan(ByVal BusOppPKID As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarketingPlan_GetAllCanAdd", BusOppPKID)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        End If
        Return Nothing
    End Function
	#End Region
#End Region
End Class

