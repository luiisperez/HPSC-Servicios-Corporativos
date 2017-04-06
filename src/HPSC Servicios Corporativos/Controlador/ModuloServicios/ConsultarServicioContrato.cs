using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ConsultarServicioContrato:Comando
    {
        String id;
        public List<Servicio> lista = FabricaObjetos.CrearListaServicios();
        public ConsultarServicioContrato(String _id)
        {
            this.id = _id;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                lista = basedatos.ConsultarServiciosContrato(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}