'仿寫別人寫的一個加密的東西
'隻實現了加密字符串與解密字符串的功能
'加密文件與解密文件的功能被注釋掉了
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System


Public Class BasePape
#Region "私有成員"
    '輸入字符串
    Private sInputString As String = Nothing
    '輸出字符串
    Private sOutputString As String = Nothing
    '輸入文件路徑
    Private sInputFilePath As String = Nothing
    '輸出文件路徑
    Private sOutputFilePath As String = Nothing
    '加密密鑰
    Private sEncryptKey As String = Nothing
    '解密密鑰
    Private sDecryptKey As String = Nothing
    '提示信息
    Private sTipMsg As String = Nothing

#End Region
#Region "公共屬性"
    '輸入字符串
    Public Overridable Property InputString() As String
        Get
            Return sInputString
        End Get
        Set(ByVal value As String)
            sInputString = value
        End Set
    End Property

    '輸出字符串
    Public Overridable Property OutputString() As String
        Get
            Return sOutputString
        End Get
        Set(ByVal value As String)
            sOutputString = value
        End Set
    End Property

    '輸入文件路徑
    Public Overridable Property InputFilePath() As String
        Get
            Return sInputFilePath
        End Get
        Set(ByVal value As String)
            sInputFilePath = value
        End Set
    End Property

    '輸出文件路徑
    Public Overridable Property OutputFilePath() As String
        Get
            Return sOutputFilePath
        End Get
        Set(ByVal value As String)
            sOutputFilePath = value
        End Set
    End Property

    '加密密鑰 
    Public Overridable Property EncryptKey() As String
        Get
            Return sEncryptKey
        End Get
        Set(ByVal value As String)
            sEncryptKey = value
        End Set
    End Property

    '解密密鑰
    Public Overridable Property DecryptKey() As String
        Get
            Return sDecryptKey
        End Get
        Set(ByVal value As String)
            sDecryptKey = value
        End Set
    End Property

    '提示信息
    Public Overridable Property TipMsg() As String
        Get
            Return sTipMsg
        End Get
        Set(ByVal value As String)
            sTipMsg = value
        End Set
    End Property
#End Region
#Region "構造函數"
    Public Sub New()

    End Sub
#End Region
#Region "Des加密字符串"
    '加密字符串
    '注意：密鑰必須為8位
    '<param name="strText">字符串</param>
    '<param name= "encryptKey">密鑰</param>
    Public Sub DesEncrypt()
        Dim byKey As Byte() = Nothing
        Dim IV As Byte() = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            byKey = Encoding.UTF8.GetBytes(sEncryptKey.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider
            Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(sInputString)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            sOutputString = System.Convert.ToBase64String(ms.ToArray)
        Catch ex As Exception
            sTipMsg = ex.Message
        End Try
    End Sub
#End Region
#Region "DES解密字符串"
    '解密字符串
    '<param name="Me.sInputString">加了密的字符串</param>
    '<param name="decryptKey">密鑰</param>
    Public Overridable Sub DesDecrypt()
        Dim byKey As Byte() = Nothing
        Dim IV As Byte() = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray As Byte()
        ReDim inputByteArray(sInputString.Length)
        Try
            byKey = Encoding.UTF8.GetBytes(sDecryptKey.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(sInputString)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim enc As Encoding = New UTF8Encoding
            sOutputString = enc.GetString(ms.ToArray)
        Catch ex As Exception
            Me.sTipMsg = ex.Message
        End Try

    End Sub
#End Region

    '編碼
    Public Shared Function EncodeStr(ByVal value As String) As String
        Dim i As Integer
        Dim temp As String = ""
        For i = 0 To value.Length - 1
            If temp = "" Then
                temp = Asc(value.Chars(i)).ToString
            Else
                temp = temp + "*" + Asc(value.Chars(i)).ToString
            End If
        Next
        Return temp
    End Function

    '解碼
    Public Shared Function DecodeStr(ByVal value As String) As String
        Dim i As Integer
        Dim arr As String() = value.Split("*".ToString)
        Dim temp As String = ""
        For i = 0 To UBound(arr)
            temp = temp + Chr(CInt(arr(i)))
        Next
        Return temp
    End Function
End Class

