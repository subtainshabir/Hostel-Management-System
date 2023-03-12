# Hostel-Management
Hostel Management System (DesktopApplication)

Hostel Management is an  desktop application developed using [.NET Framework](https://www.microsoft.com/net/download/dotnet-framework-runtime) with [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) as front-end language and [MS-SQL](https://www.microsoft.com/en-in/sql-server/) database. 

### Import Database:
- Open [Database](https://github.com/nikhilamin073/Hostel-Management/tree/master/Database) folder.
- Locate `HostelManagement.mdf` & `HostelManagement.ldf` in location ``C:......\MSSQL12.SQLEXPRESS\MSSQL\DATA``
- Open [SQL Management Studio Express](https://www.microsoft.com/en-in/download/details.aspx?id=8961) and log in to the server to which you want to attach the database. 
- In the 'Object Explorer' window, right-click on the 'Databases' folder and select 'Attach...' 
- Now inside 'Attach Databases' window, click 'Add...'
- Navigate to your `HostelManagement.mdf` file and then click 'OK'. 
- Click 'OK' once more to finish attaching the database and you are done. The database should be available for use.
- Open [App.config](https://github.com/nikhilamin073/Hostel-Management/blob/master/HostelManagement/App.config) file and edit _connectionString_ value as per your server configuration.

### Screenshots:

> - Login Window
<img src="/Screenshots/login_window.png" width="600" height="450" alt="Login Window Snap"/>


> - Welcome Window
<img src="/Screenshots/welcome_window.png" width="600" height="450" alt="Welcome Window Snap"/>


> - Room Window
<img src="/Screenshots/room_window.png" width="800" height="450" alt="Room Window Snap"/>


> - Student Window
<img src="/Screenshots/student_window.png" width="800" height="450" alt="Student Window Snap"/>


> - Mess Window
<img src="/Screenshots/mess_window.png" width="800" height="450" alt="Mess Window Snap"/>
