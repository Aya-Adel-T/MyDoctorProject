namespace MyDoctorFront.Helpers
{
    public interface IEmailSender
    {
        void SendEmail(string to);
        void SendEmailsWithArticle(string to);
    }
}
