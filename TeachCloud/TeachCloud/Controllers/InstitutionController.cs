using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeachCloud.Controllers
{
    using global::TeachCloud.Data;
    using Microsoft.AspNetCore.Mvc;
   // using TeachCloud.Core.Entities;
   // using TeachCloud.Data;

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
            public IActionResult GetAll() => Ok(_context.Files);

            [HttpGet("{id}")]
            public IActionResult GetById(int id) => Ok(_context.Files.FirstOrDefault(f => f.Id == id));

            [HttpPost]
            public IActionResult Create(File file)
            {
                _context.Files.Add(file);
                return CreatedAtAction(nameof(GetById), new { id = file.Id }, file);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, File file)
            {
                var existing = _context.Files.FirstOrDefault(f => f.Id == id);
                if (existing == null) return NotFound();
                existing.FileName = file.FileName;
                existing.FilePath = file.FilePath;
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var file = _context.Files.FirstOrDefault(f => f.Id == id);
                if (file == null) return NotFound();
                _context.Files.Remove(file);
                return NoContent();
            }
        }

    }
