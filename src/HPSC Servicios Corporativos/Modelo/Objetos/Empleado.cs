using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Empleado
    {
        public String correo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public String rol { get; set; }

        public Empleado(String _correo, String _nombre, String _apellido, String _usuario, String _contrasena)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.usuario = _usuario;
            this.contrasena = _contrasena;
        }

        public Empleado(String _correo, String _nombre, String _apellido, String _usuario, String _contrasena, String _rol)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.usuario = _usuario;
            this.contrasena = _contrasena;
            this.rol = _rol;
        }
    }
}