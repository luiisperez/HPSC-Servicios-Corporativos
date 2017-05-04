using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HPSC_Servicios_Corporativos.Controlador.ModuloAliados;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_incidentes
{
    public partial class consultarincidente : System.Web.UI.Page
    {
        public Cliente cliente;
        public String incidente;
        public List<Incidente> listado = FabricaObjetos.CrearListaIncidentes();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            cliente = (Cliente)Session["Usuario"];
            incidente = (String)Session["incidente"];
            try
            {
                if (!Page.IsPostBack)
                {
                    if (cliente == null)
                    {
                        Response.Redirect("~/Vista/Index/index.aspx");
                    }
                    try
                    {
                        ConsultarIncidentesCliente cmd = FabricaComando.ComandoConsultarIncidentesCliente(cliente.correo);
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
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No tiene ningún incidente con ese identificador");
                            var script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-incidentes/visualizarincidentes.aspx';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                        else
                        {
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
                            String fechaatencion = "No aplica";
                            String fechafinservicio = "No aplica";
                            if (consultado.fechaatencion != new DateTime())
                            {
                                fechaatencion = consultado.fechaatencion.ToString("dd/MM/yyyy HH:mm:ss tt");
                            }
                            if (consultado.fechafinservicio != new DateTime())
                            {
                                fechafinservicio = consultado.fechafinservicio.ToString("dd/MM/yyyy HH:mm:ss tt");
                            }
                            if ((consultado.aliado.Equals("")) && (!consultado.empleado.Equals("")))
                            {
                                ConsultarEmpleados _cmd = FabricaComando.ComandoConsultarEmpleados();
                                _cmd.ejecutar();
                                foreach (Empleado item in _cmd.empleados)
                                {
                                    if (item.correo.Equals(consultado.empleado))
                                    {
                                        responsable = item.nombre + " " + item.apellido;
                                    }
                                }
                            }
                            else if ((!consultado.aliado.Equals("")) && (consultado.empleado.Equals("")))
                            {
                                ConsultarAliados _cmd = FabricaComando.ComandoConsultarAliados();
                                _cmd.ejecutar();
                                foreach (Aliado item in _cmd.listado)
                                {
                                    if (item.correo.Equals(consultado.aliado))
                                    {
                                        responsable = item.nombre;
                                    }
                                }
                            }
                            String horario = "Todo el dia";
                            if (serv.canthoras != 24)
                            {
                                DateTime horaini = new DateTime(2017, 1, 1, 8, 0, 0, 0);
                                DateTime horafin = horaini.AddHours(serv.canthoras);
                                horario = horaini.ToString("hh:mm tt") + " a las " + horafin.ToString("hh:mm tt");
                            }
                            accordion_incidente.InnerHtml = "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">"+
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Fecha de registro</u>: " + consultado.fecharegistro.ToString("dd/MM/yyyy HH:mm:ss tt") + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Fecha de compromiso</u>: " + consultado.fechacompromiso.ToString("dd/MM/yyyy HH:mm:ss tt") + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Fecha de requerida</u>: " + consultado.fecharequerida.ToString("dd/MM/yyyy HH:mm:ss tt") + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Fecha de atención</u>: " + fechaatencion + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Fecha de conclusión</u>: " + fechafinservicio + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Asignado a</u>: " + responsable + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Estatus</u>: " + consultado.estatus + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Impacto</u>: " + consultado.impacto + "</label>" +
                                                                "</div>" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Urgencia</u>: " + consultado.urgencia + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px\">" +
                                                                "<div class=\"col-md-4\">" +
                                                                    "<label> <u>Tipo de servicio</u>: " + consultado.tiposerv + "</label>" +
                                                                "</div>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px;margin-left:15px\">" +
                                                                "<label> <u>Dirección</u>: " + consultado.direccion + "</label>" +
                                                            "</div>" +
                                                            "<div class=\"col-lg-12\" style=\"margin-top:20px;font-size:15px;margin-left:15px\">" +
                                                                "<label> <u>Descripción</u>: " + consultado.descripcion + "</label>" +
                                                            "</div>";
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
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}