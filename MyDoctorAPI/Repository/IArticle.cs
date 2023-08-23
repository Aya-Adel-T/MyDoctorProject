using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public interface IArticle : IRepository<Article>
    {
        public string UploadImage(IFormFile Img, string NewsTitle);

    }
}
