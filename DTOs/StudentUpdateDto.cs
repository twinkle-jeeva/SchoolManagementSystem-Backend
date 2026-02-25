using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.DTOs;

public class StudentUpdateDto
{
    [StringLength(50, ErrorMessage = "First Name can't exceed 50 characters")]
    public string? FirstName { get; set; }

    [StringLength(50, ErrorMessage = "Last Name can't exceed 50 characters")]
    public string? LastName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }
    public int CourseId { get; set; }  


    [StringLength(200, ErrorMessage = "Address can't exceed 200 characters")]
    public string? Address { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format")]
    [StringLength(20)]
    public string? Phone { get; set; }
}