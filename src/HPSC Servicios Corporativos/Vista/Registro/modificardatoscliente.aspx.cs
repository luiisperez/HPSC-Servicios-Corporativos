using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEmpleados;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Registro
{
    public partial class modificardatoslcliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cliente viejo = (Cliente)Session["Usuario"];
                if (viejo != null)
                {
                    correocli.Text = viejo.correo;
                    nombrecli.Text = viejo.nombre;
                    direccioncli.Text = viejo.direccion;
                    usuariocli.Text = viejo.usuario;
                }
                else
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
            }
        }

        protected void cancelarcli_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                    "setTimeout(function() {history.go(-2) }, 500);", true);
        }

        protected void aceptarcli_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!correocli.Text.Equals("")) && (!nombrecli.Text.Equals("")) && (!direccioncli.Text.Equals("")) && (!usuariocli.Text.Equals("")) && (!contrasenacli.Text.Equals("")))
                {
                    Cliente nuevocliente = FabricaObjetos.CrearCliente(correocli.Text, nombrecli.Text, direccioncli.Text, usuariocli.Text, contrasenacli.Text);
                    ModificarCliente mod = FabricaComando.ComandoModificarCliente(nuevocliente);
                    mod.ejecutar();
                    string script = "alert(\"Ha modificado sus datos exitosamente y será redirigido a la ventana anterior\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    ValidacionDatosCliente obtenerhash = FabricaComando.ComandoValidacionDeDatosDeCliente();
                    nuevocliente.contrasena = obtenerhash.calcularhash(nuevocliente.contrasena);
                    Session["Usuario"] = nuevocliente;
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
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}