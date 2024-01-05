using TechCareerAssignment.Dtos;

namespace TechCareerAssignment.Services
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetReservations();
        ReservationDto GetReservationById(int id);
        ReservationDto CreateReservation(ReservationCreateDto reservationDto);
        ReservationDto UpdateReservation(int id, ReservationUpdateDto reservationDto);
        ReservationDto DeleteReservation(int id);
    }
}
