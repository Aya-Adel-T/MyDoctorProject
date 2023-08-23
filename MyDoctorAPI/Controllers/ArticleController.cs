﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet("{id}")]
        public ActionResult<Article> GetById(int id)
        {
            return ArticleRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]

        public ActionResult<Article> DeleteWriter(int id)
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
        [HttpPost("uploadImage/{newsTitle}")]
        //[Authorize(Roles = "Admin")]
        public ActionResult UploadImage(IFormFile file, string ArticleTitle)
        {
            var Results = ArticleRepo.UploadImage(file, ArticleTitle);
            return Ok(Results);
        }
    }
}
