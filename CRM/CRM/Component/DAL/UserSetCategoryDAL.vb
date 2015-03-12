#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  UserSetCategoryDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的UserSetCategoryInfo實例
        ''' </summary>
        ''' <param name="UserSetCategoryInstance">要操作的UserSetCategoryInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal UserSetCategoryInstance As UserSetCategoryInfo)
            _UserSetCategoryInstance = UserSetCategoryInstance
        End Sub
#End Region

#Region "屬性"
        Private _UserSetCategoryInstance As UserSetCategoryInfo

        ''' <summary>
        ''' UserSetCategoryInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>UserSetCategoryInfo</returns>
        ''' <remarks></remarks>
        Public Property UserSetCategoryInstance() As UserSetCategoryInfo
            Get
                Return _UserSetCategoryInstance
            End Get
            Set(ByVal Value As UserSetCategoryInfo)
                _UserSetCategoryInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "UserSetCategory_Update", _
           				UserSetCategoryInstance.PKID, _
		UserSetCategoryInstance.CategoryName, _
		UserSetCategoryInstance.StateOrder, _
		UserSetCategoryInstance.Type, _
		UserSetCategoryInstance.NextStateOrder))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _UserSetCategoryInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "UserSetCategory_Insert", _
           				UserSetCategoryInstance.PKID, _
		UserSetCategoryInstance.CategoryName, _
		UserSetCategoryInstance.StateOrder, _
		UserSetCategoryInstance.Type, _
		UserSetCategoryInstance.NextStateOrder))
	 	Return  (_UserSetCategoryInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As UserSetCategoryInfo
		
			 Dim mInfo AS  new UserSetCategoryInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.CategoryName = IIf(dr.IsNull("CategoryName"), String.Empty, Convert.ToString(dr.Item("CategoryName")))
 			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.Type = IIf(dr.IsNull("Type"), 0, Convert.ToInt32(dr.Item("Type")))
			mInfo.NextStateOrder = IIf(dr.IsNull("NextStateOrder"), 0, Convert.ToInt32(dr.Item("NextStateOrder")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _UserSetCategoryInstance Is Nothing Then 
            If _UserSetCategoryInstance.PKID=0  Then
                Return Insert()
            ElseIf _UserSetCategoryInstance.PKID > 0 Then
                    Return Update()
                Else
                   _UserSetCategoryInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the UserSetCategoryInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"UserSetCategory_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As UserSetCategoryInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"UserSetCategory_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of UserSetCategoryInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "UserSetCategory_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mUserSetCategory As New list(of UserSetCategoryinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mUserSetCategory.Add(TransformDr(dr))
            Next

            Return mUserSetCategory
		
    End Function
    Public Shared Function GetInfoByType(ByVal Type As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "UserSetCategory_GetInfoByType", Type)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        End If
        Return Nothing
    End Function
#End Region
#End Region
End Class

