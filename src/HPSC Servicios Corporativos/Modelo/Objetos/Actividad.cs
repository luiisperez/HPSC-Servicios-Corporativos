using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Actividad
    {
        public String id { get; set; }
        public String actividad { get; set; }
        public DateTime fechahorainicio { get; set; }
        public DateTime fechahorafin { get; set; }
        public String empleado { get; set; }
        public double horaslaborables { get; set; }
        public double horasdiurnas { get; set; }
        public double horasnocturnas { get; set; } 

        public Actividad(String _actividad, DateTime _inicio, DateTime _fin, String _empleado)
        {
            this.actividad = _actividad;
            this.fechahorainicio = _inicio;
            this.fechahorafin = _fin;
            this.empleado = _empleado;
        }

        public Actividad(String _id, String _actividad, DateTime _inicio, DateTime _fin, String _empleado)
        {
            this.id = _id;
            this.actividad = _actividad;
            this.fechahorainicio = _inicio;
            this.fechahorafin = _fin;
            this.empleado = _empleado;
        }
    }
}