Imports System

''' <summary>
'''  GEPCSI_Period
''' </summary>

Public Class GEPCSI_Period
#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _PKID As Integer
    Private _StartDate As DateTime = DateTime.MaxValue
    Private _EndDate As DateTime = DateTime.MaxValue
    Private _CSITime As Integer = 0
    Private _Notice As String
    Private _Extend1 As String = String.Empty
    Private _Extend2 As String = String.Empty
    Private _Extend3 As String = String.Empty
    Private _Extend4 As String = String.Empty
    Private _Extend5 As String = String.Empty
    Private _CreatedDate As DateTime = DateTime.Now
    Private _DeletedFlag As Integer = 0
    Private _RecordVersion As String = "V00001"

#End Region

#Region " Public Properties"
    ''' <summary>
    ''' 
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
    ''' 滿意度調查開始日期
    ''' </summary>
    Public Property StartDate() As DateTime
        Get
            Return _StartDate
        End Get
        Set(ByVal Value As DateTime)
            _StartDate = Value
        End Set
    End Property
    ''' <summary>
    ''' 滿意度調查結束日期
    ''' </summary>
    Public Property EndDate() As DateTime
        Get
            Return _EndDate
        End Get
        Set(ByVal Value As DateTime)
            _EndDate = Value
        End Set
    End Property
    ''' <summary>
    ''' 第幾次滿意度調查(每調查一次加1)
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
    ''' 注意事項
    ''' </summary>
    Public Property Notice() As String
        Get
            Return _Notice
        End Get
        Set(ByVal Value As String)
            _Notice = Value
        End Set
    End Property
    ''' <summary>
    ''' 
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
    ''' 
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
    ''' 
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
    ''' 
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
    ''' 
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
    ''' 
    ''' </summary>
    Public Property CreatedDate() As DateTime
        Get
            Return _CreatedDate
        End Get
        Set(ByVal Value As DateTime)
            _CreatedDate = Value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property DeletedFlag() As Integer
        Get
            Return _DeletedFlag
        End Get
        Set(ByVal Value As Integer)
            _DeletedFlag = Value
        End Set
    End Property
    ''' <summary>
    ''' 
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
        _PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_Period_Update", _
                   _PKID, _
      _StartDate, _
      _EndDate, _
      _CSITime, _
      _Notice, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5, _
      _CreatedDate, _
      _DeletedFlag, _
      _RecordVersion))
        Return (_PKID = 0)
    End Function

    Private Function Insert() As Boolean
        _PKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_Period_Insert", _
                   _PKID, _
      _StartDate, _
      _EndDate, _
      _CSITime, _
      _Notice, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5, _
      _CreatedDate, _
      _DeletedFlag, _
      _RecordVersion))
        Return (_PKID > 0)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_Period

        Dim mInfo As New GEPCSI_Period
        mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
        mInfo.StartDate = IIf(dr.IsNull("StartDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("StartDate")))
        mInfo.EndDate = IIf(dr.IsNull("EndDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("EndDate")))
        mInfo.CSITime = IIf(dr.IsNull("CSITime"), 0, Convert.ToInt32(dr.Item("CSITime")))
        mInfo.Notice = IIf(dr.IsNull("Notice"), String.Empty, Convert.ToString(dr.Item("Notice")))
        mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        mInfo.CreatedDate = IIf(dr.IsNull("CreatedDate"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("CreatedDate")))
        mInfo.DeletedFlag = IIf(dr.IsNull("DeletedFlag"), 0, Convert.ToInt32(dr.Item("DeletedFlag")))
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
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "GEPCSI_Period_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_Period
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Period_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function


    Public Shared Function GetLastPeriod() As GEPCSI_Period
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_PeriodGetLast")
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim dr As DataRow = dt.Rows(0)
        Return TransformDr(dr)
    End Function



    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_PeriodCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Period_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mGEPCSI_Period As New GEPCSI_PeriodCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mGEPCSI_Period.Add(TransformDr(dr))
        Next

        Return mGEPCSI_Period

    End Function

    Public Shared Function GetPeriodListInfo() As ArrayList
        Dim alist As New ArrayList
        Dim SearchString As String = String.Empty
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Period_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Integer
        If dt.Rows.Count = 0 Then
            Return Nothing
        Else
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow = dt.Rows(i)
                Dim ListItem As ListItem = New ListItem
                ListItem.Text = "第" + dr.Item("CSITime").ToString + "次調查"
                ListItem.Value = dr.Item("CSITime")
                If Not alist.Contains(ListItem) Then
                    alist.Add(ListItem)
                End If
            Next
            Return alist
        End If
    End Function

    ''' <summary>
    ''' 取得當前調查的次數
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNewCSITime() As String
        Dim ReturnDisplayOrder As String = "1"
        Dim Obj As Object = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "GEPCSI_Period_GetNewCsITime")
        If Not Obj Is Nothing Then
            ReturnDisplayOrder = Convert.ToString(Obj)
        End If
        Return ReturnDisplayOrder
    End Function  '取得當前調查的次數

#End Region
#End Region


End Class

