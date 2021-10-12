using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueController.Models;
using VueController.Services;

namespace VueController.Controllers
{
    [Route("[Controller]/")]
    public class StudentController : Controller
    {
        public StudentService students;

        public StudentController(StudentService studentService)
        {
            students = studentService;
        }
        // GET: Student
        [Route("/")]
        public IActionResult Index()
        {
            return View(students.Students);
        }
        
        // GET: Student/Create
        [HttpGet("{nom}/{prenom}/{techno}")]
        public IActionResult Create(string nom, string prenom, string techno)
        {
            StudentModel newStudent = new StudentModel()
            {
                Id = new Guid(),
                Name = nom,
                Surname = prenom,
                Fav = techno
            };
           students.AddStudent(newStudent);
           return RedirectToAction("Index");
        }
        
        // GET: Student/Delete/5
        public IActionResult Delete(Guid id)
        {
            students.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        
        /*// POST: Student/Create
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,Surname,Fav")] StudentModel student)
        {
            if (ModelState.IsValid)
            {
                students.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }*/
    }
}