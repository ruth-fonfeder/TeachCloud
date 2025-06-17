using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class UserService : IUserService
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IStudentService studentService, ITeacherService teacherService, IPasswordHasher passwordHasher)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var hashedPassword = _passwordHasher.Hash(dto.Password);

            if (dto.UserType == "student")
            {
                var student = new Student { FullName = dto.FullName, Username = dto.Username, Password = hashedPassword };
                _studentService.CreateStudent(student);
            }
            else if (dto.UserType == "teacher")
            {
                var teacher = new Teacher { FullName = dto.FullName, Username = dto.Username, Password = hashedPassword };
                _teacherService.CreateTeacher(teacher);
            }
        }
    }

}
