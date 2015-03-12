Imports System.Data.SqlClient
Imports System.Xml

''' <summary>
''' SQL數據操作類
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class SqlHelper

#Region "    Private utility methods & constructors"

    Private Sub New()
    End Sub

    Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
        If (command Is Nothing) Then Throw New ArgumentNullException("command")
        If (Not commandParameters Is Nothing) Then
            Dim p As SqlParameter
            For Each p In commandParameters
                If (Not p Is Nothing) Then
                    ' Check for derived output value with no value assigned
                    If (p.Direction = ParameterDirection.InputOutput OrElse p.Direction = ParameterDirection.Input) AndAlso p.Value Is Nothing Then
                        p.Value = DBNull.Value
                    End If
                    command.Parameters.Add(p)
                End If
            Next p
        End If
    End Sub ' AttachParameters

    Private Overloads Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal dataRow As DataRow)

        If commandParameters Is Nothing OrElse dataRow Is Nothing Then
            ' Do nothing if we get no data    
            Exit Sub
        End If

        ' Set the parameters values
        Dim commandParameter As SqlParameter
        Dim i As Integer
        For Each commandParameter In commandParameters
            ' Check the parameter name
            If (commandParameter.ParameterName Is Nothing OrElse commandParameter.ParameterName.Length <= 1) Then
                Throw New Exception(String.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: ' {1}' .", i, commandParameter.ParameterName))
            End If
            If dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) <> -1 Then
                commandParameter.Value = dataRow(commandParameter.ParameterName.Substring(1))
            End If
            i = i + 1
        Next
    End Sub

    Private Overloads Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

        Dim i As Integer
        Dim j As Integer

        If (commandParameters Is Nothing) AndAlso (parameterValues Is Nothing) Then
            ' Do nothing if we get no data
            Return
        End If

        ' We must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        ' Value array
        j = commandParameters.Length - 1
        For i = 0 To j
            ' If the current array value derives from IDbDataParameter, then assign its Value property
            If TypeOf parameterValues(i) Is IDbDataParameter Then
                Dim paramInstance As IDbDataParameter = CType(parameterValues(i), IDbDataParameter)
                If (paramInstance.Value Is Nothing) Then
                    commandParameters(i).Value = DBNull.Value
                Else
                    commandParameters(i).Value = paramInstance.Value
                End If
            ElseIf (parameterValues(i) Is Nothing) Then
                commandParameters(i).Value = DBNull.Value
            Else
                commandParameters(i).Value = parameterValues(i)
            End If
        Next
    End Sub ' AssignParameterValues

    Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                      ByVal connection As SqlConnection, _
                                      ByVal transaction As SqlTransaction, _
                                      ByVal commandType As CommandType, _
                                      ByVal commandText As String, _
                                      ByVal commandParameters() As SqlParameter, ByRef mustCloseConnection As Boolean)

        If (command Is Nothing) Then Throw New ArgumentNullException("command")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        ' If the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            connection.Open()
            mustCloseConnection = True
        Else
            mustCloseConnection = False
        End If

        ' Associate the connection with the command
        command.Connection = connection

        ' Set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        ' If we were provided a transaction, assign it.
        If Not (transaction Is Nothing) Then
            If transaction.Connection Is Nothing Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
            command.Transaction = transaction
        End If

        ' Set the command type
        command.CommandType = commandType

        ' Attach the command parameters if they are provided
        If Not (commandParameters Is Nothing) Then
            AttachParameters(command, commandParameters)
        End If
        Return
    End Sub ' PrepareCommand

#End Region

#Region "    ExecuteNonQuery"

    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteNonQuery(connection, commandType, commandText, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal connectionString As String, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(connection, commandType, commandText, CType(Nothing, SqlParameter()))

    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Integer
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        ' Finally, execute the command
        retval = cmd.ExecuteNonQuery()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        If (mustCloseConnection) Then connection.Close()

        Return retval
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String) As Integer
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteNonQuery(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Integer
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Finally, execute the command
        retval = cmd.ExecuteNonQuery()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval
    End Function ' ExecuteNonQuery

    Public Overloads Shared Function ExecuteNonQuery(ByVal transaction As SqlTransaction, _
                                                     ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteNonQuery

#End Region

#Region "    ExecuteDataset"

    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(connection, commandType, commandText, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal connectionString As String, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet

        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim dataAdatpter As SqlDataAdapter = Nothing
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        Try
            ' Create the DataAdapter & DataSet
            dataAdatpter = New SqlDataAdapter(cmd)

            ' Fill the DataSet using default values for DataTable names, etc
            dataAdatpter.Fill(ds)

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()
        Finally
            If (Not dataAdatpter Is Nothing) Then dataAdatpter.Dispose()
        End Try
        If (mustCloseConnection) Then connection.Close()

        ' Return the dataset
        Return ds
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal connection As SqlConnection, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String) As DataSet
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteDataset(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim dataAdatpter As SqlDataAdapter = Nothing
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        Try
            ' Create the DataAdapter & DataSet
            dataAdatpter = New SqlDataAdapter(cmd)

            ' Fill the DataSet using default values for DataTable names, etc
            dataAdatpter.Fill(ds)

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()
        Finally
            If (Not dataAdatpter Is Nothing) Then dataAdatpter.Dispose()
        End Try

        ' Return the dataset
        Return ds

    End Function ' ExecuteDataset

    Public Overloads Shared Function ExecuteDataset(ByVal transaction As SqlTransaction, _
                                                    ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteDataset

#End Region

#Region "    ExecuteReader"
    Private Enum SqlConnectionOwnership
        ' Connection is owned and managed by SqlHelper
        Internal
        ' Connection is owned and managed by the caller
        [External]
    End Enum ' SqlConnectionOwnership

    Private Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                    ByVal transaction As SqlTransaction, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal commandParameters() As SqlParameter, _
                                                    ByVal connectionOwnership As SqlConnectionOwnership) As SqlDataReader

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        Dim mustCloseConnection As Boolean = False
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Try
            ' Create a reader
            Dim dataReader As SqlDataReader

            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

            ' Call ExecuteReader with the appropriate CommandBehavior
            If connectionOwnership = SqlConnectionOwnership.External Then
                dataReader = cmd.ExecuteReader()
            Else
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            End If

            ' Detach the SqlParameters from the command object, so they can be used again
            Dim canClear As Boolean = True
            Dim commandParameter As SqlParameter
            For Each commandParameter In cmd.Parameters
                If commandParameter.Direction <> ParameterDirection.Input Then
                    canClear = False
                End If
            Next

            If (canClear) Then cmd.Parameters.Clear()

            Return dataReader
        Catch
            If (mustCloseConnection) Then connection.Close()
            Throw
        End Try
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")

        ' Create & open a SqlConnection
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()
            ' Call the private overload that takes an internally owned connection in place of the connection string
            Return ExecuteReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.Internal)
        Catch
            ' If we fail to return the SqlDatReader, we need to close the connection ourselves
            If Not connection Is Nothing Then connection.Dispose()
            Throw
        End Try
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader

        Return ExecuteReader(connection, commandType, commandText, CType(Nothing, SqlParameter()))

    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        ' Pass through the call to private overload using a null transaction value
        Return ExecuteReader(connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, SqlConnectionOwnership.External)

    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()
        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As SqlDataReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        ' Pass through to private overload, indicating that the connection is owned by the caller
        Return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, SqlConnectionOwnership.External)
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal transaction As SqlTransaction, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            AssignParameterValues(commandParameters, parameterValues)

            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteReader

#End Region

#Region "    ExecuteScalar"

    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(connectionString, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        ' Create & open a SqlConnection, and dispose of it after we are done.
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)
            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(connection, commandType, commandText, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Object
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

        ' Execute the command & return the results
        retval = cmd.ExecuteScalar()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        If (mustCloseConnection) Then connection.Close()

        Return retval

    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If

    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteScalar(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Object
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Execute the command & return the results
        retval = cmd.ExecuteScalar()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval
    End Function ' ExecuteScalar

    Public Overloads Shared Function ExecuteScalar(ByVal transaction As SqlTransaction, _
                                                   ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()
        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else ' Otherwise we can just call the SP without params
            Return ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteScalar

#End Region

#Region "    ExecuteXmlReader"

    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String) As XmlReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteXmlReader(connection, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteXmlReader

    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String, _
                                                      ByVal ParamArray commandParameters() As SqlParameter) As XmlReader
        ' Pass through the call using a null transaction value
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim mustCloseConnection As Boolean = False
        Try
            Dim retval As XmlReader

            PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters, mustCloseConnection)

            ' Create the DataAdapter & DataSet
            retval = cmd.ExecuteXmlReader()

            ' Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear()

            Return retval
        Catch
            If (mustCloseConnection) Then connection.Close()
            Throw
        End Try

    End Function ' ExecuteXmlReader

    Public Overloads Shared Function ExecuteXmlReader(ByVal connection As SqlConnection, _
                                                      ByVal spName As String, _
                                                      ByVal ParamArray parameterValues() As Object) As XmlReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteXmlReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteXmlReader


    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String) As XmlReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteXmlReader(transaction, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteXmlReader

    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal commandType As CommandType, _
                                                      ByVal commandText As String, _
                                                      ByVal ParamArray commandParameters() As SqlParameter) As XmlReader
        ' Create a command and prepare it for execution
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")

        Dim cmd As New SqlCommand

        Dim retval As XmlReader
        Dim mustCloseConnection As Boolean = False

        PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Create the DataAdapter & DataSet
        retval = cmd.ExecuteXmlReader()

        ' Detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval

    End Function ' ExecuteXmlReader

    Public Overloads Shared Function ExecuteXmlReader(ByVal transaction As SqlTransaction, _
                                                      ByVal spName As String, _
                                                      ByVal ParamArray parameterValues() As Object) As XmlReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        Dim commandParameters As SqlParameter()

        ' If we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) AndAlso parameterValues.Length > 0 Then
            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
            ' Otherwise we can just call the SP without params
        Else
            Return ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function ' ExecuteXmlReader

#End Region

#Region "    FillDataset"
    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)

            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal commandType As CommandType, ByVal commandText As String, ByVal dataSet As DataSet, _
        ByVal tableNames() As String, ByVal ParamArray commandParameters() As SqlParameter)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)

            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    Public Overloads Shared Sub FillDataset(ByVal connectionString As String, ByVal spName As String, _
        ByVal dataSet As DataSet, ByVal tableNames As String(), ByVal ParamArray parameterValues() As Object)

        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create & open a SqlConnection, and dispose of it after we are done
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)

            connection.Open()

            ' Call the overload that takes a connection in place of the connection string
            FillDataset(connection, spName, dataSet, tableNames, parameterValues)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Sub

    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String())

        FillDataset(connection, commandType, commandText, dataSet, tableNames, Nothing)

    End Sub

    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal commandType As CommandType, _
    ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames As String(), _
        ByVal ParamArray commandParameters() As SqlParameter)

        FillDataset(connection, Nothing, commandType, commandText, dataSet, tableNames, commandParameters)

    End Sub

    Public Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataSet As DataSet, _
        ByVal tableNames() As String, ByVal ParamArray parameterValues() As Object)

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If we receive parameter values, we need to figure out where they go
        If Not parameterValues Is Nothing AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else ' Otherwise we can just call the SP without params
            FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If

    End Sub

    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String)

        FillDataset(transaction, commandType, commandText, dataSet, tableNames, Nothing)
    End Sub

    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String, _
        ByVal ParamArray commandParameters() As SqlParameter)

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters)

    End Sub

    Public Overloads Shared Sub FillDataset(ByVal transaction As SqlTransaction, ByVal spName As String, _
        ByVal dataSet As DataSet, ByVal tableNames() As String, ByVal ParamArray parameterValues() As Object)

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If we receive parameter values, we need to figure out where they go
        If Not parameterValues Is Nothing AndAlso parameterValues.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            ' Call the overload that takes an array of SqlParameters
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters)
        Else ' Otherwise we can just call the SP without params
            FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames)
        End If
    End Sub

    Private Overloads Shared Sub FillDataset(ByVal connection As SqlConnection, ByVal transaction As SqlTransaction, ByVal commandType As CommandType, _
        ByVal commandText As String, ByVal dataSet As DataSet, ByVal tableNames() As String, _
        ByVal ParamArray commandParameters() As SqlParameter)

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")

        ' Create a command and prepare it for execution
        Dim command As New SqlCommand

        Dim mustCloseConnection As Boolean = False
        PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, mustCloseConnection)

        ' Create the DataAdapter & DataSet
        Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)

        Try
            ' Add the table mappings specified by the user
            If Not tableNames Is Nothing AndAlso tableNames.Length > 0 Then

                Dim tableName As String = "Table"
                Dim index As Integer

                For index = 0 To tableNames.Length - 1
                    If (tableNames(index) Is Nothing OrElse tableNames(index).Length = 0) Then Throw New ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames")
                    dataAdapter.TableMappings.Add(tableName, tableNames(index))
                    tableName = "Table"
                    tableName = tableName & (index + 1).ToString()
                Next
            End If

            ' Fill the DataSet using default values for DataTable names, etc
            dataAdapter.Fill(dataSet)

            ' Detach the SqlParameters from the command object, so they can be used again
            command.Parameters.Clear()
        Finally
            If (Not dataAdapter Is Nothing) Then dataAdapter.Dispose()
        End Try

        If (mustCloseConnection) Then connection.Close()

    End Sub
#End Region

#Region "    UpdateDataset"
    Public Overloads Shared Sub UpdateDataset(ByVal insertCommand As SqlCommand, ByVal deleteCommand As SqlCommand, ByVal updateCommand As SqlCommand, ByVal dataSet As DataSet, ByVal tableName As String)

        If (insertCommand Is Nothing) Then Throw New ArgumentNullException("insertCommand")
        If (deleteCommand Is Nothing) Then Throw New ArgumentNullException("deleteCommand")
        If (updateCommand Is Nothing) Then Throw New ArgumentNullException("updateCommand")
        If (dataSet Is Nothing) Then Throw New ArgumentNullException("dataSet")
        If (tableName Is Nothing OrElse tableName.Length = 0) Then Throw New ArgumentNullException("tableName")

        ' Create a SqlDataAdapter, and dispose of it after we are done
        Dim dataAdapter As New SqlDataAdapter
        Try
            ' Set the data adapter commands
            dataAdapter.UpdateCommand = updateCommand
            dataAdapter.InsertCommand = insertCommand
            dataAdapter.DeleteCommand = deleteCommand

            ' Update the dataset changes in the data source
            dataAdapter.Update(dataSet, tableName)

            ' Commit all the changes made to the DataSet
            dataSet.AcceptChanges()
        Finally
            If (Not dataAdapter Is Nothing) Then dataAdapter.Dispose()
        End Try
    End Sub
#End Region

#Region "    CreateCommand"
    Public Overloads Shared Function CreateCommand(ByVal connection As SqlConnection, ByVal spName As String, ByVal ParamArray sourceColumns() As String) As SqlCommand

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        ' Create a SqlCommand
        Dim cmd As New SqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure

        ' If we receive parameter values, we need to figure out where they go
        If Not sourceColumns Is Nothing AndAlso sourceColumns.Length > 0 Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Assign the provided source columns to these parameters based on parameter order
            Dim index As Integer
            For index = 0 To sourceColumns.Length - 1
                commandParameters(index).SourceColumn = sourceColumns(index)
            Next

            ' Attach the discovered parameters to the SqlCommand object
            AttachParameters(cmd, commandParameters)
        End If

        CreateCommand = cmd
    End Function
#End Region

#Region "    ExecuteNonQueryTypedParams"
    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As Integer
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As Integer
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteNonQueryTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As Integer

        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteNonQueryTypedParams = SqlHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "    ExecuteDatasetTypedParams"
    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As DataSet
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As DataSet

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteDatasetTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As DataSet
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else

            ExecuteDatasetTypedParams = SqlHelper.ExecuteDataset(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "    ExecuteReaderTypedParams"
    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteReaderTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As SqlDataReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteReaderTypedParams = SqlHelper.ExecuteReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "    ExecuteScalarTypedParams"
    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal connectionString As String, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteScalarTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As Object
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteScalarTypedParams = SqlHelper.ExecuteScalar(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "    ExecuteXmlReaderTypedParams"
    Public Overloads Shared Function ExecuteXmlReaderTypedParams(ByVal connection As SqlConnection, ByVal spName As String, ByVal dataRow As DataRow) As XmlReader
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' If the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(connection, CommandType.StoredProcedure, spName)
        End If
    End Function

    Public Overloads Shared Function ExecuteXmlReaderTypedParams(ByVal transaction As SqlTransaction, ByVal spName As String, ByVal dataRow As DataRow) As XmlReader
        If (transaction Is Nothing) Then Throw New ArgumentNullException("transaction")
        If Not (transaction Is Nothing) AndAlso (transaction.Connection Is Nothing) Then Throw New ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        ' if the row has values, the store procedure parameters must be initialized
        If (Not dataRow Is Nothing AndAlso dataRow.ItemArray.Length > 0) Then

            ' Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            Dim commandParameters() As SqlParameter = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName)

            ' Set the parameters values
            AssignParameterValues(commandParameters, dataRow)

            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName, commandParameters)
        Else
            ExecuteXmlReaderTypedParams = SqlHelper.ExecuteXmlReader(transaction, CommandType.StoredProcedure, spName)
        End If
    End Function
#End Region

#Region "    DataFill"

    ' <summary>
    ' Fills a typed DataSet using the DataReader's current result. This method 
    ' allows paginated access to the database.
    ' </summary>
    ' <param name="dataReader">The DataReader used to fetch the values.</param>
    ' <param name="dataSet">The DataSet used to store the values.</param>
    ' <param name="tableName">The name of the DataSet table used to add the DataReader records.</param>
    ' <param name="from">The quantity of records skipped before placing values on the DataReader on the DataSet.</param>
    ' <param name="count">The maximum quantity of records alloed to fill on the DataSet.</param>
    Public Shared Sub Fill(ByVal dataReader As IDataReader, ByVal dataSet As DataSet, ByVal tableName As String, ByVal from As Integer, ByVal count As Integer)
        If tableName Is Nothing Then
            tableName = "unknownTable"
        End If
        If dataSet.Tables(tableName) Is Nothing Then
            dataSet.Tables.Add(tableName)
        End If
        ' Get the DataTable reference
        Dim fillTable As DataTable
        If tableName Is Nothing Then
            fillTable = dataSet.Tables(0)
        Else
            fillTable = dataSet.Tables(tableName)
        End If
        Dim fillRow As DataRow
        Dim fieldName As String
        Dim recNumber As Integer = 0
        Dim totalRecords As Integer = from + count
        While dataReader.Read()
            recNumber = recNumber + 1
            If recNumber >= from Then
                fillRow = fillTable.NewRow()
                Dim fieldIdx As Integer
                For fieldIdx = 0 To dataReader.FieldCount - 1
                    fieldName = dataReader.GetName(fieldIdx)
                    If fillTable.Columns.IndexOf(fieldName) = -1 Then
                        fillTable.Columns.Add(fieldName, dataReader.GetValue(fieldIdx).GetType())
                    End If
                    fillRow(fieldName) = dataReader.GetValue(fieldIdx)
                Next fieldIdx
                fillTable.Rows.Add(fillRow)
            End If
            If count <> 0 AndAlso totalRecords <= recNumber Then
                Exit While
            End If
        End While
        dataSet.AcceptChanges()
    End Sub 'Fill

#End Region

End Class ' SqlHelper

' SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
' ability to discover parameters for stored procedures at run-time.
Public NotInheritable Class SqlHelperParameterCache

#Region "    Private methods, variables, and constructors"

    Private Sub New()
    End Sub ' New 

    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    Private Shared Function DiscoverSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean, _
                                                       ByVal ParamArray parameterValues() As Object) As SqlParameter()

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim cmd As New SqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim discoveredParameters() As SqlParameter
        connection.Open()
        SqlCommandBuilder.DeriveParameters(cmd)
        connection.Close()
        If Not includeReturnValueParameter Then
            cmd.Parameters.RemoveAt(0)
        End If

        discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
        cmd.Parameters.CopyTo(discoveredParameters, 0)

        ' Init the parameters with a DBNull value
        Dim discoveredParameter As SqlParameter
        For Each discoveredParameter In discoveredParameters
            discoveredParameter.Value = DBNull.Value
        Next

        Return discoveredParameters

    End Function ' DiscoverSpParameterSet

    ' Deep copy of cached SqlParameter array
    Private Shared Function CloneParameters(ByVal originalParameters() As SqlParameter) As SqlParameter()

        Dim i As Integer
        Dim j As Integer = originalParameters.Length - 1
        Dim clonedParameters(j) As SqlParameter

        For i = 0 To j
            clonedParameters(i) = CType(CType(originalParameters(i), ICloneable).Clone, SqlParameter)
        Next

        Return clonedParameters
    End Function ' CloneParameters

#End Region

#Region "    Caching functions"

    Public Shared Sub CacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String, _
                                        ByVal ParamArray commandParameters() As SqlParameter)
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        Dim hashKey As String = connectionString + ":" + commandText

        paramCache(hashKey) = commandParameters
    End Sub ' CacheParameterSet

    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As SqlParameter()
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        If (commandText Is Nothing OrElse commandText.Length = 0) Then Throw New ArgumentNullException("commandText")

        Dim hashKey As String = connectionString + ":" + commandText
        Dim cachedParameters As SqlParameter() = CType(paramCache(hashKey), SqlParameter())

        If cachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(cachedParameters)
        End If
    End Function ' GetCachedParameterSet

#End Region

#Region "    Parameter Discovery Functions"
    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As SqlParameter()
        Return GetSpParameterSet(connectionString, spName, False)
    End Function ' GetSpParameterSet 

    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()
        If (connectionString Is Nothing OrElse connectionString.Length = 0) Then Throw New ArgumentNullException("connectionString")
        Dim connection As SqlConnection = Nothing
        Try
            connection = New SqlConnection(connectionString)
            GetSpParameterSet = GetSpParameterSetInternal(connection, spName, includeReturnValueParameter)
        Finally
            If Not connection Is Nothing Then connection.Dispose()
        End Try
    End Function ' GetSpParameterSet

    Public Overloads Shared Function GetSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String) As SqlParameter()

        GetSpParameterSet = GetSpParameterSet(connection, spName, False)
    End Function ' GetSpParameterSet

    Public Overloads Shared Function GetSpParameterSet(ByVal connection As SqlConnection, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()
        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        Dim clonedConnection As SqlConnection = Nothing
        Try
            clonedConnection = CType((CType(connection, ICloneable).Clone), SqlConnection)
            GetSpParameterSet = GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter)
        Finally
            If Not clonedConnection Is Nothing Then clonedConnection.Dispose()
        End Try
    End Function ' GetSpParameterSet

    Private Overloads Shared Function GetSpParameterSetInternal(ByVal connection As SqlConnection, _
                                                    ByVal spName As String, _
                                                    ByVal includeReturnValueParameter As Boolean) As SqlParameter()

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")

        Dim cachedParameters() As SqlParameter
        Dim hashKey As String

        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")

        hashKey = connection.ConnectionString + ":" + spName + IIf(includeReturnValueParameter = True, ":include ReturnValue Parameter", "").ToString

        cachedParameters = CType(paramCache(hashKey), SqlParameter())

        If (cachedParameters Is Nothing) Then
            Dim spParameters() As SqlParameter = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter)
            paramCache(hashKey) = spParameters
            cachedParameters = spParameters

        End If

        Return CloneParameters(cachedParameters)

    End Function ' GetSpParameterSet
#End Region

End Class ' SqlHelperParameterCache 


