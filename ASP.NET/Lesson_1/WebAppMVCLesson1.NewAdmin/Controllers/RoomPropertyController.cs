using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.Controllers
{
    public class RoomPropertyController : Controller
    {
        private WebAppMVCLesson1DbContext db;

        public RoomPropertyController(WebAppMVCLesson1DbContext _db)
        {
            db = _db;
        }

        // GET: RoomPropertyController
        public IActionResult Index()
        {
            List<RoomProperty> data = db.RoomProperties.ToList();

            return View(data);
        }

        // GET: RoomPropertyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomPropertyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomPropertyController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(string Name)
        {
            try
            {
                RoomProperty roomProperty = new RoomProperty();
                roomProperty.Name = Name;

                db.Add(roomProperty);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomPropertyController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.RoomProperties
                 .FirstOrDefault(f => f.RoomPropertyId == id);

            if (data != null)
                return View(data);
            else
                return RedirectToAction(nameof(Index));
        }

        // POST: RoomPropertyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomPropertyController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var data = db.RoomProperties
                           .FirstOrDefault(f => f.RoomPropertyId == id);

                db.RoomProperties.Remove(data);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
               
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: RoomPropertyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
