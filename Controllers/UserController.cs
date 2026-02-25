using Microsoft.AspNetCore.Mvc;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) => _service = service;

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserCreateDto dto)
        {
            try
            {
                var user = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }
    }
}