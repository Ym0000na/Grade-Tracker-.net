using System.ComponentModel.DataAnnotations;

namespace GradeTracker.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Range(0, 100, ErrorMessage = "Score must be between 0 and 100")]
        public int Score { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}