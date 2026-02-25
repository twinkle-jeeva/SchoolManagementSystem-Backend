using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.DTOs
{
       public class CourseDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? GradeLevel { get; set; }
        public int? Credits { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TeacherId { get; set; }

        public List<int> SubjectIds { get; set; } = new List<int>();
        public List<int> StudentIds { get; set; } = new List<int>();
    }

}