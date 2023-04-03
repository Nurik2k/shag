using Microsoft.AspNetCore.Mvc;
using SimpleRouting.Models;
using System.Diagnostics;

namespace SimpleRouting.Controllers
{
    [Route("Home")]
    [Route("main")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("[action]/{id:int}/{name:maxlength(10)}")]
        //[Route("Home/Index/{id?}")]// /Route/Home/Index
        [Route("index/{id?}")]
        public IActionResult Index(int id, string name)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            return View();
        }

        [HttpGet]
        //[Route("Sunny")]
        //[Route("CheckPrivacy")]
        //[Route("[controller]/[action]")]
        //[Route("/PrivacyPage")]
        //[Route(" ", Name = "Privac")]
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