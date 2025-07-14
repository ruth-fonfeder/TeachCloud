//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Repositories;
//using TeachCloud.Core.Service;
//using TeachCloud.Data;
//namespace TeachCloud.Service
//{
//    public class TeacherService : ITeacherService
//    {
//        private readonly ITeacherRepository _teacherRepository;
//        private readonly DataContext _context;

//        public TeacherService(ITeacherRepository teacherRepository, DataContext context)
//        {
//            _teacherRepository = teacherRepository;
//            _context = context;
//        }

//        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepository.GetAll();

//        public Teacher? GetTeacherById(int id) => _teacherRepository.GetById(id);

//        public Teacher? GetTeacherByEmail(string email) => _context.Teachers.FirstOrDefault(t => t.Email == email);

//        public List<Course> GetCoursesByTeacherId(int teacherId)
//        {
//            return _context.Courses
//                .Where(c => c.TeacherId == teacherId)
//                .Include(c => c.StudyGroups)
//                .ToList();
//        }

//        public Teacher CreateTeacher(Teacher teacher)
//        {
//            _teacherRepository.Add(teacher);
//            _teacherRepository.Save();
//            return teacher;
//        }

//        public bool UpdateTeacher(int id, Teacher teacher)
//        {
//            var existing = _teacherRepository.GetById(id);
//            if (existing == null) return false;

//            existing.FullName = teacher.FullName;
//            existing.Email = teacher.Email;

//            _teacherRepository.Save();
//            return true;
//        }

//        public bool DeleteTeacher(int id)
//        {
//            var teacher = _teacherRepository.GetById(id);
//            if (teacher == null) return false;

//            _teacherRepository.Delete(teacher);
//            _teacherRepository.Save();
//            return true;
//        }
//        public List<Group> GetGroupsByTeacherId(int teacherId)
//        {
//            var courseIds = _context.Courses
//                .Where(c => c.TeacherId == teacherId)
//                .Select(c => c.Id)
//                .ToList();

//            var groups = _context.Groups
//                .Where(g => courseIds.Contains(g.CourseId))
//                .ToList();

//            return groups;
//        }

//    }
//}




//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Repositories;
//using TeachCloud.Core.Service;
//using TeachCloud.Data;

//namespace TeachCloud.Service
//{
//    public class TeacherService : ITeacherService
//    {
//        private readonly ITeacherRepository _teacherRepository;
//        private readonly DataContext _context;

//        public TeacherService(ITeacherRepository teacherRepository, DataContext context)
//        {
//            _teacherRepository = teacherRepository;
//            _context = context;
//        }

//        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepository.GetAll();

//        public Teacher? GetTeacherById(int id) => _teacherRepository.GetById(id);

//        public Teacher? GetTeacherByEmail(string email) =>
//            _context.Teachers.FirstOrDefault(t => t.Email == email);

//        public List<Course> GetCoursesByTeacherId(int teacherId)
//        {
//            return _context.Courses
//                .Where(c => c.TeacherId == teacherId)
//                .Include(c => c.GroupCourses)
//                    .ThenInclude(gc => gc.Group)
//                .ToList();
//        }
//        public Teacher? GetByEmail(string email)
//        {
//            return _teacherRepository.GetByEmail(email);
//        }

//        public Teacher CreateTeacher(Teacher teacher)
//        {
//            _teacherRepository.Add(teacher);
//            _teacherRepository.Save();
//            return teacher;
//        }

//        public bool UpdateTeacher(int id, Teacher teacher)
//        {
//            var existing = _teacherRepository.GetById(id);
//            if (existing == null) return false;

//            existing.FullName = teacher.FullName;
//            existing.Email = teacher.Email;

//            _teacherRepository.Save();
//            return true;
//        }

//        public bool DeleteTeacher(int id)
//        {
//            var teacher = _teacherRepository.GetById(id);
//            if (teacher == null) return false;

//            _teacherRepository.Delete(teacher);
//            _teacherRepository.Save();
//            return true;
//        }

//        public List<Group> GetGroupsByTeacherId(int teacherId)
//        {
//            return _context.GroupCourses
//                .Include(gc => gc.Group)
//                .Include(gc => gc.Course)
//                .Where(gc => gc.Course.TeacherId == teacherId)
//                .Select(gc => gc.Group)
//                .Distinct()
//                .ToList();
//        }
//    }
//}



using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using TeachCloud.Data;

namespace TeachCloud.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherGroupRepository _teacherGroupRepository;
        private readonly DataContext _context;

        public TeacherService(
            ITeacherRepository teacherRepository,
            IGroupRepository groupRepository,
            ITeacherGroupRepository teacherGroupRepository,
            DataContext context)
        {
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
            _teacherGroupRepository = teacherGroupRepository;
            _context = context;
        }

        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepository.GetAll();

        public Teacher? GetTeacherById(int id) => _teacherRepository.GetById(id);

        public Teacher? GetTeacherByEmail(string email) =>
            _context.Teachers.FirstOrDefault(t => t.Email == email);

        public Teacher? GetByEmail(string email)
        {
            return _teacherRepository.GetByEmail(email);
        }

        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Include(c => c.GroupCourses)
                    .ThenInclude(gc => gc.Group)
                .ToList();
        }

        //public List<Group> GetGroupsByTeacherId(int teacherId)
        //{
        //    return _context.TeacherGroups
        //        .Include(tg => tg.Group)
        //        .Where(tg => tg.TeacherId == teacherId)
        //        .Select(tg => tg.Group)
        //        .Distinct()
        //        .ToList();
        //}

        public List<Group> GetGroupsByTeacherId(int teacherId)
        {
            var teacher = _context.Teachers
                .Include(t => t.TeacherGroups)
                .ThenInclude(tg => tg.Group)
                .FirstOrDefault(t => t.Id == teacherId);

            if (teacher == null)
                return new List<Group>();

            return teacher.TeacherGroups
                .Select(tg => tg.Group)
                .Where(g => g != null)
                .ToList();
        }


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

        // ✅ פונקציה חדשה שמוסיפה את המורה לקבוצה קיימת או יוצרת חדשה אם לא קיימת
        public Group AddOrJoinGroup(string groupName, string teacherEmail)
        {
            var teacher = _teacherRepository.GetByEmail(teacherEmail)
                ?? throw new Exception("Teacher not found");

            var group = _groupRepository.GetAll()
                .FirstOrDefault(g => g.Name.ToLower() == groupName.Trim().ToLower());

            if (group == null)
            {
                group = new Group { Name = groupName };
                _groupRepository.Add(group);
                _groupRepository.Save();
            }

            bool alreadyLinked = _teacherGroupRepository.Exists(teacher.Id, group.Id);
            if (!alreadyLinked)
            {
                _teacherGroupRepository.Add(new TeacherGroup
                {
                    TeacherId = teacher.Id,
                    GroupId = group.Id
                });
                _teacherGroupRepository.Save();
            }

            return group;
        }
    }
}
