using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
using HPSC_Servicios_Corporativos.Controlador.ModuloEquipo;
using HPSC_Servicios_Corporativos.Controlador.ModuloPersonaContacto;
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
            if ((!correoprincipal.Value.Equals("")) && (!correosecundario.Value.Equals("")) && (!direccion.Value.Equals("")) && (!descripcion.Value.Equals("")) && (!numequipo.Value.Equals("")))
            {
                try
                {
                    DateTime fechahoy = DateTime.Now.ToUniversalTime().AddHours(-4);
                    DateTime fecharegistro = fechahoy;
                    DateTime fechamodificada = fechahoy/*.AddHours(-48)*/;
                    ConsultarFeriados cmd = FabricaComando.ComandoConsultarFeriados();
                    cmd.ejecutar();
                    List<Feriado> feriados = cmd.feriados;
                    ConsultarServicio _cmd = FabricaComando.ComandoConsultarServicio(idservicio.Text);
                    _cmd.ejecutar();
                    Servicio serv = _cmd.servicioconsultado;
                    if (serv.canthoras != 24)
                    {
                        int horaini = 8;
                        int horafin = horaini + serv.canthoras;
                        if ((fechamodificada.Hour < horaini) && (fechamodificada.Hour >= 4))
                        {
                            fecharegistro = new DateTime(fechamodificada.Year, fechamodificada.Month, fechamodificada.Day, 8, 0, 0);
                        }
                        if ((fechamodificada.Hour >= horafin) || (fechamodificada.Hour < 4))
                        {
                            fecharegistro = new DateTime(fechamodificada.AddDays(1).Year, fechamodificada.AddDays(1).Month, fechamodificada.AddDays(1).Day, 8, 0, 0);
                        }
                    }
                    if (serv.cantdias != 7)
                    {
                        DayOfWeek dia = fecharegistro.DayOfWeek;
                        if ((dia.ToString().Equals("Sábado")) || (dia.ToString().Equals("Saturday")) || (dia.ToString().Equals("Sabado")))
                        {
                            fecharegistro = fecharegistro.AddDays(2);
                        }
                        else if ((dia.ToString().Equals("Domingo")) || (dia.ToString().Equals("Sunday")))
                        {
                            fecharegistro = fecharegistro.AddDays(1);
                        }
                    }
                    if (serv.feriado.Equals("No"))
                    {
                        foreach (Feriado item in feriados)
                        {
                            if ((fecharegistro.Day == item.dia) && (fecharegistro.Month == item.mes))
                            {
                                fecharegistro = fecharegistro.AddDays(1);
                            }
                        }
                    }
                    DateTime fechacompromiso = fecharegistro.AddHours(serv.tiemporespuesta);
                    if (serv.cantdias != 7)
                    {
                        DayOfWeek dia = fechacompromiso.DayOfWeek;
                        if ((dia.ToString().Equals("Sábado")) || (dia.ToString().Equals("Saturday")) || (dia.ToString().Equals("Sabado")))
                        {
                            fechacompromiso = fechacompromiso.AddDays(2);
                        }
                        else if ((dia.ToString().Equals("Domingo")) || (dia.ToString().Equals("Sunday")))
                        {
                            fechacompromiso = fechacompromiso.AddDays(1);
                        }
                    }
                    if (serv.feriado.Equals("No"))
                    {
                        foreach (Feriado item in feriados)
                        {
                            if ((fechacompromiso.Day == item.dia) && (fechacompromiso.Month == item.mes))
                            {
                                fechacompromiso = fechacompromiso.AddDays(1);
                            }
                        }
                    }
                    DateTime fecharequerida = fechacompromiso;
                    String id = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    Incidente nuevoincidente = FabricaObjetos.CrearIncidente(id, fechahoy, fechacompromiso, fecharequerida, new DateTime(), new DateTime(), "Abierto", "Soporte reactivo", impacto.Text, urgencia.Text, direccion.Value, descripcion.Value, cliente.correo, numequipo.Value, "", "", correoprincipal.Value, correosecundario.Value, idcontrato.Text, idservicio.Text);
                    AgregarIncidente _command = FabricaComando.ComandoAgregarIncidente(nuevoincidente);
                    _command.ejecutar();
                    try
                    {
                        EnviarCorreoIncidenteRegistrado command = FabricaComando.ComandoEnviarCorreoIncidenteRegistrado(nuevoincidente, cliente.nombre);
                        command.ejecutar();
                    }
                    catch (Exception ex)
                    {
                        var _message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No se ha podido enviar el correo de confirmación de registro del incidente");
                        var _script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-incidentes/agregarincidente.aspx';", _message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", _script, true);
                    }
                    var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha registrado el incidente exitosamente en el sistema y a la brevedad posible recibirá un correo de confirmación");
                    var script = string.Format("alert({0});window.location ='/Vista/Clientes/gestion-incidentes/agregarincidente.aspx';", message);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                }
                catch (Exception ex)
                {
                    string script = "alert(\"No se ha podido registrar, por favor intente nuevamente\");";
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

        [WebMethod]
        public static String FillFieldsContacto(String mail, String contacto)
        {
            try
            {
                ConsultarPersonasContactoPorCliente _cmd = FabricaComando.ComandoConsultarPersonasContactoPorCliente(mail);
                _cmd.ejecutar();
                List<PersonaContacto> listado = _cmd.listado;
                PersonaContacto persona = FabricaObjetos.CrearPersonaContacto("", "", "", "", "", "");
                bool verdadero = false;
                foreach (PersonaContacto item in listado)
                {
                    if (item.correo.Equals(contacto))
                    {
                        verdadero = true;
                        persona = item;
                    }
                }
                if (verdadero)
                {
                    return "Exito;" + persona.nombre + " " + persona.apellido;
                }
                else
                {
                    return "No tiene ninguna persona de contacto con dicho correo";
                }
            }
            catch (Exception ex)
            {
                return ("No se pudo realizar la búsqueda, por favor intente nuevamente");
            }
        }
    }
}