#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  CustomersDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的CustomersInfo實例
        ''' </summary>
        ''' <param name="CustomersInstance">要操作的CustomersInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal CustomersInstance As CustomersInfo)
            _CustomersInstance = CustomersInstance
        End Sub
#End Region

#Region "屬性"
        Private _CustomersInstance As CustomersInfo

        ''' <summary>
        ''' CustomersInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>CustomersInfo</returns>
        ''' <remarks></remarks>
        Public Property CustomersInstance() As CustomersInfo
            Get
                Return _CustomersInstance
            End Get
            Set(ByVal Value As CustomersInfo)
                _CustomersInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "Customers_Update", _
                    CustomersInstance.PKID, _
       CustomersInstance.InsertPsrson, _
       CustomersInstance.CustomerName, _
       CustomersInstance.CustomerID, _
       CustomersInstance.CustomerAlias, _
       CustomersInstance.CustomerEnglishName, _
       CustomersInstance.Category, _
       CustomersInstance.PersonInCharge, _
       CustomersInstance.Managers, _
       CustomersInstance.Grade, _
       CustomersInstance.TypeofPay, _
       CustomersInstance.Industry, _
       CustomersInstance.Status, _
       CustomersInstance.Source, _
       CustomersInstance.City, _
       CustomersInstance.ZipCode, _
       CustomersInstance.Phone, _
       CustomersInstance.Fax, _
       CustomersInstance.Email, _
       CustomersInstance.WebAddress, _
       CustomersInstance.Address, _
       CustomersInstance.ZhuceCapital, _
       CustomersInstance.EmployeeNum, _
       CustomersInstance.Bank, _
       CustomersInstance.BankAccount, _
       CustomersInstance.AccountName, _
       CustomersInstance.BillingName, _
       CustomersInstance.VATNum, _
       CustomersInstance.Remark, _
       CustomersInstance.Extend1, _
       CustomersInstance.Extend2, _
       CustomersInstance.Extend3, _
       CustomersInstance.Extend4, _
       CustomersInstance.Extend5, _
       CustomersInstance.Extend6, _
       CustomersInstance.Extend7, _
       CustomersInstance.Extend8, _
       CustomersInstance.Extend9, _
       CustomersInstance.Extend10, _
       CustomersInstance.RecordCreated, _
       CustomersInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _CustomersInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "Customers_Insert", _
                  CustomersInstance.PKID, _
     CustomersInstance.InsertPsrson, _
     CustomersInstance.CustomerName, _
     CustomersInstance.CustomerID, _
     CustomersInstance.CustomerAlias, _
     CustomersInstance.CustomerEnglishName, _
     CustomersInstance.Category, _
     CustomersInstance.PersonInCharge, _
     CustomersInstance.Managers, _
     CustomersInstance.Grade, _
     CustomersInstance.TypeofPay, _
     CustomersInstance.Industry, _
     CustomersInstance.Status, _
     CustomersInstance.Source, _
     CustomersInstance.City, _
     CustomersInstance.ZipCode, _
     CustomersInstance.Phone, _
     CustomersInstance.Fax, _
     CustomersInstance.Email, _
     CustomersInstance.WebAddress, _
     CustomersInstance.Address, _
     CustomersInstance.ZhuceCapital, _
     CustomersInstance.EmployeeNum, _
     CustomersInstance.Bank, _
     CustomersInstance.BankAccount, _
     CustomersInstance.AccountName, _
     CustomersInstance.BillingName, _
     CustomersInstance.VATNum, _
     CustomersInstance.Remark, _
     CustomersInstance.Extend1, _
     CustomersInstance.Extend2, _
     CustomersInstance.Extend3, _
     CustomersInstance.Extend4, _
     CustomersInstance.Extend5, _
     CustomersInstance.Extend6, _
     CustomersInstance.Extend7, _
     CustomersInstance.Extend8, _
     CustomersInstance.Extend9, _
     CustomersInstance.Extend10, _
     CustomersInstance.RecordCreated, _
     CustomersInstance.RecordDeleted))
        Return (_CustomersInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As CustomersInfo
		
			 Dim mInfo AS  new CustomersInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.InsertPsrson = IIf(dr.IsNull("InsertPsrson"), String.Empty, Convert.ToString(dr.Item("InsertPsrson")))
 			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.CustomerID = IIf(dr.IsNull("CustomerID"), String.Empty, Convert.ToString(dr.Item("CustomerID")))
 			mInfo.CustomerAlias = IIf(dr.IsNull("CustomerAlias"), String.Empty, Convert.ToString(dr.Item("CustomerAlias")))
 			mInfo.CustomerEnglishName = IIf(dr.IsNull("CustomerEnglishName"), String.Empty, Convert.ToString(dr.Item("CustomerEnglishName")))
 			mInfo.Category = IIf(dr.IsNull("Category"), 0, Convert.ToInt32(dr.Item("Category")))
			mInfo.PersonInCharge = IIf(dr.IsNull("PersonInCharge"), String.Empty, Convert.ToString(dr.Item("PersonInCharge")))
 			mInfo.Managers = IIf(dr.IsNull("Managers"), String.Empty, Convert.ToString(dr.Item("Managers")))
 			mInfo.Grade = IIf(dr.IsNull("Grade"), String.Empty, Convert.ToString(dr.Item("Grade")))
 			mInfo.TypeofPay = IIf(dr.IsNull("TypeofPay"), 0, Convert.ToInt32(dr.Item("TypeofPay")))
			mInfo.Industry = IIf(dr.IsNull("Industry"), String.Empty, Convert.ToString(dr.Item("Industry")))
 			mInfo.Status = IIf(dr.IsNull("Status"), 0, Convert.ToInt32(dr.Item("Status")))
			mInfo.Source = IIf(dr.IsNull("Source"), String.Empty, Convert.ToString(dr.Item("Source")))
 			mInfo.City = IIf(dr.IsNull("City"), String.Empty, Convert.ToString(dr.Item("City")))
 			mInfo.ZipCode = IIf(dr.IsNull("ZipCode"), 0, Convert.ToInt32(dr.Item("ZipCode")))
			mInfo.Phone = IIf(dr.IsNull("Phone"), String.Empty, Convert.ToString(dr.Item("Phone")))
 			mInfo.Fax = IIf(dr.IsNull("Fax"), String.Empty, Convert.ToString(dr.Item("Fax")))
 			mInfo.Email = IIf(dr.IsNull("Email"), String.Empty, Convert.ToString(dr.Item("Email")))
 			mInfo.WebAddress = IIf(dr.IsNull("WebAddress"), String.Empty, Convert.ToString(dr.Item("WebAddress")))
 			mInfo.Address = IIf(dr.IsNull("Address"), String.Empty, Convert.ToString(dr.Item("Address")))
 			mInfo.ZhuceCapital = IIf(dr.IsNull("ZhuceCapital"), 0, Convert.ToInt32(dr.Item("ZhuceCapital")))
			mInfo.EmployeeNum = IIf(dr.IsNull("EmployeeNum"), 0, Convert.ToInt32(dr.Item("EmployeeNum")))
			mInfo.Bank = IIf(dr.IsNull("Bank"), String.Empty, Convert.ToString(dr.Item("Bank")))
 			mInfo.BankAccount = IIf(dr.IsNull("BankAccount"), String.Empty, Convert.ToString(dr.Item("BankAccount")))
 			mInfo.AccountName = IIf(dr.IsNull("AccountName"), String.Empty, Convert.ToString(dr.Item("AccountName")))
 			mInfo.BillingName = IIf(dr.IsNull("BillingName"), String.Empty, Convert.ToString(dr.Item("BillingName")))
 			mInfo.VATNum = IIf(dr.IsNull("VATNum"), String.Empty, Convert.ToString(dr.Item("VATNum")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
 			mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
 			mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
 			mInfo.Extend6 = IIf(dr.IsNull("Extend6"), String.Empty, Convert.ToString(dr.Item("Extend6")))
 			mInfo.Extend7 = IIf(dr.IsNull("Extend7"), String.Empty, Convert.ToString(dr.Item("Extend7")))
 			mInfo.Extend8 = IIf(dr.IsNull("Extend8"), String.Empty, Convert.ToString(dr.Item("Extend8")))
 			mInfo.Extend9 = IIf(dr.IsNull("Extend9"), String.Empty, Convert.ToString(dr.Item("Extend9")))
 			mInfo.Extend10 = IIf(dr.IsNull("Extend10"), String.Empty, Convert.ToString(dr.Item("Extend10")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
    Public Function Save() As Integer
        If Not _CustomersInstance Is Nothing Then
            If _CustomersInstance.PKID = 0 Then
                Return Insert()
            ElseIf _CustomersInstance.PKID > 0 Then
                Return Update()
            Else
                _CustomersInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the CustomersInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Customers_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As CustomersInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Customers_GetInfoByPKID", PKID)
            Dim dt As DataTable = ds.Tables(0)

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim dr As DataRow = dt.Rows(0)

            Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByCustomername(ByVal Name As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetInfoByCustomerName", Name)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing

        End If
        Return ds
    End Function

	    ''' <summary>
    ''' 獲取指定條件的記錄
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of CustomersInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mCustomers As New list(of Customersinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mCustomers.Add(TransformDr(dr))
            Next

            Return mCustomers
		
    End Function
    Public Shared Function GetMaxIDByType(ByVal Type As String) As Integer
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetMaxID", Type)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        If ds.Tables(0).Rows(0).IsNull("maxid") Then
            Return 0
        Else
            Return Convert.ToInt32(ds.Tables(0).Rows(0).Item("maxid"))
        End If
    End Function
    Public Shared Function GetAllCustomer() As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetAllCustomer")
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetCustomerByPersonIncharge(ByVal personincharge As String) As List(Of DictionaryEntry)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetCustomerByPersonIncharge", personincharge)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("PKID").ToString + "$" + dr.Item("Grade").ToString + "$" + dr.Item("TypeofPay").ToString, dr.Item("CustomerName")))
        Next
        Return mList

    End Function
    Public Shared Function GetCustomerandPersonIncharge() As List(Of DictionaryEntry)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetCustomerandPersonIncharge")
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("PKID").ToString + "$" + dr.Item("PersonInCharge").ToString + "#" + dr.Item("Email").ToString + "￥" + dr.Item("UserSID").ToString, dr.Item("CustomerName")))
        Next
        Return mList

    End Function
    Public Shared Function GetTestHistoryBySearchCondition(ByVal SearchCondition As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_GetTestHistoryByCondition", SearchCondition)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetTestHistoryByTestItemPKID(ByVal TestItemPKID As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_GetTestHistoryByTestItemPKID", TestItemPKID)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetTestHistoryByTestItemName(ByVal TestItemName As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "View_TestHistory_GetTestHistoryByTestItemName", TestItemName)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Sub SetPersoninchargenull(ByVal CustomerPKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "Customers_SetPersoninchargenull", CustomerPKID)
    End Sub
    Public Shared Function GetAllCanAddCustomers(ByVal marketplanpkid As Integer, ByVal perincharge As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetAllCanAddCustomers", marketplanpkid, perincharge)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds

    End Function
    Public Shared Function GetAllCustomerdic() As List(Of DictionaryEntry)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Customers_GetAllCustomer")
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("PKID").ToString, dr.Item("CustomerName")))
        Next
        Return mList

    End Function
#End Region

#End Region
End Class

