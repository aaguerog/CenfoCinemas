using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class EmailService
    {
        private readonly string senderEmail = "aaguerog@ucenfotec.ac.cr";
        private readonly string appPassword = "ogbd idpz kuys bypb";

        public void SendWelcomeEmail(string toEmail, string userName)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(senderEmail, appPassword),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(senderEmail, "CenfoCinemas"),
                    Subject = "¡Bienvenido a CenfoCinemas!",
                    Body = $"Hola {userName},\n\nGracias por registrarte en nuestra plataforma.\n\n¡Disfruta de las mejores películas!",
                    IsBodyHtml = false
                };

                mail.To.Add(toEmail);

                client.Send(mail);
            }
            catch (Exception ex)
            {
                // Puedes loguear o manejar el error como prefieras
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
