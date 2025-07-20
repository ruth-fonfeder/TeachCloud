using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lessons = _lessonService.GetAllLessons();
            var lessonDtos = _mapper.Map<List<LessonDto>>(lessons);
            return Ok(lessonDtos);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var lesson = _lessonService.GetLessonById(id);
        //    if (lesson == null) return NotFound();
        //    var lessonDto = _mapper.Map<LessonDto>(lesson);
        //    return Ok(lessonDto);
        //}


        //[HttpPost]
        //public IActionResult CreateLesson([FromBody] LessonCreateDto lessonDto)
        //{
        //    if (lessonDto == null || string.IsNullOrWhiteSpace(lessonDto.Title))
        //        return BadRequest("Invalid lesson data.");

        //    var lesson = new Lesson
        //    {
        //        Title = lessonDto.Title,
        //        StudyGroupId = lessonDto.StudyGroupId
        //    };

        //    var createdLesson = _lessonService.CreateLesson(lesson);

        //    return CreatedAtAction(nameof(GetLessonById), new { id = createdLesson.Id }, createdLesson);
        //}


        [HttpPost]
        public IActionResult CreateLesson([FromBody] LessonCreateDto lessonDto)
        {
            if (lessonDto == null || string.IsNullOrWhiteSpace(lessonDto.Title))
                return BadRequest("Invalid lesson data.");

            var lesson = new Lesson
            {
                Title = lessonDto.Title,
                StudyGroupId = lessonDto.StudyGroupId
            };

            var createdLesson = _lessonService.CreateLesson(lesson);

            var lessonDtoToReturn = _mapper.Map<LessonDto>(createdLesson);
            return CreatedAtAction(nameof(GetLessonById), new { id = createdLesson.Id }, lessonDtoToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonById(int id)
        {
            var lesson = _lessonService.GetLessonById(id);
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);
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

        [HttpGet("{courseId}/lessons")]
        public IActionResult GetLessonsByCourse(int courseId)
        {
            var lessons = _lessonService.GetLessonsByCourseId(courseId);
            if (lessons == null || !lessons.Any())
                return NotFound();

            var lessonDtos = _mapper.Map<List<LessonDto>>(lessons);
            return Ok(lessonDtos);
        }

    }
    public class LessonCreateDto
    {
        public string Title { get; set; }
        public int StudyGroupId { get; set; }
    }
}
