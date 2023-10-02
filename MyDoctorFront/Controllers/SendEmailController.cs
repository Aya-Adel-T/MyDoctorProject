using FeliveryAdminPanel.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using MyDoctorFront.Helpers;

namespace MyDoctorFront.Controllers
{
    public class SendEmailController : Controller
    {
        APIClient _api = new APIClient();
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
        public  IActionResult SuccessTshnogMhpli(string Email)
        {
           
                _email.SuccessTshnogMhpli(Email);
           
            return View("SendEmail");

        }
    }
}
