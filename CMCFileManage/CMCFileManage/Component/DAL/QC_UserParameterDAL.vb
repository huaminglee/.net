#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  QC_UserParameterDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的QC_UserParameterInfo實例
        ''' </summary>
        ''' <param name="QC_UserParameterInstance">要操作的QC_UserParameterInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal QC_UserParameterInstance As QC_UserParameterInfo)
            _QC_UserParameterInstance = QC_UserParameterInstance
        End Sub
#End Region

#Region "屬性"
        Private _QC_UserParameterInstance As QC_UserParameterInfo

        ''' <summary>
        ''' QC_UserParameterInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>QC_UserParameterInfo</returns>
        ''' <remarks></remarks>
        Public Property QC_UserParameterInstance() As QC_UserParameterInfo
            Get
                Return _QC_UserParameterInstance
            End Get
            Set(ByVal Value As QC_UserParameterInfo)
                _QC_UserParameterInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_UserParameter_Update", _
           				QC_UserParameterInstance.PKID, _
		QC_UserParameterInstance.ParameterCategory, _
		QC_UserParameterInstance.ParameterText, _
		QC_UserParameterInstance.ParameterValue1, _
		QC_UserParameterInstance.ParameterValue2, _
		QC_UserParameterInstance.DispalyOrder, _
		QC_UserParameterInstance.Extend1, _
		QC_UserParameterInstance.Extend2, _
		QC_UserParameterInstance.Extend3, _
		QC_UserParameterInstance.Extend4, _
		QC_UserParameterInstance.Extend5, _
		QC_UserParameterInstance.RecordCreated, _
		QC_UserParameterInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _QC_UserParameterInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "QC_UserParameter_Insert", _
           				QC_UserParameterInstance.PKID, _
		QC_UserParameterInstance.ParameterCategory, _
		QC_UserParameterInstance.ParameterText, _
		QC_UserParameterInstance.ParameterValue1, _
		QC_UserParameterInstance.ParameterValue2, _
		QC_UserParameterInstance.DispalyOrder, _
		QC_UserParameterInstance.Extend1, _
		QC_UserParameterInstance.Extend2, _
		QC_UserParameterInstance.Extend3, _
		QC_UserParameterInstance.Extend4, _
		QC_UserParameterInstance.Extend5, _
		QC_UserParameterInstance.RecordCreated, _
		QC_UserParameterInstance.RecordDeleted))
	 	Return  (_QC_UserParameterInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As QC_UserParameterInfo
		
			 Dim mInfo AS  new QC_UserParameterInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.ParameterCategory = IIf(dr.IsNull("ParameterCategory"), String.Empty, Convert.ToString(dr.Item("ParameterCategory")))
 			mInfo.ParameterText = IIf(dr.IsNull("ParameterText"), String.Empty, Convert.ToString(dr.Item("ParameterText")))
 			mInfo.ParameterValue1 = IIf(dr.IsNull("ParameterValue1"), String.Empty, Convert.ToString(dr.Item("ParameterValue1")))
 			mInfo.ParameterValue2 = IIf(dr.IsNull("ParameterValue2"), String.Empty, Convert.ToString(dr.Item("ParameterValue2")))
 			mInfo.DispalyOrder = IIf(dr.IsNull("DispalyOrder"), 0, Convert.ToInt32(dr.Item("DispalyOrder")))
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
	     Public Function Save() As Boolean
	If Not _QC_UserParameterInstance Is Nothing Then 
            If _QC_UserParameterInstance.PKID=0  Then
                Return Insert()
            ElseIf _QC_UserParameterInstance.PKID > 0 Then
                    Return Update()
                Else
                   _QC_UserParameterInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the QC_UserParameterInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"QC_UserParameter_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As QC_UserParameterInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"QC_UserParameter_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of QC_UserParameterInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_UserParameter_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mQC_UserParameter As New list(of QC_UserParameterinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mQC_UserParameter.Add(TransformDr(dr))
            Next

            Return mQC_UserParameter
		
    End Function
    Public Shared Function GetInfoByCategory(ByVal Category As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_UserParameter_GetInfoByCategory", Category)
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetDicInfoByCategory(ByVal Category As String) As List(Of DictionaryEntry)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_UserParameter_GetInfoByCategory", Category)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mList As New List(Of DictionaryEntry)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mList.Add(New DictionaryEntry(dr.Item("ParameterValue1").ToString, dr.Item("ParameterText").ToString))
        Next

        Return mList

    End Function
    Public Shared Function GetAllZT() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "QC_UserParameter_GetAllZT")
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

