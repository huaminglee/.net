Public Class Json

   

   
    Public Shared Function ToJson(ByVal allCount As Integer, ByVal tableSource As DataTable, ByVal fields As List(Of String)) As String
        If fields.Count < 1 Then
            Throw New Exception("fields count must be 1 or more")
        End If
        Dim Json As StringBuilder = New StringBuilder()

        ' Json.Append("{""total"":" + tableSource.Rows.Count.ToString + ",")
        Json.Append("{""total"":" + allCount.ToString + ",")

        Json.Append("""rows"":[")
        If (Not tableSource Is Nothing AndAlso tableSource.Rows.Count > 0) Then
            Dim i As Integer
            For i = 0 To tableSource.Rows.Count - 1 Step i + 1
                Json.Append("{")
                For j As Integer = 0 To fields.Count - 1
                    Json.Append("""" + fields(j) + """:""" + tableSource.Rows(i)(fields(j)).ToString() + """")
                    If (j < fields.Count - 1) Then
                        Json.Append(",")
                    End If
                Next
                Json.Append("}")
                If (i < tableSource.Rows.Count - 1) Then
                    Json.Append(",")
                End If

            Next


            Json.Append("]}")
        Else
            Json.Append("]}")

        End If
        Return Json.ToString
    End Function

    Public Shared Function ToJson(ByVal DT As DataTable) As String
        Dim Json As StringBuilder = New StringBuilder()
        Json.Append("{""rows"":[")
        Dim DecimalFormat As String = ConfigurationInfo.DeciamalFormat
        If (Not DT Is Nothing AndAlso DT.Rows.Count > 0) Then
            Dim i As Integer
            For i = 0 To DT.Rows.Count - 1 Step i + 1
                Json.Append("{")

                Dim j As Integer
                For j = 0 To DT.Columns.Count - 1
                    If DT.Columns(j).DataType.Name = "Decimal" Then
                        Json.Append("""" + DT.Columns(j).ColumnName.ToString() + """:""" + CDec(DT.Rows(i)(j)).ToString(DecimalFormat) + """ ")
                    Else
                        Json.Append("""" + DT.Columns(j).ColumnName.ToString() + """:""" + DT.Rows(i)(j).ToString() + """ ")

                    End If

                    If (j < DT.Columns.Count - 1) Then
                        Json.Append(",")
                    End If
                Next
                Json.Append("}")
                If (i < DT.Rows.Count - 1) Then
                    Json.Append(",")
                End If
            Next
        End If
        Json.Append("]}")


        Return Json.ToString
    End Function

    Public Shared Function ToJsonAndFooter(ByVal DT As DataTable, ByVal IsShowFooter As Boolean, ByVal FooterName As List(Of String)) As String
        Dim Json As StringBuilder = New StringBuilder()
        Dim DecimalFormat As String = ConfigurationInfo.DeciamalFormat
        Json.Append("{""rows"":[")
        Dim SumExpense As Decimal = 0
        If (Not DT Is Nothing AndAlso DT.Rows.Count > 0) Then
            Dim i As Integer

            For i = 0 To DT.Rows.Count - 1 Step i + 1
                Json.Append("{")

                Dim j As Integer
                For j = 0 To DT.Columns.Count - 1
                    Json.Append("""" + DT.Columns(j).ColumnName.ToString() + """:""" + DT.Rows(i)(j).ToString() + """ ")
                    If (j < DT.Columns.Count - 1) Then
                        Json.Append(",")
                    End If
                    
                Next

                If (IsShowFooter) Then
                    SumExpense = SumExpense + (Convert.ToDecimal(DT.Rows(i)(FooterName(1))) * Convert.ToDecimal(DT.Rows(i)(FooterName(2))))

                End If
                Json.Append("}")
                If (i < DT.Rows.Count - 1) Then
                    Json.Append(",")
                End If
            Next
        End If

        If (IsShowFooter) Then
            Json.AppendLine("],""footer"":[{")
            Json.AppendLine("""" + FooterName(0) + """:""測試費用""")
            Json.AppendLine(",""" + FooterName(1) + """:""" + SumExpense.ToString(DecimalFormat) + """} ")
        End If
        Json.Append("]}")


        Return Json.ToString
    End Function


    Public Shared Function DeptToJson(ByVal dt As DataTable, ByVal fields As List(Of String), ByVal DeptLevel As Integer, ByVal IsOpen As Boolean)
        Dim Json As StringBuilder = New StringBuilder()
        Json.Append("[")
        If (Not dt Is Nothing AndAlso dt.Rows.Count > 0) Then
            Dim i As Integer

            For i = 0 To dt.Rows.Count - 1 Step i + 1
                Json.Append("{")

                Dim j As Integer
                For j = 0 To fields.Count - 1

                    Json.Append("" + fields(j) + ":""" + dt.Rows(i)(fields(j)).ToString() + """")
                    If (j < fields.Count - 1) Then
                        Json.Append(",")
                    End If
                Next
                If dt.Rows(i)("DeptLevel") <= DeptLevel AndAlso IsOpen = True Then
                    Json.Append(", open:true ")
                End If
                Json.Append("}")
                If (i < dt.Rows.Count - 1) Then
                    Json.Append(",")
                End If
            Next


        End If
        Json.Append("]")


        Return Json.ToString
    End Function


End Class
