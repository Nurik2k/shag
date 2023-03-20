using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVCLesson1.Models;

namespace WebAppMVCLesson1.Controllers
{
    public class RoomController : Controller
    {
        private EFContext db;
        public RoomController(EFContext db)
        {
           this.db = db;
        }

        public IActionResult Index()
        {
            List<Room> rooms = db.Rooms.Include(c=>c.Category).ToList();

            return View(rooms);
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
