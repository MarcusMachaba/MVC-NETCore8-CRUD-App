USE [master]
GO
/****** Object:  Database [MVC_CRUD_Interface_DB]    Script Date: 2024/10/09 04:47:53 ******/
CREATE DATABASE [MVC_CRUD_Interface_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVC_CRUD_Interface_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MVC_CRUD_Interface_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MVC_CRUD_Interface_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MVC_CRUD_Interface_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVC_CRUD_Interface_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET  MULTI_USER 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MVC_CRUD_Interface_DB', N'ON'
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET QUERY_STORE = OFF
GO
USE [MVC_CRUD_Interface_DB]
GO
/****** Object:  Schema [CustomIdentity]    Script Date: 2024/10/09 04:47:54 ******/
CREATE SCHEMA [CustomIdentity]
GO
/****** Object:  Table [CustomIdentity].[Clients]    Script Date: 2024/10/09 04:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[Clients](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Platform] [nvarchar](max) NOT NULL,
	[Region] [nvarchar](max) NOT NULL,
	[Package] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[LastUpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[RoleClaims]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[Roles]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[UserClaims]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[UserLogins]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[UserRoles]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[Users]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Age] [int] NULL,
	[Sex] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [CustomIdentity].[UserTokens]    Script Date: 2024/10/09 04:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CustomIdentity].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/10/09 04:47:55 ******/
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
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'1ad46c83-3eaa-4391-8476-f66344ba4b4e', N'Castrol', N'Windows 7', N'Limpopo', N'Basic', 0, CAST(N'2024-10-09T03:59:36.4086541' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'1bfcb0ba-11a0-4944-b788-7bbda26d83cf', N'Volkswagen', N'Windows 11', N'Free State', N'Basic', 1, CAST(N'2024-10-09T03:59:36.4086534' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'223baeb4-c9e3-4201-9592-56edd1423617', N'Caltex', N'Windows 7', N'Mpumalanga', N'Basic', 1, CAST(N'2024-10-09T03:59:36.4086038' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'2cbf3ac9-e2a7-4b7f-962d-b9fe05bbdf2a', N'LiquidMolly', N'Windows 10', N'Gauteng', N'Standard', 1, CAST(N'2024-10-09T03:59:36.4003747' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'3090f268-29e0-45a8-91d7-c66861b28b78', N'Mitsubishi', N'Windows 11', N'Free State', N'Basic', 1, CAST(N'2024-10-09T03:59:36.4086515' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'7f9cb026-82bd-45f1-9b74-57853fbf3c2e', N'LUK', N'Windows 8.1', N'KZN', N'Basic', 0, CAST(N'2024-10-09T03:59:36.4086424' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'806f7c6e-59c0-40ce-8ea5-dfecb04653ff', N'Goldwagen', N'Windows 10', N'Limpopo', N'Enterprise', 0, CAST(N'2024-10-09T03:59:36.4086437' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'86e2dda6-b742-4774-a8b4-f877ee5abfbc', N'Nissan', N'Windows 11', N'KZN', N'Enterprise', 1, CAST(N'2024-10-09T03:59:36.4086547' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'98859cf3-55de-40c4-bfe6-2c39eae38f87', N'M. Marcus', N'Windows 8.1', N'Gauteng', N'Standard', 1, CAST(N'2024-10-09T04:16:05.3394159' AS DateTime2), CAST(N'2024-10-09T04:16:05.3395428' AS DateTime2))
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'b0c3171b-d202-43ea-a158-35351cdd09d6', N'Ford', N'Windows 72', N'Eastern Cape', N'Basic', 1, CAST(N'2024-10-09T04:15:04.9733208' AS DateTime2), CAST(N'2024-10-09T04:15:04.9737460' AS DateTime2))
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'b9aaad0b-faac-4972-a102-dc3bb89c94a2', N'Suzuki', N'Windows 10', N'Northern Cape', N'Enterprise', 0, CAST(N'2024-10-09T03:59:36.4086527' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'bc0eeffb-f4b6-4fbe-a187-bd5981c88e2e', N'Westvaal', N'Windows 7', N'Cape Town', N'Basic', 1, CAST(N'2024-10-09T03:59:36.4086468' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'c7009de8-6c83-4f55-9011-ab8af0b8e960', N'Shell', N'Windows 11', N'Gauteng', N'Enterprise', 1, CAST(N'2024-10-09T03:59:36.4086173' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'd6a42ccc-9a6a-420a-917e-39d668804064', N'Hyundai', N'Windows 10', N'Western Cape', N'Basic', 0, CAST(N'2024-10-09T03:59:36.4086502' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'da5c9894-a68e-4092-80ce-b9e35be7cc59', N'BMW', N'Windows 10', N'Eastern Cape', N'Enterprise', 1, CAST(N'2024-10-09T03:59:36.4086479' AS DateTime2), NULL)
INSERT [CustomIdentity].[Clients] ([Id], [Name], [Platform], [Region], [Package], [Active], [CreatedDate], [LastUpdateDate]) VALUES (N'fcf3a54e-15fa-4355-91e1-5743e6a52e93', N'Toyota', N'Windows 17', N'North West', N'Standard', 0, CAST(N'2024-10-09T03:59:36.4086490' AS DateTime2), NULL)
GO
INSERT [CustomIdentity].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'05f3654e-0bef-4179-8d41-49785ef6e197', N'Admin', N'ADMIN', NULL)
INSERT [CustomIdentity].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'73b6d570-1c85-478c-9ffc-b270c2007526', N'Basic', N'BASIC', NULL)
INSERT [CustomIdentity].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9de724e7-3852-4bab-8cb6-e21d6762a6a7', N'SuperAdmin', N'SUPERADMIN', NULL)
INSERT [CustomIdentity].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd6f3b9ed-5afb-423d-b494-4023afb4b8a7', N'Moderator', N'MODERATOR', NULL)
GO
INSERT [CustomIdentity].[UserRoles] ([UserId], [RoleId]) VALUES (N'5d79f3a4-c8dd-421f-ae86-504c45f8c96c', N'05f3654e-0bef-4179-8d41-49785ef6e197')
INSERT [CustomIdentity].[UserRoles] ([UserId], [RoleId]) VALUES (N'bbadc077-1f3d-480d-a764-bf846a3f9eda', N'05f3654e-0bef-4179-8d41-49785ef6e197')
INSERT [CustomIdentity].[UserRoles] ([UserId], [RoleId]) VALUES (N'3f3ae41d-667a-4ec9-a0a7-34473ef0c23c', N'73b6d570-1c85-478c-9ffc-b270c2007526')
INSERT [CustomIdentity].[UserRoles] ([UserId], [RoleId]) VALUES (N'5d79f3a4-c8dd-421f-ae86-504c45f8c96c', N'73b6d570-1c85-478c-9ffc-b270c2007526')
INSERT [CustomIdentity].[UserRoles] ([UserId], [RoleId]) VALUES (N'5d79f3a4-c8dd-421f-ae86-504c45f8c96c', N'9de724e7-3852-4bab-8cb6-e21d6762a6a7')
GO
INSERT [CustomIdentity].[Users] ([Id], [FirstName], [Surname], [Age], [Sex], [Mobile], [Active], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3f3ae41d-667a-4ec9-a0a7-34473ef0c23c', N'Basic', N'basicsurname', NULL, NULL, NULL, 0, NULL, N'basic@gmail.com', N'BASIC@GMAIL.COM', N'basic@gmail.com', N'BASIC@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEMbbfJh5+yujSxxcNotYVYIicgRsaWzBQ4/YIybVX8pPdUpc2kInQeBYrF9XsgZqcw==', N'BEFX2K52Z6WZ3Y4G6W3RG35TI3MM2RPN', N'538dfca7-88cd-4450-a4bb-4be93b5321fe', NULL, 1, 0, NULL, 1, 0)
INSERT [CustomIdentity].[Users] ([Id], [FirstName], [Surname], [Age], [Sex], [Mobile], [Active], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5d79f3a4-c8dd-421f-ae86-504c45f8c96c', N'SuperAdmin', N'superadminsurname', NULL, NULL, NULL, 0, NULL, N'superadmin@gmail.com', N'SUPERADMIN@GMAIL.COM', N'superadmin@gmail.com', N'SUPERADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEJk9ArFWbfvotZOLWhANasy/P8zfc0c2YVhnkbsYCiE99h2m/Bw9f6EQM9ylfZujeQ==', N'2GQAKYYYASW5KXMUNUXXUIF66P6JW4NP', N'23c32540-645d-4adc-8b7b-c372edb12795', NULL, 1, 0, NULL, 1, 0)
INSERT [CustomIdentity].[Users] ([Id], [FirstName], [Surname], [Age], [Sex], [Mobile], [Active], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bbadc077-1f3d-480d-a764-bf846a3f9eda', N'Admin', N'adminsurname', NULL, NULL, NULL, 0, NULL, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEOXrivNimEsIq9mD/3zSGp3ndQUdwI9Nr0/mm/WsE445wJ8D+d/R992xOF95TmWXiw==', N'7FXDAYPIBXXXVFT5ED3I7ZDEOYR2HBEM', N'40f7c96d-4761-4a78-bd6a-3c595188bb22', NULL, 1, 0, NULL, 1, 0)
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002031651_init_migration', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241002032239_nullify_mobile_col', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007051118_add_clients', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241007072101_add_active_col', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241008182223_add_dates_cols', N'8.0.8')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 2024/10/09 04:47:55 ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [CustomIdentity].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2024/10/09 04:47:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [CustomIdentity].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 2024/10/09 04:47:55 ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [CustomIdentity].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 2024/10/09 04:47:55 ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [CustomIdentity].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 2024/10/09 04:47:55 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [CustomIdentity].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2024/10/09 04:47:55 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [CustomIdentity].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2024/10/09 04:47:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [CustomIdentity].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [CustomIdentity].[Clients] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Active]
GO
ALTER TABLE [CustomIdentity].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [CustomIdentity].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [CustomIdentity].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [CustomIdentity].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [CustomIdentity].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [CustomIdentity].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [CustomIdentity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [CustomIdentity].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [CustomIdentity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [CustomIdentity].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [CustomIdentity].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [CustomIdentity].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [CustomIdentity].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [MVC_CRUD_Interface_DB] SET  READ_WRITE 
GO
