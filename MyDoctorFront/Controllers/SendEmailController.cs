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
        //public async  Task<IActionResult> SendEmails()
        //{
        //    HttpClient Client = _api.Initial();

        //    var EmailsList = await Client.GetFromJsonAsync<List<UserEmail>>("api/UserEmailAddress");
        //    foreach (var Email in EmailsList)
        //    {
        //        _email.SendEmailsWithArticle(Email.Email);

        //    }
        //    return View();

        //}
    }
}
