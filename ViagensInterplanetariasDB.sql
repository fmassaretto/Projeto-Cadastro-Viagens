USE [master]
GO
/****** Object:  Database [ViagensInterplanetarias]    Script Date: 2017-04-10 11:49:07 PM ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Especie] [varchar](100) NULL,
	[Documento] [varchar](200) NULL,
	[Cor] [varchar](100) NULL,
	[QtdBracos] [int] NULL,
	[QtdPernas] [int] NULL,
	[QtdCabeca] [int] NULL,
	[Respira] [bit] NOT NULL,
 CONSTRAINT [PK__Especies__3214EC07E8724FD8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planetas]    Script Date: 2017-04-10 11:49:07 PM ******/
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
/****** Object:  Table [dbo].[Transportes]    Script Date: 2017-04-10 11:49:07 PM ******/
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
/****** Object:  Table [dbo].[ViagensClientes]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViagensClientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdViagensDisp] [int] NOT NULL,
	[IdClientes] [int] NOT NULL,
 CONSTRAINT [PK__Viagens__3214EC079D452DBE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ViagensDisponiveis]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ViagensDisponiveis](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanetaOrigem] [varchar](200) NOT NULL,
	[PlanetaDestino] [varchar](200) NOT NULL,
	[Valor] [int] NOT NULL,
	[Tempo] [int] NOT NULL,
 CONSTRAINT [PK_ViagensDisponiveis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Nome], [Especie], [Documento], [Cor], [QtdBracos], [QtdPernas], [QtdCabeca], [Respira]) VALUES (1, N'João', N'Humano', N'12.345.123-0', N'Branca', 2, 2, 1, 1)
INSERT [dbo].[Clientes] ([Id], [Nome], [Especie], [Documento], [Cor], [QtdBracos], [QtdPernas], [QtdCabeca], [Respira]) VALUES (2, N'Et', N'Varginha', N'fayf65', N'Verde', 2, 2, 1, 0)
INSERT [dbo].[Clientes] ([Id], [Nome], [Especie], [Documento], [Cor], [QtdBracos], [QtdPernas], [QtdCabeca], [Respira]) VALUES (3, N'asda', N'asd', N'afa3', N'azul', 1, 2, 1, 0)
INSERT [dbo].[Clientes] ([Id], [Nome], [Especie], [Documento], [Cor], [QtdBracos], [QtdPernas], [QtdCabeca], [Respira]) VALUES (4, N'asdsd', N'asdasd', N'dasdasd', N'asdsd', 1, 2, 3, 1)
INSERT [dbo].[Clientes] ([Id], [Nome], [Especie], [Documento], [Cor], [QtdBracos], [QtdPernas], [QtdCabeca], [Respira]) VALUES (5, N'Malvo', N'Marciano', N'¨%$', N'Marrom', 3, 4, 2, 0)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Planetas] ON 

INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (1, N'Terra', N'A Terra é o terceiro planeta mais próximo do Sol, o mais denso e o quinto maior dos oito planetas do Sistema Solar. É também o maior dos quatro planetas telúricos. É por vezes designada como Mundo ou Planeta Azul. Lar de milhões de espécies de seres vivos, incluindo os humanos.', 1)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (2, N'Marte', N'adasdasdasd', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (3, N'Jupter', N'asdasd', 1)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (4, N'Venus', N'Hagsgagasgasgas', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (5, N'asdasd', N'asdasdasd', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (6, N'asdasds', N'asdasdasd', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (7, N'asdasda', N'asdasda', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (8, N'sdsdfsdf', N'asdasdas', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (9, N'Plutão', N'asdasdasd', 1)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (10, N'XYZ', N'sadasdsdfsdfsdfsdfsdfsdsdfsdfsdfsdf', 1)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (11, N'Guil', N'asdasdasdasdddddddddddddddddddddddddddddddd', 0)
INSERT [dbo].[Planetas] ([Id], [Nome], [Descricao], [PossuiOxigenio]) VALUES (13, N'Planeta TZ564', N'Maior Planeta da galaxia T32, possui condições de vida.', 1)
SET IDENTITY_INSERT [dbo].[Planetas] OFF
SET IDENTITY_INSERT [dbo].[ViagensDisponiveis] ON 

INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (2, N'Terra', N'Marte', 10000, 30)
INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (3, N'Terra', N'Lua', 900, 15)
INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (4, N'Terra', N'Jupter', 20000, 60)
INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (5, N'Marte', N'Terra', 10000, 30)
INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (6, N'Marte', N'Lua', 5000, 5)
INSERT [dbo].[ViagensDisponiveis] ([Id], [PlanetaOrigem], [PlanetaDestino], [Valor], [Tempo]) VALUES (7, N'Marte', N'Jupter', 7000, 10)
SET IDENTITY_INSERT [dbo].[ViagensDisponiveis] OFF
/****** Object:  StoredProcedure [dbo].[clientes_spi]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientes_spi] @Nome VARCHAR(200), 
	@Especie VARCHAR(100), 
	@Documento VARCHAR(100), 
	@Cor VARCHAR(100), 
	@QtdBracos INT, 
	@QtdPernas INT, 
	@QtdCabeca INT, 
	@Respira BIT
AS
BEGIN
	INSERT INTO Clientes VALUES(@Nome, @Especie, @Documento, @Cor, @QtdBracos, @QtdPernas, @QtdCabeca, @Respira)

	SELECT 'Cliente Inserido com Sucesso!' AS msgSucesso
END
GO
/****** Object:  StoredProcedure [dbo].[clientes_upd]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientes_upd] @id INT, 
	@Nome VARCHAR(200), 
	@Especie VARCHAR(100), 
	@Documento VARCHAR(100), 
	@Cor VARCHAR(100), 
	@QtdBracos INT, 
	@QtdPernas INT, 
	@QtdCabeca INT, 
	@Respira BIT
AS
BEGIN
	UPDATE Clientes 
	SET Nome = @Nome, Especie = @Especie, Documento = Documento, Cor = @Cor, 
	QtdBracos = @QtdBracos, QtdPernas = @QtdPernas, QtdCabeca =	@QtdCabeca, Respira = @Respira
	WHERE Id = @Id

	SELECT 'Campo(s) de Clientes Atualizado com Sucesso!' AS msgSucesso
END
GO
/****** Object:  StoredProcedure [dbo].[clientesPorNome_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[clientesPorNome_sps] @NOME VARCHAR(200)
AS
BEGIN
	SELECT Id, Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes WHERE Nome = @Nome
END
GO
/****** Object:  StoredProcedure [dbo].[ClientesTodos_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClientesTodos_sps]
AS
BEGIN
	SELECT Id, Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes
END
GO
/****** Object:  StoredProcedure [dbo].[planetas_del]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[planetas_del] @Id INT
AS
BEGIN
	DELETE FROM Planetas WHERE Id = @Id

	SELECT 'Planeta Excluido com Sucesso!' AS msgSucesso
END
GO
/****** Object:  StoredProcedure [dbo].[planetas_spi]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[planetas_spi] @Nome VARCHAR(50),
		@Descricao VARCHAR(500),
		@PossuiOxigenio BIT
AS
BEGIN
		INSERT INTO Planetas VALUES(@Nome, @Descricao, @PossuiOxigenio)

		SELECT 'Planeta Inserido com Sucesso' AS msgSucesso
END
GO
/****** Object:  StoredProcedure [dbo].[planetas_upd]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[planetas_upd] @id INT, 
	@Nome VARCHAR(200), 
	@Descricao VARCHAR(500), 
	@PossuiOxigenio BIT
AS
BEGIN
	UPDATE Planetas 
	SET Nome = @Nome, Descricao = @Descricao, PossuiOxigenio = @PossuiOxigenio
	WHERE Id = @Id

	SELECT 'Campo(s) de PLanetas Atualizado com Sucesso!' AS msgSucesso
END

GO
/****** Object:  StoredProcedure [dbo].[planetasPorNome_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[planetasPorNome_sps] @NOME VARCHAR(200)
AS
BEGIN
	SELECT Id, Nome, Descricao, PossuiOxigenio FROM Planetas WHERE Nome = @Nome
END
GO
/****** Object:  StoredProcedure [dbo].[planetasTodos_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[planetasTodos_sps]
AS
BEGIN
	SELECT Id, Nome, Descricao, PossuiOxigenio FROM Planetas
END
GO
/****** Object:  StoredProcedure [dbo].[viagensDispPorNome_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[viagensDispPorNome_sps] @Nome VARCHAR(200)
AS
BEGIN
	SELECT Id, PlanetaOrigem, PlanetaDestino, Valor, Tempo FROM ViagensDisponiveis 
		WHERE PlanetaOrigem = @Nome OR PlanetaDestino = @Nome
END
GO
/****** Object:  StoredProcedure [dbo].[viagensDispTodos_sps]    Script Date: 2017-04-10 11:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[viagensDispTodos_sps]
AS
BEGIN
	SELECT Id, PlanetaOrigem, PlanetaDestino, Valor, Tempo FROM ViagensDisponiveis
END
GO
USE [master]
GO
ALTER DATABASE [ViagensInterplanetarias] SET  READ_WRITE 
GO
