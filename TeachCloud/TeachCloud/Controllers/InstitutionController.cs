////using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using TeachCloud.Core.Entities;
//using TeachCloud.Data;
//using File = TeachCloud.Core.Entities.File;

//namespace TeachCloud.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class FileController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public FileController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            return Ok(_context.Files);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var file = _context.Files.FirstOrDefault(f => f.Id == id);
//            if (file == null)
//                return NotFound();
//            return Ok(file);
//        }

//        [HttpPost]
//        public IActionResult Create(File file)
//        {
//            _context.Files.Add(file);
//          //  _context.SaveChanges(); // ✅ שומר את ההוספה
//            return CreatedAtAction(nameof(GetById), new { id = file.Id }, file);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update(int id, File file)
//        {
//            var existing = _context.Files.FirstOrDefault(f => f.Id == id);
//            if (existing == null)
//                return NotFound();

//            existing.FileName = file.FileName;
//            existing.FilePath = file.FilePath;

//           // _context.SaveChanges(); // ✅ שומר את העדכון
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var file = _context.Files.FirstOrDefault(f => f.Id == id);
//            if (file == null)
//                return NotFound();

//            _context.Files.Remove(file);
//           // _context.SaveChanges(); // ✅ שומר את המחיקה
//            return NoContent();
//        }
//    }
//}
