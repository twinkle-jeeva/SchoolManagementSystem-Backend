using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class ParentCreateDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name can't exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name can't exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Relationship is required")]
        [StringLength(20)]
        public string Relationship { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
         [EmailAddress(ErrorMessage = "Invalid Email format")]
         public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}