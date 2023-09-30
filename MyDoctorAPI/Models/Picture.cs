using System.ComponentModel.DataAnnotations;

namespace MyDoctorAPI.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }

    }
}
