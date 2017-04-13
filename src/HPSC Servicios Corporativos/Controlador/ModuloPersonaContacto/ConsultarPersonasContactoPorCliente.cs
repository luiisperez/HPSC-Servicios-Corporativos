using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto
{
    public class ConsultarPersonasContactoPorCliente:Comando
    {
        String correo;
        public List<PersonaContacto> listado; 
        public ConsultarPersonasContactoPorCliente(String _correo)
        {
            this.correo = _correo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOPersonaContacto basedatos = FabricaDAO.CrearDAOPersonaContacto();
                listado = basedatos.ConsultarPersonasContactoPorCliente(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}