using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_contactos
{
    public partial class modificarpersonacontacto : System.Web.UI.Page
    {
        protected Empleado emp;
        protected Equipo eq;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            emp = (Empleado)Session["Usuario"];
            if (emp == null)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
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
                        ConsultarPersonaContacto cmd = FabricaComando.ComandoConsultarPersonaContacto(Request.QueryString["id"]);
                        cmd.ejecutar();
                        PersonaContacto consultada = cmd.consultado;
                        List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
                        ConsultarClientes _cmd = FabricaComando.ComandoConsultarClientes();
                        _cmd.ejecutar();
                        clientes = _cmd.clientes;
                        foreach (Cliente item in clientes)
                        {
                            listadoclientes.Items.Add(new ListItem(item.nombre, item.correo));
                        }
                        correo.Value = consultada.correo;
                        nombre.Value = consultada.nombre;
                        apellido.Value = consultada.apellido;
                        telflocal.Value = consultada.telflocal;
                        telfmovil.Value = consultada.telfmovil;
                        estatus.SelectedValue = consultada.estatus;
                        listadoclientes.Text = consultada.cliente;
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurrido un error, intentelo de nuevo\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
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

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!nombre.Value.Equals("")) && (!apellido.Value.Equals("")) && (!correo.Value.Equals("")) && (!telflocal.Value.Equals("")))
            {
                ConsultarPersonaContacto _cmd = FabricaComando.ComandoConsultarPersonaContacto(correo.Value);
                _cmd.ejecutar();
                if ((_cmd.consultado != null) && (!correo.Value.Equals(Request.QueryString["id"])))
                {
                    string script = "alert(\"El correo ingresado ya se encuentra registrado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
                else
                {
                    PersonaContacto persona = FabricaObjetos.CrearPersonaContacto(correo.Value, nombre.Value, apellido.Value, telflocal.Value, telfmovil.Value, estatus.SelectedValue, listadoclientes.SelectedValue);
                    ModificarPersonaContacto cmd = FabricaComando.ComandoModificarPersonaContacto(persona, Request.QueryString["id"]);
                    try
                    {
                        cmd.ejecutar();
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha modificado la persona de contacto exitosamente");
                        var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-contactos/visualizarpersonascontacto.aspx';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
            }
            else
            {
                string script = "alert(\"Existen campos vacíos, por favor revise los campos\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Empleados/gestion-contactos/visualizarpersonascontacto.aspx");
        }
    }
}