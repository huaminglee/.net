#Region "導入命名空間"
Imports System
Imports Platform.Framework
#End Region


    ''' ---------------------------------------------
    ''' <summary>實例類</summary>
    ''' <remarks></remarks>
    ''' ---------------------------------------------
Partial Public Class  Sys_NewsDAL
#Region "建構式"
        ''' <summary>
        ''' 要進行數據控制的Sys_NewsInfo實例
        ''' </summary>
        ''' <param name="Sys_NewsInstance">要操作的Sys_NewsInfo實例類</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Sys_NewsInstance As Sys_NewsInfo)
            _Sys_NewsInstance = Sys_NewsInstance
        End Sub
#End Region

#Region "屬性"
        Private _Sys_NewsInstance As Sys_NewsInfo

        ''' <summary>
        ''' Sys_NewsInfo實例
        ''' </summary>
        ''' <value></value>
        ''' <returns>Sys_NewsInfo</returns>
        ''' <remarks></remarks>
        Public Property Sys_NewsInstance() As Sys_NewsInfo
            Get
                Return _Sys_NewsInstance
            End Get
            Set(ByVal Value As Sys_NewsInfo)
                _Sys_NewsInstance = Value
            End Set
        End Property
#End Region
#Region " Method"
	#Region " Private method"

 		 Private Function Update() As Boolean		 
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                              "Sys_News_Update", _
                    Sys_NewsInstance.NewsID, _
       Sys_NewsInstance.NewTitle, _
       Sys_NewsInstance.NewContent, _
       Sys_NewsInstance.CreateUser, _
       Sys_NewsInstance.ModifyUser, _
       Sys_NewsInstance.ModifyTime, _
       Sys_NewsInstance.ServicePKID, _
       Sys_NewsInstance.ServiceName, _
       Sys_NewsInstance.EndTime, _
       Sys_NewsInstance.Extend1, _
       Sys_NewsInstance.Extend2, _
       Sys_NewsInstance.Extend3, _
       Sys_NewsInstance.Extend4, _
       Sys_NewsInstance.Extend5, _
       Sys_NewsInstance.RecordCreated, _
       Sys_NewsInstance.RecordDeleted))
	 	  Return  Result
 		 End Function

 		Private Function Insert() As Boolean		
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                         "Sys_News_Insert", _
               Sys_NewsInstance.NewsID, _
              Sys_NewsInstance.NewTitle, _
              Sys_NewsInstance.NewContent, _
              Sys_NewsInstance.CreateUser, _
              Sys_NewsInstance.ModifyUser, _
              Sys_NewsInstance.ModifyTime, _
              Sys_NewsInstance.ServicePKID, _
              Sys_NewsInstance.ServiceName, _
              Sys_NewsInstance.EndTime, _
              Sys_NewsInstance.Extend1, _
              Sys_NewsInstance.Extend2, _
              Sys_NewsInstance.Extend3, _
              Sys_NewsInstance.Extend4, _
              Sys_NewsInstance.Extend5, _
              Sys_NewsInstance.RecordCreated, _
              Sys_NewsInstance.RecordDeleted))
        Return Result

    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As Sys_NewsInfo


        Dim mInfo As New Sys_NewsInfo

        mInfo.NewsID = IIf(dr.IsNull("NewsID"), String.Empty, Convert.ToString(dr.Item("NewsID")))
        mInfo.NewTitle = IIf(dr.IsNull("NewTitle"), String.Empty, Convert.ToString(dr.Item("NewTitle")))
        mInfo.NewContent = IIf(dr.IsNull("NewContent"), String.Empty, Convert.ToString(dr.Item("NewContent")))
        mInfo.CreateUser = IIf(dr.IsNull("CreateUser"), String.Empty, Convert.ToString(dr.Item("CreateUser")))
        mInfo.ModifyUser = IIf(dr.IsNull("ModifyUser"), String.Empty, Convert.ToString(dr.Item("ModifyUser")))
        mInfo.ModifyTime = IIf(dr.IsNull("ModifyTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("ModifyTime")))
        mInfo.ServicePKID = IIf(dr.IsNull("ServicePKID"), 0, Convert.ToInt32(dr.Item("ServicePKID")))
        mInfo.ServiceName = IIf(dr.IsNull("ServiceName"), String.Empty, Convert.ToString(dr.Item("ServiceName")))
        mInfo.EndTime = IIf(dr.IsNull("EndTime"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndTime")))
        mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
        mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
        Return mInfo
    End Function


	#End Region

#Region " Public method"
    ''' <summary>
    ''' 保存記錄
    ''' </summary>
    ''' <param name="IsInsert">是否為新增</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save(ByVal IsInsert As Boolean) As Boolean

        If Not _Sys_NewsInstance Is Nothing Then
            If IsInsert Then
                Return Insert()
            Else
                Return Update()
            End If
        Else
            Dim ex As New Exception("Please set the Sys_NewsInstance Property !")
            Throw ex
        End If
    End Function

    ''' <summary>
    ''' 刪除指定記錄
    ''' </summary>
    ''' <param name="NewPKID"></param>
    ''' <remarks></remarks>
    Public Shared Sub Delete(ByVal NewPKID As String)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "Sys_News_DeleteByNewsID", NewPKID)
    End Sub

    ''' <summary>
    ''' 獲取指定PKID的實例信息
    ''' </summary>
    ''' <param name="PKID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInfoByPKID(ByVal PKID As String) As Sys_NewsInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Sys_News_GetInfoByPKID", PKID)
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
    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As List(Of Sys_NewsInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Sys_News_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mSys_News As New List(Of Sys_NewsInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mSys_News.Add(TransformDr(dr))
        Next

        Return mSys_News

    End Function

    ''' <summary>
    ''' 獲取指定條件的記錄
    ''' </summary>
    ''' <param name="SearchString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDtInfoBySearchCondtion(ByVal SearchString As String) As DataTable
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Sys_News_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)


        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If


        Return dt

    End Function

#End Region
#End Region
End Class

