#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ImportantGoodsDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ImportantGoodsInfo實例
        ''' </summary>
        ''' <param name="ImportantGoodsInstance">要操作的ImportantGoodsInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ImportantGoodsInstance As ImportantGoodsInfo)
            _ImportantGoodsInstance = ImportantGoodsInstance
        End Sub
#End Region

#Region "屬性"
        Private _ImportantGoodsInstance As ImportantGoodsInfo

        ''' <summary>
        ''' ImportantGoodsInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ImportantGoodsInfo</returns>
        ''' <remarks></remarks>
        Public Property ImportantGoodsInstance() As ImportantGoodsInfo
            Get
                Return _ImportantGoodsInstance
            End Get
            Set(ByVal Value As ImportantGoodsInfo)
                _ImportantGoodsInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ImportantGoods_Update", _
           				ImportantGoodsInstance.PKID, _
		ImportantGoodsInstance.LabName, _
		ImportantGoodsInstance.GoodsName, _
		ImportantGoodsInstance.Standars, _
		ImportantGoodsInstance.Brands, _
		ImportantGoodsInstance.Supplier, _
		ImportantGoodsInstance.TecRequir, _
		ImportantGoodsInstance.Qulocation, _
		ImportantGoodsInstance.Remark, _
		ImportantGoodsInstance.Extend1, _
		ImportantGoodsInstance.Extend2, _
		ImportantGoodsInstance.Extend3, _
		ImportantGoodsInstance.Extend4, _
		ImportantGoodsInstance.Extend5, _
		ImportantGoodsInstance.Extend6, _
		ImportantGoodsInstance.Extend7, _
		ImportantGoodsInstance.Extend8, _
		ImportantGoodsInstance.Extend9, _
		ImportantGoodsInstance.Extend10, _
		ImportantGoodsInstance.RecordCreated, _
		ImportantGoodsInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _ImportantGoodsInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ImportantGoods_Insert", _
           				ImportantGoodsInstance.PKID, _
		ImportantGoodsInstance.LabName, _
		ImportantGoodsInstance.GoodsName, _
		ImportantGoodsInstance.Standars, _
		ImportantGoodsInstance.Brands, _
		ImportantGoodsInstance.Supplier, _
		ImportantGoodsInstance.TecRequir, _
		ImportantGoodsInstance.Qulocation, _
		ImportantGoodsInstance.Remark, _
		ImportantGoodsInstance.Extend1, _
		ImportantGoodsInstance.Extend2, _
		ImportantGoodsInstance.Extend3, _
		ImportantGoodsInstance.Extend4, _
		ImportantGoodsInstance.Extend5, _
		ImportantGoodsInstance.Extend6, _
		ImportantGoodsInstance.Extend7, _
		ImportantGoodsInstance.Extend8, _
		ImportantGoodsInstance.Extend9, _
		ImportantGoodsInstance.Extend10, _
		ImportantGoodsInstance.RecordCreated, _
		ImportantGoodsInstance.RecordDeleted))
	 	Return  (_ImportantGoodsInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ImportantGoodsInfo
		
			 Dim mInfo AS  new ImportantGoodsInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.LabName = IIf(dr.IsNull("LabName"), String.Empty, Convert.ToString(dr.Item("LabName")))
 			mInfo.GoodsName = IIf(dr.IsNull("GoodsName"), String.Empty, Convert.ToString(dr.Item("GoodsName")))
 			mInfo.Standars = IIf(dr.IsNull("Standars"), String.Empty, Convert.ToString(dr.Item("Standars")))
 			mInfo.Brands = IIf(dr.IsNull("Brands"), String.Empty, Convert.ToString(dr.Item("Brands")))
 			mInfo.Supplier = IIf(dr.IsNull("Supplier"), String.Empty, Convert.ToString(dr.Item("Supplier")))
 			mInfo.TecRequir = IIf(dr.IsNull("TecRequir"), String.Empty, Convert.ToString(dr.Item("TecRequir")))
 			mInfo.Qulocation = IIf(dr.IsNull("Qulocation"), String.Empty, Convert.ToString(dr.Item("Qulocation")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
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
	If Not _ImportantGoodsInstance Is Nothing Then 
            If _ImportantGoodsInstance.PKID=0  Then
                Return Insert()
            ElseIf _ImportantGoodsInstance.PKID > 0 Then
                    Return Update()
                Else
                   _ImportantGoodsInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the ImportantGoodsInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"ImportantGoods_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ImportantGoodsInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"ImportantGoods_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ImportantGoodsInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ImportantGoods_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mImportantGoods As New list(of ImportantGoodsinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mImportantGoods.Add(TransformDr(dr))
            Next

            Return mImportantGoods
		
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ImportantGoods_GetDeptBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetQyBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ImportantGoods_GetQyBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetEquipBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ImportantGoods_GetfileBySearchcondition", Searchcondition)
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

