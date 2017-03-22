using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class SolicitudEquipo
    {
        public Equipo equipo { get; set; }
        public String correo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String telflocal { get; set; }
        public String telfmovil { get; set; }

        public SolicitudEquipo(Equipo _equipo, String _correo, String _nombre, String _apellido, String _telflocal, String _telfmovil)
        {
            this.equipo = _equipo;
            this.correo = _correo;
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.telflocal = _telflocal;
            this.telfmovil = _telfmovil;
        }
    }
}