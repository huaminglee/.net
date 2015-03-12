#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  RoleManageDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的RoleManageInfo實例
        ''' </summary>
        ''' <param name="RoleManageInstance">要操作的RoleManageInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal RoleManageInstance As RoleManageInfo)
            _RoleManageInstance = RoleManageInstance
        End Sub
#End Region

#Region "屬性"
        Private _RoleManageInstance As RoleManageInfo

        ''' <summary>
        ''' RoleManageInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>RoleManageInfo</returns>
        ''' <remarks></remarks>
        Public Property RoleManageInstance() As RoleManageInfo
            Get
                Return _RoleManageInstance
            End Get
            Set(ByVal Value As RoleManageInfo)
                _RoleManageInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "RoleManage_Update", _
           				RoleManageInstance.PKID, _
		RoleManageInstance.RolePKID, _
		RoleManageInstance.RoleName, _
		RoleManageInstance.Userpkid, _
		RoleManageInstance.UserSid, _
		RoleManageInstance.UserName, _
		RoleManageInstance.UserEmail, _
		RoleManageInstance.UserPhone, _
		RoleManageInstance.IsCanEdit, _
		RoleManageInstance.StartDate, _
		RoleManageInstance.EndDate, _
		RoleManageInstance.Extend01, _
		RoleManageInstance.Extend02, _
		RoleManageInstance.Extend03, _
		RoleManageInstance.Extend04, _
		RoleManageInstance.Extend05, _
		RoleManageInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _RoleManageInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "RoleManage_Insert", _
           				RoleManageInstance.PKID, _
		RoleManageInstance.RolePKID, _
		RoleManageInstance.RoleName, _
		RoleManageInstance.Userpkid, _
		RoleManageInstance.UserSid, _
		RoleManageInstance.UserName, _
		RoleManageInstance.UserEmail, _
		RoleManageInstance.UserPhone, _
		RoleManageInstance.IsCanEdit, _
		RoleManageInstance.StartDate, _
		RoleManageInstance.EndDate, _
		RoleManageInstance.Extend01, _
		RoleManageInstance.Extend02, _
		RoleManageInstance.Extend03, _
		RoleManageInstance.Extend04, _
		RoleManageInstance.Extend05, _
		RoleManageInstance.RecordDeleted))
	 	Return  (_RoleManageInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As RoleManageInfo
		
			 Dim mInfo AS  new RoleManageInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RolePKID = IIf(dr.IsNull("RolePKID"), 0, Convert.ToInt32(dr.Item("RolePKID")))
			mInfo.RoleName = IIf(dr.IsNull("RoleName"), String.Empty, Convert.ToString(dr.Item("RoleName")))
 			mInfo.Userpkid = IIf(dr.IsNull("Userpkid"), 0, Convert.ToInt32(dr.Item("Userpkid")))
			mInfo.UserSid = IIf(dr.IsNull("UserSid"), String.Empty, Convert.ToString(dr.Item("UserSid")))
 			mInfo.UserName = IIf(dr.IsNull("UserName"), String.Empty, Convert.ToString(dr.Item("UserName")))
 			mInfo.UserEmail = IIf(dr.IsNull("UserEmail"), String.Empty, Convert.ToString(dr.Item("UserEmail")))
 			mInfo.UserPhone = IIf(dr.IsNull("UserPhone"), String.Empty, Convert.ToString(dr.Item("UserPhone")))
 			mInfo.IsCanEdit = IIf(dr.IsNull("IsCanEdit"), 0, Convert.ToInt32(dr.Item("IsCanEdit")))
			mInfo.StartDate = IIf(dr.IsNull("StartDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("StartDate")))
			mInfo.EndDate = IIf(dr.IsNull("EndDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndDate")))
			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _RoleManageInstance Is Nothing Then 
            If _RoleManageInstance.PKID=0  Then
                Return Insert()
            ElseIf _RoleManageInstance.PKID > 0 Then
                    Return Update()
                Else
                   _RoleManageInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the RoleManageInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"RoleManage_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As RoleManageInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"RoleManage_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of RoleManageInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "RoleManage_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mRoleManage As New list(of RoleManageinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mRoleManage.Add(TransformDr(dr))
            Next

            Return mRoleManage
		
 	End Function
	#End Region
#End Region
End Class

