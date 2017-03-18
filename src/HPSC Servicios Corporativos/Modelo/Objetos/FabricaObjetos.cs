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
    }
}