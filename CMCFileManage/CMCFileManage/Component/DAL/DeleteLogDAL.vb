#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  DeleteLogDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的DeleteLogInfo實例
        ''' </summary>
        ''' <param name="DeleteLogInstance">要操作的DeleteLogInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal DeleteLogInstance As DeleteLogInfo)
            _DeleteLogInstance = DeleteLogInstance
        End Sub
#End Region

#Region "屬性"
        Private _DeleteLogInstance As DeleteLogInfo

        ''' <summary>
        ''' DeleteLogInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>DeleteLogInfo</returns>
        ''' <remarks></remarks>
        Public Property DeleteLogInstance() As DeleteLogInfo
            Get
                Return _DeleteLogInstance
            End Get
            Set(ByVal Value As DeleteLogInfo)
                _DeleteLogInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "DeleteLog_Update", _
           				DeleteLogInstance.pkid, _
		DeleteLogInstance.Parentid, _
		DeleteLogInstance.parenttype, _
		DeleteLogInstance.DeleteUserSID, _
		DeleteLogInstance.DeleteUserName, _
		DeleteLogInstance.RecordCreated))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _DeleteLogInstance.pkid= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "DeleteLog_Insert", _
           				DeleteLogInstance.pkid, _
		DeleteLogInstance.Parentid, _
		DeleteLogInstance.parenttype, _
		DeleteLogInstance.DeleteUserSID, _
		DeleteLogInstance.DeleteUserName, _
		DeleteLogInstance.RecordCreated))
	 	Return  (_DeleteLogInstance.pkid> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As DeleteLogInfo
		
			 Dim mInfo AS  new DeleteLogInfo
			mInfo.pkid = IIf(dr.IsNull("pkid"), 0, Convert.ToInt32(dr.Item("pkid")))
			mInfo.Parentid = IIf(dr.IsNull("Parentid"), 0, Convert.ToInt32(dr.Item("Parentid")))
			mInfo.parenttype = IIf(dr.IsNull("parenttype"), String.Empty, Convert.ToString(dr.Item("parenttype")))
 			mInfo.DeleteUserSID = IIf(dr.IsNull("DeleteUserSID"), String.Empty, Convert.ToString(dr.Item("DeleteUserSID")))
 			mInfo.DeleteUserName = IIf(dr.IsNull("DeleteUserName"), String.Empty, Convert.ToString(dr.Item("DeleteUserName")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _DeleteLogInstance Is Nothing Then 
            If _DeleteLogInstance.pkid=0  Then
                Return Insert()
            ElseIf _DeleteLogInstance.pkid > 0 Then
                    Return Update()
                Else
                   _DeleteLogInstance.pkid= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the DeleteLogInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"DeleteLog_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As DeleteLogInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"DeleteLog_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of DeleteLogInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "DeleteLog_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mDeleteLog As New list(of DeleteLoginfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mDeleteLog.Add(TransformDr(dr))
            Next

            Return mDeleteLog
		
 	End Function
	#End Region
#End Region
End Class

