using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Comun
{
    public class ResultadoBD
    {
        public string etiqueta { get; set; }
        public string valor { get; set; }

        public ResultadoBD(string etiqueta, string valor)
        {
            this.etiqueta = etiqueta;
            this.valor = valor;
        }
    }
}