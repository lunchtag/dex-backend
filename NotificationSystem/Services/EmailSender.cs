using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotificationSystem.Configuration;
using NotificationSystem.Contracts;
using NotificationSystem.Notifications;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotificationSystem.Services
{
    public class EmailSender : INotificationService
    {
        private readonly ISendGridClient client;
        private readonly EmailAddress from;
        private EmailNotification notification;

        public EmailNotification Notification { get => notification; set => notification = value; }

        public EmailSender(ISendGridClient sendGridClient,  string emailFrom)
        {
            client = sendGridClient;
            from = new EmailAddress(emailFrom);
        }

        public void ParsePayload(string jsonBody)
        {
            notification = JsonConvert.DeserializeObject<EmailNotification>(jsonBody);
        }

        public void ExecuteTask()
        {
            EmailNotification emailNotification = notification;
            Execute(emailNotification.RecipientEmail, emailNotification.TextContent, emailNotification.HtmlContent).Wait();

        }

        public bool ValidatePayload()
        {
            EmailNotification emailNotification = notification;

            if(string.IsNullOrEmpty(emailNotification.RecipientEmail) || string.IsNullOrWhiteSpace(emailNotification.RecipientEmail))
            {
                return false;
            }

            if(string.IsNullOrEmpty(emailNotification.TextContent))
            {
                return false;
            }

            return true;
        }

        private async Task Execute(string recipient, string textContent, string htmlContent = null)
        {
            string subject = "You have a new notification on DeX";
            EmailAddress to = new EmailAddress(recipient);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, textContent, htmlContent);
            _ = await client.SendEmailAsync(msg);
        }
    }
}
