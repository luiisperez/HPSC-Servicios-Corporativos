using HPSC_Servicios_Corporativos.Controlador;
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
    public partial class visualizarempleados : System.Web.UI.Page
    {
        public List<Empleado> listado = FabricaObjetos.CrearListaEmpleados();
        protected Empleado emp;
        protected void Page_Load(object sender, EventArgs e)
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
                                 "<a href=\"/Vista/Empleados/gestion-empleados/rolesempleados.aspx\">Equipos</a>" +
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
                    ConsultarEmpleados cmd = FabricaComando.ComandoConsultarEmpleados();
                    cmd.ejecutar();
                    listado = cmd.empleados;
                    List<Empleado> listadosineliminadosniadmin = FabricaObjetos.CrearListaEmpleados();
                    foreach (Empleado empleado in listado)
                    {
                        if ((!empleado.rol.Equals("Eliminado")) && (!empleado.rol.Equals("Administrador")))
                        {
                            listadosineliminadosniadmin.Add(empleado);
                        }
                    }
                    repPeople.DataSource = listadosineliminadosniadmin;
                    repPeople.DataBind();
                }
                catch (Exception ex)
                {
                    string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
        }

        protected void visualizaremp_Click(object sender, EventArgs e)
        {
            string script = "alert(\"Se ha eliminado su cuenta exitosamente y será redirigido al inicio\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                    "ServerControlScript", script, true);
        }

        protected void repPeople_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                Label correo = (Label)repPeople.Items[e.Item.ItemIndex].FindControl("correoemp");
                Empleado empeliminar = FabricaObjetos.CrearEmpleado(correo.Text, "", "", "", "");
                EliminarEmpleado cmd = FabricaComando.ComandoEliminarEmpleado(empeliminar);
                cmd.ejecutar();
                string script = "alert(\"Se ha eliminado la cuenta exitosamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
                Response.AddHeader("REFRESH", "1;URL=/Vista/Empleados/gestion-empleados/visualizarempleados.aspx");
            }
            catch (Exception ex)
            {
                string script = "alert(\"Se generó un error al eliminar intente nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}



