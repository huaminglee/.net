#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  BuinessOpportunntitesDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的BuinessOpportunntitesInfo實例
        ''' </summary>
        ''' <param name="BuinessOpportunntitesInstance">要操作的BuinessOpportunntitesInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BuinessOpportunntitesInstance As BuinessOpportunntitesInfo)
            _BuinessOpportunntitesInstance = BuinessOpportunntitesInstance
        End Sub
#End Region

#Region "屬性"
        Private _BuinessOpportunntitesInstance As BuinessOpportunntitesInfo

        ''' <summary>
        ''' BuinessOpportunntitesInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>BuinessOpportunntitesInfo</returns>
        ''' <remarks></remarks>
        Public Property BuinessOpportunntitesInstance() As BuinessOpportunntitesInfo
            Get
                Return _BuinessOpportunntitesInstance
            End Get
            Set(ByVal Value As BuinessOpportunntitesInfo)
                _BuinessOpportunntitesInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "BuinessOpportunntites_Update", _
           				BuinessOpportunntitesInstance.PKID, _
		BuinessOpportunntitesInstance.OpportName, _
		BuinessOpportunntitesInstance.InserPerson, _
		BuinessOpportunntitesInstance.OppOwoner, _
		BuinessOpportunntitesInstance.LastChange, _
		BuinessOpportunntitesInstance.Amounts, _
		BuinessOpportunntitesInstance.CustomerName, _
		BuinessOpportunntitesInstance.Type, _
		BuinessOpportunntitesInstance.Category, _
		BuinessOpportunntitesInstance.CustomerSources, _
		BuinessOpportunntitesInstance.ExcepedIncome, _
		BuinessOpportunntitesInstance.Possibility, _
		BuinessOpportunntitesInstance.Remark, _
		BuinessOpportunntitesInstance.EndDate, _
		BuinessOpportunntitesInstance.Extend1, _
		BuinessOpportunntitesInstance.Extend2, _
		BuinessOpportunntitesInstance.Extend3, _
		BuinessOpportunntitesInstance.Extend4, _
		BuinessOpportunntitesInstance.Extend5, _
		BuinessOpportunntitesInstance.Extend6, _
		BuinessOpportunntitesInstance.Extend7, _
		BuinessOpportunntitesInstance.Extend8, _
		BuinessOpportunntitesInstance.Extend9, _
		BuinessOpportunntitesInstance.Extend10, _
		BuinessOpportunntitesInstance.RecordCreated, _
		BuinessOpportunntitesInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _BuinessOpportunntitesInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "BuinessOpportunntites_Insert", _
           				BuinessOpportunntitesInstance.PKID, _
		BuinessOpportunntitesInstance.OpportName, _
		BuinessOpportunntitesInstance.InserPerson, _
		BuinessOpportunntitesInstance.OppOwoner, _
		BuinessOpportunntitesInstance.LastChange, _
		BuinessOpportunntitesInstance.Amounts, _
		BuinessOpportunntitesInstance.CustomerName, _
		BuinessOpportunntitesInstance.Type, _
		BuinessOpportunntitesInstance.Category, _
		BuinessOpportunntitesInstance.CustomerSources, _
		BuinessOpportunntitesInstance.ExcepedIncome, _
		BuinessOpportunntitesInstance.Possibility, _
		BuinessOpportunntitesInstance.Remark, _
		BuinessOpportunntitesInstance.EndDate, _
		BuinessOpportunntitesInstance.Extend1, _
		BuinessOpportunntitesInstance.Extend2, _
		BuinessOpportunntitesInstance.Extend3, _
		BuinessOpportunntitesInstance.Extend4, _
		BuinessOpportunntitesInstance.Extend5, _
		BuinessOpportunntitesInstance.Extend6, _
		BuinessOpportunntitesInstance.Extend7, _
		BuinessOpportunntitesInstance.Extend8, _
		BuinessOpportunntitesInstance.Extend9, _
		BuinessOpportunntitesInstance.Extend10, _
		BuinessOpportunntitesInstance.RecordCreated, _
		BuinessOpportunntitesInstance.RecordDeleted))
	 	Return  (_BuinessOpportunntitesInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As BuinessOpportunntitesInfo
		
			 Dim mInfo AS  new BuinessOpportunntitesInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.OpportName = IIf(dr.IsNull("OpportName"), String.Empty, Convert.ToString(dr.Item("OpportName")))
 			mInfo.InserPerson = IIf(dr.IsNull("InserPerson"), String.Empty, Convert.ToString(dr.Item("InserPerson")))
 			mInfo.OppOwoner = IIf(dr.IsNull("OppOwoner"), String.Empty, Convert.ToString(dr.Item("OppOwoner")))
 			mInfo.LastChange = IIf(dr.IsNull("LastChange"), String.Empty, Convert.ToString(dr.Item("LastChange")))
 			mInfo.Amounts = IIf(dr.IsNull("Amounts"), 0, Convert.ToInt32(dr.Item("Amounts")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.Type = IIf(dr.IsNull("Type"), String.Empty, Convert.ToString(dr.Item("Type")))
 			mInfo.Category = IIf(dr.IsNull("Category"), String.Empty, Convert.ToString(dr.Item("Category")))
 			mInfo.CustomerSources = IIf(dr.IsNull("CustomerSources"), String.Empty, Convert.ToString(dr.Item("CustomerSources")))
 			mInfo.ExcepedIncome = IIf(dr.IsNull("ExcepedIncome"), 0, Convert.ToInt32(dr.Item("ExcepedIncome")))
			mInfo.Possibility = IIf(dr.IsNull("Possibility"), 0, Convert.ToInt32(dr.Item("Possibility")))
			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.EndDate = IIf(dr.IsNull("EndDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndDate")))
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
	If Not _BuinessOpportunntitesInstance Is Nothing Then 
            If _BuinessOpportunntitesInstance.PKID=0  Then
                Return Insert()
            ElseIf _BuinessOpportunntitesInstance.PKID > 0 Then
                    Return Update()
                Else
                   _BuinessOpportunntitesInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the BuinessOpportunntitesInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"BuinessOpportunntites_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As BuinessOpportunntitesInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"BuinessOpportunntites_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of BuinessOpportunntitesInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "BuinessOpportunntites_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mBuinessOpportunntites As New list(of BuinessOpportunntitesinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mBuinessOpportunntites.Add(TransformDr(dr))
            Next

            Return mBuinessOpportunntites
		
    End Function
    Public Shared Function GetAllCanAddBussByMarkplanpkid(ByVal markplanpkid As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "BuinessOpportunntites_GetAllCanAddBussByMarkplanpkid", markplanpkid)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        End If
        Return Nothing
    End Function
	#End Region
#End Region
End Class

