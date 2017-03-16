using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class AsignarRol:Comando
    {
        String correo;
        String rol;

        public AsignarRol(String _correo, String _rol)
        {
            this.correo = _correo;
            this.rol = _rol;
        }
        public override void ejecutar()
        {
            DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
            try
            {
                basedatos.AsignarRol(correo, rol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}