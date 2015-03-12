#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  MarketMemberDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的MarketMemberInfo實例
        ''' </summary>
        ''' <param name="MarketMemberInstance">要操作的MarketMemberInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal MarketMemberInstance As MarketMemberInfo)
            _MarketMemberInstance = MarketMemberInstance
        End Sub
#End Region

#Region "屬性"
        Private _MarketMemberInstance As MarketMemberInfo

        ''' <summary>
        ''' MarketMemberInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>MarketMemberInfo</returns>
        ''' <remarks></remarks>
        Public Property MarketMemberInstance() As MarketMemberInfo
            Get
                Return _MarketMemberInstance
            End Get
            Set(ByVal Value As MarketMemberInfo)
                _MarketMemberInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarketMember_Update", _
           				MarketMemberInstance.PKID, _
		MarketMemberInstance.Type, _
		MarketMemberInstance.PlanPKID, _
		MarketMemberInstance.MemberCategory, _
		MarketMemberInstance.ContactName, _
		MarketMemberInstance.ContactPKID, _
		MarketMemberInstance.CustomerName, _
		MarketMemberInstance.CustomerPKID, _
		MarketMemberInstance.Extend1, _
		MarketMemberInstance.Extend2, _
		MarketMemberInstance.Extend3, _
		MarketMemberInstance.Extend4, _
		MarketMemberInstance.Extend5, _
		MarketMemberInstance.Extend6, _
		MarketMemberInstance.Extend7, _
		MarketMemberInstance.Extend8, _
		MarketMemberInstance.Extend9, _
		MarketMemberInstance.Extend10, _
		MarketMemberInstance.RecordCreated, _
		MarketMemberInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _MarketMemberInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarketMember_Insert", _
           				MarketMemberInstance.PKID, _
		MarketMemberInstance.Type, _
		MarketMemberInstance.PlanPKID, _
		MarketMemberInstance.MemberCategory, _
		MarketMemberInstance.ContactName, _
		MarketMemberInstance.ContactPKID, _
		MarketMemberInstance.CustomerName, _
		MarketMemberInstance.CustomerPKID, _
		MarketMemberInstance.Extend1, _
		MarketMemberInstance.Extend2, _
		MarketMemberInstance.Extend3, _
		MarketMemberInstance.Extend4, _
		MarketMemberInstance.Extend5, _
		MarketMemberInstance.Extend6, _
		MarketMemberInstance.Extend7, _
		MarketMemberInstance.Extend8, _
		MarketMemberInstance.Extend9, _
		MarketMemberInstance.Extend10, _
		MarketMemberInstance.RecordCreated, _
		MarketMemberInstance.RecordDeleted))
	 	Return  (_MarketMemberInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As MarketMemberInfo
		
			 Dim mInfo AS  new MarketMemberInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.Type = IIf(dr.IsNull("Type"), String.Empty, Convert.ToString(dr.Item("Type")))
 			mInfo.PlanPKID = IIf(dr.IsNull("PlanPKID"), 0, Convert.ToInt32(dr.Item("PlanPKID")))
			mInfo.MemberCategory = IIf(dr.IsNull("MemberCategory"), String.Empty, Convert.ToString(dr.Item("MemberCategory")))
 			mInfo.ContactName = IIf(dr.IsNull("ContactName"), String.Empty, Convert.ToString(dr.Item("ContactName")))
 			mInfo.ContactPKID = IIf(dr.IsNull("ContactPKID"), 0, Convert.ToInt32(dr.Item("ContactPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
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
	If Not _MarketMemberInstance Is Nothing Then 
            If _MarketMemberInstance.PKID=0  Then
                Return Insert()
            ElseIf _MarketMemberInstance.PKID > 0 Then
                    Return Update()
                Else
                   _MarketMemberInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the MarketMemberInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"MarketMember_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As MarketMemberInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"MarketMember_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of MarketMemberInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarketMember_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mMarketMember As New list(of MarketMemberinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mMarketMember.Add(TransformDr(dr))
            Next

            Return mMarketMember
		
    End Function
    Public Shared Sub AddMemberForCustomer(ByVal marketplanpkid As Integer, ByVal CustomerPKIDS As String, ByVal CustomerNames As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "MarketMember_AddCustomer", marketplanpkid, CustomerPKIDS, CustomerNames)
    End Sub
	#End Region
#End Region
End Class

