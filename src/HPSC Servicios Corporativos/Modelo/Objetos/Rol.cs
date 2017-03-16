using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Rol
    {
        public String id { get; set; }
        public String nombre { get; set; }
        public String privilegio { get; set; }

        public Rol(String _id, String _nombre, String _privilegio)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.privilegio = _privilegio;
        }
    }
}