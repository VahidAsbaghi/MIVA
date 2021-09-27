USE [master]
GO
/****** Object:  Database [UserDb]    Script Date: 9/25/2021 3:57:29 PM ******/
CREATE DATABASE [UserDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UserDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UserDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UserDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UserDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserDb] SET RECOVERY FULL 
GO
ALTER DATABASE [UserDb] SET  MULTI_USER 
GO
ALTER DATABASE [UserDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UserDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UserDb]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 9/25/2021 3:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [UserDb] SET  READ_WRITE 
GO
