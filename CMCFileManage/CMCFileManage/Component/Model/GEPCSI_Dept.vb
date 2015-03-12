Imports System
''' <summary>
'''  GEPCSI_Dept
''' </summary>

Public Class GEPCSI_Dept
#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _DeptPKID As Integer
    Private _Category As Integer = 0
    Private _DeptName As String
    Private _CSIExplain As String
    Private _DisplayOrder As Integer
    Private _Remark As String
    Private _Extend1 As String
    Private _Extend2 As String
    Private _Extend3 As String
    Private _Extend4 As String
    Private _Extend5 As String
    Private _RecordDeleted As Integer = 0
    Private _RecordCreated As DateTime = DateTime.MaxValue
    Private _RecordVersion As String

#End Region

#Region " Public Properties"
    ''' <summary>
    ''' PKID
    ''' </summary>
    Public Property DeptPKID() As Integer
        Get
            Return _DeptPKID
        End Get
        Set(ByVal Value As Integer)
            _DeptPKID = Value
        End Set
    End Property
    ''' <summary>
    ''' 部門類別
    ''' </summary>
    Public Property Category() As Integer
        Get
            Return _Category
        End Get
        Set(ByVal Value As Integer)
            _Category = Value
        End Set
    End Property
    ''' <summary>
    ''' 部門名稱
    ''' </summary>
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal Value As String)
            _DeptName = Value
        End Set
    End Property
    ''' <summary>
    ''' 部門滿意度說明
    ''' </summary>
    Public Property CSIExplain() As String
        Get
            Return _CSIExplain
        End Get
        Set(ByVal Value As String)
            _CSIExplain = Value
        End Set
    End Property
    ''' <summary>
    ''' 顯示次序
    ''' </summary>
    Public Property DisplayOrder() As Integer
        Get
            Return _DisplayOrder
        End Get
        Set(ByVal Value As Integer)
            _DisplayOrder = Value
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
    ''' 預留
    ''' </summary>
    Public Property Extend1() As String
        Get
            Return _Extend1
        End Get
        Set(ByVal Value As String)
            _Extend1 = Value
        End Set
    End Property
    ''' <summary>
    ''' 預留
    ''' </summary>
    Public Property Extend2() As String
        Get
            Return _Extend2
        End Get
        Set(ByVal Value As String)
            _Extend2 = Value
        End Set
    End Property
    ''' <summary>
    ''' 預留
    ''' </summary>
    Public Property Extend3() As String
        Get
            Return _Extend3
        End Get
        Set(ByVal Value As String)
            _Extend3 = Value
        End Set
    End Property
    ''' <summary>
    ''' 預留
    ''' </summary>
    Public Property Extend4() As String
        Get
            Return _Extend4
        End Get
        Set(ByVal Value As String)
            _Extend4 = Value
        End Set
    End Property
    ''' <summary>
    ''' 預留
    ''' </summary>
    Public Property Extend5() As String
        Get
            Return _Extend5
        End Get
        Set(ByVal Value As String)
            _Extend5 = Value
        End Set
    End Property
    ''' <summary>
    ''' 刪除標志( 1軟刪)
    ''' </summary>
    Public Property RecordDeleted() As Integer
        Get
            Return _RecordDeleted
        End Get
        Set(ByVal Value As Integer)
            _RecordDeleted = Value
        End Set
    End Property
    ''' <summary>
    ''' 記錄生成時間
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
    ''' 記錄版本號
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
        _DeptPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                     "GEPCSI_Dept_Update", _
           _DeptPKID, _
_Category, _
_DeptName, _
_CSIExplain, _
_DisplayOrder, _
_Remark, _
_Extend1, _
_Extend2, _
_Extend3, _
_Extend4, _
_Extend5, _
_RecordDeleted, _
_RecordCreated, _
_RecordVersion))
        Return (_DeptPKID = 0)
    End Function

    Private Function Insert() As Boolean
        _DeptPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_Dept_Insert", _
                   _DeptPKID, _
      _Category, _
      _DeptName, _
      _CSIExplain, _
      _DisplayOrder, _
      _Remark, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5, _
      _RecordDeleted, _
      _RecordCreated, _
      _RecordVersion))
        Return (_DeptPKID > 0)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_Dept

        Dim mInfo As New GEPCSI_Dept
        mInfo.DeptPKID = IIf(dr.IsNull("DeptPKID"), 0, Convert.ToInt32(dr.Item("DeptPKID")))
        mInfo.Category = IIf(dr.IsNull("Category"), 0, Convert.ToInt32(dr.Item("Category")))
        mInfo.DeptName = IIf(dr.IsNull("DeptName"), String.Empty, Convert.ToString(dr.Item("DeptName")))
        mInfo.CSIExplain = IIf(dr.IsNull("CSIExplain"), String.Empty, Convert.ToString(dr.Item("CSIExplain")))
        mInfo.DisplayOrder = IIf(dr.IsNull("DisplayOrder"), 0, Convert.ToInt32(dr.Item("DisplayOrder")))
        mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
        mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
        mInfo.RecordCreated = IIf(dr.IsNull("RecordCreated"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("RecordCreated")))
        mInfo.RecordVersion = IIf(dr.IsNull("RecordVersion"), String.Empty, Convert.ToString(dr.Item("RecordVersion")))
        Return mInfo
    End Function


#End Region

#Region " Public method"
    Public Function Save() As Boolean
        If _DeptPKID = 0 Then
            Return Insert()
        ElseIf _DeptPKID > 0 Then
            Return Update()
        Else
            _DeptPKID = 0
            Return False
        End If
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_Dept
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function


    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_DeptCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mGEPCSI_Dept As New GEPCSI_DeptCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mGEPCSI_Dept.Add(TransformDr(dr))
        Next
        Return mGEPCSI_Dept
    End Function
    Public Shared Function GetAllDepeInfo() As ArrayList
        Dim alist As New ArrayList
        Dim SearchString As String = String.Empty
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Integer
        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                Dim ListItem As ListItem = New ListItem
                ListItem.Text = dr.Item("DeptName")
                ListItem.Value = dr.Item("DeptPKID")
                If Not alist.Contains(ListItem) Then
                    alist.Add(ListItem)
                End If
            Next
            Return alist
        End If
    End Function
    Public Shared Function GetDeptnameByDeptPKID(ByVal DeptPKID As Integer) As String
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_GetDeptnameByDeptPKID", DeptPKID)
        If ds.Tables(0).Rows.Count = 0 Then
            Return String.Empty
        End If
        Return ds.Tables(0).Rows(0).Item("DeptName")
    End Function
#End Region
#End Region


End Class
