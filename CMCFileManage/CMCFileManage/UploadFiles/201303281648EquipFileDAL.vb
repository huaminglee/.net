#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  EquipFileDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的EquipFileInfo實例
        ''' </summary>
        ''' <param name="EquipFileInstance">要操作的EquipFileInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal EquipFileInstance As EquipFileInfo)
            _EquipFileInstance = EquipFileInstance
        End Sub
#End Region

#Region "屬性"
        Private _EquipFileInstance As EquipFileInfo

        ''' <summary>
        ''' EquipFileInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>EquipFileInfo</returns>
        ''' <remarks></remarks>
        Public Property EquipFileInstance() As EquipFileInfo
            Get
                Return _EquipFileInstance
            End Get
            Set(ByVal Value As EquipFileInfo)
                _EquipFileInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
 		Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "EquipFile_Update", _
           				EquipFileInstance.PKID, _
		EquipFileInstance.ParentPKID, _
		EquipFileInstance.EquipDept, _
		EquipFileInstance.QyLocation, _
		EquipFileInstance.EquipName, _
		EquipFileInstance.ControlNO, _
		EquipFileInstance.ManuFacturer, _
		EquipFileInstance.DetailName, _
		EquipFileInstance.DetailControlNO, _
		EquipFileInstance.EquipModel, _
		EquipFileInstance.SerialNumber, _
		EquipFileInstance.MainSpecification, _
		EquipFileInstance.EquipNum, _
		EquipFileInstance.EquipLocation, _
		EquipFileInstance.KeepUser, _
		EquipFileInstance.Extend1, _
		EquipFileInstance.Extend2, _
		EquipFileInstance.Extend3, _
		EquipFileInstance.Extend4, _
		EquipFileInstance.Extend5, _
		EquipFileInstance.RecordCreated, _
		EquipFileInstance.RecordDeleted))			
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
			  _EquipFileInstance.PKID= Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "EquipFile_Insert", _
           				EquipFileInstance.PKID, _
		EquipFileInstance.ParentPKID, _
		EquipFileInstance.EquipDept, _
		EquipFileInstance.QyLocation, _
		EquipFileInstance.EquipName, _
		EquipFileInstance.ControlNO, _
		EquipFileInstance.ManuFacturer, _
		EquipFileInstance.DetailName, _
		EquipFileInstance.DetailControlNO, _
		EquipFileInstance.EquipModel, _
		EquipFileInstance.SerialNumber, _
		EquipFileInstance.MainSpecification, _
		EquipFileInstance.EquipNum, _
		EquipFileInstance.EquipLocation, _
		EquipFileInstance.KeepUser, _
		EquipFileInstance.Extend1, _
		EquipFileInstance.Extend2, _
		EquipFileInstance.Extend3, _
		EquipFileInstance.Extend4, _
		EquipFileInstance.Extend5, _
		EquipFileInstance.RecordCreated, _
		EquipFileInstance.RecordDeleted))
	 	Return  (_EquipFileInstance.PKID> 0)
	        End Function
		 			Private Shared Function TransformDr(ByVal dr As DataRow) As EquipFileInfo
		
			 Dim mInfo AS  new EquipFileInfo
			mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
			mInfo.ParentPKID = IIf(dr.IsNull("ParentPKID"), 0, Convert.ToInt32(dr.Item("ParentPKID")))
			mInfo.EquipDept = IIf(dr.IsNull("EquipDept"), String.Empty, Convert.ToString(dr.Item("EquipDept")))
 			mInfo.QyLocation = IIf(dr.IsNull("QyLocation"), String.Empty, Convert.ToString(dr.Item("QyLocation")))
 			mInfo.EquipName = IIf(dr.IsNull("EquipName"), String.Empty, Convert.ToString(dr.Item("EquipName")))
 			mInfo.ControlNO = IIf(dr.IsNull("ControlNO"), String.Empty, Convert.ToString(dr.Item("ControlNO")))
 			mInfo.ManuFacturer = IIf(dr.IsNull("ManuFacturer"), String.Empty, Convert.ToString(dr.Item("ManuFacturer")))
 			mInfo.DetailName = IIf(dr.IsNull("DetailName"), String.Empty, Convert.ToString(dr.Item("DetailName")))
 			mInfo.DetailControlNO = IIf(dr.IsNull("DetailControlNO"), String.Empty, Convert.ToString(dr.Item("DetailControlNO")))
 			mInfo.EquipModel = IIf(dr.IsNull("EquipModel"), String.Empty, Convert.ToString(dr.Item("EquipModel")))
 			mInfo.SerialNumber = IIf(dr.IsNull("SerialNumber"), String.Empty, Convert.ToString(dr.Item("SerialNumber")))
 			mInfo.MainSpecification = IIf(dr.IsNull("MainSpecification"), String.Empty, Convert.ToString(dr.Item("MainSpecification")))
 			mInfo.EquipNum = IIf(dr.IsNull("EquipNum"), 0, Convert.ToInt32(dr.Item("EquipNum")))
			mInfo.EquipLocation = IIf(dr.IsNull("EquipLocation"), String.Empty, Convert.ToString(dr.Item("EquipLocation")))
 			mInfo.KeepUser = IIf(dr.IsNull("KeepUser"), String.Empty, Convert.ToString(dr.Item("KeepUser")))
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
	If Not _EquipFileInstance Is Nothing Then 
            If _EquipFileInstance.PKID=0  Then
                Return Insert()
            ElseIf _EquipFileInstance.PKID > 0 Then
                    Return Update()
                Else
                   _EquipFileInstance.PKID= 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the EquipFileInstance Property !")
            Throw ex
        End if 
        End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <remarks></remarks>
	 Public Shared Sub Delete(ByVal PKID As Integer)
           	 SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString,"EquipFile_Delete", PKID)
       	 End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
	Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As EquipFileInfo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, 		"EquipFile_GetInfoByPKID", PKID)
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
	Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String)As list(of EquipFileInfo)
           Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "EquipFile_GetInfoBySearchCondition",SearchString)
            Dim dt As DataTable = ds.Tables(0)
            Dim dr As DataRow
            Dim i As Integer

            If (dt.Rows.Count = 0) Then
                Return Nothing
            End If

            Dim mEquipFile As New list(of EquipFileinfo)
            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                mEquipFile.Add(TransformDr(dr))
            Next

            Return mEquipFile
		
 	End Function
	#End Region
#End Region
End Class

