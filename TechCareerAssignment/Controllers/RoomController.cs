using Microsoft.AspNetCore.Mvc;
using TechCareerAssignment.Data;
using TechCareerAssignment.Models;

namespace TechCareerAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Room
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _dbContext.Rooms;
            return Ok(rooms);
        }

        // GET: api/Room/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = _dbContext.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/Room
        [HttpPost]
        public ActionResult<Room> CreateRoom([FromBody] Room newRoom)
        {
            if (newRoom == null)
            {
                return BadRequest("Room data is null.");
            }

            _dbContext.Rooms.Add(newRoom);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetRoom", new { id = newRoom.Id }, newRoom);
        }

        // PUT: api/Room/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Room> UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            if (updatedRoom == null)
            {
                return BadRequest("Room data is null.");
            }

            var room = _dbContext.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            room.Name = updatedRoom.Name;
            room.Type = updatedRoom.Type;
            room.Description = updatedRoom.Description;

            _dbContext.SaveChanges();

            return Ok(room);
        }

        // DELETE: api/Room/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Room> DeleteRoom(int id)
        {
            var room = _dbContext.Rooms.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();

            return Ok(room);
        }
    }
}
