using Microsoft.AspNetCore.Mvc;
using GradeTracker.Models;
using GradeTracker.ViewModels;

namespace GradeTracker.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }
        //only a test

        // Show all students
        public IActionResult Index()
        {
            var students = _db.Students.ToList();

            var grade = _db.Grades.ToList();

            //Linq query;
            var query = (from s in students
                        join g in grade on s.Id equals g.StudentId //into studentGrades
                        select new student_Grade_viewmodel
                        {
                            Name = s.Name,
                            Email = s.Email,
                           // Grades = studentGrades.ToList()
                           Subject=g.Subject,
                            Score=g.Score,
                        }).ToList();


            return View(students);
        }

        // Show add form
        public IActionResult Create()
        {
            return View();
        }

        // Save new student
        [HttpPost]
        public IActionResult Create(string name, string email)
        {
            _db.Students.Add(new Student { Name = name, Email = email });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete student
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _db.Students.Find(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}