using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class AgregarIncidente:Comando
    {
        Incidente incidente;

        public AgregarIncidente(Incidente _incidente)
        {
            this.incidente = _incidente;
        }
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.Agregar(incidente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}