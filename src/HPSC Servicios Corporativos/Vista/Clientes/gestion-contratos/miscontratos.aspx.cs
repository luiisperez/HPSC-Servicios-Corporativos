using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_contratos
{
    public partial class miscontratos : System.Web.UI.Page
    {
        public Cliente cliente;
        public List<Contrato> listado = FabricaObjetos.CrearListaContratos();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            try
            {
                if (!Page.IsPostBack)
                {
                    cliente = (Cliente)Session["Usuario"];
                    if (cliente == null)
                    {
                        Response.Redirect("~/Vista/Index/index.aspx");
                    }
                    try
                    {
                        ConsultarContratosCliente cmd = FabricaComando.ComandoConsultarContratosCliente(cliente.correo);
                        cmd.ejecutar();
                        listado = cmd.contratos;
                        rep.DataSource = listado;
                        rep.DataBind();
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
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

        protected void rep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton botonpresionado = (ImageButton)e.CommandSource;
            if (botonpresionado.ID.Equals("Visualizar"))
            {
                Label id = (Label)rep.Items[e.Item.ItemIndex].FindControl("identificador");
                Session["contrato"] = id.Text;
                Response.Redirect("~/Vista/Clientes/gestion-contratos/detallecontrato.aspx");
            }
        }
    }
}