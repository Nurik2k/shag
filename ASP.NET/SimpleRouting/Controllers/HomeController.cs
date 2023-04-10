using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SimpleRouting.Models;
using System.Diagnostics;

namespace SimpleRouting.Controllers
{
    //[Route("Home")]
    //[Route("main")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        #region Routes1
        //[Route("[action]/{id:int}/{name:maxlength(10)}")]
        //[Route("Home/Index/{id?}")]// /Route/Home/Index
        //[Route("index/{id?}")]
        #endregion

        #region Index(string culture, string uiculture)
        public IActionResult Index(string culture, string uiculture)
        {
            ViewBag.Lang = _localizer["Lang"];
            //if (!string.IsNullOrWhiteSpace(culture))
            //{
            //    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            //        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            //        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) });
            //}
            return View();
            #region index      
            //    //CookieOptions options = new CookieOptions();
            //    //options.Expires = DateTimeOffset.Now.AddMilliseconds(10);
            //    //Response.Cookies.Append("testCookies", "666", options);

            //    //string test = Request.Cookies["testCookies"];
            //    //Response.Cookies.Delete("testCookies");

            //    //HttpContext.Session.SetString("product", "PenDrive");
            //    //string sessionValue = "";
            //    //if(HttpContext.Session != null)
            //    //{
            //    //    sessionValue = HttpContext.Session.GetString("product");
            //    //    if (string.IsNullOrWhiteSpace(sessionValue)) sessionValue = "Session timed out";
            //    //}
            //    //ViewBag.Id = sessionValue;
            //    //ViewBag.Name = name;
            #endregion
        }
        #endregion

        [HttpGet]
        #region Routes 2
        //[Route("Sunny")]
        //[Route("CheckPrivacy")]
        //[Route("New/[controller]/Almaty/[action]")]
        //[Route("[controller]/[action]")]
        //[Route("/PrivacyPage")]
        //[Route(" ", Name = "Privac")]
        //[Route("[action]")]
        //[Route("AboutUs")]
        #endregion
        public IActionResult Privacy(string data)
        {
            var controller = RouteData.Values["controller"].ToString();
            var action = RouteData.Values["action"].ToString();
            //return View();
            return Content($"controller: {controller} | action: {action}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}