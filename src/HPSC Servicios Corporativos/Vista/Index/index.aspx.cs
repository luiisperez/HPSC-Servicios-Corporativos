using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Index
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["Usuario"];
            if ((user!=null)&&(user.GetType().Equals(typeof(Empleado)))){
                 Response.Redirect("~/Vista/Index/postlogin.aspx");
            }
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            if (!tipousuario.SelectedValue.Equals(""))
            {
                String user = Request.Form["User"];
                String pwd = Request.Form["Password"];
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwd);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                pwd = sb.ToString();
                try
                {
                    IniciarSesion cmd = FabricaComando.ComandoIniciarSesion(user, pwd, tipousuario.SelectedValue);
                    cmd.ejecutar();
                    if (tipousuario.SelectedValue.Equals("Empleado"))
                    {
                        Session["Usuario"] = cmd.emp;
                    }
                    else if (tipousuario.SelectedValue.Equals("Cliente"))
                    {
                        Session["Usuario"] = cmd.cli;
                    }
                    Response.Redirect("~/Vista/Index/postlogin.aspx");

                }
                catch (Exception ex)
                {
                    string script = "alert(\"No se pudo iniciar sesión en este momento intente nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"No has seleccionado un tipo de usuario\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}