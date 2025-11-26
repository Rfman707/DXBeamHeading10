Module Globals
    Public DataSource As String
    Public MSAccessProvider As String
    Public Server As String = "" 'local server
    Public Server1 As String = "DESKTOPVK5CT\SQLEXPRESS" 'local server
    Public Login As String
    Public Password As String
    Public USPselection As String = "usp_SelectPrefixs" 'all countries
    Public HasParameters As Integer

    '
    Public WinAuthent As Boolean = True             'Windows or SQL authentication
    Public DataBase As String = "DXCC"
    Public Const SQLProvider As String = "SQL Server"
    Public SQLServer As String                      'Current SQL Server
    Public SQL_Available As Boolean

    'Public Update As Boolean = False                'Update record
    Public Add As Boolean = True
    Public Records As Integer                       'No. of records 
    Public DXccID As Integer                        'Current record
    Public DXccIDMax As Integer                     'find max when reading each row 
    Public Hide As Boolean                          'flag to indicate a record to not be displayed
    Public MaxIDvalue As Integer
    Public SelectedPort As String                   'comm port selected
    Public ShortPath As Integer = 0              'short path for selected Prefix
    Public LastShortPath As Integer = 0          'Previous short path for selected Prefix

    Public LongPath As Boolean = False              'úse long path direction
    Public PortTestStatus As Integer = False        'flag if Port has been tested

    Public ComputerName As String                   'This computers name 
    Public LastPort As String                       'last port used i.e. Com6
    Public PortAvailable As Boolean = False         'port has been tested


    Public Debug As Boolean = False


    'Use a script to Create stored procedure in Database DXCC
    'USE [DXCC]
    'GO
    '/****** Object:  StoredProcedure [dbo].[usp_SelectPrefixs]    Script Date: 6/11/2025 5:58:15 AM ******/
    'SET ANSI_NULLS ON
    'GO
    'SET QUOTED_IDENTIFIER ON
    'GO
    'ALTER PROC [dbo].[usp_SelectPrefixs] 
    'as SELECT Prefix, Country, ShortPath, Longpath, km, Latitude, Longitude, Continent, QTH_Locator
    'FROM DXCCAu
    'ORDER by Prefix, ShortPath, Country
    'GO

End Module
