using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
        public class TeacherDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Education { get; set; } = string.Empty;

        public List<string>? Courses { get; set; } = new();
        public List<string>? Subjects { get; set; } = new();
    }


}