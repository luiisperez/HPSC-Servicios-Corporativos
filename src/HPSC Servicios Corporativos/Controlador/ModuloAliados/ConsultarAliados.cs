using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloAliado;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloAliados
{
    public class ConsultarAliados:Comando
    {
        public List<Aliado> listado = FabricaObjetos.CrearListaAliados();
        public override void ejecutar()
        {
            try
            {
                DAOAliado basedatos = FabricaDAO.CrearDAOAliado();
                listado = basedatos.ConsultarAliados();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}