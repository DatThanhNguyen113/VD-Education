USE [master]
GO
/****** Object:  Database [VDEducation]    Script Date: 5/15/2019 3:24:37 PM ******/
CREATE DATABASE [VDEducation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VDEducation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VDEducation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VDEducation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VDEducation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VDEducation] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VDEducation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VDEducation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VDEducation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VDEducation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VDEducation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VDEducation] SET ARITHABORT OFF 
GO
ALTER DATABASE [VDEducation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VDEducation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VDEducation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VDEducation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VDEducation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VDEducation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VDEducation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VDEducation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VDEducation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VDEducation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VDEducation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VDEducation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VDEducation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VDEducation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VDEducation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VDEducation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VDEducation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VDEducation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VDEducation] SET  MULTI_USER 
GO
ALTER DATABASE [VDEducation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VDEducation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VDEducation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VDEducation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VDEducation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VDEducation] SET QUERY_STORE = OFF
GO
USE [VDEducation]
GO
/****** Object:  Schema [app]    Script Date: 5/15/2019 3:24:38 PM ******/
CREATE SCHEMA [app]
GO
/****** Object:  Schema [core]    Script Date: 5/15/2019 3:24:38 PM ******/
CREATE SCHEMA [core]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/15/2019 3:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SignIn]    Script Date: 5/15/2019 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SignIn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[Role] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[RegistedID] [varchar](13) NULL,
 CONSTRAINT [PK_SignIn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingSystem]    Script Date: 5/15/2019 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingSystem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_TrainingSystem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 5/15/2019 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[SchoolYearID] [int] NULL,
	[CareerID] [int] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/15/2019 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [varchar](10) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[BirthDate] [datetime] NULL,
	[Gender] [int] NULL,
	[ClassID] [int] NULL,
	[Country] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[PhoneNumber] [varchar](13) NULL,
	[TrainingSystemID] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolYear]    Script Date: 5/15/2019 3:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolYear](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartYear] [int] NULL,
	[EndYear] [int] NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_SchoolYear] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Studen_Get]    Script Date: 5/15/2019 3:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Studen_Get]
AS
SELECT        A.ID, A.FirstName, A.LastName, A.Email, A.BirthDate, A.Gender, A.Country, A.Address, A.PhoneNumber, A.TrainingSystemID, C.Name AS Role, D.Name AS ClassName, dbo.SchoolYear.Name AS SchoolYearName, 
                         dbo.SchoolYear.StartYear, dbo.SchoolYear.EndYear, dbo.SchoolYear.ID AS SchoolYearID, D.ID AS ClassID, dbo.TrainingSystem.Name AS TrainingSystemName, D.Code AS ClassCode, C.ID AS RoleID
FROM            dbo.Student AS A INNER JOIN
                         dbo.SignIn AS B ON A.ID = B.RegistedID INNER JOIN
                         dbo.Role AS C ON B.Role = C.ID INNER JOIN
                         dbo.Class AS D ON B.ID = D.ID INNER JOIN
                         dbo.SchoolYear ON D.SchoolYearID = dbo.SchoolYear.ID INNER JOIN
                         dbo.TrainingSystem ON A.TrainingSystemID = dbo.TrainingSystem.ID
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/15/2019 3:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [varchar](13) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[Email] [varchar](100) NULL,
	[BirthDate] [datetime] NULL,
	[WorkUnit] [nvarchar](150) NULL,
	[Graduating] [nvarchar](200) NULL,
	[Diploma] [nvarchar](50) NULL,
	[BankAccountNumber] [varchar](20) NULL,
	[BankID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CareerID] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Teacher_Get]    Script Date: 5/15/2019 3:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Teacher_Get]
AS
SELECT        A.ID, A.FirstName + A.LastName AS Name, A.Gender, A.Email, A.BirthDate, A.WorkUnit, A.Graduating, A.Diploma, A.BankAccountNumber, A.BankID, A.Description, C.Name AS Role, C.ID AS RoleID
FROM            dbo.Teacher AS A INNER JOIN
                         dbo.SignIn AS B ON A.ID = B.RegistedID INNER JOIN
                         dbo.Role AS C ON B.Role = C.ID
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/15/2019 3:24:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Employee_Get]    Script Date: 5/15/2019 3:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Employee_Get]
AS
SELECT        A.ID, A.Name, A.Email, A.Position, A.Gender, A.Address, C.Name AS Role, C.ID AS RoleID
FROM            dbo.Employee AS A INNER JOIN
                         dbo.SignIn AS B ON A.ID = B.RegistedID INNER JOIN
                         dbo.Role AS C ON B.Role = C.ID
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 5/15/2019 3:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ID] [varchar](13) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PhoneNumber] [varchar](13) NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentRelation]    Script Date: 5/15/2019 3:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentRelation](
	[ID] [int] NOT NULL,
	[ParentID] [varchar](13) NULL,
	[StudentID] [varchar](10) NULL,
	[RelationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ParentRelation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Parent_Get]    Script Date: 5/15/2019 3:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Parent_Get]
AS
SELECT        A.ID, A.Name, A.Email, A.PhoneNumber, A.Address, C.Name AS Role, E.FirstName + E.LastName AS StudentName, F.Name AS ClassName, C.ID AS RoleID
FROM            dbo.Parent AS A INNER JOIN
                         dbo.SignIn AS B ON A.ID = B.RegistedID INNER JOIN
                         dbo.Role AS C ON B.Role = C.ID INNER JOIN
                         dbo.ParentRelation AS D ON A.ID = D.ParentID INNER JOIN
                         dbo.Student AS E ON E.ID = D.StudentID INNER JOIN
                         dbo.Class AS F ON E.ClassID = F.ID
GO
/****** Object:  Table [dbo].[RegistedSubjectStatus]    Script Date: 5/15/2019 3:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistedSubjectStatus](
	[ID] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_RegistedSubjectStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectRegister]    Script Date: 5/15/2019 3:24:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectRegister](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [varchar](13) NULL,
	[StartLearnDay] [datetime] NULL,
	[EndLearnDay] [datetime] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[ExpectedStudentNumber] [int] NULL,
	[CurrentStudentNumber] [int] NULL,
	[SubjectID] [int] NULL,
	[SchoolYearID] [int] NULL,
 CONSTRAINT [PK_SubjectRegister] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistedSubject]    Script Date: 5/15/2019 3:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistedSubject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectRegisterID] [int] NULL,
	[StudentID] [varchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_RegistedSubject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/15/2019 3:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[ClassID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[TotalCredits] [int] NULL,
	[PracticeCredit] [int] NULL,
	[TheoryCredit] [int] NULL,
	[LessionNumber] [int] NULL,
	[FinalEvaluationPercent] [int] NULL,
	[SemiFinalEvaluationPercent] [int] NULL,
	[DiligencePercent] [int] NULL,
	[SubjectTypeID] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[RegistedSubject_Get]    Script Date: 5/15/2019 3:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RegistedSubject_Get]
AS
SELECT        A.CreatedDate, C.Description AS Status, D.FirstName + ' ' + D.LastName AS TeacherName, B.StartLearnDay, B.EndLearnDay, B.Status AS RegisterStatus, E.Name AS SubjectName, E.TotalCredits, E.TheoryCredit, 
                         E.PracticeCredit, E.LessionNumber, A.StudentID
FROM            dbo.RegistedSubject AS A INNER JOIN
                         dbo.SubjectRegister AS B ON A.SubjectRegisterID = B.ID INNER JOIN
                         dbo.RegistedSubjectStatus AS C ON A.Status = C.ID INNER JOIN
                         dbo.Teacher AS D ON B.TeacherID = D.ID INNER JOIN
                         dbo.Subject AS E ON B.SubjectID = E.ID
WHERE        (A.Status > 0)
GO
/****** Object:  Table [core].[Sys_View]    Script Date: 5/15/2019 3:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [core].[Sys_View](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Title] [nvarchar](max) NULL,
	[ContextFunction] [nvarchar](250) NULL,
	[ActionFunction] [nvarchar](250) NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_View] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 5/15/2019 3:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](10) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Career]    Script Date: 5/15/2019 3:24:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Career](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Career] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muster]    Script Date: 5/15/2019 3:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegistedSubjectID] [int] NULL,
	[TimeTableID] [int] NULL,
	[JoinStatus] [int] NULL,
 CONSTRAINT [PK_Muster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectType]    Script Date: 5/15/2019 3:24:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Code] [nvarchar](20) NULL,
 CONSTRAINT [PK_SubjectType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Log]    Script Date: 5/15/2019 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Logs] [nvarchar](max) NULL,
	[CreatedTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 5/15/2019 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectRegisterID] [int] NULL,
	[Date] [datetime] NULL,
	[LessonNumber] [varchar](15) NULL,
	[Day] [nvarchar](50) NULL,
	[Room] [varchar](50) NULL,
	[WeekNumber] [int] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Session] [nvarchar](50) NULL,
	[Title] [nvarchar](150) NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [core].[Sys_View] ON 

INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1, N'app.usp_Login_Check', N'app.usp_Login_Check', N'app.usp_Login_Check', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (2, N'User', N'User', N'[app].[usp_User_Get]', N'app.usp_User_Action', NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (3, N'usp_RegistedSubject_Action', N'usp_RegistedSubject_Action', N'app.usp_RegistedSubject_Get', N'app.usp_RegistedSubject_Action', NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (4, N'usp_SubjectRegister_Action', N'usp_SubjectRegister_Action', N'app.usp_SubjectRegister_Get', N'app.usp_SubjectRegister_Action', NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1003, N'app.usp_Class_Get', N'app.usp_Class_Get', N'app.usp_Class_Get', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1004, N'app.usp_Career_Get', N'app.usp_Career_Get', N'app.usp_Career_Get', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1005, N'app.usp_SchoolYear_Get', N'app.usp_SchoolYear_Get', N'app.usp_SchoolYear_Get', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1006, N'app.usp_Subject_Get', N'app.usp_Subject_Get', N'app.usp_Subject_Get', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1007, N'app.usp_Teacher_Get', N'app.usp_Teacher_Get', N'app.usp_Teacher_Get', NULL, NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1008, N'[app].[usp_SubjectRegister_Status]', N'[app].[usp_SubjectRegister_Status]', NULL, N'[app].[usp_SubjectRegister_Status]', NULL)
INSERT [core].[Sys_View] ([ID], [Name], [Title], [ContextFunction], [ActionFunction], [CreatedTime]) VALUES (1009, N'app.usp_TimeTable_Action', N'app.usp_TimeTable_Action', N'app.usp_TimeTable_Get', N'app.usp_TimeTable_Action', NULL)
SET IDENTITY_INSERT [core].[Sys_View] OFF
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([ID], [Name], [Code]) VALUES (1, N'TECHCOMBANK', N'TCB')
INSERT [dbo].[Bank] ([ID], [Name], [Code]) VALUES (2, N'VIETCOMBANK', N'VDB')
INSERT [dbo].[Bank] ([ID], [Name], [Code]) VALUES (3, N'SACCOMBANK', N'SCB')
SET IDENTITY_INSERT [dbo].[Bank] OFF
SET IDENTITY_INSERT [dbo].[Career] ON 

INSERT [dbo].[Career] ([ID], [Name]) VALUES (1, N'CƠ KHÍ')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (2, N'LẬP TRÌNH')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (3, N'NHÀ HÀNG KHÁCH SẠN')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (4, N'DU LỊCH')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (5, N'Y TẾ')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (6, N'KINH DOANH')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (7, N'Ô TÔ')
INSERT [dbo].[Career] ([ID], [Name]) VALUES (8, N'ĐIỆN-ĐIỆN TỬ')
SET IDENTITY_INSERT [dbo].[Career] OFF
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (1, N'10CKC', N'CÔNG NGHỆ KỸ THUẬT CƠ KHÍ
', 1, 1)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (2, N'10THC', N'TIN HỌC ỨNG DỤNG', 1, 2)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (3, N'10OT1C', N'CÔNG NGHỆ KỸ THUẬT Ô TÔ
', 1, 7)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (4, N'10OTC2C', N'CÔNG NGHỆ KỸ THUẬT Ô TÔ
', 1, 7)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (5, N'10OT3C', N'CÔNG NGHỆ KỸ THUẬT Ô TÔ
', 1, 7)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (6, N'10KS2C', N'QUẢN TRỊ KHÁCH SẠN
', 1, 3)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (7, N'10DTC', N'CÔNG NGHỆ KỸ THUẬT ĐIỆN - ĐIỆN TỬ
', 1, 8)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (8, N'10QTMAC', N'QUẢN TRỊ KINH DOANH
', 1, 6)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (9, N'10KTC', N'KẾ TOÁN
', 1, 6)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (10, N'10QTTHC', N'QUẢN TRỊ KINH DOANH
', 1, 6)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (11, N'10TH1C', N'TIN HỌC ỨNG DỤNG', 1, 2)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (12, N'10TH2C', N'TIN HỌC ỨNG DỤNG', 1, 2)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (13, N'10MMC', N'TRUYỀN THÔNG & MẠNG MÁY TÍNH
', 1, 2)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (14, N'10DHC', N'THIẾT KẾ ĐỒ HỌA', 1, 2)
INSERT [dbo].[Class] ([ID], [Code], [Name], [SchoolYearID], [CareerID]) VALUES (15, N'10TCC', N'TÀI CHÍNH NGÂN HÀNG
', 1, 6)
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[Muster] ON 

INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (1, 3, 66, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (2, 3, 67, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (3, 3, 68, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (4, 3, 69, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (5, 3, 70, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (6, 3, 71, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (7, 3, 72, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (8, 3, 73, 0)
INSERT [dbo].[Muster] ([ID], [RegistedSubjectID], [TimeTableID], [JoinStatus]) VALUES (9, 3, 74, 0)
SET IDENTITY_INSERT [dbo].[Muster] OFF
SET IDENTITY_INSERT [dbo].[RegistedSubject] ON 

INSERT [dbo].[RegistedSubject] ([ID], [SubjectRegisterID], [StudentID], [CreatedDate], [Status]) VALUES (3, 8, N'1606020012', CAST(N'2019-05-08T01:34:21.407' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RegistedSubject] OFF
