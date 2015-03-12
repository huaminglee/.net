#region "導入命名空間"
Imports System

#end region

''' <summary>
''' 採購人員信息實例類
''' </summary>
''' <remarks>
''' </remarks>
Partial Public Class CaiGouUserDAL

#Region "建構式"
	''' <summary>
	''' 要進行數據控制的CaiGouUserInfo實例
	''' </summary>
	''' <param name="CaiGouUserInstance">要操作的CaiGouUserInfo實例類</param>
	''' <remarks></remarks>
	Public sub New(Byval CaiGouUserInstance as CaiGouUserInfo)
		_CaiGouUserInstance = CaiGouUserInstance
	End Sub
#End Region

#Region "屬性"
	Private _CaiGouUserInstance as CaiGouUserInfo
	
    ''' <summary>
    ''' CaiGouUserInfo實例
    ''' </summary>
    ''' <value></value>
    ''' <returns>CaiGouUserInfo</returns>
    ''' <remarks></remarks>
	Public Property CaiGouUserInstance as CaiGouUserInfo
	Get 
	    Return _CaiGouUserInstance
	End Get
	Set (Byval Value as CaiGouUserInfo)
	    _CaiGouUserInstance=value
	End Set
	End Property 
#End Region
	
#Region "方法"
  #Region "私有方法"
    Private Function Insert() As object
        If VerifyParameter() Then
            CaiGouUserInstance.HumanPKID = Ctype(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
            "TT_InsertCaiGouUser", _
            CaiGouUserInstance.HumanID, _
            CaiGouUserInstance.HumanName, _
            CaiGouUserInstance.HumanTel, _
            CaiGouUserInstance.HumanEmail, _
            CaiGouUserInstance.HumanDataSource, _
            CaiGouUserInstance.SkillDegree, _
            CaiGouUserInstance.Extend1, _
            CaiGouUserInstance.Extend2, _
            CaiGouUserInstance.Extend3, _
            CaiGouUserInstance.Extend4, _
            CaiGouUserInstance.Extend5, _
            CaiGouUserInstance.LastModifyTime, _
            CaiGouUserInstance.RecordDeleted, _
            CaiGouUserInstance.RecordCreated, _
            CaiGouUserInstance.RecordVersion),Integer)
            Return CaiGouUserInstance.HumanPKID
        Else
            Return nothing
        End If
    End Function
	
    Private Function Update() As Integer
        If VerifyParameter() Then
            Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
            "TT_UpdateCaiGouUser", _
            CaiGouUserInstance.HumanPKID, _
            CaiGouUserInstance.HumanID, _
            CaiGouUserInstance.HumanName, _
            CaiGouUserInstance.HumanTel, _
            CaiGouUserInstance.HumanEmail, _
            CaiGouUserInstance.HumanDataSource, _
            CaiGouUserInstance.SkillDegree, _
            CaiGouUserInstance.Extend1, _
            CaiGouUserInstance.Extend2, _
            CaiGouUserInstance.Extend3, _
            CaiGouUserInstance.Extend4, _
            CaiGouUserInstance.Extend5, _
            CaiGouUserInstance.LastModifyTime, _
            CaiGouUserInstance.RecordDeleted, _
            CaiGouUserInstance.RecordCreated, _
            CaiGouUserInstance.RecordVersion))
            Return Result
        Else
            Return 0
        End If
    End Function
	
    Private Function VerifyParameter() As Boolean
        If CaiGouUserInstance.HumanID.Length > CaiGouUserInfo.ColumnLengthForHumanID Then
            Return False
        End If
        If CaiGouUserInstance.HumanName.Length > CaiGouUserInfo.ColumnLengthForHumanName Then
            Return False
        End If
        If CaiGouUserInstance.HumanTel.Length > CaiGouUserInfo.ColumnLengthForHumanTel Then
            Return False
        End If
        If CaiGouUserInstance.HumanEmail.Length > CaiGouUserInfo.ColumnLengthForHumanEmail Then
            Return False
        End If
        If CaiGouUserInstance.SkillDegree.Length > CaiGouUserInfo.ColumnLengthForSkillDegree Then
            Return False
        End If
        If CaiGouUserInstance.Extend1.Length > CaiGouUserInfo.ColumnLengthForExtend1 Then
            Return False
        End If
        If CaiGouUserInstance.Extend2.Length > CaiGouUserInfo.ColumnLengthForExtend2 Then
            Return False
        End If
        If CaiGouUserInstance.Extend3.Length > CaiGouUserInfo.ColumnLengthForExtend3 Then
            Return False
        End If
        If CaiGouUserInstance.Extend4.Length > CaiGouUserInfo.ColumnLengthForExtend4 Then
            Return False
        End If
        If CaiGouUserInstance.Extend5.Length > CaiGouUserInfo.ColumnLengthForExtend5 Then
            Return False
        End If
        If CaiGouUserInstance.RecordVersion.Length > CaiGouUserInfo.ColumnLengthForRecordVersion Then
            Return False
        End If
        Return True
    End Function
	
    Private Shared Function TransformDr(ByVal dr As DataRow) As CaiGouUserInfo
        Dim mInfo As New CaiGouUserInfo
        If dr.IsNull("HumanPKID") Then
            mInfo.HumanPKID = 0
        Else
            mInfo.HumanPKID = Convert.ToInt32(dr.Item("HumanPKID"))
        End If
        
        If dr.IsNull("HumanID") Then
            mInfo.HumanID = ""
        Else
            mInfo.HumanID = Convert.ToString(dr.Item("HumanID"))
        End If
        
        If dr.IsNull("HumanName") Then
            mInfo.HumanName = ""
        Else
            mInfo.HumanName = Convert.ToString(dr.Item("HumanName"))
        End If
        
        If dr.IsNull("HumanTel") Then
            mInfo.HumanTel = ""
        Else
            mInfo.HumanTel = Convert.ToString(dr.Item("HumanTel"))
        End If
        
        If dr.IsNull("HumanEmail") Then
            mInfo.HumanEmail = ""
        Else
            mInfo.HumanEmail = Convert.ToString(dr.Item("HumanEmail"))
        End If
        
        If dr.IsNull("HumanDataSource") Then
            mInfo.HumanDataSource = 0
        Else
            mInfo.HumanDataSource = Convert.ToInt32(dr.Item("HumanDataSource"))
        End If
        
        If dr.IsNull("SkillDegree") Then
            mInfo.SkillDegree = ""
        Else
            mInfo.SkillDegree = Convert.ToString(dr.Item("SkillDegree"))
        End If
        
        If dr.IsNull("Extend1") Then
            mInfo.Extend1 = ""
        Else
            mInfo.Extend1 = Convert.ToString(dr.Item("Extend1"))
        End If
        
        If dr.IsNull("Extend2") Then
            mInfo.Extend2 = ""
        Else
            mInfo.Extend2 = Convert.ToString(dr.Item("Extend2"))
        End If
        
        If dr.IsNull("Extend3") Then
            mInfo.Extend3 = ""
        Else
            mInfo.Extend3 = Convert.ToString(dr.Item("Extend3"))
        End If
        
        If dr.IsNull("Extend4") Then
            mInfo.Extend4 = ""
        Else
            mInfo.Extend4 = Convert.ToString(dr.Item("Extend4"))
        End If
        
        If dr.IsNull("Extend5") Then
            mInfo.Extend5 = ""
        Else
            mInfo.Extend5 = Convert.ToString(dr.Item("Extend5"))
        End If
        
        If dr.IsNull("LastModifyTime") Then
            mInfo.LastModifyTime = DateTime.Now
        Else
            mInfo.LastModifyTime = Convert.ToDateTime(dr.Item("LastModifyTime"))
        End If
        
        If dr.IsNull("RecordDeleted") Then
            mInfo.RecordDeleted = 0
        Else
            mInfo.RecordDeleted = Convert.ToInt32(dr.Item("RecordDeleted"))
        End If
        
        If dr.IsNull("RecordCreated") Then
            mInfo.RecordCreated = DateTime.Now
        Else
            mInfo.RecordCreated = Convert.ToDateTime(dr.Item("RecordCreated"))
        End If
        
        If dr.IsNull("RecordVersion") Then
            mInfo.RecordVersion = ""
        Else
            mInfo.RecordVersion = Convert.ToString(dr.Item("RecordVersion"))
        End If
        
        Return mInfo
    End Function	
	
    Private Shared Function LoadAllCaiGouUserInfoCollectionBySearchCondition(ByVal SearchCondition As String) As  List(Of CaiGouUserInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TT_LoadCaiGouUserBySearchCondition", SearchCondition)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mInfos As New  List(Of CaiGouUserInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mInfos.Add(TransformDr(dr))
        Next
        Return mInfos
    End Function
	
  #End region
	
  #Region "公有方法"
    ''' <summary>保存數據</summary>
    ''' <returns>True/False</returns>
    ''' <remarks></remarks>
    Public Function Save() As Boolean
        If Not _CaiGouUserInstance Is Nothing Then 
            If _CaiGouUserInstance.HumanPKID =0  Then
                Return (Not Insert() is Nothing)
            ElseIf _CaiGouUserInstance.HumanPKID > 0 Then
                    Return Update()
                Else
                    _CaiGouUserInstance.HumanPKID = 0
                    Return False
                End If
        Else
            Dim ex As New Exception("Please set the CaiGouUserInstance Property !")
            Throw ex
        End if 
    End Function
    
    ''' <summary>依主鍵刪除記錄</summary>
	''' <param name="HumanPKID">作業人員PKID編號</param>
	''' <remarks></remarks>
    Public Shared Sub Delete(Byval HumanPKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "TT_DeleteCaiGouUserByPrimaryKey", HumanPKID)
    End Sub
	
    ''' <summary>刪除記錄</summary>
    ''' <param name="DeleteWhereClauseForCaiGouUserInfo">刪除條件表達式</param>
    ''' <remarks></remarks>
    Public Shared Sub Delete(Byval DeleteWhereClauseForCaiGouUserInfo As SearchWhereClause)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "TT_DeleteCaiGouUserByCondition",DeleteWhereClauseForCaiGouUserInfo.WhereClause)
    End Sub
	
    ''' <summary>載入指定主鍵對應的CaiGouUserInfo對象</summary>
    ''' <param name="HumanPKID">HumanPKID</param>
	''' <returns></returns>
	''' <remarks></remarks>
    Public Shared Function LoadCaiGouUserInfoByHumanPKID(ByVal HumanPKID As Integer) As CaiGouUserInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TT_LoadCaiGouUserByPrimaryKey", HumanPKID)
        Dim dt As DataTable = ds.Tables(0)
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim dr As DataRow = dt.Rows(0)
        Return TransformDr(dr)
    End Function

    ''' <summary>載入全部的CaiGouUserInfo對象集合</summary>
	''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadAllDataForCaiGouUserInfo() As  List(Of CaiGouUserInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TT_LoadCaiGouUserALL")
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mInfos As New List(Of CaiGouUserInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mInfos.Add(TransformDr(dr))
        Next
        Return mInfos
    End Function

	''' <summary>
    ''' 依查詢取得指定的實例個數
    ''' </summary>
    ''' <param name="SearchWhereClauseForCaiGouUserInfo">查詢表達式類</param>
    ''' <param name="IsUserInputSearchClause">查詢表達式是否通過用戶輸入創建</param>
    ''' <returns>實例個數</returns>
    ''' <remarks></remarks>
    Public Shared Function LoadAllCaiGouUserInfoCountBySearchCondition(ByVal SearchWhereClauseForCaiGouUserInfo As SearchWhereClause, _
                  Optional ByVal IsUserInputSearchClause As Boolean = False) As Integer
        Dim SearchCondition As String = ""
        If Not IsUserInputSearchClause Then
            SearchCondition = SearchWhereClauseForCaiGouUserInfo.WhereClause
        Else
            SearchCondition = SearchWhereClauseForCaiGouUserInfo.UserInputWhereClause
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "TT_LoadCaiGouUserBySearchCondition", SearchCondition)
        If (Not ds Is Nothing) AndAlso (ds.Tables.Count > 0) Then
            Return ds.Tables(0).Rows.Count
        Else
            Return 0
        End If
    End Function
	
    ''' <summary>
    ''' 依查詢取得指定的實例
    ''' </summary>
    ''' <param name="SearchWhereClauseForCaiGouUserInfo">查詢表達式類</param>
    ''' <param name="IsUserInputSearchClause">查詢表達式是否通過用戶輸入創建</param>
    ''' <returns>CaiGouUserInfoCollection</returns>
    ''' <remarks></remarks>
    Public Shared Function LoadAllCaiGouUserInfoCollectionBySearchCondition(ByVal SearchWhereClauseForCaiGouUserInfo As SearchWhereClause, _
                  Optional ByVal IsUserInputSearchClause As Boolean = False) As  List(Of CaiGouUserInfo)
        Dim SearchConditionStr As String = ""
        If Not IsUserInputSearchClause Then
            SearchConditionStr = SearchWhereClauseForCaiGouUserInfo.WhereClause
        Else
            SearchConditionStr = SearchWhereClauseForCaiGouUserInfo.UserInputWhereClause
        End If
        Return LoadAllCaiGouUserInfoCollectionBySearchCondition(SearchConditionStr)
    End Function
	
#End Region

  #Region "Collection Method"
    ''' <summary>
    ''' 將實體的泛型集合轉換成Datatable
    ''' </summary>
    ''' <param name="EntityList">實體的泛型集合</param>
    ''' <returns>Datatable</returns>
    ''' <remarks></remarks>
    Public Shared Function EntityList2Datatable(ByVal EntityList As List(Of CaiGouUserInfo)) As DataTable
        Return ADONetHelper.ToDataTable(EntityList)
    End Function

  #End Region

#End region

End Class
