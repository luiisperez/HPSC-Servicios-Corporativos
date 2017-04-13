using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto
{
    public class ModificarPersonaContacto:Comando
    {
        PersonaContacto persona;
        String correoviejo;
        public ModificarPersonaContacto(PersonaContacto _persona, String _correoviejo)
        {
            this.persona = _persona;
            this.correoviejo = _correoviejo;

        }
        public override void ejecutar()
        {
            try
            {
                DAOPersonaContacto basedatos = FabricaDAO.CrearDAOPersonaContacto();
                basedatos.Modificar(persona, correoviejo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}