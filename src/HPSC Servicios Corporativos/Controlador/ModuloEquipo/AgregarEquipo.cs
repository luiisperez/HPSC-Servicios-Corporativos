using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class AgregarEquipo:Comando
    {
        Equipo newequipo;
        public AgregarEquipo(Equipo _equipo)
        {
            this.newequipo = _equipo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                basedatos.Agregar(newequipo);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}