using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class ConsultarEquiposLibres:Comando
    {
        public List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
        public override void ejecutar()
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                equipos = basedatos.ConsultarEquiposLibres();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}