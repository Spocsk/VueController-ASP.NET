using System;

namespace VueController.Models
{
    public class StudentModel
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Fav { get; set; }
        
    }
}