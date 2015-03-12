Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection



''' <summary>
''' 數據輔助類
''' </summary>
''' <remarks></remarks>
Public Class ADONetHelper

#Region "DataTable Operation"
    ''' <summary>
    ''' 比較兩個表的不同，返回含有不同項的DataTable
    ''' </summary>
    ''' <param name="First">要比較的第一個表</param>
    ''' <param name="Second">要比較的第二個表</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' <example>
    ''' <code lang='vbnet'>
    '''  Dim sT As DataTable = New DataTable
    '''  Dim c1 As New DataColumn("c1", System.Type.GetType("System.String"))
    '''  Dim c2 As New DataColumn("c2", System.Type.GetType("System.String"))
    '''  sT.Columns.AddRange(New DataColumn() {c1, c2})
    '''  Dim r1 As DataRow = sT.NewRow
    '''  r1.Item("c1") = "S1"
    '''  r1.Item("c2") = "S2"
    '''  sT.Rows.Add(r1)
    '''  Dim r2 As DataRow = sT.NewRow
    '''  r2.Item("c1") = "S3"
    '''  r2.Item("c2") = "S4"
    '''  sT.Rows.Add(r2)
    '''  Dim DT As DataTable = New DataTable
    '''  Dim Dc1 As New DataColumn("c1", System.Type.GetType("System.String"))
    '''  Dim Dc2 As New DataColumn("c3", System.Type.GetType("System.String"))
    '''  DT.Columns.AddRange(New DataColumn() {Dc1, Dc2})
    '''  Dim Dr1 As DataRow = DT.NewRow
    '''  Dr1.Item("c1") = "D1"
    '''  Dr1.Item("c3") = "D2"
    '''  DT.Rows.Add(Dr1)
    '''  Dim Dr2 As DataRow = DT.NewRow
    '''  Dr2.Item("c1") = "S3"
    '''  Dr2.Item("c3") = "S4"
    '''  DT.Rows.Add(Dr2)
    '''  Dim DifTable As DataTable = Difference(DT, sT)
    '''  Me.DataGrid1.DataSource = DifTable
    '''  Me.DataGrid1.DataBind()
    ''' </code>
    ''' </example>
    '''</remarks>
    Public Shared Function Difference(ByVal First As DataTable, ByVal Second As DataTable) As DataTable
        '================================================================================================
        'http://weblogs.sqlteam.com/davidm/archive/2004/01/19/739.aspx
        'The DIFFERENCE Method has no equivalent in TSQL.
        'It is also refered to as MINUS and is simply all the rows that are in the First table but not the Second.
        'The argument order of the method is important. That is: Difference(First, Second) != Difference(Second, First)

        'There is only the one signature for this method.
        'In summary the code works as follows:

        '  Create new empty table
        '  Create a DataSet and add tables.
        '  Get a reference to all columns in both tables
        '  Create a DataRelation
        '  Using the DataRelation add rows with no child rows.
        '  Return table
        '================================================================================================

        'Create Empty Table 
        Dim table As New DataTable("Difference")
        'Must use a Dataset to make use of a DataRelation object 
        Dim ds As New DataSet
        'Add tables 
        ds.Tables.AddRange(New DataTable() {First.Copy(), Second.Copy()})

        'Get Columns for DataRelation 
        Dim firstcolumns As DataColumn() = New DataColumn(ds.Tables(0).Columns.Count - 1) {}
        For i As Integer = 0 To firstcolumns.Length - 1
            firstcolumns(i) = ds.Tables(0).Columns(i)
        Next

        Dim secondcolumns As DataColumn() = New DataColumn(ds.Tables(1).Columns.Count - 1) {}
        For i As Integer = 0 To secondcolumns.Length - 1
            secondcolumns(i) = ds.Tables(1).Columns(i)
        Next

        'Create DataRelation 
        Dim r As New DataRelation(String.Empty, firstcolumns, secondcolumns, False)
        ds.Relations.Add(r)
        For i As Integer = 0 To First.Columns.Count - 1
            'Create columns for return table 
            table.Columns.Add(First.Columns(i).ColumnName, First.Columns(i).DataType)
        Next
        'If First Row not in Second, Add to return table. 
        table.BeginLoadData()
        For Each parentrow As DataRow In ds.Tables(0).Rows
            Dim childrows As DataRow() = parentrow.GetChildRows(r)
            If childrows Is Nothing OrElse childrows.Length = 0 Then
                table.LoadDataRow(parentrow.ItemArray, True)
            End If
        Next
        table.EndLoadData()
        Return table

    End Function

    ''' <summary>
    ''' 內聯接兩個DataTable,返回聯接後的DataTable
    ''' </summary>
    ''' <param name="dtLeft">聯接的左表</param>
    ''' <param name="dtRight">聯接的右表</param>
    ''' <param name="columnLeft">左表聯接欄位</param>
    ''' <param name="columnRight">右表聯接欄位</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function JoinDataTable(ByVal dtLeft As DataTable, ByVal dtRight As DataTable, ByVal columnLeft As String, ByVal columnRight As String) As DataTable
        If Not dtLeft.Columns.Contains(columnLeft) Then
            Throw New Exception(String.Format("No column named ""{0}"" in table ""{1}"" ", columnLeft, dtLeft.TableName))
        End If
        If Not dtRight.Columns.Contains(columnRight) Then
            Throw New Exception(String.Format("No column named ""{0}"" in table ""{1}"" ", columnRight, dtRight.TableName))
        End If
        Dim dtJoined As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dtLeft)
        ds.Tables.Add(dtRight)
        Dim drRelation As New DataRelation(Nothing, dtLeft.Columns(columnLeft), dtRight.Columns(columnRight), False)
        ds.Relations.Add(drRelation)

        For Each dc As DataColumn In dtLeft.Columns
            dtJoined.Columns.Add(dc.ColumnName, dc.DataType)
        Next
        For Each dc As DataColumn In dtRight.Columns
            If Not dtJoined.Columns.Contains(dc.ColumnName) Then
                dtJoined.Columns.Add(dc.ColumnName, dc.DataType)
            End If
        Next
        dtJoined.BeginLoadData()
        For Each drLeft As DataRow In dtLeft.Rows
            Dim arrDataLeft As Object() = drLeft.ItemArray

            For Each drRight As DataRow In drLeft.GetChildRows(drRelation)
                Dim arrDataRight As Object() = drRight.ItemArray
                Dim arrDataJoined As Object() = New Object(arrDataLeft.Length + arrDataRight.Length - 1) {}
                Array.Copy(arrDataLeft, 0, arrDataJoined, 0, arrDataLeft.Length)
                Array.Copy(arrDataRight, 0, arrDataJoined, arrDataLeft.Length, arrDataRight.Length)
                dtJoined.LoadDataRow(arrDataJoined, True)
            Next
        Next
        dtJoined.EndLoadData()
        Return dtJoined
    End Function

    ''' <summary>
    ''' 往指定的數據表中加入一個自增1的整型欄位
    ''' </summary>
    ''' <param name="ActiveTable">要加入自增1的整型欄位的數據表</param>
    ''' <remarks></remarks>
    Public Shared Sub AddAutoIncrement(ByVal ActiveTable As System.Data.DataTable)
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
    End Sub '往指定的數據表中加入一個自增1的整型欄位

    ''' <summary>
    ''' 往指定的數據表中加入一個文本欄位
    ''' </summary>
    ''' <param name="ActiveTable">要加入文本欄位的數據表</param>
    ''' <param name="ColumnName">要加入的欄位名稱</param>
    ''' <param name="IsFillValue">是否要填入默認的值</param> 
    ''' <param name="RowCellValue">要加入的欄位文本值</param>
    ''' <remarks></remarks>
    Public Shared Sub AddTextColumn(ByVal ActiveTable As System.Data.DataTable, ByVal ColumnName As String, ByVal IsFillValue As Boolean, ByVal RowCellValue As String)
        Dim i As Integer
        Dim cColumn As New DataColumn(ColumnName, System.Type.GetType("System.String"))
        If ActiveTable.Columns.Contains(ColumnName) Then
            ActiveTable.Columns.Remove(ColumnName)
        End If
        ActiveTable.Columns.Add(cColumn)
        If IsFillValue Then
            For i = 0 To ActiveTable.Rows.Count - 1
                ActiveTable.Rows(i).Item(ColumnName) = RowCellValue
            Next
        End If
    End Sub '往指定的數據表中加入一個文本欄位

    ''' <summary>
    ''' 交叉表
    ''' </summary>
    ''' <param name="DataSetName">返回的Dataset數據集名稱</param>
    ''' <param name="result">數據源，為SqlDataReader類型</param>
    ''' <param name="FixedColumns">交叉表左邊固定的欄位</param>
    ''' <param name="VariableColumns"></param>
    ''' <param name="KeyColumn">源數據集中的主鍵欄位</param>
    ''' <param name="FieldColumn"></param>
    ''' <param name="FieldTypeColumn"></param>
    ''' <param name="StringValueColumn"></param>
    ''' <param name="NumericValueColumn"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' <example>
    ''' <code>
    '''    Dim dr As SqlDataReader = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("DBschemeConnStr"), "PRACScheme_SchemeMachine_LoadMachineYields")
    '''      Dim VarColumnsStr As String
    '''      Dim AlistVarColumnName As ArrayList = New ArrayList
    '''      Dim sb As New StringBuilder
    '''      If Not dr Is Nothing Then
    '''            While dr.Read
    '''              Dim ColumnName As String = dr.Item("MachineName").ToString
    '''              If Not AlistVarColumnName.Contains(ColumnName) Then
    '''                    If Not Integer.Equals(AlistVarColumnName.Count ,0) Then
    '''                       sb.Append(",")
    '''                    End If
    '''                    sb.Append(ColumnName + "|String")
    '''                   AlistVarColumnName.Add(ColumnName)
    '''                End If
    '''           End While
    '''           If Not dr.IsClosed Then dr.Close()
    '''       End If
    '''
    '''       dr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("DBschemeConnStr"), "PRACScheme_SchemeMachine_LoadMachineYields")
    '''       Dim ds As DataSet = DataHelper.BuildCrossTabDataSet("dsName", dr, "MaterialTexture|String", sb.ToString,"PKID", "MachineName", String.Empty, "yield", String.Empty)
    '''       Dim dt As DataTable = ds.Tables(0).Clone
    '''       Dim PrimaryKey(1) As DataColumn
    '''       PrimaryKey(0) = dt.Columns(0)
    '''       dt.PrimaryKey = PrimaryKey
    '''       Dim i As Integer 'Row Var
    '''       Dim j As Integer 'Column Var
    '''       Dim ColumnCount As Integer = ds.Tables(0).Columns.Count
    '''       Dim RowCount As Integer = ds.Tables(0).Rows.Count
    '''        For i = 0 To RowCount - 1
    '''            Dim DataSourceRow As DataRow = ds.Tables(0).Rows(i)
    '''            Dim OldDataRow As DataRow = dt.Rows.Find(DataSourceRow.Item("MaterialTexture"))
    '''            If OldDataRow Is Nothing Then
    '''               Dim NewRow As DataRow = dt.NewRow
    '''               For j = 0 To ColumnCount - 1
    '''                    NewRow.Item(j) = DataSourceRow.Item(j)
    '''                Next
    '''                dt.Rows.Add(NewRow)
    '''            Else
    '''                For j = 0 To ColumnCount - 1
    '''                    If OldDataRow.Item(j).ToString.Trim = "" Then
    '''                        OldDataRow.Item(j) = DataSourceRow.Item(j)
    '''                    End If
    '''                Next
    '''            End If
    '''        Next
    '''        Me.DataGrid1.DataSource = dt
    '''        Me.DataGrid1.DataBind()
    '''        Me.DataGrid2.DataSource = ds.Tables(0)
    '''        Me.DataGrid2.DataBind()
    '''        If Not dr.IsClosed Then dr.Close()
    ''' </code>
    ''' </example>
    ''' </remarks>
    Public Shared Function BuildCrossTabDataSet(ByVal DataSetName As String, ByVal result As IDataReader, ByVal FixedColumns As String, _
    ByVal VariableColumns As String, ByVal KeyColumn As String, ByVal FieldColumn As String, ByVal FieldTypeColumn As String, _
    ByVal StringValueColumn As String, ByVal NumericValueColumn As String) As DataSet

        Dim arrFixedColumns As String()
        Dim arrVariableColumns As String() = Nothing
        Dim arrField As String()
        Dim FieldType As String
        Dim intColumn As Integer
        Dim intKeyColumn As Integer

        ' create dataset
        Dim crosstab As New DataSet(DataSetName)
        crosstab.Namespace = "NetFrameWork"

        ' create table
        Dim tab As New DataTable(DataSetName)

        ' split fixed columns
        arrFixedColumns = FixedColumns.Split(",".ToCharArray())

        ' add fixed columns to table
        For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
            arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
            Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
            tab.Columns.Add(col)
        Next intColumn

        ' split variable columns
        If VariableColumns <> "" Then
            arrVariableColumns = VariableColumns.Split(",".ToCharArray())

            ' add varible columns to table
            For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                Dim col As New DataColumn(arrField(0), System.Type.GetType("System." & arrField(1)))
                col.AllowDBNull = True
                tab.Columns.Add(col)
            Next intColumn
        End If

        ' add table to dataset
        crosstab.Tables.Add(tab)

        ' add rows to table
        intKeyColumn = -1
        Dim row As DataRow = Nothing
        While result.Read()
            ' loop using KeyColumn as control break
            If Convert.ToInt32(result(KeyColumn)) <> intKeyColumn Then
                ' add row
                If intKeyColumn <> -1 Then
                    tab.Rows.Add(row)
                End If

                ' create new row
                row = tab.NewRow()

                ' assign fixed column values
                For intColumn = LBound(arrFixedColumns) To UBound(arrFixedColumns)
                    arrField = arrFixedColumns(intColumn).Split("|".ToCharArray())
                    row(arrField(0)) = result(arrField(0))
                Next intColumn

                ' initialize variable column values
                If VariableColumns <> "" Then
                    For intColumn = LBound(arrVariableColumns) To UBound(arrVariableColumns)
                        arrField = arrVariableColumns(intColumn).Split("|".ToCharArray())
                        Select Case arrField(1)
                            Case "Decimal"
                                row(arrField(0)) = 0
                            Case "String"
                                row(arrField(0)) = ""
                        End Select
                    Next intColumn
                End If

                intKeyColumn = Convert.ToInt32(result(KeyColumn))
            End If

            ' assign pivot column value
            If FieldTypeColumn <> "" Then
                FieldType = result(FieldTypeColumn).ToString
            Else
                FieldType = "String"
            End If
            Select Case FieldType
                Case "Decimal"       ' decimal
                    row(Convert.ToInt32(result(FieldColumn))) = result(NumericValueColumn)
                Case "String"       ' string
                    row(result(FieldColumn).ToString) = result(StringValueColumn)
            End Select
        End While

        result.Close()

        ' add row
        If intKeyColumn <> -1 Then
            tab.Rows.Add(row)
        End If

        ' finalize dataset
        crosstab.AcceptChanges()

        ' return the dataset
        Return crosstab

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 將指定的DataReader轉換成DataTable
    ''' </summary>
    ''' <param name="dataReader">要轉換的DataReader</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' -----------------------------------------------------------------------------
    Public Shared Function ConvertDataReaderToDataTable(ByVal dataReader As SqlDataReader) As DataTable
        Dim datatable As DataTable = New DataTable
        datatable.TableName = "TempTable"

        Dim schemaTable As DataTable = dataReader.GetSchemaTable

        For Each myRow As DataRow In schemaTable.Rows
            Dim myDataColumn As DataColumn = New DataColumn
            myDataColumn.DataType = myRow.GetType
            myDataColumn.ColumnName = myRow(0).ToString
            datatable.Columns.Add(myDataColumn)
        Next
        While dataReader.Read
            Dim myDataRow As DataRow = datatable.NewRow
            Dim i As Integer = 0
            While i < schemaTable.Rows.Count
                myDataRow(i) = dataReader(i).ToString
                System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            datatable.Rows.Add(myDataRow)
            myDataRow = Nothing
        End While
        schemaTable = Nothing
        dataReader.Close()
        Return datatable
    End Function

#End Region

#Region "Entity Convert"

    Public Shared Function ToDataTable(Of T)(ByVal entitys As List(Of T)) As DataTable
        If entitys Is Nothing OrElse entitys.Count < 1 Then
            Throw New Exception("需要轉換的集合為空.")
        End If

        Dim entityType As Type = entitys(0).GetType
        Dim entityProperties As PropertyInfo() = entityType.GetProperties

        Dim dt As New DataTable
        For i As Integer = 0 To entityProperties.Length - 1
            dt.Columns.Add(entityProperties(i).Name, entityProperties(i).PropertyType)
        Next
        For Each entity As Object In entitys
            If Not entity.GetType Is entityType Then
                Throw New Exception("要轉換的集合元素類型不一致.")
            End If

            Dim entityValues As Object() = New Object(entityProperties.Length - 1) {}
            For i As Integer = 0 To entityProperties.Length - 1
                entityValues(i) = entityProperties(i).GetValue(entity, Nothing)
            Next
            dt.Rows.Add(entityValues)
        Next
        Return dt
    End Function

    Public Shared Function CreateEntityFromRow(Of T)(ByVal dataRow As System.Data.DataRow) As T
        '下面实现的前提是:属性名与字段名存在明确的对应规则 
        '下面假定对应规则是:字段名称与属性名称相同 
        '其实一般字段名称与属性的对应关系是通过Attribute或XML配置做到的. 可以查阅ORM相关技术 
        Dim entity As T = System.Activator.CreateInstance(Of T)()
        '动态构建对象 
        Dim propertys As System.Reflection.PropertyInfo() = GetType(T).GetProperties()
        '所有属性 
        For Each [property] As System.Reflection.PropertyInfo In propertys
            Dim propertyValue As Object = dataRow([property].Name)
            '假定字段名称与属性名称相同,对象的属性赋值 
            [property].SetValue(entity, propertyValue, Nothing)
        Next
        Return entity
    End Function

    ''' <summary> 
    ''' 根据DataSet构建泛型对象集合 
    ''' </summary> 
    ''' <typeparam name="T">泛型 </typeparam> 
    ''' <param name="tbl">数据表. </param> 
    ''' <returns>泛型对象集合 </returns> 
    Public Shared Function GetEntitysFromTbl(Of T)(ByVal tbl As System.Data.DataTable) As List(Of T)
        Dim entitys As New List(Of T)(tbl.Rows.Count)
        For Each dataRow As System.Data.DataRow In tbl.Rows
            Dim entity As T = CreateEntityFromRow(Of T)(dataRow)
            entitys.Add(entity)
        Next
        Return entitys
    End Function

#End Region

End Class

