using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_equipos
{
    public partial class agregarequipo : System.Web.UI.Page
    {
        protected Empleado emp;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    }
                    else
                    {
                        zonausuarios.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a  href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes  <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
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
            if ((!serial.Value.Equals("")) && (!numequipo.Value.Equals("")) && (!modelo.Value.Equals("")) && (!marca.Value.Equals("")))
            {
                ValidacionDatosEquipos val = FabricaComando.ComandoValidacionDeDatosEquipo();
                bool serialrepe = val.verificarserial(serial.Value);
                bool numrepe = val.verificarnumequipo(numequipo.Value);
                if ((!serialrepe) && (!numrepe))
                {
                    try
                    {
                        Equipo nuevoequipo = FabricaObjetos.CrearEquipo(serial.Value, numequipo.Value, listadocategoria.SelectedValue, marca.Value, modelo.Value);
                        AgregarEquipo cmd = FabricaComando.ComandoAgregarEquipo(nuevoequipo);
                        cmd.ejecutar();
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha registrado el equipo en el sistema exitosamente");
                        var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-equipos/agregarequipo.aspx';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurrido un error, intentelo de nuevo\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                else if ((serialrepe) && (numrepe))
                {
                    string script = "alert(\"El serial y número de equipo proporcionados ya se encuentran registrados\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
                else if ((!serialrepe) && (numrepe))
                {
                    string script = "alert(\"El número de equipo proporcionado ya se encuentra registrado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
                else if ((serialrepe) && (!numrepe))
                {
                    string script = "alert(\"El serial proporcionado ya se encuentra registrado\");";
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