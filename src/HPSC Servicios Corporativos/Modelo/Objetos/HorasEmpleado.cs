using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class HorasEmpleado
    {
        public String empleado { get; set; }
        public double horaslaborables { get; set; }
        public double horasdiurnas { get; set; }
        public double horasnocturnas { get; set; }

        public HorasEmpleado(String _emp)
        {
            this.empleado = _emp;
        }
    }
}