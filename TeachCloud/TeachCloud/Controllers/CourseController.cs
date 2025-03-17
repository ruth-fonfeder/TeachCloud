using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Courses);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Courses.FirstOrDefault(c => c.Id == id));

        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Courses.Add(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Course course)
        {
            var existing = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();
            existing.Name = course.Name;
            existing.TeacherId = course.TeacherId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();
            _context.Courses.Remove(course);
            return NoContent();
        }
    }

}
