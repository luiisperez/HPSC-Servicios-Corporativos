using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Incidente
    {
        public String id { get; set; }
        public DateTime fecharegistro { get; set; }
        public DateTime fecharegistroreal { get; set; }
        public DateTime fechacompromiso { get; set; }
        public DateTime fecharequerida { get; set; }
        public DateTime fechaatencion { get; set; }
        public DateTime fechafinservicio { get; set; }
        public String estatus { get; set; }
        public String tiposerv { get; set; }
        public String impacto { get; set; }
        public String urgencia { get; set; }
        public String direccion { get; set; }
        public String descripcion { get; set; }
        public String cliente { get; set; }
        public String equipo { get; set; }
        public String empleado { get; set; }
        public String aliado { get; set; }
        public String contacto1 { get; set; }
        public String contacto2 { get; set; }
        public String contrato { get; set; }
        public String servicio { get; set; }

        public Incidente()
        {

        }

        public Incidente(String _id, DateTime _fecharegistro, DateTime _compromiso, DateTime _requerida, DateTime _atencion, DateTime _finservicio, 
                         String _estatus, String _tiposerv, String _impacto, String _urgencia, String _direccion, String _descripcion, String _cliente,
                         String _equipo, String _empleado, String _aliado, String _contacto1, String _contacto2, String _contrato, String _servicio)
        {
            this.id = _id;
            this.fecharegistro = _fecharegistro;
            this.fechacompromiso = _compromiso;
            this.fecharequerida = _requerida;
            this.fechaatencion = _atencion;
            this.fechafinservicio = _finservicio;
            this.estatus = _estatus;
            this.tiposerv = _tiposerv;
            this.impacto = _impacto;
            this.urgencia = _urgencia;
            this.direccion = _direccion;
            this.descripcion = _descripcion;
            this.cliente = _cliente;
            this.equipo = _equipo;
            this.empleado = _empleado;
            this.aliado = _aliado;
            this.contacto1 = _contacto1;
            this.contacto2 = _contacto2;
            this.contrato = _contrato;
            this.servicio = _servicio;
        }

    }
}