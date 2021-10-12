using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public StudentModel FindStudent(Guid id)
        {
            foreach (StudentModel student in Students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }

            return null;
        }

        public void DeleteStudent(Guid id)
        {
            Students.Remove(FindStudent(id));
            string AllStudent = JsonConvert.SerializeObject(Students);
            File.WriteAllText("students.json", AllStudent);
            
        }
    }
}