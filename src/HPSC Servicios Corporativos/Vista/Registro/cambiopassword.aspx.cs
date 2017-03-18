using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro
{
    public partial class cambiopassword : System.Web.UI.Page
    {
        String tipo;
        String correo;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipo = Request.QueryString["tipo"];
            correo = Request.QueryString["correo"];
        }

        protected void cancelaremp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptaremp_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!contrasena.Value.Equals("")) && (!contrasenarepe.Value.Equals("")))
                {
                    ValidacionDatos validar = FabricaComando.ComandoValidacionDeDatos();
                    String hash = validar.calcularhash(contrasena.Value);
                    CambiarPassword cmd = FabricaComando.ComandoCambiarPassword(correo, hash, tipo);
                    cmd.ejecutar();
                    string script = "alert(\"Ha cambiado su contraseña exitosamente y será redirigido al inicio\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    Response.AddHeader("REFRESH", "1;URL=/Vista/Index/index.aspx");
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error intentelo nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}