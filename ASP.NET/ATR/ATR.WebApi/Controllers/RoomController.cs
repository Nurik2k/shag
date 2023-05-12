using ATR.WebApi.Data;
using ATR.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ATR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public RoomController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> Get()
        {
            var room = await dbContext.Rooms.ToListAsync();
            return room;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Room room)
        {
            try
            {

                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
                return Ok(room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] Room room)
        {

            var findRooms = dbContext.Rooms.Find(room.RoomId);
            if (findRooms == null)
            {
                return BadRequest("Room is empty");
            }
            else
            {
                try
                {
                    findRooms.RoomNumber = room.RoomNumber;
                    findRooms.MainPicturePath = room.MainPicturePath;
                    findRooms.CreateDate = room.CreateDate;
                    findRooms.Description = room.Description;
                    findRooms.Price = room.Price;
                    findRooms.CategoryId = room.CategoryId;
                    findRooms.CreateUser = room.CreateUser;
                    dbContext.SaveChanges();
                    return Ok();
                }
                catch (Exception ex) { return BadRequest(ex.Message); }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int RoomId)
        {
            try
            {
                var findRoom = dbContext.Rooms.Find(RoomId);
                dbContext.Rooms.Remove(findRoom);
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
