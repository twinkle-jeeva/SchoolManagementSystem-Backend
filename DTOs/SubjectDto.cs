using System;

namespace StudentDemoAPI.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int? TeacherId { get; set; }
        public int CourseId { get; set; }

        public int? Level { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}