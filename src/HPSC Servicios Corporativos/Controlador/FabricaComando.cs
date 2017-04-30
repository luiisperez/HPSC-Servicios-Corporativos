using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Controlador.ModuloProductos;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HPSC_Servicios_Corporativos.Controlador.ModuloAliados;

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

            public static ConsultarContratosCliente ComandoConsultarContratosCliente(String id)
            {
                return new ConsultarContratosCliente(id);
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

            public static AgregarContrato ComandoAsignarServicio(List<String> servicios, List<String> seriales, String fechaini, String fechafin, String contrato)
            {
                return new AgregarContrato(servicios, seriales, fechaini, fechafin, contrato);
            }

            public static ConsultarServiciosPorEquipo ComandoConsultarServiciosPorEquipo(String id)
            {
                return new ConsultarServiciosPorEquipo(id);
            }

            public static ConsultarContratos ComandoConsultarContratos()
            {
                return new ConsultarContratos();
            }

            public static EliminarContrato ComandoEliminarContrato(String id)
            {
                return new EliminarContrato(id);
            }

            public static ConsultarServicioContrato ComandoConsultarServicioContrato(String id)
            {
                return new ConsultarServicioContrato(id);
            }

            public static ConsultarEquipoContrato ComandoConsultarEquipoContrato(String id)
            {
                return new ConsultarEquipoContrato(id);
            }
        #endregion

        #region Servicio
        public static AgregarPersonaContacto ComandoAgregarPersonaContacto(PersonaContacto nuevapersona)
        {
            return new AgregarPersonaContacto(nuevapersona);
        }

        public static ModificarPersonaContacto ComandoModificarPersonaContacto(PersonaContacto nuevapersona, String _correo)
        {
            return new ModificarPersonaContacto(nuevapersona, _correo);
        }

        public static EliminarPersonaContacto ComandoEliminarPersonaContacto(String _correo)
        {
            return new EliminarPersonaContacto(_correo);
        }

        public static ConsultarPersonasContactoPorCliente ComandoConsultarPersonasContactoPorCliente(String _correo)
        {
            return new ConsultarPersonasContactoPorCliente(_correo);
        }

        public static ConsultarTodasPersonasContacto ComandoConsultarTodasPersonasContacto()
        {
            return new ConsultarTodasPersonasContacto();
        }

        public static ConsultarPersonaContacto ComandoConsultarPersonaContacto(String _correo)
        {
            return new ConsultarPersonaContacto(_correo);
        }
        #endregion

        #region Incidentes
        public static ConsultarFeriados ComandoConsultarFeriados()
        {
            return new ConsultarFeriados();
        }

        public static AgregarIncidente ComandoAgregarIncidente(Incidente _incidente)
        {
            return new AgregarIncidente(_incidente);
        }

        public static EnviarCorreoIncidenteRegistrado ComandoEnviarCorreoIncidenteRegistrado(Incidente _incidente, String _cliente)
        {
            return new EnviarCorreoIncidenteRegistrado(_incidente, _cliente);
        }

        internal static ConsultarIncidentesCliente ComandoConsultarIncidentesCliente(String id)
        {
            return new ConsultarIncidentesCliente(id);
        }

        public static ConsultarIncidentesTodos ComandoConsultarIncidentesTodos()
        {
            return new ConsultarIncidentesTodos();
        }
        #endregion

        #region Aliado
        public static ConsultarAliados ComandoConsultarAliados()
        {
            return new ConsultarAliados();
        }
        #endregion
    }
}