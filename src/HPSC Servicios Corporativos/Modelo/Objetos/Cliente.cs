using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Cliente
    {
        public String correo { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }
        public String rol { get; set; }

        public Cliente(String _correo, String _nombre, String _direccion, String _usuario, String _contrasena)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.direccion = _direccion;
            this.usuario = _usuario;
            this.contrasena = _contrasena;
        }

        public Cliente(String _correo, String _nombre, String _direccion, String _usuario, String _contrasena, String _rol)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.direccion = _direccion;
            this.usuario = _usuario;
            this.contrasena = _contrasena;
            this.rol = _rol;
        }
    }
}