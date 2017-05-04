using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class ActualizarAliEstImpUrg:Comando
    {
        String correo;
        String est;
        String imp;
        String urg;
        String id;
        public ActualizarAliEstImpUrg(String _correo, String _est, String _imp, String _urg, String _id)
        {
            this.id = _id;
            this.correo = _correo;
            this.est = _est;
            this.imp = _imp;
            this.urg = _urg;
        }
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.ActualizarAliEstImpUrg(correo, est, imp, urg, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}