using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class ActualizarFechaAtencion:Comando
    {
        String fechaatencion;
        String id;
        public ActualizarFechaAtencion(String _fechaatencion, String _id)
        {
            this.id = _id;
            this.fechaatencion = _fechaatencion;
        }
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.ActualizarFechaAtencion(fechaatencion, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}