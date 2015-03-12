#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  EquipManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的EquipManageInfo實例
        ''' </summary>
        ''' <param name="EquipManageInstance">要操作的EquipManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal EquipManageInstance As EquipManageInfo)
            _EquipManageInstance = EquipManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _EquipManageInstance As EquipManageInfo

        ''' <summary>
        ''' EquipManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>EquipManageInfo</returns>
        ''' <remarks></remarks>
        Public Property EquipManageInstance() As EquipManageInfo
            Get
                Return _EquipManageInstance
            End Get
            Set(ByVal Value As EquipManageInfo)
                _EquipManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "EquipManage_Update", _
                    EquipManageInstance.PKID, _
       EquipManageInstance.eFlowDocID, _
       EquipManageInstance.IsFinish, _
       EquipManageInstance.StateOrder, _
       EquipManageInstance.StateName, _
       EquipManageInstance.EquipName, _
       EquipManageInstance.ControlNO, _
       EquipManageInstance.ManuFacturer, _
       EquipManageInstance.EquipModel, _
       EquipManageInstance.Specification, _
       EquipManageInstance.EquipDept, _
       EquipManageInstance.QyLocation, _
       EquipManageInstance.EquipLocation, _
       EquipManageInstance.KeepUser, _
       EquipManageInstance.IsHasDetail, _
       EquipManageInstance.Remark, _
       EquipManageInstance.IsHasFile, _
       EquipManageInstance.Extend1, _
       EquipManageInstance.Extend2, _
       EquipManageInstance.Extend3, _
       EquipManageInstance.Extend4, _
       EquipManageInstance.Extend5, _
       EquipManageInstance.RecordCreated, _
       EquipManageInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _EquipManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "EquipManage_Insert", _
                  EquipManageInstance.PKID, _
     EquipManageInstance.eFlowDocID, _
     EquipManageInstance.IsFinish, _
     EquipManageInstance.StateOrder, _
     EquipManageInstance.StateName, _
     EquipManageInstance.EquipName, _
     EquipManageInstance.ControlNO, _
     EquipManageInstance.ManuFacturer, _
     EquipManageInstance.EquipModel, _
     EquipManageInstance.Specification, _
     EquipManageInstance.EquipDept, _
     EquipManageInstance.QyLocation, _
     EquipManageInstance.EquipLocation, _
     EquipManageInstance.KeepUser, _
     EquipManageInstance.IsHasDetail, _
     EquipManageInstance.Remark, _
     EquipManageInstance.IsHasFile, _
     EquipManageInstance.Extend1, _
     EquipManageInstance.Extend2, _
     EquipManageInstance.Extend3, _
     EquipManageInstance.Extend4, _
     EquipManageInstance.Extend5, _
     EquipManageInstance.RecordCreated, _
     EquipManageInstance.RecordDeleted))
        Return (_EquipManageInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As EquipManageInfo
		
			 Dim mInfo AS  new EquipManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.EquipName = IIf(dr.IsNull("EquipName"), String.Empty, Convert.ToString(dr.Item("EquipName")))
 			mInfo.ControlNO = IIf(dr.IsNull("ControlNO"), String.Empty, Convert.ToString(dr.Item("ControlNO")))
 			mInfo.ManuFacturer = IIf(dr.IsNull("ManuFacturer"), String.Empty, Convert.ToString(dr.Item("ManuFacturer")))
 			mInfo.EquipModel = IIf(dr.IsNull("EquipModel"), String.Empty, Convert.ToString(dr.Item("EquipModel")))
 			mInfo.Specification = IIf(dr.IsNull("Specification"), String.Empty, Convert.ToString(dr.Item("Specification")))
 			mInfo.EquipDept = IIf(dr.IsNull("EquipDept"), String.Empty, Convert.ToString(dr.Item("EquipDept")))
 			mInfo.QyLocation = IIf(dr.IsNull("QyLocation"), String.Empty, Convert.ToString(dr.Item("QyLocation")))
 			mInfo.EquipLocation = IIf(dr.IsNull("EquipLocation"), String.Empty, Convert.ToString(dr.Item("EquipLocation")))
 			mInfo.KeepUser = IIf(dr.IsNull("KeepUser"), String.Empty, Convert.ToString(dr.Item("KeepUser")))
 			mInfo.IsHasDetail = IIf(dr.IsNull("IsHasDetail"), 0, Convert.ToInt32(dr.Item("IsHasDetail")))
			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.IsHasFile = IIf(dr.IsNull("IsHasFile"), 0, Convert.ToInt32(dr.Item("IsHasFile")))
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
        If Not _EquipManageInstance Is Nothing Then
            If _EquipManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _EquipManageInstance.PKID > 0 Then
                Return Update()
            Else
                _EquipManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the EquipManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"EquipManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As EquipManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"EquipManage_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFlowDocID(ByVal eFlowDocID As String) As EquipManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetInfoByeFlowDocID", eFlowDocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of EquipManageInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetnnnBySearchCondition", SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mEquipManage As New list(of EquipManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mEquipManage.Add(TransformDr(dr))
            Next

            Return mEquipManage
		
    End Function
    Public Shared Function GetEquipInfoByControlNOandQy(ByVal ControlNo As String, ByVal qy As String) As EquipManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetInfoByControlNo", ControlNo, qy)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetEquipInfoByEquipNameandqy(ByVal EquipName As String, ByVal qy As String) As EquipManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetInfoByEquipName", EquipName, qy)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetDeptBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetQyBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetQyBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetEquipBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipManage_GetEquipBySearchcondition", Searchcondition)
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

