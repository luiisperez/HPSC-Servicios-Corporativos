using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Equipo
    {
        public String serial { get; set; }				
	    public String numeroequipo { get; set; }
        public String categoria { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String cliente { get; set; }

        public Equipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo, String _cliente)
        {
            this.serial = _serial;
            this.numeroequipo = _numeroequipo;
            this.categoria = _categoria;
            this.marca = _marca;
            this.modelo = _modelo;
            this.cliente = _cliente;
        }

        public Equipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo)
        {
            this.serial = _serial;
            this.numeroequipo = _numeroequipo;
            this.categoria = _categoria;
            this.marca = _marca;
            this.modelo = _modelo;
        }
    }
}