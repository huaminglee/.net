#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  InvalidQuotationDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的InvalidQuotationInfo實例
        ''' </summary>
        ''' <param name="InvalidQuotationInstance">要操作的InvalidQuotationInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal InvalidQuotationInstance As InvalidQuotationInfo)
            _InvalidQuotationInstance = InvalidQuotationInstance
        End Sub
#End Region

#Region "屬性"
        Private _InvalidQuotationInstance As InvalidQuotationInfo

        ''' <summary>
        ''' InvalidQuotationInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>InvalidQuotationInfo</returns>
        ''' <remarks></remarks>
        Public Property InvalidQuotationInstance() As InvalidQuotationInfo
            Get
                Return _InvalidQuotationInstance
            End Get
            Set(ByVal Value As InvalidQuotationInfo)
                _InvalidQuotationInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "InvalidQuotation_Update", _
           				InvalidQuotationInstance.PKID, _
		InvalidQuotationInstance.QuotationPKID, _
		InvalidQuotationInstance.ReporDetailPKID, _
		InvalidQuotationInstance.AddUserID, _
		InvalidQuotationInstance.ConfirmUserID, _
		InvalidQuotationInstance.AddDate, _
		InvalidQuotationInstance.ConfirmDate, _
		InvalidQuotationInstance.Reason, _
		InvalidQuotationInstance.Status, _
		InvalidQuotationInstance.Extend01, _
		InvalidQuotationInstance.Extend02, _
		InvalidQuotationInstance.Extend03, _
		InvalidQuotationInstance.Extend04, _
		InvalidQuotationInstance.Extend05, _
		InvalidQuotationInstance.Extend06, _
		InvalidQuotationInstance.Extend07, _
		InvalidQuotationInstance.Extend08, _
		InvalidQuotationInstance.Extend09, _
		InvalidQuotationInstance.Extend10, _
		InvalidQuotationInstance.Recorddeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _InvalidQuotationInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "InvalidQuotation_Insert", _
           				InvalidQuotationInstance.PKID, _
		InvalidQuotationInstance.QuotationPKID, _
		InvalidQuotationInstance.ReporDetailPKID, _
		InvalidQuotationInstance.AddUserID, _
		InvalidQuotationInstance.ConfirmUserID, _
		InvalidQuotationInstance.AddDate, _
		InvalidQuotationInstance.ConfirmDate, _
		InvalidQuotationInstance.Reason, _
		InvalidQuotationInstance.Status, _
		InvalidQuotationInstance.Extend01, _
		InvalidQuotationInstance.Extend02, _
		InvalidQuotationInstance.Extend03, _
		InvalidQuotationInstance.Extend04, _
		InvalidQuotationInstance.Extend05, _
		InvalidQuotationInstance.Extend06, _
		InvalidQuotationInstance.Extend07, _
		InvalidQuotationInstance.Extend08, _
		InvalidQuotationInstance.Extend09, _
		InvalidQuotationInstance.Extend10, _
		InvalidQuotationInstance.Recorddeleted))
	 	Return  (_InvalidQuotationInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As InvalidQuotationInfo
		
			 Dim mInfo AS  new InvalidQuotationInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.QuotationPKID = IIf(dr.IsNull("QuotationPKID"), 0, Convert.ToInt32(dr.Item("QuotationPKID")))
			mInfo.ReporDetailPKID = IIf(dr.IsNull("ReporDetailPKID"), 0, Convert.ToInt32(dr.Item("ReporDetailPKID")))
			mInfo.AddUserID = IIf(dr.IsNull("AddUserID"), String.Empty, Convert.ToString(dr.Item("AddUserID")))
 			mInfo.ConfirmUserID = IIf(dr.IsNull("ConfirmUserID"), String.Empty, Convert.ToString(dr.Item("ConfirmUserID")))
 			mInfo.AddDate = IIf(dr.IsNull("AddDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("AddDate")))
			mInfo.ConfirmDate = IIf(dr.IsNull("ConfirmDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ConfirmDate")))
			mInfo.Reason = IIf(dr.IsNull("Reason"), String.Empty, Convert.ToString(dr.Item("Reason")))
 			mInfo.Status = IIf(dr.IsNull("Status"), 0, Convert.ToInt32(dr.Item("Status")))
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
 			mInfo.Recorddeleted = IIf(dr.IsNull("Recorddeleted"), 0, Convert.ToInt32(dr.Item("Recorddeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _InvalidQuotationInstance Is Nothing Then 
            If _InvalidQuotationInstance.PKID=0  Then
                Return Insert()
            ElseIf _InvalidQuotationInstance.PKID > 0 Then
                    Return Update()
                Else
                   _InvalidQuotationInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the InvalidQuotationInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"InvalidQuotation_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As InvalidQuotationInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"InvalidQuotation_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of InvalidQuotationInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "InvalidQuotation_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mInvalidQuotation As New list(of InvalidQuotationinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mInvalidQuotation.Add(TransformDr(dr))
            Next

            Return mInvalidQuotation
		
    End Function
    Public Shared Function GetInfoByQuotationPKID(ByVal PKID As Integer) As InvalidQuotationInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "InvalidQuotation_GetInfoByQuotationPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
	#End Region
#End Region
End Class

