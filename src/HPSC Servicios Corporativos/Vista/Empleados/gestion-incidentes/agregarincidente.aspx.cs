using HPSC_Servicios_Corporativos.Controlador;
using HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Controlador.ModuloClientes;
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

namespace HPSC_Servicios_Corporativos.Vista.Empleados.gestion_incidentes
{
    public partial class agregarincidente : System.Web.UI.Page
    {
        protected Empleado emp;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");
            emp = (Empleado)Session["Usuario"];
            if (emp == null)
            {
                Response.Redirect("~/Vista/Index/index.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Int32.Parse(emp.rol) >= 20) //ADMINISTRADOR
                    {
                        zonausuarios.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#usuarios\" id=\"users\" runat=\"server\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"usuarios\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarempleados\" href=\"/Vista/Empleados/gestion-empleados/visualizarempleados.aspx\">Visualizar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/rolesempleados.aspx\">Asignación de roles</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-empleados/compensaciones.aspx\">Compensaciones</a>" +
                                "</li>" +
                            "</ul>";
                        zonaclientes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#clientes\" id=\"clients\" runat=\"server\"><i class=\"fa fa-briefcase\"></i> Clientes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"clientes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/visualizarclientes.aspx\">Visualizar</a>" +
                               "</li>" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/asignarequipo.aspx\">Asignar equipos</a>" +
                               "</li>" +
                            "</ul>";
                        zonaequipos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#equipos\" id=\"equipment\" runat=\"server\"><i class=\"fa fa-laptop\"></i> Equipos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"equipos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-equipos/agregarequipo.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-equipos/visualizarequipos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonaproductos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#productos\" id=\"products\" runat=\"server\"><i class=\"fa fa-barcode\"></i> Productos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"productos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-productos/agregarproducto.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-productos/visualizarproductos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonacontratos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#contratos\" id=\"services\" runat=\"server\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"contratos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-servicios/agregarservicio.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-servicios/visualizarservicios.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#asignarservicios\" id=\"servicesequipment\" runat=\"server\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"asignarservicios\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-contratos/agregarcontrato.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-contratos/visualizarcontratos.aspx\">Contratos registrados</a>" +
                                "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-contratos/visualizarserviciosequipo.aspx\">Servicios por equipo</a>" +
                                "</li>" +
                            "</ul>";
                        zonapersonascontacto.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#personas\" id=\"contact\" runat=\"server\"><i class=\"fa fa-phone\"></i> Personal de contacto <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"personas\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-contactos/visualizarpersonascontacto.aspx\">Visualizar</a>" +
                               "</li>" +
                            "</ul>";
                        zonaincidentes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#incidentes\" id=\"incidente\" runat=\"server\"><i class=\"fa fa fa-warning\"></i> Incidentes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"incidentes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-incidentes/agregarincidente.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-incidentes/incidentes.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                    }
                    else if (Int32.Parse(emp.rol) == 10) //COORDINADOR DE SERVICIOS
                    {
                        zonausuarios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#clientes\" id=\"clients\" runat=\"server\"><i class=\"fa fa-briefcase\"></i> Clientes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"clientes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/visualizarclientes.aspx\">Visualizar</a>" +
                               "</li>" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-clientes/asignarequipo.aspx\">Asignar equipos</a>" +
                               "</li>" +
                            "</ul>";
                        zonaequipos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#equipos\" id=\"equipment\" runat=\"server\"><i class=\"fa fa-laptop\"></i> Equipos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"equipos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-equipos/agregarequipo.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-equipos/visualizarequipos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonaproductos.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#productos\" id=\"products\" runat=\"server\"><i class=\"fa fa-barcode\"></i> Productos <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"productos\" class=\"collapse\">" +
                               "<li>" +
                                    "<a id=\"visualizarclientes\" href=\"/Vista/Empleados/gestion-productos/agregarproducto.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-productos/visualizarproductos.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                        zonacontratos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonapersonascontacto.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#personas\" id=\"contact\" runat=\"server\"><i class=\"fa fa-phone\"></i> Personal de contacto <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"personas\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-contactos/visualizarpersonascontacto.aspx\">Visualizar</a>" +
                               "</li>" +
                            "</ul>";
                        zonaincidentes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#incidentes\" id=\"incidente\" runat=\"server\"><i class=\"fa fa fa-warning\"></i> Incidentes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"incidentes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-incidentes/agregarincidente.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-incidentes/incidentes.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                    }
                    else if (Int32.Parse(emp.rol) == 5) //INGENIERO DE SOPORTE
                    {
                        zonausuarios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-user\"></i> Empleados <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaclientes.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-briefcase\"></i> Clientes <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaequipos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-laptop\"></i> Equipos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaproductos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-barcode\"></i> Productos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonacontratos.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-folder-open\"></i> Servicios <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaasignacionservicios.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-book\"></i> Contratos <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonapersonascontacto.InnerHtml = "<a href=\"#\" onclick=\"privilegiosinsuficientes()\"><i class=\"fa fa-phone\"></i> Personal de contacto <i class=\"fa fa-lock\" aria-hidden=\"true\"></i></a>";
                        zonaincidentes.InnerHtml = "<a href=\"javascript:;\" data-toggle=\"collapse\" data-target=\"#incidentes\" id=\"incidente\" runat=\"server\"><i class=\"fa fa fa-warning\"></i> Incidentes <i class=\"fa fa-fw fa-caret-down\"></i></a>" +
                            "<ul id=\"incidentes\" class=\"collapse\">" +
                               "<li>" +
                                    "<a href=\"/Vista/Empleados/gestion-incidentes/agregarincidente.aspx\">Agregar</a>" +
                               "</li>" +
                                "<li>" +
                                     "<a href=\"/Vista/Empleados/gestion-incidentes/incidentes.aspx\">Visualizar</a>" +
                                "</li>" +
                            "</ul>";
                    }
                    else
                    {
                        Response.Redirect("~/Vista/Empleados/administracionHPSC.aspx");
                    }
                    try
                    {
                        List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
                        ConsultarClientes _cmd = FabricaComando.ComandoConsultarClientes();
                        _cmd.ejecutar();
                        clientes = _cmd.clientes;
                        list_clientes.Items.Add(new ListItem("", "NULL"));
                        foreach (Cliente item in clientes)
                        {
                            list_clientes.Items.Add(new ListItem(item.nombre, item.correo));
                        }
                    }
                    catch (Exception ex)
                    {
                        string script = "alert(\"No se pudo cargar la información en la página, por favor refresque la página\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                catch
                {
                    Response.Redirect("~/Vista/Index/index.aspx");
                }
            }
        }

        protected void sesioncerrar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Vista/Index/index.aspx");
        }

        protected void list_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!list_clientes.Text.Equals("NULL"))
            {
                List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposCliente cmd = FabricaComando.ComandoConsultarEquiposPorCliente(list_clientes.SelectedValue);
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
                listado_eq.InnerHtml = opciones;
            }
            else
            {
                listado_eq.InnerHtml = "NULL";
            }
        }

        [WebMethod]
        public static String FillFieldsContacto(String mail, String contacto)
        {
            try
            {
                ConsultarClientes cmd = FabricaComando.ComandoConsultarClientes();
                cmd.ejecutar();
                List<Cliente> _listado = cmd.clientes;
                String correo = "";
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

        protected void tiposerv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
                ConsultarEquiposCliente cmd = FabricaComando.ComandoConsultarEquiposPorCliente(list_clientes.SelectedValue);
                cmd.ejecutar();
                equipos = cmd.equipos;
                String opciones = "";
                bool verdad = false;
                Equipo equip = FabricaObjetos.CrearEquipo("", "", "");
                foreach (Equipo item in equipos)
                {
                    if (item.serial.Equals(equipoinput.Value))
                    {
                        verdad = true;
                        equip = item;
                    }
                }
                if (!verdad)
                {
                    string script = "alert(\"El serial ingresado no es válido, por favor ingrese un serial válido\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                    equipoinput.Value = "";
                    tiposerv.Text = "";
                    info.Attributes.Add("Title", "");
                }
                else
                {
                    ConsultarServiciosPorEquipo _cmd = FabricaComando.ComandoConsultarServiciosPorEquipo(equipoinput.Value);
                    _cmd.ejecutar();
                    List<Servicio> listado = _cmd.servicios;
                    Servicio menor = FabricaObjetos.CrearServicio("", "", 99999, 0, "", 99999);
                    bool verdadero = false;
                    foreach (Servicio item in listado)
                    {
                        if (item.tiposervicio.Equals(tiposerv.Text))
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
                        String result = "Exito;" + menor.identificador + ";" + menor.nivelservicio + ";" + menor.canthoras + ";" + menor.cantdias + ";" + menor.tiposervicio + ";" + menor.tiemporespuesta + ";" + menor.feriado + ";" + menor.identificadorservicioequipo + ";" + menor.dias.Replace(",", ", ") + ";" + equip.ubicacion;
                        String[] separar = result.Split(';');
                        String mensaje = "Datos del servicio: \n - Nivel de servicio: " + separar[2] + " " + separar[3] + " hora(s) X " + separar[4] + " día(s) \n - Tipo de servicio: " + separar[5] + " \n - Tiempo de respuesta: " + separar[6] + "hora(s) \n - ¿Incluye feriados?: " + separar[7] + " \n - Días de trabajo: " + separar[9];

                        if (Int32.Parse(separar[3]) != 24) 
                        {
                            mensaje = mensaje + " \n - Horario: 8:00 - " + (8 + Int32.Parse(separar[3])) + ":00";
                        } 
                        else 
                        {
                            mensaje = mensaje + " \n - Horario: Todo el día";
                        }
                        info.Attributes.Add("Title", mensaje);
                        idcontrato.Text = separar[8];
                        idservicio.Text = separar[1];
                        direccion.Value = separar[10];
                    }
                    else
                    {
                        string script = "alert(\"No tiene ningún contrato vigente para registrar el incidente\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                        equipoinput.Value = "";
                        tiposerv.Text = "";
                        info.Attributes.Add("Title", "");
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"No se pudo realizar la búsqueda, por favor intente nuevamente\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
                equipoinput.Value = "";
                tiposerv.Text = "";
                info.Attributes.Add("Title", "");
            }
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if ((!correoprincipal.Value.Equals("")) && (!correosecundario.Value.Equals("")) && (!direccion.Value.Equals("")) && (!descripcion.Value.Equals("")) && (!equipoinput.Value.Equals("")))
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
                    Incidente nuevoincidente = FabricaObjetos.CrearIncidente(id, fechahoy, fechacompromiso, fecharequerida, new DateTime(), new DateTime(), "Abierto", tiposerv.SelectedValue, impacto.Text, urgencia.Text, direccion.Value, descripcion.Value, list_clientes.SelectedValue, equipoinput.Value, "", "", correoprincipal.Value, correosecundario.Value, idcontrato.Text, idservicio.Text);
                    AgregarIncidente _command = FabricaComando.ComandoAgregarIncidente(nuevoincidente);
                    _command.ejecutar();
                    try
                    {
                        EnviarCorreoIncidenteRegistrado command = FabricaComando.ComandoEnviarCorreoIncidenteRegistrado(nuevoincidente, list_clientes.SelectedValue);
                        command.ejecutar();
                        var message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("Se ha registrado el incidente exitosamente en el sistema y a la brevedad posible recibirá un correo de confirmación");
                        var script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-incidentes/agregarincidente.aspx';", message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", script, true);
                    }
                    catch (Exception ex)
                    {
                        var _message = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize("No se ha podido enviar el correo de confirmación de registro del incidente pero incidente fue registrado exitosamente");
                        var _script = string.Format("alert({0});window.location ='/Vista/Empleados/gestion-incidentes/agregarincidente.aspx';", _message);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", _script, true);
                    }
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
    }
}