#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  TableBMHDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的TableBMHInfo實例
        ''' </summary>
        ''' <param name="TableBMHInstance">要操作的TableBMHInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal TableBMHInstance As TableBMHInfo)
            _TableBMHInstance = TableBMHInstance
        End Sub
#End Region

#Region "屬性"
        Private _TableBMHInstance As TableBMHInfo

        ''' <summary>
        ''' TableBMHInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>TableBMHInfo</returns>
        ''' <remarks></remarks>
        Public Property TableBMHInstance() As TableBMHInfo
            Get
                Return _TableBMHInstance
            End Get
            Set(ByVal Value As TableBMHInfo)
                _TableBMHInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "TableBMH_Update", _
           				TableBMHInstance.PKID, _
		TableBMHInstance.Category, _
		TableBMHInstance.YMD, _
		TableBMHInstance.BMH, _
		TableBMHInstance.RecordPKID))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _TableBMHInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "TableBMH_Insert", _
           				TableBMHInstance.PKID, _
		TableBMHInstance.Category, _
		TableBMHInstance.YMD, _
		TableBMHInstance.BMH, _
		TableBMHInstance.RecordPKID))
	 	Return  (_TableBMHInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As TableBMHInfo
		
			 Dim mInfo AS  new TableBMHInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.Category = IIf(dr.IsNull("Category"), String.Empty, Convert.ToString(dr.Item("Category")))
 			mInfo.YMD = IIf(dr.IsNull("YMD"), String.Empty, Convert.ToString(dr.Item("YMD")))
 			mInfo.BMH = IIf(dr.IsNull("BMH"), 0, Convert.ToInt32(dr.Item("BMH")))
			mInfo.RecordPKID = IIf(dr.IsNull("RecordPKID"), 0, Convert.ToInt32(dr.Item("RecordPKID")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _TableBMHInstance Is Nothing Then 
            If _TableBMHInstance.PKID=0  Then
                Return Insert()
            ElseIf _TableBMHInstance.PKID > 0 Then
                    Return Update()
                Else
                   _TableBMHInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the TableBMHInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"TableBMH_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As TableBMHInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"TableBMH_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of TableBMHInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TableBMH_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mTableBMH As New list(of TableBMHinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mTableBMH.Add(TransformDr(dr))
            Next

            Return mTableBMH
		
    End Function
    Public Shared Function GetMaxlsmbyCategory(ByVal Category As String) As Integer
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_BMH_getLASTBMH", Category)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        If dt.Rows.Count = 0 Then
            Return 0
        End If
        dr = dt.Rows(0)
        If dr.IsNull("MAXBH") Then
            Return 0
        Else
            Return Convert.ToInt32(dr.Item("MAXBH"))
        End If
    End Function
    Public Shared Function GetPageInfoBySearchCondition(ByVal TableName As String, ByVal SearchCondition As String, ByVal Fields As String, _
                                                        ByVal OrderField As String, Optional ByVal PageSize As Integer = 20, _
                                                        Optional ByVal pageIndex As Integer = 1, Optional ByVal TotalRecord As Integer = 0) As DataSet

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "up_Page2005V2", TableName, Fields, OrderField, SearchCondition, PageSize, pageIndex, TotalRecord)
        Dim dt As DataTableCollection = ds.Tables()
        If dt(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If

    End Function
	#End Region
#End Region
End Class

