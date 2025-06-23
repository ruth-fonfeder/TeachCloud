
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;

        public StudentService(IStudentRepository studentRepository, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }

        public IEnumerable<Student> GetAllStudents() => _studentRepository.GetAll();

        public Student? GetStudentById(int id) => _studentRepository.GetById(id);

        public Student CreateStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                FullName = studentDto.FullName,
                Email = studentDto.Email,
                StudyGroups = new List<Group>()
            };

            foreach (var groupId in studentDto.StudyGroupIds)
            {
                var group = _groupRepository.GetById(groupId);
                if (group != null)
                {
                    student.StudyGroups.Add(group);
                }
            }

            _studentRepository.Add(student);
            _studentRepository.Save();
            return student;
        }

        public bool UpdateStudent(int id, Student student)
        {
            var existing = _studentRepository.GetById(id);
            if (existing == null) return false;

            existing.FullName = student.FullName;
            existing.Email = student.Email;
            existing.GroupId = student.GroupId;

            _studentRepository.Save();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null) return false;

            _studentRepository.Delete(student);
            _studentRepository.Save();
            return true;
        }
    }
}
