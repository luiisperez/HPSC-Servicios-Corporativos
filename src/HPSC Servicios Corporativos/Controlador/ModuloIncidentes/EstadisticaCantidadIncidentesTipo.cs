using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class EstadisticaCantidadIncidentesTipo : Comando
    {
        public List<String> listado;
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                listado = basedatos.ConsultarIncidentesPorTipo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}