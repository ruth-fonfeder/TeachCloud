using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using TeachCloud.Data.Repositories;

namespace TeachCloud.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupCourseRepository _groupCourseRepository;
        public CourseService(ICourseRepository courseRepository, IGroupRepository groupRepository, IGroupCourseRepository groupCourseRepository)
        {
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
            _groupCourseRepository = groupCourseRepository;
        }

        public Course? GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public IEnumerable<Course> GetAllCourses() => _courseRepository.GetAll();

        public Course? GetCourseById(int id) => _courseRepository.GetById(id);

        public Course CreateCourse(Course course)
        {
            _courseRepository.Add(course);
            _courseRepository.Save();
            return course;
        }

        public bool UpdateCourse(int id, Course course)
        {
            var existing = _courseRepository.GetById(id);
            if (existing == null) return false;

            existing.Name = course.Name;

            _courseRepository.Save();
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var course = _courseRepository.GetByIdWithRelations(id);
            if (course == null) return false;

            if (course.GroupCourses != null && course.GroupCourses.Any())
            {
                _groupCourseRepository.DeleteRange(course.GroupCourses); // תוודאי שיש לך פעולה כזו
            }

            _courseRepository.Delete(course);
            _courseRepository.Save();
            return true;
        }

        public IEnumerable<object> GetGroupsByCourse(int courseId)
        {
            var groupCourses = _groupCourseRepository.GetAll()
                .Where(gc => gc.CourseId == courseId && gc.Group != null)
                .Select(gc => new
                {
                    gc.Group.Id,
                    gc.Group.Name
                })
                .ToList();

            return groupCourses;
        }
        //public List<Course> GetAllCoursesWithGroups()
        //{
        //    return _context.Courses
        //        .Include(c => c.GroupCourses)
        //            .ThenInclude(gc => gc.Group)
        //        .Include(c => c.Teacher)
        //        .ToList();
        //}
        public List<Course> GetAllCoursesWithGroups()
        {
            // 🚨 שינוי כאן: קריאה לריפוזיטורי במקום גישה ישירה ל-context
            return _courseRepository.GetAllCoursesWithGroups();
        }

    }
}
