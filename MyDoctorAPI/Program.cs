using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDoctorAPI.Data;
using MyDoctorAPI.Models;
using MyDoctorAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyDoctorAPIContextConnection") ?? throw new InvalidOperationException("Connection string 'MyDoctorAPIContextConnection' not found.");

builder.Services.AddDbContextFactory<MyDoctorAPIContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MyDoctorAPIContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IRepository<Writer>, WriterService>();
    builder.Services.AddScoped<IArticle, ArticleService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
