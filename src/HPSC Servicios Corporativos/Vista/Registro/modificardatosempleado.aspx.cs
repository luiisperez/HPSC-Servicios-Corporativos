using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro_Modificacion
{
    public partial class modificardatosempleado : System.Web.UI.Page
    {
        private Empleado viejo;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            if (!Page.IsPostBack)
            {
                try
                {
                    viejo = (Empleado)Session["Usuario"];
                    if (viejo != null)
                    {
                        correoemp.Value = viejo.correo;
                        nombreemp.Value = viejo.nombre;
                        apellidoemp.Value = viejo.apellido;
                        usuarioemp.Value = viejo.usuario;
                    }
                    else
                    {
                        Response.Redirect("~/Vista/Index/index.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
                
            }
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            try{
                ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                bool validaruser = validar.verificarusuarioemp(usuarioemp.Value);
                if (!validaruser || (nombreemp.Value.Equals(viejo.usuario)))
                {
                    if ((!correoemp.Value.Equals("")) && (!nombreemp.Value.Equals("")) && (!apellidoemp.Value.Equals("")) && (!usuarioemp.Value.Equals("")) && (!contrasenaemp.Value.Equals("")))
                    {
                        Empleado nuevoempleado = FabricaObjetos.CrearEmpleado(correoemp.Value, nombreemp.Value, apellidoemp.Value, usuarioemp.Value, contrasenaemp.Value);
                        ModificarEmpleado mod = FabricaComando.ComandoModificarEmpleado(nuevoempleado);
                        mod.ejecutar();
                        string script = "alert(\"Ha modificado sus datos exitosamente y será redirigido a la ventana anterior\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                        ValidacionDatos obtenerhash = FabricaComando.ComandoValidacionDeDatos();
                        nuevoempleado.contrasena = obtenerhash.calcularhash(nuevoempleado.contrasena);
                        Session["Usuario"] = nuevoempleado;
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                                "setTimeout(function() {history.go(-2) }, 500);", true);
                    }
                    else
                    {
                        string script = "alert(\"Existen campos vacíos, por favor revise todos los campos\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                }
                else
                {
                    string script = "alert(\"Ese usuario ya esta registrado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                    usuarioemp.Value = String.Empty;
                }
            }catch(Exception ex){
                string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
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