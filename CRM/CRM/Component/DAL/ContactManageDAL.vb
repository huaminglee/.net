#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ContactManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ContactManageInfo實例
        ''' </summary>
        ''' <param name="ContactManageInstance">要操作的ContactManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ContactManageInstance As ContactManageInfo)
            _ContactManageInstance = ContactManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _ContactManageInstance As ContactManageInfo

        ''' <summary>
        ''' ContactManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ContactManageInfo</returns>
        ''' <remarks></remarks>
        Public Property ContactManageInstance() As ContactManageInfo
            Get
                Return _ContactManageInstance
            End Get
            Set(ByVal Value As ContactManageInfo)
                _ContactManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ContactManage_Update", _
           				ContactManageInstance.PKID, _
		ContactManageInstance.Type, _
		ContactManageInstance.ContactPKID, _
		ContactManageInstance.CustomerPKID, _
		ContactManageInstance.InsertPerson, _
		ContactManageInstance.Extend1, _
		ContactManageInstance.Extend2, _
		ContactManageInstance.Extend3, _
		ContactManageInstance.Extend4, _
		ContactManageInstance.Extend5, _
		ContactManageInstance.RecordCreated, _
		ContactManageInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _ContactManageInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "ContactManage_Insert", _
           				ContactManageInstance.PKID, _
		ContactManageInstance.Type, _
		ContactManageInstance.ContactPKID, _
		ContactManageInstance.CustomerPKID, _
		ContactManageInstance.InsertPerson, _
		ContactManageInstance.Extend1, _
		ContactManageInstance.Extend2, _
		ContactManageInstance.Extend3, _
		ContactManageInstance.Extend4, _
		ContactManageInstance.Extend5, _
		ContactManageInstance.RecordCreated, _
		ContactManageInstance.RecordDeleted))
	 	Return  (_ContactManageInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ContactManageInfo
		
			 Dim mInfo AS  new ContactManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.Type = IIf(dr.IsNull("Type"), 0, Convert.ToInt32(dr.Item("Type")))
			mInfo.ContactPKID = IIf(dr.IsNull("ContactPKID"), 0, Convert.ToInt32(dr.Item("ContactPKID")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.InsertPerson = IIf(dr.IsNull("InsertPerson"), String.Empty, Convert.ToString(dr.Item("InsertPerson")))
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
	If Not _ContactManageInstance Is Nothing Then 
            If _ContactManageInstance.PKID=0  Then
                Return Insert()
            ElseIf _ContactManageInstance.PKID > 0 Then
                    Return Update()
                Else
                   _ContactManageInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the ContactManageInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"ContactManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ContactManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"ContactManage_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ContactManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ContactManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mContactManage As New list(of ContactManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mContactManage.Add(TransformDr(dr))
            Next

            Return mContactManage
		
    End Function
    Public Shared Function ContactMaIsExist(ByVal ContactPKID As Integer, ByVal CustomerPKID As Integer, ByVal Type As Integer) As Boolean
        Dim isexist As Integer = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "ContactManage_IsExist", ContactPKID, CustomerPKID, Type)
        If isexist > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Shared Sub DeleteByContactPKIDandCuspkid(ByVal ContactPKID As Integer, ByVal mpkid As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "ContactManage_DeleteByContactPKIDandCuspkid", ContactPKID, mpkid)
    End Sub
#End Region
#End Region
End Class

