using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class PersonaContacto
    {
        public String cliente { get; set; }
        public String correo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String telflocal { get; set; }
        public String telfmovil { get; set; }
        public String estatus { get; set; }

        public PersonaContacto(String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil, String _cliente)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.telflocal = _telflocal;
            this.telfmovil = _telfmovil;
            this.cliente = _cliente;
        }

        public PersonaContacto(String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil, String _estatus, String _cliente)
        {
            this.correo = _correo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.telflocal = _telflocal;
            this.telfmovil = _telfmovil;
            this.cliente = _cliente;
            this.estatus = _estatus;
        }
    }
}