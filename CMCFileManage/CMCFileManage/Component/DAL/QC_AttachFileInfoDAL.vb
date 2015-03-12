#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QC_AttachFileInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的QC_AttachFileInfoInfo實例
        ''' </summary>
        ''' <param name="QC_AttachFileInfoInstance">要操作的QC_AttachFileInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QC_AttachFileInfoInstance As QC_AttachFileInfoInfo)
            _QC_AttachFileInfoInstance = QC_AttachFileInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _QC_AttachFileInfoInstance As QC_AttachFileInfoInfo

        ''' <summary>
        ''' QC_AttachFileInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>QC_AttachFileInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property QC_AttachFileInfoInstance() As QC_AttachFileInfoInfo
            Get
                Return _QC_AttachFileInfoInstance
            End Get
            Set(ByVal Value As QC_AttachFileInfoInfo)
                _QC_AttachFileInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_AttachFileInfo_Update", _
           				QC_AttachFileInfoInstance.FileID, _
		QC_AttachFileInfoInstance.ParentID, _
		QC_AttachFileInfoInstance.ParentCategory, _
		QC_AttachFileInfoInstance.ParentSubCategory, _
		QC_AttachFileInfoInstance.FileGuID, _
		QC_AttachFileInfoInstance.FileName, _
		QC_AttachFileInfoInstance.FileExtension, _
		QC_AttachFileInfoInstance.FileSize, _
		QC_AttachFileInfoInstance.FileClientName, _
		QC_AttachFileInfoInstance.Extend1, _
		QC_AttachFileInfoInstance.Extend2, _
		QC_AttachFileInfoInstance.Extend3, _
		QC_AttachFileInfoInstance.Extend4, _
		QC_AttachFileInfoInstance.Extend5, _
		QC_AttachFileInfoInstance.RecordVersion, _
		QC_AttachFileInfoInstance.RecordCreateTime, _
		QC_AttachFileInfoInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _QC_AttachFileInfoInstance.FileID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_AttachFileInfo_Insert", _
           				QC_AttachFileInfoInstance.FileID, _
		QC_AttachFileInfoInstance.ParentID, _
		QC_AttachFileInfoInstance.ParentCategory, _
		QC_AttachFileInfoInstance.ParentSubCategory, _
		QC_AttachFileInfoInstance.FileGuID, _
		QC_AttachFileInfoInstance.FileName, _
		QC_AttachFileInfoInstance.FileExtension, _
		QC_AttachFileInfoInstance.FileSize, _
		QC_AttachFileInfoInstance.FileClientName, _
		QC_AttachFileInfoInstance.Extend1, _
		QC_AttachFileInfoInstance.Extend2, _
		QC_AttachFileInfoInstance.Extend3, _
		QC_AttachFileInfoInstance.Extend4, _
		QC_AttachFileInfoInstance.Extend5, _
		QC_AttachFileInfoInstance.RecordVersion, _
		QC_AttachFileInfoInstance.RecordCreateTime, _
		QC_AttachFileInfoInstance.RecordDeleted))
	 	Return  (_QC_AttachFileInfoInstance.FileID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QC_AttachFileInfoInfo
		
			 Dim mInfo AS  new QC_AttachFileInfoInfo
			mInfo.FileID = IIf(dr.IsNull("FileID"), 0, Convert.ToInt32(dr.Item("FileID")))
			mInfo.ParentID = IIf(dr.IsNull("ParentID"), String.Empty, Convert.ToString(dr.Item("ParentID")))
 			mInfo.ParentCategory = IIf(dr.IsNull("ParentCategory"), 0, Convert.ToInt32(dr.Item("ParentCategory")))
			mInfo.ParentSubCategory = IIf(dr.IsNull("ParentSubCategory"), 0, Convert.ToInt32(dr.Item("ParentSubCategory")))
			mInfo.FileGuID = IIf(dr.IsNull("FileGuID"), Guid.Empty, New Guid(dr.Item("FileGuID").ToString))
			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.FileExtension = IIf(dr.IsNull("FileExtension"), String.Empty, Convert.ToString(dr.Item("FileExtension")))
 			mInfo.FileSize = IIf(dr.IsNull("FileSize"), 0, Convert.ToInt32(dr.Item("FileSize")))
			mInfo.FileClientName = IIf(dr.IsNull("FileClientName"), String.Empty, Convert.ToString(dr.Item("FileClientName")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordVersion = IIf(dr.IsNull("RecordVersion"), String.Empty, Convert.ToString(dr.Item("RecordVersion")))
 			mInfo.RecordCreateTime = IIf(dr.IsNull("RecordCreateTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreateTime")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _QC_AttachFileInfoInstance Is Nothing Then 
            If _QC_AttachFileInfoInstance.FileID=0  Then
                Return Insert()
            ElseIf _QC_AttachFileInfoInstance.FileID > 0 Then
                    Return Update()
                Else
                   _QC_AttachFileInfoInstance.FileID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the QC_AttachFileInfoInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"QC_AttachFileInfo_Delete", PKID)
       	 End Sub
  
    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QC_AttachFileInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"QC_AttachFileInfo_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QC_AttachFileInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_AttachFileInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQC_AttachFileInfo As New list(of QC_AttachFileInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQC_AttachFileInfo.Add(TransformDr(dr))
            Next

            Return mQC_AttachFileInfo
		
    End Function
    Public Shared Function UPdateFileSubCategory(ByVal parentid As Integer, ByVal newparentid As Integer) As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "UPdateFileSubCategoryto1", parentid, newparentid))
        Return Result
    End Function
    Public Shared Function UPdateFileParentid(ByVal parentid As Integer, ByVal newparentid As Integer) As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "UPdateParentID", parentid, newparentid))
        Return Result
    End Function
#End Region

#End Region
End Class

