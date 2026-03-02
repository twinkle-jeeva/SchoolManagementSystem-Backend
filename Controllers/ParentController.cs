using Microsoft.AspNetCore.Mvc;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ParentDto>>> GetAll()
        {
            var parents = await _parentService.GetAllAsync();
            return Ok(parents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParentDto>> GetById(int id)
        {
            var parent = await _parentService.GetByIdAsync(id);
            if (parent == null) return NotFound();
            return Ok(parent);
        }

        [HttpPost]
        public async Task<ActionResult<ParentDto>> Create([FromBody] ParentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var created = await _parentService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParentDto>> Update(int id, [FromBody] ParentUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updated = await _parentService.UpdateAsync(id, dto);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _parentService.DeleteAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}