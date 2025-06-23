using System.Threading.Tasks;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using AutoMapper;

namespace TeachCloud.Service
{
    public class UserService : IUserService
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(
            IStudentService studentService,
            ITeacherService teacherService,
            IPasswordHasher passwordHasher,
            IMapper mapper)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public Task RegisterAsync(RegisterDto dto)
        {
            var hashedPassword = _passwordHasher.Hash(dto.Password);

            if (dto.UserType.ToLower() == "student")
            {
                // יצירת StudentDto מתוך הנתונים שנכנסו
                var studentDto = new StudentDto
                {
                    FullName = dto.FullName,
                    // אם יש לך Email בשירות או ב־StudentDto תוסיפי גם אותו
                    StudyGroupIds = new List<int>() // אם אין קבוצות כרגע – רשימה ריקה
                };

                _studentService.CreateStudent(studentDto);
            }
            else if (dto.UserType.ToLower() == "teacher")
            {
                var teacher = new Teacher
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PasswordHash = hashedPassword
                };

                _teacherService.CreateTeacher(teacher);
            }

            return Task.CompletedTask;
        }
    }
}
