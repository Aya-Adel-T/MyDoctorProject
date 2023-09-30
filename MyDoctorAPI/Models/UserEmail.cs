using System.ComponentModel.DataAnnotations;

namespace MyDoctorAPI.Models
{
    public class UserEmail
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
