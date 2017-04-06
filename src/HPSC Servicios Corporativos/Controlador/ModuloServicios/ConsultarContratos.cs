using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ConsultarContratos:Comando
    {
        String id;
        public List<Contrato> contratos = FabricaObjetos.CrearListaContratos();
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                contratos = basedatos.ConsultarContratos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}