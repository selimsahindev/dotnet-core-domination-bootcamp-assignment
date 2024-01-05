using System.ComponentModel.DataAnnotations;

namespace TechCareerAssignment.Models
{
    public class Company : BaseModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(120)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(400)]
        public string Address { get; set; } = null!;
    }
}
