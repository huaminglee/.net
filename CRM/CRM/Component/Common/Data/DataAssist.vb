Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports C1.C1Excel
Imports System.Web.Caching

Public Class DataAssist

#Region "Js MessageBox"
    Public Shared Sub ShowMessage(ByVal text As String, ByVal page As Page)
        page.RegisterStartupScript(Guid.NewGuid().ToString(), "<script>window.alert('" & text & "')</script>")
    End Sub

    Public Shared Sub ShowMessageRedirect(ByVal text As String, ByVal page As Page, ByVal url As String)
        page.RegisterStartupScript(Guid.NewGuid().ToString(), "<script>window.alert('" & text & "');window.location.href='" & url & "'</script>")
    End Sub
    Public Shared Sub OpenUrlNew(ByVal Url As String, ByVal page As Page)
        page.RegisterStartupScript(Guid.NewGuid().ToString(), "<script>window.open('" & Url & "')</script>")
    End Sub
    Public Shared Sub ShowMessage(ByVal text As String, ByVal page As Page, ByVal url As String)
        page.RegisterStartupScript(Guid.NewGuid().ToString(), "<script>window.alert('" & text & "');window.location.href='" & url & "'</script>")
    End Sub
#End Region

#Region "Security Function"

    ''' <summary>
    ''' 將明文通過MD5方式加密
    ''' </summary>
    ''' <param name="CleanString">要加密的文本</param>
    ''' <returns>返回MD5加密後的密文</returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt(ByVal CleanString As String) As String
        Dim clearBytes As [Byte]()
        clearBytes = New UnicodeEncoding().GetBytes(CleanString)
        Dim hashedBytes As [Byte]() = CType(CryptoConfig.CreateFromName("MD5"), HashAlgorithm).ComputeHash(clearBytes)
        Dim hashedText As String = BitConverter.ToString(hashedBytes)
        Return hashedText

    End Function '用戶密碼加密

#End Region

#Region "DataTable Operation"

    ''' <summary>
    ''' 往指定的數據表中加入一個自增1的整型欄位
    ''' </summary>
    ''' <param name="ActiveTable">要加入自增1的整型欄位的數據表</param>
    ''' <remarks></remarks>
    Public Shared Sub AddAutoIncrement(ByVal ActiveTable As Data.DataTable)
        Dim i As Integer
        Dim cCustID As New DataColumn("NO", System.Type.GetType("System.Int32"))
        If ActiveTable.Columns.Contains("NO") Then
            ActiveTable.Columns.Remove("NO")
        End If
        With cCustID
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        ActiveTable.Columns.Add(cCustID)
        For i = 0 To ActiveTable.Rows.Count - 1
            ActiveTable.Rows(i).Item("NO") = i + 1
        Next
    End Sub

    ''' <summary>
    ''' 往指定的數據表中加入一個文本欄位
    ''' </summary>
    ''' <param name="ActiveTable">要加入文本欄位的數據表</param>
    ''' <param name="ColumnName">要加入的欄位名稱</param>
    ''' <param name="RowCellValue">要加入的欄位文本值</param>
    ''' <remarks></remarks>
    Public Shared Sub AddTextColumn(ByVal ActiveTable As Data.DataTable, ByVal ColumnName As String, ByVal RowCellValue As String)
        Dim i As Integer
        Dim cColumn As New DataColumn(ColumnName, System.Type.GetType("System.String"))
        If ActiveTable.Columns.Contains(ColumnName) Then
            ActiveTable.Columns.Remove(ColumnName)
        End If
        ActiveTable.Columns.Add(cColumn)
        For i = 0 To ActiveTable.Rows.Count - 1
            ActiveTable.Rows(i).Item(ColumnName) = RowCellValue
        Next
    End Sub

#End Region

#Region "Data Verify Operation"
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
    End Function

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
    End Function

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
    End Function


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
    End Function


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 判斷指定的字符串是否可以解析為非負整數類型
    ''' </summary>
    ''' <param name="SourceParseString"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[F2156972]	2007/6/15	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ParseNonNegativeInteger(ByVal SourceParseString As String) As Boolean
        Dim m As Match = Regex.Match(SourceParseString, "^\d+$")
        If m.Success Then
            Return True
        Else
            Return False
        End If
    End Function


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
            Catch ex As Exception
                'Input Format Error（FormatException）
                Return False
            End Try
            Return True
        End If
    End Function

#End Region

#Region "Search Operation"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 動態構建查詢字串
    ''' </summary>
    ''' <param name="columnName"></param>
    ''' <param name="keyword1"></param>
    ''' <param name="keyword2"></param>
    ''' <param name="hasContent"></param>
    ''' <param name="colType"></param>
    ''' <returns></returns>
    ''' <remarks>
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
    ''' </remarks>
    ''' <history>
    ''' 	[F2156972]	2006/10/9	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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
                    tmp.Append(" like '% ")
                    tmp.Append(keyword1)
                    tmp.Append("%' ")
                Case 4
                    '日期查詢
                    tmp.Append(columnName)
                    tmp.Append(" Between '")
                    tmp.Append(keyword1)
                    tmp.Append("' and '")
                    tmp.Append(keyword2)
                    tmp.Append("'")
            End Select

            If (hasContent) Then
                tmp.Insert(0, " and ")
            End If
            hasContent = True
            Return tmp.ToString()
        End If

    End Function
#End Region

#Region "XML"

    ''' <summary>
    ''' 傳入參數下拉菜單，與XML數據綁定
    ''' </summary>
    ''' <param name="DDL"></param>
    ''' <remarks></remarks>
    Public Shared Sub DDL_BDWithXML(ByRef DDL As DropDownList)
        Dim ds As DataSet = New DataSet()
        ds.ReadXml(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\Resource\DDLResource.xml")
        DDL.DataSource = ds.Tables(DDL.ID)
        DDL.DataTextField = "text"
        DDL.DataValueField = "value"
        DDL.DataBind()
    End Sub
    ''' <summary>
    ''' 根據傳參，從XML表中取得另外一個數值（text或者value）
    ''' </summary>
    ''' <param name="TableName"></param>
    ''' <param name="key"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInfoFromXML(ByVal TableName As String, ByVal key As String, ByVal value As String) As String
        Dim ds As DataSet = New DataSet()
        ds.ReadXml(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath) + "\Resource\DDLResource.xml")
        Dim dt As DataTable = ds.Tables(TableName)
        Dim dr() As DataRow = dt.Select(key + "='" + value + "'")
        If dr.Length > 0 Then
            If dr(0).Item(0).ToString = value Then
                Return dr(0).Item(1).ToString
            Else
                Return dr(0).Item(0).ToString
            End If
        Else
            Return ""
        End If
    End Function
#End Region



End Class
