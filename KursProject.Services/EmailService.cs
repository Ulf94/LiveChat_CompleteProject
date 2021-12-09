using KursProject.Domain;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KursProject.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        public EmailService(IConfiguration configuration)
        {
            _apiKey = configuration["Application:APIKeyForSendGrid"];
        }
        public void SentMessageEmail(string email, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("michal.szura22@gmail.com", "Michal Szura");
            var subject = "Nowa wiadomosc";
            var to = new EmailAddress(email);
            var plainTextContent = $"Nowa wiadomosc: {message}";
            var htmlContent = $"<strong>Nowa wiadomosc: <br/> {message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception(response.StatusCode.ToString());
            }

        }
    }
}
