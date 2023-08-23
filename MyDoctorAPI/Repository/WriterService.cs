using FeliveryAPI.Repository;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;
using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public class WriterService : BaseRepoService, IRepository<Writer>
    {
        public WriterService(IDbContextFactory<MyDoctorAPIContext> context) : base(context)
        {
        }

        List<Writer> IRepository<Writer>.GetAll()
        {
            List<Writer> WritersList = new();
            using (var customContext = Context.CreateDbContext())
            {
                WritersList = customContext.Writers.ToList();
            }

            return WritersList;
        }

        public Writer? GetDetails(int id)
        {
            var WriterDetails = new Writer();
            using (var customContext = Context.CreateDbContext())
            {
                WriterDetails = customContext.Writers.Find(id);
            }
            using (var customContext = Context.CreateDbContext())
            {
                WriterDetails.ArticlesList = customContext.Articles.Where(r => r.Id == id).ToList();
            }
            return WriterDetails;
        }

        public void Insert(Writer writer)
        {
            using var customContext = Context.CreateDbContext();
            customContext.Writers.Add(writer);
            customContext.SaveChanges();
        }

        public void Update(Writer writer)
        {

            using var customContext = Context.CreateDbContext();
            customContext.Writers.Update(writer);
            customContext.SaveChanges();
        }

        public Writer Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            Writer writerData = customContext.Writers.Find(id);
            customContext.Writers.Remove(writerData);
            customContext.SaveChanges();
            return writerData;
        }

    }
}
