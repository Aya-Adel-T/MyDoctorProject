using Microsoft.AspNetCore.Mvc;
using MyDoctorFront.Helpers;

namespace MyDoctorFront.Controllers
{
    public class SendEmailController : Controller
    {
        private readonly IEmailSender _email;

        public SendEmailController( IEmailSender email)
        {
            _email = email;
        }
        public IActionResult SendEmail(string Email)
        {

            _email.SendEmail( Email);
            return View();

        }
    }
}
