using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class TeacherCreateDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public string? Department { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [StringLength(200)]
        public string Education { get; set; } = string.Empty;
    }
}
