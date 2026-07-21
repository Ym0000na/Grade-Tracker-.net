using System.ComponentModel.DataAnnotations;

namespace GradeTracker.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>();
    }
}