#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ComplaintsDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ComplaintsInfo實例
        ''' </summary>
        ''' <param name="ComplaintsInstance">要操作的ComplaintsInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ComplaintsInstance As ComplaintsInfo)
            _ComplaintsInstance = ComplaintsInstance
        End Sub
#End Region

#Region "屬性"
        Private _ComplaintsInstance As ComplaintsInfo

        ''' <summary>
        ''' ComplaintsInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ComplaintsInfo</returns>
        ''' <remarks></remarks>
        Public Property ComplaintsInstance() As ComplaintsInfo
            Get
                Return _ComplaintsInstance
            End Get
            Set(ByVal Value As ComplaintsInfo)
                _ComplaintsInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "Complaints_Update", _
                    ComplaintsInstance.PKID, _
       ComplaintsInstance.eFlowDocID, _
       ComplaintsInstance.RecordNO, _
       ComplaintsInstance.StateOrder, _
       ComplaintsInstance.StateName, _
       ComplaintsInstance.QyuLocation, _
       ComplaintsInstance.ComlaintsPerson, _
       ComplaintsInstance.ComplaintsDept, _
       ComplaintsInstance.ComplaintsPosition, _
       ComplaintsInstance.BeComplaintsDept, _
       ComplaintsInstance.ComplaintsDate, _
       ComplaintsInstance.HopeFinishTime, _
       ComplaintsInstance.Phone, _
       ComplaintsInstance.Email, _
       ComplaintsInstance.ComplaintsDesc, _
       ComplaintsInstance.ComplaintsDetailed, _
       ComplaintsInstance.Findings, _
       ComplaintsInstance.Reasons, _
       ComplaintsInstance.Improve, _
       ComplaintsInstance.Hinding, _
       ComplaintsInstance.IsFinished, _
       ComplaintsInstance.Approved, _
       ComplaintsInstance.UnderTake, _
       ComplaintsInstance.Extend1, _
       ComplaintsInstance.Extend2, _
       ComplaintsInstance.Extend3, _
       ComplaintsInstance.Extend4, _
       ComplaintsInstance.Extend5, _
       ComplaintsInstance.RecordDeleted, _
       ComplaintsInstance.RecordCreated))
        Return Result
    End Function

    Private Function Insert() As Integer
        _ComplaintsInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "Complaints_Insert", _
                  ComplaintsInstance.PKID, _
     ComplaintsInstance.eFlowDocID, _
     ComplaintsInstance.RecordNO, _
     ComplaintsInstance.StateOrder, _
     ComplaintsInstance.StateName, _
     ComplaintsInstance.QyuLocation, _
     ComplaintsInstance.ComlaintsPerson, _
     ComplaintsInstance.ComplaintsDept, _
     ComplaintsInstance.ComplaintsPosition, _
     ComplaintsInstance.BeComplaintsDept, _
     ComplaintsInstance.ComplaintsDate, _
     ComplaintsInstance.HopeFinishTime, _
     ComplaintsInstance.Phone, _
     ComplaintsInstance.Email, _
     ComplaintsInstance.ComplaintsDesc, _
     ComplaintsInstance.ComplaintsDetailed, _
     ComplaintsInstance.Findings, _
     ComplaintsInstance.Reasons, _
     ComplaintsInstance.Improve, _
     ComplaintsInstance.Hinding, _
     ComplaintsInstance.IsFinished, _
     ComplaintsInstance.Approved, _
     ComplaintsInstance.UnderTake, _
     ComplaintsInstance.Extend1, _
     ComplaintsInstance.Extend2, _
     ComplaintsInstance.Extend3, _
     ComplaintsInstance.Extend4, _
     ComplaintsInstance.Extend5, _
     ComplaintsInstance.RecordDeleted, _
     ComplaintsInstance.RecordCreated))
        Return (_ComplaintsInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ComplaintsInfo
		
			 Dim mInfo AS  new ComplaintsInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.RecordNO = IIf(dr.IsNull("RecordNO"), String.Empty, Convert.ToString(dr.Item("RecordNO")))
 			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.QyuLocation = IIf(dr.IsNull("QyuLocation"), String.Empty, Convert.ToString(dr.Item("QyuLocation")))
 			mInfo.ComlaintsPerson = IIf(dr.IsNull("ComlaintsPerson"), String.Empty, Convert.ToString(dr.Item("ComlaintsPerson")))
 			mInfo.ComplaintsDept = IIf(dr.IsNull("ComplaintsDept"), String.Empty, Convert.ToString(dr.Item("ComplaintsDept")))
 			mInfo.ComplaintsPosition = IIf(dr.IsNull("ComplaintsPosition"), String.Empty, Convert.ToString(dr.Item("ComplaintsPosition")))
 			mInfo.BeComplaintsDept = IIf(dr.IsNull("BeComplaintsDept"), String.Empty, Convert.ToString(dr.Item("BeComplaintsDept")))
 			mInfo.ComplaintsDate = IIf(dr.IsNull("ComplaintsDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ComplaintsDate")))
			mInfo.HopeFinishTime = IIf(dr.IsNull("HopeFinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("HopeFinishTime")))
			mInfo.Phone = IIf(dr.IsNull("Phone"), String.Empty, Convert.ToString(dr.Item("Phone")))
 			mInfo.Email = IIf(dr.IsNull("Email"), String.Empty, Convert.ToString(dr.Item("Email")))
 			mInfo.ComplaintsDesc = IIf(dr.IsNull("ComplaintsDesc"), String.Empty, Convert.ToString(dr.Item("ComplaintsDesc")))
 			mInfo.ComplaintsDetailed = IIf(dr.IsNull("ComplaintsDetailed"), String.Empty, Convert.ToString(dr.Item("ComplaintsDetailed")))
 			mInfo.Findings = IIf(dr.IsNull("Findings"), String.Empty, Convert.ToString(dr.Item("Findings")))
 			mInfo.Reasons = IIf(dr.IsNull("Reasons"), String.Empty, Convert.ToString(dr.Item("Reasons")))
 			mInfo.Improve = IIf(dr.IsNull("Improve"), String.Empty, Convert.ToString(dr.Item("Improve")))
 			mInfo.Hinding = IIf(dr.IsNull("Hinding"), String.Empty, Convert.ToString(dr.Item("Hinding")))
 			mInfo.IsFinished = IIf(dr.IsNull("IsFinished"), 0, Convert.ToInt32(dr.Item("IsFinished")))
			mInfo.Approved = IIf(dr.IsNull("Approved"), String.Empty, Convert.ToString(dr.Item("Approved")))
 			mInfo.UnderTake = IIf(dr.IsNull("UnderTake"), String.Empty, Convert.ToString(dr.Item("UnderTake")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
    Public Function Save() As Integer
        If Not _ComplaintsInstance Is Nothing Then
            If _ComplaintsInstance.PKID = 0 Then
                Return Insert()
            ElseIf _ComplaintsInstance.PKID > 0 Then
                Return Update()
            Else
                _ComplaintsInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the ComplaintsInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Complaints_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ComplaintsInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Complaints_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByDocUniqueID(ByVal DocUniqueID As String) As ComplaintsInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Complaints_GetInfoByeFlowDocID", DocUniqueID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ComplaintsInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Complaints_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mComplaints As New list(of Complaintsinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mComplaints.Add(TransformDr(dr))
            Next

            Return mComplaints
		
 	End Function
	#End Region
#End Region
End Class

