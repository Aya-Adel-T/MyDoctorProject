using FeliveryAdminPanel.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDoctorAPI.Models;

namespace MyDoctorFront.Controllers
{
    public class UserEmailsController : Controller
    {
        APIClient _api = new APIClient();

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Create()
        //{

        //    HttpClient client = _api.Initial();
        //    return View();

        //}
        [HttpPost]
        public async Task<IActionResult> Create(UserEmail userEmail)
        {
            HttpClient Client = _api.Initial();
            var EmailsList = await Client.GetFromJsonAsync<List<UserEmail>>("api/UserEmailAddress");
            foreach (var Email in EmailsList)
            {
                if(Email.Email == userEmail.Email) {
                    return RedirectToAction("Index", "Home");
                }
            }
            HttpResponseMessage res = await Client.PostAsJsonAsync($"api/UserEmailAddress", userEmail);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmails()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var EmailsList = await Client.GetFromJsonAsync<List<UserEmail>>("api/UserEmailAddress");
                return View(EmailsList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
