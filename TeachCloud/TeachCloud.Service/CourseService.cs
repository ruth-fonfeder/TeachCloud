using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IGroupRepository _groupRepository;

        public CourseService(ICourseRepository courseRepository, IGroupRepository groupRepository)
        {
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
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
            var course = _courseRepository.GetById(id);
            if (course == null) return false;

            _courseRepository.Delete(course);
            _courseRepository.Save();
            return true;
        }
    }
}
