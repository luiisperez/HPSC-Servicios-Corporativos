using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloAliados;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_incidentes
{
    public partial class detallesincidente : System.Web.UI.Page
    {
        protected Empleado emp;
        public String incidente;
        public List<Incidente> listado = FabricaObjetos.CrearListaIncidentes();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            
            emp = (Empleado)Session["Usuario"];
            incidente = (String)Session["incidente"];
            if (emp == null)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Int32.Parse(emp.rol) >= 20) //ADMINISTRADOR
                    {
                        zonausuarios.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#usuarios\" id=\"users\" runat=\"server\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"usuarios\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarempleados\" href=\"/Vista/Empleados/gestion-empleados/visualizarempleados.aspx\">Visualizar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/rolesempleados.aspx\">Asignación de roles</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/compensaciones.aspx\">Compensaciones</a>" +
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
                    else if (Int32.Parse(emp.rol) == 10) //COORDINADOR DE SERVICIOS
                    {
                        zonausuarios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
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
                        zonacontratos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
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
                    else if (Int32.Parse(emp.rol) == 5) //INGENIERO DE SOPORTE
                    {
                        zonausuarios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaequipos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-laptop\"></i> Equipos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaproductos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-barcode\"></i> Productos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonacontratos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonapersonascontacto.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-phone\"></i> Personal de contacto <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
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
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }
                    try
                    {
                        ConsultarIncidentesTodos cmd = FabricaComando.ComandoConsultarIncidentesTodos();
                        cmd.ejecutar();
                        listado = cmd.listado;
                        Incidente consultado = null;
                        foreach (Incidente item in listado)
                        {
                            if (item.id.Equals(incidente))
                            {
                                consultado = item;
                            }
                        }
                        if (consultado == null)
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No existe ningún incidente con ese identificador");
                            var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-incidentes/incidentes.aspx';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                        else
                        {
                            ConsultarActividades command = FabricaComando.ComandoConsultarActividades(consultado.id);
                            command.ejecutar();
                            List<Actividad> list = command.listado;
                            if (list.Count != 0)
                            {
                                repact.DataSource = list;
                                repact.DataBind();
                            }
                            ConsultarContratos comando = FabricaComando.ComandoConsultarContratos();
                            comando.ejecutar();
                            Contrato consul = FabricaObjetos.CrearContrato("", "", new DateTime(), new DateTime());
                            foreach (Contrato item in comando.contratos)
                            {
                                if (item.id.Equals(consultado.contrato))
                                {
                                    consul = item;
                                }
                            }
                            ConsultarEquipo com = FabricaComando.ComandoConsultarEquipo(consultado.equipo);
                            com.ejecutar();
                            Equipo equipo = com.equipoConsultado;
                            ConsultarServicio comm = FabricaComando.ComandoConsultarServicio(consultado.servicio);
                            comm.ejecutar();
                            Servicio serv = comm.servicioconsultado;
                            String responsable = "Sin asignar";
                            ConsultarPersonaContacto cmdd = FabricaComando.ComandoConsultarPersonaContacto(consultado.contacto1);
                            cmdd.ejecutar();
                            PersonaContacto principal = cmdd.consultado;
                            cmdd = FabricaComando.ComandoConsultarPersonaContacto(consultado.contacto2);
                            cmdd.ejecutar();
                            PersonaContacto secundario = cmdd.consultado;
                            var fechaatencion = "No aplica";
                            var fechafinservicio = "No aplica";
                            if (consultado.fechaatencion != new DateTime())
                            {
                                fechaatencion = consultado.fechaatencion.ToString("yyyy-MM-dd HH:mm").Replace(' ', 'T');
                                fechaatencio.Value = fechaatencion;
                            }
                            if (consultado.fechafinservicio != new DateTime())
                            {
                                fechafinservicio = consultado.fechafinservicio.ToString("yyyy-MM-dd HH:mm").Replace(' ', 'T');
                                fechaconclusion.Value = fechafinservicio;
                            }
                            if ((consultado.aliado.Equals("")) && (!consultado.empleado.Equals("")))
                            {
                                ConsultarEmpleados _cmd = FabricaComando.ComandoConsultarEmpleados();
                                _cmd.ejecutar();
                                bool verdadero = false;
                                foreach (Empleado item in _cmd.empleados)
                                {
                                    aliado_empleado.Items.Add(new ListItem(item.nombre + " " + item.apellido, item.correo));
                                    if (item.correo.Equals(consultado.empleado))
                                    {
                                        verdadero = true;
                                        responsable = item.correo;
                                    }
                                }
                                if (verdadero)
                                {
                                    tipoasignado.Text = "Empleado";
                                    aliado_empleado.SelectedValue = responsable;
                                }
                            }
                            else if ((!consultado.aliado.Equals("")) && (consultado.empleado.Equals("")))
                            {
                                ConsultarAliados _cmd = FabricaComando.ComandoConsultarAliados();
                                _cmd.ejecutar();
                                bool verdadero = false;
                                foreach (Aliado item in _cmd.listado)
                                {
                                    aliado_empleado.Items.Add(new ListItem(item.nombre, item.correo));
                                    if (item.correo.Equals(consultado.aliado))
                                    {
                                        verdadero = true;
                                        responsable = item.correo;
                                    }
                                }
                                if (verdadero)
                                {
                                    tipoasignado.Text = "Aliado";
                                    aliado_empleado.SelectedValue = responsable;
                                }
                            }
                            String horario = "Todo el dia";
                            if (serv.canthoras != 24)
                            {
                                DateTime horaini = new DateTime(2017, 1, 1, 8, 0, 0, 0);
                                DateTime horafin = horaini.AddHours(serv.canthoras);
                                horario = horaini.ToString("hh:mm tt") + " a las " + horafin.ToString("hh:mm tt");
                            }
                            fecharegistro.Text = consultado.fecharegistro.ToString("dd/MM/yyyy hh:mm tt");
                            fechacompromiso.Text = consultado.fechacompromiso.ToString("dd/MM/yyyy hh:mm tt");
                            fecharequerida.Text = consultado.fecharequerida.ToString("dd/MM/yyyy hh:mm tt");
                            estatus.Text = consultado.estatus;
                            impacto.Text = consultado.impacto;
                            urgencia.Text = consultado.urgencia;
                            tiposerv.Text = consultado.tiposerv;
                            direccion.Text = consultado.direccion;
                            descripcion.Text = consultado.descripcion;
                            accordion_equipo.InnerHtml = "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Serial</u>: " + equipo.serial + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>N° de equipo</u>: " + equipo.numeroequipo + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Categoría</u>: " + equipo.categoria + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Marca</u>: " + equipo.marca + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Modelo</u>: " + equipo.modelo + "</label>" +
                                                                "</div>" +
                                                            "</div>";
                            accordion_contacto.InnerHtml = "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:20px\">" +
                                                                "<label> Contacto principal</label>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:30px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Nombre y apellido</u>: " + principal.nombre + " " + principal.apellido + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Correo</u>: " + principal.correo + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Teléfono local</u>: " + principal.telflocal + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Teléfono movíl</u>: " + principal.telfmovil + "</label>" +
                                                                "</div>" +
                                                            "</div>" + "<div class=\"col-lg-12\" style=\"margin-top:30px;font-size:20px\">" +
                                                                "<label> Contacto secundario</label>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:30px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Nombre y apellido</u>: " + secundario.nombre + " " + secundario.apellido + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Correo</u>: " + secundario.correo + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Teléfono local</u>: " + secundario.telflocal + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Teléfono movíl</u>: " + secundario.telfmovil + "</label>" +
                                                                "</div>" +
                                                            "</div>";
                            accordion_servicio.InnerHtml = "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Identificador del servicio</u>: " + serv.identificador + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Nível de servicio</u>: " + serv.nivelservicio + " " + serv.canthoras + " hora(s) X " + serv.cantdias + " día(s)" + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Tiempo de respuesta</u>: " + serv.tiemporespuesta + " hora(s)</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-8\">" +
                                                                    "<label> <u>Identificador del contrato</u>: " + consultado.contrato + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Tipo de servicio</u>: " + serv.tiposervicio + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-8\">" +
                                                                    "<label> <u>Duración del contrato</u>: " + consul.fechaini.ToString("dd/MM/yyyy") + " al " + consul.fechafin.ToString("dd/MM/yyyy") + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Días de trabajo</u>: " + serv.dias.Replace(",", ", ") + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-8\">" +
                                                                    "<label> <u>Horario de trabajo</u>: " + horario + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>¿Incluye feriados?</u>: " + serv.feriado + "</label>" +
                                                                "</div>" +
                                                            "</div>";
                        }
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                catch (Exception ex)
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

        protected void tipoasignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            aliado_empleado.Items.Clear();
            try
            {
                if (tipoasignado.Text.Equals("Empleado"))
                {
                    ConsultarEmpleados cmd = FabricaComando.ComandoConsultarEmpleados();
                    cmd.ejecutar();
                    List<Empleado> listado = cmd.empleados;
                    foreach (Empleado item in listado)
                    {
                        aliado_empleado.Items.Add(new ListItem(item.nombre + " " + item.apellido, item.correo));
                    }
                }
                else if (tipoasignado.Text.Equals("Aliado"))
                {
                    ConsultarAliados cmd = FabricaComando.ComandoConsultarAliados();
                    cmd.ejecutar();
                    List<Aliado> listado = cmd.listado;
                    foreach (Aliado item in listado)
                    {
                        aliado_empleado.Items.Add(new ListItem(item.nombre, item.correo));
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool v1 = false;
                bool v2 = false;
                if (!fechaatencio.Value.Equals(""))
                {
                    ConsultarIncidentesTodos comd = FabricaComando.ComandoConsultarIncidentesTodos();
                    comd.ejecutar();
                    listado = comd.listado;
                    Incidente consultado = null;
                    foreach (Incidente item in listado)
                    {
                        if (item.id.Equals(incidente))
                        {
                            consultado = item;
                        }
                    }
                    DateTime fechaten = Convert.ToDateTime(fechaatencio.Value);
                    if (fechaten >= consultado.fechacompromiso)
                    {
                        ActualizarFechaAtencion cmd = FabricaComando.ComandoActualizarFechaAtencion(fechaten.ToString(), (String)Session["incidente"]);
                        cmd.ejecutar();
                        v1 = true;
                    }
                }
                if (!fechaconclusion.Value.Equals(""))
                {
                    ConsultarIncidentesTodos comd = FabricaComando.ComandoConsultarIncidentesTodos();
                    comd.ejecutar();
                    listado = comd.listado;
                    Incidente consultado = null;
                    foreach (Incidente item in listado)
                    {
                        if (item.id.Equals(incidente))
                        {
                            consultado = item;
                        }
                    }
                    DateTime conclufecha = Convert.ToDateTime(fechaconclusion.Value);
                    if (conclufecha >= consultado.fechacompromiso)
                    {
                        ActualizarFechaConclusion cmd = FabricaComando.ComandoActualizarFechaConclusion(conclufecha.ToString(), (String)Session["incidente"]);
                        cmd.ejecutar();
                        v2 = true;
                    }
                }
                if (tipoasignado.Text.Equals("Empleado"))
                {
                    String correo = aliado_empleado.SelectedValue;
                    String est = estatus.Text;
                    String imp = impacto.Text;
                    String urg = urgencia.Text;
                    ActualizarEmpEstImpUrg cmd = FabricaComando.ComandoActualizarEmpEstImpUrg(correo, est, imp, urg, (String)Session["incidente"]);
                    cmd.ejecutar();
                }
                else
                {
                    String correo = aliado_empleado.SelectedValue;
                    String est = estatus.Text;
                    String imp = impacto.Text;
                    String urg = urgencia.Text;
                    ActualizarAliEstImpUrg cmd = FabricaComando.ComandoActualizarAliEstImpUrg(correo, est, imp, urg, (String)Session["incidente"]);
                    cmd.ejecutar();
                }
                if (v1 && v2)
                {
                    string script = "alert(\"Se actualizaron los datos exitosamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-incidentes/detallesincidente.aspx");
                }
                else if (!v1 && v2)
                {
                    string script = "alert(\"Se actualizaron los datos exitosamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-incidentes/detallesincidente.aspx");
                }
                else if (!v2 && v1)
                {
                    string script = "alert(\"Se actualizaron los datos exitosamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-incidentes/detallesincidente.aspx");
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se ha podido actualizar toda la información, por favor intente nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Empleados/gestion-equipos/visualizarequipos.aspx");
        }

        protected void anadir_Click(object sender, EventArgs e)
        {
            if ((!fechahorainiact.Value.Equals("")) && (!fechahorafinact.Value.Equals("")))
            {
                DateTime ini = Convert.ToDateTime(fechahorainiact.Value);
                DateTime fin = Convert.ToDateTime(fechahorafinact.Value);
                if (fin > ini)
                {
                    ConsultarIncidentesTodos comd = FabricaComando.ComandoConsultarIncidentesTodos();
                    comd.ejecutar();
                    listado = comd.listado;
                    Incidente consultado = null;
                    foreach (Incidente item in listado)
                    {
                        if (item.id.Equals(incidente))
                        {
                            consultado = item;
                        }
                    }
                    if ((ini >= consultado.fechacompromiso) && (fin >= consultado.fechacompromiso))
                    {
                        TimeSpan horamax = new TimeSpan(24, 0, 0);
                        TimeSpan horausada = fin - ini;
                        if (horausada < horamax)
                        {
                            ConsultarActividades com = FabricaComando.ComandoConsultarActividades(incidente);
                            com.ejecutar();
                            List<Actividad> lista = com.listado;
                            bool verdad = false;
                            foreach (Actividad item in lista)
                            {
                                if ((ini >= item.fechahorainicio) && (ini < item.fechahorafin) && (item.empleado.Equals(emp.nombre + " " + emp.apellido)))
                                {
                                    verdad = true;
                                }
                            }
                            if (!verdad)
                            {
                                try
                                {
                                    AnadirActividad cmd = FabricaComando.ComandoAnadirActividad(tipoactividades.Text, fechahorainiact.Value, fechahorafinact.Value, emp.correo, incidente);
                                    cmd.ejecutar();
                                    string script = "alert(\"Se ha registrado la actividad exitosamente en el sistema\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(),
                                                            "ServerControlScript", script, true);
                                    Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-incidentes/detallesincidente.aspx");
                                    ConsultarActividades command = FabricaComando.ComandoConsultarActividades(incidente);
                                    command.ejecutar();
                                    List<Actividad> list = command.listado;
                                    if (list.Count != 0)
                                    {
                                        repact.DataSource = list;
                                        repact.DataBind();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string script = "alert(\"No se ha podido registrar, por favor intente nuevamente\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(),
                                                            "ServerControlScript", script, true);
                                }
                            }
                            else
                            {
                                string script = "alert(\"Existe un error de solapamiento de horas, la actividad que deseas cargar tiene conflicto con otra ya registrada\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                        "ServerControlScript", script, true);
                            }
                        }
                        else
                        {
                            string script = "alert(\"Una actividad no puede durar más de 24 horas, por favor revise\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                    "ServerControlScript", script, true);
                        }
                    }
                    else
                    {
                        string script = "alert(\"La fecha de inicio o la de finalización no debe ser antes que la fecha de compromiso, por favor revise\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                else
                {
                    string script = "alert(\"La fecha de finalización no debe ser antes que la de inicio, por favor revise\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"Existen campos vacíos, por favor revise todos los campos\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton botonpresionado = (ImageButton)e.CommandSource;
            if (botonpresionado.ID.Equals("Eliminar"))
            {
                Label id = (Label)repact.Items[e.Item.ItemIndex].FindControl("identificador");
                Label nombre = (Label)repact.Items[e.Item.ItemIndex].FindControl("name");
                try
                {
                    if (nombre.Text.Equals(emp.nombre + " " + emp.apellido))
                    {
                        EliminarActividad cdm = FabricaComando.ComandoEliminarActividad(id.Text);
                        cdm.ejecutar();
                        ConsultarActividades command = FabricaComando.ComandoConsultarActividades(incidente);
                        command.ejecutar();
                        List<Actividad> list = command.listado;
                        repact.DataSource = list;
                        repact.DataBind();
                        string script = "alert(\"Se ha eliminado la actividad exitosamente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                        Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-incidentes/detallesincidente.aspx");
                    }
                    else
                    {
                        string script = "alert(\"No se puede eliminar una actividad realizada por otra persona\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                catch (Exception ex)
                {
                    string script = "alert(\"No se ha podido eliminar, por favor intente nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
        }
    }
}