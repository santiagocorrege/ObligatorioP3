USE [master]
GO
/****** Object:  Database [PapeleriaObligatorio]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE DATABASE [PapeleriaObligatorio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PapeleriaObligatorio', FILENAME = N'C:\Users\Ryzen\PapeleriaObligatorio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PapeleriaObligatorio_log', FILENAME = N'C:\Users\Ryzen\PapeleriaObligatorio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PapeleriaObligatorio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PapeleriaObligatorio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PapeleriaObligatorio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ARITHABORT OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PapeleriaObligatorio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PapeleriaObligatorio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PapeleriaObligatorio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PapeleriaObligatorio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PapeleriaObligatorio] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PapeleriaObligatorio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PapeleriaObligatorio] SET  MULTI_USER 
GO
ALTER DATABASE [PapeleriaObligatorio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PapeleriaObligatorio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PapeleriaObligatorio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PapeleriaObligatorio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PapeleriaObligatorio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PapeleriaObligatorio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PapeleriaObligatorio] SET QUERY_STORE = OFF
GO
USE [PapeleriaObligatorio]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15-May-24 12:05:23 AM ******/
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
/****** Object:  Table [dbo].[Articulos]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Codigo] [nvarchar](450) NOT NULL,
	[PrecioActual] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](450) NOT NULL,
	[RUT] [bigint] NOT NULL,
	[Direccion_Calle] [nvarchar](max) NOT NULL,
	[Direccion_Ciudad] [nvarchar](max) NOT NULL,
	[Direccion_Distancia] [decimal](18, 2) NOT NULL,
	[Direccion_Numero] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Linea]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linea](
	[PedidoId] [int] NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[PrecioVigente] [decimal](10, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Linea] PRIMARY KEY CLUSTERED 
(
	[PedidoId] ASC,
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[Nombre] [nvarchar](450) NOT NULL,
	[Valor] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaPedido] [date] NOT NULL,
	[FechaEntrega] [date] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Recargo] [decimal](10, 2) NOT NULL,
	[CostoPedido] [decimal](10, 2) NOT NULL,
	[Valido] [bit] NOT NULL,
	[Discriminator] [nvarchar](13) NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 15-May-24 12:05:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](13) NOT NULL,
	[Password_Encriptada] [nvarchar](max) NOT NULL,
	[Password_Valor] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Articulos_Codigo]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Articulos_Codigo] ON [dbo].[Articulos]
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Articulos_Nombre]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Articulos_Nombre] ON [dbo].[Articulos]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clientes_RazonSocial]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_RazonSocial] ON [dbo].[Clientes]
(
	[RazonSocial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Clientes_RUT]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clientes_RUT] ON [dbo].[Clientes]
(
	[RUT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Linea_ArticuloId]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE NONCLUSTERED INDEX [IX_Linea_ArticuloId] ON [dbo].[Linea]
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pedidos_ClienteId]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE NONCLUSTERED INDEX [IX_Pedidos_ClienteId] ON [dbo].[Pedidos]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_Email]    Script Date: 15-May-24 12:05:23 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_Email] ON [dbo].[Usuarios]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Linea]  WITH CHECK ADD  CONSTRAINT [FK_Linea_Articulos_ArticuloId] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Linea] CHECK CONSTRAINT [FK_Linea_Articulos_ArticuloId]
GO
ALTER TABLE [dbo].[Linea]  WITH CHECK ADD  CONSTRAINT [FK_Linea_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Linea] CHECK CONSTRAINT [FK_Linea_Pedidos_PedidoId]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_ClienteId]
GO
USE [master]
GO
ALTER DATABASE [PapeleriaObligatorio] SET  READ_WRITE 
GO
