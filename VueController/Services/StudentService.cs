using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VueController.Models;

namespace VueController.Services
{
    public class StudentService
    {
        public List<StudentModel> Students;

        public StudentService()
        {
            string text = File.ReadAllText("students.json");
            Students = JsonConvert.DeserializeObject<List<StudentModel>>(text);
        }

        public void AddStudent(StudentModel student)
        {
            Students.Add(student);
            string AllStudent = JsonConvert.SerializeObject(Students);
            File.WriteAllText("students.json", AllStudent);
        }
        

        public void DeleteStudent(Guid id)
        {
            Students.Remove(Students.First(i => i.Id == id));
            string AllStudent = JsonConvert.SerializeObject(Students);
            File.WriteAllText("students.json", AllStudent);
            
        }
        
        public void ModifyStudent(string prenom, string nom, string NewFav)
        {
            StudentModel studentFound = Students.FirstOrDefault(i => i.Name == prenom && i.Surname == nom);
            DeleteStudent(studentFound.Id);
            studentFound.Fav = NewFav;
            AddStudent(studentFound);

        }
    }
}