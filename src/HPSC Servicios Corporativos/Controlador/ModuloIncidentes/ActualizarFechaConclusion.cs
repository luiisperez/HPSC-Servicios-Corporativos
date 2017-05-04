using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class ActualizarFechaConclusion:Comando
    {
        String fechaconclusion;
        String id;
        public ActualizarFechaConclusion(String _fechaconclusion, String _id)
        {
            this.id = _id;
            this.fechaconclusion = _fechaconclusion;
        }
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.ActualizarFechaConclusion(fechaconclusion, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}