Imports System
Imports System.Text
Imports System.Text.RegularExpressions

''' <summary>
''' 查詢表達式類
''' </summary>
''' <remarks></remarks>
Public Class SearchHelper

    ''' <summary>
    ''' 動態構建查詢字串
    ''' </summary>
    ''' <param name="columnName">查詢的資料欄位名</param>
    ''' <param name="keyword1">第一查詢關鍵字</param>
    ''' <param name="keyword2">第二查詢關鍵字</param>
    ''' <param name="hasContent">是否有查詢內容</param>
    ''' <param name="colType">查詢類別(可通過SearchType枚舉項進行設定)</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <example>
    ''' 	<code>
    '''         Dim tmp As Boolean = False
    '''         Dim key1 As String = "ABC"
    '''         Dim key2 As String = "CCC"
    '''         Dim key3 As Integer = 5
    '''         Dim search As String = ""
    '''         search += GetSearchString("col1", key1, "", tmp, 2)
    '''         search += GetSearchString("col2", key2, "", tmp, 3)
    '''         search += GetSearchString("col3", key3, "", tmp, 1)
    '''         search += GetSearchString("DateCol", "2006-01-01", "2006-02-01", tmp, 4)
    '''         Me.TextBox1.Text = search
    ''' 	</code>
    ''' </example>
    Public Shared Function GetSearchString(ByVal columnName As String, ByVal keyword1 As String, ByVal keyword2 As String, ByRef hasContent As Boolean, ByVal colType As Integer) As String
        If keyword1 = String.Empty Then
            Return ""
        Else
            Dim tmp As StringBuilder = New StringBuilder("")
            Select Case colType
                Case 1
                    '數字
                    tmp.Append(columnName)
                    tmp.Append(" = ")
                    tmp.Append(keyword1)
                Case 2
                    '字符串,精確查詢
                    tmp.Append(columnName)
                    tmp.Append(" = '")
                    tmp.Append(keyword1)
                    tmp.Append("' ")
                Case 3
                    '字符串,模糊查詢
                    tmp.Append(columnName)
                    tmp.Append(" like '%")
                    tmp.Append(keyword1)
                    tmp.Append("%' ")
                Case 4
                    '日期查詢
                    tmp.Append(columnName)
                    tmp.Append(" Between cast('")
                    tmp.Append(keyword1)
                    tmp.Append("' as datetime) and dateadd(day,1,cast('")
                    tmp.Append(keyword1)
                    tmp.Append("' as datetime))")
                Case 5
                    '數字范圍查詢
                    tmp.Append(columnName)
                    tmp.Append(" Between ")
                    tmp.Append(keyword1)
                    tmp.Append("  and ")
                    tmp.Append(keyword2)
                    tmp.Append(" ")
                Case 6
                    '日期范圍查詢
                    tmp.Append(columnName)
                    tmp.Append(" Between cast('")
                    tmp.Append(keyword1)
                    tmp.Append("' as datetime) and cast('")
                    tmp.Append(keyword2)
                    tmp.Append("' as datetime)")
            End Select

            If (hasContent) Then
                tmp.Insert(0, " and ")
            End If
            hasContent = True
            Return tmp.ToString()
        End If

    End Function

    ''' <summary>
    ''' 搜索類別
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Enum SearchType

        ''' <summary>
        ''' 數字查詢類別
        ''' </summary>
        NumberType = 1

        ''' <summary>
        ''' 字串精確查詢類別
        ''' </summary>
        StringStrict = 2

        ''' <summary>
        ''' 字串模糊查詢類別
        ''' </summary>
        StringNoStrict = 3

        ''' <summary>
        ''' 指定日期並往後一天的日期查詢類別
        ''' </summary>
        DateType = 4

        ''' <summary>
        ''' 間於指定數字范圍的查詢類別
        ''' </summary>
        NumberBetween = 5

        ''' <summary>
        ''' 間於指定日期范圍的查詢類別
        ''' </summary>
        DateTypeNoStrict = 6


    End Enum

End Class

''' <summary>
''' 動態條件查詢表達式生成類
''' </summary>
''' <remarks>
''' <example>
''' <code>
'''     Dim obj As New SearchHelper.SearchWhereClause
'''     obj.AddSearchTerm("FinishedFlag", obj.CompareOperator.BetweenDays, "2008/12/30", "2009/01/31")
'''     obj.AddSearchTerm("DeleteFlag", obj.CompareOperator.NotEqual, "1", "")
'''     Me.TextBox1.Text = obj.WhereClause
'''  </code>
''' </example> 
''' </remarks>
Public Class SearchWhereClause
    ''' <summary>
    ''' 查詢組成項結構
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure SearchTerm
        ''' <summary>
        '''查詢項目
        ''' </summary>
        ''' <remarks></remarks>
        Friend mField As String
        ''' <summary>
        ''' 查詢值1
        ''' </summary>
        ''' <remarks></remarks>
        Friend mValue1 As String
        ''' <summary>
        ''' 查詢值2
        ''' </summary>
        ''' <remarks></remarks>
        Friend mValue2 As String
        ''' <summary>
        ''' 查詢計算條件
        ''' </summary>
        ''' <remarks></remarks>
        Friend mCondition As String
        ''' <summary>
        ''' 查詢多條件時的操作關系
        ''' </summary>
        ''' <remarks></remarks>
        Friend mCompareOperator As CompareOperator

        Friend Sub SetProperty(ByVal Field As String, ByVal mOperator As CompareOperator, ByVal Value1 As String, ByVal Value2 As String, ByVal Condition As String)
            mField = Field
            mValue1 = Value1
            mValue2 = Value2
            mCompareOperator = mOperator
            mCondition = Condition
        End Sub

        ''' <summary>
        ''' 查詢字段/資料庫欄位名
        ''' </summary>
        ''' <value></value>
        ''' <returns>資料庫欄位名</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Field() As String
            Get
                Return mField
            End Get
        End Property

        ''' <summary>
        ''' 查詢值1
        ''' </summary>
        ''' <value></value>
        ''' <returns>查詢值或查詢上下界值中的下界值</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Value1() As String
            Get
                Return mValue1
            End Get
        End Property

        ''' <summary>
        ''' 查詢值2
        ''' </summary>
        ''' <value></value>
        ''' <returns>查詢上下界值中的上界值</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Value2() As String
            Get
                Return mValue2
            End Get
        End Property

        ''' <summary>
        ''' 查詢條件的計算方式
        ''' </summary>
        ''' <value></value>
        ''' <returns>查詢條件的計算方式,如大於、小於、包含、等於、介於等等</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CompareOperator() As CompareOperator
            Get
                Return mCompareOperator
            End Get
        End Property

        ''' <summary>
        ''' 查詢多條件時的操作關系
        ''' </summary>
        ''' <value></value>
        ''' <returns>查詢多條件時的操作關系, And / OR </returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Condition() As String
            Get
                Return mCondition
            End Get
        End Property

    End Structure

    Private mSearchTerms As New ArrayList
    Private mWhereClause As String
    Private mUserInputWhereClause As String

    ''' <summary>
    ''' 建構式
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' 添加查詢條件式
    ''' </summary>
    ''' <param name="Field">查詢字段</param>
    ''' <param name="mOperator">查詢條件計算方法</param>
    ''' <param name="Value1">查詢值1</param>
    ''' <param name="Value2">查詢值2</param>
    ''' <param name="mConditionOperator">查詢多條件時的操作關系</param>
    ''' <remarks></remarks>
    Public Sub AddSearchTerm(ByVal Field As String, ByVal mOperator As CompareOperator, ByVal Value1 As String, ByVal Value2 As String, Optional ByVal mConditionOperator As ConditionOperator = ConditionOperator.AndOperator)
        Dim term As New SearchTerm
        Dim Condition As String = String.Empty
        If mSearchTerms.Count > 0 Then
            Select Case mConditionOperator
                Case ConditionOperator.AndOperator
                    Condition = " AND "
                Case ConditionOperator.OrOperator
                    Condition = " OR "
            End Select
        Else
            Condition = ""
        End If
        term.SetProperty(Field, mOperator, Value1, Value2, Condition)
        mSearchTerms.Add(term)
    End Sub

    ''' <summary>
    ''' 清除查詢條件
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearSearchTerm()
        mSearchTerms.Clear()
    End Sub

    ''' <summary>
    ''' 查詢表達式集合
    ''' </summary>
    ''' <value></value>
    ''' <returns>已設定的查詢表達式集合</returns>
    ''' <remarks></remarks>
    Public Property SearchTerms() As ArrayList
        Get
            Return mSearchTerms
        End Get
        Set(ByVal Value As ArrayList)
            mSearchTerms = Value
        End Set
    End Property

    ''' <summary>
    ''' 查詢表達式的SQL拼接字串結果
    ''' </summary>
    ''' <value></value>
    ''' <returns>查詢表達式的SQL拼接字串結果</returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WhereClause() As String
        Get
            Dim Term As SearchTerm
            Dim sb As New System.Text.StringBuilder
            For Each Term In SearchTerms
                sb.Append(ConvertOperator(Term))
            Next
            Return sb.ToString
        End Get
    End Property

    ''' <summary>
    ''' 用戶輸入的直接查詢條件
    ''' </summary>
    ''' <value></value>
    ''' <returns>用戶輸入的直接查詢條件</returns>
    ''' <remarks></remarks>
    Public Property UserInputWhereClause() As String
        Get
            Return mUserInputWhereClause
        End Get
        Set(ByVal value As String)
            mUserInputWhereClause = value
        End Set
    End Property

    Private Shared Function ConvertOperator(ByVal Term As SearchTerm) As String
        Dim sb As New System.Text.StringBuilder
        Select Case Term.CompareOperator
            Case CompareOperator.Equal
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" = ")
                sb.Append(Term.Value1)
                sb.Append(")")
            Case CompareOperator.EqualString
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" = N'")
                sb.Append(Term.Value1)
                sb.Append("')")
            Case CompareOperator.NotEqual
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" <> ")
                sb.Append(Term.Value1)
                sb.Append(")")
            Case CompareOperator.NotEqualString
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" <> N'")
                sb.Append(Term.Value1)
                sb.Append("')")
            Case CompareOperator.Contains
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" LIKE N'%")
                sb.Append(FormatQuery(Term.Value1))
                sb.Append("%'")
                sb.Append(")")
            Case CompareOperator.StartWith
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" LIKE N'")
                sb.Append(FormatQuery(Term.Value1))
                sb.Append(":perc:'")
                sb.Append(")")
            Case CompareOperator.NotStartWith
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" NOT LIKE N'")
                sb.Append(FormatQuery(Term.Value1))
                sb.Append(":perc:'")
                sb.Append(")")
            Case CompareOperator.GreaterThan
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" > '")
                sb.Append(Term.Value1)
                sb.Append("'")
                sb.Append(")")
            Case CompareOperator.LessThan
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" < '")
                sb.Append(Term.Value1)
                sb.Append("'")
                sb.Append(")")
            Case CompareOperator.BetweenNumber
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" Between ")
                sb.Append(Term.Value1)
                sb.Append(" And ")
                sb.Append(Term.Value2)
                sb.Append(")")
            Case CompareOperator.BetweenOneDay
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" Between Cast('")
                sb.Append(Term.Value1)
                sb.Append("' As DateTime) AND DateAdd(Day,1,Cast('")
                sb.Append(Term.Value1)
                sb.Append("' As DateTime))")
                sb.Append(")")
            Case CompareOperator.BetweenDays
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" Between Cast('")
                sb.Append(Term.Value1)
                sb.Append("' As DateTime) And Cast('")
                sb.Append(Term.Value2)
                sb.Append("' As DateTime)")
                sb.Append(")")
            Case CompareOperator.HaveValueIn
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" IN ")
                sb.Append("(" & Term.Value1 & ")")
                sb.Append(")")
            Case CompareOperator.NotHaveValueIn
                sb.Append(Term.Condition & "(")
                sb.Append(Term.Field)
                sb.Append(" NOT IN ")
                sb.Append("(" & Term.Value1 & ")")
                sb.Append(")")
        End Select

        Return sb.ToString

    End Function

    Private Shared Function FormatQuery(ByVal Query As String) As String
        Dim strReturn As String = Query
        strReturn = Query.Replace("'", "''")
        strReturn = strReturn.Replace("%", "[%]")
        strReturn = strReturn.Replace("-", "[-]")
        Return strReturn
    End Function

    ''' <summary>
    ''' 查詢條件計算操作方法枚舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum CompareOperator As Integer
        ''' <summary>
        ''' 包含文字(子串)
        ''' </summary>
        ''' <remarks></remarks>
        Contains = 0
        ''' <summary>
        ''' 數值型等於
        ''' </summary>
        ''' <remarks></remarks>
        Equal = 1
        ''' <summary>
        ''' 字串型等於
        ''' </summary>
        ''' <remarks></remarks>
        EqualString = 2
        ''' <summary>
        ''' 數值型不等於
        ''' </summary>
        ''' <remarks></remarks>
        NotEqual = 3
        ''' <summary>
        ''' 字串型不等於
        ''' </summary>
        ''' <remarks></remarks>
        NotEqualString = 4
        ''' <summary>
        ''' 介於兩個數值之間
        ''' </summary>
        ''' <remarks></remarks>
        BetweenNumber = 5
        ''' <summary>
        ''' 大於
        ''' </summary>
        ''' <remarks></remarks>
        GreaterThan = 6
        ''' <summary>
        ''' 小於
        ''' </summary>
        ''' <remarks></remarks>
        LessThan = 7
        ''' <summary>
        ''' 存在值
        ''' </summary>
        ''' <remarks></remarks>
        HaveValueIn = 8
        ''' <summary>
        ''' 不存在值
        ''' </summary>
        ''' <remarks></remarks>
        NotHaveValueIn = 9
        ''' <summary>
        ''' 文字開始於
        ''' </summary>
        ''' <remarks></remarks>
        StartWith = 10
        ''' <summary>
        ''' 文字不開始於
        ''' </summary>
        ''' <remarks></remarks>
        NotStartWith = 11
        ''' <summary>
        ''' 日期在一天內
        ''' </summary>
        ''' <remarks></remarks>
        BetweenOneDay = 12
        ''' <summary>
        ''' 日期在一個時間段內
        ''' </summary>
        ''' <remarks></remarks>
        BetweenDays = 13
    End Enum

    ''' <summary>
    ''' 查詢多條件時的操作關系枚舉
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ConditionOperator As Integer
        ''' <summary>
        ''' And 關系
        ''' </summary>
        ''' <remarks></remarks>
        AndOperator = 1
        ''' <summary>
        ''' Or 關系
        ''' </summary>
        ''' <remarks></remarks>
        OrOperator = 2
    End Enum

End Class

