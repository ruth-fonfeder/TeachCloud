using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;
using System.Linq;
using FileEntity = TeachCloud.Core.Entities.File;


namespace TeachCloud.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly DataContext _context;

        public FileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Files);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == id);
            if (file == null)
                return NotFound();
            return Ok(file);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FileEntity file)
        {
            file.Id = _context.Files.Any() ? _context.Files.Max(f => f.Id) + 1 : 1;
            _context.Files.Add(file);
            return CreatedAtAction(nameof(GetById), new { id = file.Id }, file);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FileEntity file)
        {
            var existing = _context.Files.FirstOrDefault(f => f.Id == id);
            if (existing == null)
                return NotFound();

            existing.FileName = file.FileName;
            existing.FilePath = file.FilePath;
            existing.LessonId = file.LessonId;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == id);
            if (file == null)
                return NotFound();

            _context.Files.Remove(file);
            return NoContent();
        }
    }
}