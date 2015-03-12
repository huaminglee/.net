Imports System.Runtime.InteropServices

Public Class Log
#Region "Constrcutors"
    Public Sub New()

    End Sub

    ''' <summary>
    ''' 插入日誌
    ''' </summary>
    ''' <param name="Type">記錄類型</param>
    ''' <param name="Operater">操作者</param>
    ''' <param name="Operated">對象，若對象不顯著，請輸入SYSTEM</param>
    ''' <param name="Time">記錄時間，一般是NOW</param>
    ''' <param name="IP">動作發生的IP，Request.UserHostAddress</param>
    ''' <param name="Action">動作</param>
    ''' <param name="Extend01">擴展字段</param>
    ''' <param name="Extend02">擴展字段</param>
    ''' <param name="Extend03">擴展字段</param>
    ''' <param name="Extend04">擴展字段</param>
    ''' <param name="Extend05">擴展字段</param>
    ''' <param name="Extend06">擴展字段</param>
    ''' <param name="Extend07">擴展字段</param>
    ''' <param name="Extend08">擴展字段</param>
    ''' <param name="Extend09">擴展字段</param>
    ''' <param name="Extend10">擴展字段</param>
    ''' <param name="RecordDeleted">軟刪除標記</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Type As Integer, ByVal Operater As String, ByVal Operated As String, ByVal Time As DateTime, ByVal IP As String, ByVal Action As String, Optional ByVal Extend01 As String = "", Optional ByVal Extend02 As String = "", Optional ByVal Extend03 As String = "", Optional ByVal Extend04 As String = "", Optional ByVal Extend05 As String = "", Optional ByVal Extend06 As String = "", Optional ByVal Extend07 As String = "", Optional ByVal Extend08 As String = "", Optional ByVal Extend09 As String = "", Optional ByVal Extend10 As String = "", Optional ByVal RecordDeleted As Integer = 0)
        Dim iLog As New Log()
        iLog.Type = Type
        iLog.Operater = Operater
        iLog.Operated = Operated
        iLog.Time = Time
        iLog.IP = IP 'Request.UserHostAddress
        iLog.MAC = GetMacAddress(IP)
        iLog.Action = Action
        iLog.Extend01 = Extend01
        iLog.Extend02 = Extend02
        iLog.Extend03 = Extend03
        iLog.Extend04 = Extend04
        iLog.Extend05 = Extend05
        iLog.Extend06 = Extend06
        iLog.Extend07 = Extend07
        iLog.Extend08 = Extend08
        iLog.Extend09 = Extend09
        iLog.Extend10 = Extend10
        iLog.RecordDeleted = RecordDeleted

        iLog.Insert()
    End Sub

#End Region

#Region "Private Field"
    Private _PKID As Integer
    Private _Type As Integer
    Private _Operater As String
    Private _Operated As String
    Private _Time As DateTime
    Private _IP As String
    Private _MAC As String
    Private _Action As String
    Private _Extend01 As String
    Private _Extend02 As String
    Private _Extend03 As String
    Private _Extend04 As String
    Private _Extend05 As String
    Private _Extend06 As String
    Private _Extend07 As String
    Private _Extend08 As String
    Private _Extend09 As String
    Private _Extend10 As String
    Private _RecordDeleted As Integer
#End Region

#Region "Public Properties"
    Public Property PKID() As Integer
        Get
            Return _PKID
        End Get
        Set(ByVal value As Integer)
            _PKID = value
        End Set
    End Property
    Public Property Type() As Integer
        Get
            Return _Type
        End Get
        Set(ByVal value As Integer)
            _Type = value
        End Set
    End Property
    Public Property Operater() As String
        Get
            Return _Operater
        End Get
        Set(ByVal value As String)
            _Operater = value
        End Set
    End Property
    Public Property Operated() As String
        Get
            Return _Operated
        End Get
        Set(ByVal value As String)
            _Operated = value
        End Set
    End Property
    Public Property Time() As DateTime
        Get
            Return _Time
        End Get
        Set(ByVal value As DateTime)
            _Time = value
        End Set
    End Property
    Public Property IP() As String
        Get
            Return _IP
        End Get
        Set(ByVal value As String)
            _IP = value
        End Set
    End Property
    Public Property MAC() As String
        Get
            Return _MAC
        End Get
        Set(ByVal value As String)
            _MAC = value
        End Set
    End Property
    Public Property Action() As String
        Get
            Return _Action
        End Get
        Set(ByVal value As String)
            _Action = value
        End Set
    End Property
    Public Property Extend01() As String
        Get
            Return _Extend01
        End Get
        Set(ByVal value As String)
            _Extend01 = value
        End Set
    End Property
    Public Property Extend02() As String
        Get
            Return _Extend02
        End Get
        Set(ByVal value As String)
            _Extend02 = value
        End Set
    End Property
    Public Property Extend03() As String
        Get
            Return _Extend03
        End Get
        Set(ByVal value As String)
            _Extend03 = value
        End Set
    End Property
    Public Property Extend04() As String
        Get
            Return _Extend04
        End Get
        Set(ByVal value As String)
            _Extend04 = value
        End Set
    End Property
    Public Property Extend05() As String
        Get
            Return _Extend05
        End Get
        Set(ByVal value As String)
            _Extend05 = value
        End Set
    End Property
    Public Property Extend06() As String
        Get
            Return _Extend06
        End Get
        Set(ByVal value As String)
            _Extend06 = value
        End Set
    End Property
    Public Property Extend07() As String
        Get
            Return _Extend07
        End Get
        Set(ByVal value As String)
            _Extend07 = value
        End Set
    End Property
    Public Property Extend08() As String
        Get
            Return _Extend08
        End Get
        Set(ByVal value As String)
            _Extend08 = value
        End Set
    End Property
    Public Property Extend09() As String
        Get
            Return _Extend09
        End Get
        Set(ByVal value As String)
            _Extend09 = value
        End Set
    End Property
    Public Property Extend10() As String
        Get
            Return _Extend10
        End Get
        Set(ByVal value As String)
            _Extend10 = value
        End Set
    End Property
    Public Property RecordDeleted() As Integer
        Get
            Return _RecordDeleted
        End Get
        Set(ByVal value As Integer)
            _RecordDeleted = value
        End Set
    End Property
#End Region

    Public Shared LogType() As String = New String() {"所有", "登入", "密碼修改", "資料修改"}

#Region "Methods"
    Public Function Insert() As Boolean
        Dim Result As Integer = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "Log_Insert", _
                                                                        _PKID, _
                                                                        _Type, _
                                                                        _Operater, _
                                                                        _Operated, _
                                                                        _Time, _
                                                                        _IP, _
                                                                        _MAC, _
                                                                        _Action, _
                                                                        _Extend01, _
                                                                        _Extend02, _
                                                                        _Extend03, _
                                                                        _Extend04, _
                                                                        _Extend05, _
                                                                        _Extend06, _
                                                                        _Extend07, _
                                                                        _Extend08, _
                                                                        _Extend09, _
                                                                        _Extend10, _
                                                                        _RecordDeleted))
        Return (Result > 0)
    End Function

    Private Shared Function TransformDr(ByVal dr As DataRow) As Log

        Dim mInfo As New Log()
        mInfo.PKID = IIf(dr.IsNull("PKID"), 0, Convert.ToInt32(dr.Item("PKID")))
        mInfo.Type = IIf(dr.IsNull("Type"), 0, Convert.ToInt32(dr.Item("Type")))
        mInfo.Operater = IIf(dr.IsNull("Operator"), String.Empty, Convert.ToString(dr.Item("Operator")))
        mInfo.Operated = IIf(dr.IsNull("Operated"), String.Empty, Convert.ToString(dr.Item("Operated")))
        mInfo.Time = IIf(dr.IsNull("Time"), DateTime.MaxValue, Convert.ToDateTime(dr.Item("Time")))
        mInfo.IP = IIf(dr.IsNull("IP"), String.Empty, Convert.ToString(dr.Item("IP")))
        mInfo.MAC = IIf(dr.IsNull("MAC"), String.Empty, Convert.ToString(dr.Item("MAC")))
        mInfo.Action = IIf(dr.IsNull("Action"), String.Empty, Convert.ToString(dr.Item("Action")))
        mInfo.Extend01 = IIf(dr.IsNull("Extend01"), String.Empty, Convert.ToString(dr.Item("Extend01")))
        mInfo.Extend02 = IIf(dr.IsNull("Extend02"), String.Empty, Convert.ToString(dr.Item("Extend02")))
        mInfo.Extend03 = IIf(dr.IsNull("Extend03"), String.Empty, Convert.ToString(dr.Item("Extend03")))
        mInfo.Extend04 = IIf(dr.IsNull("Extend04"), String.Empty, Convert.ToString(dr.Item("Extend04")))
        mInfo.Extend05 = IIf(dr.IsNull("Extend05"), String.Empty, Convert.ToString(dr.Item("Extend05")))
        mInfo.Extend06 = IIf(dr.IsNull("Extend06"), String.Empty, Convert.ToString(dr.Item("Extend06")))
        mInfo.Extend07 = IIf(dr.IsNull("Extend07"), String.Empty, Convert.ToString(dr.Item("Extend07")))
        mInfo.Extend08 = IIf(dr.IsNull("Extend08"), String.Empty, Convert.ToString(dr.Item("Extend08")))
        mInfo.Extend09 = IIf(dr.IsNull("Extend09"), String.Empty, Convert.ToString(dr.Item("Extend09")))
        mInfo.Extend10 = IIf(dr.IsNull("Extend10"), String.Empty, Convert.ToString(dr.Item("Extend10")))
        mInfo.RecordDeleted = IIf(dr.IsNull("RecordDeleted"), 0, Convert.ToInt32(dr.Item("RecordDeleted")))
        Return mInfo
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "Log_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByOperator(ByVal operater As String) As List(Of Log)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Log_GetInfoByOperator", operater)
        Dim dt As DataTable = ds.Tables(0)

        If dt.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim dr As DataRow
        Dim minfos As New List(Of Log)

        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            minfos.Add(TransformDr(dr))
        Next

        Return minfos
    End Function

    Public Shared Function GetInfoByOperated(ByVal operated As String) As List(Of Log)
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Log_GetInfoByOperated", operated)
        Dim dt As DataTable = ds.Tables(0)

        If dt.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim dr As DataRow
        Dim minfos As New List(Of Log)

        For i As Integer = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            minfos.Add(TransformDr(dr))
        Next

        Return minfos
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
               ByVal SortExpression As String, ByVal TableName As String, ByVal PageNumber As Integer, Optional ByVal PageSize As Integer = 20) As List(Of Log)
        Dim ds As DataSet = SearchExtHelper.SearchDataWithCustomPaging(ConfigurationInfo.ConnectionString, TableName, _
  "PKID", SortExpression, PageNumber, PageSize, Filter)

        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer
        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If
        Dim mInfos As New List(Of Log)
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mInfos.Add(TransformDr(dr))
        Next
        Return mInfos
    End Function

    Public Shared Function LoadInstanceCountgBySearch(ByVal Filter As String) As Integer

        Dim ResultCounut As Integer
        ResultCounut = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                                    "Log_loadInfoCountBySearchConditon", Filter))

        Return ResultCounut

    End Function

    <DllImport("Iphlpapi.dll")> Private Shared Function SendARP(ByVal dest As Int32, ByVal host As Int32, ByRef mac As Int64, ByRef length As Int32) As Int32

    End Function

    <DllImport("Ws2_32.dll")> Private Shared Function inet_addr(ByVal ip As String) As Int32

    End Function

    ''' <summary>
    ''' 只能獲取遠端客戶端MAC地址，若為LocalHost，則無法獲取,並且只能獲取同一網段內的電腦。
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMacAddress(ByVal ip As String) As String
        Try

            Dim ldest As Int32 = inet_addr(ip) ' 遠端客戶的ip
            Dim macinfo As Int64 = New Int64()
            Dim len As Int32 = 6
            Dim res As Int32 = SendARP(ldest, 0, macinfo, len)
            Dim mac_src As String = macinfo.ToString("X")

            While mac_src.Length < 12
                mac_src = mac_src.Insert(0, "0")
            End While

            Dim mac_dest As String = ""

            For index As Integer = 0 To 11

                If index Mod 2 = 0 Then

                    If index = 10 Then
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(index, 2))
                    Else
                        mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(index, 2))
                    End If

                End If

            Next

            Return mac_dest
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
#End Region
End Class
