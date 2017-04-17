using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_contratos
{
    public partial class detallecontrato : System.Web.UI.Page
    {
        public String contrato;
        public List<Servicio> listado = FabricaObjetos.CrearListaServicios();
        public List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
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
                        contrato = (String)Session["contrato"];
                        ConsultarEquipoContrato cmd = FabricaComando.ComandoConsultarEquipoContrato(contrato);
                        cmd.ejecutar();
                        equipos = cmd.lista;
                        ConsultarServicioContrato _cmd = FabricaComando.ComandoConsultarServicioContrato(contrato);
                        _cmd.ejecutar();
                        listado = _cmd.lista;
                        String html = "";
                        foreach (Servicio item in listado)
                        {
                            String dias = item.dias;
                            html = html + "<p style=\"font-size:15px;margin-left:30px\">• " + item.nivelservicio + " " + item.canthoras + "x" + item.dias.Split(',').Count() + ", Tipo de servicio: " + item.tiposervicio + ", Feriado: " + item.feriado + ", Tiempo de respuesta: " + item.tiemporespuesta + " hora(s)" + ", Días de trabajo: " + dias.Replace(",", ", ") + "</p>";
                        }
                        servicios.InnerHtml = html;
                        html = "";
                        foreach (Equipo item in equipos)
                        {
                            html = html + "<p style=\"font-size:15px;margin-left:30px\">• " + "Serial: " + item.serial + ". Marca: " + item.marca + ". Modelo: " + item.modelo + ". Categoría: " + item.categoria + "</p>";
                        }
                        equipment.InnerHtml = html;
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Clientes/gestion-contratos/miscontratos.aspx");
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }
    }
}