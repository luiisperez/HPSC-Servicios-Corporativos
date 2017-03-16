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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Empleado viejo = (Empleado)Session["Usuario"];
                correoemp.Text = viejo.correo;
                nombreemp.Text = viejo.nombre;
                apellidoemp.Text = viejo.apellido;
                usuarioemp.Text = viejo.usuario;
            }
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            try{
                Empleado nuevoempleado = FabricaObjetos.CrearEmpleado(correoemp.Text, nombreemp.Text, apellidoemp.Text, usuarioemp.Text, contrasenaemp.Text);
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