using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyDoctorFront.Helpers
{
    public class Email : IEmailSender

    {
        private readonly IConfiguration _config;
        public Email(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string to)
        {
           
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "MY Doctor Your Course (دورة ولادة مطمئنة)";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text =
                "نحن نثق بكما" +
                "الدورة هنا" +
                "https://forms.gle/NupdSNWtC2mtHRJ4A " +
                "لتفعيل الإشتراك يرجى ارسال الإيميل الذى سيحدد لفتح دورة [ ولادة مطمئنة ] واتساب على" +
                "https://wa.me/201005217612" +
                "سيتم إرسال كلمة المرور عليه " +
                "" +
                "وفقكم الله دائما و أحل عليكم بركته"




            };


            var emailToAdmin = new MimeMessage();
            emailToAdmin.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            emailToAdmin.To.Add(MailboxAddress.Parse("Tbibtyclinic@gmail.com"));
            emailToAdmin.Subject = "New Purchase";
            emailToAdmin.Body = new TextPart(TextFormat.Html)
            {
                Text =
                "This user Purchased the course" + " " + to

            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Send(emailToAdmin);
            smtp.Disconnect(true);
        }


    }
}
