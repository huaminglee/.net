#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  StandardSearchManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的StandardSearchManageInfo實例
        ''' </summary>
        ''' <param name="StandardSearchManageInstance">要操作的StandardSearchManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal StandardSearchManageInstance As StandardSearchManageInfo)
            _StandardSearchManageInstance = StandardSearchManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _StandardSearchManageInstance As StandardSearchManageInfo

        ''' <summary>
        ''' StandardSearchManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>StandardSearchManageInfo</returns>
        ''' <remarks></remarks>
        Public Property StandardSearchManageInstance() As StandardSearchManageInfo
            Get
                Return _StandardSearchManageInstance
            End Get
            Set(ByVal Value As StandardSearchManageInfo)
                _StandardSearchManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "StandardSearchManage_Update", _
                    StandardSearchManageInstance.PKID, _
       StandardSearchManageInstance.SearchDept, _
       StandardSearchManageInstance.QyLocation, _
       StandardSearchManageInstance.SearchJD, _
       StandardSearchManageInstance.SearchTime, _
       StandardSearchManageInstance.SearchUser, _
       StandardSearchManageInstance.IsHasFile, _
       StandardSearchManageInstance.Remark, _
       StandardSearchManageInstance.Extend1, _
       StandardSearchManageInstance.Extend2, _
       StandardSearchManageInstance.Extend3, _
       StandardSearchManageInstance.Extend4, _
       StandardSearchManageInstance.Extend5, _
       StandardSearchManageInstance.RecordCreated, _
       StandardSearchManageInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _StandardSearchManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "StandardSearchManage_Insert", _
                  StandardSearchManageInstance.PKID, _
     StandardSearchManageInstance.SearchDept, _
     StandardSearchManageInstance.QyLocation, _
     StandardSearchManageInstance.SearchJD, _
     StandardSearchManageInstance.SearchTime, _
     StandardSearchManageInstance.SearchUser, _
     StandardSearchManageInstance.IsHasFile, _
     StandardSearchManageInstance.Remark, _
     StandardSearchManageInstance.Extend1, _
     StandardSearchManageInstance.Extend2, _
     StandardSearchManageInstance.Extend3, _
     StandardSearchManageInstance.Extend4, _
     StandardSearchManageInstance.Extend5, _
     StandardSearchManageInstance.RecordCreated, _
     StandardSearchManageInstance.RecordDeleted))
        Return (_StandardSearchManageInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As StandardSearchManageInfo
		
			 Dim mInfo AS  new StandardSearchManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.SearchDept = IIf(dr.IsNull("SearchDept"), String.Empty, Convert.ToString(dr.Item("SearchDept")))
 			mInfo.QyLocation = IIf(dr.IsNull("QyLocation"), String.Empty, Convert.ToString(dr.Item("QyLocation")))
 			mInfo.SearchJD = IIf(dr.IsNull("SearchJD"), String.Empty, Convert.ToString(dr.Item("SearchJD")))
 			mInfo.SearchTime = IIf(dr.IsNull("SearchTime"), String.Empty, Convert.ToString(dr.Item("SearchTime")))
 			mInfo.SearchUser = IIf(dr.IsNull("SearchUser"), String.Empty, Convert.ToString(dr.Item("SearchUser")))
 			mInfo.IsHasFile = IIf(dr.IsNull("IsHasFile"), 0, Convert.ToInt32(dr.Item("IsHasFile")))
			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
    Public Function Save() As Integer
        If Not _StandardSearchManageInstance Is Nothing Then
            If _StandardSearchManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _StandardSearchManageInstance.PKID > 0 Then
                Return Update()
            Else
                _StandardSearchManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the StandardSearchManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"StandardSearchManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As StandardSearchManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"StandardSearchManage_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of StandardSearchManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardSearchManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mStandardSearchManage As New list(of StandardSearchManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mStandardSearchManage.Add(TransformDr(dr))
            Next

            Return mStandardSearchManage
		
    End Function
    Public Shared Function GetStandsearchBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardSearchManage_GetfileBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardSearchManage_GetDeptBySearchcondition", Searchcondition)
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

