----------------------SERVICIO--------------------------
------------------------ROL-----------------------------
INSERT INTO ROL VALUES (1, 'Administrador', 20);
INSERT INTO ROL VALUES (2, 'Sin rol', -1);
INSERT INTO ROL VALUES (3, 'Cliente', -10);
INSERT INTO ROL VALUES (4, 'Eliminado', -100);
INSERT INTO ROL VALUES (5, 'Coordinador de servicios', 10);
INSERT INTO ROL VALUES (6, 'Ingeniero de soporte', 10);
INSERT INTO ROL VALUES (7, 'Aliado', -5);

----------------------CLIENTE---------------------------
INSERT INTO CLIENTE VALUES ('luis.alejandro120895@gmail.com', 'Kikiriskiaga CA', 'Kikiriskiaga128', 'F9F299C9FE7AE645AE722D2B2E1965AE', 'Av. Ohiggins, La Paz', 3);

----------------------ALIADO (MODIFICAR A CONVENIENCIA)---------------------------
INSERT INTO ALIADO VALUES ('info@cronsistemas.com.ve', 'CRON Sistemas, C.A.', 'cronsistemas', 'B96C0ADF7B666E8C839A771D1416B6DF', 'Av. 19 con calle 72, Edificio Marta Planta Baja Local 4. Maracaibo, Estado Zulia. Venezuela', 7); /*Clave CronSistemas.17*/
INSERT INTO ALIADO VALUES ('correodeprueba@gmail.com', 'Armando José Gil González', 'armando.17', '4037D798A00635112FD5F75616C47525', 'Direccion provicional', 7); /*Clave Armando.17*/
INSERT INTO ALIADO VALUES ('correodeprueba1@gmail.com', 'José Antonio Díaz González', 'jadiaz.17', 'B8828AF52ABCBDAF70824E29AEA9FC13', 'Direccion provicional', 7); /*Clave Jadiaz.17*/
INSERT INTO ALIADO VALUES ('correodeprueba2@gmail.com', 'MEGAPC Sistemas, C.A.', 'megapc', 'A316A44ACFB8E4E25B039F64FEB00808', 'Direccion provicional', 7); /*Clave Megapc.17*/
INSERT INTO ALIADO VALUES ('correodeprueba3@gmail.com', 'Miguel Angel Coronado Silva', 'macoronado.17', '7E2FE1B17D674B4FA9CDA09C3B3AB5A5', 'Direccion provicional', 7); /*Clave Macoronado.17*/
INSERT INTO ALIADO VALUES ('correodeprueba4@gmail.com', 'Pro Sistemas, C.A.', 'prosistemas', 'EE1CABDD6F547F2C00FBDD6971D03589', 'Direccion provicional', 7); /*Clave Prosistemas.17*/
INSERT INTO ALIADO VALUES ('correodeprueba5@gmail.com', 'Services Computer FyE, C.A.', 'servcompfe', '9070BCB05D7DFFC3B44ED40992E7D982', 'Direccion provicional', 7); /*Clave Servcompfe.17*/
INSERT INTO ALIADO VALUES ('correodeprueba6@gmail.com', 'Servicios Especializados G & B', 'servespgb', '6F2BD50A49D3B0D0136B9BD3C7FE343B', 'Direccion provicional', 7); /*Clave Servespgb.17*/
INSERT INTO ALIADO VALUES ('correodeprueba7@gmail.com', 'Servicios KOMPU 9000, C.A.', 'kompu9000', 'E44D7CF877A94E14A357C1A244E445E5', 'Direccion provicional', 7); /*Clave Kompu9000.17*/

----------------------EMPLEADO--------------------------
INSERT INTO EMPLEADO VALUES ('luis.alejandro120895@gmail.com', 'Luis', 'Perez', 'LAPGrock', 'F9F299C9FE7AE645AE722D2B2E1965AE', 1);
INSERT INTO EMPLEADO VALUES ('jose.torres@hp-sc.net', 'José', 'Torres', 'JoseTorres', '5BD5658E1D7D0D3C39FDC107AD2D4AA5', 1);
INSERT INTO EMPLEADO VALUES ('admin', 'Administrador', 'del sistema', 'admin', '5BD5658E1D7D0D3C39FDC107AD2D4AA5', 1); /* Clave HpscAdmin0.*/
INSERT INTO EMPLEADO VALUES ('pepito1208295@gmail.com', 'Luis', 'Sumatra', 'LAPG', 'F9F299C9FE7AE645AE722D2B2E1965AE', 2);
INSERT INTO EMPLEADO VALUES ('jjuanito120895@gmail.com', 'Sanson', 'Perez', 'LAPGrock55454', 'F9F299C9FE7AE645AE722D2B2E1965AE', 2);
INSERT INTO EMPLEADO VALUES ('jjuanitoffff120895@gmail.com', 'Gepeto', 'Perez', 'LAPGrock55fff454', 'F9F299C9FE7AE645AE722D2B2E1965AE', 2);

------------------------MARCA---------------------------
INSERT INTO MARCA VALUES ('IBM');
INSERT INTO MARCA VALUES ('Dell');
INSERT INTO MARCA VALUES ('Hewlett-Packard');

----------------------PRODUCTO---------------------------
INSERT INTO PRODUCTO VALUES ('CC477A', 'Impresoras', 'HP Laserjet M3035XS Multifunction Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CB426A', 'Impresoras', 'HP Laserjet 4345 MFP Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CE991A', 'Impresoras', 'HP Laserjet Enterprise 600 Printer M602N', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('Q7831A', 'Impresoras', 'HP Laserjet M5035XS Multifunction Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CE738A', 'Impresoras', 'HP Laserjet Enterprise M4555H MFP', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CD645A', 'Impresoras', 'HP Laserjet M575F Color', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('Q5403A', 'Impresoras', 'HP Laserjet 4250DTN Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CF082A', 'Impresoras', 'HP Laserjet Enterprise 500 Color Printer M551DN', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CB511A', 'Impresoras', 'HP Laserjet P4015X Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CF081A', 'Impresoras', 'HP Laserjet Enterprise 500 Color Printer M551N', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CB516A', 'Impresoras', 'HP Laserjet P4515X Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('DUMM001', 'Servidores', 'Serial Ficticio para casos sin equipo', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CF145A', 'Impresoras', 'HP Laserjet PRO 200 Color MFP M276NW', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CC470A', 'Impresoras', 'HP Color Laserjet CP3525DN Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CB532A', 'Impresoras', 'HP Laserjet M2727NF Multifunction Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('B5L05A', 'Impresoras', 'HP Officejet Color MFP X585', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CE994A', 'Impresoras', 'HP Laserjet Enterprise 600 Printer M603N', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CC520A', 'Impresoras', 'HP Color Laserjet CM3530 MFP', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CE528A', 'Impresoras', 'HP Laserjet P3010 SERIES', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CB442A', 'Impresoras', 'HP Color Laserjet CP3505N Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('CC494A', 'Impresoras', 'HP Color Laserjet Enterprise CP4525DN Printer', 'Hewlett-Packard');
INSERT INTO PRODUCTO VALUES ('Q3723A', 'Impresoras', 'HP Laserjet 9050DN Printer', 'Hewlett-Packard');

-----------------------EQUIPO---------------------------
INSERT INTO EQUIPO VALUES ('FGDFS3432S', 'Impresoras', 'Hewlett-Packard', 'HP Laserjet M3035XS Multifunction Printer', 'Operativo', 'CC477A', 'Av. Ohiggins, La Paz', 'luis.alejandro120895@gmail.com');
INSERT INTO EQUIPO VALUES ('FGDFS343DFGDFGS', 'Impresoras', 'Hewlett-Packard', 'HP Laserjet M3035XS Multifunction Printer', 'Operativo', 'CC477A', 'Av. Ohiggins, La Paz', 'luis.alejandro120895@gmail.com');
INSERT INTO EQUIPO VALUES ('FGDFS343DFGD2S', 'Impresoras', 'Hewlett-Packard', 'HP Laserjet M3035XS Multifunction Printer', 'Operativo', 'CC477A', 'Av. Ohiggins, La Paz', 'luis.alejandro120895@gmail.com');
INSERT INTO EQUIPO VALUES ('FGDFS343DFGFDGD2S', 'Impresoras', 'Hewlett-Packard', 'HP Laserjet M3035XS Multifunction Printer', 'Operativo', 'CC477A', 'Av. Ohiggins, La Paz', 'luis.alejandro120895@gmail.com');

----------------------SERVICIO--------------------------
INSERT INTO SERVICIO VALUES ('20173301944', 'Garantía Premium', 'Soporte reactivo', 24, 0, 'Lunes,Martes,Miércoles,Viernes', 9, 'Disponible');
INSERT INTO SERVICIO VALUES ('20173301945', 'Garantía Estándar', 'Implementación', 72, 0, 'Lunes,Martes,Miércoles,Viernes', 15, 'Disponible');

----------------------FERIADOS--------------------------
INSERT INTO FERIADO VALUES (1, 'Año Nuevo', 1, 1);
INSERT INTO FERIADO VALUES (2, 'Lunes de Carnaval', 27, 2);
INSERT INTO FERIADO VALUES (3, 'Martes de Carnaval', 28, 2);
INSERT INTO FERIADO VALUES (4, 'Jueves Santo', 13, 4);
INSERT INTO FERIADO VALUES (5, 'Viernes Santo', 14, 4);
INSERT INTO FERIADO VALUES (6, 'Domingo de resurreción', 16, 4);
INSERT INTO FERIADO VALUES (7, 'Declaración de la Independencia', 19, 4);
INSERT INTO FERIADO VALUES (8, 'Día del Trabajo', 1, 5);
INSERT INTO FERIADO VALUES (9, 'Batalla de Carabobo', 24, 6);
INSERT INTO FERIADO VALUES (10, 'Día de la Independencia', 5, 7);
INSERT INTO FERIADO VALUES (11, 'Natalicio de Simón Bolívar', 24, 7);
INSERT INTO FERIADO VALUES (12, 'Día de la Resistencia Indígena', 12, 10);
INSERT INTO FERIADO VALUES (13, 'Víspera de Navidad', 24, 12);
INSERT INTO FERIADO VALUES (14, 'Navidad', 25, 12);
INSERT INTO FERIADO VALUES (15, 'Fin de Año', 24, 12);