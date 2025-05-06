using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;
using System.Linq;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Teachers);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Teachers.FirstOrDefault(t => t.Id == id));

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            // _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Teacher teacher)
        {
            var existing = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (existing == null) return NotFound();

            existing.FullName = teacher.FullName;
            existing.Email = teacher.Email;
            existing.PasswordHash = teacher.PasswordHash;
            // אין צורך לעדכן את ה-Role
            //_context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return NotFound();

            _context.Teachers.Remove(teacher);
            // _context.SaveChanges();
            return NoContent();
        }
    }
}