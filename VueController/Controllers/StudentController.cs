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
        [HttpGet("{prenom}/{nom}/{techno}")]
        public IActionResult Create(string prenom, string nom, string techno)
        {
            StudentModel newStudent = new StudentModel()
            {
                Id = Guid.NewGuid(),
                Name = prenom,
                Surname = nom,
                Fav = techno
            };
           students.AddStudent(newStudent);
           return RedirectToAction("Index");
        }
        
        // GET: student/delete/id
        [HttpGet("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            students.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        
        // GET: student/edit/nom/prenom/techno
        [HttpGet("edit/{prenom}/{nom}/{techno}")]
        public IActionResult Edit(string prenom, string nom, string techno)
        {
            students.ModifyStudent(prenom, nom, techno);
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