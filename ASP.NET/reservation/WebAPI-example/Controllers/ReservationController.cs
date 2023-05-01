using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection.Metadata.Ecma335;
using WebAPI_example.Models;

namespace WebAPI_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //filters
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
            return "http://localhost:5285/Images/" + file.FileName;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value mast be passed in the requests body");
            }
            else return Ok(repository[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation res)
        {
            if (!Authenticate()) { return Unauthorized(); }
            return Ok(repository.AddReservation(new Reservation { Name = res.Name, StartLocation = res.StartLocation, EndLocation = res.EndLocation }));
        }

        bool Authenticate()
        {
            var allowKeys = new[] { "secret@123", "VictoriasSecret" };
            StringValues key = Request.Headers["Key"];
            int count = (from t in allowKeys where t == key select t).Count();
            return count == 0 ? false : true;
        }

        [HttpPut]
        public Reservation Put([FromForm] Reservation res) => repository.UpdateReservation(res);

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}
