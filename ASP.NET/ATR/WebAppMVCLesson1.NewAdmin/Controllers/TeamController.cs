using Microsoft.AspNetCore.Mvc;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Migrations;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class TeamController : Controller
    {
        private WebAppMVCLesson1DbContext db;
        private IWebHostEnvironment hostEnvironment;
        public TeamController(WebAppMVCLesson1DbContext db, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.TeamWorks.ToList();

            return View(data);
        }

        public IActionResult AddTeam()
        {
            Modals.TeamWork teamWork = new Modals.TeamWork();
            ViewBag.JobPosition = db.JobPositions.ToList();
            return View(teamWork);
        }

        [HttpPost]
        public IActionResult AddTeam(IFormFile Photo, Modals.TeamWork teamWork)
        {
            try
            {
                string shortpath = Path.Combine("img", "teams", Photo.FileName);
                string path = Path.Combine(hostEnvironment.WebRootPath, "img", "teams", Photo.FileName);

                //using (FileStream filestream = new FileStream(path, FileMode.Create))
                //{
                //    Photo.CopyTo(filestream);
                //}

                teamWork.Photo = shortpath;

                db.TeamWorks.Add(teamWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message + ex.InnerException?.Message;
                return View(teamWork);

            }

        }
        public IActionResult DeleteTeam()
        {
            return View();
        }
        public IActionResult EditTeam()
        {
            return View();
        }
    }
}
