using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.FileSystemGlobbing;
using System.ComponentModel.DataAnnotations;

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

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller}/{action}",
//        //значение по умолчанию для параметров маршрута
//        defaults: new
//        {
//            controller = "Home",
//            action = "Index",
//        },
//        constraints: new
//        {
//            id = new IntRouteConstraint()
//        });

//    endpoints.MapControllerRoute(
//        name: "Documents",
//        pattern: "documents/{controller}/{number}/{action}",
//        //значение по умолчанию для параметров маршрута
//        defaults: new
//        {
//            controller = "Invoices",
//            action = "View",
//        },
//        constraints: new
//        {
//            number = new RegexRouteConstraint("[a-z]{2}")
//        });
//});

//app.MapControllerRoute(
//    name: "CatchAll",
//    pattern: "{controller=Home}/{action=Index}/{*data}");

//app.MapControllerRoute(
//    name: "twoParametrRoute",
//    pattern: "{controller=Home}/{action=Privacy}/{x}/{y}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/{controller=Home}/{action=Index}");

////Определение route template
//app.MapControllerRoute(
//    name: "default",//Название
//                    //route template для запросов состоящих из двух сегментов
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//если мы выстраиваем маршрутизатор только на основе атрибутов
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();//нет определенных маршрутов
});

app.Run();
