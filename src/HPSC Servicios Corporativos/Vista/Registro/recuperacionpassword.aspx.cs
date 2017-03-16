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

        protected void correoemp_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            if (click == null)
            {
                bool validarcorreo = Regex.IsMatch(correo.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (validarcorreo)
                {
                    if (tipousuario.SelectedValue.Equals("Empleado"))
                    {
                        ValidacionDatos validarmail = FabricaComando.ComandoValidacionDeDatos();
                        bool correovalido = validarmail.verificarcorreoemp(correo.Text);
                        if (correovalido)
                        {
                            EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correo.Text);
                            env.ejecutar();
                            codigohexa.Enabled = true;
                            ViewState["codigohexadecimal"] = env.codigohexadecimal;
                            ViewState["click"] = "243edewc"; //String al azar
                        }
                    }
                    else if (tipousuario.SelectedValue.Equals("Cliente"))
                    {
                        ValidacionDatosCliente validarmail = FabricaComando.ComandoValidacionDeDatosDeCliente();
                        bool correovalido = validarmail.verificarcorreocli(correo.Text);
                        if (correovalido)
                        {
                            EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correo.Text);
                            env.ejecutar();
                            codigohexa.Enabled = true;
                            ViewState["codigohexadecimal"] = env.codigohexadecimal;
                            ViewState["click"] = "243edewc"; //String al azar
                        }
                    }
                }
                else
                {
                    string script = "alert(\"El correo ingresado no tiene formato de correo\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    correo.Text = "";
                }
            }
            else
            {
                if (codigohexa.Text.ToUpper().Equals((String)ViewState["codigohexadecimal"]))
                {
                    if (tipousuario.SelectedValue.Equals("Empleado"))
                    {
                        Response.Redirect("~/Vista/Registro/cambiopassword.aspx?correo=" + correo.Text + "&tipo=" + tipousuario.SelectedValue);
                    }
                    else if (tipousuario.SelectedValue.Equals("Cliente"))
                    {
                        Response.Redirect("~/Vista/Registro/cambiopassword.aspx?correo=" + correo.Text + "&tipo=" + tipousuario.SelectedValue);
                    }
                }
            }
        }
    }
}