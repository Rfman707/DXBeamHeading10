Module Module1
    Sub Main()
        ' Get the computer name
        'Dim computerName As String = My.Computer.Name
        ComputerName = My.Computer.Name
        Server = ComputerName & "\SQLEXPRESS"
        
        ' Display the computer name in a message box
        If Debug = True Then
            MessageBox.Show("Server Name: " & Server, "Sub Main .. Server.")
        End If


        ' Start the application's main form
        Application.Run(New frmMainStart())
    End Sub

End Module
