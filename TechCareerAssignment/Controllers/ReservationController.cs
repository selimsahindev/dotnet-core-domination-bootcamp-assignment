using Microsoft.AspNetCore.Mvc;
using TechCareerAssignment.Dtos;
using TechCareerAssignment.Services;

namespace TechCareerAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservation
        [HttpGet]
        public ActionResult<IEnumerable<ReservationDto>> GetReservations()
        {
            var reservations = _reservationService.GetReservations();
            return Ok(reservations);
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public ActionResult<ReservationDto> GetReservationById(int id)
        {
            var reservation = _reservationService.GetReservationById(id);
            return Ok(reservation);
        }

        // POST: api/Reservation
        [HttpPost]
        public ActionResult<ReservationDto> CreateReservation(ReservationCreateDto reservationDto)
        {
            var reservation = _reservationService.CreateReservation(reservationDto);
            return Ok(reservation);
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, ReservationUpdateDto reservationDto)
        {
            var reservation = _reservationService.UpdateReservation(id, reservationDto);
            return Ok(reservation);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _reservationService.DeleteReservation(id);
            return Ok(reservation);
        }
    }
}
