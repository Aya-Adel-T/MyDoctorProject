using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;

namespace MyDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        public IArticle ArticleRepo { get; set; }
        public ArticleController(IArticle articleRepo)
        {
            ArticleRepo = articleRepo;
        }
        [HttpGet]
        public ActionResult<List<Article>> GetArticles()
        {
            return ArticleRepo.GetAll();
        }
        [HttpGet("GetNotApprovedArticles")]
        public ActionResult<List<Article>> GetNotApprovedArticles()
        {
            return ArticleRepo.GetNotApproved();
        }
        [HttpGet("GetAra2")]
        public ActionResult<List<Article>> GetAra2()
        {
            return ArticleRepo.GetAra2();
        }
        [HttpGet("GetMiniHawa")]
        public ActionResult<List<Article>> GetMiniHawa()
        {
            return ArticleRepo.GetMiniHawa2();
        }
        [HttpGet("GetZawagNaks")]
        public ActionResult<List<Article>> GetZawagNaks()
        {
            return ArticleRepo.GetZawagNaks();
        }
        [HttpGet("GetHatkoniOm")]
        public ActionResult<List<Article>> GetHatkoniOm()
        {
            return ArticleRepo.GetHatkoniOm();
        }
        [HttpGet("Get9ShhorFar7a")]
        public ActionResult<List<Article>> Get9ShhorFar7a()
        {
            return ArticleRepo.Get9ShhorFar7a();
        }
        [HttpGet("GetWladaMotm2na")]

        public ActionResult<List<Article>> GetWladaMotm2na()
        {
            return ArticleRepo.GetWladaMotm2na();
        }
        [HttpGet("GetNga7kM3Tabibty")]

        public ActionResult<List<Article>> GetNga7kM3Tabibty()
        {
            return ArticleRepo.GetNga7kM3Tabibty();
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(int id)
        {
            return ArticleRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]

        public ActionResult<Article> DeleteArticle(int id)
        {
            Article ArticleData = ArticleRepo.Delete(id);
            return Ok(ArticleData);
        }
        [HttpPut]
        public ActionResult Put(Article article)
        {
            if (article != null && article.Id != 0)
            {
                ArticleRepo.Update(article);
                return Ok(article);
            }
            return NotFound();
        }
        [HttpPut("ApproveArticles{id}")]
        public ActionResult ApproveArticles(int Id)
        {
            if (Id != 0)
            {
                ArticleRepo.ApproveArticles(Id);
                return Ok();
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post(Article article)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ArticleRepo.Insert(article);
                    return Created("url", article);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
        //Upload Images
        [HttpPost("uploadImage/{ArticleTitle}")]
        //[Authorize(Roles = "Admin,Writer")]
        public ActionResult UploadImage(IFormFile file, string ArticleTitle)
        {
            var Results = ArticleRepo.UploadImage(file, ArticleTitle);
            return Ok(Results);
        }
    }
}

