using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechCareerAssignment.Enums;

namespace TechCareerAssignment.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int? CompanyId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        // Navigation properties
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
