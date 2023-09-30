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
    }

}
