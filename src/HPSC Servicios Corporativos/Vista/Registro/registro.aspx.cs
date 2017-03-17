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
                formemp.Visible = true;
                cliform.Visible = false;
            }
            if (tipousuario.SelectedValue.Equals("Cliente"))
            {
                formemp.Visible = false;
                cliform.Visible = true;
            }
            if (tipousuario.SelectedValue.Equals("Aliado"))
            {
                formemp.Visible = false;
                cliform.Visible = false;
            }
        }

        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void correoemp_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            String correoem = Request.Form["correoemp"];
            String nombreem = Request.Form["nombreemp"];
            String apellidoem = Request.Form["apellidoemp"];
            String usuarioem = Request.Form["usuarioemp"];
            String contrasenaem = Request.Form["contrasenaemp"];
            String valcontrasenaem = Request.Form["verificarcontrasenaemp"];
            try
            {
                if ((!correoem.Equals("")) && (!nombreem.Equals("")) && (!apellidoem.Equals("")) && (!usuarioem.Equals("")) && (!contrasenaem.Equals("")) && (!valcontrasenaem.Equals("")))
                {
                    ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                    bool validaruser = validar.verificarusuarioemp(usuarioem);
                    bool validarcorreo = validar.verificarcorreoemp(correoem);
                    if ((!validaruser) && (!validarcorreo))
                    {
                        EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correoem);
                        env.ejecutar();
                        Empleado nuevoempleado = FabricaObjetos.CrearEmpleado(correoem, nombreem, apellidoem, usuarioem, contrasenaem);
                        UsuarioRegistrar nuevouser = new UsuarioRegistrar(nuevoempleado, env.codigohexadecimal);
                        Session["Usuario"] = nuevouser;
                        Response.Redirect("~/Vista/Registro/validarregistro.aspx?tipo=" + tipousuario.SelectedValue);
                    }
                    else if ((validaruser) && (!validarcorreo))
                    {
                        string script = "alert(\"Ese usuario ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuarioemp.Value = String.Empty;
                    }
                    else if ((!validaruser) && (validarcorreo))
                    {
                        string script = "alert(\"Ese correo ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        correoemp.Value = String.Empty;
                    }
                    else
                    {
                        string script = "alert(\"Ese usuario y ese correo ya estan registrados\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuarioemp.Value = String.Empty;
                        correoemp.Value = String.Empty;
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
                if ((!correocli.Value.Equals("")) && (!nombrecli.Value.Equals("")) && (!direccioncli.Value.Equals("")) && (!usuariocli.Value.Equals("")) && (!contrasenacli.Value.Equals("")))
                {
                    ValidacionDatosCliente validar = FabricaComando.ComandoValidacionDeDatosDeCliente();
                    bool validaruser = validar.verificarusuariocli(usuariocli.Value);
                    bool validarcorreo = validar.verificarcorreocli(correocli.Value);
                    if ((!validaruser) && (!validarcorreo))
                    {
                        EnviarConfirmacion env = FabricaComando.ComandoEnviarConfirmacion(correocli.Value);
                        env.ejecutar();
                        Cliente nuevocliente = FabricaObjetos.CrearCliente(correocli.Value, nombrecli.Value, direccioncli.Value, usuariocli.Value, contrasenacli.Value);
                        UsuarioRegistrar nuevouser = new UsuarioRegistrar(nuevocliente, env.codigohexadecimal);
                        Session["Usuario"] = nuevouser;
                        Response.Redirect("~/Vista/Registro/validarregistro.aspx?tipo=" + tipousuario.SelectedValue);
                    }
                    else if ((validaruser) && (!validarcorreo))
                    {
                        string script = "alert(\"Ese usuario ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuariocli.Value = String.Empty;
                    }
                    else if ((!validaruser) && (validarcorreo))
                    {
                        string script = "alert(\"Ese correo ya esta registrado\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        correocli.Value = String.Empty;
                    }
                    else
                    {
                        string script = "alert(\"Ese usuario y ese correo ya estan registrados\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        usuariocli.Value = String.Empty;
                        correocli.Value = String.Empty;
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