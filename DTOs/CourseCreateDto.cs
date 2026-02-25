using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentDemoAPI.DTOs
{
    public class CourseCreateDto
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;  

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int? GradeLevel { get; set; }

        public int? Credits { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TeacherId { get; set; }
    }
}