using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLesson1.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
