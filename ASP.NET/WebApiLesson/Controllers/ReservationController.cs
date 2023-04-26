using Microsoft.AspNetCore.Mvc;
using WebApiLesson.Models;

namespace WebApiLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        public ReservationController(IRepository repository)
        {
            this.repository = repository;
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
        public Reservation Post([FromBody] Reservation res) =>
            repository.AddReservation(
            new Reservation
            {
                Name = res.Name,
                StartLocation = res.StartLocation,
                EndLocation = res.EndLocation
            });

        [HttpPut]
        public Reservation Put([FromForm] Reservation res) => repository.UpdateReservation(res);

        [HttpDelete("{Id}")]
        public void Delete(int id) => repository.DeleteReservation(id);

    }
}
