<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainStart
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
        Me.components = New System.ComponentModel.Container
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtConnectionString = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtFindme = New System.Windows.Forms.TextBox
        Me.lblPrefix = New System.Windows.Forms.Label
        Me.lblShortPath = New System.Windows.Forms.Label
        Me.lblKM = New System.Windows.Forms.Label
        Me.lblLong = New System.Windows.Forms.Label
        Me.lblQthLoc = New System.Windows.Forms.Label
        Me.lblCountry = New System.Windows.Forms.Label
        Me.lblLongPath = New System.Windows.Forms.Label
        Me.lblLat = New System.Windows.Forms.Label
        Me.lblContinent = New System.Windows.Forms.Label
        Me.txtPrefix = New System.Windows.Forms.TextBox
        Me.txtShortPath = New System.Windows.Forms.TextBox
        Me.txtKm = New System.Windows.Forms.TextBox
        Me.txtLongnitude = New System.Windows.Forms.TextBox
        Me.txtQTH_Locator = New System.Windows.Forms.TextBox
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtLongPath = New System.Windows.Forms.TextBox
        Me.txtLatitude = New System.Windows.Forms.TextBox
        Me.txtContinent = New System.Windows.Forms.TextBox
        Me.btnLoadDXCC = New System.Windows.Forms.Button
        Me.txtRecords = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblConnectionStatus = New System.Windows.Forms.Label
        Me.lvwCustomers = New System.Windows.Forms.ListView
        Me.ColumnHeader0 = New System.Windows.Forms.ColumnHeader
        Me.Column1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkTestMode = New System.Windows.Forms.CheckBox
        Me.chkPrefixAll = New System.Windows.Forms.CheckBox
        Me.chkPrefix = New System.Windows.Forms.CheckBox
        Me.chkBegin = New System.Windows.Forms.CheckBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.txtDXccID = New System.Windows.Forms.TextBox
        Me.txtUsp_String = New System.Windows.Forms.TextBox
        Me.lblUspStr = New System.Windows.Forms.Label
        Me.txtGuidID = New System.Windows.Forms.TextBox
        Me.btnGetMaxID = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMaxID = New System.Windows.Forms.TextBox
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblSendHeading = New System.Windows.Forms.Label
        Me.lblPort = New System.Windows.Forms.Label
        Me.txtLocalServer = New System.Windows.Forms.TextBox
        Me.lblLocalServer = New System.Windows.Forms.Label
        Me.txtComputerName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnResendHeading = New System.Windows.Forms.Button
        Me.btnNewRecords = New System.Windows.Forms.Button
        Me.chkLongPath = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.chkDebug = New System.Windows.Forms.CheckBox
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.btnTestPort = New System.Windows.Forms.Button
        Me.lblPortUsing = New System.Windows.Forms.Label
        Me.lblSendHeadingLong = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(40, 43)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtConnectionString
        '
        Me.txtConnectionString.Location = New System.Drawing.Point(134, 46)
        Me.txtConnectionString.Name = "txtConnectionString"
        Me.txtConnectionString.Size = New System.Drawing.Size(717, 20)
        Me.txtConnectionString.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(822, 842)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "&Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(40, 139)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtFindme
        '
        Me.txtFindme.Location = New System.Drawing.Point(282, 142)
        Me.txtFindme.Name = "txtFindme"
        Me.txtFindme.Size = New System.Drawing.Size(54, 20)
        Me.txtFindme.TabIndex = 7
        Me.txtFindme.Text = "ZL"
        '
        'lblPrefix
        '
        Me.lblPrefix.AutoSize = True
        Me.lblPrefix.Location = New System.Drawing.Point(28, 588)
        Me.lblPrefix.Name = "lblPrefix"
        Me.lblPrefix.Size = New System.Drawing.Size(33, 13)
        Me.lblPrefix.TabIndex = 11
        Me.lblPrefix.Text = "Prefix"
        '
        'lblShortPath
        '
        Me.lblShortPath.AutoSize = True
        Me.lblShortPath.Location = New System.Drawing.Point(28, 634)
        Me.lblShortPath.Name = "lblShortPath"
        Me.lblShortPath.Size = New System.Drawing.Size(54, 13)
        Me.lblShortPath.TabIndex = 12
        Me.lblShortPath.Text = "ShortPath"
        '
        'lblKM
        '
        Me.lblKM.AutoSize = True
        Me.lblKM.Location = New System.Drawing.Point(28, 780)
        Me.lblKM.Name = "lblKM"
        Me.lblKM.Size = New System.Drawing.Size(55, 13)
        Me.lblKM.TabIndex = 13
        Me.lblKM.Text = "Kilometers"
        '
        'lblLong
        '
        Me.lblLong.AutoSize = True
        Me.lblLong.Location = New System.Drawing.Point(403, 685)
        Me.lblLong.Name = "lblLong"
        Me.lblLong.Size = New System.Drawing.Size(60, 13)
        Me.lblLong.TabIndex = 14
        Me.lblLong.Text = "Longnitude"
        '
        'lblQthLoc
        '
        Me.lblQthLoc.AutoSize = True
        Me.lblQthLoc.Location = New System.Drawing.Point(404, 728)
        Me.lblQthLoc.Name = "lblQthLoc"
        Me.lblQthLoc.Size = New System.Drawing.Size(69, 13)
        Me.lblQthLoc.TabIndex = 15
        Me.lblQthLoc.Text = "QTH Locator"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(403, 588)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 16
        Me.lblCountry.Text = "Country"
        '
        'lblLongPath
        '
        Me.lblLongPath.AutoSize = True
        Me.lblLongPath.Location = New System.Drawing.Point(403, 634)
        Me.lblLongPath.Name = "lblLongPath"
        Me.lblLongPath.Size = New System.Drawing.Size(53, 13)
        Me.lblLongPath.TabIndex = 17
        Me.lblLongPath.Text = "LongPath"
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(28, 685)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(45, 13)
        Me.lblLat.TabIndex = 18
        Me.lblLat.Text = "Latitude"
        '
        'lblContinent
        '
        Me.lblContinent.AutoSize = True
        Me.lblContinent.Location = New System.Drawing.Point(28, 732)
        Me.lblContinent.Name = "lblContinent"
        Me.lblContinent.Size = New System.Drawing.Size(52, 13)
        Me.lblContinent.TabIndex = 19
        Me.lblContinent.Text = "Continent"
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(98, 581)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(242, 20)
        Me.txtPrefix.TabIndex = 20
        '
        'txtShortPath
        '
        Me.txtShortPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtShortPath.Location = New System.Drawing.Point(99, 627)
        Me.txtShortPath.Name = "txtShortPath"
        Me.txtShortPath.Size = New System.Drawing.Size(77, 20)
        Me.txtShortPath.TabIndex = 21
        '
        'txtKm
        '
        Me.txtKm.Location = New System.Drawing.Point(99, 773)
        Me.txtKm.Name = "txtKm"
        Me.txtKm.Size = New System.Drawing.Size(77, 20)
        Me.txtKm.TabIndex = 22
        '
        'txtLongnitude
        '
        Me.txtLongnitude.Location = New System.Drawing.Point(479, 678)
        Me.txtLongnitude.Name = "txtLongnitude"
        Me.txtLongnitude.Size = New System.Drawing.Size(106, 20)
        Me.txtLongnitude.TabIndex = 23
        '
        'txtQTH_Locator
        '
        Me.txtQTH_Locator.Location = New System.Drawing.Point(479, 725)
        Me.txtQTH_Locator.Name = "txtQTH_Locator"
        Me.txtQTH_Locator.Size = New System.Drawing.Size(241, 20)
        Me.txtQTH_Locator.TabIndex = 24
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(479, 581)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(298, 20)
        Me.txtCountry.TabIndex = 25
        '
        'txtLongPath
        '
        Me.txtLongPath.Location = New System.Drawing.Point(479, 627)
        Me.txtLongPath.Name = "txtLongPath"
        Me.txtLongPath.Size = New System.Drawing.Size(77, 20)
        Me.txtLongPath.TabIndex = 26
        '
        'txtLatitude
        '
        Me.txtLatitude.Location = New System.Drawing.Point(98, 678)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(78, 20)
        Me.txtLatitude.TabIndex = 27
        '
        'txtContinent
        '
        Me.txtContinent.Location = New System.Drawing.Point(99, 725)
        Me.txtContinent.Name = "txtContinent"
        Me.txtContinent.Size = New System.Drawing.Size(241, 20)
        Me.txtContinent.TabIndex = 28
        '
        'btnLoadDXCC
        '
        Me.btnLoadDXCC.Location = New System.Drawing.Point(40, 93)
        Me.btnLoadDXCC.Name = "btnLoadDXCC"
        Me.btnLoadDXCC.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadDXCC.TabIndex = 29
        Me.btnLoadDXCC.Text = "&Show All"
        Me.btnLoadDXCC.UseVisualStyleBackColor = True
        '
        'txtRecords
        '
        Me.txtRecords.Location = New System.Drawing.Point(824, 534)
        Me.txtRecords.Name = "txtRecords"
        Me.txtRecords.Size = New System.Drawing.Size(73, 20)
        Me.txtRecords.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(692, 537)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Record"
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.AutoSize = True
        Me.lblConnectionStatus.Location = New System.Drawing.Point(792, 98)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(79, 13)
        Me.lblConnectionStatus.TabIndex = 33
        Me.lblConnectionStatus.Text = "Not Connected"
        '
        'lvwCustomers
        '
        Me.lvwCustomers.BackColor = System.Drawing.Color.White
        Me.lvwCustomers.BackgroundImageTiled = True
        Me.lvwCustomers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.Column1, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvwCustomers.FullRowSelect = True
        Me.lvwCustomers.GridLines = True
        Me.lvwCustomers.HideSelection = False
        Me.lvwCustomers.Location = New System.Drawing.Point(40, 185)
        Me.lvwCustomers.MultiSelect = False
        Me.lvwCustomers.Name = "lvwCustomers"
        Me.lvwCustomers.Size = New System.Drawing.Size(857, 320)
        Me.lvwCustomers.TabIndex = 0
        Me.lvwCustomers.UseCompatibleStateImageBehavior = False
        Me.lvwCustomers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Prefix"
        Me.ColumnHeader0.Width = 150
        '
        'Column1
        '
        Me.Column1.Text = "Country"
        Me.Column1.Width = 170
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "ShortP"
        Me.ColumnHeader12.Width = 45
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "LongP"
        Me.ColumnHeader13.Width = 43
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "km"
        Me.ColumnHeader14.Width = 47
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Lat."
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Long."
        Me.ColumnHeader16.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Continent"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "QTH_Loc"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ID"
        Me.ColumnHeader3.Width = 30
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "GuidID"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Hide"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(182, 634)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Deg."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(562, 634)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Deg."
        '
        'chkTestMode
        '
        Me.chkTestMode.AutoSize = True
        Me.chkTestMode.Location = New System.Drawing.Point(810, 12)
        Me.chkTestMode.Name = "chkTestMode"
        Me.chkTestMode.Size = New System.Drawing.Size(61, 17)
        Me.chkTestMode.TabIndex = 40
        Me.chkTestMode.Text = "Testing"
        Me.chkTestMode.UseVisualStyleBackColor = True
        '
        'chkPrefixAll
        '
        Me.chkPrefixAll.AutoSize = True
        Me.chkPrefixAll.Checked = True
        Me.chkPrefixAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrefixAll.Location = New System.Drawing.Point(121, 99)
        Me.chkPrefixAll.Name = "chkPrefixAll"
        Me.chkPrefixAll.Size = New System.Drawing.Size(52, 17)
        Me.chkPrefixAll.TabIndex = 41
        Me.chkPrefixAll.Text = "Prefix"
        Me.chkPrefixAll.UseVisualStyleBackColor = True
        '
        'chkPrefix
        '
        Me.chkPrefix.AutoSize = True
        Me.chkPrefix.Location = New System.Drawing.Point(121, 145)
        Me.chkPrefix.Name = "chkPrefix"
        Me.chkPrefix.Size = New System.Drawing.Size(52, 17)
        Me.chkPrefix.TabIndex = 42
        Me.chkPrefix.Text = "Prefix"
        Me.chkPrefix.UseVisualStyleBackColor = True
        '
        'chkBegin
        '
        Me.chkBegin.AutoSize = True
        Me.chkBegin.Location = New System.Drawing.Point(179, 145)
        Me.chkBegin.Name = "chkBegin"
        Me.chkBegin.Size = New System.Drawing.Size(97, 17)
        Me.chkBegin.TabIndex = 43
        Me.chkBegin.Text = "beginning  with"
        Me.chkBegin.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAdd.Location = New System.Drawing.Point(40, 534)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 23)
        Me.btnAdd.TabIndex = 44
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnUpdate.Location = New System.Drawing.Point(113, 534)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(60, 23)
        Me.btnUpdate.TabIndex = 45
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDelete.Location = New System.Drawing.Point(185, 534)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 23)
        Me.btnDelete.TabIndex = 46
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'txtDXccID
        '
        Me.txtDXccID.Location = New System.Drawing.Point(740, 534)
        Me.txtDXccID.Name = "txtDXccID"
        Me.txtDXccID.Size = New System.Drawing.Size(47, 20)
        Me.txtDXccID.TabIndex = 47
        '
        'txtUsp_String
        '
        Me.txtUsp_String.Location = New System.Drawing.Point(282, 96)
        Me.txtUsp_String.Name = "txtUsp_String"
        Me.txtUsp_String.Size = New System.Drawing.Size(312, 20)
        Me.txtUsp_String.TabIndex = 48
        '
        'lblUspStr
        '
        Me.lblUspStr.AutoSize = True
        Me.lblUspStr.Location = New System.Drawing.Point(243, 103)
        Me.lblUspStr.Name = "lblUspStr"
        Me.lblUspStr.Size = New System.Drawing.Size(33, 13)
        Me.lblUspStr.TabIndex = 49
        Me.lblUspStr.Text = "usp .."
        '
        'txtGuidID
        '
        Me.txtGuidID.Location = New System.Drawing.Point(264, 536)
        Me.txtGuidID.Name = "txtGuidID"
        Me.txtGuidID.Size = New System.Drawing.Size(257, 20)
        Me.txtGuidID.TabIndex = 50
        '
        'btnGetMaxID
        '
        Me.btnGetMaxID.Location = New System.Drawing.Point(629, 77)
        Me.btnGetMaxID.Name = "btnGetMaxID"
        Me.btnGetMaxID.Size = New System.Drawing.Size(78, 39)
        Me.btnGetMaxID.TabIndex = 51
        Me.btnGetMaxID.Text = "Find Max DXccID"
        Me.btnGetMaxID.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(792, 541)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Of"
        '
        'txtMaxID
        '
        Me.txtMaxID.Location = New System.Drawing.Point(713, 95)
        Me.txtMaxID.Name = "txtMaxID"
        Me.txtMaxID.Size = New System.Drawing.Size(63, 20)
        Me.txtMaxID.TabIndex = 53
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'lblSendHeading
        '
        Me.lblSendHeading.AutoSize = True
        Me.lblSendHeading.Location = New System.Drawing.Point(217, 634)
        Me.lblSendHeading.Name = "lblSendHeading"
        Me.lblSendHeading.Size = New System.Drawing.Size(16, 13)
        Me.lblSendHeading.TabIndex = 58
        Me.lblSendHeading.Text = "..."
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(437, 800)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 60
        Me.lblPort.Text = "Port"
        '
        'txtLocalServer
        '
        Me.txtLocalServer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLocalServer.Location = New System.Drawing.Point(255, 10)
        Me.txtLocalServer.Name = "txtLocalServer"
        Me.txtLocalServer.Size = New System.Drawing.Size(134, 20)
        Me.txtLocalServer.TabIndex = 61
        '
        'lblLocalServer
        '
        Me.lblLocalServer.AutoSize = True
        Me.lblLocalServer.Location = New System.Drawing.Point(37, 13)
        Me.lblLocalServer.Name = "lblLocalServer"
        Me.lblLocalServer.Size = New System.Drawing.Size(94, 13)
        Me.lblLocalServer.TabIndex = 62
        Me.lblLocalServer.Text = "Local SQL Server:"
        '
        'txtComputerName
        '
        Me.txtComputerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtComputerName.Location = New System.Drawing.Point(134, 10)
        Me.txtComputerName.Name = "txtComputerName"
        Me.txtComputerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtComputerName.Size = New System.Drawing.Size(106, 20)
        Me.txtComputerName.TabIndex = 63
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(242, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "\"
        '
        'btnResendHeading
        '
        Me.btnResendHeading.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnResendHeading.Location = New System.Drawing.Point(629, 785)
        Me.btnResendHeading.Name = "btnResendHeading"
        Me.btnResendHeading.Size = New System.Drawing.Size(75, 42)
        Me.btnResendHeading.TabIndex = 65
        Me.btnResendHeading.Text = "Send Path"
        Me.btnResendHeading.UseVisualStyleBackColor = False
        '
        'btnNewRecords
        '
        Me.btnNewRecords.Location = New System.Drawing.Point(629, 130)
        Me.btnNewRecords.Name = "btnNewRecords"
        Me.btnNewRecords.Size = New System.Drawing.Size(75, 40)
        Me.btnNewRecords.TabIndex = 66
        Me.btnNewRecords.Text = "Added Records"
        Me.btnNewRecords.UseVisualStyleBackColor = True
        '
        'chkLongPath
        '
        Me.chkLongPath.AutoSize = True
        Me.chkLongPath.Location = New System.Drawing.Point(710, 799)
        Me.chkLongPath.Name = "chkLongPath"
        Me.chkLongPath.Size = New System.Drawing.Size(73, 17)
        Me.chkLongPath.TabIndex = 67
        Me.chkLongPath.Text = "ShortPath"
        Me.chkLongPath.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(0, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 68
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkDebug
        '
        Me.chkDebug.AutoSize = True
        Me.chkDebug.Location = New System.Drawing.Point(713, 10)
        Me.chkDebug.Name = "chkDebug"
        Me.chkDebug.Size = New System.Drawing.Size(58, 17)
        Me.chkDebug.TabIndex = 69
        Me.chkDebug.Text = "Debug"
        Me.chkDebug.UseVisualStyleBackColor = True
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(327, 795)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(82, 21)
        Me.cboPort.TabIndex = 70
        '
        'btnTestPort
        '
        Me.btnTestPort.Location = New System.Drawing.Point(479, 795)
        Me.btnTestPort.Name = "btnTestPort"
        Me.btnTestPort.Size = New System.Drawing.Size(75, 23)
        Me.btnTestPort.TabIndex = 71
        Me.btnTestPort.Text = "Sel. Port"
        Me.btnTestPort.UseVisualStyleBackColor = True
        '
        'lblPortUsing
        '
        Me.lblPortUsing.AutoSize = True
        Me.lblPortUsing.Location = New System.Drawing.Point(437, 781)
        Me.lblPortUsing.Name = "lblPortUsing"
        Me.lblPortUsing.Size = New System.Drawing.Size(34, 13)
        Me.lblPortUsing.TabIndex = 72
        Me.lblPortUsing.Text = "Using"
        '
        'lblSendHeadingLong
        '
        Me.lblSendHeadingLong.AutoSize = True
        Me.lblSendHeadingLong.Location = New System.Drawing.Point(598, 634)
        Me.lblSendHeadingLong.Name = "lblSendHeadingLong"
        Me.lblSendHeadingLong.Size = New System.Drawing.Size(16, 13)
        Me.lblSendHeadingLong.TabIndex = 73
        Me.lblSendHeadingLong.Text = "..."
        '
        'frmMainStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 891)
        Me.Controls.Add(Me.lblSendHeadingLong)
        Me.Controls.Add(Me.lblPortUsing)
        Me.Controls.Add(Me.btnTestPort)
        Me.Controls.Add(Me.cboPort)
        Me.Controls.Add(Me.chkDebug)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chkLongPath)
        Me.Controls.Add(Me.btnNewRecords)
        Me.Controls.Add(Me.btnResendHeading)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtComputerName)
        Me.Controls.Add(Me.lblLocalServer)
        Me.Controls.Add(Me.txtLocalServer)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.lblSendHeading)
        Me.Controls.Add(Me.txtMaxID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnGetMaxID)
        Me.Controls.Add(Me.txtGuidID)
        Me.Controls.Add(Me.lblUspStr)
        Me.Controls.Add(Me.txtUsp_String)
        Me.Controls.Add(Me.txtDXccID)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.chkBegin)
        Me.Controls.Add(Me.chkPrefix)
        Me.Controls.Add(Me.chkPrefixAll)
        Me.Controls.Add(Me.chkTestMode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lvwCustomers)
        Me.Controls.Add(Me.lblConnectionStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRecords)
        Me.Controls.Add(Me.btnLoadDXCC)
        Me.Controls.Add(Me.txtContinent)
        Me.Controls.Add(Me.txtLatitude)
        Me.Controls.Add(Me.txtLongPath)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.txtQTH_Locator)
        Me.Controls.Add(Me.txtLongnitude)
        Me.Controls.Add(Me.txtKm)
        Me.Controls.Add(Me.txtShortPath)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblContinent)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.lblLongPath)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.lblQthLoc)
        Me.Controls.Add(Me.lblLong)
        Me.Controls.Add(Me.lblKM)
        Me.Controls.Add(Me.lblShortPath)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.txtFindme)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtConnectionString)
        Me.Controls.Add(Me.btnConnect)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMainStart"
        Me.Text = "Beam Headings for DXCC countries .. for the City of Adelaide, Australia 2025"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtFindme As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents lblShortPath As System.Windows.Forms.Label
    Friend WithEvents lblKM As System.Windows.Forms.Label
    Friend WithEvents lblLong As System.Windows.Forms.Label
    Friend WithEvents lblQthLoc As System.Windows.Forms.Label
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblLongPath As System.Windows.Forms.Label
    Friend WithEvents lblLat As System.Windows.Forms.Label
    Friend WithEvents lblContinent As System.Windows.Forms.Label
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtShortPath As System.Windows.Forms.TextBox
    Friend WithEvents txtKm As System.Windows.Forms.TextBox
    Friend WithEvents txtLongnitude As System.Windows.Forms.TextBox
    Friend WithEvents txtQTH_Locator As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtLongPath As System.Windows.Forms.TextBox
    Friend WithEvents txtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents txtContinent As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadDXCC As System.Windows.Forms.Button
    Friend WithEvents txtRecords As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblConnectionStatus As System.Windows.Forms.Label
    Friend WithEvents lvwCustomers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Column1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkTestMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrefixAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrefix As System.Windows.Forms.CheckBox
    Friend WithEvents chkBegin As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtDXccID As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtUsp_String As System.Windows.Forms.TextBox
    Friend WithEvents lblUspStr As System.Windows.Forms.Label
    Friend WithEvents txtGuidID As System.Windows.Forms.TextBox
    Friend WithEvents btnGetMaxID As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtMaxID As System.Windows.Forms.TextBox
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblSendHeading As System.Windows.Forms.Label
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtLocalServer As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalServer As System.Windows.Forms.Label
    Friend WithEvents txtComputerName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnResendHeading As System.Windows.Forms.Button
    Friend WithEvents btnNewRecords As System.Windows.Forms.Button
    Friend WithEvents chkLongPath As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDebug As System.Windows.Forms.CheckBox
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents btnTestPort As System.Windows.Forms.Button
    Friend WithEvents lblPortUsing As System.Windows.Forms.Label
    Friend WithEvents lblSendHeadingLong As System.Windows.Forms.Label

End Class
