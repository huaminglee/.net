#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  calendarDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的calendarInfo實例
        ''' </summary>
        ''' <param name="calendarInstance">要操作的calendarInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal calendarInstance As calendarInfo)
            _calendarInstance = calendarInstance
        End Sub
#End Region

#Region "屬性"
        Private _calendarInstance As calendarInfo

        ''' <summary>
        ''' calendarInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>calendarInfo</returns>
        ''' <remarks></remarks>
        Public Property calendarInstance() As calendarInfo
            Get
                Return _calendarInstance
            End Get
            Set(ByVal Value As calendarInfo)
                _calendarInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "calendar_Update", _
           				calendarInstance.PKID, _
		calendarInstance.UserSID, _
		calendarInstance.Title, _
		calendarInstance.Xiangxi, _
		calendarInstance.BeginTime, _
		calendarInstance.EndTime, _
		calendarInstance.IsDeal, _
		calendarInstance.Extend1, _
		calendarInstance.Extend2, _
		calendarInstance.Extend3, _
		calendarInstance.Extend4, _
		calendarInstance.Extend5, _
		calendarInstance.RecordCreated, _
		calendarInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _calendarInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "calendar_Insert", _
           				calendarInstance.PKID, _
		calendarInstance.UserSID, _
		calendarInstance.Title, _
		calendarInstance.Xiangxi, _
		calendarInstance.BeginTime, _
		calendarInstance.EndTime, _
		calendarInstance.IsDeal, _
		calendarInstance.Extend1, _
		calendarInstance.Extend2, _
		calendarInstance.Extend3, _
		calendarInstance.Extend4, _
		calendarInstance.Extend5, _
		calendarInstance.RecordCreated, _
		calendarInstance.RecordDeleted))
	 	Return  (_calendarInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As calendarInfo
		
			 Dim mInfo AS  new calendarInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.UserSID = IIf(dr.IsNull("UserSID"), String.Empty, Convert.ToString(dr.Item("UserSID")))
 			mInfo.Title = IIf(dr.IsNull("Title"), String.Empty, Convert.ToString(dr.Item("Title")))
 			mInfo.Xiangxi = IIf(dr.IsNull("Xiangxi"), String.Empty, Convert.ToString(dr.Item("Xiangxi")))
 			mInfo.BeginTime = IIf(dr.IsNull("BeginTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("BeginTime")))
			mInfo.EndTime = IIf(dr.IsNull("EndTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndTime")))
			mInfo.IsDeal = IIf(dr.IsNull("IsDeal"), 0, Convert.ToInt32(dr.Item("IsDeal")))
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
	If Not _calendarInstance Is Nothing Then 
            If _calendarInstance.PKID=0  Then
                Return Insert()
            ElseIf _calendarInstance.PKID > 0 Then
                    Return Update()
                Else
                   _calendarInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the calendarInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"calendar_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As calendarInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"calendar_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of calendarInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "calendar_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mcalendar As New list(of calendarinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mcalendar.Add(TransformDr(dr))
            Next

            Return mcalendar
		
    End Function
    Public Shared Function GetdsByUserSid(ByVal userid As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "calendar_GetInfoByUserSID", userid)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetundodsByUserSid(ByVal userid As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "calendar_GetundoInfoByUserSID", userid)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function IsExites(ByVal Biaozhi As String, ByVal Userid As String) As Integer
        Dim count As Integer = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "calendar_IsExit", Biaozhi, Userid)
        Return count
    End Function
	#End Region
#End Region
End Class

