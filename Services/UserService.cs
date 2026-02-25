using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(UserCreateDto dto)
        {
            if (await _repo.ExistsByEmailAsync(dto.Email))
                throw new Exception("Email already exists");

            var user = _mapper.Map<User>(dto);
            await _repo.AddAsync(user);
            await _repo.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}