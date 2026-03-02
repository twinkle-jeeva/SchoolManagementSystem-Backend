using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class EmergencyContactCreateDto
    {
        [Required]
        public int ParentId { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Relationship is required")]
        [StringLength(20)]
        public string Relationship { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

       [Required(ErrorMessage = "Email is required")]
       [EmailAddress(ErrorMessage = "Invalid Email format")]
       public string Email { get; set; } = string.Empty;

    }

}