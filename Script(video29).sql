USE [master]
GO
/****** Object:  Database [DB_Sistema_de_Ventas]    Script Date: 18/01/2022 23:28:06 ******/
CREATE DATABASE [DB_Sistema_de_Ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Sistema_de_Ventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DB_Sistema_de_Ventas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Sistema_de_Ventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\DB_Sistema_de_Ventas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Sistema_de_Ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET QUERY_STORE = OFF
GO
USE [DB_Sistema_de_Ventas]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [DB_Sistema_de_Ventas]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](15) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[rnc_cliente] [varchar](15) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK__Clientes__677F38F5B4ABAA07] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Ingreso]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ingreso](
	[id_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_ingreso] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[costo_unitario] [decimal](12, 2) NOT NULL,
	[sub_total] [decimal](12, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[id_empresa] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[rnc_empresa] [varchar](15) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[logo] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngresoProductos]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngresoProductos](
	[id_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[fecha_ingreso] [date] NOT NULL,
	[comprobante] [varchar](20) NOT NULL,
	[monto_total] [decimal](12, 2) NOT NULL,
	[estado] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[id_inventario] [int] NOT NULL,
	[codigo] [varchar](15) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[costo_unitario] [decimal](12, 2) NOT NULL,
	[precio_venta] [decimal](12, 2) NOT NULL,
	[monto_total] [decimal](12, 2) NOT NULL,
	[tipo_cargo] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](15) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[presentacion] [varchar](10) NOT NULL,
	[costo_unitario] [decimal](12, 2) NOT NULL,
	[precio_venta] [decimal](12, 2) NOT NULL,
	[tipo_cargo] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](15) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[rnc_proveedor] [varchar](15) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[email] [varchar](40) NOT NULL,
 CONSTRAINT [PK__Proveedo__8D3DFE287A91471D] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Agregar_Detalle_Ingreso]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Agregar_Detalle_Ingreso]
@id_ingreso int,
@id_producto int,
@cantidad int,
@costo_unitario decimal (12,2),
@sub_total decimal (12,2)
as
insert into Detalle_Ingreso(id_ingreso,id_producto,cantidad,costo_unitario,sub_total)
values (@id_ingreso,@id_producto,@cantidad,@costo_unitario,@sub_total)
GO
/****** Object:  StoredProcedure [dbo].[Agregar_Ingreso_Productos]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Agregar_Ingreso_Productos]
@id_proveedor int,
@fecha_ingreso date,
@comprobante varchar (20),
@monto_total decimal (12,2),
@estado varchar (10)
as
insert into IngresoProductos (id_proveedor, fecha_ingreso, comprobante,
monto_total, estado)
values
(@id_proveedor, @fecha_ingreso, @comprobante,
@monto_total, @estado)
GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AgregarCliente]
@codigo varchar (15),
@nombre varchar (50),
@rnc_cliente varchar (15),
@direccion varchar (150),
@telefono varchar (15),
@email varchar (40),
@estado varchar(10)
as
insert into Clientes(codigo,nombre,rnc_cliente,direccion,telefono,email,estado)
values (@codigo,@nombre,@rnc_cliente,@direccion,@telefono,@email,@estado)
GO
/****** Object:  StoredProcedure [dbo].[AgregarEmpresa]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AgregarEmpresa]
@nombre varchar (60),
@rnc_empresa varchar (15),
@direccion varchar (100),
@telefono varchar (15),
@email varchar (40),
@logo image
as
insert into Empresas (nombre,rnc_empresa,direccion,telefono,email,logo)
values (@nombre,@rnc_empresa,@direccion,@telefono,@email,@logo)
GO
/****** Object:  StoredProcedure [dbo].[AgregarProducto]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--procedimiento agregar producto

create proc [dbo].[AgregarProducto]
@codigo varchar (15),
@nombre varchar (50),
@descripcion varchar (100),
@presentacion varchar (10),
@costo_unitario decimal (12,2),
@precio_venta decimal (12,2),
@tipo_cargo varchar (10)
as
insert into Productos (codigo,nombre,descripcion,presentacion,costo_unitario,precio_venta,tipo_cargo)
values (@codigo,@nombre,@descripcion,@presentacion,@costo_unitario,@precio_venta,@tipo_cargo)
GO
/****** Object:  StoredProcedure [dbo].[AgregarProveedor]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AgregarProveedor]
@codigo varchar (15),
@nombre varchar (50),
@rnc_proveedor varchar (15),
@direccion varchar (150),
@telefono varchar (15),
@email varchar (40)
as
insert into Proveedores(codigo,nombre,rnc_proveedor,direccion,telefono,email)
values (@codigo,@nombre,@rnc_proveedor,@direccion,@telefono,@email)
GO
/****** Object:  StoredProcedure [dbo].[Anular_Detalle_Ingreso]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Anular_Detalle_Ingreso]
@id_detalle int,
@id_ingreso int,
@id_producto int,
@cantidad int,
@costo_unitario decimal (12,2),
@sub_total decimal (12,2)
as
update Detalle_Ingreso 
set id_ingreso=@id_ingreso, id_producto=@id_producto, cantidad=@cantidad,
costo_unitario=@costo_unitario, sub_total=@sub_total
where id_detalle=@id_detalle
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Cliente_Codigo]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------buscar un  cliente por el codigo-----------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[Buscar_Cliente_Codigo]
@buscar varchar(50)
as
select * from Clientes where codigo like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Cliente_Nombre]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------buscar un  cliente por el nombre-----------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[Buscar_Cliente_Nombre]
@buscar varchar(50)
as
select * from Clientes where nombre like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Cliente_Rnc_Cliente]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Buscar_Cliente_Rnc_Cliente]
@buscar varchar(50)
as
select * from Clientes where rnc_cliente like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_IngresoProducto_Comprobante]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Buscar_IngresoProducto_Comprobante]
@buscar nvarchar(100)
as
select pro.nombre as 'Nombre Proveedor', ing.fecha_ingreso,
ing.comprobante, ing.monto_total, ing.estado 
from IngresoProductos ing
inner join Proveedores pro on ing.id_proveedor=pro.id_proveedor
where comprobante like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_IngresoProducto_Fecha]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------buscar ingreso producto por fecha------------------------
create proc [dbo].[Buscar_IngresoProducto_Fecha]
@buscar nvarchar(100)
as
select pro.nombre as 'Nombre Proveedor', ing.fecha_ingreso,
ing.comprobante, ing.monto_total, ing.estado 
from IngresoProductos ing
inner join Proveedores pro on ing.id_proveedor=pro.id_proveedor
where fecha_ingreso like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_IngresoProducto_Proveedor]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------buscar ingreso producto por proveedor------------------------
create proc [dbo].[Buscar_IngresoProducto_Proveedor]
@buscar nvarchar(100)
as
select pro.nombre as 'Nombre Proveedor', ing.fecha_ingreso,
ing.comprobante, ing.monto_total, ing.estado 
from IngresoProductos ing
inner join Proveedores pro on ing.id_proveedor=pro.id_proveedor
where nombre like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Producto_Codigo]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--buscar un  producto por el codigo
create proc [dbo].[Buscar_Producto_Codigo]
@buscar varchar(50)
as
select * from Productos where codigo like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Producto_Descripcion]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--buscar un  producto por el descripcion
create proc [dbo].[Buscar_Producto_Descripcion]
@buscar varchar(50)
as
select * from Productos where descripcion like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Producto_Nombre]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--buscar un  producto por el nombre
create proc [dbo].[Buscar_Producto_Nombre]
@buscar varchar(50)
as
select * from Productos where nombre like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Proveedor_Codigo]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[Buscar_Proveedor_Codigo]
@buscar varchar(50)
as
select * from Proveedores where codigo like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Proveedor_Nombre]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------buscar un  producto por el nombre-----------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[Buscar_Proveedor_Nombre]
@buscar varchar(50)
as
select * from Proveedores where nombre like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[Buscar_Proveedor_Rnc_Proveedor]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------buscar un  producto por la descripcion-----------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[Buscar_Proveedor_Rnc_Proveedor]
@buscar varchar(50)
as
select * from Proveedores where rnc_proveedor like @buscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EditarCliente]
@id_cliente int,
@codigo varchar (15),
@nombre varchar (50),
@rnc_cliente varchar (15),
@direccion varchar (150),
@telefono varchar (15),
@email varchar (40),
@estado varchar(10)
as
update Clientes set codigo=@codigo,nombre=@nombre,rnc_cliente=@rnc_cliente,
direccion=@direccion,telefono=@telefono,email=@email, estado=@estado
where id_cliente=@id_cliente
GO
/****** Object:  StoredProcedure [dbo].[EditarEmpresa]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EditarEmpresa]
@id_empresa int,
@nombre varchar (60),
@rnc_empresa varchar (15),
@direccion varchar (100),
@telefono varchar (15),
@email varchar (40),
@logo image
as
update Empresas set nombre=@nombre,rnc_empresa=@rnc_empresa,
direccion=@direccion,telefono=@telefono,email=@email,logo=@logo
where id_empresa=@id_empresa
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--procedimiento editar producto
create proc [dbo].[EditarProducto]
@id_producto int,
@codigo varchar (15),
@nombre varchar (50),
@descripcion varchar (100),
@presentacion varchar (10),
@costo_unitario decimal (12,2),
@precio_venta decimal (12,2),
@tipo_cargo varchar (10)
as
update Productos set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,
presentacion=@presentacion,costo_unitario=@costo_unitario,precio_venta=@precio_venta,
tipo_cargo=@tipo_cargo
where id_producto=@id_producto
GO
/****** Object:  StoredProcedure [dbo].[EditarProveedor]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--procedimiento editar producto
create proc [dbo].[EditarProveedor]
@id_proveedor int,
@codigo varchar (15),
@nombre varchar (50),
@rnc_proveedor varchar (15),
@direccion varchar (150),
@telefono varchar (15),
@email varchar (40)
as
update Proveedores set codigo=@codigo,nombre=@nombre,rnc_proveedor=@rnc_proveedor,
direccion=@direccion,telefono=@telefono,email=@email
where id_proveedor=@id_proveedor
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[EliminarCliente]
@id_cliente int
as
delete from Clientes
where id_cliente=@id_cliente
GO
/****** Object:  StoredProcedure [dbo].[EliminarEmpresa]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarEmpresa]
@id_empresa int
as
delete from Empresas where id_empresa=@id_empresa
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--procedimiento eliminar producto
create proc [dbo].[EliminarProducto]
@id_producto int
as
delete from Productos
where id_producto=@id_producto
GO
/****** Object:  StoredProcedure [dbo].[EliminarProveedor]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarProveedor]
@id_proveedor int
as
delete from Proveedores
where id_proveedor=@id_proveedor
GO
/****** Object:  StoredProcedure [dbo].[Mostrar_Ingreso]    Script Date: 18/01/2022 23:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Mostrar_Ingreso]
as
select pro.nombre as 'Nombre Proveedor', ing.fecha_ingreso,
ing.comprobante, ing.monto_total, ing.estado from IngresoProductos ing
inner join Proveedores pro on ing.id_proveedor=pro.id_proveedor
GO
USE [master]
GO
ALTER DATABASE [DB_Sistema_de_Ventas] SET  READ_WRITE 
GO
