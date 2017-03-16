using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class ConsultarEmpleados:Comando
    {
        public List<Empleado> empleados = FabricaObjetos.CrearListaEmpleados();
        public override void ejecutar()
        {
            try
            {
                DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                empleados = basedatos.ConsultarEmpleados();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}