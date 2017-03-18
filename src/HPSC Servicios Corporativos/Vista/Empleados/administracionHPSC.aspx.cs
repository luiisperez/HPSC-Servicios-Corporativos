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
        protected Empleado emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}