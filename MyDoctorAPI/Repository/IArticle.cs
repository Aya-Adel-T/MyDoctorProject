using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public interface IArticle : IRepository<Article>
    {
        public List<Article> GetMiniHawa2();
        public List<Article> GetZawagNaks();
        public List<Article> GetHatkoniOm();
        public List<Article> Get9ShhorFar7a();
        public List<Article> GetWladaMotm2na();
        public List<Article> GetNga7kM3Tabibty();
        public List<Article> GetNotApproved();
        public List<Article> GetApproved();
        public List<Article> GetAra2();
        public void ApproveArticles(int id);


    }
}
