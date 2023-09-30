using FeliveryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;
using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public class EmailAddressService : BaseRepoService, IRepository<UserEmail>
    {
        private readonly IWebHostEnvironment _environment;

        public EmailAddressService(IDbContextFactory<MyDoctorAPIContext> context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _environment = webHostEnvironment;
        }

        public List<UserEmail> GetAll()
        {
            List<UserEmail> userEmailsList = new();
         
            using (var customContext = Context.CreateDbContext())
            {
                userEmailsList = customContext.UsersEmail.ToList();

            }

            return userEmailsList;
        }
        public void Insert(UserEmail UserEmail)
        {
            using var customContext = Context.CreateDbContext();
            customContext.UsersEmail.Add(UserEmail);
            customContext.SaveChanges();
        }
        public UserEmail Delete(int id)
        {
            using var customContext = Context.CreateDbContext();
            UserEmail entity = customContext.UsersEmail.Find(id);
            customContext.UsersEmail.Remove(entity);
            customContext.SaveChanges();
            return entity;
        }

        public UserEmail? GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEmail entity)
        {
            throw new NotImplementedException();
        }
    }
}
