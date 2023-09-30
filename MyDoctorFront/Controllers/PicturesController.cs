using FeliveryAdminPanel.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using System.Net.Http.Headers;

namespace MyDoctorFront.Controllers
{
    public class PicturesController : Controller
    {
        APIClient _api = new APIClient();


        public async Task<IActionResult> getAllPictures()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Picture>>("api/Picture");
                return View(ArticlesList);
            }

            catch (Exception e)
            {
                return View();
            }
        }

        public IActionResult Index()
        {
            return View("~/Views/LoginFront/AddHomePictures.cshtml");
        }
        public async Task<IActionResult> addImage(IFormFile file, string Type)
        {
            HttpClient client = _api.Initial();

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers =
                     {
                         ContentLength = file.Length,
                         ContentType = new MediaTypeHeaderValue(file.ContentType)
                     }
                }, "file", file.FileName);

                HttpResponseMessage res = await client.PostAsync($"api/Picture/uploadImage/{Type}", content);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("AdminPanel", "LoginFront");
                }
                return View();
            }
        }
    }
}
