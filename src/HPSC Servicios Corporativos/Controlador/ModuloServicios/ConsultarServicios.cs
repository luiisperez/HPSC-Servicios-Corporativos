using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ConsultarServicios:Comando
    {
        public List<Servicio> servicios;
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                servicios = basedatos.ConsultarServicios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}