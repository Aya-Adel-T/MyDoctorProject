using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;

namespace MyDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEmailAddressController : ControllerBase
    {
        public IRepository<UserEmail> EmailRepo { get; set; }
        public UserEmailAddressController(IRepository<UserEmail> emailRepo)
        {
            EmailRepo = emailRepo;
        }
        [HttpGet]
        public ActionResult<List<UserEmail>> GetWriters()
        {
            return EmailRepo.GetAll();
        }
        [HttpDelete("{id}")]

        public ActionResult<UserEmail> DeleteWriter(int id)
        {
            UserEmail entity = EmailRepo.Delete(id);
            return Ok(entity);
        }
        [HttpPost]
        public ActionResult Post(UserEmail entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmailRepo.Insert(entity);

                    return Created("url", entity);
                    // return 201 & Url is the place where you added the object
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Return 400!
                }
            }
            return BadRequest();
        }
    }
}
