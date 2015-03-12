#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  StandardFileManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的StandardFileManageInfo實例
        ''' </summary>
        ''' <param name="StandardFileManageInstance">要操作的StandardFileManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal StandardFileManageInstance As StandardFileManageInfo)
            _StandardFileManageInstance = StandardFileManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _StandardFileManageInstance As StandardFileManageInfo

        ''' <summary>
        ''' StandardFileManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>StandardFileManageInfo</returns>
        ''' <remarks></remarks>
        Public Property StandardFileManageInstance() As StandardFileManageInfo
            Get
                Return _StandardFileManageInstance
            End Get
            Set(ByVal Value As StandardFileManageInfo)
                _StandardFileManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "StandardFileManage_Update", _
                    StandardFileManageInstance.PKID, _
       StandardFileManageInstance.RecordStype, _
       StandardFileManageInstance.StandardOrganize, _
       StandardFileManageInstance.StandardNumber, _
       StandardFileManageInstance.StandardName, _
       StandardFileManageInstance.StandardVersion, _
       StandardFileManageInstance.StandardDept, _
       StandardFileManageInstance.ApplyUser, _
       StandardFileManageInstance.StandardStatus, _
       StandardFileManageInstance.StandardSaveType, _
       StandardFileManageInstance.QYLocation, _
       StandardFileManageInstance.IsHasFile, _
       StandardFileManageInstance.IsAdditionFile, _
       StandardFileManageInstance.BackUpAddress, _
       StandardFileManageInstance.BuyTime, _
       StandardFileManageInstance.UseFor, _
       StandardFileManageInstance.UseForEquip, _
       StandardFileManageInstance.Remark, _
       StandardFileManageInstance.Extend1, _
       StandardFileManageInstance.Extend2, _
       StandardFileManageInstance.Extend3, _
       StandardFileManageInstance.Extend4, _
       StandardFileManageInstance.Extend5, _
       StandardFileManageInstance.RecordCreated, _
       StandardFileManageInstance.RecordDeleted, _
       StandardFileManageInstance.Zhangshu, _
       StandardFileManageInstance.Fenshu))
        Return Result
    End Function

    Private Function Insert() As Integer
        _StandardFileManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "StandardFileManage_Insert", _
                  StandardFileManageInstance.PKID, _
     StandardFileManageInstance.RecordStype, _
     StandardFileManageInstance.StandardOrganize, _
     StandardFileManageInstance.StandardNumber, _
     StandardFileManageInstance.StandardName, _
     StandardFileManageInstance.StandardVersion, _
     StandardFileManageInstance.StandardDept, _
     StandardFileManageInstance.ApplyUser, _
     StandardFileManageInstance.StandardStatus, _
     StandardFileManageInstance.StandardSaveType, _
     StandardFileManageInstance.QYLocation, _
     StandardFileManageInstance.IsHasFile, _
     StandardFileManageInstance.IsAdditionFile, _
     StandardFileManageInstance.BackUpAddress, _
     StandardFileManageInstance.BuyTime, _
     StandardFileManageInstance.UseFor, _
     StandardFileManageInstance.UseForEquip, _
     StandardFileManageInstance.Remark, _
     StandardFileManageInstance.Extend1, _
     StandardFileManageInstance.Extend2, _
     StandardFileManageInstance.Extend3, _
     StandardFileManageInstance.Extend4, _
     StandardFileManageInstance.Extend5, _
     StandardFileManageInstance.RecordCreated, _
     StandardFileManageInstance.RecordDeleted, _
     StandardFileManageInstance.Zhangshu, _
     StandardFileManageInstance.Fenshu))
        Return (_StandardFileManageInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As StandardFileManageInfo
		
			 Dim mInfo AS  new StandardFileManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordStype = IIf(dr.IsNull("RecordStype"), 0, Convert.ToInt32(dr.Item("RecordStype")))
			mInfo.StandardOrganize = IIf(dr.IsNull("StandardOrganize"), String.Empty, Convert.ToString(dr.Item("StandardOrganize")))
 			mInfo.StandardNumber = IIf(dr.IsNull("StandardNumber"), String.Empty, Convert.ToString(dr.Item("StandardNumber")))
 			mInfo.StandardName = IIf(dr.IsNull("StandardName"), String.Empty, Convert.ToString(dr.Item("StandardName")))
 			mInfo.StandardVersion = IIf(dr.IsNull("StandardVersion"), String.Empty, Convert.ToString(dr.Item("StandardVersion")))
 			mInfo.StandardDept = IIf(dr.IsNull("StandardDept"), String.Empty, Convert.ToString(dr.Item("StandardDept")))
 			mInfo.ApplyUser = IIf(dr.IsNull("ApplyUser"), String.Empty, Convert.ToString(dr.Item("ApplyUser")))
 			mInfo.StandardStatus = IIf(dr.IsNull("StandardStatus"), 0, Convert.ToInt32(dr.Item("StandardStatus")))
			mInfo.StandardSaveType = IIf(dr.IsNull("StandardSaveType"), 0, Convert.ToInt32(dr.Item("StandardSaveType")))
			mInfo.QYLocation = IIf(dr.IsNull("QYLocation"), String.Empty, Convert.ToString(dr.Item("QYLocation")))
 			mInfo.IsHasFile = IIf(dr.IsNull("IsHasFile"), 0, Convert.ToInt32(dr.Item("IsHasFile")))
			mInfo.IsAdditionFile = IIf(dr.IsNull("IsAdditionFile"), 0, Convert.ToInt32(dr.Item("IsAdditionFile")))
			mInfo.BackUpAddress = IIf(dr.IsNull("BackUpAddress"), String.Empty, Convert.ToString(dr.Item("BackUpAddress")))
 			mInfo.BuyTime = IIf(dr.IsNull("BuyTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("BuyTime")))
			mInfo.UseFor = IIf(dr.IsNull("UseFor"), String.Empty, Convert.ToString(dr.Item("UseFor")))
 			mInfo.UseForEquip = IIf(dr.IsNull("UseForEquip"), String.Empty, Convert.ToString(dr.Item("UseForEquip")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
			mInfo.Zhangshu = IIf(dr.IsNull("Zhangshu"), 0, Convert.ToInt32(dr.Item("Zhangshu")))
			mInfo.Fenshu = IIf(dr.IsNull("Fenshu"), 0, Convert.ToInt32(dr.Item("Fenshu")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
    Public Function Save() As Integer
        If Not _StandardFileManageInstance Is Nothing Then
            If _StandardFileManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _StandardFileManageInstance.PKID > 0 Then
                Return Update()
            Else
                _StandardFileManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the StandardFileManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"StandardFileManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As StandardFileManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"StandardFileManage_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of StandardFileManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mStandardFileManage As New list(of StandardFileManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mStandardFileManage.Add(TransformDr(dr))
            Next

            Return mStandardFileManage
		
    End Function
    Public Shared Function GetStandfileByRecordStype(ByVal RecordStype As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetStandfileByRecordStype", RecordStype)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetDeptBysearchcondition(ByVal searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetDeptBySearchcondition", searchcondition)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetQyBysearchcondition(ByVal searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetQyBySearchcondition", searchcondition)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetfileBysearchcondition(ByVal searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetfileBySearchcondition", searchcondition)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetztBysearchcondition(ByVal searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetztBySearchcondition", searchcondition)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
    Public Shared Function GetzzBysearchcondition(ByVal searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "StandardFileManage_GetzzBySearchcondition", searchcondition)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
#End Region
#End Region
End Class

