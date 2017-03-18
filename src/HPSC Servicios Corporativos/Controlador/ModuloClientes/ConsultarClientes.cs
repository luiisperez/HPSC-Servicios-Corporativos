using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloClientes
{
    public class ConsultarClientes:Comando
    {
        public List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
        public override void ejecutar()
        {
            try
            {
                DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                clientes = basedatos.ConsultarEmpleados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}