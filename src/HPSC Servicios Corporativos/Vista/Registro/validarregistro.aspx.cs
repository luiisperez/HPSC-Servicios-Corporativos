using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro
{
    public partial class validarregistro : System.Web.UI.Page
    {
        UsuarioRegistrar user = null;
        String tipo;
        static int Intentos = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                tipo = Request.QueryString["tipo"];
                user = (UsuarioRegistrar)Session["Registro"];
                if (user == null)
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
            }
            catch 
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }


        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            ValidacionDatos validarcaptcha = FabricaComando.ComandoValidacionDeDatos();
            bool validacionexitosa = validarcaptcha.validarrecaptcha(Request["g-recaptcha-response"]);
            if (validacionexitosa)
            {
                try
                {
                    if (tipo.Equals("Empleado"))
                    {
                        if ((user.codigohexadecimal.Equals(codigohexa.Value.ToUpper())))
                        {
                            try
                            {
                                AgregarEmpleado add = FabricaComando.ComandoAgregarEmpleado(user.emp);
                                add.ejecutar();
                                string script = "alert(\"Se ha registrado exitosamente y será redirigido al inicio\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                        "ServerControlScript", script, true);
                                Response.AddHeader("REFRESH", "1;URL=/Vista/Index/index.aspx");
                            }
                            catch (Exception ex)
                            {
                                string script = "alert(\"No se pudo completar el registro, por favor intente nuevamente\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                        "ServerControlScript", script, true);
                            }
                        }
                        else
                        {
                            user.intentos = user.intentos - 1;
                            string script = "alert(\"Código incorrecto quedan: " + user.intentos + " intento/s\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                    "ServerControlScript", script, true);
                            if (user.intentos == 0)
                            {
                                Response.Redirect("~/Vista/Index/index.aspx");
                            }
                        }
                    }
                    else if (tipo.Equals("Cliente"))
                    {
                        if ((user.codigohexadecimal.Equals(codigohexa.Value.ToUpper())))
                        {
                            try
                            {
                                AgregarCliente add = FabricaComando.ComandoAgregarCliente(user.cli);
                                add.ejecutar();
                                string script = "alert(\"Se ha registrado exitosamente y será redirigido al inicio\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                        "ServerControlScript", script, true);
                                Response.AddHeader("REFRESH", "1;URL=/Vista/Index/index.aspx");
                            }
                            catch (Exception ex)
                            {
                                string script = "alert(\"No se pudo completar el registro, por favor intente nuevamente\");";
                                ScriptManager.RegisterStartupScript(this, GetType(),
                                                        "ServerControlScript", script, true);
                            }
                        }
                        else
                        {
                            user.intentos = user.intentos - 1;
                            string script = "alert(\"Código incorrecto quedan: " + user.intentos + " intento/s\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                    "ServerControlScript", script, true);
                            if (user.intentos == 0)
                            {
                                Response.Redirect("~/Vista/Index/index.aspx");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string script = "alert(\"Ha ocurrido un error, por favor refresque la página\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"La resolución de el reCAPTCHA no fue completada exitosamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}