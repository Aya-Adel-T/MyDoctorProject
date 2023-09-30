using FeliveryAPI.Repository;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;
using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public class ArticleService : BaseRepoService, IArticle
    {
        private readonly IWebHostEnvironment _environment;

        public ArticleService(IDbContextFactory<MyDoctorAPIContext> context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _environment = webHostEnvironment;
        }

        public List<Article> GetAll()
        {
            List<Article> ArticlesList = new();
            List<Writer> WritersList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                WritersList = customContext.Writers.ToList();
            }
            foreach(var article in ArticlesList)
            {
                foreach (var writer in WritersList)
                {
                    if (article.WriterID == writer.Id)

                        article.Writer = writer;
                }
            }


            return ArticlesList;
        }

        public Article? GetDetails(int id)
        {

            var ArticleDetails = new Article();
            List<Writer> WritersList = new();

            using (var customContext = Context.CreateDbContext())
            {
                WritersList = customContext.Writers.ToList();
            }
            using (var customContext = Context.CreateDbContext())
            {
                ArticleDetails = customContext.Articles.Find(id);
               foreach (var writer in WritersList)
                {
                    if (ArticleDetails.WriterID == writer.Id)
                    {
                        ArticleDetails.Writer = writer;
                    }
                }
            }
            return ArticleDetails;
        }

        public void Insert(Article article)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Articles.Add(article);
            customContext.SaveChanges();
        }

        public void Update(Article article)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Articles.Update(article);
            customContext.SaveChanges();
        }

        public string UploadImage(IFormFile Img, string ArticleTitle)
        {

            using (var customContext = Context.CreateDbContext())
            {
                if (customContext.Articles.Where(r => r.Title == ArticleTitle).First() == null)
                    throw new Exception("Article Title Not Found");
            }
            if (Img != null)
            {
                string ImageUrl = string.Empty;
                //string HostUrl = "https://mydoctorapi121852.azurewebsites.net/";              
                string HostUrl = "https://localhost:7292";              
                string RawName = ArticleTitle.Replace(" ", "-");
                string filePath = _environment.WebRootPath + "\\Uploads\\Product\\" + RawName;
                string imagepath = filePath + "\\ArticleImg.png";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (Directory.Exists(imagepath))
                    Directory.Delete(imagepath);
                using (FileStream fileStream = File.Create(imagepath))
                {
                    Img.CopyTo(fileStream);
                }
                ImageUrl = HostUrl + "/uploads/Product/" + RawName + "/ArticleImg.png";
                using (var customContext = Context.CreateDbContext())
                {
                    var storeImg = customContext.Articles.Where(r => r.Title == ArticleTitle).First();
                    storeImg.ArticleImg = ImageUrl;
                    customContext.SaveChanges();
                }
                return ImageUrl;
            }
            else
                throw new Exception("Image Not Found");
        }


        public Article Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            Article ArticleData = customContext.Articles.Find(id);
            customContext.Articles.Remove(ArticleData);
            customContext.SaveChanges();
            return ArticleData;
        }

        public List<Article> GetMiniHawa2()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "Mini-Hawa") && (s.Status == "Approved")).ToList(); ; 
            }
            return ArticlesList;
    }

        public List<Article> GetZawagNaks()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "Zawag-Naks" )&& (s.Status == "Approved") ).ToList();
            }
            return ArticlesList;
        }

        public List<Article> GetHatkoniOm()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "Hatkoni-Om") && (s.Status == "Approved")).ToList(); ;
            }
            return ArticlesList;
        }

        public List<Article> Get9ShhorFar7a()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "9-Shohor-Far7a") && (s.Status == "Approved")).ToList(); ;
            }
            return ArticlesList;
        }
        public List<Article> GetWladaMotm2na()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "Wlada-motm2na") && (s.Status == "Approved")).ToList(); ;
            }
            return ArticlesList;
        }

        public List<Article> GetNga7kM3Tabibty()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => (s.ArticleType == "Nga7k-Ma3-Tabibty") && (s.Status == "NotApproved")).ToList(); ;
            }
            return ArticlesList;
        }
        public List<Article> GetNotApproved()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => s.Status == "NotApproved").ToList(); ;
            }
            return ArticlesList;
        }
        public List<Article> GetApproved()
        {
            List<Article> ArticlesList = new();
            using (var customContext = Context.CreateDbContext())
            {
                ArticlesList = customContext.Articles.Where(s => s.Status == "Approved").ToList(); ;
            }
            return ArticlesList;
        }


        public void ApproveArticles(int Id)
        {
            var ArticleDetails = new Article();
            using (var customContext = Context.CreateDbContext())
            {
                ArticleDetails = customContext.Articles.Find(Id);
                ArticleDetails.Status = "Approved";
                customContext.Articles.Update(ArticleDetails);
                customContext.SaveChanges();
            }                
        }


   
    }
}
