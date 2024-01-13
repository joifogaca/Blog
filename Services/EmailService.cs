using System.Net;
using System.Net.Mail;

namespace Blog.Services
{
    public class EmailService
    {
        public bool Send(
            string toName,
            string toEmail,
            string subject,
            string body,
            string fromName = "Equipe joi",
            string fromEmail = "joi.fogaca@gmail.com"
            ) { 
        var SmtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);

            SmtpClient.Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password);
            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpClient.EnableSsl = true;

            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                SmtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
