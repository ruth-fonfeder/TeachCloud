using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class TeacherService /*: ITeacherService*/
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepository.GetAll();

        public Teacher? GetTeacherById(int id) => _teacherRepository.GetById(id);

        public Teacher CreateTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
            _teacherRepository.Save();
            return teacher;
        }

        public bool UpdateTeacher(int id, Teacher teacher)
        {
            var existing = _teacherRepository.GetById(id);
            if (existing == null) return false;

            existing.FullName = teacher.FullName;
            existing.Email = teacher.Email;

            _teacherRepository.Save();
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetById(id);
            if (teacher == null) return false;

            _teacherRepository.Delete(teacher);
            _teacherRepository.Save();
            return true;
        }
    }
}