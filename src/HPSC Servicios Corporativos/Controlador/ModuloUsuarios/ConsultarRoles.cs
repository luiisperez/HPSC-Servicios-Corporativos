using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class ConsultarRoles:Comando
    {
        public List<Rol> roles = FabricaObjetos.CrearListaRoles();
        public override void ejecutar()
        {
            try
            {
                DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                roles = basedatos.ConsultarRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}