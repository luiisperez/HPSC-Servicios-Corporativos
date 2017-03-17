using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloClientes
{
    public class ModificarCliente:Comando
    {
        Cliente cli = null;
        public ModificarCliente(Cliente _cli)
        {
            this.cli = _cli;
        }

        public override void ejecutar()
        {
            try
            {
                DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                basedatos.Modificar(cli);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}