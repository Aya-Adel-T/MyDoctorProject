﻿using MyDoctorAPI.Models;

namespace MyDoctorAPI.Repository
{
    public interface IArticle : IRepository<Article>
    {
        public string UploadImage(IFormFile Img, string NewsTitle);
        public List<Article> GetMiniHawa2();
        public List<Article> GetZawagNaks();
        public List<Article> GetHatkoniOm();
        public List<Article> Get9ShhorFar7a();
        public List<Article> GetWladaMotm2na();
        public List<Article> GetNga7kM3Tabibty();
        public List<Article> GetNotApproved();
        public List<Article> GetApproved();
        public void ApproveArticles(int id);


    }
}
