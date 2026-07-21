using System.ComponentModel.DataAnnotations;

namespace GradeTracker.ViewModels
{
    public class student_Grade_viewmodel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }

        public int Score { get; set; }
    }

}
