using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class EliminarEquipo:Comando
    {
        Equipo eqeliminar;
        public EliminarEquipo(Equipo _eqeliminar)
        {
            this.eqeliminar = _eqeliminar;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                basedatos.Eliminar(eqeliminar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}