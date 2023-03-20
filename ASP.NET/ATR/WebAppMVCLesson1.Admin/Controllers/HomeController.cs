using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCLesson1.Admin.Models;

namespace WebAppMVCLesson1.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;
        //private ProductSum _productSum;

        public HomeController(ILogger<HomeController> logger, 
            IRepository repo/*, ProductSum productSum*/)
        {
            _logger = logger;
            _repo = repo;
            //_productSum = productSum;
        }

        public IActionResult Index([FromServices] ProductSum _productSum)
        {
            ViewBag.HomeControllerGuid = _repo.ToString();
            ViewBag.TotalGuid = _productSum.Repository.ToString();

            ViewBag.Tottal = _productSum.Total;

            //return View(new Repository().Products);
            return View(_repo.Products);
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

        public JsonResult GetSomeData()
        {
            var data = new List<string>() { "01", "02" };
            return Json(data);
        }
    }
}