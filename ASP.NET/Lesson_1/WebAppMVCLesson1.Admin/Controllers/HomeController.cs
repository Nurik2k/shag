using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCLesson1.Admin.Models;

namespace WebAppMVCLesson1.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentDate = DateTime.Now;
            TempData["CurrentDate"] = DateTime.Now;
            return View();
        }

        public IActionResult Privacy(string msg)
        {
            return View(msg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}