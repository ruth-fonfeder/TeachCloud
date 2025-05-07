using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using FileEntity = TeachCloud.Core.Entities.File;
namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_fileService.GetAllFiles());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var file = _fileService.GetFileById(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpPost]
        public IActionResult Create(FileEntity file)
        {
            var createdFile = _fileService.CreateFile(file);
            return CreatedAtAction(nameof(GetById), new { id = createdFile.Id }, createdFile);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, FileEntity file)
        {
            var success = _fileService.UpdateFile(id, file);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _fileService.DeleteFile(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
