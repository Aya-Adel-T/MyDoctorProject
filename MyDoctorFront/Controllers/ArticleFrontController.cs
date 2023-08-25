using FeliveryAdminPanel.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;
using Newtonsoft.Json;

namespace MyDoctorFront.Controllers
{
    public class ArticleFrontController : Controller
    {
        APIClient _api = new APIClient();

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
        public async Task<IActionResult> GetSingle()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetSingle");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> GetMarried()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetMarried");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> GetPregnant()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetPregnant");
                return View(ArticlesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        public async Task<IActionResult> GetMother()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var ArticlesList = await Client.GetFromJsonAsync<List<Article>>("api/Article/GetMother");
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
                return RedirectToAction("Index");
            }
            return View();
        }
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
                return RedirectToAction("index");
            }

            return View(article);
        }
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
     
    }
}
