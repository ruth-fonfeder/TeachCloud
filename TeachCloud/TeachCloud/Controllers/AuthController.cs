using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Data;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // בדיקה אם מישהו עם האימייל הזה כבר קיים באחת מהטבלאות
            var existingStudent = await _context.Students.FirstOrDefaultAsync(u => u.Email == dto.Email);
            var existingTeacher = existingStudent == null ? await _context.Teachers.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;
            var existingAdmin = (existingStudent == null && existingTeacher == null)
                ? await _context.Admins.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;

            if (existingStudent != null || existingTeacher != null || existingAdmin != null)
            {
                return Ok(new { exists = true });
            }

            // יצירת יוזר חדש לפי Role
            User newUser;
            switch (dto.Role)
            {
                case UserRole.Admin:
                    newUser = new Admin
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password, // כאן תוכל לשים בעתיד Hash
                    };
                    _context.Admins.Add((Admin)newUser);
                    break;

                case UserRole.Teacher:
                    newUser = new Teacher
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password
                    };
                    _context.Teachers.Add((Teacher)newUser);
                    break;

                case UserRole.Student:
                default:
                    newUser = new Student
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password
                    };
                    _context.Students.Add((Student)newUser);
                    break;
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == dto.Email && s.PasswordHash == dto.Password);
            if (student != null)
                return Ok(new { role = "Student", fullName = student.FullName, token = "student-token" });

            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Email == dto.Email && t.PasswordHash == dto.Password);
            if (teacher != null)
                return Ok(new { role = "Teacher", fullName = teacher.FullName, token = "teacher-token" });

            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == dto.Email && a.PasswordHash == dto.Password);
            if (admin != null)
                return Ok(new { role = "Admin", fullName = admin.FullName, token = "admin-token" });

            return Unauthorized("Invalid email or password");
        }


    }
}