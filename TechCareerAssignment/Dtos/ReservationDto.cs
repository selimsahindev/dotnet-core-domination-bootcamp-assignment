using TechCareerAssignment.Enums;

namespace TechCareerAssignment.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? CompanyId { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}
