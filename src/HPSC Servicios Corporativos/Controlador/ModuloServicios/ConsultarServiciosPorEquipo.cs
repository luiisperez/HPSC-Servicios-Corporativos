using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ConsultarServiciosPorEquipo:Comando
    {
        String id;
        public List<Servicio> servicios;
        public ConsultarServiciosPorEquipo(String _id)
        {
            this.id = _id;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                servicios = basedatos.ConsultarServiciosPorEquipo(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}