#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  AddFileSharedDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的AddFileSharedInfo實例
        ''' </summary>
        ''' <param name="AddFileSharedInstance">要操作的AddFileSharedInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal AddFileSharedInstance As AddFileSharedInfo)
            _AddFileSharedInstance = AddFileSharedInstance
        End Sub
#End Region

#Region "屬性"
        Private _AddFileSharedInstance As AddFileSharedInfo

        ''' <summary>
        ''' AddFileSharedInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>AddFileSharedInfo</returns>
        ''' <remarks></remarks>
        Public Property AddFileSharedInstance() As AddFileSharedInfo
            Get
                Return _AddFileSharedInstance
            End Get
            Set(ByVal Value As AddFileSharedInfo)
                _AddFileSharedInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "AddFileShared_Update", _
           				AddFileSharedInstance.PKID, _
		AddFileSharedInstance.eFlowDocID, _
		AddFileSharedInstance.StateName, _
		AddFileSharedInstance.StateOrder, _
		AddFileSharedInstance.IsFinished, _
		AddFileSharedInstance.FinishTime, _
		AddFileSharedInstance.CustomerPKID, _
		AddFileSharedInstance.CustomerName, _
		AddFileSharedInstance.UploadUserSID, _
		AddFileSharedInstance.Extend01, _
		AddFileSharedInstance.Extend02, _
		AddFileSharedInstance.Extend03, _
		AddFileSharedInstance.Extend04, _
		AddFileSharedInstance.Extend05, _
		AddFileSharedInstance.RecordCreated, _
		AddFileSharedInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _AddFileSharedInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "AddFileShared_Insert", _
           				AddFileSharedInstance.PKID, _
		AddFileSharedInstance.eFlowDocID, _
		AddFileSharedInstance.StateName, _
		AddFileSharedInstance.StateOrder, _
		AddFileSharedInstance.IsFinished, _
		AddFileSharedInstance.FinishTime, _
		AddFileSharedInstance.CustomerPKID, _
		AddFileSharedInstance.CustomerName, _
		AddFileSharedInstance.UploadUserSID, _
		AddFileSharedInstance.Extend01, _
		AddFileSharedInstance.Extend02, _
		AddFileSharedInstance.Extend03, _
		AddFileSharedInstance.Extend04, _
		AddFileSharedInstance.Extend05, _
		AddFileSharedInstance.RecordCreated, _
		AddFileSharedInstance.RecordDeleted))
	 	Return  (_AddFileSharedInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As AddFileSharedInfo
		
			 Dim mInfo AS  new AddFileSharedInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.IsFinished = IIf(dr.IsNull("IsFinished"), 0, Convert.ToInt32(dr.Item("IsFinished")))
			mInfo.FinishTime = IIf(dr.IsNull("FinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishTime")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.UploadUserSID = IIf(dr.IsNull("UploadUserSID"), String.Empty, Convert.ToString(dr.Item("UploadUserSID")))
 			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _AddFileSharedInstance Is Nothing Then 
            If _AddFileSharedInstance.PKID=0  Then
                Return Insert()
            ElseIf _AddFileSharedInstance.PKID > 0 Then
                    Return Update()
                Else
                   _AddFileSharedInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the AddFileSharedInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"AddFileShared_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As AddFileSharedInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"AddFileShared_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFLowdocID As String) As AddFileSharedInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "AddFileShared_GetInfoByeFLowdocID", eFLowdocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of AddFileSharedInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "AddFileShared_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mAddFileShared As New list(of AddFileSharedinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mAddFileShared.Add(TransformDr(dr))
            Next

            Return mAddFileShared
		
    End Function
    Public Shared Sub UpFileInfoFinish(ByVal ParentID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "UpFileInfoFinish", ParentID)
    End Sub
	#End Region
#End Region
End Class

