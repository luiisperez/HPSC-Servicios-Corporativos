ALTER TABLE ALIADO
ADD CONSTRAINT FK_ROL_ALIADO
FOREIGN KEY(A_FK_ROL)
REFERENCES ROL(R_ID) ON DELETE SET NULL;

ALTER TABLE CLIENTE
ADD CONSTRAINT FK_ROL_CLIENTE
FOREIGN KEY(C_FK_ROL)
REFERENCES ROL(R_ID) ON DELETE SET NULL;

ALTER TABLE EMPLEADO
ADD CONSTRAINT FK_ROL_EMPLEADO
FOREIGN KEY(E_FK_ROL)
REFERENCES ROL(R_ID) ON DELETE SET NULL;

ALTER TABLE EQUIPO_CONTRATO
ADD CONSTRAINT FK_CONTRATO_EQUIPO
FOREIGN KEY(EC_FK_CONTRATO)
REFERENCES CONTRATO(CT_ID);

ALTER TABLE EQUIPO_CONTRATO
ADD CONSTRAINT FK_EQUIPO_CONTRATO
FOREIGN KEY(EC_FK_EQUIPO)
REFERENCES EQUIPO(EQ_SERIAL);

ALTER TABLE PERSONAL_CONTACTO
ADD CONSTRAINT FK_CLIENTE_PERSONAL
FOREIGN KEY(PC_FK_CLIENTE)
REFERENCES CLIENTE(C_CORREO) ON DELETE CASCADE;

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_CLIENTE_EQUIPO
FOREIGN KEY(EQ_FK_CLIENTE)
REFERENCES CLIENTE(C_CORREO) ON DELETE CASCADE;

ALTER TABLE ACTIVIDAD
ADD CONSTRAINT FK_EMPLEADO_ACTIVIDAD
FOREIGN KEY(AC_FK_EMPLEADO)
REFERENCES EMPLEADO(E_CORREO);

ALTER TABLE ACTIVIDAD
ADD CONSTRAINT FK_INCIDENTE_ACTIVIDAD
FOREIGN KEY(AC_FK_INCIDENTE)
REFERENCES INCIDENTE(I_ID);

ALTER TABLE INCIDENTE
ADD CONSTRAINT FK_INCIDENTE_EQUIPO
FOREIGN KEY(I_FK_EQUIPO)
REFERENCES EQUIPO(EQ_SERIAL);

ALTER TABLE INCIDENTE
ADD CONSTRAINT FK_INCIDENTE_CLIENTE
FOREIGN KEY(I_FK_CLIENTE)
REFERENCES CLIENTE(C_CORREO);

ALTER TABLE INCIDENTE
ADD CONSTRAINT FK_INCIDENTE_ALIADO
FOREIGN KEY(I_FK_ALIADO)
REFERENCES ALIADO(A_CORREO);

ALTER TABLE INCIDENTE
ADD CONSTRAINT FK_INCIDENTE_EMPLEADO
FOREIGN KEY(I_FK_EMPLEADO)
REFERENCES EMPLEADO(E_CORREO);