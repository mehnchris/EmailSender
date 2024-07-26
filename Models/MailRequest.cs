namespace EmailSender.Models
{
    public class MailRequest
        //attributes that email will have
    {
        public string MailRecipient { get; set; }

        public string MailSender { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
