using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateAsync(StudentCreateDto dto)
        {
            // Check course exists
            var course = await _courseRepository.GetByIdAsync(dto.CourseId);
            if (course == null) throw new Exception("Invalid Course Id");

            // Check unique email
            if (await _studentRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception("Email already exists");

            var student = _mapper.Map<Student>(dto);
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto?> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var existing = await _studentRepository.GetByIdAsync(id);
            if (existing == null) return null;

            // Check email uniqueness if changed
            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != existing.Email)
            {
                if (await _studentRepository.ExistsByEmailAsync(dto.Email))
                    throw new Exception("Email already exists");
            }

            // Check course exists
            var course = await _courseRepository.GetByIdAsync(dto.CourseId);
            if (course == null) throw new Exception("Invalid Course Id");

            // Map updates
            _mapper.Map(dto, existing);

            await _studentRepository.UpdateAsync(existing);
            await _studentRepository.SaveChangesAsync();

            return _mapper.Map<StudentDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return false;

            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveChangesAsync();

            return true;
        }
    }
}