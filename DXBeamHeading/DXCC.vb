
Imports System.Data.OleDb



Public Class frmMainStart
    'Private myConn As SqlConnection     'connection
    'Private myCmd As SqlCommand

    'Private objData As WDABase

    Public Provider As String = "SQL Server"
    Public ServerName As String = "DESKTOPVK5CT\SQLEXPRESS"
    Public DataBase As String = "DXCC"
    Public DBTable As String = "DXCCAu"
   
    Public ConnectionString As String
    Public SQLCommandString As String 'SQL command to instagate Search using LIKE
    Public SearchLike As String    ' eg VK5 etc

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        'Dim connectionString As String = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True"
        'ConnectionString = "Data Source=LAPTOP_VK5CT\SQLEXPRESS;Initial Catalog=DXCC;Integrated Security=True"
        'Imports System.Data.SqlClient 'sql client needed!
        'Dim myConn As New SqlConnection(ConnectionString1)

        'code out below 
        'Try
        ''myConn.Open()
        'MessageBox.Show("Connection Successfull!", "Server Connection")
        ''myConn.Close()
        'Catch ex As Exception
        'MessageBox.Show("Connection FAILED!", "Server Connection")
        'End Try

        'use old method
        'chkBegin.Checked = True
        'txtConnectionString.Text = ConnectionString

        'txtConnectionString.Show()
        'DBConnection.Show()


    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ConnectionString = "Data Source=" & ServerName & ";Initial Catalog=" & DataBase & ";Integrated Security=True"
        'ConnectionString = "Data Source=LAPTOP_VK5CT\SQLEXPRESS;Initial Catalog=DXCC;Integrated Security=True"

        'txtLocalServer.Text = Server 'show local server on the Main Form
        txtLocalServer.Text = "SQLEXPRESS"

        chkTestMode.Checked = False 'not in test mode at each start
        btnConnect.Hide()
        btnNewRecords.Hide()
        txtConnectionString.Hide()
        lblConnectionStatus.Hide()
        txtUsp_String.Hide()
        lblUspStr.Hide()
        btnGetMaxID.Hide()
        txtMaxID.Hide()
        chkDebug.Hide()
        lblPort.Hide()
        lblPortUsing.Hide()


        'lblPort.ForeColor = Color.Red
        'lblPortUsing.ForeColor = Color.Red

        btnResendHeading.Visible = False              'setup port first

        chkBegin.Checked = True 'for showing search results
        chkPrefix.Checked = True 'for showing search results
        chkPrefixAll.Checked = True 'For showing all results

        'MessageBox.Show(Server, "1. This PC's SQL Server")

        '' 
        ''Dim PCnameName As String
        ''PCnameName = Environ("computername")
        txtComputerName.Text = ComputerName
        Server = ComputerName & "\" & "SQLEXPRESS" 'The default server is now the Computername and "\SQLSERVER !

        'MessageBox.Show(Server, "2. This PC's SQL Server")

        txtConnectionString.Text = ConnectionString '' show the string usp
        'MessageBox.Show(ConnectionString, "Connection String")

        'txtComPort.Text = SelectedPort ' com port selected

        txtFindme.Text = "Vk"
        HasParameters = False
        SetLoadStoredProcs()    'load correct Stored proc, parameters etc based on where call from and checkbox's
        'MessageBox.Show("Startup")
        ShowDXCCinfo()
        lvwCustomers.Focus()
        'MessageBox.Show("Startup End")
        FindPorts() 'fill combo box, 

    End Sub

    Private Sub FindPorts()

        ''rdoSetupPort.Hide()

        cboPort.Items.Clear()

        ' Add all available serial port names to the ComboBox
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboPort.Items.Add(sp)
        Next

        ' Select the first item as DEFAULT if any ports are found
        If cboPort.Items.Count > 0 Then
            cboPort.SelectedIndex = 0
        End If

        Try
            SelectedPort = cboPort.SelectedItem.ToString()
            'MessageBox.Show("Port is " & SelectedPort, "Selected Com Port")
        Catch ex As Exception
            MessageBox.Show("None Available!", "Com Port Availability")
            'cboPort.Hide()
            ''Me.Close() 'closes program
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        '
        'SQLCommandString = "SELECT * FROM " & DBTable & " WHERE Prefix LIKE @" & SearchLike & ", myConn"
        'txtQryCmd.Text = SQLCommandString
        'MessageBox.Show("Check Qry string!")

        'CallbyLoad = False              'calleed by search
        SearchLike = txtFindme.Text     'search for this string!

        SetSearchStoredProcs()                       'load correct Stored proc, parameters etc based on where call from and checkbox's
        ShowDXCCinfo()

        'CallbyLoad = True               'default
    End Sub

    Private Sub ShowDXCCinfo()
        'Shows listView with all customer/manufacturer information


        'Declare variables
        Dim objListViewItem As ListViewItem
        'Dim RiderMass As String = String.Empty

        'Dim HasParameters As Boolean = False    'no parameters for this query

        'This is done in the properties  for the ListView object or here!
        'set column header names ******
        'lvwCustomers.Columns(0).Text = "Prefix"
        'lvwCustomers.Columns(1).Text = "Country"
        'lvwCustomers.Columns(2).Text = "ShortPath"
        'lvwCustomers.Columns(3).Text = "LongPath"

        'USPselection = "usp_SelectPrefix"      'qry to return all countries
        '@pattern char(20)
        'HasParameters = True

        'USPselection = "usp_SelectPrefixs"      'qry to return all countries
        'HasParameters = False    'no parameters for this query

        Me.Refresh()

        Records = 0
        'All site, eed text information is 100 bytes unless stated

        'Provider:  is "SQL Server"
        'Server:    DESKTOPVK5CT\SQLEXPRESS 
        'DataBase:  DXCC
        'Login:     ""  ,only required if SQL server authentication is used
        'Password:  ""  , (as above) and must be changed depending on localDB selected.

        'If chkTestMode.Checked = True Then
        'MessageBox.Show("Usp=" & USPselection.ToString & "; HasPars= " & HasParameters.ToString, "Testing")
        'End If

        Dim LastDXccID As Integer = 0 'get the  max value of the DXccID, for adding new record

        lblConnectionStatus.Text = "Connection Failed!" ''Çorrect if it opens OK

        Using objData As New WDABase(Provider, Server, DataBase, Login, Password) 'Access, SQL etc '*******************
            'Dim myConn As New SqlConnection(ConnectionString1)

            'Using objData As New SqlConnection(ConnectionString1)
            If Debug = True Then
                MessageBox.Show("Prov=" & Provider & ";  Server=" & Server & ";  DataBase=" & DataBase & ":  Login=" & Login & ";  Pass=" & Password & ";  USPselection=" & USPselection, "Connect to Server")

            End If

            'Using objData As New WDABase .. calls IDispose at EndUsing automatically
            Try 'try to open the connection and get data

                'Using objData As New WDABase
                objData.SQL = USPselection

                'Initialize the Command object and set its properties
                objData.InitializeCommand() 'Done Automatically!

                'all parameters must be pass individually with
                'objData.AddWithParameter("@Prefix", Trim(txtFindme.Text))
                If (HasParameters = True) Then
                    objData.AddWithParameter("@Prefix", Trim(txtFindme.Text)) ' @Prefix is used in the query as the string passed.
                End If

                ''Try
                'Open the database connection
                objData.OpenConnection()
                lblConnectionStatus.Text = "Connected OK"
                ''Catch
                'error message
                ''lblConnectionStatus.Text = "Connection Failed!"
                ''End Try

                'Get the data, from DataReader
                objData.DataReader = objData.Command.ExecuteReader

                'Clear previous list
                lvwCustomers.Items.Clear()

                'See if any data exists before continuing
                If objData.DataReader.HasRows Then

                    'objListViewItem.BackColor = Color.WhiteSmoke

                    'Clear previous list
                    'lvwCustomers.Items.Clear()

                    'Process all rows (records)
                    While objData.DataReader.Read()
                        Records = Records + 1

                        'Create a new ListViewItem
                        objListViewItem = New ListViewItem

                        'Add the data to the ListView control (LHS row)
                        objListViewItem.Text = objData.DataReader.Item("Prefix").ToString

                        'CustomerGuidID
                        'use for ????? ListViewSelection?
                        objListViewItem.Tag = objData.DataReader("Prefix").ToString

                        'Add the sub items to the listview item (i.e. Columns to the RHS of Prefix Column (Not working)
                        'Must be same name i.e. "Prefix" as the Table column names! i.e. "Prefix"
                        '
                        objListViewItem.SubItems.Add(objData.DataReader("Country").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("ShortPath").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("LongPath").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("km").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("Latitude").ToString)

                        objListViewItem.SubItems.Add(objData.DataReader("Longitude").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("Continent").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("QTH_Locator").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("DXccID").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("GuidID").ToString)
                        objListViewItem.SubItems.Add(objData.DataReader("Hide").ToString)

                        'DXccID = Integer.Parse(txtDXccID.Text)


                        'If (DXccID > LastDXccID) Then
                        'DXccIDMax = DXccID
                        'End If

                        lvwCustomers.Items.Add(objListViewItem) '

                    End While
                    txtRecords.Text = Records.ToString
                    txtGuidID.Text = LastDXccID.ToString

                Else
                    'No rows of data retrieved
                    MessageBox.Show("No Rows of Data received", "DataReader .. Results")

                End If

                'try to open the connection and get data
            Catch ex As System.InvalidOperationException
                MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")

            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show(ex.Message.ToString, "Error: Sql Exception")

            Catch ex As System.Exception
                MessageBox.Show(ex.Message.ToString, "Error: System Exception")

            Finally
                'Cleanup even if error
                objData.Command.Dispose()
                objData.Command = Nothing
            End Try
            lblConnectionStatus.Text = "Not Connection"

        End Using 'WBAClass .. calls IDispose method

        objListViewItem = Nothing
        'objCommand.Parameters.

        lvwCustomers.Focus()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnLoadDXCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDXCC.Click

        SetLoadStoredProcs()                       'load correct Stored proc, parameters etc based on where call from and checkbox's
        ShowDXCCinfo()

    End Sub
    Sub SetLoadStoredProcs()
        '
        HasParameters = False
        If chkPrefixAll.Checked = True Then
            'ordered on Prefix
            USPselection = "usp_SelectPrefixs"        'return all DXCC, order by prefix
        Else
            'ordered on Country
            USPselection = "usp_SelectCountries"      'return all DXCC, order by countries
        End If
        ''If chkTestMode.Checked Then
        txtUsp_String.Text = USPselection
        ''End If
    End Sub

    Sub SetSearchStoredProcs()
        'ordered on Prefixs or Country
        'determine USP selection and Has parameters

        'called by load is false
        'Called by Search Button
        HasParameters = True                        ' all need parameters
        'Prefix
        If chkPrefix.Checked = True Then
            'ordered on Prefix
            If chkBegin.Checked = True Then
                'only match prefix from start of the search string
                USPselection = "usp_FindPrefixL"
            Else
                'match prefix anywhere in the search string
                USPselection = "usp_FindPrefix"      'qry to return all countries
            End If

        Else
            'Country
            'only match Country from start of the search string
            If chkBegin.Checked = True Then
                'only match from start of the search string
                USPselection = "usp_FindCountryL"

            Else
                'match Country from anywhere in search string
                USPselection = "usp_FindCountry"

            End If
        End If
        If chkTestMode.Checked Then
            txtUsp_String.Text = USPselection
        End If

    End Sub


    Private Sub lvwCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwCustomers.SelectedIndexChanged
        ' Fill Text Box details with the item selected details
        '
        'txtRowSel.Text = lvwCustomers.SelectedItems.Count.ToString
        'txtRowSel.Text = lvwCustomers.SelectedItems.Count.ToString

        'Dim selectedItem As ListViewItem = lvwCustomers.Item
        If Debug = True Then
            MessageBox.Show("Listview index changed")
        End If

        Try
            txtPrefix.Text = lvwCustomers.SelectedItems(0).SubItems(0).Text     'Prefix ..Column 0
            txtCountry.Text = lvwCustomers.SelectedItems(0).SubItems(1).Text    'Country..Column 1

            txtShortPath.Text = lvwCustomers.SelectedItems(0).SubItems(2).Text  'ShortPath..Column 2
            ShortPath = Integer.Parse(txtShortPath.Text) 'global save


            txtLongPath.Text = lvwCustomers.SelectedItems(0).SubItems(3).Text   'LongPath ..Column 3

            txtKm.Text = lvwCustomers.SelectedItems(0).SubItems(4).Text         'km        ..Column 4

            txtLatitude.Text = lvwCustomers.SelectedItems(0).SubItems(5).Text   'Latitude..Column 5
            txtLongnitude.Text = lvwCustomers.SelectedItems(0).SubItems(6).Text 'txtLong..Column 6

            txtContinent.Text = lvwCustomers.SelectedItems(0).SubItems(7).Text
            txtQTH_Locator.Text = lvwCustomers.SelectedItems(0).SubItems(8).Text

            txtDXccID.Text = lvwCustomers.SelectedItems(0).SubItems(9).Text

            Try
                DXccID = Integer.Parse(txtDXccID.Text)

            Catch ex As Exception
                'DXccID = 0 'default value
                MessageBox.Show(ex.Message & "DXccID not converted to integer")
            End Try

            txtGuidID.Text = lvwCustomers.SelectedItems(0).SubItems(10).Text


        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString, "Fail to Resolve Listview, Index changed")
        End Try

        'If port chosen, send shortpath data to Arduino
        '
        ''SendShortPathData()

        Me.Refresh()

        If (ShortPath <> LastShortPath) Then
            SendHeadingInfo()
        End If

        LastShortPath = ShortPath

    End Sub

    Private Sub chkTestMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTestMode.CheckedChanged
        'testing
        If (chkTestMode.Checked) Then
            'Testing mode
            btnConnect.Show()
            btnNewRecords.Show()
            txtConnectionString.Show()
            lblConnectionStatus.Show()
            txtUsp_String.Show()
            lblUspStr.Show()
            btnGetMaxID.Show()
            txtMaxID.Show()
            chkDebug.Show()

        Else
            'Running Mode
            btnConnect.Hide()
            btnNewRecords.Hide()
            txtConnectionString.Hide()
            lblConnectionStatus.Hide()
            txtUsp_String.Hide()
            lblUspStr.Hide()
            btnGetMaxID.Hide()
            txtMaxID.Hide()
            chkDebug.Hide()

        End If
    End Sub

    Private Sub chkPrefix_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrefix.CheckedChanged
        If chkPrefix.Checked = True Then
            'use Prefix
            ' setup preDXCC call
            chkPrefix.Text = "Prefix "

        Else
            'use Prefix
            'usp = '
            chkPrefix.Text = "Country"
        End If
        SetSearchStoredProcs()
        ShowDXCCinfo()                  'Connnect to server, exec qry, show results

    End Sub

    Private Sub chkBegin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBegin.CheckedChanged
        If chkBegin.Checked = True Then
            'use Prefix
            'usp = '
            chkBegin.Text = "Beginning with  "
        Else
            'use Prefix
            'usp = '
            chkBegin.Text = "Containg letters"
        End If
        'SetSearchStoredProcs()
        'ShowDXCCinfo()                  'Connnect to server, exec qry, show results
    End Sub

    Private Sub chkPrefixAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrefixAll.CheckedChanged
        If chkPrefixAll.Checked = True Then
            'use Prefix
            ' setup preDXCC call
            chkPrefixAll.Text = "Prefix "

        Else
            'use Prefix
            'usp = '
            chkPrefixAll.Text = "Country"
        End If
        'SetLoadStoredProcs()
        'ShowDXCCinfo()                  'Connnect to server, exec qry, show results

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'add a record

        Dim userResponse As String

        ' Display the message box with a question and Yes/No buttons
        userResponse = MsgBox("Do you want to proceed with this action?", vbYesNo + vbQuestion, "Confirmation")

        'MessageBox.Show("Ans was " & userResponse)

        ' Branch based on the user's response
        Dim vbYes As Integer = 6

        If userResponse = vbYes Then
            ' Code to execute if the user clicks "Yes"
            USPselection = "usp_InsertDXCC"
            HasParameters = True
            Add = True
            MsgBox("You clicked Yes. Proceeding with the action.")
            UpdateAddDXCC()
            'show results
            SetLoadStoredProcs()
            ShowDXCCinfo()                  'Connnect to server, exec qry, show results

        ElseIf userResponse = vbNo Then
            ' Code to execute if the user clicks "No"
            MsgBox("You clicked No. Action cancelled.")
        End If


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        'edit a record
        'add a record

        Dim userResponse As String

        ' Display the message box with a question and Yes/No buttons
        userResponse = MsgBox("Do you want to proceed with this action?", vbYesNo + vbQuestion, "Confirmation")
        'MessageBox.Show("Ans was " & userResponse)

        ' Branch based on the user's response
        Dim vbYes As Integer = 6

        If userResponse = vbYes Then
            ' Code to execute if the user clicks "Yes"
            USPselection = "usp_UpdateDXCC"
            HasParameters = True
            Add = False ' update
            MsgBox("You clicked Yes. Proceeding with the action.")
            UpdateAddDXCC()
            SetLoadStoredProcs()
            ShowDXCCinfo()                  'Connnect to server, exec qry, show results

        ElseIf userResponse = vbNo Then
            ' Code to execute if the user clicks "No"
            MsgBox("You clicked No. Action cancelled.")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'delete a record
        'DeleteDXCC
        Dim userResponse As String

        ' Display the message box with a question and Yes/No buttons
        userResponse = MsgBox("Do you want to proceed with this action?", vbYesNo + vbQuestion, "Confirmation")
        'MessageBox.Show("Ans was " & userResponse)

        ' Branch based on the user's response
        Dim vbYes As Integer = 6

        If userResponse = vbYes Then
            ' Code to execute if the user clicks "Yes"
            USPselection = "DeleteDXCC"
            HasParameters = True

            'MsgBox("You clicked Yes. Proceeding with the action.")
            DeleteDXCC()
            SetLoadStoredProcs()
            ShowDXCCinfo()                  'Connnect to server, exec qry, show results

        ElseIf userResponse = vbNo Then
            ' Code to execute if the user clicks "No"
            MsgBox("You clicked No. Action cancelled.")
        End If


    End Sub
    Public Sub DeleteDXCC()
        'permanently deletes record

        'Update/Add, Standard/  , Customer Info as an Object
        'returns CustomerID GUID as a string for special use (copy)

        'Updates or Adds a new Customer record
        'modify to: pass Customer Info as an object, not use form text-box information.

        Dim intRowsAffected As Integer = 0

        Dim intValue As Integer = 0     'used for text to int conversions

        'Dim CustGuid As Guid = Guid.Empty

        Using objData As New WDABase(Provider, Server, DataBase, Login, Password)
            'Using objData As New WDABase(SpecialProvider, SpecialServer, DataBase, Login, Password) 'Access, SQL etc
            'Initialize the Command object and set its properties

            Try
                objData.SQL = "DeleteDXCC" 'NEW CHM - stored proc

                objData.InitializeCommand() 'Done Automatically!

                'Add the Parameters to the Parameters collection, 
                'Must be Passed in the Same order as query! Names are not important
                'eg. could use @Base or @second etc

                objData.DefaultMaxNameSize = 50 'set default text max size.

                'Prefix, Country, ShortPath, LongPath, km, Latitude, 
                'Longitude, Continent, QTH_Locator, DXccID, 

                'objData.DefaultMaxNameSize = 50
                Me.Refresh()

                objData.AddIntParameter("@DXccID", DXccID) 'Records is current Record count

                'Open the database connection
                objData.OpenConnection()

                'Execute the query - prob with SQL server
                intRowsAffected = objData.Command.ExecuteNonQuery() 'NonQuery does not return data

                'Close the database connection

            Catch ex As System.InvalidOperationException
                MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")

            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show(ex.Message.ToString, "Error: Sql Exception")

            Catch ex As System.Exception
                MessageBox.Show(ex.Message.ToString, "Error: System Exception")

            Finally
                'Cleanup even if error
                objData.Command.Dispose()
                objData.Command = Nothing
            End Try

        End Using

        'Check the rows affected
        If intRowsAffected = 0 Then
            MessageBox.Show("Delete DXCC Failed.")
        Else
            'Add or Update Successful
            MessageBox.Show("Delete DXCC Succeeded.")
        End If

        'returns new GUID if Add, or null if update.
        'Return CustGuid.ToString

    End Sub

    Public Sub UpdateAddDXCC()

        'Public Function UpdateAddDXCC(ByVal Update As Boolean, _
        'ByVal StandardTable As Boolean, ByVal x As Customer) As String

        'Update/Add, Standard/  , Customer Info as an Object
        'returns CustomerID GUID as a string for special use (copy)

        'Updates or Adds a new Customer record
        'modify to: pass Customer Info as an object, not use form text-box information.
        MaxIDvalue = GetMaxDXccID() 'find the highest DXccID number
        MessageBox.Show(MaxIDvalue.ToString, "Max DXccID")

        Dim intRowsAffected As Integer = 0

        Dim intValue As Integer = 0     'used for text to int conversions

        'Dim CustGuid As Guid = Guid.Empty

        Using objData As New WDABase(Provider, Server, DataBase, Login, Password)
            'Using objData As New WDABase(SpecialProvider, SpecialServer, DataBase, Login, Password) 'Access, SQL etc
            'Initialize the Command object and set its properties

            Try
                If Add = True Then
                    'Update existing record
                    objData.SQL = "usp_InsertDXCC" 'NEW CHM - stored proc
                Else
                    'Add a New record - standard record
                    objData.SQL = "usp_UpdateDXCC" 'NEW CHM - stored proc
                    'txtIntID.Text = (GetMaxValue() + 1).ToString 'set new customers to zero
                End If

                objData.InitializeCommand() 'Done Automatically!

                'Add the Parameters to the Parameters collection, 
                'Must be Passed in the Same order as query! Names are not important
                'eg. could use @Base or @second etc

                objData.DefaultMaxNameSize = 50 'set default text max size.

                'Prefix,  Country,  ShortPath,  Longpath,  km,  Latitude,  Longitude,  Continent,  QTH_Locator,  DXccID,  Hide,  GuidID
                'note: the parameters below must be added in the same order as the stored procedure!

                'objData.DefaultMaxNameSize = 50
                Me.Refresh()

                objData.AddTextParameter("@Prefix", txtPrefix.Text) 'Prefix

                objData.AddTextParameter("@Country", txtCountry.Text) 'Country

                objData.AddIntParameter("@ShortPath", txtShortPath.Text) 'ShortPath

                objData.AddIntParameter("@LongPath", txtLongPath.Text) 'Longpath

                'objData.DefaultMaxNameSize = 50
                '.
                objData.AddIntParameter("@km", txtKm.Text) 'km

                objData.AddTextParameter("@Latitude", txtLatitude.Text) 'Latitude

                objData.AddTextParameter("@Longnitude", txtLongnitude.Text) 'Longitude

                objData.AddTextParameter("@Continent", txtContinent.Text) 'Continent

                objData.AddTextParameter("@QTH_Locator", txtQTH_Locator.Text) 'QTH_Locator

                If Add = True Then '****  ADD a New Record *** DXccID
                    'Add a new record! .

                    Dim NewDXccID = MaxIDvalue + 1
                    MessageBox.Show("New DXccID is " & NewDXccID.ToString)

                    'objData.AddGuidParameter("@GuidID", CustGuid)
                    objData.AddIntParameter("@DXccID", Integer.Parse(NewDXccID)) ' next DXccID number (error, always Zero????

                    objData.AddBooleanParameter("@Hide", 0) 'Hide

                    objData.AddGuidNewParameter("@GuidID") 'generates and adds a new guide

                Else '*** Update an existing Record ***

                    'objData.AddGuidParameter("@DXccID", txtDXccID.Text(txtDXccID.Text)) 'DXccID is the current record
                    'objData.AddIntParameter("@DXccID", txtDXccID.Text) 'Records is current Record count (works chm)
                    objData.AddIntParameter("@DXccID", DXccID) 'Records is current Record count (works chm)

                    objData.AddBooleanParameter("@Hide", 0) 'Hide

                    objData.AddGuidParameter("@GuidID", New Guid(txtGuidID.Text)) 'casts the old guid
                End If


                'Open the database connection
                objData.OpenConnection()

                'Execute the query - prob with SQL server
                intRowsAffected = objData.Command.ExecuteNonQuery() 'NonQuery does not return data

                'Close the database connection

            Catch ex As System.InvalidOperationException
                MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")

            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show(ex.Message.ToString, "Error: Sql Exception")

            Catch ex As System.Exception
                MessageBox.Show(ex.Message.ToString, "Error: System Exception")

            Finally
                'Cleanup even if error
                objData.Command.Dispose()
                objData.Command = Nothing
            End Try

        End Using

        'Check the rows affected
        If intRowsAffected = 0 Then
            'Add or Update Failed
            If Add = True Then
                MessageBox.Show("Add New DXCC record Failed.")
            Else
                MessageBox.Show("Update DXCC Failed.")
            End If
        Else
            'Add or Update Successful
            If Add = True Then
                MessageBox.Show("Add New DXCC Succeeded.")
            Else
                MessageBox.Show("Update DXCC Succeeded.")
            End If


        End If

        'returns new GUID if Add, or null if update.
        'Return CustGuid.ToString

    End Sub
    Public Function GetMaxDXccID() As Integer
        'returns max value (i.e. of IntID) for all existing customer's as string (Works OK)

        Dim IntID As Integer = 0

        'Using objData As New WDABase
        Using objData As New WDABase(Provider, Server, DataBase, Login, Password) 'Access, SQL etc

            Try
                objData.SQL = "usp_MaxIntID" 'Max Job Int

                'Initialize the Command object and set its properties
                objData.InitializeCommand() 'Done Automatically!

                objData.OpenConnection()

                'Get the data returned by the qry
                objData.DataReader = objData.Command.ExecuteReader

                'See if any data exists before continuing
                If objData.DataReader.HasRows Then

                    'Read the first (only 1 row of data returned in this Qry)
                    objData.DataReader.Read()
                    Try
                        IntID = objData.DataReader.Item("") 'Gets the Resxult of the Stored Proc, Query OK
                    Catch ex As Exception
                        IntID = 0
                    End Try
                Else
                    'no records found
                    IntID = 0
                End If

            Catch ex As System.InvalidOperationException
                MessageBox.Show(ex.Message.ToString, "Error: Invalid Operation Exception")

            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show(ex.Message.ToString, "Error: Sql Exception")

            Catch ex As System.Exception
                MessageBox.Show(ex.Message.ToString, "Error: System Exception")

            Finally
                'Cleanup even if error
                objData.Command.Dispose()
                objData.Command = Nothing
            End Try

            'objData.DataReader.Close()
            'Close the database connection
        End Using 'WBAClass .. calls IDispose method

        Return IntID

    End Function

    Private Sub txtDXccID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDXccID.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuidID.TextChanged

    End Sub

    Private Sub btnGetMaxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMaxID.Click
        '
        txtMaxID.Text = GetMaxDXccID().ToString

    End Sub
    Private Sub btnNewRecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecords.Click
        'find added records
        'DXCCID > 339
        USPselection = "usp_FindNewPrefixs"
        ''[dbo].[usp_FindNewPrefixs]
        HasParameters = False
        txtUsp_String.Text = USPselection
        ShowDXCCinfo()

    End Sub

    Public Sub SendHeadingInfo()
        'used in 2 places, listview selection changed and forced send
        'frmSerialPort.Show()
        'auto send the heading, if port tested

        If PortTestStatus = True Then 'Port has been tested and ok
            'ckkPortTestStatus.Checked = True


            lblPort.ForeColor = Color.Green
            lblPortUsing.ForeColor = Color.Green
            btnResendHeading.Visible = True 'show user send heading button

            ''lblSendHeading.Text = "Sending Heading " & txtShortPath.Text & " Deg."
            lblSendHeading.ForeColor = Color.Green
            lblSendHeadingLong.ForeColor = Color.Green
            Timer1.Enabled = True ' Start the timer, to hide the text after 2 seconds

            SendPathData() 'sent from main form
        Else
            'Port Not Tested
            '

        End If

    End Sub

    Private Sub txtShortPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShortPath.TextChanged
        ' send info via serial port if this value changes.
        '
        ''SendHeadingInfo()

    End Sub

  

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '
        lblSendHeading.Text = "" ' Clear the label text
        lblSendHeadingLong.Text = ""
        Timer1.Enabled = False ' Stop the timer
    End Sub

    Private Sub ckkPortTestStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        'If ckkPortTestStatus.Checked = True Then
        '
        'btnResendHeading.Visible = True
        'End If

    End Sub

    Private Sub btnResendHeading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResendHeading.Click
        '
        SendHeadingInfo() '
        lvwCustomers.Focus() 'try get focus again

    End Sub

    
    Private Sub chkShortPath_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLongPath.CheckedChanged
        'long path option, modify so long path of (shortpath headinmg is sent instead 
        If chkLongPath.Checked Then
            LongPath = True
            chkLongPath.Checked = True
            chkLongPath.Text = "Long Path"
        Else
            'únchecked
            'Long Path
            LongPath = False
            chkLongPath.Checked = False
            chkLongPath.Text = "Short Path"
        End If
    End Sub

    Private Sub chkDebug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebug.CheckedChanged
        If chkDebug.Checked = True Then
            Debug = True
        Else
            Debug = False
        End If
    End Sub

    Public Sub SendPathData()
        '
        'Uses Serial Port 2
        'Uses Shortpath (Global Int) with checkbox Longpath to send the correct info via the serial Port
        'PortStatus, indicates if the port has been open ok, recently
        'If PortTestStatus = True Then 'ok to use port
        'short longpath option
        ''
        Dim Heading As Integer = ShortPath 'Save value of heading
        Dim HeadingID As String = "S"
        ''Dim HID As Char = 'S'

        If LastPort IsNot Nothing Then
            Try
                ' Configure the SerialPort component
                SerialPort2.PortName = LastPort
                SerialPort2.BaudRate = 9600 ' Set your desired baud rate
                SerialPort2.DataBits = 8
                SerialPort2.StopBits = IO.Ports.StopBits.One
                SerialPort2.Parity = IO.Ports.Parity.None

                ' Open the serial port
                SerialPort2.Open()

                ' Send the text from TextBox1 is better. i.e. no empty string etc.
               
                ''''''''''''''''''''''''
                If LongPath = True Then
                    HeadingID = "L"
                End If

                If ((Heading >= 0) And (Heading <= 360)) Then
                    If LongPath = True Then
                        'smodify heading to longpath value.
                        If ShortPath >= 180 Then
                            Heading = ShortPath - 180                     
                        Else
                            'Shortpath was < 180, so add 180
                            Heading = 180 + ShortPath                     
                        End If
                    End If

                    If LongPath = True Then
                        lblSendHeading.Text = ""
                        lblSendHeadingLong.Text = "Sending " & Heading & " Deg. " & HeadingID
                    Else
                        lblSendHeadingLong.Text = ""
                        lblSendHeading.Text = "Sending " & Heading & " Deg. " & HeadingID
                    End If

                    SerialPort2.Write(Heading & HeadingID & vbCrLf) 'send shortpath direction to Arduino via port
                    ''lblSendHeading.Text = "Sending " & Heading & " Deg. " & HeadingID
                Else
                    MessageBox.Show(ShortPath.ToString & " <- Invalid Short Path Heading")
                End If
                'SerialPort1.Write(ShortPath) 'send shortpath direction to Arduino via port

                ' Close the serial port
                SerialPort2.Close()
                ''SerialPort2.Text = "Heading Sent OK"
                ''SerialPort2.ForeColor = Color.Green

                If Debug = True Then
                    MessageBox.Show("Text sent successfully!", "Serial Port Communication", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                ''lblSendInfo.Text = "Error Heading Not Sent!"
                ''lblSendInfo.ForeColor = Color.Red
                MessageBox.Show("Error sending data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a serial port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub btnTestPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestPort.Click
        'test selected Port
        'refresh combo box
        'FindPorts()
        TestCommPort()
    End Sub

    Private Sub TestCommPort()
        '
        If cboPort.SelectedItem IsNot Nothing Then
            Try
                ' Configure the SerialPort component
                SerialPort2.PortName = cboPort.SelectedItem.ToString()
                SerialPort2.BaudRate = 9600 ' Set your desired baud rate
                SerialPort2.DataBits = 8
                SerialPort2.StopBits = IO.Ports.StopBits.One
                SerialPort2.Parity = IO.Ports.Parity.None

                If Debug = True Then

                End If
                'MessageBox.Show("PortName is " & cboPorts.SelectedItem.ToString(), "Test Port")

                ' Open the serial port
                SerialPort2.Open()
                PortTestStatus = True 'Port has opened ok
                lblPort.Show()
                lblPortUsing.Show()
                LastPort = SelectedPort
                ''lblPortTestStatus.ForeColor = Color.Green
                ''lblPortTestStatus.Text = "Tested OK"
                cboPort.Hide()
                btnTestPort.Hide()
                lblPort.Text = SelectedPort
                lblPort.ForeColor = Color.Green
                lblPortUsing.ForeColor = Color.Green

                ' Close the serial port
                SerialPort2.Close()

                'If Debug = True Then
                MessageBox.Show("Port " & SelectedPort & " Opened Successfully!", "Serial Port Availability", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End If

            Catch ex As Exception
                'lblPortTestStatus.ForeColor = Color.Red
                ''lblPortTestStatus.Text = "Not Tested"
                ''lblPortTestStatus.ForeColor = Color.Red
                MessageBox.Show("Port Not Available: " & ex.Message, "Port Available Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a serial port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'lblPortTestStatus.ForeColor = Color.Red
        End If

    End Sub

    Private Sub lblSendHeading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSendHeading.Click

    End Sub

    Private Sub cboPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPort.SelectedIndexChanged
        'select the comm port
        SelectedPort = cboPort.SelectedItem.ToString()
        'MessageBox.Show("Selection is " & SelectedPort)
        'TestCommPort()
    End Sub
End Class


