using System.Net;
using System.Net.Mail;

namespace _Net_Core_IdentityServer4.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient sc = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("burakyilmaz31@gmail.com", "Şifre")
            };

            MailMessage mail = new MailMessage
            {
                From = new MailAddress("burakyilmaz31@gmail.com", "Mail Bilgilendirme Servisi")
            };

            mail.To.Add(email);

            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = message;

            sc.Send(mail);

            return Task.CompletedTask;
        }
    }
}
