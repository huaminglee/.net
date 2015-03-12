#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  PersonTecDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的PersonTecInfo實例
        ''' </summary>
        ''' <param name="PersonTecInstance">要操作的PersonTecInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal PersonTecInstance As PersonTecInfo)
            _PersonTecInstance = PersonTecInstance
        End Sub
#End Region

#Region "屬性"
        Private _PersonTecInstance As PersonTecInfo

        ''' <summary>
        ''' PersonTecInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>PersonTecInfo</returns>
        ''' <remarks></remarks>
        Public Property PersonTecInstance() As PersonTecInfo
            Get
                Return _PersonTecInstance
            End Get
            Set(ByVal Value As PersonTecInfo)
                _PersonTecInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "PersonTec_Update", _
           				PersonTecInstance.PKID, _
		PersonTecInstance.Dept, _
		PersonTecInstance.UserName, _
		PersonTecInstance.UserSid, _
		PersonTecInstance.QuLocation, _
		PersonTecInstance.JobType, _
		PersonTecInstance.Position, _
		PersonTecInstance.CerNO, _
		PersonTecInstance.Intime, _
		PersonTecInstance.PostsTime, _
		PersonTecInstance.PostsRemark, _
		PersonTecInstance.OtherRemark, _
		PersonTecInstance.CurType, _
		PersonTecInstance.Remark, _
		PersonTecInstance.Extend1, _
		PersonTecInstance.Extend2, _
		PersonTecInstance.Extend3, _
		PersonTecInstance.Extend4, _
		PersonTecInstance.Extend5, _
		PersonTecInstance.RecordCreated, _
		PersonTecInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _PersonTecInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "PersonTec_Insert", _
           				PersonTecInstance.PKID, _
		PersonTecInstance.Dept, _
		PersonTecInstance.UserName, _
		PersonTecInstance.UserSid, _
		PersonTecInstance.QuLocation, _
		PersonTecInstance.JobType, _
		PersonTecInstance.Position, _
		PersonTecInstance.CerNO, _
		PersonTecInstance.Intime, _
		PersonTecInstance.PostsTime, _
		PersonTecInstance.PostsRemark, _
		PersonTecInstance.OtherRemark, _
		PersonTecInstance.CurType, _
		PersonTecInstance.Remark, _
		PersonTecInstance.Extend1, _
		PersonTecInstance.Extend2, _
		PersonTecInstance.Extend3, _
		PersonTecInstance.Extend4, _
		PersonTecInstance.Extend5, _
		PersonTecInstance.RecordCreated, _
		PersonTecInstance.RecordDeleted))
	 	Return  (_PersonTecInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As PersonTecInfo
		
			 Dim mInfo AS  new PersonTecInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.Dept = IIf(dr.IsNull("Dept"), String.Empty, Convert.ToString(dr.Item("Dept")))
 			mInfo.UserName = IIf(dr.IsNull("UserName"), String.Empty, Convert.ToString(dr.Item("UserName")))
 			mInfo.UserSid = IIf(dr.IsNull("UserSid"), String.Empty, Convert.ToString(dr.Item("UserSid")))
 			mInfo.QuLocation = IIf(dr.IsNull("QuLocation"), String.Empty, Convert.ToString(dr.Item("QuLocation")))
 			mInfo.JobType = IIf(dr.IsNull("JobType"), String.Empty, Convert.ToString(dr.Item("JobType")))
 			mInfo.Position = IIf(dr.IsNull("Position"), String.Empty, Convert.ToString(dr.Item("Position")))
 			mInfo.CerNO = IIf(dr.IsNull("CerNO"), String.Empty, Convert.ToString(dr.Item("CerNO")))
 			mInfo.Intime = IIf(dr.IsNull("Intime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("Intime")))
			mInfo.PostsTime = IIf(dr.IsNull("PostsTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("PostsTime")))
			mInfo.PostsRemark = IIf(dr.IsNull("PostsRemark"), String.Empty, Convert.ToString(dr.Item("PostsRemark")))
 			mInfo.OtherRemark = IIf(dr.IsNull("OtherRemark"), String.Empty, Convert.ToString(dr.Item("OtherRemark")))
 			mInfo.CurType = IIf(dr.IsNull("CurType"), 0, Convert.ToInt32(dr.Item("CurType")))
			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
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
	If Not _PersonTecInstance Is Nothing Then 
            If _PersonTecInstance.PKID=0  Then
                Return Insert()
            ElseIf _PersonTecInstance.PKID > 0 Then
                    Return Update()
                Else
                   _PersonTecInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the PersonTecInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"PersonTec_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As PersonTecInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"PersonTec_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of PersonTecInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "PersonTec_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mPersonTec As New list(of PersonTecinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mPersonTec.Add(TransformDr(dr))
            Next

            Return mPersonTec
		
    End Function
    Public Shared Function GetDsBySearchcontition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "PersonTec_GetInfoBySearchCondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        End If
        Return Nothing
    End Function
    Public Shared Function GetDeptBySearchcontition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "PersonTec_GetDeptBysearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        End If
        Return Nothing
    End Function
    Public Shared Function GetQuBySearchcontition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "PersonTec_GetQuBysearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        End If
        Return Nothing
    End Function
	#End Region
#End Region
End Class

