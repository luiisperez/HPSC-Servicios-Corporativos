using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class EliminarEmpleado:Comando
    {
        Empleado emp = null;
        public EliminarEmpleado(Empleado _emp)
        {
            this.emp = _emp;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                basedatos.Eliminar(emp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}