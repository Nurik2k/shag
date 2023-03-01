using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAppMVCLesson1.Admin.Models;
using WebAppMVCLesson1.Lib;

namespace WebAppMVCLesson1.Admin.Controllers
{
    public class DirectoryController : Controller
    {
        private IWebHostEnvironment hostEnvironment;
        private IConfiguration config;
        private CustomOptionsConfiguration options;
        private EFContext db;
        public DirectoryController(IWebHostEnvironment _hostEnvironment, IConfiguration _config, IOptions<CustomOptionsConfiguration> _options, EFContext _db)
        {
            hostEnvironment = _hostEnvironment;
            config = _config;
            options = _options.Value;
            db = _db;
        }

       

        public IActionResult Index(string message)
        {
            //Вариант 1
            var option1 = config.GetValue<string>("customOptions:complexOption:option1");
            var option2 = config.GetSection("customOptions").GetSection("complexOption").GetSection("option2").Value;
           //Вариант2
            CustomOptionsConfiguration coc = new CustomOptionsConfiguration();
            config.GetSection("customOptions").Bind(coc);
            //Вариант 2
            
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
        public ActionResult EventCategoryIndex()
        {
            return View(db.EventCategories.ToList());
        }
    }
}
