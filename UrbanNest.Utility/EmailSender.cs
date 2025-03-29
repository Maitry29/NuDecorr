using brevo_csharp.Api;
using brevo_csharp.Client;
using brevo_csharp.Model;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrbanNest.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailSender(IConfiguration configuration)
        {
            _apiKey = configuration["BrevoSettings:ApiKey"];
            _senderEmail = configuration["BrevoSettings:SenderEmail"];
            _senderName = configuration["BrevoSettings:SenderName"];
        }

        public async System.Threading.Tasks.Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                // Set up API key authentication
                Configuration.Default.ApiKey["api-key"] = _apiKey;

                var apiInstance = new TransactionalEmailsApi();
                var emailData = new SendSmtpEmail
                {
                    Sender = new SendSmtpEmailSender { Email = _senderEmail, Name = _senderName }, // Corrected Sender
                    To = new List<SendSmtpEmailTo> { new SendSmtpEmailTo { Email = email, Name = "User" } }, // Corrected To field
                    Subject = subject,
                    HtmlContent = htmlMessage
                };

                // Send email
                var response = await apiInstance.SendTransacEmailAsync(emailData);

                // Log success
                Console.WriteLine($"✅ Email sent successfully! Response ID: {response.MessageId}");
            }
            catch (ApiException apiEx)
            {
                Console.WriteLine($"❌ Brevo API Error: {apiEx.ErrorCode} - {apiEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ General Error: {ex.Message}");
            }
        }
    }
}
