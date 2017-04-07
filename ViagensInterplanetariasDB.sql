USE [master]
GO
/****** Object:  Database [ViagensInterplanetarias]    Script Date: 2017-04-06 10:07:03 PM ******/
CREATE DATABASE [ViagensInterplanetarias]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ViagensInterplanetarias', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ViagensInterplanetarias.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ViagensInterplanetarias_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ViagensInterplanetarias_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ViagensInterplanetarias] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ViagensInterplanetarias].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ViagensInterplanetarias] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET ARITHABORT OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ViagensInterplanetarias] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ViagensInterplanetarias] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ViagensInterplanetarias] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ViagensInterplanetarias] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ViagensInterplanetarias] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ViagensInterplanetarias] SET  MULTI_USER 
GO
ALTER DATABASE [ViagensInterplanetarias] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ViagensInterplanetarias] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ViagensInterplanetarias] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ViagensInterplanetarias] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ViagensInterplanetarias] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ViagensInterplanetarias]
GO
/****** Object:  Table [dbo].[Especies]    Script Date: 2017-04-06 10:07:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[Documento] [varchar](200) NULL,
	[Cor] [varchar](100) NULL,
	[QtdBracos] [int] NULL,
	[QtdPernas] [int] NULL,
	[QtdCabeca] [int] NULL,
	[Respira] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planetas]    Script Date: 2017-04-06 10:07:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planetas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[Descricao] [varchar](500) NULL,
	[PossuiOxigenio] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transportes]    Script Date: 2017-04-06 10:07:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[Terreno] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Viagens]    Script Date: 2017-04-06 10:07:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viagens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPlanetaOrigem] [int] NULL,
	[IdPlanetaDestino] [int] NULL,
	[IdCliente] [int] NULL,
	[Valor] [float] NULL,
	[Tempo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Planetas] ON 

INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (1, N'Terra', N'A Terra é o terceiro planeta mais próximo do Sol, o mais denso e o quinto maior dos oito planetas do Sistema Solar. É também o maior dos quatro planetas telúricos. É por vezes designada como Mundo ou Planeta Azul. Lar de milhões de espécies de seres vivos, incluindo os humanos.', 1)
SET IDENTITY_INSERT [dbo].[Planetas] OFF
USE [master]
GO
ALTER DATABASE [ViagensInterplanetarias] SET  READ_WRITE 
GO
