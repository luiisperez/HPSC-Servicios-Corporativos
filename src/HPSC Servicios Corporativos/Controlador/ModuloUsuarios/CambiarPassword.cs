using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class CambiarPassword:Comando
    {
        String password;
        String correo;
        String tipo;
        public CambiarPassword(String _pwd, String _correo, String _tipo)
        {
            this.correo = _pwd;
            this.password = _correo;
            this.tipo = _tipo;
        }
        public override void ejecutar()
        {
            try 
            {
                if (tipo.Equals("Empleado")){
                    DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                    basedatos.Cambiarpwd(correo, password);
                }
                else if (tipo.Equals("Cliente"))
                {
                    DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                    basedatos.Cambiarpwd(correo, password);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}