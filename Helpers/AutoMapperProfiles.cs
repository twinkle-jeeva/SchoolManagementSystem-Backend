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

        CreateMap<TeacherUpdateDto, Teacher>()
           .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Teacher, TeacherDto>()
        .ForMember(dest => dest.FullName,
        opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
       .ForMember(dest => dest.Courses,
        opt => opt.MapFrom(src => src.Courses.Select(c => c.Name)))
      .ForMember(dest => dest.Subjects,
        opt => opt.MapFrom(src => src.Subjects.Select(s => s.Name)));
     // Parent mappings
            CreateMap<ParentCreateDto, Parent>();

            CreateMap<ParentUpdateDto, Parent>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Parent, ParentDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // EmergencyContact mappings
            CreateMap<EmergencyContactCreateDto, EmergencyContact>();

            CreateMap<EmergencyContactUpdateDto, EmergencyContact>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EmergencyContact, EmergencyContactDto>();


        // User mappings
         CreateMap<UserCreateDto, User>()
        .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

          CreateMap<User, UserDto>();
    }
}

}
