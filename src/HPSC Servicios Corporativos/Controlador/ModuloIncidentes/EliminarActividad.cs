using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class EliminarActividad:Comando
    {
        String idact;

        public EliminarActividad(String _idact)
        {
            this.idact = _idact;
        }


        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.EliminarActividad(idact);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}