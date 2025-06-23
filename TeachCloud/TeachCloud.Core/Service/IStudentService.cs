using System.Collections.Generic;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student? GetStudentById(int id);
        Student CreateStudent(StudentDto studentDto); // ✅ כאן הסדר הנכון
        //Student CreateStudent(Student student);
        bool UpdateStudent(int id, Student student);
        bool DeleteStudent(int id);
    }
}
