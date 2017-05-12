using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados
{
    public partial class administracionHPSC : System.Web.UI.Page
    {
        public Empleado emp;
        public String datatipo = "";
        public String dataurgencia = "";
        public String dataimpacto = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            if (!Page.IsPostBack)
            {
                try
                {
                    emp = (Empleado)Session["Usuario"];
                    if (emp == null)
                    {
                        Response.Redirect("~/Vista/Index/index.aspx");
                    }
                    if (Int32.Parse(emp.rol) >= 20)
                    {
                        zonausuarios.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#usuarios\" id=\"users\" runat=\"server\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"usuarios\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarempleados\" href=\"/Vista/Empleados/gestion-empleados/visualizarempleados.aspx\">Visualizar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/rolesempleados.aspx\">Asignación de roles</a>" +
                                "</li>" +
                            "</ul>";
                        zonaclientes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#clientes\" id=\"clients\" runat=\"server\"><i class=\"fa fa-briefcase\"></i> Clientes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"clientes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/visualizarclientes.aspx\">Visualizar</a>" +
                               "</li>" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/asignarequipo.aspx\">Asignar equipos</a>" +
                               "</li>" +
                            "</ul>";
                        zonaequipos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#equipos\" id=\"equipment\" runat=\"server\"><i class=\"fa fa-laptop\"></i> Equipos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"equipos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-equipos/agregarequipo.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-equipos/visualizarequipos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonaproductos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#productos\" id=\"products\" runat=\"server\"><i class=\"fa fa-barcode\"></i> Productos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"productos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-productos/agregarproducto.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-productos/visualizarproductos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonacontratos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#contratos\" id=\"services\" runat=\"server\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"contratos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-servicios/agregarservicio.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-servicios/visualizarservicios.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#asignarservicios\" id=\"servicesequipment\" runat=\"server\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"asignarservicios\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-contratos/agregarcontrato.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-contratos/visualizarcontratos.aspx\">Contratos registrados</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-contratos/visualizarserviciosequipo.aspx\">Servicios por equipo</a>" +
                                "</li>" +
                            "</ul>";
                        zonapersonascontacto.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#personas\" id=\"contact\" runat=\"server\"><i class=\"fa fa-phone\"></i> Personal de contacto <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"personas\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-contactos/visualizarpersonascontacto.aspx\">Visualizar</a>" +
                               "</li>" +
                            "</ul>";
                        zonaincidentes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#incidentes\" id=\"incidente\" runat=\"server\"><i class=\"fa fa fa-warning\"></i> Incidentes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"incidentes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-incidentes/agregarincidente.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-incidentes/incidentes.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                    }
                    else
                    {
                        zonausuarios.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes  <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }
                    EstadisticaCantidadIncidentesEstatus cmd = FabricaComando.ComandoConsultarEstadisticaCantidadIncidentesEstatus();
                    cmd.ejecutar();
                    EstadisticaCantidadIncidentesImpacto _cmd = FabricaComando.ComandoConsultarEstadisticaCantidadIncidentesImpacto();
                    _cmd.ejecutar();
                    EstadisticaCantidadIncidentesTipo __cmd = FabricaComando.ComandoConsultarEstadisticaCantidadIncidentesTipo();
                    __cmd.ejecutar();
                    EstadisticaCantidadIncidentesUrgencia ___cmd = FabricaComando.ComandoConsultarEstadisticaCantidadIncidentesUrgencia();
                    ___cmd.ejecutar();
                    casosregistrados.InnerHtml = cmd.listado[0];
                    casosatendidos.InnerHtml = cmd.listado[1];
                    casosnoatendidos.InnerHtml = cmd.listado[2];
                    casosresueltos.InnerHtml = cmd.listado[3];
                    datatipo = "{ label: \"Preventivo\", value: " + __cmd.listado[1] + " }," +
                               "{ label: \"Reactivo\", value: " + __cmd.listado[0] + " }," +
                               "{ label: \"Implementación\", value: " + __cmd.listado[2] + " },";
                    dataimpacto = "{ label: \"Crítico\", value: " + _cmd.listado[0] + " }," +
                                  "{ label: \"Significativo\", value: " + _cmd.listado[1] + " }," +
                                  "{ label: \"Moderado\", value: " + _cmd.listado[2] + " }," +
                                  "{ label: \"Menor\", value: " + _cmd.listado[3] + " },";
                    dataurgencia = "{ label: \"Crítica\", value: " + ___cmd.listado[0] + " }," +
                                   "{ label: \"Alta\", value: " + ___cmd.listado[1] + " }," +
                                   "{ label: \"Media\", value: " + ___cmd.listado[2] + " }," +
                                   "{ label: \"Baja\", value: " + ___cmd.listado[3] + " },";
                }
                catch
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}