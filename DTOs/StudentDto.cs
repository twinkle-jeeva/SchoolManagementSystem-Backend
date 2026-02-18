using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CourseName { get; set; }
        public List<string>? Clubs { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }


    }
}