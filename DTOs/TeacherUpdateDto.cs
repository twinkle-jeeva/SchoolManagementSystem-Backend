using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class TeacherUpdateDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Joining Date is required")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Education is required")]
        public string Education { get; set; } = string.Empty;
         public List<int>? CourseIds { get; set; } 

    }
}