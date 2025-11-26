Imports System.Data.OleDb
Imports System.String
Imports System.Data.Sql

Public Class DBConnection

    Private objData As WDABase
    Private Provider As String = "SQL Server"

    'To use, in main program code

    '1) Private strProvider As String = "SQL Server"
    '   Private txtServer As String = ""
    '   Private txtDatabase As String = ""
    '   Private txtLoginName As String = "sa"
    '   Private txtPassword As String = "Fred"

    Private Sub DBConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        'Public LocalDB As Boolean = True                'use local MSAccess DB
        'Public WinAuthent As Boolean = True              'Windows or SQL authentication

        'Public LocalDB As Boolean = True                'use local MSAccess DB
        'Public WinAuthent As Boolean = True              'Windows or SQL authentication

        'show available databases in db combo box
        'Dim x As ArrayList = New ArrayList
        'x = ExecuteQuery1("select * from sysdatabases", "master", False, True)
        'bind combo box to found datatables
        'cboDataBase.DataSource = x


        txtSQLServer.Text = Server
        If WinAuthent Then
            'Win Authent
            cboAuthentication.SelectedIndex = 1
        Else
            'SQL authent
            cboAuthentication.SelectedIndex = 0
        End If


    End Sub
   
    Private Sub btnCloseDBSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseDBSetup.Click

        'save infomation
        Provider = SQLProvider      'SQL Server"
        ''Server = cboServer.Text     'Home-Server
        Server = txtSQLServer.Text  'current SQL server
        'SQLServer = Server          'Current SQL server
        DataBase = cboDataBase.Text 'EED-P
        ' TestQuery.cboDatabase.Text = DataBase

        Login = txtLogin.Text       'sa
        Password = txtPassword.Text 'carl

        'ChangeReportSource(Server) 'change the crystal report source to the current SQL server

        Me.Close()
    End Sub

    Private Sub cboAuthentication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAuthentication.SelectedIndexChanged
        'Selectedindex = 0 .. SQL Authentcation
        'Selectedindex = 1 .. Windows Authentcation

        If cboAuthentication.SelectedIndex = 1 Then
            'Windows Authentication
            lblLoginName.Visible = False
            txtLogin.Visible = False
            txtLogin.Text = ""
            lblPassword.Visible = False
            txtPassword.Visible = False
            WinAuthent = True

        Else 'SelectedIndex = 0
            lblLoginName.Visible = True
            txtLogin.Visible = True
            txtLogin.Text = "sa"
            lblPassword.Visible = True
            txtPassword.Visible = True
            txtPassword.Text = "carl"
            WinAuthent = False

        End If

        Login = txtLogin.Text
        Password = txtPassword.Text
        'ServerSetup.txtLogin.Text = Login 'update parent form info.
        'ShowLogin()

    End Sub

    Private Sub btnOpenConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenConnection.Click
        'if Login = "" then Windows Authentication is being used
        'else SQL authentication: 
        'Login = sa 
        'password = carl

        Server = txtSQLServer.Text
        DataBase = cboDataBase.Text
        Login = txtLogin.Text
        Dim Password As String = txtPassword.Text

        'Initialize a new instance of the data access base class
        objData = New WDABase(Provider, Server, DataBase, Login, Password)

        Try
            'Open the database connection
            objData.OpenConnection()
            'Set the status message
            lblStatus.Text = "Database Opened .."
            lblStatus.ForeColor = Color.Green
            SQL_Available = True 'SQL server is available
        Catch ExceptionErr As Exception
            'Display the error
            MessageBox.Show(ExceptionErr.Message)
        End Try

    End Sub

    Private Sub btnCloseConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseConnection.Click

        'Close the database connection
        objData.CloseConnection()
        'Set the status message
        lblStatus.Text = "Database closed"
        lblStatus.ForeColor = Color.Red
        'Form.DBConnection.txtConnectionString.Hide()
        'Cleanup
        objData.Dispose()
        objData = Nothing
    End Sub

    Private Sub cboDataBase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDataBase.SelectedIndexChanged

    End Sub

   
End Class