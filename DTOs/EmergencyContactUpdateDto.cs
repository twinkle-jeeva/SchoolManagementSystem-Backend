using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs
{
    public class EmergencyContactUpdateDto
    {
        [StringLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        public string? Name { get; set; }

        [StringLength(20, ErrorMessage = "Relationship can't exceed 20 characters")]
        public string? Relationship { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20)]
        public string? Phone { get; set; }
    }
}