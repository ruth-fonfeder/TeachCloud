using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_lessonService.GetAllLessons());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lesson = _lessonService.GetLessonById(id);
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }

        [HttpPost]
        public IActionResult Create(Lesson lesson)
        {
            var createdLesson = _lessonService.CreateLesson(lesson);
            return CreatedAtAction(nameof(GetById), new { id = createdLesson.Id }, createdLesson);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Lesson lesson)
        {
            var success = _lessonService.UpdateLesson(id, lesson);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _lessonService.DeleteLesson(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
