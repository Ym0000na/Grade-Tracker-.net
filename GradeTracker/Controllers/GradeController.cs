using Microsoft.AspNetCore.Mvc;
using GradeTracker.Models;
using Microsoft.EntityFrameworkCore;
using GradeTracker.ViewModels;

namespace GradeTracker.Controllers
{
    public class GradeController : Controller
    {
        private readonly AppDbContext _db;

        public GradeController(AppDbContext db)
        {
            _db = db;
        }

        // Show all grades for a student
        //public IActionResult Index(int studentId)
        //{
        //    var student = _db.Students
        //        .Include(s => s.Grades)
        //        .FirstOrDefault(s => s.Id == studentId);

        //    if (student == null) return RedirectToAction("Index", "Student");
        //    return View(student);
        //}

        public IActionResult Index(int studentId)
        {
            var student = _db.Students
                .Where(s => s.Id == studentId)
                .Select(s => new StudentGradeViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Grades = s.Grades.Select(g => new GradeViewModel
                    {
                        Id= g.Id,
                        Subject = g.Subject,
                        Score = g.Score
                    }).ToList()
                })
                .FirstOrDefault();

            if (student == null) return RedirectToAction("Index", "Student");
            return View(student);
        }

        // Save new grade
        [HttpPost]
        public IActionResult Create(int studentId, string subject, int score)
        {
            bool subjectExists = _db.Grades
                .Any(g => g.StudentId == studentId && g.Subject.ToLower() == subject.ToLower());

            if (subjectExists)
            {
                TempData["Error"] = "This subject already exists for this student.";
                return RedirectToAction("Index", new { studentId });
            }

            _db.Grades.Add(new Grade
            {
                StudentId = studentId,
                Subject = subject,
                Score = score
            });
            _db.SaveChanges();
            return RedirectToAction("Index", new { studentId });
        }

        // Delete grade
        [HttpPost]
        public IActionResult Delete(int id, int studentId)
        {
            var grade = _db.Grades.Find(id);
            if (grade != null)
            {
                _db.Grades.Remove(grade);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", new { studentId });
        }
    }
}