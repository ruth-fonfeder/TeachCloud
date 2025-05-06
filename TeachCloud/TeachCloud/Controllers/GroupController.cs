using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;
using System.Linq;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Groups);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Groups.FirstOrDefault(g => g.Id == id));

        [HttpPost]
        public IActionResult Create(Group group)
        {
            _context.Groups.Add(group);
            return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Group group)
        {
            var existing = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (existing == null) return NotFound();
            existing.Name = group.Name;
            existing.CourseId = group.CourseId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null) return NotFound();
            _context.Groups.Remove(group);
            return NoContent();
        }
    }
}