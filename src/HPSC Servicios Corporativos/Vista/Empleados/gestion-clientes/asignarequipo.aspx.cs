using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_clientes
{
    public partial class asignarequipo : System.Web.UI.Page
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
                if (emp == null)
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
                if (!Page.IsPostBack)
                {
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
                                    "<a href=\"/Vista/Empleados/gestion-asignacion-servicios/agregarcontrato.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-asignacion-servicios/visualizarcontratos.aspx\">Contratos registrados</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-asignacion-servicios/visualizarserviciosequipo.aspx\">Servicios por equipo</a>" +
                                "</li>" +
                            "</ul>";
                    }
                    else
                    {
                        zonausuarios.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes  <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            try
            {
                equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposTodos cmd = FabricaComando.ComandoConsultarEquiposTodos();
                cmd.ejecutar();
                equipos = cmd.equipos;
                String opciones = "";
                foreach (Equipo item in equipos)
                {
                    if (!item.estatus.Equals("Eliminado"))
                    {
                        String itemvalue = "Categoría: " + item.categoria + ". Equipo: " + item.modelo;
                        if (item.cliente.Equals("Sin asignar"))
                        {
                            itemvalue = itemvalue + ". Estatus: Sin asignar";
                        }
                        else
                        {
                            itemvalue = itemvalue + ". Estatus: Asignado";
                        }
                        opciones = opciones + "<option value=\"" + item.serial + "\" label=\"" + itemvalue + "\" >";
                    }
                }
                listado_equipos.InnerHtml = opciones;
                List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
                ConsultarClientes _cmd = FabricaComando.ComandoConsultarClientes();
                _cmd.ejecutar();
                clientes = _cmd.clientes;
                listadoclientes.Items.Add(new ListItem("Sin asignar", "NULL"));
                foreach (Cliente item in clientes)
                {
                    listadoclientes.Items.Add(new ListItem(item.nombre, item.correo));
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            ValidacionDatosEquipos valdatos = FabricaComando.ComandoValidacionDeDatosEquipo();
            bool serialexistente = valdatos.verificarserialenlista(equipos, equipoinput.Value);
            if (serialexistente)
            {
                try
                {
                    AsignarEquipo cmd = FabricaComando.ComandoAsignarEquipo(listadoclientes.SelectedValue, equipoinput.Value);
                    cmd.ejecutar();
                    var message = "";
                    if (!listadoclientes.SelectedValue.Equals("NULL")){
                        message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se asignó correctamente el equipo a " + listadoclientes.SelectedItem.Text);
                    }
                    else
                    {
                        message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha desasignado correctamente el equipo");
                    }
                    var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-clientes/asignarequipo.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
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
                string script = "alert(\"El serial colocado no existe o el campo se encuentra vacío\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}