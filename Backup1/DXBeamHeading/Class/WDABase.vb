Imports System.Data
Imports System.Data.OleDb

Public Class WDABase

    Implements IDisposable

    'Class level variables that are available to classes that instantiate WDABase
    'This class needs to be included in projects using this class!
    'Additional vairables must be declared in the main project including...
    '
    'Provider, Server, DatabaseHoey, Login, Password, USPselection, 
    'Manufacturer, DataSource, MSAccessProvider, DataSource
    '
    Public SQL As String
    Public DefaultMaxNameSize As Integer = 1 ' was 1

    Public Provider As String 'new

    Public Connection As OleDbConnection
    Public Command As OleDbCommand
    Public DataAdapter As OleDbDataAdapter
    Public DataReader As OleDbDataReader

    Private disposed As Boolean = False

    Public Sub New()
        'Constructor .. reads app.config file
        'Build the SQL connection string and initialize the Connection object

        'origional code
        '"Provider=" & My.Settings.Provider & ";" & _
        '"Data Source=" & My.Settings.DataSource & ";")

        'Provider and DataSource now found in ModGlobals.vb module (mod chm)
        'Current values found in modGlobals.vb
        'Public Provider As String = "Microsoft.Jet.OLEDB.4.0"
        'Public DataSource As String = Directory() & "\EED-P.mdb"
        Connection = New OleDbConnection( _
        "Provider=" & Provider & ";" & _
        "Data Source=" & DataSource & ";")

    End Sub

    ' IDisposable
    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                ' TODO: put code to dispose managed resources
                If Not DataReader Is Nothing Then
                    DataReader.Close()
                    DataReader = Nothing
                End If
                If Not DataAdapter Is Nothing Then
                    DataAdapter.Dispose()
                    DataAdapter = Nothing
                End If
                If Not Command Is Nothing Then
                    Command.Dispose()
                    Command = Nothing
                End If
                If Not Connection Is Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End If

            ' TODO: put code to free unmanaged resources here
        End If
        Me.disposed = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region

    Public Sub OpenConnection()
        Try
            Connection.Open()
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        Catch InvalidOperationExceptionErr As InvalidOperationException
            Throw New System.Exception(InvalidOperationExceptionErr.Message, _
                InvalidOperationExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub New(ByVal Provider As String, ByVal Server As String, _
       ByVal Database As String, ByVal Login As String, ByVal Password As String)

        'Build the SQL connection string and initialize the Connection object
        'use server as 192.168.0.101, userid = sa, password = carl
        'i.e. SQL authentication , not windows as cant resolve DSN.

        '*************************************************
        'To use, in main program code

        '1) Private strProvider As String = "SQL Server"
        '   Private txtServer As String = "131.185.33.101"
        '   Private txtDatabase As String = "ProjectTimeTracker"
        '   Private txtLoginName As String = "sa"
        '   Private txtPassword As String = "carl"

        '*************************************************
        '2) ' Private Sub btnOpenConnection_Click(ByVal sender As Object, _
        'ByVal e As System.EventArgs) Handles btnOpenConnection.Click


        ''Initialize a new instance of the data access base class
        ''SQL or Oracle
        'objData = New WDABase(strProvider, txtServer.Text, _
        '    txtDatabase.Text, txtLoginName.Text, txtPassword.Text)

        'Try
        '    'Open the database connection
        '    objData.OpenConnection()
        '    'Set the status message
        '    lblStatus.Text = "Database opened"
        'Catch ExceptionErr As Exception
        '    'Display the error
        '    MessageBox.Show("Connection Failure", ExceptionErr.Message)
        'End Try

        'End Sub
        '*************************************************
        ''3)  Private Sub btnCloseConnection_Click(ByVal sender As Object, _
        'ByVal e As System.EventArgs) Handles btnCloseConnection.Click

        ''Close the database connection
        'objData.CloseConnection()
        ''Set the status message
        'lblStatus.Text = "Database closed"
        ''Cleanup
        'objData.Dispose()
        'objData = Nothing

        'End Sub
        '*************************************************

        If Provider = "SQL Server" Then
            'SQL Server Connection used.
            If Login = "" Then
                'Windows Authentication 
                'tried adding! - works!
                Connection = New OleDbConnection( _
                "Provider=SQLOLEDB;" & _
                "Data Source=" & Server & ";" & _
                "Database=" & Database & ";" & _
                "Integrated Security=SSPI;")
            Else
                'SQL Authentication .. this works and is preferred for now!
                Connection = New OleDbConnection( _
                    "Provider=SQLOLEDB;" & _
                    "Data Source=" & Server & ";" & _
                    "Database=" & Database & ";" & _
                    "User ID=" & Login & ";" & _
                    "Password=" & Password & ";")
            End If
        End If

        If Provider = "Oracle Server" Then
            'Oracle Server Connection used.
            Connection = New OleDbConnection( _
                "Provider=MSDAORA;" & _
                "Data Source=" & Server & ";" & _
                "User ID=" & Login & ";" & _
                "Password=" & Password & ";")
        End If

        If Provider = MSAccessProvider Then '"Microsoft.Jet.OLEDB.4.0"
            Connection = New OleDbConnection( _
                  "Provider=" & Provider & ";" & _
                  "Data Source=" & DataSource & ";")
        End If

    End Sub

    Public Sub CloseConnection()
        Connection.Close()
    End Sub

    Public Sub InitializeCommand()
        'set command type, 1) sql string, 2) query or 3) stored procedure
        'stored procedures most common.
        If Command Is Nothing Then
            Try
                Command = New OleDbCommand(SQL, Connection)
                'See if this is a stored procedure
                If Not SQL.ToUpper.StartsWith("SELECT ") _
                    And Not SQL.ToUpper.StartsWith("INSERT ") _
                    And Not SQL.ToUpper.StartsWith("UPDATE ") _
                    And Not SQL.ToUpper.StartsWith("DELETE ") Then
                    Command.CommandType = CommandType.StoredProcedure
                End If
            Catch OleDbExceptionErr As OleDbException
                Throw New System.Exception(OleDbExceptionErr.Message, _
                    OleDbExceptionErr.InnerException)
            End Try
        End If
    End Sub

    Public Sub AddParameter(ByVal Name As String, ByVal Type As OleDbType, _
        ByVal Size As Integer, ByVal Value As Object)
        'Command Object support, add parameters to parameters collection
        'This is the most general method used
        'Command.Parameters.Add("@Site", Type, Size).Value = Value
        'type data.oledb.oledbtype.char

        Try
            Command.Parameters.Add(Name, Type, Size).Value = Value
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddWithParameter(ByVal Name As String, ByVal Value As Object)
        'Command Object support, add parameters to parameters collection
        'Data Type and Size not required, can cause problems when text strings
        'are used if they are bigger than the table
        'The AddTextParameter addresses this issue by setting a maximum size

        Try
            'Command.Parameters.Add(Name, Type, Size).Value = Value
            Command.Parameters.AddWithValue(Name, Value)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub AddTextParameter(ByVal ArgName As String, ByVal Name As String, _
        ByVal MaxNameSize As Integer)
        'ArgName is a dummy argument eg. "@base", the order of parameters Must
        'be the same as needed by the actual query parameters
        'checks if size of Name (txtBox) is greater than the Max Permissable size 
        'see size of text field in the table definition, if size is too big, Name is
        'reduced in size (left trim), stops runtime errors!
        'added by CHM
        Dim TrimName As String
        TrimName = TrimLen(Name, MaxNameSize)

        Try
            Command.Parameters.AddWithValue(ArgName, TrimName)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub

    Public Sub AddTextParameter(ByVal ArgName As String, ByVal Name As String)
        'checks if size of Name is greater than the Max Permissable size 
        'DefaultMaxNameSize is set
        'see size of text field in the table definition, if size is too big, Name is
        'reduced in size (left trim), stops runtime errors!
        Dim TrimName As String
        TrimName = TrimLen(Name, DefaultMaxNameSize)

        Try
            Command.Parameters.AddWithValue(ArgName, TrimName)
            'Command.Parameters.AddWithValue(ArgName, TrimLen(Name, DefaultMaxNameSize))
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddTextParameter(ByVal Name As String)
        'checks if size of Name is greater than the Max Permissable size 
        'see size of text field in the table definition, if size is too big, Name is
        'reduced in size (left trim), stops runtime errors!
        'Uses a default max name size and adds a dummy argname
        'ArgName is a dummy argument eg. "@base", 

        Dim TrimName As String
        TrimName = TrimLen(Name, DefaultMaxNameSize)
        Try
            Command.Parameters.AddWithValue("@Arg", TrimName)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddGuidParameter(ByVal TextGUID As String)
        '
        'objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))
        Try
            Command.Parameters.AddWithValue("@Arg", New Guid(TextGUID))
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddGuidParameter(ByVal GuidID As Guid)
        '
        'objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))
        Try
            Command.Parameters.AddWithValue("@Arg", GuidID)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddGuidParameter(ByVal Para As String, ByVal TextGUID As String)
        '
        'objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))
        Try
            Command.Parameters.AddWithValue(Para, New Guid(TextGUID))
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddGuidParameter(ByVal Para As String, ByVal GUIDID As Guid)
        '
        'objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))
        Try
            Command.Parameters.AddWithValue(Para, GUIDID)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try

    End Sub
    Public Sub AddGuidNewParameter()
        Try
            Command.Parameters.AddWithValue("@Arg", Guid.NewGuid())
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
        ' objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))

    End Sub
    Public Sub AddGuidNewParameter(ByVal Para As String)
        Try
            Command.Parameters.AddWithValue(Para, Guid.NewGuid())
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
        ' objData.AddParameter("@TxID", OleDbType.Guid, 16, New Guid(txtTxID.Text))

    End Sub
    Public Sub AddBooleanParameter(ByVal state As Boolean)
        '
        'objData.AddParameter("@NSStatus", OleDbType.Boolean, 1, NSUnSafeStatusG)
        Try
            Command.Parameters.AddWithValue("@Arg", state)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddBooleanParameter(ByVal Name As String, ByVal state As Boolean)
        '
        'objData.AddParameter("@NSStatus", OleDbType.Boolean, 1, NSUnSafeStatusG)
        Try
            Command.Parameters.AddWithValue("@Arg", state)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub AddDateParameter(ByVal ArgName As String, ByVal _Date As String)

        Dim x As DateTime

        Try
            x = _Date
        Catch
            x = Now.ToString
        End Try

        Try
            Command.Parameters.AddWithValue(ArgName, x) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddDateParameter(ByVal _Date As String)

        Dim x As DateTime

        Try
            x = _Date
        Catch
            x = Now.ToString
        End Try

        Try
            Command.Parameters.AddWithValue("@Arg", x) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddFloatParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Double
        If Double.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddFloatParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned
        'SQL Float and VB Double are the same

        Dim Value As Double
        If Double.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddDoubleParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Double
        If Double.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddDoubleParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Double
        If Double.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddMoneyParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Decimal
        If Decimal.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddMoneyParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Decimal
        If Decimal.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddDecimalParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Decimal
        If Decimal.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddDecimalParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Decimal
        If Decimal.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddRealParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Single
        If Single.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddRealParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Single
        If Single.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddUseNewGuid(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Single
        If Single.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddUseNewGuid(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Single
        If Single.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddIntParameter(ByVal ArgName As String, ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'Enables use of a dummy argname

        Dim Value As Integer
        If Integer.TryParse(Name, Value) Then
        Else
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue(ArgName, Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub AddIntParameter(ByVal Name As String)
        'Checks the textbox name can be converted to a double, if not set to zero
        'dummy argname is assigned

        Dim Value As Integer
        If Integer.TryParse(Name, Value) Then
            'Value has a real value
        Else
            'no value returned, so default to zero
            Value = 0
        End If

        Try
            Command.Parameters.AddWithValue("@Arg", Value) 'Type and Size not required.
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub
    Public Sub InitializeDataAdapter()
        'Initialises the DataAdapter - sets select command type
        Try
            DataAdapter = New OleDbDataAdapter
            DataAdapter.SelectCommand = Command
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
            OleDbExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub FillDataSet(ByRef oDataSet As DataSet, ByVal TableName As String)
        'fill Dataset
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataSet, TableName)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Sub FillDataTable(ByRef oDataTable As DataTable)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataTable)
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Function ExecuteStoredProcedure() As Integer
        Try
            OpenConnection()
            ExecuteStoredProcedure = Command.ExecuteNonQuery()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function

    Private Function TrimLen(ByVal TextString As String, ByVal MaxSize As Integer) As String
        'returns a string no longer than the max length set
        'If MazSize = 0 or negative, return the origional string, used for NText

        If MaxSize <= 0 Then
            Return TextString
        Else
            'Text.Substring(0, TestLen(Text, TxtSize))
            Dim Actlen As Integer = TextString.Length
            If (Actlen < MaxSize) Then
                'return the origional string
                Return TextString.Substring(0, Actlen)
            Else
                Return TextString.Substring(0, MaxSize)
            End If
        End If
    End Function

End Class
