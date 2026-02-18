using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime DateOfBirth { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
                // 1-M: Student belongs to one course
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        // M-M: Student can join multiple clubs
        public ICollection<Club> Clubs { get; set; } = new List<Club>();

        // 1-1: StudentProfile
        public StudentProfile? Profile { get; set; }


    }
}