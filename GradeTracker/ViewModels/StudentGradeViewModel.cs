namespace GradeTracker.ViewModels
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }

        public string LetterGrade
        {
            get
            {
                if (Score >= 95) return "A+";
                if (Score >= 90) return "A";
                if (Score >= 85) return "B+";
                if (Score >= 80) return "B";
                if (Score >= 75) return "C+";
                if (Score >= 70) return "C";
                if (Score >= 65) return "D+";
                if (Score >= 60) return "D";
                return "F";
            }
        }
    }

    public class StudentGradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<GradeViewModel> Grades { get; set; }
    }
}