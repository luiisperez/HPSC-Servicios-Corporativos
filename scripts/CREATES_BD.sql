CREATE TABLE dbo.EMPLEADO(
	E_CORREO					varchar(350) NOT NULL,
	E_NOMBRE1					varchar(250) NOT NULL,
	E_APELLIDO1					varchar(250) NOT NULL,
	E_USUARIO					varchar(200) NOT NULL UNIQUE,
	E_PASSWORD					varchar(200) NOT NULL,
	E_FK_ROL					int,
	CONSTRAINT PK_CORREO_EMP PRIMARY KEY (E_CORREO),
);

CREATE TABLE dbo.ALIADO(
	A_CORREO					varchar(350) NOT NULL,
	A_NOMBRE_EMPRESA			varchar(250) NOT NULL,
	A_USUARIO					varchar(200) NOT NULL UNIQUE,
	A_PASSWORD					varchar(200) NOT NULL,
	A_UBICACION					varchar(1500) NOT NULL,
	A_FK_ROL					int,
	CONSTRAINT PK_CORREO_ALIADO PRIMARY KEY (A_CORREO)
);

CREATE TABLE dbo.CLIENTE(
	C_CORREO					varchar(350) NOT NULL,
	C_NOMBRE_EMPRESA			varchar(250) NOT NULL,
	C_USUARIO					varchar(200) NOT NULL UNIQUE,
	C_PASSWORD					varchar(200) NOT NULL,
	C_UBICACION					varchar(1500) NOT NULL,
	C_FK_ROL					int,
	CONSTRAINT PK_CORREO_CLIENTE PRIMARY KEY (C_CORREO)
);

CREATE TABLE dbo.ROL(
	R_ID						int NOT NULL,
	R_NOMBRE					varchar(250) NOT NULL,
	R_NIVELPRIVILEGIO			int NOT NULL,
	CONSTRAINT PK_ID_ROL PRIMARY KEY (R_ID)
);

CREATE TABLE dbo.EQUIPO(
	EQ_SERIAL					varchar(250) NOT NULL,
	EQ_CATEGORIA				varchar(500) NOT NULL,
	EQ_MARCA					varchar(500) NOT NULL,
	EQ_MODELO					varchar(500) NOT NULL,
	EQ_ESTATUS					varchar(500) NOT NULL,
	EQ_FK_NUMEROPRODUCTO		varchar(500) NOT NULL,
	EQ_FK_CLIENTE				varchar(350),
	CONSTRAINT PK_SERIAL_EQUIPO PRIMARY KEY (EQ_SERIAL),
	CONSTRAINT CH_ESTATUS_EQ CHECK(EQ_ESTATUS in('Operativo', 'Eliminado'))
);

CREATE TABLE dbo.PERSONAL_CONTACTO(
	PC_CORREO					varchar(350) NOT NULL,
	PC_NOMBRE1					varchar(250) NOT NULL,
	PC_APELLIDO1				varchar(250) NOT NULL,
	PC_TELFLOCAL				varchar(200) NOT NULL,
	PC_TELFMOVIL				varchar(200),
	PC_ESTATUS					varchar(200),
	PC_FK_CLIENTE				varchar(350) NOT NULL,
	CONSTRAINT PK_ID_PERSCONTACTO PRIMARY KEY (PC_CORREO),
	CONSTRAINT CH_ESTATUS_pc CHECK(pc_ESTATUS in('Activo', 'Eliminado'))
);

CREATE TABLE dbo.ACTIVIDAD(
	AC_ID						int NOT NULL,
	AC_TIPO						varchar(250) NOT NULL,
	AC_FECHAINICIO				datetime NOT NULL,
	AC_FECHAFIN					datetime NOT NULL,
	AC_FK_INCIDENTE				int NOT NULL,
	AC_FK_EMPLEADO				varchar(350) NOT NULL,
	CONSTRAINT PK_ID_ACTIVIDAD PRIMARY KEY (AC_ID),
	CONSTRAINT CH_TIPOACTIVIDAD CHECK(AC_TIPO in('Conferencia telefónica','Diagnóstico en sitio','Diagnóstico remoto'
												 ,'Entrenamiento','Estudio','Mantenimiento','Reparación','Reunión con el cliente'
												 ,'Soporte remoto','Traslado de ida','Traslado de regreso'))
);

CREATE TABLE dbo.EQUIPO_SERVICIO(
	EC_ID						varchar(500) NOT NULL,
	EC_ID_CONTRATO				varchar(500) NOT NULL,
	EC_FECHAINICIO				date NOT NULL,
	EC_FECHAFIN					date NOT NULL,
	EC_FK_EQUIPO				varchar(250) NOT NULL,
	EC_FK_SERVICIO				varchar(500) NOT NULL,
	CONSTRAINT PK_ID_CLI_CON PRIMARY KEY (EC_ID)
);

CREATE TABLE dbo.SERVICIO(
	SV_ID						varchar(500) NOT NULL,
	SV_NIVELSERVICIO			varchar(500) NOT NULL,
	SV_TIPOSERVICIO				varchar(500) NOT NULL,
	SV_TIEMPORESPUESTA			int NOT NULL,
	SV_FERIADOS_SI_NO			int NOT NULL,
	SV_CANTDIAS					varchar(500) NOT NULL,
	SV_CANTHORAS				int NOT NULL,
	SV_DISPONIBILIDAD			varchar(500) NOT NULL,
	CONSTRAINT PK_ID_SERVICIO PRIMARY KEY (SV_ID),
	CONSTRAINT CH_TIPOSERVICIOCONT CHECK(SV_TIPOSERVICIO in('Soporte reactivo','Soporte preventivo','Implementación')),
	CONSTRAINT CH_DISPOCONT CHECK(SV_DISPONIBILIDAD in('Disponible','No disponible'))
);

CREATE TABLE dbo.INCIDENTE(
	I_ID						int NOT NULL,
	I_FECHA 					datetime NOT NULL,
	I_FECHAREQUERIDA			datetime NOT NULL,
	I_FECHAFINALIZACION			datetime NOT NULL,
	I_FECHACOMPROMISO			datetime,
	I_FECHAATENCION				datetime,
	I_FECHAFINSERVICIO			datetime,
	I_ESTATUS					varchar(200) NOT NULL,
	I_TIPOSERVICIO				varchar(200) NOT NULL,
	I_IMPACTO					varchar(200) NOT NULL,
	I_URGENCIA					varchar(200) NOT NULL,
	I_DIRECCIONINCIDENTE		varchar(500) NOT NULL,
	I_DESCRIPCIONBREVE			varchar(500) NOT NULL,
	I_FK_CLIENTE				varchar(350) NOT NULL,
	I_FK_EQUIPO					varchar(250) NOT NULL,
	I_FK_EMPLEADO				varchar(350),
	I_FK_ALIADO					varchar(350),
	I_FK_PERSONAL_CONTACTO1		varchar(350) NOT NULL,
	I_FK_PERSONAL_CONTACTO2		varchar(350) NOT NULL,
	CONSTRAINT PK_ID_INCIDENTE PRIMARY KEY (I_ID),
	CONSTRAINT CH_TIPOSERVICIOINC CHECK(I_TIPOSERVICIO in('Soporte reactivo','Soporte preventivo','Implementación')),
	CONSTRAINT CH_ESTATUS CHECK(I_ESTATUS in('Abierto','Asignado','En sitio','Espera de partes','Monitoreo','Atendido','Cancelado')),
	CONSTRAINT CH_IMPACTO CHECK(I_IMPACTO in('Significativo','Moderado','Crítico','Menor')),
	CONSTRAINT CH_URGENCIA CHECK(I_URGENCIA in('Crítica','Alta','Media','Baja'))
);

CREATE TABLE dbo.PRODUCTO(
	P_NUMEROPRODUCTO			varchar(500) NOT NULL,
	P_CATEGORIA					varchar(500) NOT NULL,
	P_MODELO					varchar(500) NOT NULL,
	P_FK_MARCA					varchar(500) NOT NULL,
	CONSTRAINT PK_NUM_EQUIPO PRIMARY KEY (P_NUMEROPRODUCTO),
	CONSTRAINT CH_CATEGORIA CHECK(P_CATEGORIA in('Impresoras','Computadoras','Laptops', 'Servidores', 'Almacenamiento', 'Comunicaciones'))
);

CREATE TABLE dbo.MARCA(
	M_MARCA						varchar(500) NOT NULL,
	CONSTRAINT PK_MARCA PRIMARY KEY (M_MARCA)
);