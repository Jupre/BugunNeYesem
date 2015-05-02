namespace BugunNeYesem.Logic.Utils
{
    public interface IEmailSender
    {
        void Send(string to, string subject, string body);
    }
}