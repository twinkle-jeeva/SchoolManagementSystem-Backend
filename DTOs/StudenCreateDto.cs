using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class StudentCreateDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name can't exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Course Id is required")]
        public int CourseId { get; set; }

        // Clubs are optional
        public List<int>? ClubIds { get; set; } = new();

        [StringLength(200, ErrorMessage = "Address can't exceed 200 characters")]
        public string? Address { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
