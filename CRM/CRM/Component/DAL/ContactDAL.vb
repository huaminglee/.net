#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ContactDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ContactInfo實例
        ''' </summary>
        ''' <param name="ContactInstance">要操作的ContactInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ContactInstance As ContactInfo)
            _ContactInstance = ContactInstance
        End Sub
#End Region

#Region "屬性"
        Private _ContactInstance As ContactInfo

        ''' <summary>
        ''' ContactInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ContactInfo</returns>
        ''' <remarks></remarks>
        Public Property ContactInstance() As ContactInfo
            Get
                Return _ContactInstance
            End Get
            Set(ByVal Value As ContactInfo)
                _ContactInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

    Private Function Update() As Integer
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "Contact_Update", _
                    ContactInstance.PKID, _
       ContactInstance.UserSID, _
       ContactInstance.UserName, _
       ContactInstance.ContactCategory, _
       ContactInstance.CusTomerPKID, _
       ContactInstance.CustomerName, _
       ContactInstance.Position, _
       ContactInstance.Photo, _
       ContactInstance.Address, _
       ContactInstance.IDnumber, _
       ContactInstance.Birthday, _
       ContactInstance.Sex, _
       ContactInstance.ZIPcode, _
       ContactInstance.Graduated, _
       ContactInstance.Degree, _
       ContactInstance.Major, _
       ContactInstance.Remark, _
       ContactInstance.Extend1, _
       ContactInstance.Extend2, _
       ContactInstance.Extend3, _
       ContactInstance.Extend4, _
       ContactInstance.Extend5, _
       ContactInstance.Extend6, _
       ContactInstance.Extend7, _
       ContactInstance.Extend8, _
       ContactInstance.Extend9, _
       ContactInstance.Extend10, _
       ContactInstance.RecordCreated, _
       ContactInstance.RecordDeleted))
        Return Result
    End Function

    Private Function Insert() As Integer
        _ContactInstance.PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                            "Contact_Insert", _
                  ContactInstance.PKID, _
     ContactInstance.UserSID, _
     ContactInstance.UserName, _
     ContactInstance.ContactCategory, _
     ContactInstance.CusTomerPKID, _
     ContactInstance.CustomerName, _
     ContactInstance.Position, _
     ContactInstance.Photo, _
     ContactInstance.Address, _
     ContactInstance.IDnumber, _
     ContactInstance.Birthday, _
     ContactInstance.Sex, _
     ContactInstance.ZIPcode, _
     ContactInstance.Graduated, _
     ContactInstance.Degree, _
     ContactInstance.Major, _
     ContactInstance.Remark, _
     ContactInstance.Extend1, _
     ContactInstance.Extend2, _
     ContactInstance.Extend3, _
     ContactInstance.Extend4, _
     ContactInstance.Extend5, _
     ContactInstance.Extend6, _
     ContactInstance.Extend7, _
     ContactInstance.Extend8, _
     ContactInstance.Extend9, _
     ContactInstance.Extend10, _
     ContactInstance.RecordCreated, _
     ContactInstance.RecordDeleted))
        Return (_ContactInstance.PKID)
    End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ContactInfo
		
			 Dim mInfo AS  new ContactInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.UserSID = IIf(dr.IsNull("UserSID"), String.Empty, Convert.ToString(dr.Item("UserSID")))
 			mInfo.UserName = IIf(dr.IsNull("UserName"), String.Empty, Convert.ToString(dr.Item("UserName")))
 			mInfo.ContactCategory = IIf(dr.IsNull("ContactCategory"), 0, Convert.ToInt32(dr.Item("ContactCategory")))
			mInfo.CusTomerPKID = IIf(dr.IsNull("CusTomerPKID"), 0, Convert.ToInt32(dr.Item("CusTomerPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.Position = IIf(dr.IsNull("Position"), String.Empty, Convert.ToString(dr.Item("Position")))
 			mInfo.Photo = IIf(dr.IsNull("Photo"), String.Empty, Convert.ToString(dr.Item("Photo")))
 			mInfo.Address = IIf(dr.IsNull("Address"), String.Empty, Convert.ToString(dr.Item("Address")))
 			mInfo.IDnumber = IIf(dr.IsNull("IDnumber"), String.Empty, Convert.ToString(dr.Item("IDnumber")))
 			mInfo.Birthday = IIf(dr.IsNull("Birthday"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("Birthday")))
			mInfo.Sex = IIf(dr.IsNull("Sex"), 0, Convert.ToInt32(dr.Item("Sex")))
			mInfo.ZIPcode = IIf(dr.IsNull("ZIPcode"), 0, Convert.ToInt32(dr.Item("ZIPcode")))
			mInfo.Graduated = IIf(dr.IsNull("Graduated"), String.Empty, Convert.ToString(dr.Item("Graduated")))
 			mInfo.Degree = IIf(dr.IsNull("Degree"), String.Empty, Convert.ToString(dr.Item("Degree")))
 			mInfo.Major = IIf(dr.IsNull("Major"), String.Empty, Convert.ToString(dr.Item("Major")))
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
        If Not _ContactInstance Is Nothing Then
            If _ContactInstance.PKID = 0 Then
                Return Insert()
            ElseIf _ContactInstance.PKID > 0 Then
                Return Update()
            Else
                _ContactInstance.PKID = 0
                Return False
            End If
        Else
            Dim ex As New Exception("Please set the ContactInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Contact_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ContactInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Contact_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ContactInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mContact As New list(of Contactinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mContact.Add(TransformDr(dr))
            Next

            Return mContact
		
    End Function
    Public Shared Function GetCustomerPKIDByUserSID(ByVal usersid As String) As Integer
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetCustomerPKIDByUserSID", usersid)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return Convert.ToInt32(ds.Tables(0).Rows(0).Item("CusTomerPKID"))
    End Function

    Public Shared Function GetContactPKIDByContactName(ByVal Name As String) As String
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetContactPKIDByName", Name)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim PKIDS As String = String.Empty
        Dim i As Integer
        If dt.Rows.Count = 0 Then
            Return 0
        Else
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                PKIDS += dr.Item("PKID").ToString + "、"
            Next
        End If
        Return PKIDS.Substring(0, PKIDS.Length - 1)
    End Function
    Public Shared Function GetInfoByUserSID(ByVal usersid As String) As ContactInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetInfoByUserSid", usersid)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return New ContactInfo()
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByContactName(ByVal ContactName As String) As ContactInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetInfoByContactName", ContactName)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return New ContactInfo()
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetdsByContactName(ByVal name As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetdsByName", name)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return ds
    End Function
    Public Shared Function GetContactByCustomerPKID(ByVal CustomerPKID As Integer) As List(Of DictionaryEntry)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetContactByCustomerPKID", CustomerPKID)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            If dr.Item("UserSID").ToString.Trim = String.Empty Then
                mList.Add(New DictionaryEntry(dr.Item("Extend1").ToString + "$" + dr.Item("Extend4") + "&000000#" + dr.Item("Extend3") + "*" + dr.Item("pkid").ToString, dr.Item("UserName")))
            Else
                mList.Add(New DictionaryEntry(dr.Item("Extend1").ToString + "$" + dr.Item("Extend4") + "&" + dr.Item("UserSID") + "#" + dr.Item("Extend3") + "*" + dr.Item("pkid").ToString, dr.Item("UserName")))
            End If

        Next
        Return mList

    End Function
    Public Shared Function Contact_GetInfoByContactID(ByVal ContactID As String) As ContactInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Contact_GetInfoByContactID", ContactID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return New ContactInfo()
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
	#End Region
#End Region
End Class

