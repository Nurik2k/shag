using Microsoft.AspNetCore.Mvc;

namespace SimpleRouting.Controllers
{
    public class InvoicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult View(string number)
        {
            ViewBag.Number = number;
            return View();
        }
    }
}
