using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Index
{
    public partial class postlogin : System.Web.UI.Page
    {
        protected Empleado emp = null;
        protected Cliente cli = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            var user = Session["Usuario"];
            if (user == null)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            if (!Page.IsPostBack)
            {
                if ((user != null) && (user.GetType().Equals(typeof(Empleado))))
                {
                    emp = (Empleado)user;
                    if (Int32.Parse(emp.rol) != -1)
                    {
                        zonaadministrativa.InnerHtml = "<a id=\"zonaempleado\" href=\"/Vista/Empleados/administracionHPSC.aspx\" style=\"color:white\">• Zona de empleados</a>";
                    }
                    else
                    {
                        zonaadministrativa.InnerHtml = "<a id=\"zonaempleado\" href=\"#\" style=\"color:white\" onclick=\"privilegiosinsuficientes()\">• Zona de empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                    }
                    actdatos.InnerHtml = "<a href=\"/Vista/Registro/modificardatosempleado.aspx\" style=\"color:white\">• Actualizar mis datos</a>";
                }
                else if ((user != null) && (user.GetType().Equals(typeof(Cliente))))
                {
                    zonaadministrativa.InnerHtml = "<a id=\"zonacliente\" href=\"/Vista/Clientes/administracionCliente.aspx\" style=\"color:white\">• Zona de clientes</a>";
                    actdatos.InnerHtml = "<a href=\"/Vista/Registro/modificardatoscliente.aspx\" style=\"color:white\">• Actualizar mis datos</a>";
                }
                else
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
                
            }
        }

        protected void Cerrarsesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}