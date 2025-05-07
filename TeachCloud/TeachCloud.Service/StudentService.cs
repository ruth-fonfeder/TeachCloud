using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents() => _studentRepository.GetAll();

        public Student? GetStudentById(int id) => _studentRepository.GetById(id);

        public Student CreateStudent(Student student)
        {
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
