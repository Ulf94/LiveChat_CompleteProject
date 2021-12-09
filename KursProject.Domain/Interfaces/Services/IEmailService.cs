namespace KursProject.Domain
{
    public interface IEmailService
    {
        void SentMessageEmail(string email, string message);
    }
}
