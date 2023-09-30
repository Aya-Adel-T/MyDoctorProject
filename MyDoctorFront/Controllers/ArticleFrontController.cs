using FeliveryAdminPanel.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;
using MyDoctorFront.Helpers;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace MyDoctorFront.Controllers
{
    public class ArticleFrontController : Controller
    {
        APIClient _api = new APIClient();
        private readonly IEmailSender _email;

        public ArticleFrontController(IEmailSender email)
        {
            _email = email;
        }
        //GetAllArticles
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article");
                return View(ArticlesList);
            }

            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> Minihawa2()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetMiniHawa");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public async Task<IActionResult> DetailsUser()
        {
          
                return View();
            
        }



        public async Task<IActionResult> ZawagNaks()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetZawagNaks");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> HatkoniOm()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetHatkoniOm");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> tes3ShhorFar7a()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/Get9ShhorFar7a");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> WladaMotm2na()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetWladaMotm2na");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> Nga7kM3Tabibty()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetNga7kM3Tabibty");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> ApprovedArticles()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetApprovedArticles");
               
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NotApprovedArticles()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetNotApprovedArticles");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Article article = new Article();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Article/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                article = JsonConvert.DeserializeObject<Article>(data);
            }
            return View(article);
        }
        [Authorize(Roles = "Writer ,Admin")]
        public async Task<IActionResult> Create()
        {

            HttpClient client = _api.Initial();
            //Writer drop down list
            var writersList = await client.GetFromJsonAsync<List<Writer>>("api/Writer");
            SelectList WritersSelectList = new SelectList(writersList, "Id", "Name");
            ViewBag.WritersList = WritersSelectList;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Article", article);
            if (res.IsSuccessStatusCode)
            {
                return View("addNewsImage");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveArticles(int id)
        {
            HttpClient Client = _api.Initial();
            try
            {
                var requestBody = new { id = id, Status = "Approved" };

                var ArticlesList = await Client.PutAsJsonAsync($"api/Article/ApproveArticles{id}", requestBody);
                 var EmailsList = await Client.GetFromJsonAsync<List<UserEmail>>("api/UserEmailAddress");
                foreach (var Email in EmailsList)
                {
                    _email.SendEmailsWithArticle(Email.Email);

                }
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [Authorize(Roles = "Writer ,Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            Article article = new Article();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Article/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                article = JsonConvert.DeserializeObject<Article>(data);
            }
            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Writer>>("api/Writer");
            SelectList WritersSelectList = new SelectList(restaurantList, "Id", "Name");
            ViewBag.WritersList = WritersSelectList;
            return View(article);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Article article)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<Article>("api/Article", article);

            if (res.IsSuccessStatusCode)
            {
                return View("addNewsImage");
            }

            return View(article);
        }
        [Authorize(Roles = "Writer ,Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            Article article = new Article();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Article/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                article = JsonConvert.DeserializeObject<Article>(data);
            }
            return View(article);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Article/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Writer ,Admin")]
        public async Task<IActionResult> addNewsImage(IFormFile file, string Title)
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

                HttpResponseMessage res = await client.PostAsync($"api/Article/uploadImage/{Title}", content);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

    }
}
