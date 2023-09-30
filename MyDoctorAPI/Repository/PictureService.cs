using FeliveryAPI.Repository;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;
using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public class PictureService : BaseRepoService, IRepository<Picture>
    {

        private readonly IWebHostEnvironment _environment;

        public PictureService(IDbContextFactory<MyDoctorAPIContext> context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _environment = webHostEnvironment;
        }

        public Picture Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Picture> GetAll()
        {
            List<Picture> list = new List<Picture>();
            using (var customContext = Context.CreateDbContext())
            {
                list = customContext.Pictures.ToList();              
            }
            return list;
        }

        public Picture? GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Picture t)
        {
            throw new NotImplementedException();
        }

        public void Update(Picture entity)
        {
            throw new NotImplementedException();
        }

        public string UploadImage(IFormFile Img, string PictureType)
        {

            using (var customContext = Context.CreateDbContext())
            {
                if (customContext.Pictures.Where(r => r.Type == PictureType).First() == null)
                    throw new Exception("Picture is not exist");
            }
            if (Img != null)
            {
                string ImageUrl = string.Empty;
                //string HostUrl = "https://mydoctorapi121852.azurewebsites.net/";              
                string HostUrl = "https://localhost:7292";
                string RawName = PictureType.Replace(" ", "-");
                string filePath = _environment.WebRootPath + "\\Uploads\\PicturesHome\\" + RawName;
                string imagepath = filePath + "\\ArticleImg.png";
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                if (Directory.Exists(imagepath))
                    Directory.Delete(imagepath);
                using (FileStream fileStream = File.Create(imagepath))
                {
                    Img.CopyTo(fileStream);
                }
                ImageUrl = HostUrl + "/uploads/PicturesHome/" + RawName + "/ArticleImg.png";
                using (var customContext = Context.CreateDbContext())
                {
                    var storeImg = customContext.Pictures.Where(r => r.Type == PictureType).First();
                    storeImg.Name = ImageUrl;
                    customContext.SaveChanges();
                }
                return ImageUrl;
            }
            else
                throw new Exception("Image Not Found");
        }
    }
}
