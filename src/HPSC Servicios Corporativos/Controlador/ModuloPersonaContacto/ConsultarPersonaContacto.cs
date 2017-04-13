using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto
{
    public class ConsultarPersonaContacto:Comando
    {
        String correo;
        public PersonaContacto consultado; 
        public ConsultarPersonaContacto(String _correo)
        {
            this.correo = _correo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOPersonaContacto basedatos = FabricaDAO.CrearDAOPersonaContacto();
                consultado = basedatos.ConsultarPersonaContacto(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}