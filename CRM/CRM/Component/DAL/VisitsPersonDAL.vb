#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  VisitsPersonDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的VisitsPersonInfo實例
        ''' </summary>
        ''' <param name="VisitsPersonInstance">要操作的VisitsPersonInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal VisitsPersonInstance As VisitsPersonInfo)
            _VisitsPersonInstance = VisitsPersonInstance
        End Sub
#End Region

#Region "屬性"
        Private _VisitsPersonInstance As VisitsPersonInfo

        ''' <summary>
        ''' VisitsPersonInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>VisitsPersonInfo</returns>
        ''' <remarks></remarks>
        Public Property VisitsPersonInstance() As VisitsPersonInfo
            Get
                Return _VisitsPersonInstance
            End Get
            Set(ByVal Value As VisitsPersonInfo)
                _VisitsPersonInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "VisitsPerson_Update", _
           				VisitsPersonInstance.PKID, _
		VisitsPersonInstance.CustomerVisitsPKID, _
		VisitsPersonInstance.Name, _
		VisitsPersonInstance.Contact, _
		VisitsPersonInstance.Post, _
		VisitsPersonInstance.WorkContent, _
		VisitsPersonInstance.Remark, _
		VisitsPersonInstance.Extend01, _
		VisitsPersonInstance.Extend02, _
		VisitsPersonInstance.Extend03, _
		VisitsPersonInstance.Extend04, _
		VisitsPersonInstance.Extend05))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _VisitsPersonInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "VisitsPerson_Insert", _
           				VisitsPersonInstance.PKID, _
		VisitsPersonInstance.CustomerVisitsPKID, _
		VisitsPersonInstance.Name, _
		VisitsPersonInstance.Contact, _
		VisitsPersonInstance.Post, _
		VisitsPersonInstance.WorkContent, _
		VisitsPersonInstance.Remark, _
		VisitsPersonInstance.Extend01, _
		VisitsPersonInstance.Extend02, _
		VisitsPersonInstance.Extend03, _
		VisitsPersonInstance.Extend04, _
		VisitsPersonInstance.Extend05))
	 	Return  (_VisitsPersonInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As VisitsPersonInfo
		
			 Dim mInfo AS  new VisitsPersonInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.CustomerVisitsPKID = IIf(dr.IsNull("CustomerVisitsPKID"), 0, Convert.ToInt32(dr.Item("CustomerVisitsPKID")))
			mInfo.Name = IIf(dr.IsNull("Name"), String.Empty, Convert.ToString(dr.Item("Name")))
 			mInfo.Contact = IIf(dr.IsNull("Contact"), String.Empty, Convert.ToString(dr.Item("Contact")))
 			mInfo.Post = IIf(dr.IsNull("Post"), String.Empty, Convert.ToString(dr.Item("Post")))
 			mInfo.WorkContent = IIf(dr.IsNull("WorkContent"), String.Empty, Convert.ToString(dr.Item("WorkContent")))
 			mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
 			mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
 			mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
 			mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
 			mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
 			mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
 		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _VisitsPersonInstance Is Nothing Then 
            If _VisitsPersonInstance.PKID=0  Then
                Return Insert()
            ElseIf _VisitsPersonInstance.PKID > 0 Then
                    Return Update()
                Else
                   _VisitsPersonInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the VisitsPersonInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"VisitsPerson_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As VisitsPersonInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"VisitsPerson_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of VisitsPersonInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "VisitsPerson_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mVisitsPerson As New list(of VisitsPersoninfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mVisitsPerson.Add(TransformDr(dr))
            Next

            Return mVisitsPerson
		
    End Function
    Public Shared Function GetPersonInfoByCustomerVisitsPKID(ByVal CustomerVisitsPKID As Integer) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "VisitsPerson_GetInfoByCustomerVisitsPKID", CustomerVisitsPKID)


        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Return dt
    End Function
	#End Region
#End Region
End Class

