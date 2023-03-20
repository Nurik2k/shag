using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class CaruselController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment hostEnvironment;

        public CaruselController(WebAppMVCLesson1DbContext _db, 
                                 IWebHostEnvironment hostEnvironment)
        {
            db = _db;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var data = db.Carusels.ToList();

            return View(data);
        }

        public IActionResult AddCarusel()
        {
            Carusel carl = new Carusel();
            return View(carl);
        }

        [HttpPost]
        public IActionResult AddCarusel(IFormFile PictureUrl, Carusel carusel)
        {
            try
            {
                string picUrl = 
                    Path.Combine(
                        hostEnvironment.WebRootPath,
                        "img",
                        PictureUrl.FileName);

                string shortPicUrl =
                   Path.Combine("img",
                       PictureUrl.FileName);

                using (var stream =
                new FileStream(picUrl, FileMode.Create))
                {
                     PictureUrl.CopyTo(stream);
                }

                carusel.PictureUrl = shortPicUrl;
                db.Carusels.Add(carusel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            
        }
    }
}
