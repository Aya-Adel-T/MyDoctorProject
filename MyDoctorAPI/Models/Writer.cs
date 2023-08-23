using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyDoctorAPI.Models
{
    public class Writer
    {

        public Writer()
        {
            ArticlesList = new List<Article?>();

        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }
        public virtual ICollection<Article?> ArticlesList { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string? SecurityID { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
