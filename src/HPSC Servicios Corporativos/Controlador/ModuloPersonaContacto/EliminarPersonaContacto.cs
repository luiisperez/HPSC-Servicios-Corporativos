using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto
{
    public class EliminarPersonaContacto:Comando
    {
        String correo;

        public EliminarPersonaContacto(String _correo)
        {
            this.correo = _correo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOPersonaContacto basedatos = FabricaDAO.CrearDAOPersonaContacto();
                basedatos.Eliminar(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}