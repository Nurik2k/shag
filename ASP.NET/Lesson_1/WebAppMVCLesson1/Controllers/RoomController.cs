using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCLesson1.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoomList()
        {
            return View();
        }
        public IActionResult RoomDetails()
        {
            return View();
        }
    }
}
