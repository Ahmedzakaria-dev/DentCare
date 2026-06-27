using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailConfig = _configuration.GetSection("EmailSender");

            var client = new SmtpClient(emailConfig["Host"], int.Parse(emailConfig["Port"]))
            {
                EnableSsl = bool.Parse(emailConfig["EnableSSL"]),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailConfig["Username"], emailConfig["Password"])
            };

            var mailMessage = new MailMessage(
                from: emailConfig["Username"],
                to: email,
                subject,
                message
            )
            {
                IsBodyHtml = true
            };

            return client.SendMailAsync(mailMessage);
        }
    }
}
