using Microsoft.AspNetCore.Mvc;
using SimpleRouting.Models;
using System.Diagnostics;

namespace SimpleRouting.Controllers
{
    [Route("main")]// /home
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("[action]/{id:int}/{name:maxlength(10)}")]
        //[Route("Home/Index/{id?}")]// /home/Home/Index
        [Route("index/{id?}")]
        public IActionResult Index(int id, string name)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            return View();
        }

        [Route("[controller]/[action]")]
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