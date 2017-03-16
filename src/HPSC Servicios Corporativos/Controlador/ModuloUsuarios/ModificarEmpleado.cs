using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class ModificarEmpleado:Comando
    {
        Empleado emp = null;
        public ModificarEmpleado(Empleado _emp)
        {
            this.emp = _emp;
        }

        public override void ejecutar()
        {
            try
            {
                DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                basedatos.Modificar(emp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}