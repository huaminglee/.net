Imports System

''' <summary>
'''  GEPCSI_Result
''' </summary>

Public Class GEPCSI_Result

#Region " Constructors "
    Public Sub New()

    End Sub

#End Region


#Region " Private Fields "
    Private _ResultPKID As Integer
    Private _CSITime As Integer = 0
    Private _DeptPKID As Integer = 0
    Private _DeptName As String = String.Empty
    Private _AcceptGroup As String = String.Empty
    Private _AcceptDivision As String = String.Empty
    Private _AcceptDept As String = String.Empty
    Private _AcceptMan As String = String.Empty
    Private _AcceptExt As Integer = 0
    Private _AcceptEmail As String = String.Empty
    Private _SubmitGroup As String = String.Empty
    Private _SubmitDivision As String = String.Empty
    Private _SubmitDept As String = String.Empty
    Private _SubmitMan As String = String.Empty
    Private _SubmitExt As Integer = 0
    Private _SubmitEmail As String = String.Empty
    Private _SendTime As DateTime = DateTime.MaxValue
    Private _SubmitTime As DateTime = DateTime.MaxValue
    Private _IsSubmited As Integer = 0
    Private _Remark As String = String.Empty
    Private _Extend1 As String = String.Empty
    Private _Extend2 As String = String.Empty
    Private _Extend3 As String = String.Empty
    Private _Extend4 As String = String.Empty
    Private _Extend5 As String = String.Empty
    Private _SendStatus As String
#End Region

#Region " Public Properties"
    ''' <summary>
    ''' ResultPKID
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
    ''' 被調查單位PKID
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
    ''' 被調查單位名稱
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
    ''' 接收結果人的事業群
    ''' </summary>
    Public Property AcceptGroup() As String
        Get
            Return _AcceptGroup
        End Get
        Set(ByVal Value As String)
            _AcceptGroup = Value
        End Set
    End Property
    ''' <summary>
    ''' 接收結果人的事業處
    ''' </summary>
    Public Property AcceptDivision() As String
        Get
            Return _AcceptDivision
        End Get
        Set(ByVal Value As String)
            _AcceptDivision = Value
        End Set
    End Property
    ''' <summary>
    ''' 接收結果人的部門
    ''' </summary>
    Public Property AcceptDept() As String
        Get
            Return _AcceptDept
        End Get
        Set(ByVal Value As String)
            _AcceptDept = Value
        End Set
    End Property
    ''' <summary>
    ''' 接收結果人的訪問者
    ''' </summary>
    Public Property AcceptMan() As String
        Get
            Return _AcceptMan
        End Get
        Set(ByVal Value As String)
            _AcceptMan = Value
        End Set
    End Property
    ''' <summary>
    ''' 接收結果人的分機
    ''' </summary>
    Public Property AcceptExt() As Integer
        Get
            Return _AcceptExt
        End Get
        Set(ByVal Value As Integer)
            _AcceptExt = Value
        End Set
    End Property
    ''' <summary>
    ''' 接收結果人的EMail
    ''' </summary>
    Public Property AcceptEmail() As String
        Get
            Return _AcceptEmail
        End Get
        Set(ByVal Value As String)
            _AcceptEmail = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的事業群
    ''' </summary>
    Public Property SubmitGroup() As String
        Get
            Return _SubmitGroup
        End Get
        Set(ByVal Value As String)
            _SubmitGroup = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的事業處
    ''' </summary>
    Public Property SubmitDivision() As String
        Get
            Return _SubmitDivision
        End Get
        Set(ByVal Value As String)
            _SubmitDivision = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的部門
    ''' </summary>
    Public Property SubmitDept() As String
        Get
            Return _SubmitDept
        End Get
        Set(ByVal Value As String)
            _SubmitDept = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的訪問者
    ''' </summary>
    Public Property SubmitMan() As String
        Get
            Return _SubmitMan
        End Get
        Set(ByVal Value As String)
            _SubmitMan = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的分機
    ''' </summary>
    Public Property SubmitExt() As Integer
        Get
            Return _SubmitExt
        End Get
        Set(ByVal Value As Integer)
            _SubmitExt = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交結果人的EMail
    ''' </summary>
    Public Property SubmitEmail() As String
        Get
            Return _SubmitEmail
        End Get
        Set(ByVal Value As String)
            _SubmitEmail = Value
        End Set
    End Property

    ''' <summary>
    ''' 發送日期
    ''' </summary>
    Public Property SendTime() As DateTime
        Get
            Return _SendTime
        End Get
        Set(ByVal Value As DateTime)
            _SendTime = Value
        End Set
    End Property
    ''' <summary>
    ''' 提交日期
    ''' </summary>
    Public Property SubmitTime() As DateTime
        Get
            Return _SubmitTime
        End Get
        Set(ByVal Value As DateTime)
            _SubmitTime = Value
        End Set
    End Property
    ''' <summary>
    ''' 是否提交調查
    ''' </summary>
    Public Property IsSubmited() As Integer
        Get
            Return _IsSubmited
        End Get
        Set(ByVal Value As Integer)
            _IsSubmited = Value
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
    ''' 預留电话
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
    ''' 預留传真
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
    ''' 預留网址
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

    Public ReadOnly Property SendStatus() As String
        Get
            Select Case IsSubmited
                Case 0
                    _SendStatus = "未發送"
                Case 1
                    _SendStatus = "已發送"
                Case 2
                    _SendStatus = "已提交"
            End Select
            Return _SendStatus
        End Get
    End Property

#End Region

#Region " Method"
#Region " Private method"

    Private Function Update() As Integer
        _ResultPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_Result_Update", _
                   _ResultPKID, _
      _CSITime, _
      _DeptPKID, _
      _DeptName, _
      _AcceptGroup, _
      _AcceptDivision, _
      _AcceptDept, _
      _AcceptMan, _
      _AcceptExt, _
      _AcceptEmail, _
      _SubmitGroup, _
      _SubmitDivision, _
      _SubmitDept, _
      _SubmitMan, _
      _SubmitExt, _
      _SubmitEmail, _
      _SendTime, _
      _SubmitTime, _
      _IsSubmited, _
      _Remark, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5))
        Return (_ResultPKID)
    End Function

    Private Function Insert() As Integer
        _ResultPKID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, _
                             "GEPCSI_Result_Insert", _
                   _ResultPKID, _
      _CSITime, _
      _DeptPKID, _
      _DeptName, _
      _AcceptGroup, _
      _AcceptDivision, _
      _AcceptDept, _
      _AcceptMan, _
      _AcceptExt, _
      _AcceptEmail, _
      _SubmitGroup, _
      _SubmitDivision, _
      _SubmitDept, _
      _SubmitMan, _
      _SubmitExt, _
      _SubmitEmail, _
      _SendTime, _
      _SubmitTime, _
      _IsSubmited, _
      _Remark, _
      _Extend1, _
      _Extend2, _
      _Extend3, _
      _Extend4, _
      _Extend5))
        Return (_ResultPKID)
    End Function
    Private Shared Function TransformDr(ByVal dr As DataRow) As GEPCSI_Result

        Dim mInfo As New GEPCSI_Result
        mInfo.ResultPKID = IIf(dr.IsNull("ResultPKID"), 0, Convert.ToInt32(dr.Item("ResultPKID")))
        mInfo.CSITime = IIf(dr.IsNull("CSITime"), 0, Convert.ToInt32(dr.Item("CSITime")))
        mInfo.DeptPKID = IIf(dr.IsNull("DeptPKID"), 0, Convert.ToInt32(dr.Item("DeptPKID")))
        mInfo.DeptName = IIf(dr.IsNull("DeptName"), String.Empty, Convert.ToString(dr.Item("DeptName")))
        mInfo.AcceptGroup = IIf(dr.IsNull("AcceptGroup"), String.Empty, Convert.ToString(dr.Item("AcceptGroup")))
        mInfo.AcceptDivision = IIf(dr.IsNull("AcceptDivision"), String.Empty, Convert.ToString(dr.Item("AcceptDivision")))
        mInfo.AcceptDept = IIf(dr.IsNull("AcceptDept"), String.Empty, Convert.ToString(dr.Item("AcceptDept")))
        mInfo.AcceptMan = IIf(dr.IsNull("AcceptMan"), String.Empty, Convert.ToString(dr.Item("AcceptMan")))
        mInfo.AcceptExt = IIf(dr.IsNull("AcceptExt"), 0, Convert.ToInt32(dr.Item("AcceptExt")))
        mInfo.AcceptEmail = IIf(dr.IsNull("AcceptEmail"), String.Empty, Convert.ToString(dr.Item("AcceptEmail")))
        mInfo.SubmitGroup = IIf(dr.IsNull("SubmitGroup"), String.Empty, Convert.ToString(dr.Item("SubmitGroup")))
        mInfo.SubmitDivision = IIf(dr.IsNull("SubmitDivision"), String.Empty, Convert.ToString(dr.Item("SubmitDivision")))
        mInfo.SubmitDept = IIf(dr.IsNull("SubmitDept"), String.Empty, Convert.ToString(dr.Item("SubmitDept")))
        mInfo.SubmitMan = IIf(dr.IsNull("SubmitMan"), String.Empty, Convert.ToString(dr.Item("SubmitMan")))
        mInfo.SubmitExt = IIf(dr.IsNull("SubmitExt"), 0, Convert.ToInt32(dr.Item("SubmitExt")))
        mInfo.SubmitEmail = IIf(dr.IsNull("SubmitEmail"), String.Empty, Convert.ToString(dr.Item("SubmitEmail")))
        mInfo.SendTime = IIf(dr.IsNull("SendTime"), DateTime.MaxValue, dr.Item("SendTime"))
        mInfo.SubmitTime = IIf(dr.IsNull("SubmitTime"), DateTime.MaxValue, dr.Item("SubmitTime"))
        mInfo.IsSubmited = IIf(dr.IsNull("IsSubmited"), 0, Convert.ToInt32(dr.Item("IsSubmited")))
        mInfo.Remark = IIf(dr.IsNull("Remark"), String.Empty, Convert.ToString(dr.Item("Remark")))
        mInfo.Extend1 = IIf(dr.IsNull("Extend1"), String.Empty, Convert.ToString(dr.Item("Extend1")))
        mInfo.Extend2 = IIf(dr.IsNull("Extend2"), String.Empty, Convert.ToString(dr.Item("Extend2")))
        mInfo.Extend3 = IIf(dr.IsNull("Extend3"), String.Empty, Convert.ToString(dr.Item("Extend3")))
        mInfo.Extend4 = IIf(dr.IsNull("Extend4"), String.Empty, Convert.ToString(dr.Item("Extend4")))
        mInfo.Extend5 = IIf(dr.IsNull("Extend5"), String.Empty, Convert.ToString(dr.Item("Extend5")))
        Return mInfo
    End Function


#End Region

#Region " Public method"
    Public Function Save() As Integer
        If _ResultPKID = 0 Then
            Return Insert()
        ElseIf _ResultPKID > 0 Then
            Return Update()
        Else
            _ResultPKID = 0
            Return False
        End If
    End Function

    Public Shared Sub Delete(ByVal PKID As Integer)
        SqlHelper.ExecuteNonQuery(ConfigurationInfo.ConnectionString, "GEPCSI_Result_Delete", PKID)
    End Sub

    Public Shared Function GetInfoByPKID(ByVal PKID As Integer) As GEPCSI_Result
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Result_GetInfoByPKID", PKID)
        Dim dt As DataTable = ds.Tables(0)

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim dr As DataRow = dt.Rows(0)

        Return TransformDr(dr)
    End Function

    Public Shared Function UpdateStatus(ByVal SendResultPKID As String) As Boolean
        Dim FlagResult As Integer = 0
        FlagResult = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "GEPCSI_Result_UpdateByResultPKID", SendResultPKID))
        Return FlagResult > 0
    End Function
    Public Shared Function GetInfoBySearchCondtion(ByVal SearchString As String) As GEPCSI_ResultCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Result_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mResult As New GEPCSI_ResultCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mResult.Add(TransformDr(dr))
        Next

        Return mResult

    End Function

    Public Shared Function GetDsBySearchCondtion(ByVal SearchString As String) As DataSet
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Result_GetInfoBySearchCondition", SearchString)
        Dim dt As DataTable = ds.Tables(0)
        If (dt.Rows.Count = 0) Then
            Return Nothing
        Else
            Return ds
        End If

    End Function

    Public Shared Function GetImportDeptInfo(ByVal SearchString As String) As ArrayList
        Dim alist As New ArrayList
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Result_GetDeptNameInfoBySearchCondition", SearchString)
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
    Public Shared Function GetallDeptInfo() As ArrayList
        Dim alist As New ArrayList
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "GEPCSI_Dept_GetallDept")
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

    Public Shared Function LoadPageInfoBySearchcondition(ByVal searchcondition As String, ByVal TableName As String, ByVal PKIDKey As String, ByVal SorKey As String, ByVal pageindex As Integer, ByVal pagesize As Integer) As GEPCSI_ResultCollection
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConfigurationInfo.ConnectionString, "Paging_RowCount", TableName, PKIDKey, SorKey, pageindex, pagesize, "*", searchcondition, Nothing)
        Dim dt As DataTable = ds.Tables(0)
        Dim dr As DataRow
        Dim i As Integer

        If (dt.Rows.Count = 0) Then
            Return Nothing
        End If

        Dim mResult As New GEPCSI_ResultCollection
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            mResult.Add(TransformDr(dr))
        Next

        Return mResult
    End Function

    Public Shared Function LoadDataCount(ByVal TableName As String, ByVal PKIDKey As String, ByVal searchcondition As String) As Integer
        Return SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "LoadDataCountBySearchConition", TableName, PKIDKey, searchcondition)
    End Function
    Public Shared Function IsSubmit(ByVal deptpkid As Integer, ByVal Username As String) As Boolean
        Dim i As Integer = SqlHelper.ExecuteScalar(ConfigurationInfo.ConnectionString, "IsSubmit", deptpkid, Username)
        If i > 0 Then
            Return True
        ElseIf i = 0 Then
            Return False
        End If
    End Function
#End Region
#End Region

End Class

