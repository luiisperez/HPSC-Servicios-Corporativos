using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class FabricaObjetos
    {
        public static Empleado CrearEmpleado(String _correo, String _nombre, String _apellido, String _usuario, String _contrasena)
        {
            return new Empleado(_correo, _nombre, _apellido, _usuario, _contrasena);
        }

        public static Empleado CrearEmpleado(String _correo, String _nombre, String _apellido, String _usuario, String _contrasena, String _rol)
        {
            return new Empleado(_correo, _nombre, _apellido, _usuario, _contrasena, _rol);
        }

        public static List<Empleado> CrearListaEmpleados()
        {
            return new List<Empleado>();
        }

        public static List<Rol> CrearListaRoles()
        {
            return new List<Rol>();
        }

        public static Rol CrearRol(String _id, String _nombre, String _privilegio)
        {
            return new Rol(_id, _nombre, _privilegio);
        }

        public static Cliente CrearCliente(String _correo, String _nombre, String _direccion, String _usuario, String _contrasena)
        {
            return new Cliente(_correo, _nombre, _direccion, _usuario, _contrasena);
        }

        public static Cliente CrearCliente(String _correo, String _nombre, String _direccion, String _usuario, String _contrasena, String _rol)
        {
            return new Cliente(_correo, _nombre, _direccion, _usuario, _contrasena, _rol);
        }

        internal static List<Cliente> CrearListaClientes()
        {
            return new List<Cliente>();
        }

        public static Equipo CrearEquipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo, String _cliente)
        {
            return new Equipo(_serial, _numeroequipo, _categoria, _marca, _modelo, _cliente);
        }

        public static Equipo CrearEquipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo)
        {
            return new Equipo(_serial, _numeroequipo, _categoria, _marca, _modelo);
        }

        public static Equipo CrearEquipo(String _categoria, String _marca, String _modelo)
        {
            return new Equipo(_categoria, _marca, _modelo);
        }

        public static Equipo CrearEquipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo, String _cliente, String _estatus)
        {
            return new Equipo(_serial, _numeroequipo, _categoria, _marca, _modelo, _cliente, _estatus);
        }

        public static List<Equipo> CrearListaEquipos()
        {
            return new List<Equipo>();
        }

        public static SolicitudEquipo CrearSolicitudDeEquipo(Equipo _equipo, String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil)
        {
            return new SolicitudEquipo(_equipo, _correo, _nombre, _apellido, _telflocal, _telfmovil);
        }

        public static Equipo CrearEquipo(String _numequipo, String _categoria, String _marca, String _modelo)
        {
            return new Equipo(_numequipo, _categoria, _modelo, _marca);
        }

        public static Servicio CrearServicio(String _identificador, String _nivelservicio, String _tiposervicio, int _tiemporesp, String _feriado, String _dias, int _canthoras, String _disponibilidad)
        {
            return new Servicio(_identificador, _nivelservicio, _tiposervicio, _tiemporesp, _feriado, _dias, _canthoras, _disponibilidad);
        }

        public static Servicio CrearServicio(String _nivelservicio, String _tiposervicio, int _tiemporesp, int _feriado, String _dias, int _canthoras)
        {
            return new Servicio(_nivelservicio, _tiposervicio, _tiemporesp, _feriado, _dias, _canthoras);
        }

        public static Servicio CrearServicio(String _identificador, String _nivelservicio, String _tiposervicio, int _tiemporesp, String _feriado, String _dias, int _canthoras, DateTime _fechaini, DateTime _fechafin, String _estatus, String _identificadorservicioequipo)
        {
            return new Servicio(_identificador, _nivelservicio, _tiposervicio, _tiemporesp, _feriado, _dias, _canthoras, _fechaini, _fechafin, _estatus, _identificadorservicioequipo);
        }

        public static List<Servicio> CrearListaServicios()
        {
            return new List<Servicio>();
        }

        public static Contrato CrearContrato(String _id, String _cliente, DateTime _fechaini, DateTime _fechafin)
        {
            return new Contrato(_id, _cliente, _fechaini, _fechafin);
        }

        public static List<Contrato> CrearListaContratos()
        {
            return new List<Contrato>();
        }

        public static PersonaContacto CrearPersonaContacto(String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil, String _cliente)
        {
            return new PersonaContacto(_correo, _nombre, _apellido, _telflocal, _telfmovil,  _cliente);
        }

        public static PersonaContacto CrearPersonaContacto(String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil, String _estatus, String _cliente)
        {
            return new PersonaContacto(_correo, _nombre, _apellido, _telflocal, _telfmovil, _estatus, _cliente);
        }

        public static List<PersonaContacto> CrearListaPersonaContacto()
        {
            return new List<PersonaContacto>();
        }

        public static List<Feriado> CrearListaFeriados()
        {
            return new List<Feriado>();
        }

        public static Feriado CrearFeriado(String _descripcion, int _dia, int _mes)
        {
            return new Feriado(_descripcion, _dia, _mes);
        }

        public static Incidente CrearIncidente(String _id, DateTime _fecharegistro, DateTime _compromiso, DateTime _requerida, DateTime _atencion, DateTime _finservicio, 
                         String _estatus, String _tiposerv, String _impacto, String _urgencia, String _direccion, String _descripcion, String _cliente,
                         String _equipo, String _empleado, String _aliado, String _contacto1, String _contacto2, String _contrato, String _servicio)
        {
            return new Incidente(_id, _fecharegistro, _compromiso, _requerida, _atencion, _finservicio,
                                 _estatus, _tiposerv, _impacto, _urgencia, _direccion, _descripcion, _cliente,
                                 _equipo, _empleado, _aliado, _contacto1, _contacto2, _contrato, _servicio);
        }

        public static List<Incidente> CrearListaIncidentes()
        {
            return new List<Incidente>();
        }

        
    }
}