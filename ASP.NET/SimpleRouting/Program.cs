using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using SimpleRouting.Models;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MyApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    var supportedCulture = new[] {
    new CultureInfo("en"),
    new CultureInfo("ru"),
    new CultureInfo("kk")
    };
    option.DefaultRequestCulture = new RequestCulture(culture: "kk", uiCulture: "kk");
    option.SupportedCultures = supportedCulture;
    option.SupportedUICultures = supportedCulture;
    //option.AddInitialRequestCultureProvider(new MyCultureProvider());


    option.AddInitialRequestCultureProvider(
        new CustomRequestCultureProvider(async context =>
        {
            var currentCulture = "kk";
            var segment = context.Request.Path.Value.Split(new char[] { '/' },
                StringSplitOptions.RemoveEmptyEntries);
            if (segment.Length >= 1)
            {
                string lastSegment = segment[segment.Length - 1];
                currentCulture = lastSegment;
            }
            var requestCulture = new ProviderCultureResult(currentCulture);
            return await Task.FromResult(requestCulture);
        }));
});

builder.Services.AddLocalization(option =>
option.ResourcesPath = "Resources");

var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession();

app.UseStaticFiles();

app.UseRouting();

var LocOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(LocOptions.Value);

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
//            //HttpMethod = new HttpMethodRouteConstraint("GET")
//            customeConstraint = new UserAgentConstraint("Chrome")
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

//Определение route template
app.MapControllerRoute(
    name: "default",//Название
                    //route template для запросов состоящих из двух сегментов
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "defaultApi",
//    pattern: "api/{action}",
//    defaults: new { controller = "Home" });

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");

//если мы выстраиваем маршрутизатор только на основе атрибутов
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();//нет определенных маршрутов
//});
app.MapControllerRoute(
    name: "default",
    pattern: "/en",
    defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(
    name: "default",
    pattern: "/ru",
    defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(
    name: "default",
    pattern: "/kk",
    defaults: new { controller = "Home", action = "Index" });

app.Run();
