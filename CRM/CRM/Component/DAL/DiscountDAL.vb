#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  DiscountDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的DiscountInfo實例
        ''' </summary>
        ''' <param name="DiscountInstance">要操作的DiscountInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal DiscountInstance As DiscountInfo)
            _DiscountInstance = DiscountInstance
        End Sub
#End Region

#Region "屬性"
        Private _DiscountInstance As DiscountInfo

        ''' <summary>
        ''' DiscountInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>DiscountInfo</returns>
        ''' <remarks></remarks>
        Public Property DiscountInstance() As DiscountInfo
            Get
                Return _DiscountInstance
            End Get
            Set(ByVal Value As DiscountInfo)
                _DiscountInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Discount_Update", _
           				DiscountInstance.PKID, _
		DiscountInstance.RoleName, _
		DiscountInstance.One, _
		DiscountInstance.Two, _
		DiscountInstance.Three, _
		DiscountInstance.Four, _
		DiscountInstance.Five, _
		DiscountInstance.Extend1, _
		DiscountInstance.Extend2, _
		DiscountInstance.Extend3, _
		DiscountInstance.Extend4, _
		DiscountInstance.Extend5, _
		DiscountInstance.RecordCreated, _
		DiscountInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _DiscountInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Discount_Insert", _
           				DiscountInstance.PKID, _
		DiscountInstance.RoleName, _
		DiscountInstance.One, _
		DiscountInstance.Two, _
		DiscountInstance.Three, _
		DiscountInstance.Four, _
		DiscountInstance.Five, _
		DiscountInstance.Extend1, _
		DiscountInstance.Extend2, _
		DiscountInstance.Extend3, _
		DiscountInstance.Extend4, _
		DiscountInstance.Extend5, _
		DiscountInstance.RecordCreated, _
		DiscountInstance.RecordDeleted))
	 	Return  (_DiscountInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As DiscountInfo
		
			 Dim mInfo AS  new DiscountInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RoleName = IIf(dr.IsNull("RoleName"), String.Empty, Convert.ToString(dr.Item("RoleName")))
 			mInfo.One = IIf(dr.IsNull("One"), String.Empty, Convert.ToString(dr.Item("One")))
 			mInfo.Two = IIf(dr.IsNull("Two"), String.Empty, Convert.ToString(dr.Item("Two")))
 			mInfo.Three = IIf(dr.IsNull("Three"), String.Empty, Convert.ToString(dr.Item("Three")))
 			mInfo.Four = IIf(dr.IsNull("Four"), String.Empty, Convert.ToString(dr.Item("Four")))
 			mInfo.Five = IIf(dr.IsNull("Five"), String.Empty, Convert.ToString(dr.Item("Five")))
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
	If Not _DiscountInstance Is Nothing Then 
            If _DiscountInstance.PKID=0  Then
                Return Insert()
            ElseIf _DiscountInstance.PKID > 0 Then
                    Return Update()
                Else
                   _DiscountInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the DiscountInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Discount_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As DiscountInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Discount_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of DiscountInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Discount_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mDiscount As New list(of Discountinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mDiscount.Add(TransformDr(dr))
            Next

            Return mDiscount
		
    End Function
    Public Shared Function GetDiscountInfoByRoleName(ByVal RoleName As String) As DiscountInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Discount_GetDiscountInfoByRoleName", RoleName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
	#End Region
#End Region
End Class

