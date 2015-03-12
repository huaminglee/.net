#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  InternalAuditPlanandReportDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的InternalAuditPlanandReportInfo實例
        ''' </summary>
        ''' <param name="InternalAuditPlanandReportInstance">要操作的InternalAuditPlanandReportInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal InternalAuditPlanandReportInstance As InternalAuditPlanandReportInfo)
            _InternalAuditPlanandReportInstance = InternalAuditPlanandReportInstance
        End Sub
#End Region

#Region "屬性"
        Private _InternalAuditPlanandReportInstance As InternalAuditPlanandReportInfo

        ''' <summary>
        ''' InternalAuditPlanandReportInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>InternalAuditPlanandReportInfo</returns>
        ''' <remarks></remarks>
        Public Property InternalAuditPlanandReportInstance() As InternalAuditPlanandReportInfo
            Get
                Return _InternalAuditPlanandReportInstance
            End Get
            Set(ByVal Value As InternalAuditPlanandReportInfo)
                _InternalAuditPlanandReportInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "InternalAuditPlanandReport_Update", _
           				InternalAuditPlanandReportInstance.PKID, _
		InternalAuditPlanandReportInstance.RecordType, _
		InternalAuditPlanandReportInstance.RecordNO, _
		InternalAuditPlanandReportInstance.FormulDate, _
		InternalAuditPlanandReportInstance.Name, _
		InternalAuditPlanandReportInstance.Qulocation, _
		InternalAuditPlanandReportInstance.FormulDept, _
		InternalAuditPlanandReportInstance.FprmilUser, _
		InternalAuditPlanandReportInstance.Extend1, _
		InternalAuditPlanandReportInstance.Extend2, _
		InternalAuditPlanandReportInstance.Extend3, _
		InternalAuditPlanandReportInstance.Extend4, _
		InternalAuditPlanandReportInstance.RecordCreated, _
		InternalAuditPlanandReportInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _InternalAuditPlanandReportInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "InternalAuditPlanandReport_Insert", _
           				InternalAuditPlanandReportInstance.PKID, _
		InternalAuditPlanandReportInstance.RecordType, _
		InternalAuditPlanandReportInstance.RecordNO, _
		InternalAuditPlanandReportInstance.FormulDate, _
		InternalAuditPlanandReportInstance.Name, _
		InternalAuditPlanandReportInstance.Qulocation, _
		InternalAuditPlanandReportInstance.FormulDept, _
		InternalAuditPlanandReportInstance.FprmilUser, _
		InternalAuditPlanandReportInstance.Extend1, _
		InternalAuditPlanandReportInstance.Extend2, _
		InternalAuditPlanandReportInstance.Extend3, _
		InternalAuditPlanandReportInstance.Extend4, _
		InternalAuditPlanandReportInstance.RecordCreated, _
		InternalAuditPlanandReportInstance.RecordDeleted))
	 	Return  (_InternalAuditPlanandReportInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As InternalAuditPlanandReportInfo
		
			 Dim mInfo AS  new InternalAuditPlanandReportInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.RecordType = IIf(dr.IsNull("RecordType"), 0, Convert.ToInt32(dr.Item("RecordType")))
			mInfo.RecordNO = IIf(dr.IsNull("RecordNO"), String.Empty, Convert.ToString(dr.Item("RecordNO")))
 			mInfo.FormulDate = IIf(dr.IsNull("FormulDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FormulDate")))
			mInfo.Name = IIf(dr.IsNull("Name"), String.Empty, Convert.ToString(dr.Item("Name")))
 			mInfo.Qulocation = IIf(dr.IsNull("Qulocation"), String.Empty, Convert.ToString(dr.Item("Qulocation")))
 			mInfo.FormulDept = IIf(dr.IsNull("FormulDept"), String.Empty, Convert.ToString(dr.Item("FormulDept")))
 			mInfo.FprmilUser = IIf(dr.IsNull("FprmilUser"), String.Empty, Convert.ToString(dr.Item("FprmilUser")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _InternalAuditPlanandReportInstance Is Nothing Then 
            If _InternalAuditPlanandReportInstance.PKID=0  Then
                Return Insert()
            ElseIf _InternalAuditPlanandReportInstance.PKID > 0 Then
                    Return Update()
                Else
                   _InternalAuditPlanandReportInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the InternalAuditPlanandReportInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"InternalAuditPlanandReport_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As InternalAuditPlanandReportInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"InternalAuditPlanandReport_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of InternalAuditPlanandReportInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "InternalAuditPlanandReport_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mInternalAuditPlanandReport As New list(of InternalAuditPlanandReportinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mInternalAuditPlanandReport.Add(TransformDr(dr))
            Next

            Return mInternalAuditPlanandReport
		
 	End Function
	#End Region
#End Region
End Class

