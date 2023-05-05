using Microsoft.AspNetCore.Mvc;

namespace CalculatingDz.Controllers
{
    public class Calc : Controller
    {
        public IActionResult Add(int x, int y)
        {
            var result = x + y;
            ViewBag.Result = result;
            return View();
        }
        public IActionResult Mul(int x, int y)
        {
            var result = x * y;
            ViewBag.Result = result;
            return View();
        }
        public IActionResult Div(int x, int y)
        {
            var result = x / y;
            ViewBag.Result = result;
            return View();
        }
        public IActionResult Sub(int x, int y)
        {
            var result = x - y;
            ViewBag.Result = result;
            return View();
        }
    }
}
