Imports System



''' <summary>
'''  GEPCSI_DetailResult
''' </summary>

Public Class GEPCSI_DetailResult
#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _DetailPKID As Integer
    Private _ResultPKID As Integer = 0
    Private _DeptItemPKID As Integer = 0
    Private _ItemCategory As Integer = 0
    Private _ItemName As String
    Private _ItemValue As String
    Private _ItemNGReason As Integer = 0
    Private _ItemNGText As String
    Private _Extend1 As String = String.Empty
    Private _Extend2 As String = String.Empty
    Private _Extend3 As String = String.Empty
    Private _Extend4 As String = String.Empty
    Private _Extend5 As String = String.Empty



#End Region

#Region " Public Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property DetailPKID() As Integer
        Get
            Return _DetailPKID
        End Get
        Set(ByVal Value As Integer)
            _DetailPKID = Value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property ResultPKID() As Integer
        Get
            Return _ResultPKID
        End Get
        Set(ByVal Value As Integer)
            _ResultPKID = Value
        End Set
    End Property
    ''' <summary>
    ''' 調查項目PKID
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
    ''' 調查項目值
    ''' </summary>
    Public Property ItemValue() As String
        Get
            Return _ItemValue
        End Get
        Set(ByVal Value As String)
            _ItemValue = Value
        End Set
    End Property
    ''' <summary>
    ''' 調查結果為不滿意時原因值和
    ''' </summary>
    Public Property ItemNGReason() As Integer
        Get
            Return _ItemNGReason
        End Get
        Set(ByVal Value As Integer)
            _ItemNGReason = Value
        End Set
    End Property
    ''' <summary>
    ''' 不滿意時原因拼接值,格式(1:T1^2:T2^3:T3^4:T4^5:T5)
    ''' </summary>
    Public Property ItemNGText() As String
        Get
            Return _ItemNGText
        End Get
        Set(ByVal Value As String)
            _ItemNGText = Value
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

#End Region

#Region " Method"
#Region " Private method"

    Private Function Update() As Boolean
        _DetailPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_DetailResult_Update", _
                   _DetailPKID, _
      _ResultPKID, _
      _DeptItemPKID, _
      _ItemCategory, _
      _ItemName, _
      _ItemValue, _
      _ItemNGReason, _
      _ItemNGText, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5))
        Return (_DetailPKID = 0)
    End Function

    Private Function Insert() As Boolean
        _DetailPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_DetailResult_Insert", _
                   _DetailPKID, _
      _ResultPKID, _
      _DeptItemPKID, _
      _ItemCategory, _
      _ItemName, _
      _ItemValue, _
      _ItemNGReason, _
      _ItemNGText, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5))
        Return (_DetailPKID > 0)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_DetailResult

        Dim mInfo As New GEPCSI_DetailResult
        mInfo.DetailPKID = IIf(dr.IsNull("DetailPKID"), 0, Convert.ToInt32(dr.Item("DetailPKID")))
        mInfo.ResultPKID = IIf(dr.IsNull("ResultPKID"), 0, Convert.ToInt32(dr.Item("ResultPKID")))
        mInfo.DeptItemPKID = IIf(dr.IsNull("DeptItemPKID"), 0, Convert.ToInt32(dr.Item("DeptItemPKID")))
        mInfo.ItemCategory = IIf(dr.IsNull("ItemCategory"), 0, Convert.ToInt32(dr.Item("ItemCategory")))
        mInfo.ItemName = IIf(dr.IsNull("ItemName"), String.Empty, Convert.ToString(dr.Item("ItemName")))
        mInfo.ItemValue = IIf(dr.IsNull("ItemValue"), String.Empty, Convert.ToString(dr.Item("ItemValue")))
        mInfo.ItemNGReason = IIf(dr.IsNull("ItemNGReason"), 0, Convert.ToInt32(dr.Item("ItemNGReason")))
        mInfo.ItemNGText = IIf(dr.IsNull("ItemNGText"), String.Empty, Convert.ToString(dr.Item("ItemNGText")))
        mInfo.Extend1 = IIf(dr.IsNull("ItemNO"), String.Empty, Convert.ToString(dr.Item("ItemNO")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        Return mInfo
    End Function


#End Region

#Region " Public method"
    Public Function Save() As Boolean
        If _DetailPKID = 0 Then
            Return Insert()
        ElseIf _DetailPKID > 0 Then
            Return Update()
        Else
            _DetailPKID = 0
            Return False
        End If
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_DetailResult
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function


    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_DetailResultCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mGEPCSI_DetailResult As New GEPCSI_DetailResultCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mGEPCSI_DetailResult.Add(TransformDr(dr))
        Next

        Return mGEPCSI_DetailResult

    End Function

    Public Shared Function GetAnswerInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_DetailResultCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_GetAnswerInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mGEPCSI_DetailResult As New GEPCSI_DetailResultCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mGEPCSI_DetailResult.Add(TransformDr(dr))
        Next

        Return mGEPCSI_DetailResult

    End Function

    Public Shared Function GetReportInfoBySearchCondition(ByVal SearchString As String, ByVal GroupName As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_VoteReportInfo_BySearchCondition", SearchString, GroupName)
        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If
    End Function

    Public Shared Function GetDsBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_GetInfoBySearchCondition", SearchString)
        If ds.Tables(0).Rows.Count = 0 AndAlso ds.Tables(1).Rows.Count = 0 Then
            Return Nothing
        Else
            Return ds
        End If
    End Function

    Public Shared Function GetNGItemBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_DetailResult_GetNGItemBySearchCondition", SearchString)
        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If

    End Function

#End Region
#End Region


End Class
