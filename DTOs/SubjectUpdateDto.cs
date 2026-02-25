using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class SubjectUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int? TeacherId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public int? Level { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}