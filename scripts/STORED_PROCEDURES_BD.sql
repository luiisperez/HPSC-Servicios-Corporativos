/********************************************************* CRUD DE EMPLEADOS *********************************************************/ 



/****** 
		PROCEDIMIENTO PARA AGREGAR EMPLEADOS A LA BASE DE DATOS (NO POSEEN NINGUN ROL) 
		FECHA: 3/3/2017 3:29 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_EMPLEADO]
  @emp_nombre AS varchar (250),
  @emp_apellido AS varchar (250),
  @emp_correo AS varchar (350),
  @emp_usuario AS varchar (200),
  @emp_password AS varchar (200)
AS
BEGIN
		BEGIN
			INSERT INTO EMPLEADO VALUES(@emp_correo, @emp_nombre, @emp_apellido, @emp_usuario, @emp_password, 2);
		END
END



/****** 
		PROCEDIMIENTO PARA MODIFICAR UN EMPLEADO DE LA BASE DE DATOS
		FECHA: 3/3/2017 4:10 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_EMPLEADO]
  @emp_nombre AS varchar (250),
  @emp_apellido AS varchar (250),
  @emp_correo AS varchar (350),
  @emp_usuario AS varchar (200),
  @emp_password AS varchar (200) 
AS
BEGIN
	UPDATE [dbo].[EMPLEADO] SET [E_NOMBRE1] = @emp_nombre, [E_APELLIDO1] = @emp_apellido, [E_PASSWORD] = @emp_password WHERE [E_CORREO] = @emp_correo
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN EMPLEADO DE LA BASE DE DATOS
		FECHA: 3/3/2017 4:15 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_EMPLEADO]
  @emp_correo AS varchar(350)
AS
BEGIN
	UPDATE [dbo].[EMPLEADO] SET [E_FK_ROL] = 4 WHERE [E_CORREO] = @emp_correo
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS EMPLEADOS DE LA BASE DE DATOS
		FECHA: 3/3/2017 4:17 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EMPLEADOS]
AS
BEGIN
	SELECT E.E_CORREO, E.E_NOMBRE1, E.E_APELLIDO1, E.E_USUARIO, E.E_PASSWORD, R.R_NOMBRE FROM EMPLEADO E, ROL R WHERE R.R_ID=E.E_FK_ROL;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS EMPLEADOS DE LA BASE DE DATOS
		FECHA: 3/3/2017 4:19 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EMPLEADO]
  @emp_usuario AS varchar(350)
AS
BEGIN
	SELECT E.E_CORREO, E.E_NOMBRE1, E.E_APELLIDO1, E.E_USUARIO, E.E_PASSWORD, R.R_NIVELPRIVILEGIO FROM EMPLEADO E, ROL R WHERE [E_USUARIO] = @emp_usuario AND R.R_ID=E.E_FK_ROL;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS EMPLEADOS DE LA BASE DE DATOS POR CORREO
		FECHA: 3/3/2017 5:12 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EMPLEADO_CORREO]
  @emp_correo AS varchar(350)
AS
BEGIN
	SELECT * FROM EMPLEADO WHERE [E_CORREO] = @emp_correo
END



/****** 
		PROCEDIMIENTO PARA CAMBIAR EL PWD DE UN EMPLEADO DE LA BASE DE DATOS POR CORREO
		FECHA: 3/3/2017 6:12 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAMBIAR_PWD_EMPLEADO]
  @emp_correo AS varchar(350),
  @emp_password AS varchar(350)
AS
BEGIN
	UPDATE [dbo].[EMPLEADO] SET [E_PASSWORD] = @emp_password WHERE [E_CORREO] = @emp_correo
END



/********************************************************* FIN CRUD DE EMPLEADOS *********************************************************/ 





/********************************************************* CRUD DE ROLES *********************************************************/ 



/****** 
		PROCEDIMIENTO PARA AGREGAR ROLES A LOS EMPLEADOS DE LA BASE DE DATOS
		FECHA: 3/3/2017 3:41 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_ROL_EMPLEADO]
  @emp_correo AS varchar(350),
  @emp_rol AS int
AS
BEGIN
	UPDATE [dbo].[EMPLEADO] SET [E_FK_ROL] = @emp_rol WHERE [e_correo] = @emp_correo
END



/****** 
		PROCEDIMIENTO PARA AGREGAR ROLES A LA BASE DE DATOS 
		FECHA: 3/3/2017 3:11 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_ROL]
  @rol_nombre AS varchar (100),
  @rol_nivelprivilegio AS int  
AS
BEGIN
	IF ((SELECT COUNT(R_ID) FROM ROL) = 0)
		BEGIN
			INSERT INTO ROL VALUES(1, @rol_nombre, @rol_nivelprivilegio);
		END
  	ELSE
		BEGIN
			INSERT INTO ROL VALUES((SELECT MAX(R_ID) from ROL)+1, @rol_nombre, @rol_nivelprivilegio);
		END
END



/****** 
		PROCEDIMIENTO PARA MODIFICAR UN ROL DE LA BASE DE DATOS
		FECHA: 3/3/2017 3:53 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_ROL]
  @rol_id AS int,
  @rol_nombre AS varchar (100),
  @rol_nivelprivilegio AS int  
AS
BEGIN
	UPDATE [dbo].[ROL] SET [R_NOMBRE] = @rol_nombre, [R_NIVELPRIVILEGIO] = @rol_nivelprivilegio WHERE [R_ID] = @rol_id
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN ROL DE LA BASE DE DATOS
		FECHA: 3/3/2017 3:57 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_ROL]
  @rol_id AS int,
  @rol_nombre AS varchar (100),
  @rol_nivelprivilegio AS int  
AS
BEGIN
	DELETE FROM [dbo].[ROL] WHERE [R_ID] = @rol_id
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR TODOS LOS ROLES
		FECHA: 3/3/2017 3:59 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_ROLES]
AS
BEGIN
	SELECT * FROM ROL
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR UN ROL
		FECHA: 3/3/2017 4:02 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_ROL]
  @rol_id AS int
AS
BEGIN
	SELECT * FROM ROL WHERE [R_ID] = @rol_id
END



/********************************************************* FIN CRUD ROLES *********************************************************/





/********************************************************* CRUD DE CLIENTES *********************************************************/ 



/****** 
		PROCEDIMIENTO PARA AGREGAR CLIENTES A LA BASE DE DATOS 
		FECHA: 14/3/2017 5:40 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_CLIENTE]
  @cli_nombre AS varchar (250),
  @cli_direccion AS varchar (1500),
  @cli_correo AS varchar (350),
  @cli_usuario AS varchar (200),
  @cli_password AS varchar (200)
AS
BEGIN
		BEGIN
			INSERT INTO CLIENTE VALUES(@cli_correo, @cli_nombre, @cli_usuario, @cli_password, @cli_direccion, 3);
		END
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS CLIENTES DE LA BASE DE DATOS
		FECHA: 14/3/2017 5:19 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_CLIENTE]
  @cli_usuario AS varchar(350)
AS
BEGIN
	SELECT C.C_CORREO, C.C_NOMBRE_EMPRESA, C.C_USUARIO, C.C_PASSWORD, C.C_UBICACION, R.R_NIVELPRIVILEGIO FROM CLIENTE C, ROL R WHERE [C_USUARIO] = @cli_usuario AND R.R_ID=C.C_FK_ROL;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS CLIENTES DE LA BASE DE DATOS POR CORREO
		FECHA: 14/3/2017 5:12 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_CLIENTE_CORREO]
  @cli_correo AS varchar(350)
AS
BEGIN
	SELECT * FROM CLIENTE WHERE [C_CORREO] = @cli_correo
END



/****** 
		PROCEDIMIENTO PARA CAMBIAR EL PWD DE UN CLIENTE DE LA BASE DE DATOS POR CORREO
		FECHA: 16/3/2017 1:12 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CAMBIAR_PWD_CLIENTE]
  @cli_correo AS varchar(350),
  @cli_password AS varchar(350)
AS
BEGIN
	UPDATE [dbo].[CLIENTE] SET [C_PASSWORD] = @cli_password WHERE [C_CORREO] = @cli_correo
END



/****** 
		PROCEDIMIENTO PARA MODIFICAR UN CLIENTE DE LA BASE DE DATOS
		FECHA: 16/3/2017 1:18 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_CLIENTE]
  @cli_nombre AS varchar (250),
  @cli_direccion AS varchar (250),
  @cli_correo AS varchar (350),
  @cli_usuario AS varchar (200),
  @cli_password AS varchar (200) 
AS
BEGIN
	UPDATE [dbo].[CLIENTE] SET [C_NOMBRE_EMPRESA] = @cli_nombre, [C_UBICACION] = @cli_direccion, [C_PASSWORD] = @cli_password WHERE [C_CORREO] = @cli_correo
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN CLIENTE DE LA BASE DE DATOS
		FECHA: 16/3/2017 1:20 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_CLIENTE]
  @cli_correo AS varchar(350)
AS
BEGIN
	UPDATE [dbo].[CLIENTE] SET [C_FK_ROL] = 4 WHERE [C_CORREO] = @cli_correo
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN CLIENTE DE LA BASE DE DATOS
		FECHA: 17/3/2017 3:22 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_CLIENTES]
AS
BEGIN
	SELECT * FROM CLIENTE WHERE C_FK_ROL<>4
END



/********************************************************* FIN CRUD CLIENTES *********************************************************/





/********************************************************* CRUD DE EQUIPOS *********************************************************/ 



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS EQUIPOS POR CLIENTE DE LA BASE DE DATOS
		FECHA: 20/3/2017 1:03 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPOS_CLIENTE]
  @cli_correo AS varchar(350)
AS
BEGIN
	SELECT E.EQ_SERIAL, E.EQ_FK_NUMEROPRODUCTO, P.P_CATEGORIA, P.P_FK_MARCA, P.P_MODELO, E.EQ_ESTATUS, E.EQ_FK_CLIENTE
	FROM EQUIPO E, PRODUCTO P
	WHERE E.EQ_FK_NUMEROPRODUCTO = P.P_NUMEROPRODUCTO AND [EQ_FK_CLIENTE] = @cli_correo;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR UN EQUIPO DE LA BASE DE DATOS POR SERIAL
		FECHA: 22/3/2017 10:03 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPO_SERIAL]
  @eq_serial AS varchar(350)
AS
BEGIN
	SELECT E.EQ_SERIAL, E.EQ_FK_NUMEROPRODUCTO, P.P_CATEGORIA, P.P_FK_MARCA, P.P_MODELO, E.EQ_ESTATUS, C.C_NOMBRE_EMPRESA
	FROM EQUIPO E, PRODUCTO P, CLIENTE C
	WHERE E.EQ_FK_NUMEROPRODUCTO = P.P_NUMEROPRODUCTO AND E.EQ_FK_CLIENTE = C.C_CORREO AND E.EQ_SERIAL = @eq_serial;
END


/****** 
		PROCEDIMIENTO PARA CONSULTAR UN EQUIPO DE LA BASE DE DATOS POR N° DE EQUIPO
		FECHA: 22/3/2017 10:05 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPO_NUM]
  @pr_numequipo AS varchar(350)
AS
BEGIN
	SELECT * FROM PRODUCTO WHERE [P_NUMEROPRODUCTO] = @pr_numequipo;
END



/****** 
		PROCEDIMIENTO PARA AGREGAR EQUIPOS A LA BASE DE DATOS 
		FECHA: 22/3/2017 10:40 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_EQUIPO]
  @eq_categoria AS varchar(500),
  @eq_marca AS varchar(500),
  @eq_modelo AS varchar(500),
  @eq_numequipo AS varchar(500),
  @eq_serial AS varchar(250)
AS
BEGIN
	INSERT INTO EQUIPO VALUES(@eq_serial, @eq_categoria, @eq_marca, @eq_modelo, 'Operativo', @eq_numequipo, NULL);
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR EQUIPOS LIBRES A LA BASE DE DATOS 
		FECHA: 22/3/2017 10:58 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPOS_LIBRES]
AS
BEGIN
	SELECT E.EQ_SERIAL, E.EQ_FK_NUMEROPRODUCTO, P.P_CATEGORIA, P.P_FK_MARCA, P.P_MODELO, E.EQ_ESTATUS, E.EQ_FK_CLIENTE
	FROM EQUIPO E, PRODUCTO P
	WHERE E.EQ_FK_NUMEROPRODUCTO = P.P_NUMEROPRODUCTO AND E.EQ_FK_CLIENTE IS NULL;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR EQUIPOS A LA BASE DE DATOS 
		FECHA: 22/3/2017 11:58 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPOS_TODOS]
AS
BEGIN
	SELECT E.EQ_SERIAL, E.EQ_FK_NUMEROPRODUCTO, P.P_CATEGORIA, P.P_FK_MARCA, P.P_MODELO, E.EQ_ESTATUS, C.C_NOMBRE_EMPRESA
	FROM EQUIPO E, PRODUCTO P, CLIENTE C
	WHERE E.EQ_FK_NUMEROPRODUCTO = P.P_NUMEROPRODUCTO AND E.EQ_FK_CLIENTE = C.C_CORREO

	UNION 

	SELECT E.EQ_SERIAL, E.EQ_FK_NUMEROPRODUCTO, P.P_CATEGORIA, P.P_FK_MARCA, P.P_MODELO, E.EQ_ESTATUS, E.EQ_FK_CLIENTE
	FROM EQUIPO E, PRODUCTO P
	WHERE E.EQ_FK_NUMEROPRODUCTO = P.P_NUMEROPRODUCTO AND E.EQ_FK_CLIENTE IS NULL;
END


/****** 
		PROCEDIMIENTO PARA ASIGNAR EQUIPOS A LOS CLIENTES
		FECHA: 22/3/2017 3:58 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ASIGNAR_EQUIPO]
@eq_serial AS varchar(250),
@cli_correo AS varchar(350)
AS
BEGIN
	IF (@cli_correo = 'NULL')
		BEGIN 
			UPDATE EQUIPO SET [EQ_FK_CLIENTE] = NULL WHERE [EQ_SERIAl] = @eq_serial;
		END
	ELSE
		BEGIN
			UPDATE EQUIPO SET [EQ_FK_CLIENTE] = @cli_correo WHERE [EQ_SERIAl] = @eq_serial;
		END
END


/****** 
		PROCEDIMIENTO PARA ELIMINAR EQUIPOS
		FECHA: 22/3/2017 4:58 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_EQUIPO]
@eq_serial AS varchar(250)
AS
BEGIN
	UPDATE EQUIPO SET [EQ_FK_CLIENTE] = NULL, [EQ_ESTATUS] = 'Eliminado' WHERE [EQ_SERIAl] = @eq_serial;	
END


/****** 
		PROCEDIMIENTO PARA MODIFICAR EQUIPOS
		FECHA: 22/3/2017 5:20 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_EQUIPO]
  @eq_categoria AS varchar(500),
  @eq_marca AS varchar(500),
  @eq_modelo AS varchar(500),
  @eq_estatus AS varchar(500),
  @eq_numequipo AS varchar(500),
  @eq_serial AS varchar(250)
AS
BEGIN
	UPDATE EQUIPO SET [EQ_CATEGORIA] = @eq_categoria, [EQ_FK_NUMEROPRODUCTO] = @eq_numequipo, [EQ_ESTATUS] = @eq_estatus, [EQ_MARCA] = @eq_marca, [EQ_MODELO] = @eq_modelo WHERE [EQ_SERIAl] = @eq_serial;	
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS NUMEROS DE EQUIPOS REGISTRADOS
		FECHA: 28/3/2017 10:58 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_NUMEQUIPOS]
AS
BEGIN
	SELECT * FROM PRODUCTO;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LAS MARCAS REGISTRADAS EN EL SISTEMA
		FECHA: 28/3/2017 11:58 AM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_MARCAS]
AS
BEGIN
	SELECT * FROM MARCA;
END



/****** 
		PROCEDIMIENTO PARA AGREGAR UN PRODUCTO A LA BD
		FECHA: 28/3/2017 1:58 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_PRODUCTO]
  @pr_categoria AS varchar(500),
  @pr_marca AS varchar(500),
  @pr_modelo AS varchar(500),
  @pr_numproducto AS varchar(500)
AS
BEGIN
	INSERT INTO PRODUCTO VALUES (@pr_numproducto, @pr_categoria, @pr_modelo, @pr_marca);
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS PRODUCTOS REGISTRADOS EN EL SISTEMA
		FECHA: 28/3/2017 2:03 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_PRODUCTOS]
AS
BEGIN
	SELECT * FROM PRODUCTO;
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN PRODUCTO DE LA BD
		FECHA: 28/3/2017 2:15 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_PRODUCTO]
  @pr_categoria AS varchar(500),
  @pr_marca AS varchar(500),
  @pr_modelo AS varchar(500),
  @pr_numproducto AS varchar(500),
  @pr_numproductoviejo AS varchar(500)
AS
BEGIN
	UPDATE PRODUCTO SET [P_CATEGORIA] = @pr_categoria, [P_NUMEROPRODUCTO] = @pr_numproducto, [P_FK_MARCA] = @pr_marca, [P_MODELO] = @pr_modelo WHERE [P_NUMEROPRODUCTO] = @pr_numproductoviejo;	
END



/********************************************************* FIN CRUD EQUIPOS *********************************************************/





/********************************************************* CRUD DE SERVICIOS *********************************************************/ 



/****** 
		PROCEDIMIENTO PARA INSERTAR UN SERVICIO EN LA BASE DE DATOS
		FECHA: 30/3/2017 1:03 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_SERVICIO]
  @sv_cantdias AS int,
  @sv_canthoras AS int,
  @sv_disponibilidad AS varchar(500),
  @sv_feriados AS int,
  @sv_id AS varchar(500),
  @sv_nivelserv AS varchar(500),
  @sv_tiemporesp AS int,
  @sv_tiposerv AS varchar(500)
AS
BEGIN
	INSERT INTO SERVICIO VALUES (@sv_id, @sv_nivelserv, @sv_tiposerv, @sv_tiemporesp, @sv_feriados, @sv_cantdias, @sv_canthoras, @sv_disponibilidad);
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS SERVICIOS DE LA BASE DE DATOS
		FECHA: 30/3/2017 1:40 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_SERVICIOS]
AS
BEGIN
	SELECT * FROM SERVICIO;
END



/****** 
		PROCEDIMIENTO PARA INSERTAR UN SERVICIO EN LA BASE DE DATOS
		FECHA: 30/3/2017 1:42 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_SERVICIO]
  @sv_cantdias AS int,
  @sv_canthoras AS int,
  @sv_disponibilidad AS varchar(500),
  @sv_feriados AS int,
  @sv_id AS varchar(500),
  @sv_nivelserv AS varchar(500),
  @sv_tiemporesp AS int,
  @sv_tiposerv AS varchar(500)
AS
BEGIN
	UPDATE SERVICIO SET [SV_NIVELSERVICIO] = @sv_nivelserv, [SV_TIPOSERVICIO] = @sv_tiposerv, [SV_TIEMPORESPUESTA] = @sv_tiemporesp, [SV_FERIADOS_SI_NO] = @sv_feriados,
					    [SV_CANTDIAS] = @sv_cantdias, [SV_CANTHORAS] = @sv_canthoras, [SV_DISPONIBILIDAD] = @sv_disponibilidad WHERE [SV_ID] = @sv_id;	
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR UN SERVICIO DE LA BASE DE DATOS
		FECHA: 30/3/2017 1:47 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_SERVICIO]
  @sv_id AS varchar(500)
AS
BEGIN
	SELECT * FROM SERVICIO WHERE SV_ID = @sv_id;
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN SERVICIO DE LA BASE DE DATOS
		FECHA: 30/3/2017 1:51 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_SERVICIO]
  @sv_id AS varchar(500)
AS
BEGIN
	UPDATE SERVICIO SET [SV_DISPONIBILIDAD] = 'No disponible' WHERE [SV_ID] = @sv_id;
END



/****** 
		PROCEDIMIENTO PARA ASIGNAR UN SERVICIO A UN EQUIPO
		FECHA: 31/3/2017 12:03 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ASIGNAR_SERVICIO]
  @sv_id AS varchar(500),
  @eq_serial AS varchar(250),
  @eqsv_id AS varchar(500),
  @eqsv_contrato AS varchar(500),
  @eqsv_fechaini as date,
  @eqsv_fechafin as date
AS
BEGIN
	INSERT INTO EQUIPO_SERVICIO VALUES (@eqsv_id, @eqsv_contrato, @eqsv_fechaini, @eqsv_fechafin, @eq_serial, @sv_id);
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS SERVICIOS ASIGNADOS POR UN EQUIPO
		FECHA: 3/4/2017 12:19 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_SERVICIOS_POR_EQUIPO]
  @eq_serial AS varchar(250)
AS
BEGIN
	SELECT ES.EC_ID_CONTRATO AS ID, S.SV_NIVELSERVICIO AS NIVELSERV, S.SV_TIPOSERVICIO AS TIPOSERV, S.SV_TIEMPORESPUESTA AS TIEMPORESP, 
		   S.SV_FERIADOS_SI_NO AS FERIADO, S.SV_CANTDIAS AS DIAS, S.SV_CANTHORAS AS HORAS, 
		   ES.EC_FECHAINICIO AS INICIO, ES.EC_FECHAFIN AS FECHAFIN, S.SV_ID AS IDSERVICIO
	FROM SERVICIO S, EQUIPO E, EQUIPO_SERVICIO ES
	WHERE ES.EC_FK_EQUIPO = E.EQ_SERIAL AND S.SV_ID = ES.EC_FK_SERVICIO AND E.EQ_SERIAL = @eq_serial;
END



/****** 
		PROCEDIMIENTO PARA ELIMINAR UN CONTRATO DE LA BASE DE DATOS
		FECHA: 3/4/2017 1:13 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_CONTRATO]
  @eqsv_contrato AS varchar(500)
AS
BEGIN
	DELETE FROM EQUIPO_SERVICIO WHERE EC_ID_CONTRATO = @eqsv_contrato;
END



/****** 
		PROCEDIMIENTO PARA SELECCIONAR UN SERVICIO ASIGNADO
		FECHA: 3/4/2017 1:55 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_SERVICIO_ASIGNADO]
  @eqsv_id AS varchar(500)
AS
BEGIN
	SELECT * FROM EQUIPO_SERVICIO WHERE EC_ID = @eqsv_id;
END




/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS CONTRATOS REGISTRADOS EN LA BD
		FECHA: 31/3/2017 12:03 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_CONTRATOS]
AS
BEGIN
	SELECT ES.EC_ID_CONTRATO,ES.EC_FECHAINICIO, ES.EC_FECHAFIN, C.C_NOMBRE_EMPRESA
	FROM EQUIPO_SERVICIO ES, EQUIPO E, CLIENTE C
	WHERE C.C_CORREO = E.EQ_FK_CLIENTE AND E.EQ_SERIAL = ES.EC_FK_EQUIPO 
	GROUP BY ES.EC_ID_CONTRATO,ES.EC_FECHAINICIO, ES.EC_FECHAFIN, C.C_NOMBRE_EMPRESA;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS EQUIPOS DE UN CONTRATO
		FECHA: 3/5/2017 1:01 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_EQUIPO_CONTRATO]
  @eqsv_contrato AS varchar(500)
AS
BEGIN
	SELECT E.EQ_SERIAL, E.EQ_CATEGORIA, E.EQ_MARCA, E.EQ_MODELO, E.EQ_ESTATUS, E.EQ_FK_NUMEROPRODUCTO
	FROM EQUIPO_SERVICIO ES, EQUIPO E, CLIENTE C
	WHERE C.C_CORREO = E.EQ_FK_CLIENTE AND E.EQ_SERIAL = ES.EC_FK_EQUIPO AND ES.EC_ID_CONTRATO = @eqsv_contrato 
	GROUP BY E.EQ_SERIAL, E.EQ_CATEGORIA, E.EQ_MARCA, E.EQ_MODELO, E.EQ_ESTATUS, E.EQ_FK_NUMEROPRODUCTO;
END



/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS SERVICIOS QUE POSEE UN CONTRATO
		FECHA: 3/5/2017 1:06 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_SERVICIO_CONTRATO]
  @eqsv_contrato AS varchar(500)
AS
BEGIN
	SELECT S.SV_ID, S.SV_NIVELSERVICIO, S.SV_TIPOSERVICIO, S.SV_TIEMPORESPUESTA, S.SV_FERIADOS_SI_NO, S.SV_CANTHORAS, S.SV_CANTDIAS, S.SV_DISPONIBILIDAD
	FROM EQUIPO_SERVICIO ES, SERVICIO S
	WHERE ES.EC_FK_SERVICIO = S.SV_ID AND ES.EC_ID_CONTRATO = @eqsv_contrato 
	GROUP BY S.SV_ID, S.SV_NIVELSERVICIO, S.SV_TIPOSERVICIO, S.SV_TIEMPORESPUESTA, S.SV_FERIADOS_SI_NO, S.SV_CANTHORAS, S.SV_CANTDIAS, S.SV_DISPONIBILIDAD;
END




/****** 
		PROCEDIMIENTO PARA CONSULTAR LOS CONTRATOS REGISTRADOS EN LA BD
		FECHA: 6/4/2017 2:23 PM
******/
USE [HPSC_SERVCORP]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CONSULTAR_CONTRATOS_CLIENTE]
  @cli_correo AS varchar(350)
AS
BEGIN
	SELECT ES.EC_ID_CONTRATO,ES.EC_FECHAINICIO, ES.EC_FECHAFIN, C.C_NOMBRE_EMPRESA
	FROM EQUIPO_SERVICIO ES, EQUIPO E, CLIENTE C
	WHERE C.C_CORREO = E.EQ_FK_CLIENTE AND E.EQ_SERIAL = ES.EC_FK_EQUIPO AND C.C_CORREO = @cli_correo
	GROUP BY ES.EC_ID_CONTRATO,ES.EC_FECHAINICIO, ES.EC_FECHAFIN, C.C_NOMBRE_EMPRESA;
END




