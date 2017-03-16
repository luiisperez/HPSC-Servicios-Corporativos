using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class AgregarEmpleado:Comando
    {
        Empleado nuevo;

        public AgregarEmpleado(Empleado _nuevo)
        {
            this.nuevo = _nuevo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                basedatos.Agregar(nuevo);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}