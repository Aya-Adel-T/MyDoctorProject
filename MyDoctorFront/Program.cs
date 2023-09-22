
using Microsoft.AspNetCore.Authentication.Cookies;
using MyDoctorFront.Helpers;
using PaypalCheckoutExample.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddSingleton(x =>
    new PaypalClient(
        builder.Configuration["PayPalOptions:ClientId"],
        builder.Configuration["PayPalOptions:ClientSecret"],
        builder.Configuration["PayPalOptions:Mode"]
)
);

builder.Services.AddScoped<IEmailSender, Email>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Notfound";
        await next();
    }
});
app.MapRazorPages();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
