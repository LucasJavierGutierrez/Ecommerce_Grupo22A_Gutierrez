using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailServices
    {
        private MailMessage email;
        private SmtpClient server;
        public EmailServices()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("69853b34000c16", "033074ac1e598c");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";
        }
        public void armarCorreoBienvenida(string emailDestino, string asunto)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@implanteDental.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<br> <h3 style=\"font -family:Arial;\"te has inscripto correctamente a Implante dental</h3>";
            ;
            // "<h1> Bienvenido!!!" + email + "  </h1> <br> <p>te has inscripto correctamente a Implante dental</p>";
        }
        public void armarCorreoCompra(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@implanteDental.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
            ;
            // "<h1> Bienvenido!!!" + email + "  </h1> <br> <p>te has inscripto correctamente a Implante dental</p>";
        }
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
