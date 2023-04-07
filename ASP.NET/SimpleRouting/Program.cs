using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();
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
    new CultureInfo("en-US"),
    new CultureInfo("ru-Ru"),
    new CultureInfo("kk-KZ")
    };
    option.DefaultRequestCulture = new RequestCulture(culture: "kk-KZ", uiCulture: "kk-Kz");
    option.SupportedCultures= supportedCulture;
    option.SupportedUICultures= supportedCulture;
});

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

app.Run();
