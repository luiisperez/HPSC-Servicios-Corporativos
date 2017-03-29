using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloProductos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloProductos
{
    public class ConsultarProductos:Comando
    {
        public List<Equipo> equipos =FabricaObjetos.CrearListaEquipos();
        public override void ejecutar()
        {
            try
            {
                DAOProducto basedatos = FabricaDAO.CrearDAOProducto();
                equipos = basedatos.ConsultarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}