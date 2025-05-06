using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;
using System.Linq;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Students);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Students.FirstOrDefault(s => s.Id == id));

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
         //   _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existing = _context.Students.FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound();

            existing.FullName = student.FullName;
            existing.Email = student.Email;
            existing.PasswordHash = student.PasswordHash;
            // אין צורך לעדכן Role

            //_context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
           // _context.SaveChanges();
            return NoContent();
        }
    }
}
