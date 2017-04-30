using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class EnviarCorreoIncidenteRegistrado:Comando
    {
        Incidente nuevoincidente;
        String cliente;
        public EnviarCorreoIncidenteRegistrado(Incidente _nuevoincidente, String _cliente)
        {
            this.nuevoincidente = _nuevoincidente;
            this.cliente = _cliente;
        }
        public override void ejecutar()
        {
            try
            {
                Mail cmd = new Mail();
                cmd.EnviarIncidente(nuevoincidente, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}