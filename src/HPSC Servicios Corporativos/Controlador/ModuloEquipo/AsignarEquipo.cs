using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class AsignarEquipo:Comando
    {
        String serial;
        String cliente;
        public AsignarEquipo(String _cliente, String _serial)
        {
            this.serial = _serial;
            this.cliente = _cliente;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                basedatos.AsignarEquipo(cliente, serial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}