using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechCareerAssignment.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        public int CompanyId { get; set; }

        // Navigation properties
        public virtual Company Company { get; set; }
    }
}
