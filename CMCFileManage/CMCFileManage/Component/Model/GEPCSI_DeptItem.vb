Imports System

''' <summary>
'''  GEPCSI_DeptItem
''' </summary>

Public Class GEPCSI_DeptItem
#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _DeptItemPKID As Integer
    Private _CSITime As Integer = 0
    Private _DeptPKID As Integer = 0
    Private _ItemCategory As Integer = 0
    Private _ItemNO As String = String.Empty
    Private _ItemName As String = String.Empty
    Private _DisplayOrder As String = String.Empty
    Private _Remark As String = String.Empty
    Private _Extend1 As String = String.Empty
    Private _Extend2 As String = String.Empty
    Private _Extend3 As String = String.Empty
    Private _Extend4 As String = String.Empty
    Private _Extend5 As String = String.Empty

    Private _RecordDeleted As Integer = 0
    Private _RecordCreated As DateTime = DateTime.MaxValue
    Private _RecordVersion As String = String.Empty

#End Region

#Region " Public Properties"
    ''' <summary>
    ''' PKID
    ''' </summary>
    Public Property DeptItemPKID() As Integer
        Get
            Return _DeptItemPKID
        End Get
        Set(ByVal Value As Integer)
            _DeptItemPKID = Value
        End Set
    End Property
    ''' <summary>
    ''' 第幾次滿意度調查模板(每調查一次加1)
    ''' </summary>
    Public Property CSITime() As Integer
        Get
            Return _CSITime
        End Get
        Set(ByVal Value As Integer)
            _CSITime = Value
        End Set
    End Property
    ''' <summary>
    ''' 部門ID
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
    ''' 調查項目分類(1:選擇;2文本輸入)
    ''' </summary>
    Public Property ItemCategory() As Integer
        Get
            Return _ItemCategory
        End Get
        Set(ByVal Value As Integer)
            _ItemCategory = Value
        End Set
    End Property
    ''' <summary>
    ''' 測試項目編號(相當與Key)
    ''' </summary>
    Public Property ItemNO() As String
        Get
            Return _ItemNO
        End Get
        Set(ByVal Value As String)
            _ItemNO = Value
        End Set
    End Property
    ''' <summary>
    ''' 調查項目名
    ''' </summary>
    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal Value As String)
            _ItemName = Value
        End Set
    End Property
    ''' <summary>
    ''' 顯示次序
    ''' </summary>
    Public Property DisplayOrder() As String
        Get
            Return _DisplayOrder
        End Get
        Set(ByVal Value As String)
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
        _DeptItemPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_DeptItem_Update", _
                   _DeptItemPKID, _
      _CSITime, _
      _DeptPKID, _
      _ItemCategory, _
      _ItemNO, _
      _ItemName, _
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
        Return (_DeptItemPKID)
    End Function

    Private Function Insert() As Boolean
        _DeptItemPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_DeptItem_Insert", _
                   _DeptItemPKID, _
      _CSITime, _
      _DeptPKID, _
      _ItemCategory, _
      _ItemNO, _
      _ItemName, _
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
        Return (_DeptItemPKID > 0)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_DeptItem

        Dim mInfo As New GEPCSI_DeptItem
        mInfo.DeptItemPKID = IIf(dr.IsNull("DeptItemPKID"), 0, Convert.ToInt32(dr.Item("DeptItemPKID")))
        mInfo.CSITime = IIf(dr.IsNull("CSITime"), 0, Convert.ToInt32(dr.Item("CSITime")))
        mInfo.DeptPKID = IIf(dr.IsNull("DeptPKID"), 0, Convert.ToInt32(dr.Item("DeptPKID")))
        mInfo.ItemCategory = IIf(dr.IsNull("ItemCategory"), 0, Convert.ToInt32(dr.Item("ItemCategory")))
        mInfo.ItemNO = IIf(dr.IsNull("ItemNO"), String.Empty, Convert.ToString(dr.Item("ItemNO")))
        mInfo.ItemName = IIf(dr.IsNull("ItemName"), String.Empty, Convert.ToString(dr.Item("ItemName")))
        mInfo.DisplayOrder = IIf(dr.IsNull("DisplayOrder"), String.Empty, Convert.ToString(dr.Item("DisplayOrder")))
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
        If _DeptItemPKID = 0 Then
            Return Insert()
        ElseIf _DeptItemPKID > 0 Then
            Return Update()
        Else
            _DeptItemPKID = 0
            Return False
        End If
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "GEPCSI_DeptItem_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_DeptItem
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DeptItem_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function


    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_DeptItemCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DeptItem_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mGEPCSI_DeptItem As New GEPCSI_DeptItemCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mGEPCSI_DeptItem.Add(TransformDr(dr))
        Next

        Return mGEPCSI_DeptItem

    End Function

    Public Shared Function GetDsBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DeptItem_GetInfoBySearchCondition", SearchString)
        If ds.Tables(0).Rows.Count = 0 AndAlso ds.Tables(1).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If
    End Function
    Public Shared Function GetallDsBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DeptItem_GetallInfoBySearchCondition", SearchString)
        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If
    End Function


#End Region
#End Region


End Class

