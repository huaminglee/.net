#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  SendOutMailLogDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的SendOutMailLogInfo實例
        ''' </summary>
        ''' <param name="SendOutMailLogInstance">要操作的SendOutMailLogInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal SendOutMailLogInstance As SendOutMailLogInfo)
            _SendOutMailLogInstance = SendOutMailLogInstance
        End Sub
#End Region

#Region "屬性"
        Private _SendOutMailLogInstance As SendOutMailLogInfo

        ''' <summary>
        ''' SendOutMailLogInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>SendOutMailLogInfo</returns>
        ''' <remarks></remarks>
        Public Property SendOutMailLogInstance() As SendOutMailLogInfo
            Get
                Return _SendOutMailLogInstance
            End Get
            Set(ByVal Value As SendOutMailLogInfo)
                _SendOutMailLogInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SendOutMailLog_Update", _
           				SendOutMailLogInstance.pkid, _
		SendOutMailLogInstance.ParentID, _
		SendOutMailLogInstance.ParentType, _
		SendOutMailLogInstance.CurrentUserSID, _
		SendOutMailLogInstance.MailAddress, _
		SendOutMailLogInstance.MailContent, _
		SendOutMailLogInstance.MailCC, _
		SendOutMailLogInstance.MailTitle, _
		SendOutMailLogInstance.Remark, _
		SendOutMailLogInstance.Extend1, _
		SendOutMailLogInstance.Extend2, _
		SendOutMailLogInstance.Extend3, _
		SendOutMailLogInstance.Extend4, _
		SendOutMailLogInstance.Extend5, _
		SendOutMailLogInstance.RecordCreated, _
		SendOutMailLogInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _SendOutMailLogInstance.pkid= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "SendOutMailLog_Insert", _
           				SendOutMailLogInstance.pkid, _
		SendOutMailLogInstance.ParentID, _
		SendOutMailLogInstance.ParentType, _
		SendOutMailLogInstance.CurrentUserSID, _
		SendOutMailLogInstance.MailAddress, _
		SendOutMailLogInstance.MailContent, _
		SendOutMailLogInstance.MailCC, _
		SendOutMailLogInstance.MailTitle, _
		SendOutMailLogInstance.Remark, _
		SendOutMailLogInstance.Extend1, _
		SendOutMailLogInstance.Extend2, _
		SendOutMailLogInstance.Extend3, _
		SendOutMailLogInstance.Extend4, _
		SendOutMailLogInstance.Extend5, _
		SendOutMailLogInstance.RecordCreated, _
		SendOutMailLogInstance.RecordDeleted))
	 	Return  (_SendOutMailLogInstance.pkid> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As SendOutMailLogInfo
		
			 Dim mInfo AS  new SendOutMailLogInfo
			mInfo.pkid = IIf(dr.IsNull("pkid"), 0, Convert.ToInt32(dr.Item("pkid")))
			mInfo.ParentID = IIf(dr.IsNull("ParentID"), 0, Convert.ToInt32(dr.Item("ParentID")))
			mInfo.ParentType = IIf(dr.IsNull("ParentType"), 0, Convert.ToInt32(dr.Item("ParentType")))
			mInfo.CurrentUserSID = IIf(dr.IsNull("CurrentUserSID"), String.Empty, Convert.ToString(dr.Item("CurrentUserSID")))
 			mInfo.MailAddress = IIf(dr.IsNull("MailAddress"), String.Empty, Convert.ToString(dr.Item("MailAddress")))
 			mInfo.MailContent = IIf(dr.IsNull("MailContent"), String.Empty, Convert.ToString(dr.Item("MailContent")))
 			mInfo.MailCC = IIf(dr.IsNull("MailCC"), String.Empty, Convert.ToString(dr.Item("MailCC")))
 			mInfo.MailTitle = IIf(dr.IsNull("MailTitle"), String.Empty, Convert.ToString(dr.Item("MailTitle")))
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
	If Not _SendOutMailLogInstance Is Nothing Then 
            If _SendOutMailLogInstance.pkid=0  Then
                Return Insert()
            ElseIf _SendOutMailLogInstance.pkid > 0 Then
                    Return Update()
                Else
                   _SendOutMailLogInstance.pkid= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the SendOutMailLogInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"SendOutMailLog_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As SendOutMailLogInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"SendOutMailLog_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of SendOutMailLogInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "SendOutMailLog_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mSendOutMailLog As New list(of SendOutMailLoginfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mSendOutMailLog.Add(TransformDr(dr))
            Next

            Return mSendOutMailLog
		
 	End Function
	#End Region
#End Region
End Class

