using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyDoctorAPI.Models
{
    public enum ArticleType
    {
        Single , Pregnant , Married , Mother

    }
    public class Article
    {
       

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ForeignKey(nameof(Writer))]
        public int WriterID { get; set; }
        public virtual Writer? Writer { get; set; }
        [Required]
        public string OurArticle { get; set; }
        [Required]

        public  string ArticleType { get; set; }
        public string Status { get; set; } = "NotApproved";
        public string? ArticleImg { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PublicationDate { get; set; } 
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string? SecurityID { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
