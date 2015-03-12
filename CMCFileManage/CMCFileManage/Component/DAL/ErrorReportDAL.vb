#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ErrorReportDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ErrorReportInfo實例
        ''' </summary>
        ''' <param name="ErrorReportInstance">要操作的ErrorReportInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ErrorReportInstance As ErrorReportInfo)
            _ErrorReportInstance = ErrorReportInstance
        End Sub
#End Region

#Region "屬性"
        Private _ErrorReportInstance As ErrorReportInfo

        ''' <summary>
        ''' ErrorReportInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ErrorReportInfo</returns>
        ''' <remarks></remarks>
        Public Property ErrorReportInstance() As ErrorReportInfo
            Get
                Return _ErrorReportInstance
            End Get
            Set(ByVal Value As ErrorReportInfo)
                _ErrorReportInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "ErrorReport_Update", _
                    ErrorReportInstance.PKID, _
       ErrorReportInstance.ReportBH, _
       ErrorReportInstance.Dept, _
       ErrorReportInstance.Qulocation, _
       ErrorReportInstance.Aduiter, _
       ErrorReportInstance.Follower, _
       ErrorReportInstance.SpecTitle, _
       ErrorReportInstance.SpecVersion, _
       ErrorReportInstance.ReportDate, _
       ErrorReportInstance.AppSec, _
       ErrorReportInstance.Description, _
       ErrorReportInstance.FindOut, _
       ErrorReportInstance.Reason, _
       ErrorReportInstance.FinishTime, _
       ErrorReportInstance.Ready, _
       ErrorReportInstance.Approvedzg, _
       ErrorReportInstance.FinishAduit, _
       ErrorReportInstance.VertifyResult, _
       ErrorReportInstance.Result, _
       ErrorReportInstance.Approved, _
       ErrorReportInstance.Vertigyer, _
       ErrorReportInstance.Extend1, _
       ErrorReportInstance.Extend2, _
       ErrorReportInstance.Extend3, _
       ErrorReportInstance.Extend4, _
       ErrorReportInstance.Extend5, _
       ErrorReportInstance.RecordCreated, _
       ErrorReportInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _ErrorReportInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "ErrorReport_Insert", _
                  ErrorReportInstance.PKID, _
     ErrorReportInstance.ReportBH, _
     ErrorReportInstance.Dept, _
     ErrorReportInstance.Qulocation, _
     ErrorReportInstance.Aduiter, _
     ErrorReportInstance.Follower, _
     ErrorReportInstance.SpecTitle, _
     ErrorReportInstance.SpecVersion, _
     ErrorReportInstance.ReportDate, _
     ErrorReportInstance.AppSec, _
     ErrorReportInstance.Description, _
     ErrorReportInstance.FindOut, _
     ErrorReportInstance.Reason, _
     ErrorReportInstance.FinishTime, _
     ErrorReportInstance.Ready, _
     ErrorReportInstance.Approvedzg, _
     ErrorReportInstance.FinishAduit, _
     ErrorReportInstance.VertifyResult, _
     ErrorReportInstance.Result, _
     ErrorReportInstance.Approved, _
     ErrorReportInstance.Vertigyer, _
     ErrorReportInstance.Extend1, _
     ErrorReportInstance.Extend2, _
     ErrorReportInstance.Extend3, _
     ErrorReportInstance.Extend4, _
     ErrorReportInstance.Extend5, _
     ErrorReportInstance.RecordCreated, _
     ErrorReportInstance.RecordDeleted))
        Return (_ErrorReportInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ErrorReportInfo
		
			 Dim mInfo AS  new ErrorReportInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.ReportBH = IIf(dr.IsNull("ReportBH"), String.Empty, Convert.ToString(dr.Item("ReportBH")))
 			mInfo.Dept = IIf(dr.IsNull("Dept"), String.Empty, Convert.ToString(dr.Item("Dept")))
 			mInfo.Qulocation = IIf(dr.IsNull("Qulocation"), String.Empty, Convert.ToString(dr.Item("Qulocation")))
 			mInfo.Aduiter = IIf(dr.IsNull("Aduiter"), String.Empty, Convert.ToString(dr.Item("Aduiter")))
 			mInfo.Follower = IIf(dr.IsNull("Follower"), String.Empty, Convert.ToString(dr.Item("Follower")))
 			mInfo.SpecTitle = IIf(dr.IsNull("SpecTitle"), String.Empty, Convert.ToString(dr.Item("SpecTitle")))
 			mInfo.SpecVersion = IIf(dr.IsNull("SpecVersion"), String.Empty, Convert.ToString(dr.Item("SpecVersion")))
 			mInfo.ReportDate = IIf(dr.IsNull("ReportDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ReportDate")))
			mInfo.AppSec = IIf(dr.IsNull("AppSec"), 0, Convert.ToInt32(dr.Item("AppSec")))
			mInfo.Description = IIf(dr.IsNull("Description"), String.Empty, Convert.ToString(dr.Item("Description")))
 			mInfo.FindOut = IIf(dr.IsNull("FindOut"), String.Empty, Convert.ToString(dr.Item("FindOut")))
 			mInfo.Reason = IIf(dr.IsNull("Reason"), String.Empty, Convert.ToString(dr.Item("Reason")))
 			mInfo.FinishTime = IIf(dr.IsNull("FinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishTime")))
			mInfo.Ready = IIf(dr.IsNull("Ready"), String.Empty, Convert.ToString(dr.Item("Ready")))
 			mInfo.Approvedzg = IIf(dr.IsNull("Approvedzg"), String.Empty, Convert.ToString(dr.Item("Approvedzg")))
 			mInfo.FinishAduit = IIf(dr.IsNull("FinishAduit"), String.Empty, Convert.ToString(dr.Item("FinishAduit")))
 			mInfo.VertifyResult = IIf(dr.IsNull("VertifyResult"), 0, Convert.ToInt32(dr.Item("VertifyResult")))
			mInfo.Result = IIf(dr.IsNull("Result"), String.Empty, Convert.ToString(dr.Item("Result")))
 			mInfo.Approved = IIf(dr.IsNull("Approved"), String.Empty, Convert.ToString(dr.Item("Approved")))
 			mInfo.Vertigyer = IIf(dr.IsNull("Vertigyer"), String.Empty, Convert.ToString(dr.Item("Vertigyer")))
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
    Public Function Save() As Integer
        If Not _ErrorReportInstance Is Nothing Then
            If _ErrorReportInstance.PKID = 0 Then
                Return Insert()
            ElseIf _ErrorReportInstance.PKID > 0 Then
                Return Update()
            Else
                _ErrorReportInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the ErrorReportInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"ErrorReport_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ErrorReportInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"ErrorReport_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ErrorReportInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ErrorReport_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mErrorReport As New list(of ErrorReportinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mErrorReport.Add(TransformDr(dr))
            Next

            Return mErrorReport
		
    End Function
    Public Shared Function GetDeptBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ErrorReport_GetDeptBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetQyBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ErrorReport_GetQyBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetEquipBySearchcondition(ByVal Searchcondition As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "ErrorReport_GetfileBySearchcondition", Searchcondition)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
	#End Region
#End Region
End Class

