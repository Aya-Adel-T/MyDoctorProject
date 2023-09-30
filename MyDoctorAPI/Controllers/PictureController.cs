using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;

namespace MyDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        public IRepository<Picture> PictureRepo { get; set; }
        public PictureController(IRepository<Picture> pictureRepo)
        {
            PictureRepo = pictureRepo;
        }
        [HttpGet]
        public ActionResult<List<Picture>> GetPics()
        {
            return PictureRepo.GetAll();
        }
        //Upload Images
        [HttpPost("uploadImage/{PicType}")]
        //[Authorize(Roles = "Admin,Writer")]
        public ActionResult UploadImage(IFormFile file, string PicType)
        {
            var Results = PictureRepo.UploadImage(file, PicType);
            return Ok(Results);
        }
    }
}
