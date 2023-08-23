using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Models;

namespace MyDoctorAPI.Data;

public class MyDoctorAPIContext : IdentityDbContext<IdentityUser>
{
    public MyDoctorAPIContext(DbContextOptions<MyDoctorAPIContext> options)
        : base(options)
    { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Writer> Writers { get; set; }

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
                new IdentityRole() { Name = "Customer", ConcurrencyStamp = "3", NormalizedName = "Writer" }
            );
    }

}
