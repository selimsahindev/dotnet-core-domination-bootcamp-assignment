using System.ComponentModel.DataAnnotations;
using TechCareerAssignment.Enums;

namespace TechCareerAssignment.Models
{
    public class Room : BaseModel
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public RoomType Type { get; set; } = RoomType.Standard;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
