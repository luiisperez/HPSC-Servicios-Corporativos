using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_empleados
{
    public partial class compensaciones : System.Web.UI.Page
    {
        public List<Empleado> listado = FabricaObjetos.CrearListaEmpleados();
        protected Empleado emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            try
            {
                emp = (Empleado)Session["Usuario"];
                if (emp == null)
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
                if (!Page.IsPostBack)
                {
                    if (Int32.Parse(emp.rol) >= 20)
                    {
                        zonaincidentes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#incidentes\" id=\"incidente\" runat=\"server\"><i class=\"fa fa fa-warning\"></i> Incidentes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"incidentes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-incidentes/agregarincidente.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-incidentes/incidentes.aspx\">Visualizar</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/compensaciones.aspx\">Compensaciones</a>" +
                                "</li>" +
                            "</ul>";
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
                    }
                    else
                    {
                        zonausuarios.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes  <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }
                    try
                    {
                        String inicio = Request.QueryString["inicio"];
                        String fin = Request.QueryString["fin"];

                        if ((inicio != null) && (fin != null))
                        {
                            inifecha.Value = inicio;
                            finfecha.Value = fin;
                            DateTime _inicio = Convert.ToDateTime(Request.QueryString["inicio"]);
                            DateTime _fin = Convert.ToDateTime(Request.QueryString["fin"]);
                            ConsultarEmpleados cmd_ = FabricaComando.ComandoConsultarEmpleados();
                            cmd_.ejecutar();
                            List<HorasEmpleado> horasemp = FabricaObjetos.CrearListaHorasEmpleados();
                            foreach (Empleado item in cmd_.empleados)
                            {
                                horasemp.Add(FabricaObjetos.CrearHorasEmpleado(item.nombre + " " + item.apellido));
                            }
                            ConsultarIncidentesTodos cmd = FabricaComando.ComandoConsultarIncidentesTodos();
                            cmd.ejecutar();
                            foreach (Incidente item in cmd.listado)
                            {
                                ConsultarActividades _cmd = FabricaComando.ComandoConsultarActividades(item.id);
                                _cmd.ejecutar();
                                foreach (Actividad actconsultada in _cmd.listado)
                                {
                                    actconsultada.horasnocturnas = 0;
                                    actconsultada.horasdiurnas = 0;
                                    actconsultada.horaslaborables = 0;
                                    DateTime ini = actconsultada.fechahorainicio;
                                    DateTime movil = actconsultada.fechahorainicio;
                                    DateTime end = actconsultada.fechahorafin;
                                    TimeSpan horastrabajadas = end - ini;
                                    int horastrabajadasreal = horastrabajadas.Minutes + (horastrabajadas.Hours * 60);
                                    double hora = 60;
                                    double x = horastrabajadas.Minutes;
                                    double fracciontiempo = 1 / hora;
                                    ConsultarFeriados com = FabricaComando.ComandoConsultarFeriados();
                                    com.ejecutar();
                                    List<Feriado> feriados = com.feriados;
                                    for (int i = 1; i <= horastrabajadasreal; i++)
                                    {
                                        movil = movil.AddMinutes(1);
                                        if ((movil >= _inicio) && (movil <= _fin))
                                        {
                                            TimeSpan h = movil.TimeOfDay;
                                            TimeSpan cero = new TimeSpan(0, 0, 0);
                                            TimeSpan seis = new TimeSpan(6, 0, 0);
                                            TimeSpan ocho = new TimeSpan(8, 0, 0);
                                            TimeSpan diecisiete = new TimeSpan(17, 0, 0);
                                            TimeSpan diecinueve = new TimeSpan(19, 0, 0);
                                            TimeSpan venticuatro = new TimeSpan(24, 0, 0);

                                            if ((h >= cero) && (h <= seis))
                                            {
                                                actconsultada.horasnocturnas = actconsultada.horasnocturnas + fracciontiempo;
                                            }
                                            if ((h > seis) && (h <= ocho))
                                            {
                                                actconsultada.horasdiurnas = actconsultada.horasdiurnas + fracciontiempo;
                                            }
                                            if ((h > ocho) && (h <= diecisiete))
                                            {
                                                bool feriado = false;
                                                foreach (Feriado item_ in feriados)
                                                {
                                                    if ((item_.dia == movil.Day) && (item_.mes == movil.Month))
                                                    {
                                                        feriado = true;
                                                    }
                                                }
                                                if ((feriado == true) || (movil.DayOfWeek.ToString().Equals("Saturday")) || (movil.DayOfWeek.ToString().Equals("Sábado")) ||
                                                                         (movil.DayOfWeek.ToString().Equals("Sabado")) || (movil.DayOfWeek.ToString().Equals("Domingo")) ||
                                                                         (movil.DayOfWeek.ToString().Equals("Sunday")))
                                                {
                                                    actconsultada.horasdiurnas = actconsultada.horasdiurnas + fracciontiempo;
                                                }
                                                else
                                                {
                                                    actconsultada.horaslaborables = actconsultada.horaslaborables + fracciontiempo;
                                                }
                                            }
                                            if ((h > diecisiete) && (h <= diecinueve))
                                            {
                                                actconsultada.horasdiurnas = actconsultada.horasdiurnas + fracciontiempo;
                                            }
                                            if ((h > diecinueve) && (h < venticuatro))
                                            {
                                                actconsultada.horasdiurnas = actconsultada.horasdiurnas + fracciontiempo;
                                            }
                                        }
                                    }
                                    actconsultada.horasdiurnas = Math.Round(actconsultada.horasdiurnas, 2);
                                    actconsultada.horasnocturnas = Math.Round(actconsultada.horasnocturnas, 2);
                                    actconsultada.horaslaborables = Math.Round(actconsultada.horaslaborables, 2);
                                    foreach (HorasEmpleado item_ in horasemp)
                                    {
                                        if (item_.empleado.Equals(actconsultada.empleado))
                                        {
                                            item_.horasdiurnas = item_.horasdiurnas + actconsultada.horasdiurnas;
                                            item_.horasnocturnas = item_.horasnocturnas + actconsultada.horasnocturnas;
                                            item_.horaslaborables = item_.horaslaborables + actconsultada.horaslaborables;
                                        }
                                    }
                                }
                            }
                            repPeople.DataSource = horasemp;
                            repPeople.DataBind();
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
            catch
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!inifecha.Value.Equals("")) && (!finfecha.Value.Equals("")))
            {
                DateTime inicio = Convert.ToDateTime(inifecha.Value);
                DateTime fin = Convert.ToDateTime(finfecha.Value);
                if (fin >= inicio)
                {
                    Response.Redirect("~/Vista/Empleados/gestion-empleados/compensaciones.aspx?inicio=" + inifecha.Value + "&fin=" + finfecha.Value);
                }
                else
                {
                    string script = "alert(\"La fecha de fin es menor a la de inicio\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"No coloco las dos fechas para realizar la búsqueda\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}



