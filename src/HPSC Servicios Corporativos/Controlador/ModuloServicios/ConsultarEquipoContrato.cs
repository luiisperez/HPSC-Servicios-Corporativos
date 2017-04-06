using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ConsultarEquipoContrato:Comando
    {
        String id;
        public List<Equipo> lista = FabricaObjetos.CrearListaEquipos();
        public ConsultarEquipoContrato(String _id)
        {
            this.id = _id;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                lista = basedatos.ConsultarEquiposContrato(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}