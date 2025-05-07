using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher? GetTeacherById(int id);
        Teacher CreateTeacher(Teacher teacher);
        bool UpdateTeacher(int id, Teacher teacher);
        bool DeleteTeacher(int id);
    }
}