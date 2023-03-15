using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
using WebAppMVCLesson1.Admin.Models;
using WebAppMVCLesson1.Lib;

namespace WebAppMVCLesson1.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        private IConfiguration config;
        private customOptionsConfiguration options;
        private EFContext db;

        public DirectoryController(IWebHostEnvironment _hostEnvironment,
            IConfiguration _config, 
            IOptions<customOptionsConfiguration> _options,
            EFContext _db)
        {
            hostEnvironment = _hostEnvironment;
            config = _config;
            options = _options.Value;
            db = _db;
        }


        public IActionResult Index(string message)
        {

            var optin1 = 
                config.GetValue<string>("customOptions:complexOption:optin1");

            var optin2 = config.GetSection("customOptions")
                .GetSection("complexOption")
                .GetSection("optin2").Value;

            customOptionsConfiguration coc = new customOptionsConfiguration();
            config.GetSection("customOptions").Bind(coc);

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

            return RedirectToAction("Index", "Home");
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


        public ActionResult EventCategoryIndex()
        {
            return View(db.EventCategories.ToList());
        }

    }
}
