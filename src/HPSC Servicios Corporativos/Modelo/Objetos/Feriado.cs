using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Feriado
    {
        public String descripcion { get; set; }
        public int dia { get; set; }
        public int mes{ get; set; }

        public Feriado(String _descripcion, int _dia, int _mes)
        {
            this.descripcion = _descripcion;
            this.dia = _dia;
            this.mes = _mes;
        }
    }
}