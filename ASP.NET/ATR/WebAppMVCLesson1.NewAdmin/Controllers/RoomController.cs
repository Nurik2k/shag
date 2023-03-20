using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class RoomController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment hostEnvironment;
        public RoomController(WebAppMVCLesson1DbContext _db, IWebHostEnvironment hostEnvironment)
        {
            this.db = _db;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();
            return View(rooms);
        }


        public IActionResult AddRoom(Room room)
        {
            if (room == null)
                room = new Room();

            ViewBag.CategoryList = db.Categories.ToList();
            return View(room);
        }

        public IActionResult EditRoom(int Id)
        {
            var room = db.Rooms.FirstOrDefault(f => f.RoomId == Id);

            return RedirectToAction("AddRoom", room );
        }



        [HttpPost]
        public IActionResult AddRoom(IFormFile MainPicturePath, Room room)
        {
            try
            {
                string shortpath = "";
                if (MainPicturePath != null)
                {
                    shortpath = Path.Combine("img", "room", MainPicturePath.FileName);
                    string path = Path.Combine(hostEnvironment.WebRootPath, "img", "room", MainPicturePath.FileName);

                    using (FileStream filestream = new FileStream(path, FileMode.Create))
                    {
                        MainPicturePath.CopyTo(filestream);
                    }                   
                }               

                room.MainPicturePath = shortpath;
                room.CreateDate = DateTime.Now;
                room.CreateUser = "admin";
                
                if (room.RoomId == 0)
                {
                    db.Rooms.Add(room);
                }
                else
                {
                    var roomEdit = db.Rooms.FirstOrDefault(f => f.RoomId == room.RoomId);
                    if (roomEdit == null)
                        throw new Exception("Команата {"+ room.RoomId + "} не найдена");

                    roomEdit.MainPicturePath = room.MainPicturePath;
                    roomEdit.RoomNumber = room.RoomNumber;
                    roomEdit.Price = room.Price;
                    roomEdit.CategoryId = room.CategoryId;
                    roomEdit.Description = room.Description;
                    roomEdit.IsAvalible = room.IsAvalible;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Произошла ошибка";
                return View(room);
            }
        }


    }
}
