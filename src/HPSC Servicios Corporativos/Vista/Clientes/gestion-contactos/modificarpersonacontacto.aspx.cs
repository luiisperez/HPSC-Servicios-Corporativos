using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_contactos
{
    public partial class modificarpersonacontacto : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                try
                {
                    ConsultarPersonaContacto cmd = FabricaComando.ComandoConsultarPersonaContacto(Request.QueryString["id"]);
                    cmd.ejecutar();
                    PersonaContacto consultada = cmd.consultado;
                    correo.Value = consultada.correo;
                    nombre.Value = consultada.nombre;
                    apellido.Value = consultada.apellido;
                    telflocal.Value = consultada.telflocal;
                    telfmovil.Value = consultada.telfmovil;
                    estatus.Value = consultada.estatus;
                }
                catch (Exception ex)
                {
                    string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Clientes/gestion-contactos/visualizarpersonascontacto.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!nombre.Value.Equals("")) && (!apellido.Value.Equals("")) && (!correo.Value.Equals("")) && (!telflocal.Value.Equals("")))
            {
                ConsultarPersonaContacto _cmd = FabricaComando.ComandoConsultarPersonaContacto(correo.Value);
                _cmd.ejecutar();
                if ((_cmd.consultado != null) && (!correo.Value.Equals(Request.QueryString["id"])))
                {
                    string script = "alert(\"El correo ingresado ya se encuentra registrado\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
                else
                {
                    PersonaContacto persona = FabricaObjetos.CrearPersonaContacto(correo.Value, nombre.Value, apellido.Value, telflocal.Value, telfmovil.Value, estatus.Value, cliente.correo);
                    ModificarPersonaContacto cmd = FabricaComando.ComandoModificarPersonaContacto(persona, Request.QueryString["id"]);
                    try
                    {
                        cmd.ejecutar();
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha modificado la persona de contacto exitosamente");
                        var script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-contactos/visualizarpersonascontacto.aspx';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurrido un error por favor intentelo nuevamente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
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