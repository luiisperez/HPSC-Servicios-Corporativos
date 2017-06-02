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
        private Cliente viejo;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            if (!Page.IsPostBack)
            {
                try
                {
                    viejo = (Cliente)Session["Usuario"];
                    if (viejo != null)
                    {
                        correocli.Value = viejo.correo;
                        nombrecli.Value = viejo.nombre;
                        direccioncli.Value = viejo.direccion;
                        usuariocli.Value = viejo.usuario;
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

        protected void cancelarcli_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                                                    "setTimeout(function() {history.go(-2) }, 500);", true);
        }

        protected void aceptarcli_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!correocli.Value.Equals("")) && (!nombrecli.Value.Equals("")) && (!direccioncli.Value.Equals("")) && (!usuariocli.Value.Equals("")) && (!contrasenacli.Value.Equals("")))
                {
                    Cliente nuevocliente = FabricaObjetos.CrearCliente(correocli.Value, nombrecli.Value, direccioncli.Value, usuariocli.Value, contrasenacli.Value);
                    ModificarCliente mod = FabricaComando.ComandoModificarCliente(nuevocliente);
                    mod.ejecutar();
                    ValidacionDatosCliente obtenerhash = FabricaComando.ComandoValidacionDeDatosDeCliente();
                    nuevocliente.contrasena = obtenerhash.calcularhash(nuevocliente.contrasena);
                    Session["Usuario"] = nuevocliente;
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
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se pudo modificar, por favor intente nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}