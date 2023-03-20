using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLesson1.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
