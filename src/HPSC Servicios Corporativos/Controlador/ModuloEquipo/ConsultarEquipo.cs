using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class ConsultarEquipo:Comando
    {
        public Equipo equipoConsultado;
        String serial;
        public ConsultarEquipo(String _serial)
        {
            this.serial = _serial;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                equipoConsultado = basedatos.ConsultarEquipoSerial(serial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}