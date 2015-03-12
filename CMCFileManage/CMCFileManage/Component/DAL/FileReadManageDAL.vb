#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  FileReadManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的FileReadManageInfo實例
        ''' </summary>
        ''' <param name="FileReadManageInstance">要操作的FileReadManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal FileReadManageInstance As FileReadManageInfo)
            _FileReadManageInstance = FileReadManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _FileReadManageInstance As FileReadManageInfo

        ''' <summary>
        ''' FileReadManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>FileReadManageInfo</returns>
        ''' <remarks></remarks>
        Public Property FileReadManageInstance() As FileReadManageInfo
            Get
                Return _FileReadManageInstance
            End Get
            Set(ByVal Value As FileReadManageInfo)
                _FileReadManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "FileReadManage_Update", _
                    FileReadManageInstance.PKID, _
       FileReadManageInstance.eFlowDocID, _
       FileReadManageInstance.IsFinish, _
       FileReadManageInstance.StateOrder, _
       FileReadManageInstance.StateName, _
       FileReadManageInstance.ApplyUser, _
       FileReadManageInstance.ReadDept, _
       FileReadManageInstance.ApplyTime, _
       FileReadManageInstance.UseUserOrDept, _
       FileReadManageInstance.LeaderUser, _
       FileReadManageInstance.Remark, _
       FileReadManageInstance.AduitUser, _
       FileReadManageInstance.AduitTime, _
       FileReadManageInstance.FileHandle, _
       FileReadManageInstance.IsBack, _
       FileReadManageInstance.ApplyConfirmInfo, _
       FileReadManageInstance.DealwithUser, _
       FileReadManageInstance.DealWithTime, _
       FileReadManageInstance.DealRemark, _
       FileReadManageInstance.Extend1, _
       FileReadManageInstance.Extend2, _
       FileReadManageInstance.Extend3, _
       FileReadManageInstance.Extend4, _
       FileReadManageInstance.Extend5, _
       FileReadManageInstance.Extend6, _
       FileReadManageInstance.Extend7, _
       FileReadManageInstance.Extend8, _
       FileReadManageInstance.Extend9, _
       FileReadManageInstance.Extend10, _
       FileReadManageInstance.RecordCreated, _
       FileReadManageInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _FileReadManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "FileReadManage_Insert", _
                  FileReadManageInstance.PKID, _
     FileReadManageInstance.eFlowDocID, _
     FileReadManageInstance.IsFinish, _
     FileReadManageInstance.StateOrder, _
     FileReadManageInstance.StateName, _
     FileReadManageInstance.ApplyUser, _
     FileReadManageInstance.ReadDept, _
     FileReadManageInstance.ApplyTime, _
     FileReadManageInstance.UseUserOrDept, _
     FileReadManageInstance.LeaderUser, _
     FileReadManageInstance.Remark, _
     FileReadManageInstance.AduitUser, _
     FileReadManageInstance.AduitTime, _
     FileReadManageInstance.FileHandle, _
     FileReadManageInstance.IsBack, _
     FileReadManageInstance.ApplyConfirmInfo, _
     FileReadManageInstance.DealwithUser, _
     FileReadManageInstance.DealWithTime, _
     FileReadManageInstance.DealRemark, _
     FileReadManageInstance.Extend1, _
     FileReadManageInstance.Extend2, _
     FileReadManageInstance.Extend3, _
     FileReadManageInstance.Extend4, _
     FileReadManageInstance.Extend5, _
     FileReadManageInstance.Extend6, _
     FileReadManageInstance.Extend7, _
     FileReadManageInstance.Extend8, _
     FileReadManageInstance.Extend9, _
     FileReadManageInstance.Extend10, _
     FileReadManageInstance.RecordCreated, _
     FileReadManageInstance.RecordDeleted))
        Return (_FileReadManageInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As FileReadManageInfo
		
			 Dim mInfo AS  new FileReadManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.ApplyUser = IIf(dr.IsNull("ApplyUser"), String.Empty, Convert.ToString(dr.Item("ApplyUser")))
 			mInfo.ReadDept = IIf(dr.IsNull("ReadDept"), String.Empty, Convert.ToString(dr.Item("ReadDept")))
 			mInfo.ApplyTime = IIf(dr.IsNull("ApplyTime"), String.Empty, Convert.ToString(dr.Item("ApplyTime")))
 			mInfo.UseUserOrDept = IIf(dr.IsNull("UseUserOrDept"), String.Empty, Convert.ToString(dr.Item("UseUserOrDept")))
 			mInfo.LeaderUser = IIf(dr.IsNull("LeaderUser"), String.Empty, Convert.ToString(dr.Item("LeaderUser")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.AduitUser = IIf(dr.IsNull("AduitUser"), String.Empty, Convert.ToString(dr.Item("AduitUser")))
 			mInfo.AduitTime = IIf(dr.IsNull("AduitTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("AduitTime")))
			mInfo.FileHandle = IIf(dr.IsNull("FileHandle"), String.Empty, Convert.ToString(dr.Item("FileHandle")))
 			mInfo.IsBack = IIf(dr.IsNull("IsBack"), 0, Convert.ToInt32(dr.Item("IsBack")))
			mInfo.ApplyConfirmInfo = IIf(dr.IsNull("ApplyConfirmInfo"), String.Empty, Convert.ToString(dr.Item("ApplyConfirmInfo")))
 			mInfo.DealwithUser = IIf(dr.IsNull("DealwithUser"), String.Empty, Convert.ToString(dr.Item("DealwithUser")))
 			mInfo.DealWithTime = IIf(dr.IsNull("DealWithTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("DealWithTime")))
			mInfo.DealRemark = IIf(dr.IsNull("DealRemark"), String.Empty, Convert.ToString(dr.Item("DealRemark")))
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
    Public Function Save() As Integer
        If Not _FileReadManageInstance Is Nothing Then
            If _FileReadManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _FileReadManageInstance.PKID > 0 Then
                Return Update()
            Else
                _FileReadManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the FileReadManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"FileReadManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As FileReadManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"FileReadManage_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFlowDocID(ByVal eFlowDocID As String) As FileReadManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "FileReadManage_GetInfoByeFlowDocID", eFlowDocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of FileReadManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "FileReadManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mFileReadManage As New list(of FileReadManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mFileReadManage.Add(TransformDr(dr))
            Next

            Return mFileReadManage
		
    End Function
    Public Shared Function GetfilereadBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ViewFileRead_GetInfoBySearchCondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetstatenamedBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "FileReadManage_GetstatenameBySearchCondition", Searchcondition)
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

