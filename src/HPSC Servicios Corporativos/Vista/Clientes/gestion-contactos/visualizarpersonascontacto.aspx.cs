using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_contactos
{
    public partial class vizualizarpersonascontacto : System.Web.UI.Page
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
                if (!Page.IsPostBack)
                {
                    try
                    {
                        ConsultarPersonasContactoPorCliente cmd = FabricaComando.ComandoConsultarPersonasContactoPorCliente(cliente.correo);
                        cmd.ejecutar();
                        List<PersonaContacto> listado = cmd.listado;
                        List<PersonaContacto> listadosineliminados = FabricaObjetos.CrearListaPersonaContacto();
                        foreach (PersonaContacto persona in listado)
                        {
                            if (!persona.estatus.Equals("Eliminado"))
                            {
                                listadosineliminados.Add(persona);
                            }
                        }
                        repPeople.DataSource = listadosineliminados;
                        repPeople.DataBind();
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
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

        protected void repPeople_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton botonpresionado = (ImageButton)e.CommandSource;
            if (botonpresionado.ID.Equals("Modificar"))
            {
                Label id = (Label)repPeople.Items[e.Item.ItemIndex].FindControl("identificador");
                Response.Redirect("/Vista/Clientes/gestion-contactos/modificarpersonacontacto.aspx?id=" + id.Text);
            }
            if (botonpresionado.ID.Equals("Eliminar"))
            {
                Label id = (Label)repPeople.Items[e.Item.ItemIndex].FindControl("identificador");
                try
                {
                    EliminarPersonaContacto cmd = FabricaComando.ComandoEliminarPersonaContacto(id.Text);
                    cmd.ejecutar();
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha eliminado exitosamente la persona de contacto");
                    var script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-contactos/visualizarpersonascontacto.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                catch (Exception ex)
                {
                    string script = "alert(\"Ha ocurido un error intente nuevamente\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
        }
    }
}