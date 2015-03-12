#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QC_FileInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的QC_FileInfoInfo實例
        ''' </summary>
        ''' <param name="QC_FileInfoInstance">要操作的QC_FileInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QC_FileInfoInstance As QC_FileInfoInfo)
            _QC_FileInfoInstance = QC_FileInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _QC_FileInfoInstance As QC_FileInfoInfo

        ''' <summary>
        ''' QC_FileInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>QC_FileInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property QC_FileInfoInstance() As QC_FileInfoInfo
            Get
                Return _QC_FileInfoInstance
            End Get
            Set(ByVal Value As QC_FileInfoInfo)
                _QC_FileInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "QC_FileInfo_Update", _
                    QC_FileInfoInstance.PKID, _
       QC_FileInfoInstance.RecordNO, _
       QC_FileInfoInstance.eFlowDocID, _
       QC_FileInfoInstance.IsFinish, _
       QC_FileInfoInstance.StateOrder, _
       QC_FileInfoInstance.StateName, _
       QC_FileInfoInstance.NeedAround, _
       QC_FileInfoInstance.ApplyDept, _
       QC_FileInfoInstance.ApplyUser, _
       QC_FileInfoInstance.ApplyDate, _
       QC_FileInfoInstance.FileVersion, _
       QC_FileInfoInstance.ToTalPage, _
       QC_FileInfoInstance.FileName, _
       QC_FileInfoInstance.FileLayer, _
       QC_FileInfoInstance.FileCategory, _
       QC_FileInfoInstance.ISO, _
       QC_FileInfoInstance.FileBH, _
       QC_FileInfoInstance.ChangeReason, _
       QC_FileInfoInstance.ChangePreDes, _
       QC_FileInfoInstance.ChangeBehDes, _
       QC_FileInfoInstance.LabTechniqueCharge, _
       QC_FileInfoInstance.CounterSignType, _
       QC_FileInfoInstance.SendDept, _
       QC_FileInfoInstance.SendNum, _
       QC_FileInfoInstance.SendPaperNums, _
       QC_FileInfoInstance.IsTeach, _
       QC_FileInfoInstance.TeachDept, _
       QC_FileInfoInstance.EffectDate, _
       QC_FileInfoInstance.IsPdf, _
       QC_FileInfoInstance.Isexecl, _
       QC_FileInfoInstance.CenterTechniqueCharge, _
       QC_FileInfoInstance.CenterQuantityCharge, _
       QC_FileInfoInstance.HighManager, _
       QC_FileInfoInstance.QualityFinishUser, _
       QC_FileInfoInstance.IsChange, _
       QC_FileInfoInstance.BackDept, _
       QC_FileInfoInstance.BackSum, _
       QC_FileInfoInstance.RecordType, _
       QC_FileInfoInstance.FileStatus, _
       QC_FileInfoInstance.Extend1, _
       QC_FileInfoInstance.Extend2, _
       QC_FileInfoInstance.Extend3, _
       QC_FileInfoInstance.Extend4, _
       QC_FileInfoInstance.Extend5, _
       QC_FileInfoInstance.Extend6, _
       QC_FileInfoInstance.Extend7, _
       QC_FileInfoInstance.Extend8, _
       QC_FileInfoInstance.Extend9, _
       QC_FileInfoInstance.Extend10, _
       QC_FileInfoInstance.RecordCreated, _
       QC_FileInfoInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _QC_FileInfoInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "QC_FileInfo_Insert", _
                  QC_FileInfoInstance.PKID, _
     QC_FileInfoInstance.RecordNO, _
     QC_FileInfoInstance.eFlowDocID, _
     QC_FileInfoInstance.IsFinish, _
     QC_FileInfoInstance.StateOrder, _
     QC_FileInfoInstance.StateName, _
     QC_FileInfoInstance.NeedAround, _
     QC_FileInfoInstance.ApplyDept, _
     QC_FileInfoInstance.ApplyUser, _
     QC_FileInfoInstance.ApplyDate, _
     QC_FileInfoInstance.FileVersion, _
     QC_FileInfoInstance.ToTalPage, _
     QC_FileInfoInstance.FileName, _
     QC_FileInfoInstance.FileLayer, _
     QC_FileInfoInstance.FileCategory, _
     QC_FileInfoInstance.ISO, _
     QC_FileInfoInstance.FileBH, _
     QC_FileInfoInstance.ChangeReason, _
     QC_FileInfoInstance.ChangePreDes, _
     QC_FileInfoInstance.ChangeBehDes, _
     QC_FileInfoInstance.LabTechniqueCharge, _
     QC_FileInfoInstance.CounterSignType, _
     QC_FileInfoInstance.SendDept, _
     QC_FileInfoInstance.SendNum, _
     QC_FileInfoInstance.SendPaperNums, _
     QC_FileInfoInstance.IsTeach, _
     QC_FileInfoInstance.TeachDept, _
     QC_FileInfoInstance.EffectDate, _
     QC_FileInfoInstance.IsPdf, _
     QC_FileInfoInstance.Isexecl, _
     QC_FileInfoInstance.CenterTechniqueCharge, _
     QC_FileInfoInstance.CenterQuantityCharge, _
     QC_FileInfoInstance.HighManager, _
     QC_FileInfoInstance.QualityFinishUser, _
     QC_FileInfoInstance.IsChange, _
     QC_FileInfoInstance.BackDept, _
     QC_FileInfoInstance.BackSum, _
     QC_FileInfoInstance.RecordType, _
     QC_FileInfoInstance.FileStatus, _
     QC_FileInfoInstance.Extend1, _
     QC_FileInfoInstance.Extend2, _
     QC_FileInfoInstance.Extend3, _
     QC_FileInfoInstance.Extend4, _
     QC_FileInfoInstance.Extend5, _
     QC_FileInfoInstance.Extend6, _
     QC_FileInfoInstance.Extend7, _
     QC_FileInfoInstance.Extend8, _
     QC_FileInfoInstance.Extend9, _
     QC_FileInfoInstance.Extend10, _
     QC_FileInfoInstance.RecordCreated, _
     QC_FileInfoInstance.RecordDeleted))
        Return (_QC_FileInfoInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QC_FileInfoInfo
		
			 Dim mInfo AS  new QC_FileInfoInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordNO = IIf(dr.IsNull("RecordNO"), String.Empty, Convert.ToString(dr.Item("RecordNO")))
 			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.NeedAround = IIf(dr.IsNull("NeedAround"), 0, Convert.ToInt32(dr.Item("NeedAround")))
			mInfo.ApplyDept = IIf(dr.IsNull("ApplyDept"), String.Empty, Convert.ToString(dr.Item("ApplyDept")))
 			mInfo.ApplyUser = IIf(dr.IsNull("ApplyUser"), String.Empty, Convert.ToString(dr.Item("ApplyUser")))
 			mInfo.ApplyDate = IIf(dr.IsNull("ApplyDate"), String.Empty, Convert.ToString(dr.Item("ApplyDate")))
 			mInfo.FileVersion = IIf(dr.IsNull("FileVersion"), String.Empty, Convert.ToString(dr.Item("FileVersion")))
 			mInfo.ToTalPage = IIf(dr.IsNull("ToTalPage"), 0, Convert.ToInt32(dr.Item("ToTalPage")))
			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.FileLayer = IIf(dr.IsNull("FileLayer"), String.Empty, Convert.ToString(dr.Item("FileLayer")))
 			mInfo.FileCategory = IIf(dr.IsNull("FileCategory"), String.Empty, Convert.ToString(dr.Item("FileCategory")))
 			mInfo.ISO = IIf(dr.IsNull("ISO"), String.Empty, Convert.ToString(dr.Item("ISO")))
 			mInfo.FileBH = IIf(dr.IsNull("FileBH"), String.Empty, Convert.ToString(dr.Item("FileBH")))
 			mInfo.ChangeReason = IIf(dr.IsNull("ChangeReason"), String.Empty, Convert.ToString(dr.Item("ChangeReason")))
 			mInfo.ChangePreDes = IIf(dr.IsNull("ChangePreDes"), String.Empty, Convert.ToString(dr.Item("ChangePreDes")))
 			mInfo.ChangeBehDes = IIf(dr.IsNull("ChangeBehDes"), String.Empty, Convert.ToString(dr.Item("ChangeBehDes")))
 			mInfo.LabTechniqueCharge = IIf(dr.IsNull("LabTechniqueCharge"), String.Empty, Convert.ToString(dr.Item("LabTechniqueCharge")))
 			mInfo.CounterSignType = IIf(dr.IsNull("CounterSignType"), 0, Convert.ToInt32(dr.Item("CounterSignType")))
			mInfo.SendDept = IIf(dr.IsNull("SendDept"), 0, Convert.ToInt32(dr.Item("SendDept")))
			mInfo.SendNum = IIf(dr.IsNull("SendNum"), String.Empty, Convert.ToString(dr.Item("SendNum")))
 			mInfo.SendPaperNums = IIf(dr.IsNull("SendPaperNums"), 0, Convert.ToInt32(dr.Item("SendPaperNums")))
			mInfo.IsTeach = IIf(dr.IsNull("IsTeach"), 0, Convert.ToInt32(dr.Item("IsTeach")))
			mInfo.TeachDept = IIf(dr.IsNull("TeachDept"), String.Empty, Convert.ToString(dr.Item("TeachDept")))
 			mInfo.EffectDate = IIf(dr.IsNull("EffectDate"), String.Empty, Convert.ToString(dr.Item("EffectDate")))
 			mInfo.IsPdf = IIf(dr.IsNull("IsPdf"), 0, Convert.ToInt32(dr.Item("IsPdf")))
			mInfo.Isexecl = IIf(dr.IsNull("Isexecl"), 0, Convert.ToInt32(dr.Item("Isexecl")))
			mInfo.CenterTechniqueCharge = IIf(dr.IsNull("CenterTechniqueCharge"), String.Empty, Convert.ToString(dr.Item("CenterTechniqueCharge")))
 			mInfo.CenterQuantityCharge = IIf(dr.IsNull("CenterQuantityCharge"), String.Empty, Convert.ToString(dr.Item("CenterQuantityCharge")))
 			mInfo.HighManager = IIf(dr.IsNull("HighManager"), String.Empty, Convert.ToString(dr.Item("HighManager")))
 			mInfo.QualityFinishUser = IIf(dr.IsNull("QualityFinishUser"), String.Empty, Convert.ToString(dr.Item("QualityFinishUser")))
 			mInfo.IsChange = IIf(dr.IsNull("IsChange"), 0, Convert.ToInt32(dr.Item("IsChange")))
			mInfo.BackDept = IIf(dr.IsNull("BackDept"), 0, Convert.ToInt32(dr.Item("BackDept")))
			mInfo.BackSum = IIf(dr.IsNull("BackSum"), String.Empty, Convert.ToString(dr.Item("BackSum")))
 			mInfo.RecordType = IIf(dr.IsNull("RecordType"), 0, Convert.ToInt32(dr.Item("RecordType")))
			mInfo.FileStatus = IIf(dr.IsNull("FileStatus"), 0, Convert.ToInt32(dr.Item("FileStatus")))
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
        If Not _QC_FileInfoInstance Is Nothing Then
            If _QC_FileInfoInstance.PKID = 0 Then
                Return Insert()
            ElseIf _QC_FileInfoInstance.PKID > 0 Then
                Return Update()
            Else
                _QC_FileInfoInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the QC_FileInfoInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"QC_FileInfo_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QC_FileInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"QC_FileInfo_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFlowdocID As String) As QC_FileInfoInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_GetInfoByeFLowdocID", eFlowdocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QC_FileInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQC_FileInfo As New list(of QC_FileInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQC_FileInfo.Add(TransformDr(dr))
            Next

            Return mQC_FileInfo
		
    End Function
    Public Shared Function GetReadFileInfoList() As List(Of DictionaryEntry)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetReadFileInfoList")

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("FileName"), dr.Item("FileBH")))
        Next
        Return mList
    End Function
    Public Shared Function GetReadFileInfoListall(ByVal ApplyDept As String, ByVal FileLayer As String) As List(Of DictionaryEntry)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetReadFileInfoListall", ApplyDept, FileLayer)

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("FileName"), dr.Item("FileBH")))
        Next
        Return mList
    End Function
    Public Shared Function GetInfoByeFileBH(ByVal FileBH As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_GetInfoByeFileBH", FileBH)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If



        Return dt
    End Function
    Public Shared Function Get34dsByeFileName(ByVal FileName As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_Get34InfoByeFileName", FileName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetReadFileBySearchcondition(ByVal Searchcondotion As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_GetInfoBySearchCondition", Searchcondotion)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetALL34File() As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_FileInfo_GetAll34File")
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function QC_fILE_GetFilelayerByApplyDept(ByVal ApplyDept As String) As String
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_fILE_GetFilelayerByApplyDept", ApplyDept)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim filelayers As StringBuilder = New StringBuilder()
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            filelayers.Append(dr.Item("FileLayer") + ",")
        Next
        Return filelayers.ToString.Substring(0, filelayers.Length - 1)
    End Function
    Public Shared Sub QC_FileUpFileStatus(ByVal pkid As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "QC_Upfilestatus", pkid)
    End Sub
    Public Shared Function GetApplydeptByfilelayer(ByVal filelayer As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetApplyDeptByfilelayer", filelayer)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetApplydeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetApplyDeptBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFilecategoryByapplydepts(ByVal Applydepts As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetfilecategorybyApplyDept", Applydepts)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFilecategoryBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetfilecategorybySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFilebyapplydeptandfilecategory(ByVal Applydepts As String, ByVal filecategory As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetFilebyapplydeptandfilecategory", Applydepts, filecategory)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFourFileByApplyDept(ByVal Applydepts As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetFourFileByApplyDept", Applydepts)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetDeptByIsfinishedandrecordtype(ByVal isfinished As String, ByVal recordtype As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetDeptByIsfinishedandrecordtype", isfinished, recordtype)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetDeptBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFileBydeptandtype(ByVal isfinished As Integer, ByVal applydept As String, ByVal type As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetFileBydeptandtype", isfinished, applydept, type)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetFileBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetFileBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetZT() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetZT")
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then

            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetZTByType(ByVal Type As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetZTByType", Type)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then

            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetZTBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetZTBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then

            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetZuofeiFileByDeptName(ByVal DeptName As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_File_GetZuofeiFileByDeptName", DeptName)
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

