using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Migrations;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class TeamController : Controller
    {

        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment hostEnvironment;
        public TeamController(WebAppMVCLesson1DbContext _db, IWebHostEnvironment web)
        {
            db = _db;
            hostEnvironment = web;
        }

        public IActionResult Index()
        {
            var data = db.TeamWorks.ToList();
            return View(data);
        }
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(IFormFile Photo, Modals.TeamWork teamWork)
        {
            try
            {
                string pUrl =
                    Path.Combine(hostEnvironment.WebRootPath, "img", Photo.FileName);

                string shortPath = Path.Combine("img", Photo.FileName);
                using(var stream = new FileStream(pUrl, FileMode.Create))
                {
                    Photo.CopyTo(stream);
                }
                teamWork.Photo = shortPath;
                db.TeamWorks.Add(teamWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message; 
                return View(teamWork);
            }
        }
        public IActionResult EditTeam()
        {
            return View();
        }
        public IActionResult DeleteTeam()
        {
            return View();
        }

    }
}
