using Microsoft.EntityFrameworkCore;
using WebAppMVCLesson1.NewAdmin.DataContext;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration["ConnectionStrings:DefaultConnection"];

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddUserSecrets<Program>();



//builder.Services.AddDbContext<WebAppMVCLesson1DbContext>(options =>
//options.UseSqlServer(builder
//.Configuration
//.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<WebAppMVCLesson1DbContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
