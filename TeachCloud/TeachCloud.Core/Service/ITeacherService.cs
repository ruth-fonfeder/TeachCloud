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
        Teacher? GetByEmail(string email);

        IEnumerable<Teacher> GetAllTeachers();
        Teacher? GetTeacherById(int id);
        Teacher? GetTeacherByEmail(string email);       // <-- הוסף
        List<Course> GetCoursesByTeacherId(int teacherId);  // <-- הוסף
        Group AddOrJoinGroup(string groupName, string teacherEmail);

        List<Group> GetGroupsByTeacherId(int teacherId);
        Teacher CreateTeacher(Teacher teacher);
        bool UpdateTeacher(int id, Teacher teacher);
        bool DeleteTeacher(int id);
    }

}

