using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados
{
    public class AgregarCliente:Comando
    {
        Cliente newcliente;
        public AgregarCliente(Cliente _cliente)
        {
            this.newcliente = _cliente;
        }
        public override void ejecutar()
        {
            try
            {
                DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                basedatos.Agregar(newcliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}