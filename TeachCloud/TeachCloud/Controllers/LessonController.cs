using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;
using System.Linq;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly DataContext _context;

        public LessonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Lessons);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Lessons.FirstOrDefault(l => l.Id == id));

        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            return CreatedAtAction(nameof(GetById), new { id = lesson.Id }, lesson);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Lesson lesson)
        {
            var existing = _context.Lessons.FirstOrDefault(l => l.Id == id);
            if (existing == null) return NotFound();
            existing.Title = lesson.Title;
            existing.Date = lesson.Date;
            existing.StudyGroupId = lesson.StudyGroupId;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lesson = _context.Lessons.FirstOrDefault(l => l.Id == id);
            if (lesson == null) return NotFound();
            _context.Lessons.Remove(lesson);
            return NoContent();
        }
    }
}