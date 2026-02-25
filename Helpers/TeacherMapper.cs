using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Helpers
{
    public static class TeacherMapper
    {
        public static TeacherDto ToDto(Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Address = teacher.Address,
                JoiningDate = teacher.JoiningDate,
                Education = teacher.Education,
                CreatedDate = teacher.CreatedDate,
               /* Courses = teacher.Courses?.Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToList() ?? new List<CourseDto>()*/ 
            }; 
        }

        public static Teacher ToEntity(TeacherCreateDto dto)
        {
            return new Teacher
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone ?? string.Empty,
                Address = dto.Address ?? string.Empty,
                JoiningDate = dto.JoiningDate,
                Education = dto.Education,
                CreatedDate = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(Teacher teacher, TeacherUpdateDto dto)
        {
            teacher.FirstName = dto.FirstName;
            teacher.LastName = dto.LastName;
            teacher.Email = dto.Email;
            teacher.Phone = dto.Phone ?? string.Empty;
            teacher.Address = dto.Address ?? string.Empty;
            teacher.JoiningDate = dto.JoiningDate;
            teacher.Education = dto.Education;
        }
    }
}