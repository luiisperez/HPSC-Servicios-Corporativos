using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloClientes
{
    public class ConsultarContratosCliente : Comando
    {
        String id;
        public List<Contrato> contratos = FabricaObjetos.CrearListaContratos();
        public ConsultarContratosCliente(String _id)
        {
            this.id = _id;
        }
        public override void ejecutar()
        {
            try
            {
                DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                contratos = basedatos.ConsultarContratos(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}