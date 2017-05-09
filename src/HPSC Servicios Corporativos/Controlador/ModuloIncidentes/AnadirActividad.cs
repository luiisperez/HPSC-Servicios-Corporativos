using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class AnadirActividad:Comando
    {
        String actividad;
        String fechahorainicio;
        String fechahorafin;
        String empleado;
        String idincidente;
        public AnadirActividad(String _actividad, String _inicio, String _fin, String _empleado, String _idincidente)
        {
            this.actividad = _actividad;
            this.fechahorainicio = _inicio;
            this.fechahorafin = _fin;
            this.empleado = _empleado;
            this.idincidente = _idincidente;
        }
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                basedatos.AnadirActividad(actividad, fechahorainicio, fechahorafin, empleado, idincidente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}