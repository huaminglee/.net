#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  MarkOppContactDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的MarkOppContactInfo實例
        ''' </summary>
        ''' <param name="MarkOppContactInstance">要操作的MarkOppContactInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal MarkOppContactInstance As MarkOppContactInfo)
            _MarkOppContactInstance = MarkOppContactInstance
        End Sub
#End Region

#Region "屬性"
        Private _MarkOppContactInstance As MarkOppContactInfo

        ''' <summary>
        ''' MarkOppContactInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>MarkOppContactInfo</returns>
        ''' <remarks></remarks>
        Public Property MarkOppContactInstance() As MarkOppContactInfo
            Get
                Return _MarkOppContactInstance
            End Get
            Set(ByVal Value As MarkOppContactInfo)
                _MarkOppContactInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarkOppContact_Update", _
           				MarkOppContactInstance.PKID, _
		MarkOppContactInstance.MarkPlanPKID, _
		MarkOppContactInstance.BusOppPKID, _
		MarkOppContactInstance.Extend1, _
		MarkOppContactInstance.Extend2, _
		MarkOppContactInstance.Extend3, _
		MarkOppContactInstance.Extend4, _
		MarkOppContactInstance.Extend5, _
		MarkOppContactInstance.Extend6, _
		MarkOppContactInstance.Extend7, _
		MarkOppContactInstance.Extend8, _
		MarkOppContactInstance.Extend9, _
		MarkOppContactInstance.Extend10, _
		MarkOppContactInstance.RecordCreated, _
		MarkOppContactInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _MarkOppContactInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "MarkOppContact_Insert", _
           				MarkOppContactInstance.PKID, _
		MarkOppContactInstance.MarkPlanPKID, _
		MarkOppContactInstance.BusOppPKID, _
		MarkOppContactInstance.Extend1, _
		MarkOppContactInstance.Extend2, _
		MarkOppContactInstance.Extend3, _
		MarkOppContactInstance.Extend4, _
		MarkOppContactInstance.Extend5, _
		MarkOppContactInstance.Extend6, _
		MarkOppContactInstance.Extend7, _
		MarkOppContactInstance.Extend8, _
		MarkOppContactInstance.Extend9, _
		MarkOppContactInstance.Extend10, _
		MarkOppContactInstance.RecordCreated, _
		MarkOppContactInstance.RecordDeleted))
	 	Return  (_MarkOppContactInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As MarkOppContactInfo
		
			 Dim mInfo AS  new MarkOppContactInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.MarkPlanPKID = IIf(dr.IsNull("MarkPlanPKID"), 0, Convert.ToInt32(dr.Item("MarkPlanPKID")))
			mInfo.BusOppPKID = IIf(dr.IsNull("BusOppPKID"), 0, Convert.ToInt32(dr.Item("BusOppPKID")))
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
	     Public Function Save() As Boolean
	If Not _MarkOppContactInstance Is Nothing Then 
            If _MarkOppContactInstance.PKID=0  Then
                Return Insert()
            ElseIf _MarkOppContactInstance.PKID > 0 Then
                    Return Update()
                Else
                   _MarkOppContactInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the MarkOppContactInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"MarkOppContact_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As MarkOppContactInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"MarkOppContact_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of MarkOppContactInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarkOppContact_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mMarkOppContact As New list(of MarkOppContactinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mMarkOppContact.Add(TransformDr(dr))
            Next

            Return mMarkOppContact
		
    End Function
    Public Shared Sub DeleteByBusPKID(ByVal Buspkid As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "MarkOppContact_DeleteByBusPKID", Buspkid)
    End Sub
    Public Shared Sub AddContact(ByVal matkpkid As Integer, ByVal BusPKID As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "mARKoPPcONTACT_AddContact", matkpkid, BusPKID)
    End Sub
    Public Shared Sub AddContactForBussopp(ByVal BussOppPKID As Integer, ByVal MarkPlanPKIDS As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "MarkOppContact_AddContactForBuss", BussOppPKID, MarkPlanPKIDS)
    End Sub
    Public Shared Function GetDSByBussOPPpkid(ByVal bussopppkid As Integer) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "MarkOppContact_GetdsByBusOppPKID", bussopppkid)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds
        End If
        Return Nothing
    End Function
	#End Region
#End Region
End Class

