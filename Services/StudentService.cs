using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.DTOs.Common;
using StudentDemoAPI.Models;
using StudentDemoAPI.Helpers;
using StudentDemoAPI.Repositories;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Services.Interfaces;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // Get paginated, searchable, sortable students
        public async Task<PagedResult<StudentDto>> GetStudentsAsync(
            ClaimsPrincipal user,
            QueryParamsDto request)
        {
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;

            IQueryable<Student> query = _studentRepository.GetQueryable()
                        .Include(s => s.Course)
                        .Include(s => s.Parents)
                            .ThenInclude(p => p.EmergencyContacts);


            // Role-based access
            if (role == Roles.Parent)
                query = query.Where(s => s.Parents.Any(p => p.Email == email));
            else if (role == Roles.Student)
                query = query.Where(s => s.Email == email);
            else if (role == Roles.Teacher)
                query = query.Where(s => s.Course != null && s.Course.Teacher != null && s.Course.Teacher.Email == email);

            // Search
            query = query.ApplySearch(request.Search,
                        s => s.FirstName,
                        s => s.LastName,
                        s => s.Email);

            // Sorting
            query = query.ApplySorting(request.SortBy, request.IsDescending);

            // Total count before pagination
            var total = await query.CountAsync();

            // Pagination
            var pagedData = await query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ToListAsync();

            var studentDtos = _mapper.Map<List<StudentDto>>(pagedData);

            return new PagedResult<StudentDto>
            {
                Items = studentDtos,
                TotalCount = total,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        // Get student by ID
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetQueryable()
                .Include(s => s.Course)
                .Include(s => s.Parents)
                    .ThenInclude(p => p.EmergencyContacts)
                .FirstOrDefaultAsync(s => s.Id == id);

            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        // Create new student
        public async Task<StudentDto> CreateAsync(StudentCreateDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(dto.CourseId);
            if (course == null) throw new Exception("Invalid Course Id");

            if (await _studentRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception("Email already exists");

            var student = _mapper.Map<Student>(dto);
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return _mapper.Map<StudentDto>(student);
        }

        // Update student
        public async Task<StudentDto?> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var existing = await _studentRepository.GetByIdAsync(id);
            if (existing == null) return null;

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != existing.Email)
            {
                if (await _studentRepository.ExistsByEmailAsync(dto.Email))
                    throw new Exception("Email already exists");
            }
if (dto.CourseId.HasValue)
{
            var course = await _courseRepository.GetByIdAsync(dto.CourseId.Value);
            if (course == null) throw new Exception("Invalid Course Id");
}
            _mapper.Map(dto, existing);

            await _studentRepository.UpdateAsync(existing);
            await _studentRepository.SaveChangesAsync();

            return _mapper.Map<StudentDto>(existing);
        }

        // Delete student
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