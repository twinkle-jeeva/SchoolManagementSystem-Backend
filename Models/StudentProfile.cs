using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

    }
}