using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Servicio
    {
        public String identificador { get; set; }
        public String nivelservicio { get; set; }
        public String tiposervicio { get; set; }
        public int tiemporespuesta { get; set; }
        public int feriado_si_no { get; set; }
        public String dias { get; set; }
        public int canthoras { get; set; }
        public String disponibilidad { get; set; }
        public String feriado { get; set; }
        public DateTime fechaini { get; set; }
        public DateTime fechafin { get; set; }
        public String estatus { get; set; }
        public int cantdias { get; set; }
        public String identificadorservicioequipo { get; set; } 

        public Servicio(String _identificador, String _nivelservicio, String _tiposervicio, int _tiemporesp, String _feriado, String _dias, int _canthoras, String _disponibilidad)
        {
            this.identificador = _identificador;
            this.nivelservicio = _nivelservicio;
            this.tiposervicio = _tiposervicio;
            this.tiemporespuesta = _tiemporesp;
            this.feriado = _feriado;
            this.dias = _dias;
            this.canthoras = _canthoras;
            this.disponibilidad = _disponibilidad;
        }

        public Servicio(String _nivelservicio, String _tiposervicio, int _tiemporesp, int _feriado, String _dias, int _canthoras)
        {
            this.nivelservicio = _nivelservicio;
            this.tiposervicio = _tiposervicio;
            this.tiemporespuesta = _tiemporesp;
            this.feriado_si_no = _feriado;
            this.dias = _dias;
            this.canthoras = _canthoras;
        }

        public Servicio(String _identificador, String _nivelservicio, String _tiposervicio, int _tiemporesp, String _feriado, String _dias, int _canthoras, DateTime _fechaini, DateTime _fechafin, String _estatus, String _identificadorservicioequipo)
        {
            this.identificador = _identificador;
            this.nivelservicio = _nivelservicio;
            this.tiposervicio = _tiposervicio;
            this.tiemporespuesta = _tiemporesp;
            this.feriado = _feriado;
            this.dias = _dias;
            this.canthoras = _canthoras;
            this.identificadorservicioequipo = _identificadorservicioequipo;
            this.estatus = _estatus;
            this.fechafin = _fechafin;
            this.fechaini = _fechaini;
        }
    }
}