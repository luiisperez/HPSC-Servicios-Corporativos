
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto
{
    public class AgregarPersonaContacto:Comando
    {
        PersonaContacto persona;
        public AgregarPersonaContacto(PersonaContacto _persona)
        {
            this.persona = _persona;
        }
        public override void ejecutar()
        {
            try
            {
                DAOPersonaContacto basedatos = FabricaDAO.CrearDAOPersonaContacto();
                basedatos.Agregar(persona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}