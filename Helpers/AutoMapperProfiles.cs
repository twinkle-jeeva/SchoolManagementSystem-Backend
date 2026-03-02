using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace StudentDemoAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Course mappings
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseDto>();

            // Subject mappings
            CreateMap<SubjectCreateDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();
            CreateMap<Subject, SubjectDto>();

            // Student mappings
            CreateMap<StudentCreateDto, Student>();

            CreateMap<StudentUpdateDto, Student>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CourseName,
                           opt => opt.MapFrom(src => src.Course != null ? src.Course.Name : null));

            // Teacher mappings
        CreateMap<TeacherCreateDto, Teacher>();
        CreateMap<TeacherUpdateDto, Teacher>();
        CreateMap<Teacher, TeacherDto>()
            .ForMember(dest => dest.Courses,
                opt => opt.MapFrom(src => src.Courses != null
                    ? src.Courses.Select(c => c.Name).ToList()
                    : new List<string>()))
            .ForMember(dest => dest.Subjects,
                opt => opt.MapFrom(src => src.Subjects != null
                    ? src.Subjects.Select(s => s.Name).ToList()
                    : new List<string>()));
                                // Parent mappings
            CreateMap<ParentCreateDto, Parent>();
            CreateMap<ParentUpdateDto, Parent>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Parent, ParentDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            // EmergencyContact mappings
            CreateMap<EmergencyContactCreateDto, EmergencyContact>();
            CreateMap<EmergencyContactUpdateDto, EmergencyContact>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<EmergencyContact, EmergencyContactDto>();


            // User mappings
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.MapFrom(src => HashPassword(src.Password)));

            CreateMap<User, UserDto>();
        }

           // Password hashing function
        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}