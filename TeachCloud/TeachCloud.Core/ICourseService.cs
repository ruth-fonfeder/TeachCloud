using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course? GetCourseById(int id);
        Course CreateCourse(Course course);
        bool UpdateCourse(int id, Course course);
        bool DeleteCourse(int id);
    }
}
