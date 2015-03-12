#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  WF_AttachFileInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的WF_AttachFileInfoInfo實例
        ''' </summary>
        ''' <param name="WF_AttachFileInfoInstance">要操作的WF_AttachFileInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal WF_AttachFileInfoInstance As WF_AttachFileInfoInfo)
            _WF_AttachFileInfoInstance = WF_AttachFileInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _WF_AttachFileInfoInstance As WF_AttachFileInfoInfo

        ''' <summary>
        ''' WF_AttachFileInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>WF_AttachFileInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property WF_AttachFileInfoInstance() As WF_AttachFileInfoInfo
            Get
                Return _WF_AttachFileInfoInstance
            End Get
            Set(ByVal Value As WF_AttachFileInfoInfo)
                _WF_AttachFileInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "WF_AttachFileInfo_Update", _
                    WF_AttachFileInfoInstance.FileID, _
       WF_AttachFileInfoInstance.ParentID, _
       WF_AttachFileInfoInstance.ParentCategory, _
       WF_AttachFileInfoInstance.ParentSubCategory, _
       WF_AttachFileInfoInstance.FileGuID, _
       WF_AttachFileInfoInstance.FileName, _
       WF_AttachFileInfoInstance.FileExtension, _
       WF_AttachFileInfoInstance.FileSize, _
       WF_AttachFileInfoInstance.FileClientName, _
             WF_AttachFileInfoInstance.FileContent, _
       WF_AttachFileInfoInstance.Extend1, _
       WF_AttachFileInfoInstance.Extend2, _
       WF_AttachFileInfoInstance.Extend3, _
       WF_AttachFileInfoInstance.Extend4, _
       WF_AttachFileInfoInstance.Extend5, _
       WF_AttachFileInfoInstance.RecordVersion, _
       WF_AttachFileInfoInstance.RecordCreateTime, _
       WF_AttachFileInfoInstance.RecordDeleted))
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
        _WF_AttachFileInfoInstance.FileID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "WF_AttachFileInfo_Insert", _
                  WF_AttachFileInfoInstance.FileID, _
     WF_AttachFileInfoInstance.ParentID, _
     WF_AttachFileInfoInstance.ParentCategory, _
     WF_AttachFileInfoInstance.ParentSubCategory, _
     WF_AttachFileInfoInstance.FileGuID, _
     WF_AttachFileInfoInstance.FileName, _
     WF_AttachFileInfoInstance.FileExtension, _
     WF_AttachFileInfoInstance.FileSize, _
     WF_AttachFileInfoInstance.FileClientName, _
     WF_AttachFileInfoInstance.FileContent, _
     WF_AttachFileInfoInstance.Extend1, _
     WF_AttachFileInfoInstance.Extend2, _
     WF_AttachFileInfoInstance.Extend3, _
     WF_AttachFileInfoInstance.Extend4, _
     WF_AttachFileInfoInstance.Extend5, _
     WF_AttachFileInfoInstance.RecordVersion, _
     WF_AttachFileInfoInstance.RecordCreateTime, _
     WF_AttachFileInfoInstance.RecordDeleted))
	 	Return  (_WF_AttachFileInfoInstance.FileID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As WF_AttachFileInfoInfo
		
			 Dim mInfo AS  new WF_AttachFileInfoInfo
			mInfo.FileID = IIf(dr.IsNull("FileID"), 0, Convert.ToInt32(dr.Item("FileID")))
			mInfo.ParentID = IIf(dr.IsNull("ParentID"), 0, Convert.ToInt32(dr.Item("ParentID")))
			mInfo.ParentCategory = IIf(dr.IsNull("ParentCategory"), 0, Convert.ToInt32(dr.Item("ParentCategory")))
			mInfo.ParentSubCategory = IIf(dr.IsNull("ParentSubCategory"), 0, Convert.ToInt32(dr.Item("ParentSubCategory")))
        mInfo.FileGuID = IIf(dr.IsNull("FileGuID"), Guid.Empty, New Guid(dr.Item("FileGuID").ToString))
			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.FileExtension = IIf(dr.IsNull("FileExtension"), String.Empty, Convert.ToString(dr.Item("FileExtension")))
 			mInfo.FileSize = IIf(dr.IsNull("FileSize"), 0, Convert.ToInt32(dr.Item("FileSize")))
        mInfo.FileClientName = IIf(dr.IsNull("FileClientName"), String.Empty, Convert.ToString(dr.Item("FileClientName")))
        mInfo.FileContent = dr.Item("FileContent")
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
	If Not _WF_AttachFileInfoInstance Is Nothing Then 
            If _WF_AttachFileInfoInstance.FileID=0  Then
                Return Insert()
            ElseIf _WF_AttachFileInfoInstance.FileID > 0 Then
                    Return Update()
                Else
                   _WF_AttachFileInfoInstance.FileID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the WF_AttachFileInfoInstance Property !")
            Throw ex
        End if 
    End Function
   
   
   

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"WF_AttachFileInfo_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As WF_AttachFileInfoInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of WF_AttachFileInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mWF_AttachFileInfo As New list(of WF_AttachFileInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mWF_AttachFileInfo.Add(TransformDr(dr))
            Next

            Return mWF_AttachFileInfo
		
    End Function
    Public Shared Function GetInfoBySearchCondtionQuotation(ByVal SearchString As String) As List(Of WF_AttachFileInfoInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestApplyManage_GetFileBySearchcondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mWF_AttachFileInfo As New List(Of WF_AttachFileInfoInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mWF_AttachFileInfo.Add(TransformDr(dr))
        Next

        Return mWF_AttachFileInfo

    End Function
    Public Shared Function GetdsnocontentInfoBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_GetNOcontentInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)


        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Return ds

    End Function
    Public Shared Sub DeleteByParentIDandParentcategory(ByVal ParentID As Integer, ByVal ParentCategory As Integer, ByVal ParentSubCategery As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_DeleteByParentIDandParentcategory", ParentID, ParentCategory, ParentSubCategery)
    End Sub
    Public Shared Function GetTongjiInfoByCustomerPKID(ByVal CustomerPKID As Integer) As Long
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_GettONGJIByCustomerPKID", CustomerPKID)
        Dim dt As DataTable = ds.Tables(0)
        If (ds.Tables(0).Rows(0).IsNull("UseSize")) Then
            Return 0
        End If
        Return CType(ds.Tables(0).Rows(0).Item(0), Long)

    End Function
    Public Shared Function GetLastquotationclientname(ByVal quotationpkid As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GetLastQuotationClientName", quotationpkid)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return ds
        End If
        Return Nothing
    End Function
    Public Shared Sub Upcontentandsize(ByVal fileid As Integer, ByVal filecontent As Byte(), ByVal filesize As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_AttachFileInfo_UpContentandSize", fileid, filecontent, filesize)
    End Sub
    Public Shared Sub UpDeleteinfo(ByVal fileid As Integer, ByVal changeto As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_AttachFileinfo_UPDeleteInfo", fileid, changeto)
    End Sub
#End Region
#End Region
End Class

