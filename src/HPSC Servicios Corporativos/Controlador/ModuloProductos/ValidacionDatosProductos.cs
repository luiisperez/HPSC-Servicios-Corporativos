using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloProductos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloProductos
{
    public class ValidacionDatosProductos
    {
        public bool verificarnumequipo(String numequipo)
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                Equipo equipoConsultado = basedatos.ConsultarEquipoNumero(numequipo);
                if ((equipoConsultado == null))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<String> listadomarcas()
        {
            try
            {
                DAOProducto basedatos = FabricaDAO.CrearDAOProducto();
                List<String> marcasConsultadas = basedatos.ConsultarMarcas();
                return marcasConsultadas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}