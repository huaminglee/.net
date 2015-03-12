#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ReadFileInfoDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ReadFileInfoInfo實例
        ''' </summary>
        ''' <param name="ReadFileInfoInstance">要操作的ReadFileInfoInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ReadFileInfoInstance As ReadFileInfoInfo)
            _ReadFileInfoInstance = ReadFileInfoInstance
        End Sub
#End Region

#Region "屬性"
        Private _ReadFileInfoInstance As ReadFileInfoInfo

        ''' <summary>
        ''' ReadFileInfoInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ReadFileInfoInfo</returns>
        ''' <remarks></remarks>
        Public Property ReadFileInfoInstance() As ReadFileInfoInfo
            Get
                Return _ReadFileInfoInstance
            End Get
            Set(ByVal Value As ReadFileInfoInfo)
                _ReadFileInfoInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ReadFileInfo_Update", _
           				ReadFileInfoInstance.pkid, _
		ReadFileInfoInstance.parentid, _
		ReadFileInfoInstance.FileBH, _
		ReadFileInfoInstance.FileName, _
		ReadFileInfoInstance.ReadType, _
		ReadFileInfoInstance.ReadFor, _
		ReadFileInfoInstance.Extend1, _
		ReadFileInfoInstance.Extend2, _
		ReadFileInfoInstance.Extend3, _
		ReadFileInfoInstance.Extend4, _
		ReadFileInfoInstance.Extend5, _
		ReadFileInfoInstance.RecordCreated, _
		ReadFileInfoInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _ReadFileInfoInstance.pkid= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ReadFileInfo_Insert", _
           				ReadFileInfoInstance.pkid, _
		ReadFileInfoInstance.parentid, _
		ReadFileInfoInstance.FileBH, _
		ReadFileInfoInstance.FileName, _
		ReadFileInfoInstance.ReadType, _
		ReadFileInfoInstance.ReadFor, _
		ReadFileInfoInstance.Extend1, _
		ReadFileInfoInstance.Extend2, _
		ReadFileInfoInstance.Extend3, _
		ReadFileInfoInstance.Extend4, _
		ReadFileInfoInstance.Extend5, _
		ReadFileInfoInstance.RecordCreated, _
		ReadFileInfoInstance.RecordDeleted))
	 	Return  (_ReadFileInfoInstance.pkid> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ReadFileInfoInfo
		
			 Dim mInfo AS  new ReadFileInfoInfo
			mInfo.pkid = IIf(dr.IsNull("pkid"), 0, Convert.ToInt32(dr.Item("pkid")))
			mInfo.parentid = IIf(dr.IsNull("parentid"), 0, Convert.ToInt32(dr.Item("parentid")))
			mInfo.FileBH = IIf(dr.IsNull("FileBH"), String.Empty, Convert.ToString(dr.Item("FileBH")))
 			mInfo.FileName = IIf(dr.IsNull("FileName"), String.Empty, Convert.ToString(dr.Item("FileName")))
 			mInfo.ReadType = IIf(dr.IsNull("ReadType"), String.Empty, Convert.ToString(dr.Item("ReadType")))
 			mInfo.ReadFor = IIf(dr.IsNull("ReadFor"), String.Empty, Convert.ToString(dr.Item("ReadFor")))
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
	     Public Function Save() As Boolean
	If Not _ReadFileInfoInstance Is Nothing Then 
            If _ReadFileInfoInstance.pkid=0  Then
                Return Insert()
            ElseIf _ReadFileInfoInstance.pkid > 0 Then
                    Return Update()
                Else
                   _ReadFileInfoInstance.pkid= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the ReadFileInfoInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"ReadFileInfo_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ReadFileInfoInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"ReadFileInfo_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByparentid(ByVal parentid As Integer) As ReadFileInfoInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReadFileInfo_GetInfoByparentid", parentid)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ReadFileInfoInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ReadFileInfo_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mReadFileInfo As New list(of ReadFileInfoinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mReadFileInfo.Add(TransformDr(dr))
            Next

            Return mReadFileInfo
		
 	End Function
	#End Region
#End Region
End Class

