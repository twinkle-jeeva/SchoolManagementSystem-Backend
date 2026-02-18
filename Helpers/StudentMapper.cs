using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Helpers
{
    public static class StudentMapper
    {
        public static StudentDto ToDto(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                CourseName = student.Course?.Name,
                Clubs = student.Clubs?.Select(c => c.Name).ToList(),
                Address = student.Profile?.Address,
                Phone = student.Profile?.Phone
            };
        }

        public static Student ToEntity(StudentCreateDto dto)
        {
            return new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                CourseId = dto.CourseId,
                Profile = new StudentProfile
                {
                    Address = dto.Address,
                    Phone = dto.Phone
                }
            };
        }
    }
}
