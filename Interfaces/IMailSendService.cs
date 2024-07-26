using EmailSender.Models;

namespace EmailSender.Interfaces
{
    public interface IMailSendService
    {
        public Task EmailSenderAsync(MailRequest mailRequest);
    }
}
