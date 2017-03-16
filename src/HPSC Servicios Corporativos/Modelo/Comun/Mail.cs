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
    }
}