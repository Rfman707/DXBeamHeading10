<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBConnection
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBConnection))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSQLServer = New System.Windows.Forms.TextBox
        Me.cboDataBase = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboAuthentication = New System.Windows.Forms.ComboBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblLoginName = New System.Windows.Forms.Label
        Me.lblDatabase = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtLogin = New System.Windows.Forms.TextBox
        Me.lblServer = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.btnCloseConnection = New System.Windows.Forms.Button
        Me.btnOpenConnection = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnCloseDBSetup = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSQLServer)
        Me.GroupBox1.Controls.Add(Me.cboDataBase)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboAuthentication)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblLoginName)
        Me.GroupBox1.Controls.Add(Me.lblDatabase)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.lblServer)
        Me.GroupBox1.Location = New System.Drawing.Point(81, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 197)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SQL Server"
        '
        'txtSQLServer
        '
        Me.txtSQLServer.Location = New System.Drawing.Point(90, 31)
        Me.txtSQLServer.Name = "txtSQLServer"
        Me.txtSQLServer.Size = New System.Drawing.Size(284, 20)
        Me.txtSQLServer.TabIndex = 30
        '
        'cboDataBase
        '
        Me.cboDataBase.AllowDrop = True
        Me.cboDataBase.FormattingEnabled = True
        Me.cboDataBase.Items.AddRange(New Object() {"Hoey2", "Northwind", "HousePlans", "EED-P"})
        Me.cboDataBase.Location = New System.Drawing.Point(90, 62)
        Me.cboDataBase.MaxLength = 20
        Me.cboDataBase.Name = "cboDataBase"
        Me.cboDataBase.Size = New System.Drawing.Size(284, 21)
        Me.cboDataBase.TabIndex = 29
        Me.cboDataBase.Text = "DXCC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Authentication"
        '
        'cboAuthentication
        '
        Me.cboAuthentication.FormattingEnabled = True
        Me.cboAuthentication.Items.AddRange(New Object() {"SQL Server", "Windows"})
        Me.cboAuthentication.Location = New System.Drawing.Point(90, 95)
        Me.cboAuthentication.Name = "cboAuthentication"
        Me.cboAuthentication.Size = New System.Drawing.Size(147, 21)
        Me.cboAuthentication.TabIndex = 26
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(9, 157)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 22
        Me.lblPassword.Text = "Password"
        '
        'lblLoginName
        '
        Me.lblLoginName.AutoSize = True
        Me.lblLoginName.Location = New System.Drawing.Point(9, 130)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(64, 13)
        Me.lblLoginName.TabIndex = 21
        Me.lblLoginName.Text = "Login Name"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(9, 65)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblDatabase.TabIndex = 20
        Me.lblDatabase.Text = "Database"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(90, 154)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(147, 20)
        Me.txtPassword.TabIndex = 19
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(90, 127)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(147, 20)
        Me.txtLogin.TabIndex = 18
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(9, 34)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 15
        Me.lblServer.Text = "Server"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(245, 37)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(98, 13)
        Me.lblStatus.TabIndex = 25
        Me.lblStatus.Text = "Database is not set"
        '
        'btnCloseConnection
        '
        Me.btnCloseConnection.Location = New System.Drawing.Point(134, 32)
        Me.btnCloseConnection.Name = "btnCloseConnection"
        Me.btnCloseConnection.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseConnection.TabIndex = 24
        Me.btnCloseConnection.Text = "Close"
        '
        'btnOpenConnection
        '
        Me.btnOpenConnection.Location = New System.Drawing.Point(12, 32)
        Me.btnOpenConnection.Name = "btnOpenConnection"
        Me.btnOpenConnection.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenConnection.TabIndex = 23
        Me.btnOpenConnection.Text = "Open"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOpenConnection)
        Me.GroupBox2.Controls.Add(Me.btnCloseConnection)
        Me.GroupBox2.Controls.Add(Me.lblStatus)
        Me.GroupBox2.Location = New System.Drawing.Point(81, 303)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 81)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Test Connection"
        '
        'btnCloseDBSetup
        '
        Me.btnCloseDBSetup.Location = New System.Drawing.Point(457, 537)
        Me.btnCloseDBSetup.Name = "btnCloseDBSetup"
        Me.btnCloseDBSetup.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseDBSetup.TabIndex = 26
        Me.btnCloseDBSetup.Text = "Close"
        '
        'DBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 581)
        Me.Controls.Add(Me.btnCloseDBSetup)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DBConnection"
        Me.Text = "SQL Server Database details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnCloseConnection As System.Windows.Forms.Button
    Friend WithEvents btnOpenConnection As System.Windows.Forms.Button
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblLoginName As System.Windows.Forms.Label
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAuthentication As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloseDBSetup As System.Windows.Forms.Button
    Friend WithEvents txtSQLServer As System.Windows.Forms.TextBox
End Class
