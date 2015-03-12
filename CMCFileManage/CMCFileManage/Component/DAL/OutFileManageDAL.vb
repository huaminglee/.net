#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  OutFileManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的OutFileManageInfo實例
        ''' </summary>
        ''' <param name="OutFileManageInstance">要操作的OutFileManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal OutFileManageInstance As OutFileManageInfo)
            _OutFileManageInstance = OutFileManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _OutFileManageInstance As OutFileManageInfo

        ''' <summary>
        ''' OutFileManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>OutFileManageInfo</returns>
        ''' <remarks></remarks>
        Public Property OutFileManageInstance() As OutFileManageInfo
            Get
                Return _OutFileManageInstance
            End Get
            Set(ByVal Value As OutFileManageInfo)
                _OutFileManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "OutFileManage_Update", _
                    OutFileManageInstance.PKID, _
       OutFileManageInstance.RecordStype, _
       OutFileManageInstance.eFlowDocID, _
       OutFileManageInstance.IsFinish, _
       OutFileManageInstance.StateOrder, _
       OutFileManageInstance.StateName, _
       OutFileManageInstance.FileBH, _
       OutFileManageInstance.FileName, _
       OutFileManageInstance.FileVersion, _
       OutFileManageInstance.FilePageNum, _
       OutFileManageInstance.FileNum, _
       OutFileManageInstance.UseFor, _
       OutFileManageInstance.UseForEquip, _
       OutFileManageInstance.FileSource, _
       OutFileManageInstance.QyLocation, _
       OutFileManageInstance.FileDept, _
       OutFileManageInstance.BuyTime, _
       OutFileManageInstance.BackAddress, _
       OutFileManageInstance.Remark, _
       OutFileManageInstance.SaveType, _
       OutFileManageInstance.IsHasFile, _
       OutFileManageInstance.Extend1, _
       OutFileManageInstance.Extend2, _
       OutFileManageInstance.Extend3, _
       OutFileManageInstance.Extend4, _
       OutFileManageInstance.Extend5, _
       OutFileManageInstance.Extend6, _
       OutFileManageInstance.Extend7, _
       OutFileManageInstance.Extend8, _
       OutFileManageInstance.Extend9, _
       OutFileManageInstance.Extend10, _
       OutFileManageInstance.RecordCreated, _
       OutFileManageInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _OutFileManageInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "OutFileManage_Insert", _
                  OutFileManageInstance.PKID, _
     OutFileManageInstance.RecordStype, _
     OutFileManageInstance.eFlowDocID, _
     OutFileManageInstance.IsFinish, _
     OutFileManageInstance.StateOrder, _
     OutFileManageInstance.StateName, _
     OutFileManageInstance.FileBH, _
     OutFileManageInstance.FileName, _
     OutFileManageInstance.FileVersion, _
     OutFileManageInstance.FilePageNum, _
     OutFileManageInstance.FileNum, _
     OutFileManageInstance.UseFor, _
     OutFileManageInstance.UseForEquip, _
     OutFileManageInstance.FileSource, _
     OutFileManageInstance.QyLocation, _
     OutFileManageInstance.FileDept, _
     OutFileManageInstance.BuyTime, _
     OutFileManageInstance.BackAddress, _
     OutFileManageInstance.Remark, _
     OutFileManageInstance.SaveType, _
     OutFileManageInstance.IsHasFile, _
     OutFileManageInstance.Extend1, _
     OutFileManageInstance.Extend2, _
     OutFileManageInstance.Extend3, _
     OutFileManageInstance.Extend4, _
     OutFileManageInstance.Extend5, _
     OutFileManageInstance.Extend6, _
     OutFileManageInstance.Extend7, _
     OutFileManageInstance.Extend8, _
     OutFileManageInstance.Extend9, _
     OutFileManageInstance.Extend10, _
     OutFileManageInstance.RecordCreated, _
     OutFileManageInstance.RecordDeleted))
        Return (_OutFileManageInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As OutFileManageInfo
		
			 Dim mInfo AS  new OutFileManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordStype = IIf(dr.IsNull("RecordStype"), 0, Convert.ToInt32(dr.Item("RecordStype")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.FileBH = IIf(dr.IsNull("FileBH"), String.Empty, Convert.ToString(dr.Item("FileBH")))
 			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.FileVersion = IIf(dr.IsNull("FileVersion"), String.Empty, Convert.ToString(dr.Item("FileVersion")))
 			mInfo.FilePageNum = IIf(dr.IsNull("FilePageNum"), 0, Convert.ToInt32(dr.Item("FilePageNum")))
			mInfo.FileNum = IIf(dr.IsNull("FileNum"), 0, Convert.ToInt32(dr.Item("FileNum")))
			mInfo.UseFor = IIf(dr.IsNull("UseFor"), String.Empty, Convert.ToString(dr.Item("UseFor")))
 			mInfo.UseForEquip = IIf(dr.IsNull("UseForEquip"), String.Empty, Convert.ToString(dr.Item("UseForEquip")))
 			mInfo.FileSource = IIf(dr.IsNull("FileSource"), String.Empty, Convert.ToString(dr.Item("FileSource")))
 			mInfo.QyLocation = IIf(dr.IsNull("QyLocation"), String.Empty, Convert.ToString(dr.Item("QyLocation")))
 			mInfo.FileDept = IIf(dr.IsNull("FileDept"), String.Empty, Convert.ToString(dr.Item("FileDept")))
 			mInfo.BuyTime = IIf(dr.IsNull("BuyTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("BuyTime")))
			mInfo.BackAddress = IIf(dr.IsNull("BackAddress"), String.Empty, Convert.ToString(dr.Item("BackAddress")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.SaveType = IIf(dr.IsNull("SaveType"), 0, Convert.ToInt32(dr.Item("SaveType")))
			mInfo.IsHasFile = IIf(dr.IsNull("IsHasFile"), 0, Convert.ToInt32(dr.Item("IsHasFile")))
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
        If Not _OutFileManageInstance Is Nothing Then
            If _OutFileManageInstance.PKID = 0 Then
                Return Insert()
            ElseIf _OutFileManageInstance.PKID > 0 Then
                Return Update()
            Else
                _OutFileManageInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the OutFileManageInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"OutFileManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As OutFileManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"OutFileManage_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFlowDocID(ByVal eFlowDocOD As String) As OutFileManageInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "OutFileManage_GetInfoByeFlowDocOD", eFlowDocOD)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of OutFileManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "OutFileManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mOutFileManage As New list(of OutFileManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mOutFileManage.Add(TransformDr(dr))
            Next

            Return mOutFileManage
		
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondotion As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "OutFileManage_GetDeptBysearchcondition", Searchcondotion)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            Return dt
        End If
    End Function
    Public Shared Function GetQuBySearchcondition(ByVal Searchcondotion As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "OutFileManage_GetQyBysearchcondition", Searchcondotion)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            Return dt
        End If
    End Function
    Public Shared Function GetfileBySearchcondition(ByVal Searchcondotion As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "OutFileManage_GetfileBysearchcondition", Searchcondotion)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            Return dt
        End If
    End Function
	#End Region
#End Region
End Class

