using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public interface IArticle : IRepository<Article>
    {
        public string UploadImage(IFormFile Img, string NewsTitle);
        public List<Article> GetSingle();
        public List<Article> GetMarried();
        public List<Article> GetPregenant();
        public List<Article> GetMother();
        public List<Article> GetNotApproved();
        public void ApproveArticles(int id);


    }
}
