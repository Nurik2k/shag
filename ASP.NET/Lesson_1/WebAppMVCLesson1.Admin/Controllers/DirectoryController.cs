using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebAppMVCLesson1.Admin.Models;
using WebAppMVCLesson1.Lib;

namespace WebAppMVCLesson1.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        public DirectoryController(IWebHostEnvironment _hostEnvironment)
        {
            hostEnvironment = _hostEnvironment;
        }


        public IActionResult Index(string message)
        {
            //return View("~/Views/Home/Privacy.cshtml", "test");
            //return View("DirectoryRoomProperties");

            return View(message);
        }

        public IActionResult DirectoryRoomProperties(int page=0)
        {
            var data = new RoomPropertyModel() {
                RoomProperty = new RoomProperty(),
                RoomProperties = new List<RoomProperty>()
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult RoomProperties() 
        {
            string nameProp = Request.Form["NameProperties"];
            string descrProp = Request.Form["Description"];

            return View("Index", "Данные добавлены 1");
        }

        [HttpPost]
        public IActionResult RoomPropertiesModel(RoomProperty  roomProperties)
        {
            RoomService roomService = new RoomService();
            roomService.AddRoomProperies(roomProperties);

            return View("Index", "Данные добавлены 2");
        }

        [HttpPost]
        public async Task<IActionResult> RoomPropertiesFile(IFormFile photo)
        {
            using (var stream =
                new FileStream(
                    Path.Combine(hostEnvironment.WebRootPath, photo.FileName),
                    FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            string fileName = photo.FileName;

           return View("Index", "Данные добавлены 3");
        }
    }
}
