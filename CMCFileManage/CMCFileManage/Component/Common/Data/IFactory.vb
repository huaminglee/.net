
''' <summary>
''' 調用listaction的UCtrl時需繼承此接口
''' </summary>
''' <remarks></remarks>
Public Interface IFactory
    Sub Delete(ByVal PKID As Integer)
    Function GetInfosBySearchCondition(ByVal SearchString As String) As DataSet
End Interface


Public MustInherit Class Factory

    Protected MustOverride Function Insert() As Boolean
    Protected MustOverride Function Update() As Boolean
    Public MustOverride Property PKID() As Integer

    Public Overridable Function Save() As Boolean
        If PKID = 0 Then
            Return Insert()
        ElseIf PKID > 0 Then
            Return Update()
        Else
            PKID = 0
            Return False
        End If
    End Function
    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="PKID">需要刪除數據的PKID</param>
    ''' <remarks></remarks>
    Public MustOverride Sub Delete(ByVal PKID As Integer)

    ''' <summary>
    ''' 通過PKID查詢一條數據
    ''' </summary>
    ''' <param name="PKID">需要要搜尋的PKID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function GetInfoByPKID(ByVal PKID As Integer) As Object
    ''' <summary>
    ''' 根據條件查詢
    ''' </summary>
    ''' <param name="SearchString">查詢條件</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function GetInfosBySearchCondition(ByVal SearchString As String) As Object

End Class


