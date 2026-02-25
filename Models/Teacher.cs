using System;
using System.Collections.Generic;

namespace StudentDemoAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        public DateTime JoiningDate { get; set; }
        public string Education { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; }  

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}