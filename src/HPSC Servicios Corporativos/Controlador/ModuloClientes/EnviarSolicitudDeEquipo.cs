using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloClientes
{
    public class EnviarSolicitudDeEquipo:Comando
    {
        SolicitudEquipo nuevasolicitud;
        String cliente;
        public EnviarSolicitudDeEquipo(SolicitudEquipo _solicitud, String _cliente)
        {
            this.nuevasolicitud = _solicitud;
            this.cliente = _cliente;
        }
        public override void ejecutar()
        {
            try
            {
                Mail cmd = new Mail();
                cmd.EnviarSolicitud(nuevasolicitud, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}