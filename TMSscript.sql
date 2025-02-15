USE [master]
GO
/****** Object:  Database [TaskMgmtSystem]    Script Date: 2/6/2025 11:02:25 PM ******/
CREATE DATABASE [TaskMgmtSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskMgmtSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TaskMgmtSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskMgmtSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TaskMgmtSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TaskMgmtSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskMgmtSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskMgmtSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskMgmtSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskMgmtSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskMgmtSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskMgmtSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskMgmtSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TaskMgmtSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskMgmtSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskMgmtSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskMgmtSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskMgmtSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskMgmtSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaskMgmtSystem', N'ON'
GO
ALTER DATABASE [TaskMgmtSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [TaskMgmtSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TaskMgmtSystem]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (2, N'Test2', N'Test2Description', N'Pending', CAST(N'1905-06-30T00:00:00.000' AS DateTime), CAST(N'1905-06-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (3, N'Test3', N'Test3Description', N'Completed', CAST(N'1905-06-29T00:00:00.000' AS DateTime), CAST(N'1905-06-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (4, N'Test4', N'Test4Description', N'In Progress', CAST(N'1905-07-01T00:00:00.000' AS DateTime), CAST(N'1905-06-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (5, N'Test5', N'Test5Description', N'Pending', CAST(N'1905-06-28T00:00:00.000' AS DateTime), CAST(N'1905-06-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (2001, N'Task6', N'Task6Description', N'Pending', CAST(N'2025-02-06T17:00:17.907' AS DateTime), CAST(N'2025-02-13T17:00:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (2002, N'Task7', N'Task7Description', N'Pending', CAST(N'2025-02-06T22:31:56.913' AS DateTime), CAST(N'2025-02-18T22:31:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (2003, N'Task8', N'Task8Description', N'In Progress', CAST(N'2025-02-06T22:33:52.187' AS DateTime), CAST(N'2025-02-06T22:33:00.000' AS DateTime))
INSERT [dbo].[Tasks] ([Id], [Title], [Description], [Status], [CreatedAt], [DueDate]) VALUES (2004, N'task9', N'task9descp', N'Pending', CAST(N'2025-02-06T22:40:11.040' AS DateTime), CAST(N'2025-02-21T22:40:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash]) VALUES (1, N'admin', N'admin@gmail.com', N'$2a$11$9NZ.B10GYIYCaq1niEPEX.0rA8i31Vg3/c9VPwZG6RXypYhBnP6JG')
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash]) VALUES (2, N'asbin', N'asbin@gmail.com', N'$2a$11$FRW.1OmAuCPIztBG/o4Rp.RIGduukl0LWc47LG7sapEb5wRxrWftq')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Roles_Name]    Script Date: 2/6/2025 11:02:25 PM ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [UQ_Roles_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 2/6/2025 11:02:25 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Username]    Script Date: 2/6/2025 11:02:25 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD CHECK  (([Status]='Completed' OR [Status]='In Progress' OR [Status]='Pending'))
GO
/****** Object:  StoredProcedure [dbo].[spAddRole]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddRole]
@Name NVARCHAR(256)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Roles WHERE Name = @Name)
	BEGIN
	INSERT INTO Roles (Name) VALUES (@Name);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[spAddTasks]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddTasks]
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @Status NVARCHAR(50),
    @CreatedAt DATETIME,
    @DueDate DATETIME
AS
BEGIN
    -- Insert the new task into the Tasks table
    INSERT INTO Tasks (Title, [Description], [Status], CreatedAt, DueDate)
    VALUES (@Title, @Description, @Status, @CreatedAt, @DueDate);
    
    -- return the ID of the newly inserted task
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewTaskID;
END
GO
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddUser]
@Username NVARCHAR(256),
@Email NVARCHAR(256),
@PasswordHash NVARCHAR(MAX),
@RoleName NVARCHAR(256)
AS
BEGIN
	DECLARE @UserId INT;
	DECLARE @RoleId INT;
	IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
		BEGIN
			INSERT INTO Users(Username, Email, PasswordHash)
			VALUES (@Username, @Email, @PasswordHash);

			SET @UserId = SCOPE_IDENTITY();
		END
	ELSE
		BEGIN
			SET @UserId = (SELECT Id FROM Users WHERE Username = @Username);
		END
			SET @RoleId = (SELECT Id FROM Roles WHERE Name = @RoleName);
	
	IF NOT EXISTS (SELECT 1 FROM UserRoles WHERE UserId = @UserId AND RoleId = @RoleId)
		BEGIN
			INSERT INTO UserRoles (UserId,RoleId) VALUES (@UserId, @RoleId);
		END
END
GO
/****** Object:  StoredProcedure [dbo].[spAuthenticateUser]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAuthenticateUser]
@Username NVARCHAR(256)
AS
BEGIN
	SELECT
	Id, Username, Email, PasswordHash FROM Users WHERE Username = @Username OR Email = @Username;
END

GO
/****** Object:  StoredProcedure [dbo].[spDeleteTasks]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spDeleteTasks]
    @Id INT
AS
BEGIN
--Check if task is in completed to delete task
IF EXISTS(SELECT 1 FROM Tasks WHERE Id = @Id AND Status ='Completed')
	DELETE FROM TASKS WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllTasksWithStatus]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[spGetAllTasksWithStatus]
as
begin
select * from Tasks
end
GO
/****** Object:  StoredProcedure [dbo].[spGetTasksById]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetTasksById]
@Id INT
AS 
BEGIN
SELECT * FROM Tasks WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUserRoles]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetUserRoles]
@UserId INT
AS
BEGIN
	SELECT r.Name
	from Roles r
	INNER JOIN UserRoles ur ON r.Id = ur.RoleId
	WHERE ur.UserId = @UserId
END

--exec spGetUserRoles @UserId=2;
GO
/****** Object:  StoredProcedure [dbo].[spUpdateTasks]    Script Date: 2/6/2025 11:02:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateTasks]
@Id INT,
@Title NVARCHAR(255),
@Description NVARCHAR(MAX),
@Status NVARCHAR(50),
@CreatedAt DATETIME,
@DueDate DATETIME
AS
BEGIN
	UPDATE Tasks
	SET Title = @Title,
		[Description] = @Description,
		[Status] = @Status,
		CreatedAt = @CreatedAt,
		DueDate = @DueDate
	WHERE Id = @Id 
END
GO
USE [master]
GO
ALTER DATABASE [TaskMgmtSystem] SET  READ_WRITE 
GO
