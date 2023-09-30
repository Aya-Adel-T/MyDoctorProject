using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Models;
using System.Drawing;

namespace MyDoctorAPI.Data;

public class MyDoctorAPIContext : IdentityDbContext<IdentityUser>
{
    public MyDoctorAPIContext(DbContextOptions<MyDoctorAPIContext> options)
        : base(options)
    { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<UserEmail> UsersEmail { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }
    private void SeedRoles(ModelBuilder Builder)
    {
        Builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Writer", ConcurrencyStamp = "3", NormalizedName = "Writer" }
            );
        Builder.Entity<Picture>().HasData
            (
                new Picture() {Id=1, Name = "Admin", Type = "Slider1",  Section="Slider"},
                new Picture() {Id=2, Name = "Admin", Type = "Slider2",  Section="Slider"},
                new Picture() {Id=3, Name = "Admin", Type = "Slider3",  Section="Slider"},
                new Picture() {Id=4, Name = "Admin", Type = "AboutUs",  Section="About"},
                new Picture() {Id=5, Name = "Admin", Type = "Nga7at1",  Section="Nga7atna"},
                new Picture() {Id=6, Name = "Admin", Type = "Nga7at2",  Section= "Nga7atna" },
                new Picture() {Id=7, Name = "Admin", Type = "Nga7at3",  Section= "Nga7atna" },
                new Picture() {Id=8, Name = "Admin", Type = "Nga7at4",  Section= "Nga7atna" },
                new Picture() {Id=9, Name = "Admin", Type = "Nga7at5",  Section= "Nga7atna" },
                new Picture() {Id=10, Name = "Admin", Type = "Nga7at6",  Section= "Nga7atna" },
                new Picture() {Id=11, Name = "Admin", Type = "Nga7at7",  Section= "Nga7atna" },
                new Picture() {Id=12, Name = "Admin", Type = "Nga7at8",  Section= "Nga7atna" }
            
                
            );
    }

}
