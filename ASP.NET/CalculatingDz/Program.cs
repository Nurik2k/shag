var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Add",
    pattern: "{controller=Calc}/{action=Add}/{x}/{y}");
app.MapControllerRoute(
    name: "Mul",
    pattern: "{controller=Calc}/{action=Mul}/{x}/{y}");
app.MapControllerRoute(
    name: "Div",
    pattern: "{controller=Calc}/{action=Div}/{x}/{y}");
app.MapControllerRoute(
    name: "Sub",
    pattern: "{controller=Calc}/{action=Sub}/{x}/{y}");

app.Run();
