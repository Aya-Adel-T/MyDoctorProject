using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyDoctorAPI.Models;

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
                "نحن نثق بكما   <br>" +
                
                "الدورة هنا \n" +
                "https://forms.gle/NupdSNWtC2mtHRJ4A <br>" +
                "لتفعيل الإشتراك يرجى ارسال الإيميل الذى سيحدد لفتح دورة [ ولادة مطمئنة ] واتساب على \n <br>" +
                "https://wa.me/201005217612 \n <br>" +
                "سيتم إرسال كلمة المرور عليه \n <br>" +
                "\n <br>" +
                "وفقكم الله دائما و أحل عليكم بركته \n <br>"
            };


            var emailToAdmin = new MimeMessage();
            emailToAdmin.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            emailToAdmin.To.Add(MailboxAddress.Parse("Tbibtyclinic@gmail.com"));
            emailToAdmin.Subject = "New Purchase";
            emailToAdmin.Body = new TextPart(TextFormat.Html)
            {
                Text =
                "This user Purchased the course دورة ولادة مطمئنة" + " " + to

            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Send(emailToAdmin);
            smtp.Disconnect(true);
        }




        public void SendEmailsWithArticle(string to)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "مقال جديد من طبيبتي";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "تمت اضافة مقاله جديده على موقع طبيبتي <br>" +
                "http://tbibti.com/"
            };
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SuccessTshnogMhpli(string to)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "MY Doctor Your Course (دورة أسرار شفاء التشنج المهبلى اللاإرادى)";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text =
              "نحن نثق بكما   <br>" +

                "الدورة من هنا \n" +
                "https://forms.gle/XKWWDz9QAFVoRmWf6<br>" +
                "لتفعيل الإشتراك يرجى ارسال الإيميل الذى سيحدد لفتح دورة [ التشنج المهبلي الللارادي ] واتساب على \n <br>" +
                "https://wa.me/201005217612 \n <br>" +
                "سيتم إرسال كلمة المرور عليه \n <br>" +
                "\n <br>" +
                "وفقكم الله دائما و أحل عليكم بركته \n <br>"
            };


            var emailToAdmin = new MimeMessage();
            emailToAdmin.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            emailToAdmin.To.Add(MailboxAddress.Parse("Tbibtyclinic@gmail.com"));
            emailToAdmin.Subject = "New Purchase";
            emailToAdmin.Body = new TextPart(TextFormat.Html)
            {
                Text =
                "This user Purchased the course دورة أسرار شفاء التشنج المهبلي اللاارادي" + " " + to

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
