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

        public static List<Equipo> CrearListaEquipos()
        {
            return new List<Equipo>();
        }

        public static SolicitudEquipo CrearSolicitudDeEquipo(Equipo _equipo, String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil)
        {
            return new SolicitudEquipo(_equipo, _correo, _nombre, _apellido, _telflocal, _telfmovil);
        }
    }
}