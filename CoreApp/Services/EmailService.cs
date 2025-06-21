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

        public void EmailCreateUser(string toEmail, string userName)
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
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
        public void EmailNewMovie(string movieTitle, List<string> userEmails)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(senderEmail, appPassword),
                    EnableSsl = true
                };
                foreach (var email in userEmails)
                {
                    var mail = new MailMessage
                    {
                        From = new MailAddress(senderEmail, "CenfoCinemas"),
                        Subject = "Nueva Película Disponible",
                        Body = $"Hola,\n\n¡Tenemos una nueva película disponible: {movieTitle}!\n\n¡No te la pierdas!",
                        IsBodyHtml = false
                    };
                    mail.To.Add(email);
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
