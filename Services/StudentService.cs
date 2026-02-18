using StudentDemoAPI.DTOs;
using StudentDemoAPI.Helpers;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories;

namespace StudentDemoAPI.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        // GET all students
        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(StudentMapper.ToDto).ToList();
        }

        // GET by Id
        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            return student == null ? null : StudentMapper.ToDto(student);
        }

        // CREATE student
        public async Task<StudentDto> CreateAsync(StudentCreateDto dto)
        {
            // Check for duplicate email
            var existing = (await _repo.GetAllAsync())
                .Any(s => s.Email.ToLower() == dto.Email.ToLower());

            if (existing)
                throw new Exception("Email already exists. Please use a different email.");

            // Map basic student and profile
            var student = StudentMapper.ToEntity(dto);

            //  Handle Clubs (many-to-many)
            if (dto.ClubIds != null && dto.ClubIds.Any())
            {
                var clubs = await _repo.GetClubsByIdsAsync(dto.ClubIds);

                foreach (var club in clubs)
                    student.Clubs.Add(club);
            }

            //  Add to repository & save
            await _repo.AddAsync(student);
            await _repo.SaveChangesAsync();

            return StudentMapper.ToDto(student);
        }

        // UPDATE student
        public async Task<StudentDto?> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null) return null;

            // 1️⃣ Update basic fields
            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.DateOfBirth = dto.DateOfBirth;
            student.CourseId = dto.CourseId;

            // 2️⃣ Update profile
            if (student.Profile == null)
                student.Profile = new StudentProfile();

            student.Profile.Address = dto.Address;
            student.Profile.Phone = dto.Phone;

            // 3️⃣ Update Clubs (many-to-many)
            if (dto.ClubIds != null)
            {
                var clubs = await _repo.GetClubsByIdsAsync(dto.ClubIds);
                student.Clubs.Clear(); // remove old clubs
                foreach (var club in clubs)
                    student.Clubs.Add(club);
            }

            // 4️⃣ Update in repository & save
            await _repo.UpdateAsync(student);
            await _repo.SaveChangesAsync();

            return StudentMapper.ToDto(student);
        }

        // DELETE student
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if (student == null) return false;

            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
