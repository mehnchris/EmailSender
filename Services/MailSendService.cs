//using EmailSender.Interfaces;
using EmailSender.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MailKit;
using MimeKit;
using EmailSender.Interfaces;
using Microsoft.Extensions.Options;

namespace EmailSender.Services
{
    public class MailSendService : IMailSendService
    {
        private readonly MailSettings _mailSettings;
        public MailSendService(IOptions<MailSettings> mailSettings) 
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task EmailSenderAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.MailRecipient));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smpt = new SmtpClient();
            smpt.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smpt.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smpt.SendAsync(email);
            smpt.Disconnect(true);
        }

    }
}
