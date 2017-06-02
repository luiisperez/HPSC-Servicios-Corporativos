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
            viejo = (Empleado)Session["Usuario"];
            if (!Page.IsPostBack)
            {
                try
                {
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
            try
            {
                if ((!correoemp.Value.Equals("")) && (!nombreemp.Value.Equals("")) && (!apellidoemp.Value.Equals("")) && (!usuarioemp.Value.Equals("")) && (!contrasenaemp.Value.Equals("")))
                {
                    Empleado nuevoempleado = FabricaObjetos.CrearEmpleado(correoemp.Value, nombreemp.Value, apellidoemp.Value, usuarioemp.Value, contrasenaemp.Value, viejo.rol);
                    ModificarEmpleado mod = FabricaComando.ComandoModificarEmpleado(nuevoempleado);
                    mod.ejecutar();
                    ValidacionDatos obtenerhash = FabricaComando.ComandoValidacionDeDatos();
                    nuevoempleado.contrasena = obtenerhash.calcularhash(nuevoempleado.contrasena);
                    Session["Usuario"] = nuevoempleado;
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Ha modificado sus datos exitosamente");
                    string script = string.Format("alert({0});window.location ='/Vista/Empleados/administracionHPSC.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                else
                {
                    string script = "alert(\"Existen campos vacíos, por favor revise todos los campos\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }catch(Exception ex){
                string script = "alert(\"No se pudo modificar, por favor intente nuevamente\");";
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