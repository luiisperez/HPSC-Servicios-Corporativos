using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro
{
    public partial class recuperacionpassword : System.Web.UI.Page
    {
        String click;
        protected void Page_Load(object sender, EventArgs e)
        {
            click = (String)ViewState["click"];
        }

        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            if (click == null)
            {
                bool validarcorreo = Regex.IsMatch(correo.Value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (validarcorreo)
                {
                    if (tipousuario.SelectedValue.Equals("Empleado"))
                    {
                        ValidacionDatos validarmail = FabricaComando.ComandoValidacionDeDatos();
                        bool correovalido = validarmail.verificarcorreoemp(correo.Value);
                        if (correovalido)
                        {
                            try
                            {
                                EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correo.Value);
                                env.ejecutar();
                                hexacode.Visible = true;
                                mail.Enabled = false;
                                mensaje.Visible = true;
                                ViewState["codigohexadecimal"] = env.codigohexadecimal;
                                ViewState["click"] = "243edewc"; //String al azar
                            }
                            catch (Exception ex)
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No se pudo enviar el correo, por favor refresque la página");
                                var script = string.Format("alert({0});window.location ='/Vista/Registro/recuperacionpassword.aspx';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                        }
                        else
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("El correo ingresado no existe en el sistema");
                            var script = string.Format("alert({0});window.location ='/Vista/Registro/recuperacionpassword.aspx';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                    }
                    else if (tipousuario.SelectedValue.Equals("Cliente"))
                    {
                        ValidacionDatosCliente validarmail = FabricaComando.ComandoValidacionDeDatosDeCliente();
                        bool correovalido = validarmail.verificarcorreocli(correo.Value);
                        if (correovalido)
                        {
                            try
                            {
                                EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correo.Value);
                                env.ejecutar();
                                hexacode.Visible = true;
                                mail.Visible = false;
                                mensaje.Visible = true;
                                ViewState["codigohexadecimal"] = env.codigohexadecimal;
                                ViewState["click"] = "243edewc"; //String al azar
                            }
                            catch (Exception ex)
                            {
                                var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No se pudo enviar el correo, por favor refresque la página");
                                var script = string.Format("alert({0});window.location ='/Vista/Registro/recuperacionpassword.aspx';", message);
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                            }
                        }
                        else
                        {
                            var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("El correo ingresado no existe en el sistema");
                            var script = string.Format("alert({0});window.location ='/Vista/Registro/recuperacionpassword.aspx';", message);
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                        }
                    }
                }
                else
                {
                    string script = "alert(\"El correo ingresado no tiene formato de correo\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    correo.Value = "";
                }
            }
            else
            {
                if (codigohexa.Value.ToUpper().Equals((String)ViewState["codigohexadecimal"]))
                {
                    if (tipousuario.SelectedValue.Equals("Empleado"))
                    {
                        Response.Redirect("~/Vista/Registro/cambiopassword.aspx?correo=" + correo.Value + "&tipo=" + tipousuario.SelectedValue);
                    }
                    else if (tipousuario.SelectedValue.Equals("Cliente"))
                    {
                        Response.Redirect("~/Vista/Registro/cambiopassword.aspx?correo=" + correo.Value + "&tipo=" + tipousuario.SelectedValue);
                    }
                }
            }
        }
    }
}