using Microsoft.AspNetCore.Mvc;
using WebAppMVCLesson1.NewAdmin.DataContext;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class RoomController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        public RoomController(WebAppMVCLesson1DbContext _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();
            return View(rooms);
        }


    }
}
