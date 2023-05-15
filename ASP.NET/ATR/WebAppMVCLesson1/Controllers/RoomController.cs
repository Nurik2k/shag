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

        public IActionResult Index()
        {
            List<Room> rooms = db.Rooms.Include(c => c.Category).ToList();

            return View(rooms);
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public async Task<IActionResult> RoomDetails(int Id)
        {
            Room room = new Room();
            using (HttpClient client = new HttpClient())
            {
                using (var request = client.GetAsync("http://localhost:5036/api/Room/GetRoomById?id=" + Id))
                {

                    var result = await request.Result.Content.ReadAsStringAsync();
                    if (request.IsFaulted)
                    {
                        room = JsonConvert.DeserializeObject<Room>(result);
                    }
                    else if (request.Result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        ViewBag.Message = "Информация по данной комнате не найдена";
                    }
                    else
                    {
                        ViewBag.Message = "При получении данных возникла ошибка" + result;
                    }
                }
            }
            return View(room);
        }
    }
}
