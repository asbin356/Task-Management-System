TaskManagementSystem with Dapper
SETUP INSTRUCTIONS:
1. with git bash clone the git repo from https://github.com/asbin356/Task-Management-System
2. create database with the sql Script given as attachment.

After Application run
Login: admin@gmail.com
Password: Admin@12345
1. when admin login get to access all nav bar tabs i.e Dashboard, Tasks Status, All Tasks and can Create new tasks, delete only completed tasks, update tasks

Employee
Login: asbin@gmail.com
Password: asbin
1. when asbin employee logins he gets to access Dashboard and Task Status only

Updated Code: 
1	SqlConnection with Dapper
2	Added TasksService with implementation using stored procedure
3	Implemented CRUD operation in TasksController
4	Scaffolding Views for TasksController
5	Adding dropdown for Status in View
6	Adding required libraries of jquery dataTable, bootstrap, toastersweetalert in Layout
7	HomePage Actionmethod and View
8	Implemented SearchFilter by Title and status and pagination
9	Implementing Report Generation in Dashboard as TaskStatus Report
10	Used Chart.js to show report percent and in pie chart
11	Implemented ExporttoPdf feature for TaskStatusReport
12	Implemented Serilog for Error Handling and logging
13	DataSeeder class to seed data into database and Registered DataSeeder in Program.cs
14	ViewModels for Accounts
15	Implemented Register and Login Service
16	Implemented Register and Login methods
17	Created _LoginPartial page
18	Registered Authentication Handlers in Program.cs
19	Get User Roles
20	Implemented Authorization filter
21	Session Configuration
22	Signout functions
23	Appied Bootswatch theme
24	Implemented Role Authorize
25	RoleAuthorize Admin
26	Debugging some changes

DEPENDENCIES:
Frameworks used: 
1 Microsoft.AspNetCore.App
2 Microsoft.AspNetCore

Nuget Packages Used:
1. BCrypt.Net-Next > to encrypt password
2. Dapper > application connects to database to manipulate SQL database 
3. Microsoft.Data.SqlClient > used to interact with database
4. microsoft.visualstudio.web.codegeneration.design\8.0.7\
5. Serilog
6. Serilog.AspNetCore
7. Serilog.Sinks.File > to save log in file

Static Files in wwwroot:
In CSS and JS file
1. bootstrap-icons.min.css > used to update icons
2. dataTables.dataTables.min.css,
dataTables.min.js > for using jquery data table to filter data, search data, show data in lists
3. flatty.css > used to update navigation bar in application _Layout.
4. chart.js > used to show data task status report in piechart  
5. html2canvas.min.js,
 jspdf.umd.min.js> to save report in images


KEY DESIGN DECISIONS:
1. Used repository pattern and 
2. Used Stored procedures to do CRUD operations through dapper.

