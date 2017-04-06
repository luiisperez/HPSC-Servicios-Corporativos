using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class Contrato
    {
        public DateTime fechaini { get; set; }
        public DateTime fechafin { get; set; }
        public String id { get; set; }
        public String cliente { get; set; }

        public Contrato(String _id, String _cliente, DateTime _fechaini, DateTime _fechafin)
        {
            this.cliente = _cliente;
            this.id = _id;
            this.fechaini = _fechaini;
            this.fechafin = _fechafin;
        }
    }
}