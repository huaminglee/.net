#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  ReconcieldDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的ReconcieldInfo實例
        ''' </summary>
        ''' <param name="ReconcieldInstance">要操作的ReconcieldInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ReconcieldInstance As ReconcieldInfo)
            _ReconcieldInstance = ReconcieldInstance
        End Sub
#End Region

#Region "屬性"
        Private _ReconcieldInstance As ReconcieldInfo

        ''' <summary>
        ''' ReconcieldInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>ReconcieldInfo</returns>
        ''' <remarks></remarks>
        Public Property ReconcieldInstance() As ReconcieldInfo
            Get
                Return _ReconcieldInstance
            End Get
            Set(ByVal Value As ReconcieldInfo)
                _ReconcieldInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Reconcield_Update", _
           				ReconcieldInstance.PKID, _
		ReconcieldInstance.ReconcieldMonth, _
		ReconcieldInstance.ReconPersonID, _
		ReconcieldInstance.ReconDate, _
		ReconcieldInstance.CustomerPKID, _
		ReconcieldInstance.CustomerName, _
		ReconcieldInstance.FileClientName, _
		ReconcieldInstance.FileRealName, _
		ReconcieldInstance.Extend01, _
		ReconcieldInstance.Extend02, _
		ReconcieldInstance.Extend03, _
		ReconcieldInstance.Extend04, _
		ReconcieldInstance.Extend05, _
		ReconcieldInstance.Extend06, _
		ReconcieldInstance.Extend07, _
		ReconcieldInstance.Extend08, _
		ReconcieldInstance.Extend09, _
		ReconcieldInstance.Extend10, _
		ReconcieldInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _ReconcieldInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Reconcield_Insert", _
           				ReconcieldInstance.PKID, _
		ReconcieldInstance.ReconcieldMonth, _
		ReconcieldInstance.ReconPersonID, _
		ReconcieldInstance.ReconDate, _
		ReconcieldInstance.CustomerPKID, _
		ReconcieldInstance.CustomerName, _
		ReconcieldInstance.FileClientName, _
		ReconcieldInstance.FileRealName, _
		ReconcieldInstance.Extend01, _
		ReconcieldInstance.Extend02, _
		ReconcieldInstance.Extend03, _
		ReconcieldInstance.Extend04, _
		ReconcieldInstance.Extend05, _
		ReconcieldInstance.Extend06, _
		ReconcieldInstance.Extend07, _
		ReconcieldInstance.Extend08, _
		ReconcieldInstance.Extend09, _
		ReconcieldInstance.Extend10, _
		ReconcieldInstance.RecordDeleted))
	 	Return  (_ReconcieldInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As ReconcieldInfo
		
			 Dim mInfo AS  new ReconcieldInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.ReconcieldMonth = IIf(dr.IsNull("ReconcieldMonth"), 0, Convert.ToInt32(dr.Item("ReconcieldMonth")))
			mInfo.ReconPersonID = IIf(dr.IsNull("ReconPersonID"), String.Empty, Convert.ToString(dr.Item("ReconPersonID")))
 			mInfo.ReconDate = IIf(dr.IsNull("ReconDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ReconDate")))
			mInfo.CustomerPKID = IIf(dr.IsNull("CustomerPKID"), 0, Convert.ToInt32(dr.Item("CustomerPKID")))
			mInfo.CustomerName = IIf(dr.IsNull("CustomerName"), String.Empty, Convert.ToString(dr.Item("CustomerName")))
 			mInfo.FileClientName = IIf(dr.IsNull("FileClientName"), String.Empty, Convert.ToString(dr.Item("FileClientName")))
 			mInfo.FileRealName = IIf(dr.IsNull("FileRealName"), String.Empty, Convert.ToString(dr.Item("FileRealName")))
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
 			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _ReconcieldInstance Is Nothing Then 
            If _ReconcieldInstance.PKID=0  Then
                Return Insert()
            ElseIf _ReconcieldInstance.PKID > 0 Then
                    Return Update()
                Else
                   _ReconcieldInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the ReconcieldInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Reconcield_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As ReconcieldInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Reconcield_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of ReconcieldInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Reconcield_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mReconcield As New list(of Reconcieldinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mReconcield.Add(TransformDr(dr))
            Next

            Return mReconcield
		
 	End Function
	#End Region
#End Region
End Class

