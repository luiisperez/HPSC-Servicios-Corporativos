using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloEquipo
{
    public class ValidacionDatosEquipos{

        public bool verificarserial(String serial)
        {
            try
            {
                DAOEquipo basedatos = FabricaDAO.CrearDAOEquipo();
                Equipo equipoConsultado = basedatos.ConsultarEquipoSerial(serial);
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

        internal bool verificarserialenlista(List<Equipo> equipos, String serial)
        {
            foreach (Equipo item in equipos)
            {
                if (item.serial.Equals(serial))
                {
                    return true;
                }
            }
            return false;
        }
    }
}