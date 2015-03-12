Imports System
Imports Platform.Framework


''' <summary>
'''  WF_ProjectInfo
''' </summary>

Public Class WF_ProjectInfo
#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _PKID As Integer
    Private _DocUniqueID As System.Guid
    Private _ProjectType As String
    Private _RequestNum As Integer
    Private _AddUser As String
    Private _IsFinish As Integer = 0
    Private _Remark As String
    Private _RecordCreated As DateTime = DateTime.Now
    Private _RecordVersion As String

#End Region

#Region " Public Properties"
    ''' <summary>
    ''' 主鍵ID
    ''' </summary>
    Public Property PKID() As Integer
        Get
            Return _PKID
        End Get
        Set(ByVal Value As Integer)
            _PKID = Value
        End Set
    End Property
    ''' <summary>
    ''' 流程實例ID
    ''' </summary>
    Public Property DocUniqueID() As System.Guid
        Get
            Return _DocUniqueID
        End Get
        Set(ByVal Value As System.Guid)
            _DocUniqueID = Value
        End Set
    End Property
    ''' <summary>
    ''' 專案類型
    ''' </summary>
    Public Property ProjectType() As String
        Get
            Return _ProjectType
        End Get
        Set(ByVal Value As String)
            _ProjectType = Value
        End Set
    End Property
    ''' <summary>
    ''' 需求數量
    ''' </summary>
    Public Property RequestNum() As Integer
        Get
            Return _RequestNum
        End Get
        Set(ByVal Value As Integer)
            _RequestNum = Value
        End Set
    End Property
    ''' <summary>
    ''' 申請人工號
    ''' </summary>
    Public Property AddUser() As String
        Get
            Return _AddUser
        End Get
        Set(ByVal Value As String)
            _AddUser = Value
        End Set
    End Property
    ''' <summary>
    ''' 是否結案
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsFinish() As Integer
        Get
            Return _IsFinish
        End Get
        Set(ByVal value As Integer)
            _IsFinish = value
        End Set
    End Property
    ''' <summary>
    ''' 備注
    ''' </summary>
    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal Value As String)
            _Remark = Value
        End Set
    End Property
    ''' <summary>
    ''' 創建時間
    ''' </summary>
    Public Property RecordCreated() As DateTime
        Get
            Return _RecordCreated
        End Get
        Set(ByVal Value As DateTime)
            _RecordCreated = Value
        End Set
    End Property
    ''' <summary>
    ''' 記錄版本
    ''' </summary>
    Public Property RecordVersion() As String
        Get
            Return _RecordVersion
        End Get
        Set(ByVal Value As String)
            _RecordVersion = Value
        End Set
    End Property

#End Region



#Region " Method"
#Region " Private method"

    Private Function Update() As Boolean
        Try
            _PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                                        "WF_ProjectInfo_Update", _
                              _PKID, _
                 _DocUniqueID, _
                 _ProjectType, _
                 _RequestNum, _
                 _AddUser, _
                 _IsFinish, _
                 _Remark, _
                 _RecordCreated, _
                 _RecordVersion))
            Return (_PKID = 0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Function Insert() As Boolean
        Try
            _PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                                        "WF_ProjectInfo_Insert", _
                              _PKID, _
                 _DocUniqueID, _
                 _ProjectType, _
                 _RequestNum, _
                 _AddUser, _
                 _IsFinish, _
                 _Remark, _
                 _RecordCreated, _
                 _RecordVersion))
            Return (_PKID > 0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As WF_ProjectInfo

        Dim mInfo As New WF_ProjectInfo
        mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
        mInfo.DocUniqueID = IIf(dr.IsNull("DocUniqueID"), Guid.Empty, New Guid(dr.Item("DocUniqueID").ToString))
        mInfo.ProjectType = IIf(dr.IsNull("ProjectType"), String.Empty, Convert.ToString(dr.Item("ProjectType")))
        mInfo.RequestNum = IIf(dr.IsNull("RequestNum"), 0, Convert.ToInt32(dr.Item("RequestNum")))
        mInfo.AddUser = IIf(dr.IsNull("AddUser"), String.Empty, Convert.ToString(dr.Item("AddUser")))
        mInfo.IsFinish = IIf(dr.IsNull("IsFinish"), 0, Convert.ToInt32(dr.Item("IsFinish")))
        mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
        mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
        mInfo.RecordVersion = IIf(dr.IsNull("RecordVersion"), String.Empty, Convert.ToString(dr.Item("RecordVersion")))
        Return mInfo
    End Function


#End Region

#Region " Public method"
    Public Function Save() As Boolean
        If _PKID = 0 Then
            Return Insert()
        ElseIf _PKID > 0 Then
            Return Update()
        Else
            _PKID = 0
            Return False
        End If
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As WF_ProjectInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function
    Public Shared Function GetInfoByDocUniqueID(ByVal DocUniqueID As String) As WF_ProjectInfo
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoByDocUniqueID", DocUniqueID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function


    Public Shared Function GetInfoByOwner(ByVal TemplateID As Integer, ByVal UserPKID As Integer)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoByOwner", TemplateID, UserPKID)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mWF_ProjectInfo As New List(Of WF_ProjectInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mWF_ProjectInfo.Add(TransformDr(dr))
        Next
        Return mWF_ProjectInfo
    End Function

    Public Shared Function getInfoByStatus(ByVal TemplateStatusID As Integer) As List(Of WF_ProjectInfo)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoByStatus", TemplateStatusID)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mWF_ProjectInfo As New List(Of WF_ProjectInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mWF_ProjectInfo.Add(TransformDr(dr))
        Next

        Return mWF_ProjectInfo
    End Function

    Public Shared Function GetInfoByUnFinish() As List(Of WF_ProjectInfo)

        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoUnFinish")
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mWF_ProjectInfo As New List(Of WF_ProjectInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mWF_ProjectInfo.Add(TransformDr(dr))
        Next

        Return mWF_ProjectInfo
    End Function


    Public Shared Function getDTInfoUnFinish() As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoUnFinish")
        Return ds
    End Function

    Public Shared Function GetInfoFinish() As List(Of WF_ProjectInfo)



        Dim mWF_ProjectInfo As New List(Of WF_ProjectInfo)

        Return mWF_ProjectInfo
    End Function

    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As List(Of WF_ProjectInfo)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "WF_ProjectInfo_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mWF_ProjectInfo As New List(Of WF_ProjectInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mWF_ProjectInfo.Add(TransformDr(dr))
        Next

        Return mWF_ProjectInfo

    End Function


    ''' <summary>
    ''' 分頁取得數據集
    ''' </summary>
    ''' <param name="Filter">條件過濾表達式</param>
    ''' <param name="SortExpression">排序表達式</param>
    ''' <param name="PageNumber">第幾頁</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadInstanceCollectionByCustomPaging(ByVal Filter As String, _
               ByVal SortExpression As String, ByVal TableName As String, ByVal PageNumber As Integer) As List(Of WF_ProjectInfo)
        Dim CustomPageSize As Integer = ConfigurationManager.AppSettings("CustomPageSize")

        Dim ds As DataSet = SearchExtHelper.SearchDataWithCustomPaging(ConfigurationInfo.ConnectionString, TableName, _
  "PKID", SortExpression, PageNumber, CustomPageSize, Filter)

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mInfos As New List(Of WF_ProjectInfo)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mInfos.Add(TransformDr(dr))
        Next
        Return mInfos
    End Function

    Public Shared Function LoadInstanceCountgBySearch(ByVal Filter As String) As Integer

        Dim ResultCounut As Integer
        ResultCounut = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                                    "WF_loadInfoCountBySearchConditon", Filter))

        Return ResultCounut

    End Function



#End Region
#End Region


End Class

