using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public async Task<IActionResult> Index()
        {
            //List<Room> rooms = db.Rooms.Include(c=>c.Category).ToList();
            List<Room> rooms = new List<Room>();
            using (HttpClient client = new HttpClient())
            {
                using(var request = client.GetAsync("http://localhost:5036/api/Room"))
                {
                    var result = await request.Result.Content.ReadAsStringAsync();
                    
                    rooms = JsonConvert.DeserializeObject<List<Room>>(result);

                }
            }

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
