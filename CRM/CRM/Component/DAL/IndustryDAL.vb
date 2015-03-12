#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  IndustryDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的IndustryInfo實例
        ''' </summary>
        ''' <param name="IndustryInstance">要操作的IndustryInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal IndustryInstance As IndustryInfo)
            _IndustryInstance = IndustryInstance
        End Sub
#End Region

#Region "屬性"
        Private _IndustryInstance As IndustryInfo

        ''' <summary>
        ''' IndustryInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>IndustryInfo</returns>
        ''' <remarks></remarks>
        Public Property IndustryInstance() As IndustryInfo
            Get
                Return _IndustryInstance
            End Get
            Set(ByVal Value As IndustryInfo)
                _IndustryInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Industry_Update", _
           				IndustryInstance.PKID, _
		IndustryInstance.IndustryName, _
		IndustryInstance.Extend1, _
		IndustryInstance.Extend2, _
		IndustryInstance.RecordCreated, _
		IndustryInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _IndustryInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Industry_Insert", _
           				IndustryInstance.PKID, _
		IndustryInstance.IndustryName, _
		IndustryInstance.Extend1, _
		IndustryInstance.Extend2, _
		IndustryInstance.RecordCreated, _
		IndustryInstance.RecordDeleted))
	 	Return  (_IndustryInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As IndustryInfo
		
			 Dim mInfo AS  new IndustryInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.IndustryName = IIf(dr.IsNull("IndustryName"), String.Empty, Convert.ToString(dr.Item("IndustryName")))
 			mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
 			mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
 			mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
			mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
		Return  mInfo
		End Function 


	#End Region

	#Region " Public method"
	     Public Function Save() As Boolean
	If Not _IndustryInstance Is Nothing Then 
            If _IndustryInstance.PKID=0  Then
                Return Insert()
            ElseIf _IndustryInstance.PKID > 0 Then
                    Return Update()
                Else
                   _IndustryInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the IndustryInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"Industry_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As IndustryInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"Industry_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of IndustryInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Industry_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mIndustry As New list(of Industryinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mIndustry.Add(TransformDr(dr))
            Next

            Return mIndustry
		
    End Function
    Public Shared Function GetAllInfo() As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Industry_GetAllInfo")
        Dim dt As DataTable = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            Return Nothing
        End If
        Return dt
    End Function
	#End Region
#End Region
End Class

