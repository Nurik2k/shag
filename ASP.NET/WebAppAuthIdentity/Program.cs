using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using WebAppAuthIdentity.Data;
using WebAppAuthIdentity.Models;
using WebAppAuthIdentity.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppIdentityDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
