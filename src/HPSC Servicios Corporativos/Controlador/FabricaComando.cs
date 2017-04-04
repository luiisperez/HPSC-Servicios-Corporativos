using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloProductos;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
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

            public static ConsultarEquiposCliente ComandoConsultarEquiposPorCliente(String correocliente)
            {
                return new ConsultarEquiposCliente(correocliente);
            }

            public static EnviarSolicitudDeEquipo ComandoEnviarSolicitudDeEquipo(SolicitudEquipo nuevasolicitud, String cliente)
            {
                return new EnviarSolicitudDeEquipo(nuevasolicitud, cliente);
            }
        #endregion


        #region Equipos
            public static ValidacionDatosEquipos ComandoValidacionDeDatosEquipo()
            {
                return new ValidacionDatosEquipos();
            }

            public static AgregarEquipo ComandoAgregarEquipo(Equipo nuevoequipo)
            {
                return new AgregarEquipo(nuevoequipo);
            }

            public static ConsultarEquiposTodos ComandoConsultarEquiposTodos()
            {
                return new ConsultarEquiposTodos();
            }

            public static AsignarEquipo ComandoAsignarEquipo(String cliente, String serial)
            {
                return new AsignarEquipo(cliente, serial);
            }

            public static EliminarEquipo ComandoEliminarEquipo(Equipo eqeliminar)
            {
                return new EliminarEquipo(eqeliminar);
            }
            public static ConsultarEquipo ComandoConsultarEquipo(String serial)
            {
                return new ConsultarEquipo(serial);
            }
            public static ModificarEquipo ComandoModificarEquipo(Equipo equipo)
            {
                return new ModificarEquipo(equipo);
            }
        #endregion

        #region Producto
            public static AgregarProducto ComandoAgregarProducto(Equipo nuevoequipo)
            {
                return new AgregarProducto(nuevoequipo);
            }

            public static ValidacionDatosProductos ComandoValidacionDeDatosProductos()
            {
                return new ValidacionDatosProductos();
            }

            public static ConsultarProductos ComandoConsultarProductos()
            {
                return new ConsultarProductos();
            }

            public static ModificarProducto ComandoModificarProducto(Equipo equipo, String viejonumero)
            {
                return new ModificarProducto(equipo, viejonumero);
            }
        #endregion

        #region Servicio
            public static AgregarServicio ComandoAgregarServicio(Servicio nuevoserv)
            {
                return new AgregarServicio(nuevoserv);
            }

            public static ModificarServicio ComandoModificarServicio(Servicio nuevoserv)
            {
                return new ModificarServicio(nuevoserv);
            }

            public static ConsultarServicios ComandoConsultarServicios()
            {
                return new ConsultarServicios();
            }

            public static ConsultarServicio ComandoConsultarServicio(String id)
            {
                return new ConsultarServicio(id);
            }

            public static EliminarServicio ComandoEliminarServicio(String id)
            {
                return new EliminarServicio(id);
            }

            public static AsignarServicio ComandoAsignarServicio(String servicio, String serial, String fechaini, String fechafin)
            {
                return new AsignarServicio(servicio, serial, fechaini, fechafin);
            }

            public static ConsultarServiciosPorEquipo ComandoConsultarServiciosPorEquipo(String id)
            {
                return new ConsultarServiciosPorEquipo(id);
            }

            public static EliminarServicioAsignado ComandoEliminarServicioAsignado(String id)
            {
                return new EliminarServicioAsignado(id);
            }

            public static ConsultarServicioAsignado ComandoConsultarServicioAsignado(String id)
            {
                return new ConsultarServicioAsignado(id);
            }

            public static ModificarServicioAsignado ComandoModificarServicioAsignado(String servicio, String serial, String fechaini, String fechafin)
            {
                return new ModificarServicioAsignado(servicio, serial, fechaini, fechafin);
            }
        #endregion
    }
}