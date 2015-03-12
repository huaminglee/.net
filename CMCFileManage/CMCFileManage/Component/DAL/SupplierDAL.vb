#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  SupplierDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的SupplierInfo實例
        ''' </summary>
        ''' <param name="SupplierInstance">要操作的SupplierInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SupplierInstance As SupplierInfo)
            _SupplierInstance = SupplierInstance
        End Sub
#End Region

#Region "屬性"
        Private _SupplierInstance As SupplierInfo

        ''' <summary>
        ''' SupplierInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>SupplierInfo</returns>
        ''' <remarks></remarks>
        Public Property SupplierInstance() As SupplierInfo
            Get
                Return _SupplierInstance
            End Get
            Set(ByVal Value As SupplierInfo)
                _SupplierInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Supplier_Update", _
           				SupplierInstance.PKID, _
		SupplierInstance.Type, _
		SupplierInstance.eFlowDocID, _
		SupplierInstance.IsFinish, _
		SupplierInstance.StateOrder, _
		SupplierInstance.StateName, _
		SupplierInstance.SupplierName, _
		SupplierInstance.SupplierShortName, _
		SupplierInstance.ContactName, _
		SupplierInstance.ContactPhone, _
		SupplierInstance.Address, _
		SupplierInstance.Industry, _
		SupplierInstance.BelongLab, _
		SupplierInstance.ISOdate, _
		SupplierInstance.BIdate, _
		SupplierInstance.Assessor, _
		SupplierInstance.Status, _
		SupplierInstance.AssessCycle, _
		SupplierInstance.AssessDate, _
		SupplierInstance.AssessResult, _
		SupplierInstance.Remark, _
		SupplierInstance.Extend1, _
		SupplierInstance.Extend2, _
		SupplierInstance.Extend3, _
		SupplierInstance.Extend4, _
		SupplierInstance.Extend5, _
		SupplierInstance.Extend6, _
		SupplierInstance.Extend7, _
		SupplierInstance.Extend8, _
		SupplierInstance.Extend9, _
		SupplierInstance.Extend10, _
		SupplierInstance.RecordCreated, _
		SupplierInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _SupplierInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Supplier_Insert", _
           				SupplierInstance.PKID, _
		SupplierInstance.Type, _
		SupplierInstance.eFlowDocID, _
		SupplierInstance.IsFinish, _
		SupplierInstance.StateOrder, _
		SupplierInstance.StateName, _
		SupplierInstance.SupplierName, _
		SupplierInstance.SupplierShortName, _
		SupplierInstance.ContactName, _
		SupplierInstance.ContactPhone, _
		SupplierInstance.Address, _
		SupplierInstance.Industry, _
		SupplierInstance.BelongLab, _
		SupplierInstance.ISOdate, _
		SupplierInstance.BIdate, _
		SupplierInstance.Assessor, _
		SupplierInstance.Status, _
		SupplierInstance.AssessCycle, _
		SupplierInstance.AssessDate, _
		SupplierInstance.AssessResult, _
		SupplierInstance.Remark, _
		SupplierInstance.Extend1, _
		SupplierInstance.Extend2, _
		SupplierInstance.Extend3, _
		SupplierInstance.Extend4, _
		SupplierInstance.Extend5, _
		SupplierInstance.Extend6, _
		SupplierInstance.Extend7, _
		SupplierInstance.Extend8, _
		SupplierInstance.Extend9, _
		SupplierInstance.Extend10, _
		SupplierInstance.RecordCreated, _
		SupplierInstance.RecordDeleted))
	 	Return  (_SupplierInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As SupplierInfo
		
			 Dim mInfo AS  new SupplierInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.Type = IIf(dr.IsNull("Type"), 0, Convert.ToInt32(dr.Item("Type")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.SupplierName = IIf(dr.IsNull("SupplierName"), String.Empty, Convert.ToString(dr.Item("SupplierName")))
 			mInfo.SupplierShortName = IIf(dr.IsNull("SupplierShortName"), String.Empty, Convert.ToString(dr.Item("SupplierShortName")))
 			mInfo.ContactName = IIf(dr.IsNull("ContactName"), String.Empty, Convert.ToString(dr.Item("ContactName")))
 			mInfo.ContactPhone = IIf(dr.IsNull("ContactPhone"), String.Empty, Convert.ToString(dr.Item("ContactPhone")))
 			mInfo.Address = IIf(dr.IsNull("Address"), String.Empty, Convert.ToString(dr.Item("Address")))
 			mInfo.Industry = IIf(dr.IsNull("Industry"), String.Empty, Convert.ToString(dr.Item("Industry")))
 			mInfo.BelongLab = IIf(dr.IsNull("BelongLab"), String.Empty, Convert.ToString(dr.Item("BelongLab")))
 			mInfo.ISOdate = IIf(dr.IsNull("ISOdate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ISOdate")))
			mInfo.BIdate = IIf(dr.IsNull("BIdate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("BIdate")))
			mInfo.Assessor = IIf(dr.IsNull("Assessor"), String.Empty, Convert.ToString(dr.Item("Assessor")))
 			mInfo.Status = IIf(dr.IsNull("Status"), 0, Convert.ToInt32(dr.Item("Status")))
			mInfo.AssessCycle = IIf(dr.IsNull("AssessCycle"), 0, Convert.ToInt32(dr.Item("AssessCycle")))
			mInfo.AssessDate = IIf(dr.IsNull("AssessDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("AssessDate")))
			mInfo.AssessResult = IIf(dr.IsNull("AssessResult"), String.Empty, Convert.ToString(dr.Item("AssessResult")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
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
	If Not _SupplierInstance Is Nothing Then 
            If _SupplierInstance.PKID=0  Then
                Return Insert()
            ElseIf _SupplierInstance.PKID > 0 Then
                    Return Update()
                Else
                   _SupplierInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the SupplierInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Supplier_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As SupplierInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Supplier_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of SupplierInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Supplier_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mSupplier As New list(of Supplierinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mSupplier.Add(TransformDr(dr))
            Next

            Return mSupplier
		
    End Function
    Public Shared Function GetInfoByeFlowDocID(ByVal eFlowDocId As String) As SupplierInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Supplier_GetInfoByeFlowDocID", eFlowDocId)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetsupplierBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Supplier_GetfileBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Supplier_GetDeptBySearchcondition", Searchcondition)
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

