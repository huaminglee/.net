#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QC_FileDeleteInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的QC_FileDeleteInfoInfo實例
        ''' </summary>
        ''' <param name="QC_FileDeleteInfoInstance">要操作的QC_FileDeleteInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QC_FileDeleteInfoInstance As QC_FileDeleteInfoInfo)
            _QC_FileDeleteInfoInstance = QC_FileDeleteInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _QC_FileDeleteInfoInstance As QC_FileDeleteInfoInfo

        ''' <summary>
        ''' QC_FileDeleteInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>QC_FileDeleteInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property QC_FileDeleteInfoInstance() As QC_FileDeleteInfoInfo
            Get
                Return _QC_FileDeleteInfoInstance
            End Get
            Set(ByVal Value As QC_FileDeleteInfoInfo)
                _QC_FileDeleteInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_FileDeleteInfo_Update", _
           				QC_FileDeleteInfoInstance.PKID, _
		QC_FileDeleteInfoInstance.RecordNO, _
		QC_FileDeleteInfoInstance.eFlowDocID, _
		QC_FileDeleteInfoInstance.IsFinish, _
		QC_FileDeleteInfoInstance.StateOrder, _
		QC_FileDeleteInfoInstance.StateName, _
		QC_FileDeleteInfoInstance.FileType, _
		QC_FileDeleteInfoInstance.FileName, _
		QC_FileDeleteInfoInstance.FileBH, _
		QC_FileDeleteInfoInstance.FileDept, _
		QC_FileDeleteInfoInstance.DeleteReason, _
		QC_FileDeleteInfoInstance.ApplyUser, _
		QC_FileDeleteInfoInstance.AduitUser, _
		QC_FileDeleteInfoInstance.QuanlityUser, _
		QC_FileDeleteInfoInstance.Extend1, _
		QC_FileDeleteInfoInstance.Extend2, _
		QC_FileDeleteInfoInstance.Extend3, _
		QC_FileDeleteInfoInstance.Extend4, _
		QC_FileDeleteInfoInstance.Extend5, _
		QC_FileDeleteInfoInstance.Extend6, _
		QC_FileDeleteInfoInstance.Extend7, _
		QC_FileDeleteInfoInstance.Extend8, _
		QC_FileDeleteInfoInstance.Extend9, _
		QC_FileDeleteInfoInstance.Extend10, _
		QC_FileDeleteInfoInstance.RecordCreated, _
		QC_FileDeleteInfoInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _QC_FileDeleteInfoInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_FileDeleteInfo_Insert", _
           				QC_FileDeleteInfoInstance.PKID, _
		QC_FileDeleteInfoInstance.RecordNO, _
		QC_FileDeleteInfoInstance.eFlowDocID, _
		QC_FileDeleteInfoInstance.IsFinish, _
		QC_FileDeleteInfoInstance.StateOrder, _
		QC_FileDeleteInfoInstance.StateName, _
		QC_FileDeleteInfoInstance.FileType, _
		QC_FileDeleteInfoInstance.FileName, _
		QC_FileDeleteInfoInstance.FileBH, _
		QC_FileDeleteInfoInstance.FileDept, _
		QC_FileDeleteInfoInstance.DeleteReason, _
		QC_FileDeleteInfoInstance.ApplyUser, _
		QC_FileDeleteInfoInstance.AduitUser, _
		QC_FileDeleteInfoInstance.QuanlityUser, _
		QC_FileDeleteInfoInstance.Extend1, _
		QC_FileDeleteInfoInstance.Extend2, _
		QC_FileDeleteInfoInstance.Extend3, _
		QC_FileDeleteInfoInstance.Extend4, _
		QC_FileDeleteInfoInstance.Extend5, _
		QC_FileDeleteInfoInstance.Extend6, _
		QC_FileDeleteInfoInstance.Extend7, _
		QC_FileDeleteInfoInstance.Extend8, _
		QC_FileDeleteInfoInstance.Extend9, _
		QC_FileDeleteInfoInstance.Extend10, _
		QC_FileDeleteInfoInstance.RecordCreated, _
		QC_FileDeleteInfoInstance.RecordDeleted))
	 	Return  (_QC_FileDeleteInfoInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QC_FileDeleteInfoInfo
		
			 Dim mInfo AS  new QC_FileDeleteInfoInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordNO = IIf(dr.IsNull("RecordNO"), String.Empty, Convert.ToString(dr.Item("RecordNO")))
 			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.FileType = IIf(dr.IsNull("FileType"), String.Empty, Convert.ToString(dr.Item("FileType")))
 			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.FileBH = IIf(dr.IsNull("FileBH"), String.Empty, Convert.ToString(dr.Item("FileBH")))
 			mInfo.FileDept = IIf(dr.IsNull("FileDept"), String.Empty, Convert.ToString(dr.Item("FileDept")))
 			mInfo.DeleteReason = IIf(dr.IsNull("DeleteReason"), String.Empty, Convert.ToString(dr.Item("DeleteReason")))
 			mInfo.ApplyUser = IIf(dr.IsNull("ApplyUser"), String.Empty, Convert.ToString(dr.Item("ApplyUser")))
 			mInfo.AduitUser = IIf(dr.IsNull("AduitUser"), String.Empty, Convert.ToString(dr.Item("AduitUser")))
 			mInfo.QuanlityUser = IIf(dr.IsNull("QuanlityUser"), String.Empty, Convert.ToString(dr.Item("QuanlityUser")))
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
	If Not _QC_FileDeleteInfoInstance Is Nothing Then 
            If _QC_FileDeleteInfoInstance.PKID=0  Then
                Return Insert()
            ElseIf _QC_FileDeleteInfoInstance.PKID > 0 Then
                    Return Update()
                Else
                   _QC_FileDeleteInfoInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the QC_FileDeleteInfoInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"QC_FileDeleteInfo_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QC_FileDeleteInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"QC_FileDeleteInfo_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFlowDocID(ByVal eFlowDocID As String) As QC_FileDeleteInfoInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileDeleteInfo_GetInfoByeFlowDocID", eFlowDocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QC_FileDeleteInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileDeleteInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQC_FileDeleteInfo As New list(of QC_FileDeleteInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQC_FileDeleteInfo.Add(TransformDr(dr))
            Next

            Return mQC_FileDeleteInfo
		
 	End Function
	#End Region
#End Region
End Class

