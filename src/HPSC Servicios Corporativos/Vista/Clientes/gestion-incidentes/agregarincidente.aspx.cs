using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPSC_Servicios_Corporativos.Vista.Clientes.gestion_incidentes
{
    public partial class agregarincidente : System.Web.UI.Page
    {
        public Cliente cliente;
        Servicio serv;
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
                correo.Text = cliente.correo;
            }
            catch
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            try
            {
                List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposCliente cmd = FabricaComando.ComandoConsultarEquiposPorCliente(cliente.correo);
                cmd.ejecutar();
                equipos = cmd.equipos;
                String opciones = "";
                foreach (Equipo item in equipos)
                {
                    if (!item.estatus.Equals("Eliminado"))
                    {
                        String itemvalue = "Categoría: " + item.categoria + ". Equipo: " + item.marca + "/" + item.modelo;
                        opciones = opciones + "<option value=\"" + item.serial + "\" label=\"" + itemvalue + "\" >";
                    }
                }
                listado_equipos.InnerHtml = opciones;
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!correoprincipal.Value.Equals("")) && (!correosecundario.Value.Equals("")))
            {
                try
                {
                    //EnviarSolicitudDeEquipo env = FabricaComando.ComandoEnviarSolicitudDeEquipo(nuevasolicitud, cliente.nombre);
                    //env.ejecutar();
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

        [WebMethod]
        public static String FillFields(String serial, String mail)
        {
            try
            {
                List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposCliente cmd = FabricaComando.ComandoConsultarEquiposPorCliente(mail);
                cmd.ejecutar();
                equipos = cmd.equipos;
                String opciones = "";
                bool verdad = false;
                Equipo equip = FabricaObjetos.CrearEquipo("","","");
                foreach (Equipo item in equipos)
                {
                    if (item.serial.Equals(serial))
                    {
                        verdad = true;
                        equip = item;
                    }
                }
                if (!verdad)
                {
                    return "No existe el serial colocado, por favor verifique";
                }
                else
                {
                    ConsultarServiciosPorEquipo _cmd = FabricaComando.ComandoConsultarServiciosPorEquipo(serial);
                    _cmd.ejecutar();
                    List<Servicio> listado = _cmd.servicios;
                    Servicio menor = FabricaObjetos.CrearServicio("", "", 99999, 0, "", 99999);
                    bool verdadero = false;
                    foreach (Servicio item in listado)
                    {
                        if (item.tiposervicio.Equals("Soporte reactivo"))
                        {
                            if (item.estatus.Equals("Vigente"))
                            {
                                if (item.tiemporespuesta < menor.tiemporespuesta)
                                {
                                    menor = item;
                                    verdadero = true;
                                }
                            }
                        }
                    }
                    if (verdadero)
                    {
                        return "Exito;" + menor.identificador + ";" + menor.nivelservicio + ";" + menor.canthoras + ";" + menor.cantdias + ";" + menor.tiposervicio + ";" + menor.tiemporespuesta + ";" + menor.feriado + ";" + menor.identificadorservicioequipo + ";" + menor.dias.Replace(",", ", ") + ";" + equip.ubicacion;
                    }
                    else
                    {
                        return "No tiene ningún contrato vigente para registrar el incidente";
                    }
                }
            }
            catch (Exception ex)
            {
                return ("No se pudo realizar la búsqueda, por favor intente nuevamente");
            }
        }
    }
}