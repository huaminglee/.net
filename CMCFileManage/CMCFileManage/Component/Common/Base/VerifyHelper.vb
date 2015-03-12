Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

''' -----------------------------------------------------------------------------
''' Project	 : MPTTimeTrack
''' Class	 : VerifyHelper
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 系統校驗類
''' </summary>
''' <remarks>
''' </remarks>
''' -----------------------------------------------------------------------------
Public Class VerifyHelper

#Region "        String Length"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 校驗輸入的字串長度，若有超過截斷超過長度的部分
    ''' </summary>
    ''' <param name="VerifyString"></param>
    ''' <param name="Length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function VerifyStringLength(ByVal VerifyString As String, ByVal Length As Integer) As String
        If (VerifyString Is Nothing) Then
            Return String.Empty
        Else
            If VerifyString.Trim.Length <= Length Then
                Return VerifyString.Trim
            Else
                Return VerifyString.Trim.Substring(0, Length)
            End If
        End If
    End Function ' 校驗輸入的字串長度，若有超過截斷超過長度的部分

#End Region

#Region "        Integer Verify"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為數字類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseIsNum(ByVal SourceParseString As String) As Boolean
        If Not (SourceParseString Is Nothing) Then
            If SourceParseString.Trim.Length = 0 Then
                Return False
            End If
            If Not IsNumeric(SourceParseString) Then
                Return False
            End If
            Return True
        End If
    End Function '判斷指定的字符串是否可以解析為數字類型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為正數數字類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseIsPositiveNum(ByVal SourceParseString As String) As Boolean
        If Not (SourceParseString Is Nothing) Then
            If SourceParseString.Trim.Length = 0 Then
                Return False
            End If
            If Not IsNumeric(SourceParseString) Then
                Return False
            End If
            If Not Convert.ToSingle(SourceParseString) >= 0 Then
                Return False
            End If
            Return True
        End If
    End Function '判斷指定的字符串是否可以解析為正數數字類型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為正整型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseIsPositiveInteger(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^[0-9]*[1-9][0-9]*$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function '判斷指定的字符串是否可以解析為正整型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為負整型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseIsNegativeInteger(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^-[0-9]*[1-9][0-9]*$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function ' 判斷指定的字符串是否可以解析為負整型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為非負整數類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ParseNonNegativeInteger(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^\d+$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function ' 判斷指定的字符串是否可以解析為非負整數類型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為正數類型
    ''' </summary>
    ''' <param name="SourceParseString">解析字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ParsePositiveNumber(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為浮點數類型
    ''' </summary>
    ''' <param name="SourceParseString">解析字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ParseFloatNumber(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^(-?\d+)(\.\d+)?$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "        String Verify"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 驗証隻有字母
        ''' </summary>
        ''' <param name="InString">待驗証的字串</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidOnllyChar(ByVal InString As String) As Boolean
        Return Regex.IsMatch(InString, "^[A-Za-z]+$")
    End Function '驗証隻有字母

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証隻有數字
    ''' </summary>
    ''' <param name="strln">待驗証的字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidOnlyNumber(ByVal strln As String) As Boolean
        Return Regex.IsMatch(strln, "^[0-9]+$")
    End Function '驗証隻有數字

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証隻有數字和字母
    ''' </summary>
    ''' <param name="strln">待驗証的字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidOnlyNumberAndChar(ByVal strln As String) As Boolean
        Return Regex.IsMatch(strln, "^[A-Za-z0-9]+$") '由数字和26个英文字母组成的字符串)
    End Function '驗証由数字和26个英文字母组成的字符串

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証隻有中文
    ''' </summary>
    ''' <param name="InString">待驗証的字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidOnllyChinese(ByVal InString As String) As Boolean
        Return Regex.IsMatch(InString, "^[\u4e00-\u9fa5]+$")
    End Function '驗証隻有中文

    ''' <summary>
    ''' 只能是數字
    ''' </summary>
    ''' <param name="InString">要驗證的字串</param>
    ''' <param name="maxDigitalBit">最長的小數位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidNumder(ByVal InString As String, ByVal maxDigitalBit As Integer) As Boolean
        Return Regex.IsMatch(InString, "^(\d*)([.]{0,1})(\d{0," + maxDigitalBit.ToString + "})$")
    End Function '驗證金額等只能是數字

#End Region

#Region "        DateTime Verify"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為日期時間類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ParseIsDate(ByVal SourceParseString As String) As Boolean
        If Not (SourceParseString Is Nothing) Then
            If SourceParseString.Trim.Length = 0 Then
                Return False
            End If
            Try
                Dim dt As DateTime = DateTime.Parse(SourceParseString)
            Catch ex As System.Exception
                'Input Format Error（FormatException）
                Return False
            End Try
            Return True
        End If
    End Function '判斷指定的字符串是否可以解析為日期時間類型

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為日期時間類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidDate(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^[12]{1}(\d){3}[-][01]?(\d){1}[-][0123]?(\d){1}$")
        If m.Success Then
            Return SourceParseString.CompareTo("1753-01-01") >= 0
        Else
            Return False
        End If
    End Function '判斷指定的字符串是否可以解析為日期時間類型

    Public Shared Function ParseIsDateTime(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[0-9])|([1-2][0-3]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function ParseIsDate2(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2]0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function ParseIsDate3(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^((((1[6-9]|[2-9]d)d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]d|3[01]))|(((1[6-9]|[2-9]d)d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]d|30))|(((1[6-9]|[2-9]d)d{2})-0?2-(0?[1-9]|1d|2[0-8]))|(((1[6-9]|[2-9]d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "        Other Verify"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証Email
    ''' </summary>
    ''' <param name="InString">待驗証的Email</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidEmail(ByVal InString As String) As Boolean
        Return Regex.IsMatch(InString, "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
    End Function '驗証Email

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証傳真號碼
    ''' </summary>
    ''' <param name="InString">傳入的傳真號碼</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidFax(ByVal InString As String) As Boolean
        Return Regex.IsMatch(InString, "^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$")
    End Function '驗証傳真號碼

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証是否為移動電話
    ''' </summary>
    ''' <param name="InString"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function IsValidMobil(ByVal InString As String) As Boolean
        Return Regex.IsMatch(InString, "^(\d)+[-]?(\d){6,12}$")
    End Function '驗証是否為移動電話

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 驗証是否為強密碼長度
    ''' </summary>
    ''' <param name="strln">待驗証的字串</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function isValidPassWord(ByVal strln As String) As Boolean
        Return Regex.IsMatch(strln, "^(\w){6,20}$")
    End Function '驗証是否為強密碼長度
#End Region

End Class

