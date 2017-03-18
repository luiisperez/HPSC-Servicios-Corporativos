using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador
{
    public class FabricaComando
    {
        #region Empleados
            public static AgregarEmpleado ComandoAgregarEmpleado(Empleado nuevoempleado)
            {
                return new AgregarEmpleado(nuevoempleado);
            }

            public static IniciarSesion ComandoIniciarSesion(String user, String pwd, String tipouser)
            {
                return new IniciarSesion(user, pwd, tipouser);
            }

            public static ModificarEmpleado ComandoModificarEmpleado(Empleado nuevoempleado)
            {
                return new ModificarEmpleado(nuevoempleado);
            }

            public static ValidacionDatos ComandoValidacionDeDatos()
            {
                return new ValidacionDatos();
            }

            public static EliminarEmpleado ComandoEliminarEmpleado(Empleado eliminarempleado)
            {
                return new EliminarEmpleado(eliminarempleado);
            }

            public static EnviarConfirmacion ComandoEnviarConfirmacion(String correo)
            {
                return new EnviarConfirmacion(correo);
            }

            public static CambiarPassword ComandoCambiarPassword(String correo, String password, String tipo)
            {
                return new CambiarPassword(correo, password, tipo);
            }

            public static ConsultarEmpleados ComandoConsultarEmpleados()
            {
                return new ConsultarEmpleados();
            }

            public static ConsultarRoles ComandoConsultarRoles()
            {
                return new ConsultarRoles();
            }

            public static AsignarRol ComandoAsignarRol(String correo, String rol)
            {
                return new AsignarRol(correo, rol);
            }
        #endregion


        #region Clientes
            public static AgregarCliente ComandoAgregarCliente(Cliente nuevocliente)
            {
                return new AgregarCliente(nuevocliente);
            }

            public static ValidacionDatosCliente ComandoValidacionDeDatosDeCliente()
            {
                return new ValidacionDatosCliente();
            }

            public static ModificarCliente ComandoModificarCliente(Cliente nuevocliente)
            {
                return new ModificarCliente(nuevocliente);
            }

            public static EliminarCliente ComandoEliminarCliente(Cliente eliminarcliente)
            {
                return new EliminarCliente(eliminarcliente);
            }

            public static ConsultarClientes ComandoConsultarClientes()
            {
                return new ConsultarClientes();
            }
        #endregion
    }
}