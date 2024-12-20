USE [master]
GO
/****** Object:  Database [ECOMMERCE]    Script Date: 6/12/2024 18:11:16 ******/
CREATE DATABASE [ECOMMERCE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ECOMMERCE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ECOMMERCE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ECOMMERCE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ECOMMERCE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ECOMMERCE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ECOMMERCE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ECOMMERCE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ECOMMERCE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ECOMMERCE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ECOMMERCE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ECOMMERCE] SET ARITHABORT OFF 
GO
ALTER DATABASE [ECOMMERCE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ECOMMERCE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ECOMMERCE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ECOMMERCE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ECOMMERCE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ECOMMERCE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ECOMMERCE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ECOMMERCE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ECOMMERCE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ECOMMERCE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ECOMMERCE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ECOMMERCE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ECOMMERCE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ECOMMERCE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ECOMMERCE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ECOMMERCE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ECOMMERCE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ECOMMERCE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ECOMMERCE] SET  MULTI_USER 
GO
ALTER DATABASE [ECOMMERCE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ECOMMERCE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ECOMMERCE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ECOMMERCE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ECOMMERCE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ECOMMERCE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ECOMMERCE] SET QUERY_STORE = OFF
GO
USE [ECOMMERCE]
GO
/****** Object:  Table [dbo].[DETALLE_VENTA]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_VENTA](
	[IDVENTA] [int] NULL,
	[IDPRODUCTO] [int] NULL,
	[IDORIFICIOS] [int] NULL,
	[CANTIDAD] [int] NOT NULL,
	[PRECIO] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEVOLUCIONES]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEVOLUCIONES](
	[IDVENTA] [int] NULL,
	[IDPRODUCTO] [int] NULL,
	[IDORIFICIOS] [int] NULL,
	[IDUSUARIO] [int] NULL,
	[MOTIVO] [varchar](500) NULL,
	[DEVUELTO] [bit] NULL,
	[CANTIDAD] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATERIALES]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATERIALES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORIFICIOS]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORIFICIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORIFICIOS_X_PRODUCTO]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORIFICIOS_X_PRODUCTO](
	[IDPRODUCTO] [int] NULL,
	[IDORIFICIOS] [int] NULL,
	[STOCK] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTOS]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](200) NOT NULL,
	[DESCRIPCION] [varchar](200) NULL,
	[IDTIPO] [int] NOT NULL,
	[IDMATERIAL] [int] NULL,
	[LADO] [varchar](3) NULL,
	[TIPO_BLOQUEO] [varchar](3) NULL,
	[CANTIDAD_ORIFICIOS] [int] NULL,
	[DIAMETRO] [decimal](10, 2) NULL,
	[IMAGEN1] [varchar](500) NULL,
	[IMAGEN2] [varchar](500) NULL,
	[IMAGEN3] [varchar](500) NULL,
	[IMAGEN4] [varchar](500) NULL,
	[PRECIO] [money] NULL,
	[ESTADO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOS]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
	[APELLIDO] [varchar](100) NULL,
	[EMAIL] [varchar](100) NULL,
	[CONTRASEÑA] [varchar](100) NULL,
	[TipoUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTAS]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUSUARIO] [int] NULL,
	[FECHAVENTA] [datetime] NOT NULL,
	[PRECIOTOTAL] [money] NULL,
	[ESTADO] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DEVOLUCIONES] ADD  DEFAULT ((0)) FOR [DEVUELTO]
GO
ALTER TABLE [dbo].[VENTAS] ADD  DEFAULT ((1)) FOR [ESTADO]
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IDORIFICIOS])
REFERENCES [dbo].[ORIFICIOS] ([ID])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IDPRODUCTO])
REFERENCES [dbo].[PRODUCTOS] ([ID])
GO
ALTER TABLE [dbo].[DETALLE_VENTA]  WITH CHECK ADD FOREIGN KEY([IDVENTA])
REFERENCES [dbo].[VENTAS] ([ID])
GO
ALTER TABLE [dbo].[ORIFICIOS_X_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IDORIFICIOS])
REFERENCES [dbo].[ORIFICIOS] ([ID])
GO
ALTER TABLE [dbo].[ORIFICIOS_X_PRODUCTO]  WITH CHECK ADD FOREIGN KEY([IDPRODUCTO])
REFERENCES [dbo].[PRODUCTOS] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD FOREIGN KEY([IDMATERIAL])
REFERENCES [dbo].[MATERIALES] ([ID])
GO
ALTER TABLE [dbo].[PRODUCTOS]  WITH CHECK ADD FOREIGN KEY([IDTIPO])
REFERENCES [dbo].[TIPOS] ([ID])
GO
ALTER TABLE [dbo].[VENTAS]  WITH CHECK ADD FOREIGN KEY([IDUSUARIO])
REFERENCES [dbo].[USUARIOS] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarCompra]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AgregarCompra](
@Id int, 
@IdUsuario int,
@Total money
) AS BEGIN 
	Insert into VENTAS (IDUSUARIO, FECHAVENTA,PRECIOTOTAL) values(@IdUsuario,GETDATE() ,@Total)
END 



--AGREGA DETALLE VENTA 
GO
/****** Object:  StoredProcedure [dbo].[SP_agregarDetalleVenta]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_agregarDetalleVenta] (
@Id int, 
@IdProducto int, 
@IdOrificios int,
@Cantidad int, 
@Precio money
)AS 
BEGIN 
Insert into DETALLE_VENTA VALUES (@Id, @IdProducto,@IdOrificios,@Cantidad,@Precio)
DECLARE @Stock int
SELECT @Stock= STOCK FROM ORIFICIOS_X_PRODUCTO WHERE IDORIFICIOS=@IdOrificios AND IDPRODUCTO=IDPRODUCTO
DECLARE @StockActualizado int 
SET @StockActualizado = (@Stock-@Cantidad)
Update ORIFICIOS_X_PRODUCTO set STOCK = @StockActualizado WHERE IDORIFICIOS=@IdOrificios AND IDPRODUCTO=@IdProducto
END 


--ELIMINA MATERIAL
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGARMATERIAL]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGARMATERIAL] (
@Nombre varchar (100)
)AS
BEGIN 
	INSERT INTO MATERIALES VALUES(@Nombre)
	
END 




-- LISTA LA CANTIDAD DE STOCK POR PRODUCTO Y COLOR
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGARORIFICIOS_x_PRODUCTO]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGARORIFICIOS_x_PRODUCTO] (
@IdProducto int, 
@IdOrificios int, 
@Stock int
)AS
BEGIN 
	INSERT INTO ORIFICIOS_X_PRODUCTO VALUES (@IdProducto,@IdOrificios,@Stock)
END 
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGARPRODUCTO]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGARPRODUCTO] (
@Nombre varchar (200), 
@Descripcion varchar (200), 
@Tipo int, 
@Material int, 

@Lado varchar(3),
@TipoBloqueo varchar(3),
@CantidadOrificios int,
@Diametro decimal(10,2),

@Imagen1 varchar (500), 
@Imagen2 varchar (500),
@Imagen3 varchar (500),
@Imagen4 varchar (500),
@Precio money
)AS
BEGIN 
	INSERT INTO PRODUCTOS VALUES(@Nombre,@Descripcion, @Tipo, @Material,@Lado,@TipoBloqueo,@CantidadOrificios,@Diametro,@Imagen1,@Imagen2,@Imagen3,@Imagen4, @Precio,1)
	
END 

GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGARTIPO]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGARTIPO] (
@Nombre varchar (100)
)AS
BEGIN 
	INSERT INTO TIPOS VALUES(@Nombre)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_AgregarUsuario]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--AGREGAR USUARIO
CREATE PROCEDURE [dbo].[SP_AgregarUsuario]( 
@Nombre varchar (100),
@Apellido varchar (100),
@Email varchar (100),
@Contraseña varchar(100)
) AS
BEGIN
Declare @CantidadUsuarios int 
Select @CantidadUsuarios= COUNT(DISTINCT U.Id) from Usuarios U 
IF (@CantidadUsuarios = 0) BEGIN 
insert into Usuarios (NOMBRE,APELLIDO,Email,Contraseña,TipoUser) output inserted.Id values (@Nombre,@Apellido,@Email,@Contraseña,2)
END 
ELSE BEGIN
insert into Usuarios (NOMBRE,APELLIDO,Email,Contraseña,TipoUser) output inserted.Id values (@Nombre,@Apellido,@Email,@Contraseña,1)
END 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminaMaterial]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_EliminaMaterial](@Id bigint)
as
Begin
delete MATERIAL Where ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminaProducto]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_EliminaProducto](@Id bigint)
as
Begin
Update PRODUCTOS set ESTADO = 0 Where ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminaTipo]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_EliminaTipo](@Id bigint)
as
Begin
delete TIPOS Where ID = @Id
end
--ELIMINA Producto
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertaSolicitudDevolucion]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertaSolicitudDevolucion](
@IdVenta INT,
@IdProducto INT,
@IdOrificios INT,
@IdUsuario INT,
@Motivo VARCHAR (500),
@Cantidad INT
) AS
BEGIN 
Insert into DEVOLUCIONES VALUES (@IdVenta, @IdProducto, @IdOrificios, @IdUsuario, @Motivo, 0, @Cantidad)
END


GO
/****** Object:  StoredProcedure [dbo].[SP_ListarStock]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarStock] (
@IdProducto int, 
@IdOrificios int 
)
AS BEGIN 
Select CXP.IDPRODUCTO,CXP.IDORIFICIOS,CXP.STOCK from ORIFICIOS_X_PRODUCTO CXP WHERE CXP.IDPRODUCTO= @IdProducto AND @IdOrificios=@IdOrificios
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICACATEGORIA]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICACATEGORIA] (
@Id int, 
@Nombre varchar (100)
) 
AS BEGIN 
	UPDATE TIPOS SET NOMBRE = @Nombre WHERE ID= @Id
END 


-- AGREGA CATEGORIA
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAMATERIAL]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- MODIFICA MARCA
CREATE PROCEDURE [dbo].[SP_MODIFICAMATERIAL] (
@Id int, 
@Nombre varchar (100)
) 
AS BEGIN 
	UPDATE MATERIALES SET NOMBRE = @Nombre WHERE ID= @Id

END 

-- MODIFICA CATEGORIA
GO
/****** Object:  StoredProcedure [dbo].[SP_ModificaProducto]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- MODIFICA PRODUCTO
CREATE Procedure [dbo].[SP_ModificaProducto](
@Id int, 
@Nombre varchar (100),
@Descripcion VARCHAR (200),
@Tipo int,
@Material int,
@Lado varchar(3),
@TipoBloqueo varchar(3),
@CantidadOrificios int,
@Diametro decimal(10,2),

@Imagen1 varchar(500),
@Imagen2 varchar(500),
@Imagen3 varchar(500),
@Imagen4 varchar(500),
@Precio money
)
as
Begin
update PRODUCTOS 
set NOMBRE = @Nombre,
DESCRIPCION = @Descripcion,
IDTIPO = @Tipo,
IDMATERIAL = @Material,
LADO = @Lado,
TIPO_BLOQUEO = @TipoBloqueo, 
CANTIDAD_ORIFICIOS = @CantidadOrificios,
DIAMETRO = @Diametro,

IMAGEN1 = @Imagen1, 
IMAGEN2 = @Imagen2, 
IMAGEN3 = @Imagen3, 
IMAGEN4 = @Imagen4, 
PRECIO = @Precio
Where ID = @Id
end

--AGREGA EL STOCK DE CADA COLOR POR PRODUCTO
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICARORIFICIOS_x_PRODUCTO]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--MODIFICA EL COLOR POR PRODUCTO
CREATE PROCEDURE [dbo].[SP_MODIFICARORIFICIOS_x_PRODUCTO] (
@IdProducto int, 
@IdOrificios int, 
@Stock int
)AS
BEGIN 
	UPDATE ORIFICIOS_X_PRODUCTO SET STOCK=@Stock WHERE IDPRODUCTO=@IdProducto AND IDORIFICIOS=@IdOrificios
END 




--AGREGA UN MATERIAL
GO
/****** Object:  StoredProcedure [dbo].[SP_SumoStock]    Script Date: 6/12/2024 18:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SumoStock] (
@idProducto int,
@idOrificios int, 
@cantidadDevuelto int
) AS 
BEGIN 

DECLARE @CANTIDADSTOCKACTUAL INT 
DECLARE @NUEVOSTOCK INT 
SELECT @CANTIDADSTOCKACTUAL= STOCK FROM ORIFICIOS_X_PRODUCTO WHERE IDPRODUCTO=@idProducto AND IDORIFICIOS=@idOrificios
SET @NUEVOSTOCK =  @CANTIDADSTOCKACTUAL + @cantidadDevuelto
UPDATE ORIFICIOS_X_PRODUCTO SET  STOCK= @NUEVOSTOCK Where IDPRODUCTO=@idProducto AND IDORIFICIOS=@idOrificios
END
GO
USE [master]
GO
ALTER DATABASE [ECOMMERCE] SET  READ_WRITE 
GO
