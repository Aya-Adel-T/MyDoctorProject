using MyDoctorAPI.Models;

namespace MyDoctorFront.Helpers
{
    public class MyMainViewModel
    {
        public UserEmail? Email { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
