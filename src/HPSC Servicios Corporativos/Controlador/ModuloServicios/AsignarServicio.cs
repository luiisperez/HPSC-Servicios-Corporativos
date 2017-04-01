using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class AsignarServicio:Comando
    {
        String serial;
        String servicio;
        String fechaini;
        String fechafin;
        public AsignarServicio(String _servicio, String _serial, String _fechaini, String _fechafin)
        {
            this.serial = _serial;
            this.servicio = _servicio;
            this.fechafin = _fechafin;
            this.fechaini = _fechaini;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                basedatos.AsignarServicio(servicio, serial, fechaini, fechafin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}