using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Servicio
    {
        public int identificador { get; set; }
        public String nivelservicio { get; set; }
        public String tiposervicio { get; set; }
        public int tiemporespuesta { get; set; }
        public int feriado_si_no { get; set; }
        public int cantdias { get; set; }
        public int canthoras { get; set; }
        public String disponibilidad { get; set; }

        public Servicio(int _identificador, String _nivelservicio, String _tiposervicio, int _tiemporesp, int _feriado, int _cantdias, int _canthoras, String _disponibilidad)
        {
            this.identificador = _identificador;
            this.nivelservicio = _nivelservicio;
            this.tiposervicio = _tiposervicio;
            this.tiemporespuesta = _tiemporesp;
            this.feriado_si_no = _feriado;
            this.cantdias = _cantdias;
            this.canthoras = _canthoras;
            this.disponibilidad = _disponibilidad;
        }

        public Servicio(String _nivelservicio, String _tiposervicio, int _tiemporesp, int _feriado, int _cantdias, int _canthoras)
        {
            this.nivelservicio = _nivelservicio;
            this.tiposervicio = _tiposervicio;
            this.tiemporespuesta = _tiemporesp;
            this.feriado_si_no = _feriado;
            this.cantdias = _cantdias;
            this.canthoras = _canthoras;
        }
    }
}