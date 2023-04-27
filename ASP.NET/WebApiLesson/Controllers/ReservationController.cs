using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApiLesson.Models;

namespace WebApiLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        private IWebHostEnvironment webHostEnvironment;
        public ReservationController(IRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile([FromForm] IFormFile file)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Images/" + file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "http://localhost:5177/Images/" + file.FileName;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{Id}")]
        public ActionResult<Reservation> Get(int id)
        {
            if (id == 0) return BadRequest("Value must be passed in the request");
            return Ok(repository[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation res)
        {
            if (!Authentificate())
                return Unauthorized();

            return Ok(repository.AddReservation(
            new Reservation
            {
                Name = res.Name,
                StartLocation = res.StartLocation,
                EndLocation = res.EndLocation
            }));
        }

        bool Authentificate()
        {
            var allowKeys = new[] { "Secret@123", "VictoriaSecret" };
            StringValues key = Request.Headers["Key"];
            int count = (from t in allowKeys where t == key select t).Count();
            return count == 0 ? false : true;
        }

        [HttpPut]
        public Reservation Put([FromForm] Reservation res) => repository.UpdateReservation(res);

        [HttpDelete("{Id}")]
        public void Delete(int id) => repository.DeleteReservation(id);

    }
}
