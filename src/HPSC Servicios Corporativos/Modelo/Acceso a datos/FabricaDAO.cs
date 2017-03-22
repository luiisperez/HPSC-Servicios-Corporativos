using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos
{
    public class FabricaDAO
    {
        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, valorAtributo, output);
        }

        public static Parametro asignarParametro(string nombreAtributo, SqlDbType tipoDeDato, bool output)
        {
            return new Parametro(nombreAtributo, tipoDeDato, output);
        }

        public static List<Parametro> asignarListaDeParametro()
        {
            return new List<Parametro>();
        }

        public static DAOEmpleado CrearDAOEmpleado()
        {
            return new DAOEmpleado();
        }

        public static DAOCliente CrearDAOCliente()
        {
            return new DAOCliente();
        }

        public static ModuloEquipos.DAOEquipo CrearDAOEquipo()
        {
            return new DAOEquipo();
        }
    }
}