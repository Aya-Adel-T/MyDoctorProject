using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;

namespace MyDoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {

        public IRepository<Writer> WriterRepo { get; set; }
        public WriterController(IRepository<Writer> writerRepo)
        {
            WriterRepo = writerRepo;
        }
        [HttpGet]
        public ActionResult<List<Writer>> GetWriters()
        {
            return WriterRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<Writer> GetById(int id)
        {
            return WriterRepo.GetDetails(id);
        }
        [HttpDelete("{id}")]

        public ActionResult<Writer> DeleteWriter(int id)
        {
            Writer WriterData = WriterRepo.Delete(id);
            return Ok(WriterData);
        }
        [HttpPut]
        public ActionResult Put(Writer writer)
        {
            if (writer != null && writer.Id != 0)
            {
                WriterRepo.Update(writer);
                return Ok(writer);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post(Writer writer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WriterRepo.Insert(writer);
                    return Created("url", writer);
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

