using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLesson1.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
