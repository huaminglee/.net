#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QuotationDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的QuotationInfo實例
        ''' </summary>
        ''' <param name="QuotationInstance">要操作的QuotationInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QuotationInstance As QuotationInfo)
            _QuotationInstance = QuotationInstance
        End Sub
#End Region

#Region "屬性"
        Private _QuotationInstance As QuotationInfo

        ''' <summary>
        ''' QuotationInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>QuotationInfo</returns>
        ''' <remarks></remarks>
        Public Property QuotationInstance() As QuotationInfo
            Get
                Return _QuotationInstance
            End Get
            Set(ByVal Value As QuotationInfo)
                _QuotationInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Quotation_Update", _
           				QuotationInstance.PKID, _
		QuotationInstance.QuotationNO, _
		QuotationInstance.TestNO, _
		QuotationInstance.eFlowDocID, _
		QuotationInstance.StateName, _
		QuotationInstance.IsFinished, _
		QuotationInstance.FinishTime, _
		QuotationInstance.CustomerPKID, _
		QuotationInstance.StateOrder, _
		QuotationInstance.CustomerName, _
		QuotationInstance.TestCategory, _
		QuotationInstance.ContactName, _
		QuotationInstance.ContactPhone, _
		QuotationInstance.ContactEmail, _
		QuotationInstance.QuotaerName, _
		QuotationInstance.QuotaerPhone, _
		QuotationInstance.QuoteEmail, _
		QuotationInstance.QuoteDate, _
		QuotationInstance.FinishDate, _
		QuotationInstance.HopeFinishDATE, _
		QuotationInstance.Paijia, _
		QuotationInstance.Shijizongjia, _
		QuotationInstance.Extend01, _
		QuotationInstance.Extend02, _
		QuotationInstance.Extend03, _
		QuotationInstance.Extend04, _
		QuotationInstance.Extend05, _
		QuotationInstance.Extend06, _
		QuotationInstance.Extend07, _
		QuotationInstance.Extend08, _
		QuotationInstance.Extend09, _
		QuotationInstance.Extend10, _
		QuotationInstance.RecordCreated, _
		QuotationInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _QuotationInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Quotation_Insert", _
           				QuotationInstance.PKID, _
		QuotationInstance.QuotationNO, _
		QuotationInstance.TestNO, _
		QuotationInstance.eFlowDocID, _
		QuotationInstance.StateName, _
		QuotationInstance.IsFinished, _
		QuotationInstance.FinishTime, _
		QuotationInstance.CustomerPKID, _
		QuotationInstance.StateOrder, _
		QuotationInstance.CustomerName, _
		QuotationInstance.TestCategory, _
		QuotationInstance.ContactName, _
		QuotationInstance.ContactPhone, _
		QuotationInstance.ContactEmail, _
		QuotationInstance.QuotaerName, _
		QuotationInstance.QuotaerPhone, _
		QuotationInstance.QuoteEmail, _
		QuotationInstance.QuoteDate, _
		QuotationInstance.FinishDate, _
		QuotationInstance.HopeFinishDATE, _
		QuotationInstance.Paijia, _
		QuotationInstance.Shijizongjia, _
		QuotationInstance.Extend01, _
		QuotationInstance.Extend02, _
		QuotationInstance.Extend03, _
		QuotationInstance.Extend04, _
		QuotationInstance.Extend05, _
		QuotationInstance.Extend06, _
		QuotationInstance.Extend07, _
		QuotationInstance.Extend08, _
		QuotationInstance.Extend09, _
		QuotationInstance.Extend10, _
		QuotationInstance.RecordCreated, _
		QuotationInstance.RecordDeleted))
	 	Return  (_QuotationInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QuotationInfo
		
			 Dim mInfo AS  new QuotationInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.QuotationNO = IIf(dr.IsNull("QuotationNO"), String.Empty, Convert.ToString(dr.Item("QuotationNO")))
 			mInfo.TestNO = IIf(dr.IsNull("TestNO"), String.Empty, Convert.ToString(dr.Item("TestNO")))
 			mInfo.eFlowDocID = IIf(dr.IsNull("eFlowDocID"), Guid.Empty, New Guid(dr.Item("eFlowDocID").ToString))
			mInfo.StateName = IIf(dr.IsNull("StateName"), String.Empty, Convert.ToString(dr.Item("StateName")))
 			mInfo.IsFinished = IIf(dr.IsNull("IsFinished"), 0, Convert.ToInt32(dr.Item("IsFinished")))
			mInfo.FinishTime = IIf(dr.IsNull("FinishTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishTime")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.StateOrder = IIf(dr.IsNull("StateOrder"), 0, Convert.ToInt32(dr.Item("StateOrder")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.TestCategory = IIf(dr.IsNull("TestCategory"), 0, Convert.ToInt32(dr.Item("TestCategory")))
			mInfo.ContactName = IIf(dr.IsNull("ContactName"), String.Empty, Convert.ToString(dr.Item("ContactName")))
 			mInfo.ContactPhone = IIf(dr.IsNull("ContactPhone"), String.Empty, Convert.ToString(dr.Item("ContactPhone")))
 			mInfo.ContactEmail = IIf(dr.IsNull("ContactEmail"), String.Empty, Convert.ToString(dr.Item("ContactEmail")))
 			mInfo.QuotaerName = IIf(dr.IsNull("QuotaerName"), String.Empty, Convert.ToString(dr.Item("QuotaerName")))
 			mInfo.QuotaerPhone = IIf(dr.IsNull("QuotaerPhone"), String.Empty, Convert.ToString(dr.Item("QuotaerPhone")))
 			mInfo.QuoteEmail = IIf(dr.IsNull("QuoteEmail"), String.Empty, Convert.ToString(dr.Item("QuoteEmail")))
 			mInfo.QuoteDate = IIf(dr.IsNull("QuoteDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("QuoteDate")))
			mInfo.FinishDate = IIf(dr.IsNull("FinishDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("FinishDate")))
			mInfo.HopeFinishDATE = IIf(dr.IsNull("HopeFinishDATE"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("HopeFinishDATE")))
			mInfo.Paijia = IIf(dr.IsNull("Paijia"), 0, Convert.ToInt32(dr.Item("Paijia")))
        mInfo.Shijizongjia = IIf(dr.IsNull("Shijizongjia"), 0, CDbl(dr.Item("Shijizongjia")))
			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 			mInfo.Extend06 = IIf(dr.IsNull("Extend06"), String.Empty, Convert.ToString(dr.Item("Extend06")))
 			mInfo.Extend07 = IIf(dr.IsNull("Extend07"), String.Empty, Convert.ToString(dr.Item("Extend07")))
 			mInfo.Extend08 = IIf(dr.IsNull("Extend08"), String.Empty, Convert.ToString(dr.Item("Extend08")))
 			mInfo.Extend09 = IIf(dr.IsNull("Extend09"), String.Empty, Convert.ToString(dr.Item("Extend09")))
 			mInfo.Extend10 = IIf(dr.IsNull("Extend10"), String.Empty, Convert.ToString(dr.Item("Extend10")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _QuotationInstance Is Nothing Then 
            If _QuotationInstance.PKID=0  Then
                Return Insert()
            ElseIf _QuotationInstance.PKID > 0 Then
                    Return Update()
                Else
                   _QuotationInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the QuotationInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Quotation_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QuotationInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Quotation_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByeFLowdocID(ByVal eFLowdocID As String) As QuotationInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetInfoByeeFLowdocID", eFLowdocID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QuotationInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQuotation As New list(of Quotationinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQuotation.Add(TransformDr(dr))
            Next

            Return mQuotation
		
    End Function
    Public Shared Function GetExpenseByQuotationPKID(ByVal QuotationPKID As Integer) As String
        Dim paijiaandshiji As String = String.Empty
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetExpenseByQuotationPKID", QuotationPKID)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim dr As DataRow = dt.Rows(0)
        Dim paijia As String = dr.Item("Paijia").ToString
        Dim shiji As String = dr.Item("Shijizongjia").ToString
        Dim CBjia As String = dr.Item("CBjia").ToString
        paijiaandshiji = paijia.ToString + "$" + shiji.ToString + "&" + CBjia

        Dim dt2 As DataTable = ds.Tables(1)
        If dt2.Rows.Count > 0 Then
            Dim dr2 As DataRow = dt2.Rows(0)
            Dim Minyouhui As String = dr2.Item("minyouhui").ToString
            paijiaandshiji += "#" + Minyouhui
        End If

        Return paijiaandshiji
    End Function
    Public Shared Function GetHisByCustomerPKID(ByVal CustomerPKID As Integer) As String
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Quotation_GetCountAndSumExpenseByCustomerPKID", CustomerPKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return dr.Item("cishu").ToString + "次，交易額：" + dr.Item("zongqian").ToString
    End Function
    Public Shared Function GetTestapplyEflowdocidByPkid(ByVal applypkid As Integer) As String
        Dim eflowdocid As String
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TestApplyManage_GetEflowDocidBypkid", applypkid)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        eflowdocid = dt.Rows(0).Item("eFlowDocID").ToString
        Return eflowdocid
    End Function
    Public Shared Function CopyQuotation(ByVal PKID As Integer) As Integer
        Dim NewQuotationPKID As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                          "QuotationInfo_COPY", PKID))
        Return NewQuotationPKID

    End Function
    Public Shared Function TransFotReport(ByVal pkid As Integer) As DataSet1
        'Dim ReDs As DataSet1 = New DataSet1()
        'Dim DtQuotation As DataTable = ReDs.Tables("Quotation")
        'Dim DtSampleInfo As DataTable = ReDs.Tables("SampleInfo")
        'Dim DtTestItemDetail As DataTable = ReDs.Tables("TestItemDetail")

        'Dim cquotationinfo As QuotationInfo = QuotationDAL.GetInfoByPKID(pkid)
        Dim myConnection As New SqlClient.SqlConnection()
        myConnection.ConnectionString = ConfigurationInfo.ConnectionString
        Dim MyCommand As New SqlClient.SqlCommand()
        MyCommand.Connection = myConnection
        MyCommand.CommandText = "select * from Quotation where PKID= " + pkid.ToString
        MyCommand.CommandType = CommandType.Text
        Dim MyDA As New SqlClient.SqlDataAdapter()
        MyDA.SelectCommand = MyCommand
        Dim myDS As New DataSet1() 
        MyDA.Fill(myDS, "Quotation")

        MyCommand.CommandText = "select * from SampleInfo where QuotationPKID =" + pkid.ToString
        Dim MyDA2 As New SqlClient.SqlDataAdapter()
        MyDA2.SelectCommand = MyCommand
        MyDA2.Fill(myDS, "SampleInfo")


        MyCommand.CommandText = "select * from TestItemDetail where (RecordDeleted =0 or RecordDeleted =2) and QuotationPKID =" + pkid.ToString
        Dim MyDA3 As New SqlClient.SqlDataAdapter()
        MyDA3.SelectCommand = MyCommand
        MyDA3.Fill(myDS, "TestItemDetail")


        Return myDS

    End Function
    Public Shared Function TransForReconcield(ByVal Searchcondition As String) As DataSet2
        Dim myConnection As New SqlClient.SqlConnection()
        myConnection.ConnectionString = ConfigurationInfo.ConnectionString
        Dim MyCommand As New SqlClient.SqlCommand()
        MyCommand.Connection = myConnection
        MyCommand.CommandText = "select convert(int, ROW_NUMBER() OVER(ORDER BY QuotationNO DESC)) AS XH,* from View_Reconcield where  " + Searchcondition
        MyCommand.CommandType = CommandType.Text
        Dim MyDA As New SqlClient.SqlDataAdapter()
        MyDA.SelectCommand = MyCommand
        Dim myDS As New DataSet2()
        MyDA.Fill(myDS, "View_Reconcield")
        Return myDS
    End Function
    Public Shared Sub UpdateFinishTimeByPKID(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "Quotation_UpFinishTimeByPKID", PKID)

    End Sub

#End Region

#End Region
End Class

