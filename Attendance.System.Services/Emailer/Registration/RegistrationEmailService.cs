
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Attendance.System.Services.Emailer.Registration
{
    public class RegistrationEmailService : IRegistrationEmailService
    {
        private readonly string smtpServer;
        private readonly int smtpPort = 587;
        private readonly string smtpUsername;
        private readonly string smtpPassword;
        private readonly string fromEmail;
        private readonly string fromName = "Attendance System";

        public RegistrationEmailService(IOptions<EmailSettings> emailSettings)
        {
            var settings = emailSettings.Value;

            smtpServer = settings.MailServer;
            smtpUsername = settings.SenderEmail;
            smtpPassword = settings.SenderPassword;
            fromEmail = settings.SenderEmail;
        }
        public async Task sendRegistrationEmail(string email, string password)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromEmail));
            message.To.Add(MailboxAddress.Parse(email));

            message.Subject = "Account Registered";

            message.Body = new TextPart("plain")
            {
                Text = $"You have been registered on Attendance Tracking System!\n\nYour log in details are : \n\n Email: {email} \n\n Password: {password}"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(smtpUsername, smtpPassword);
                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to send registration email: " + ex.Message);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
