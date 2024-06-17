using EmploymentApi.DTOs;
using EmploymentApi.Models;
using EmploymentApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmploymentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _service;

        public DevelopersController(IDeveloperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetAll()
        {
            var developers = await _service.GetAllAsync();
            return Ok(developers);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Developer>> GetByEmail(string email)
        {
            var developer = await _service.GetByEmailAsync(email);
            if (developer == null)
                return NotFound();
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DeveloperDto developerDto)
        {
            await _service.AddAsync(developerDto);
            return CreatedAtAction(nameof(GetByEmail), new { email = developerDto.Email }, developerDto);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DeveloperDto developerDto)
        {
            await _service.UpdateAsync(id,developerDto);
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            await _service.DeleteAsync(email);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Developer>>> Search([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] int? age, [FromQuery] int? workedHours)
        {
            var developers = await _service.SearchAsync(firstName, lastName, age, workedHours);
            return Ok(developers);
        }
    }
}
