This is my second Real attempt at publishing some code for a working project. This is a Microsoft Visual Studio Community 2022 (64-bit) - Version 17.14.18 (October 2025)
The visual basic program is used to send a beam heading via a com port to your controller (ESP32/Arduino) The program enables a Search for a Stations Call Prefix e.g. F6ARC, and selecting a suitable Row from the Listview box, sends the shortPath or LongPath direction if a Comport has been selected and tested. This serial information is used to control your rotator's direction via your home made, modified or commercial rotator controller. 
I am using a web based controller to control an old EMOTATOR 105. The code was developed on the free version of Visual Studio 2025 and SQL Server EXPRESS 2025. 
It was originally written in Visual Studio 2008 and imported into a Current version of Visual Studio Express. 
I have not built a Deployed project yet, this will come soon.
My QTH is Adelaide, South Australia, so the headings are based on my QTH (PF95fe), my Call is VK5CT The Short Path Directions can be altered, 
by altering the SQL servers database 'DXCC, table DXccAu, Column's, ShortPath, LongPath and km based on your own QTH. 
I used a text file generated from this website http://ok2pbq.atesystem.cz/prog/dxcclist.php as the basis for this process.

Objective:
---------
Modify the Database DXCC used in the Visual Studio 2022 project, and modify the contents of 3 Columns of data in the Table DXccAu. 
The 3 Column's ShortPath, LongPath and km will be updated to reflect your QTH's data, rather than the data provided in the 
sample database supplied. i.e. DXCC.bak that is based on my QTH.

Databases: 1) DXCC (Restored from the included file DXCC.bak),    2) DXccNew is Created by you using SSMS.
Tables:    1) DXccAu is a table that exists in the database DXCC, 2) DXccXX is a user generated table in the database DXccNew.


Stage 1.
-------
Create a new Text file DXccXX.txt that contains 9 Columns and 339 Rows of your QTH data. 
A Wizard will use this file to import data into a temporary Database Called, DXccNew, and generates a table called DXccXX when completed. 

a) Create a text file using your Location e.g. PF95fe for myself or JN99gm the default from the site below..
http://ok2pbq.atesystem.cz/prog/dxcclist.php

b) Select all the text on this page using your mouse to high-light (select) the text, then use Ctl + C to copy the selected text.
Open Notepad, or similar text editor, and paste into a file named DXccXX.txt the text using CTL + V.

c) You will need to tidy up the first few lines of text so the Column names are clearly separated with TABs.
There must be 9 Column as shown below.

Prefix	Country		ShortPath	LongPath	km	Latitude	Longitude	Continent	QTH_Locator
1A	Sov. Mil.	295		115		15358	41N		12E		EU		JN61aa
1S	Spratly Is.	323		143		5572	8N		111E		AS		OJ58ma
3A	Monaco		297		117		15796	43N		7E		EU		JN33ma
......	
ZS8	Prince Edward	167		347		10782	46S		37E		AF		KE84ma


There should be 339 rows of data and 9 Columns.

d) Name this new File DXccXX.txt, i.e. the same name as the new generated Table in the new Database DXccNew.


Stage 2.
-------
Prerequisites.

Using Microsoft's SQL Server Management Studio (SSMS) 21, v21.6.17 or later, installed and running. (Free)
SQL Server (EXPRESS) 22 SQL Server & Configuration Manager Version: 2022.0160.1000.06 

Permissions to create a database and import data on the SQL Server instance. 

Using the Import and Export Wizard
Create the new destination database with SSMS:

1) In Object Explorer, right-click on the Databases node.
Select New Database... and provide a name for your new database. (DXccNew)
Click OK.

2) Start the Import and Export Wizard: using the 
Right-click on the newly created database in Object Explorer. Note: Find the location of the DXCC-New.txt file before beginning.

Hover over Tasks, and select Import Flat File. This launches the SQL Server Import and Export Wizard.
Specify the Input File:, use the Browse option supplied.  (DXccXX.txt)
Enter the Table Name, DXccXX and Schema as dbo.
This completes the "Specify Input File"page of the Wizard.
Press Next to Preview the Data, Press Next again (Modify Columns).
Press Next again.
Press Next again to Finish.

Verify the Import:
Right click on the New Database, DXccNew, Expand to view the table DXccXX.
Right Click to view the first 1000 records.
The data from the Text file should be imported into the new database.

Stage 3
-----

Use a query to replace the data in the DXCC database, table DXccAu, Columns, ShortPath, LongPath and km with your QTH data.

Select New Query in the SSMS.

copy and paste the lines below to update the Database DXCC, table DXccAu, used by Visual Studio Express from the Database DXccNew, table DXccXX.  

/* 
Database to Update is DXCC
Table to update is DXccAu
Column's updated are ShortPath, LongPath and km

Database containing New QTH info is DXccNew
Table supplying data is DXccXX
Columns supplying updated QTH data are ShortPath, LongPath and km
Column Join is Prefix, a text string, must be identical.

*/
-- 24 Nov 25 CHM

UPDATE DXCC.dbo.DXccAu 
SET 
    DXCC.dbo.DXccAu.ShortPath = DXccNew.dbo.DXccXX.ShortPath,
    DXCC.dbo.DXccAu.LongPath = DXccNew.dbo.DXccXX.LongPath,
    DXCC.dbo.DXccAu.km = DXccNew.dbo.DXccXX.km
FROM DXCC.dbo.DXccAu
JOIN DXccNew.dbo.DXccXX ON DXCC.dbo.DXccAu.Prefix = DXccNew.dbo.DXccXX.Prefix;



The Perform Operation page will show the progress and result.
Once completed successfully, right-click on the Tables node under your new database in SSMS Object Explorer and select Refresh to see your new table(s). 
You can then right-click on the table and select Select Top 1000 Rows to view the imported data. 
There should be 339 records, and Include the following 9 Columns,
Prefix, Country, ShortPath, LongPath, km, Latitude, longitude, Continent and QTH.

You have completed the steps to run the Visual Basic code.


