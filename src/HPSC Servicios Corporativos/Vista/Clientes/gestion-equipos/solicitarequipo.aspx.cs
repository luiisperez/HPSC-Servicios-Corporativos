using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_equipos
{
    public partial class solicitarequipo : System.Web.UI.Page
    {
        public Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            try
            {
                cliente = (Cliente)Session["Usuario"];
                if (cliente == null)
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!marca.Value.Equals("")) && (!modelo.Value.Equals("")) && (!correo.Value.Equals("")) && (!apellido.Value.Equals("")) && (!telflocal.Value.Equals("")) && (!nombre.Value.Equals("")))
            {
                SolicitudEquipo nuevasolicitud = FabricaObjetos.CrearSolicitudDeEquipo(FabricaObjetos.CrearEquipo(listadocategoria.SelectedValue, marca.Value, modelo.Value), 
                                                                                       correo.Value, 
                                                                                       nombre.Value, 
                                                                                       apellido.Value, 
                                                                                       telflocal.Value, 
                                                                                       telfmovil.Value);
                try
                {
                    EnviarSolicitudDeEquipo env = FabricaComando.ComandoEnviarSolicitudDeEquipo(nuevasolicitud, cliente.nombre);
                    env.ejecutar();
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha enviado su solicitud exitosamente y será revisada por nosotros en lo posible");
                    var script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-equipos/solicitarequipo.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                catch (Exception ex)
                {
                    string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"Existen campos vacíos, por favor revise los campos\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
    }
}