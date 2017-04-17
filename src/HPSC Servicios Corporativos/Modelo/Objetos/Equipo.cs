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
        public String estatus { get; set; }
        public String ubicacion { get; set; }

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

        public Equipo(String _categoria, String _marca, String _modelo)
        {
            this.categoria = _categoria;
            this.marca = _marca;
            this.modelo = _modelo;
        }

        public Equipo(String _serial, String _numeroequipo, String _categoria, String _marca, String _modelo, String _cliente, String _estatus)
        {
            this.serial = _serial;
            this.numeroequipo = _numeroequipo;
            this.categoria = _categoria;
            this.marca = _marca;
            this.modelo = _modelo;
            this.cliente = _cliente;
            this.estatus = _estatus;
        }

        public Equipo(String _numequipo, String _categoria, String _marca, String _modelo)
        {
            this.categoria = _categoria;
            this.marca = _marca;
            this.modelo = _modelo;
            this.numeroequipo = _numequipo;
        }
    }
}