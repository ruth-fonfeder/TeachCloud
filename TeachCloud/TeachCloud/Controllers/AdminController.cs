using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Admins);

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_context.Admins.FirstOrDefault(a => a.Id == id));

        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            _context.Admins.Add(admin);
            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Admin admin)
        {
            var existing = _context.Admins.FirstOrDefault(a => a.Id == id);
            if (existing == null) return NotFound();
            existing.FullName = admin.FullName;
            existing.Email = admin.Email;
            existing.PasswordHash = admin.PasswordHash;
            existing.Role = admin.Role;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == id);
            if (admin == null) return NotFound();
            _context.Admins.Remove(admin);
            return NoContent();
        }
    }
}

