using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Index
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tipousuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipousuario.SelectedValue.Equals("Empleado"))
            {
                empform.Visible = true;
                cliform.Visible = false;
                aliform.Visible = false;
            }
            if (tipousuario.SelectedValue.Equals("Cliente"))
            {
                empform.Visible = false;
                cliform.Visible = true;
                aliform.Visible = false;
            }
            if (tipousuario.SelectedValue.Equals("Aliado"))
            {
                empform.Visible = false;
                cliform.Visible = false;
                aliform.Visible = true;
            }
        }

        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void correoemp_TextChanged(object sender, EventArgs e)
        {
            bool validarcorreo = Regex.IsMatch(correoemp.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (validarcorreo)
            {

            }
            else
            {
                string script = "alert(\"El correo ingresado no tiene formato de correo\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                correoemp.Text = "";
            }
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!correoemp.Text.Equals("")) && (!nombreemp.Text.Equals("")) && (!apellidoemp.Text.Equals("")) && (!usuarioemp.Text.Equals("")) && (!contrasenaemp.Text.Equals("")))
                {
                    ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                    bool validaruser = validar.verificarusuarioemp(usuarioemp.Text);
                    bool validarcorreo = validar.verificarcorreoemp(correoemp.Text);
                    if ((!validaruser) && (!validarcorreo))
                    {
                        EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correoemp.Text);
                        env.ejecutar();
                        Empleado nuevoempleado = FabricaObjetos.CrearEmpleado(correoemp.Text, nombreemp.Text, apellidoemp.Text, usuarioemp.Text, contrasenaemp.Text);
                        UsuarioRegistrar nuevouser = new UsuarioRegistrar(nuevoempleado, env.codigohexadecimal);
                        Session["Usuario"] = nuevouser;
                        Response.Redirect("~/Vista/Registro/validarregistro.aspx?tipo=" + tipousuario.SelectedValue);
                    }
                    else if ((validaruser) && (!validarcorreo))
                    {
                        string script = "alert(\"Ese usuario ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuarioemp.Text = String.Empty;
                    }
                    else if ((!validaruser) && (validarcorreo))
                    {
                        string script = "alert(\"Ese correo ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        correoemp.Text = String.Empty;
                    }
                    else
                    {
                        string script = "alert(\"Ese usuario y ese correo ya estan registrados\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuarioemp.Text = String.Empty;
                        correoemp.Text = String.Empty;
                    }
                }
                else
                {
                    string script = "alert(\"Existen campos vacíos, por favor revise todos los campos\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void cancelarcli_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptarcli_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!correocli.Text.Equals("")) && (!nombrecli.Text.Equals("")) && (!direccioncli.Text.Equals("")) && (!usuariocli.Text.Equals("")) && (!contrasenacli.Text.Equals("")))
                {
                    ValidacionDatosCliente validar = FabricaComando.ComandoValidacionDeDatosDeCliente();
                    bool validaruser = validar.verificarusuariocli(usuariocli.Text);
                    bool validarcorreo = validar.verificarcorreocli(correocli.Text);
                    if ((!validaruser) && (!validarcorreo))
                    {
                        EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correocli.Text);
                        env.ejecutar();
                        Cliente nuevocliente = FabricaObjetos.CrearCliente(correocli.Text, nombrecli.Text, direccioncli.Text, usuariocli.Text, contrasenacli.Text);
                        UsuarioRegistrar nuevouser = new UsuarioRegistrar(nuevocliente, env.codigohexadecimal);
                        Session["Usuario"] = nuevouser;
                        Response.Redirect("~/Vista/Registro/validarregistro.aspx?tipo=" + tipousuario.SelectedValue);
                    }
                    else if ((validaruser) && (!validarcorreo))
                    {
                        string script = "alert(\"Ese usuario ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuariocli.Text = String.Empty;
                    }
                    else if ((!validaruser) && (validarcorreo))
                    {
                        string script = "alert(\"Ese correo ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        correocli.Text = String.Empty;
                    }
                    else
                    {
                        string script = "alert(\"Ese usuario y ese correo ya estan registrados\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuariocli.Text = String.Empty;
                        correocli.Text = String.Empty;
                    }
                }
                else
                {
                    string script = "alert(\"Existen campos vacíos, por favor revise todos los campos\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}