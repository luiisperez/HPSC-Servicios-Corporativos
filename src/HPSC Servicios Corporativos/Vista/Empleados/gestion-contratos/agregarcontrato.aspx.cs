using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_asignacion_servicios
{
    public partial class asignarservicio : System.Web.UI.Page
    {
        protected Empleado emp;
        protected List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            try
            {
                emp = (Empleado)Session["Usuario"];
                if (!Page.IsPostBack)
                {
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
                    }
                    else
                    {
                        zonausuarios.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes  <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }

                    try
                    {
                        List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
                        ConsultarClientes cmd = FabricaComando.ComandoConsultarClientes();
                        cmd.ejecutar();
                        clientes = cmd.clientes;
                        foreach (Cliente item in clientes)
                        {
                            listadoclientes.Items.Add(new ListItem(item.nombre, item.correo));
                        }
                        List<Servicio> servicios = FabricaObjetos.CrearListaServicios();
                        ConsultarServicios _cmd = FabricaComando.ComandoConsultarServicios();
                        _cmd.ejecutar();
                        servicios = _cmd.servicios;
                        foreach (Servicio item in servicios)
                        {
                            if (item.disponibilidad.Equals("Disponible"))
                            {
                                String dias = item.dias;
                                checkservicios.Items.Add(new ListItem(item.nivelservicio + " " + item.canthoras + "x" + item.dias.Split(',').Count() + ", Tipo de servicio: " + item.tiposervicio + ", Feriado: " + item.feriado + ", Tiempo de respuesta: " + item.tiemporespuesta + " hora(s)" + ", Días de trabajo: " + dias.Replace(",", ", "), item.identificador));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurido un error intente nuevamente\");";
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

        protected void listadoclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listadoclientes.SelectedValue.Equals(""))
            {
                cblItem.Items.Clear();
            }
            else
            {
                List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposCliente cmd = FabricaComando.ComandoConsultarEquiposPorCliente(listadoclientes.SelectedValue);
                cmd.ejecutar();
                equipos = cmd.equipos;
                foreach (Equipo item in equipos)
                {
                    if (!item.estatus.Equals("Eliminado"))
                    {
                        cblItem.Items.Add(new ListItem(item.serial + ": Categoría: " + item.categoria + ". Marca/Modelo: " + item.marca + "/" + item.modelo, item.serial));
                    }
                }
            }
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!inifecha.Value.Equals("")) && (!finfecha.Value.Equals("")))
            {

                if (!(Convert.ToDateTime(inifecha.Value) > Convert.ToDateTime(finfecha.Value)))
                {
                    try
                    {
                        String hola = checkservicios.SelectedValue;
                        List<String> serviciosseleccionados = checkservicios.Items.Cast<ListItem>()
                           .Where(li => li.Selected)
                           .Select(li => li.Value)
                           .ToList();
                        List<String> equiposseleccionados = cblItem.Items.Cast<ListItem>()
                           .Where(li => li.Selected)
                           .Select(li => li.Value)
                           .ToList();
                        if ((equiposseleccionados.Count != 0) && (serviciosseleccionados.Count != 0))
                        {
                            String contrato = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                            AgregarContrato cmd = FabricaComando.ComandoAsignarServicio(serviciosseleccionados, equiposseleccionados, inifecha.Value, finfecha.Value, contrato);
                            cmd.ejecutar();
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha agregado el contrato exitosamente, el identificador del contrato es: CID-" + contrato);
                            var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-contratos/agregarcontrato.aspx';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                        else
                        {
                            string script = "alert(\"No se ha seleccionado ningún contrato y/o equipo, por favor revise\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                    "ServerControlScript", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                else
                {
                    string script = "alert(\"La fecha inicio no puede ser posterior a la fecha de finalización\");";
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
    }
}