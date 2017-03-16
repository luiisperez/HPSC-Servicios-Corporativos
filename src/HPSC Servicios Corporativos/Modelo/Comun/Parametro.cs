using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Comun
{
    public class Parametro
    {
        public string etiqueta { get; set; }
        public SqlDbType tipoDato { get; set; }
        public string valor { get; set; }
        public bool esOutput { get; set; }

        public Parametro()
        {
        }

        public Parametro(string etiqueta, SqlDbType tipoDato, string valor, bool esOutput)
        {
            this.etiqueta = etiqueta;
            this.tipoDato = tipoDato;
            this.valor = valor;
            this.esOutput = esOutput;
        }
        public Parametro(string etiqueta, SqlDbType tipoDato, bool esOutput)
        {
            this.etiqueta = etiqueta;
            this.tipoDato = tipoDato;
            this.esOutput = esOutput;
        }
    }
}