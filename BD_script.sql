USE [master]
GO
/****** Object:  Database [bd_ger]    Script Date: 2/6/2020 1:40:34 a. m. ******/
CREATE DATABASE [bd_ger]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bd_ger', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\bd_ger.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bd_ger_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\bd_ger_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bd_ger] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd_ger].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd_ger] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd_ger] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd_ger] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd_ger] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd_ger] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd_ger] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [bd_ger] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd_ger] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd_ger] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd_ger] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd_ger] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd_ger] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd_ger] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd_ger] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd_ger] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bd_ger] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd_ger] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd_ger] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd_ger] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd_ger] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd_ger] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bd_ger] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd_ger] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bd_ger] SET  MULTI_USER 
GO
ALTER DATABASE [bd_ger] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd_ger] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd_ger] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd_ger] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [bd_ger] SET DELAYED_DURABILITY = DISABLED 
GO
USE [bd_ger]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comentarios](
	[idcomentario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NOT NULL,
	[correo] [varchar](80) NOT NULL,
	[telefono] [varchar](10) NOT NULL,
	[mensaje] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idcomentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuentas](
	[idcuenta] [int] IDENTITY(1,1) NOT NULL,
	[nombreuser] [varchar](30) NULL,
	[clave] [varchar](30) NULL,
	[rol] [varchar](30) NULL,
	[idusuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [NombreUser_clave] UNIQUE NONCLUSTERED 
(
	[clave] ASC,
	[nombreuser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recursos]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recursos](
	[idrecursos] [int] IDENTITY(1,1) NOT NULL,
	[nombrer] [varchar](50) NULL,
	[codigo] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idrecursos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [NombreRecurso_Codigo] UNIQUE NONCLUSTERED 
(
	[nombrer] ASC,
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Solicitud](
	[idsolicitud] [int] IDENTITY(1,1) NOT NULL,
	[aula] [varchar](10) NULL,
	[nivel] [varchar](4) NULL,
	[fechasolicitud] [datetime] NULL DEFAULT (getdate()),
	[fechauso] [date] NULL,
	[horainicio] [time](7) NULL,
	[horafinal] [time](7) NULL,
	[carrera] [varchar](max) NULL,
	[asignatura] [varchar](max) NULL,
	[idrecursos] [int] NULL,
	[idusuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](14) NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[email] [varchar](80) NULL,
	[telefono] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Usuario_Cedula] UNIQUE NONCLUSTERED 
(
	[cedula] ASC,
	[email] ASC,
	[telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[Usuarios] ([idusuario])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD FOREIGN KEY([idrecursos])
REFERENCES [dbo].[Recursos] ([idrecursos])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[Usuarios] ([idusuario])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [Nivel] CHECK  (([nivel]='I' OR [nivel]='III' OR [nivel]='IV' OR [nivel]='V'))
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [Nivel]
GO
/****** Object:  StoredProcedure [dbo].[_Cuentas]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_Cuentas]
	@b INT, @idcuenta INT, @nombreuser VARCHAR(30), @clave VARCHAR(30), @rol VARCHAR(30), @idusuario INT 
AS
BEGIN

SET NOCOUNT ON;
IF @b = 1
	INSERT INTO Cuentas VALUES (@nombreuser, @clave, @rol, @idusuario);
IF @b = 2
	DELETE FROM Cuentas WHERE idcuenta = @idcuenta;
IF @b = 3
	SELECT* FROM Cuentas
IF @b = 4
	UPDATE Cuentas SET nombreuser = @nombreuser, clave = @clave, rol = @rol, idusuario = @idusuario
	WHERE idcuenta = @idcuenta
IF @b =5
	SELECT * FROM Cuentas
	WHERE nombreuser LIKE '%' + @nombreuser + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[_Recursos]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[_Recursos]
@b int, @idrecursos int, @nombrer varchar(50), @codigo varchar(50), @descripcion varchar(50)
as
begin
set nocount on;

if @b = 1
insert into Recursos values (@nombrer, @codigo, @descripcion);

if @b = 2
delete from Recursos where idrecursos = @idrecursos;

if @b = 3
select * from Recursos

if @b=4
		update Recursos set nombrer = @nombrer, codigo = @codigo, descripcion = @descripcion
		where idrecursos = @idrecursos
if @b=5
		select * from recursos where nombrer like '%'+@nombrer+ '%'
end

GO
/****** Object:  StoredProcedure [dbo].[_Solicitud]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_Solicitud]
	@b INT, @idsolicitud INT, @aula VARCHAR(10), @nivel VARCHAR(10), @fechasolicitud DATETIME, @fechauso DATE, @horainicio TIME(6),
	@horafinal TIME(6), @carrera VARCHAR(MAX), @asignatura VARCHAR(MAX), @idrecursos INT, @idusuario INT, @nombres VARCHAR(50)
AS
BEGIN

SET NOCOUNT ON;
IF @b = 1
	INSERT INTO Solicitud VALUES (@aula, @nivel, @fechasolicitud, @fechauso, @horainicio, @horafinal, @carrera, @asignatura, @idrecursos, @idusuario);
IF @b = 2
	DELETE FROM Solicitud WHERE idsolicitud = @idsolicitud;
If @b = 3
	/*SELECT S.aula, S.nivel, S.fechasolicitud, S.fechauso, S.horainicio, S.horainicio, S.horafinal,
		   S.carrera, S.asignatura, U.nombres
	FROM   Recursos AS R INNER JOIN
		Solicitud AS S ON R.idrecursos = S.idrecursos INNER JOIN
		Usuarios AS U ON S.idusuario = U.idusuario*/

		/*SELECT R.nombrer, S.aula, S.nivel, S.fechasolicitud, S.fechauso, S.horainicio, S.horainicio, S.horafinal,
		   S.carrera, S.asignatura, U.nombres
	FROM   Recursos AS R INNER JOIN
		Solicitud AS S ON R.idrecursos = S.idrecursos INNER JOIN
		Usuarios AS U ON S.idusuario = U.idusuario*/

		SELECT* FROM Solicitud

IF @b = 4
	UPDATE Solicitud SET aula = @aula, nivel = @nivel, fechasolicitud = @fechasolicitud, fechauso = @fechauso, horainicio = @horainicio, horafinal = @horafinal,
	carrera = @carrera, asignatura = @asignatura, idrecursos = @idrecursos, idusuario = @idusuario
	WHERE idsolicitud = @idsolicitud
IF @b = 5
	/*SELECT * FROM Solicitud AS S
	INNER JOIN Usuarios AS U
	ON S.idusuario = U.idusuario
	WHERE nombres LIKE '%' + 'hola' + '%'/*buscar las concidencias*/
	*/

	/*SELECT R.nombrer, S.aula, S.nivel, S.fechasolicitud, S.fechauso, S.horainicio, S.horainicio, S.horafinal,
		   S.carrera, S.asignatura, U.nombres
	FROM   Recursos AS R INNER JOIN
		Solicitud AS S ON R.idrecursos = S.idrecursos INNER JOIN
		Usuarios AS U ON S.idusuario = U.idusuario
		WHERE nombres LIKE '%' + @nombres + '%'*/

		select * from Solicitud where aula like '%'+@aula+ '%'
END

GO
/****** Object:  StoredProcedure [dbo].[_Usuarios]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_Usuarios]
	@b INT, @idusuario INT, @cedula VARCHAR(14), @nombres VARCHAR(50), @apellidos VARCHAR(50), @email VARCHAR(80), @telefono VARCHAR(10)
AS
BEGIN

SET NOCOUNT ON;
IF @b = 1
	INSERT INTO Usuarios VALUES (@cedula, @nombres, @apellidos, @email, @telefono);
IF @b = 2
	DELETE FROM Usuarios WHERE idusuario = @idusuario;
If @b = 3
	SELECT * FROM Usuarios
IF @b = 4
	UPDATE Usuarios SET cedula = @cedula, nombres = @nombres, apellidos = @apellidos, email = @email, telefono = @telefono
	WHERE idusuario = @idusuario
IF @b = 5
	SELECT * FROM Usuarios
	WHERE nombres LIKE '%' + @nombres + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Comentar]    Script Date: 2/6/2020 1:40:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Comentar]

@b INT, @idcomentario INT, @nombres VARCHAR(100), @correo VARCHAR(50), @telefono VARCHAR(10), @mensaje VARCHAR(MAX)

AS
BEGIN

SET NOCOUNT ON;

IF @b = 1
	INSERT INTO Comentarios VALUES (@nombres, @correo, @telefono, @mensaje);
IF @b = 2
	DELETE FROM Comentarios WHERE idcomentario = @idcomentario;
IF @b = 3 
	SELECT * FROM Comentarios

END

GO
USE [master]
GO
ALTER DATABASE [bd_ger] SET  READ_WRITE 
GO
