using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        
    }
}