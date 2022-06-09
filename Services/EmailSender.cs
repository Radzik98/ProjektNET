using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 
namespace ProjektNET.Services
{
    public class EmailSender
    {
        public EmailSender( )
        {
 
        }

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dotnecikprojekt@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));
 
            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;
 
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("dotnecikprojekt@gmail.com", "cqgyfxwexpwvfuqo");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
 
            try
            {
                client.Send(mailMessage); 
                return true;
            }
            catch (Exception ex)
            {
                throw;
                // log exception
            }
            return false;
        }
 
    }
}
