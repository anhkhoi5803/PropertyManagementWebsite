USE [master]
GO
/****** Object:  Database [PropertyManagementDB]    Script Date: 2023-12-04 6:03:01 PM ******/
CREATE DATABASE [PropertyManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PropertyManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS2022\MSSQL\DATA\PropertyManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PropertyManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS2022\MSSQL\DATA\PropertyManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PropertyManagementDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PropertyManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PropertyManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PropertyManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PropertyManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PropertyManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PropertyManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PropertyManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [PropertyManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PropertyManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PropertyManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PropertyManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PropertyManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PropertyManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PropertyManagementDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [PropertyManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PropertyManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appartments]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appartments](
	[AppartmentId] [int] IDENTITY(1,1) NOT NULL,
	[BuildingId] [int] NOT NULL,
	[Available] [bit] NOT NULL,
	[NumOfBedrooms] [int] NOT NULL,
	[NumOfBathRooms] [int] NOT NULL,
	[Size] [nvarchar](10) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Appartments] PRIMARY KEY CLUSTERED 
(
	[AppartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[PotentialTenantId] [int] NOT NULL,
	[PropertyManagerId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[PropertyOwnerId] [int] NOT NULL,
	[PropertyManagerId] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[BuildingName] [nvarchar](50) NOT NULL,
	[HasLaundry] [bit] NOT NULL,
	[HasParking] [bit] NOT NULL,
	[IncludeUtils] [bit] NOT NULL,
	[CloseToTransit] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[ReceiverId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023-12-04 6:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appartments] ON 

INSERT [dbo].[Appartments] ([AppartmentId], [BuildingId], [Available], [NumOfBedrooms], [NumOfBathRooms], [Size], [Price]) VALUES (1, 1, 0, 2, 1, N'4 1/2', 1400)
INSERT [dbo].[Appartments] ([AppartmentId], [BuildingId], [Available], [NumOfBedrooms], [NumOfBathRooms], [Size], [Price]) VALUES (2, 1, 0, 1, 1, N'3 1/2', 1200)
INSERT [dbo].[Appartments] ([AppartmentId], [BuildingId], [Available], [NumOfBedrooms], [NumOfBathRooms], [Size], [Price]) VALUES (3, 1, 1, 0, 1, N'2 1/2', 900)
INSERT [dbo].[Appartments] ([AppartmentId], [BuildingId], [Available], [NumOfBedrooms], [NumOfBathRooms], [Size], [Price]) VALUES (4, 1, 1, 12, 23, N'41 2/3', 4000)
INSERT [dbo].[Appartments] ([AppartmentId], [BuildingId], [Available], [NumOfBedrooms], [NumOfBathRooms], [Size], [Price]) VALUES (1005, 1, 1, 1, 1, N'3 1/2', 1200)
SET IDENTITY_INSERT [dbo].[Appartments] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (1, 5, 3, CAST(N'2023-05-05T12:00:00.000' AS DateTime), N'consulting')
INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (2, 1, 2, CAST(N'2021-05-12T15:00:00.000' AS DateTime), N'visit')
INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (3, 10, 3, CAST(N'2023-12-12T19:00:00.000' AS DateTime), N'Vist')
INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (1003, 1007, 8, CAST(N'2023-12-24T19:00:00.000' AS DateTime), N'Visit')
INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (1004, 1008, 8, CAST(N'2023-12-12T19:00:00.000' AS DateTime), N'Visit')
INSERT [dbo].[Appointments] ([AppointmentId], [PotentialTenantId], [PropertyManagerId], [DateTime], [Note]) VALUES (1005, 5, 3, CAST(N'2023-12-12T19:00:00.000' AS DateTime), N'Visit floor')
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Buildings] ON 

INSERT [dbo].[Buildings] ([BuildingId], [PropertyOwnerId], [PropertyManagerId], [Address], [City], [Province], [PostalCode], [BuildingName], [HasLaundry], [HasParking], [IncludeUtils], [CloseToTransit], [Description]) VALUES (1, 9, 8, N'123 DC', N'Montreal', N'QC', N'H2H3P1', N'BD1', 1, 1, 1, 1, N'Free 1 month rent ')
SET IDENTITY_INSERT [dbo].[Buildings] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (1, 5, 3, CAST(N'2023-08-12T19:00:00.000' AS DateTime), N'Hello I would like to see an appartment')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (2, 3, 5, CAST(N'2023-08-12T19:30:00.000' AS DateTime), N'Yes when would you like to visit')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (7, 5, 3, CAST(N'2023-11-30T14:39:39.443' AS DateTime), N'hello')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (8, 2, 9, CAST(N'2023-11-30T14:55:04.883' AS DateTime), N'admin txt')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (9, 9, 7, CAST(N'2023-11-30T14:55:57.483' AS DateTime), N'123')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (10, 10, 3, CAST(N'2023-11-30T16:22:49.900' AS DateTime), N'Hello')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (11, 5, 3, CAST(N'2023-11-30T16:29:08.173' AS DateTime), N'Hello 1')
INSERT [dbo].[Messages] ([MessageId], [SenderId], [ReceiverId], [DateTime], [Message]) VALUES (1008, 1008, 8, CAST(N'2023-12-04T17:37:57.873' AS DateTime), N'hello ')
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
INSERT [dbo].[Role] ([RoleName]) VALUES (N'Administrator')
INSERT [dbo].[Role] ([RoleName]) VALUES (N'PotentialTenant')
INSERT [dbo].[Role] ([RoleName]) VALUES (N'PropertyManager')
INSERT [dbo].[Role] ([RoleName]) VALUES (N'PropertyOwner')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (1, N'kn', N'1234', N'Khoi', N'Nguyen', CAST(N'2003-05-08' AS Date), N'akn@gmail.com', N'PropertyOwner')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (2, N'aa', N'1234', N'A', N'A', CAST(N'2000-02-12' AS Date), N'aa@gmail.com', N'Administrator')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (3, N'bb', N'1234', N'B', N'B', CAST(N'2023-03-03' AS Date), N'BB@gmail.com', N'PropertyManager')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (5, N'cc', N'1234', N'Ander', N'Was', CAST(N'2022-02-01' AS Date), N'c@gmail.com', N'PotentialTenant')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (6, N'a12', N'1234', N'HA', N'HA', CAST(N'2003-04-04' AS Date), N'haha@gmail.com', N'Administrator')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (7, N'a11', N'1234', N'he', N'he', CAST(N'2001-01-01' AS Date), N'hehe@gmail.com', N'PotentialTenant')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (8, N'a1', N'1234', N'AM', N'MA', CAST(N'2001-01-01' AS Date), N'amma@gmail.com', N'PropertyManager')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (9, N'a13', N'1234', N'Elon', N'Musk', CAST(N'2001-01-01' AS Date), N'elm@gmail.com', N'PropertyOwner')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (10, N'a123', N'a123', N'aaa', N'bbb', CAST(N'2001-01-01' AS Date), N'elm@gmail.com', N'PotentialTenant')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (1007, N'tenant', N'123', N'tenant', N'ten', CAST(N'1992-04-02' AS Date), N'tenant@gmail.com', N'PotentialTenant')
INSERT [dbo].[Users] ([UserId], [Username], [Password], [FirstName], [LastName], [DOB], [Email], [Role]) VALUES (1008, N'tenant1', N'123', N'tenant', N'ten', CAST(N'1992-04-02' AS Date), N'tenant@gmail.com', N'PotentialTenant')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Appartments]  WITH CHECK ADD  CONSTRAINT [FK_Appartments_BuildingId] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([BuildingId])
GO
ALTER TABLE [dbo].[Appartments] CHECK CONSTRAINT [FK_Appartments_BuildingId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_PotentialTenantId] FOREIGN KEY([PotentialTenantId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_PotentialTenantId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_PropertyManagerId] FOREIGN KEY([PropertyManagerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_PropertyManagerId]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_PropertyManagerId] FOREIGN KEY([PropertyManagerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_PropertyManagerId]
GO
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_Buildings_PropertyOwnerId] FOREIGN KEY([PropertyOwnerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_Buildings_PropertyOwnerId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_ReceiverId] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_ReceiverId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_SenderId] FOREIGN KEY([SenderId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_SenderId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([Role])
REFERENCES [dbo].[Role] ([RoleName])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
USE [master]
GO
ALTER DATABASE [PropertyManagementDB] SET  READ_WRITE 
GO
