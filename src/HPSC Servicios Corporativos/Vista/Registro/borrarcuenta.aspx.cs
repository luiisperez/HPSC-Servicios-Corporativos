using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro
{
    public partial class borrarcuenta : System.Web.UI.Page
    {
        Empleado emp = null;
        Cliente cli = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["Usuario"];
            if ((user!=null)&&(user.GetType().Equals(typeof(Empleado)))){
                emp = (Empleado)user;
            }else if ((user != null) && (user.GetType().Equals(typeof(Cliente))))
            {
                cli = (Cliente)user;
            }
            else
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!contrasena.Value.Equals("")) && (!contrasenarepe.Value.Equals("")) && (emp != null))
                {
                    ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                    if ((validar.validarcontrasenahash(contrasena.Value, emp.contrasena)))
                    {
                        EliminarEmpleado cmd = FabricaComando.ComandoEliminarEmpleado(emp);
                        cmd.ejecutar();
                        string script = "alert(\"Se ha eliminado su cuenta exitosamente y será redirigido al inicio\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                        Session.Abandon();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                    "setTimeout(function() {window.location.replace('/Vista/Index/index.aspx') }, 500);", true);
                    }
                }
                else if ((!contrasena.Value.Equals("")) && (!contrasenarepe.Value.Equals("")) && (cli != null))
                {
                    ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                    if ((validar.validarcontrasenahash(contrasena.Value, cli.contrasena)))
                    {
                        EliminarCliente cmd = FabricaComando.ComandoEliminarCliente(cli);
                        cmd.ejecutar();
                        string script = "alert(\"Se ha eliminado su cuenta exitosamente y será redirigido al inicio\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                        Session.Abandon();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                    "setTimeout(function() {window.location.replace('/Vista/Index/index.aspx') }, 500);", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error intentelo nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                    "setTimeout(function() {history.go(-2) }, 500);", true);
        }
    }
}