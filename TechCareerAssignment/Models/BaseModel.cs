namespace TechCareerAssignment.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
    }
}
