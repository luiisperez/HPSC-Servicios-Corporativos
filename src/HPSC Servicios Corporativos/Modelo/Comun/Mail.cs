using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Comun
{
    public class Mail
    {
        public void EnviarCorreo(String receptor, String codigo)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(receptor, receptor));
                msg.From = new MailAddress("noreply@hp-sc.net", "noreply@hp-sc.net");
                msg.Subject = RecursoMail.Cabecera;
                msg.Body = RecursoMail.Cuerpo + codigo;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(RecursoMail.Correo, RecursoMail.PWD);
                client.Port = 587; // You can use Port 25 if 587 is blocked
                client.Host = "smtp.office365.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarSolicitud(SolicitudEquipo nuevasolicitud, String cliente)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress("luis.alejandro120895@gmail.com", "luis.alejandro120895@gmail.com"));
                //msg.To.Add(new MailAddress(RecursoMail.Correo, RecursoMail.Correo));
                msg.From = new MailAddress("noreply@hp-sc.net", "noreply@hp-sc.net");
                msg.Subject = RecursoMail.CabeceraSolicitud + "Cliente: " + cliente + ". Fecha/Hora: " + DateTime.Now;
                msg.Body = cliente + " " + RecursoMail.CuerpoSolicitudP1 + Environment.NewLine +
                                "   • Categoría: " + nuevasolicitud.equipo.categoria + Environment.NewLine +
                                "   • Marca: " + nuevasolicitud.equipo.marca + Environment.NewLine +
                                "   • Modelo: " + nuevasolicitud.equipo.modelo + Environment.NewLine + Environment.NewLine +
                           RecursoMail.CuerpoSolicitudP2 + Environment.NewLine +
                                "   • Nombre: " + nuevasolicitud.nombre + " " + nuevasolicitud.apellido + Environment.NewLine +
                                "   • Correo: " + nuevasolicitud.correo + Environment.NewLine +
                                "   • Teléfono local: " + nuevasolicitud.telflocal + Environment.NewLine;
                if (nuevasolicitud.telfmovil.Equals(Environment.NewLine))
                {
                    msg.Body = msg.Body +
                                "   • Teléfono móvil: No aplica";
                }
                else
                {
                    msg.Body = msg.Body +
                                "   • Teléfono móvil: " + nuevasolicitud.telfmovil;
                }
                msg.IsBodyHtml = false;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(RecursoMail.Correo, RecursoMail.PWD);
                client.Port = 587; // You can use Port 25 if 587 is blocked
                client.Host = "smtp.office365.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarIncidente(Incidente nuevoincidente, String nombrecliente)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(nuevoincidente.cliente, nuevoincidente.cliente));
                //msg.To.Add(new MailAddress("luis_alejandro0812@hotmail.com", "luis_alejandro0812@hotmail.com"));
                msg.To.Add(new MailAddress(RecursoMail.Correo, RecursoMail.Correo));
                msg.From = new MailAddress("noreply@hp-sc.net", "noreply@hp-sc.net");
                msg.Subject = "Registro de Incidente N° " + nuevoincidente.id;
                msg.Body = "Se ha registrado exitosamente el incidente de ID " + nuevoincidente.id + " de " + nombrecliente + " a continuación se presentan los siguientes detalles del mismo: " + Environment.NewLine +
                                "   • Fecha y hora de registro: " + nuevoincidente.fecharegistro.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                                "   • Fecha de compromiso: " + nuevoincidente.fechacompromiso.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                                "   • Serial del equipo: " + nuevoincidente.equipo + Environment.NewLine +
                                "   • Dirección: " + nuevoincidente.direccion + Environment.NewLine +
                                "   • Descripción: " + nuevoincidente.descripcion + Environment.NewLine +
                                "Para mayor información puede consultar en el portal y si tiene alguna duda contáctenos";
                msg.IsBodyHtml = false;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(RecursoMail.Correo, RecursoMail.PWD);
                client.Port = 587; // You can use Port 25 if 587 is blocked
                client.Host = "smtp.office365.com";
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}