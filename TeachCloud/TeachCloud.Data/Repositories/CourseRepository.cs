using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        //public Course? GetById(int id)
        //{
        //    return _context.Courses.FirstOrDefault(e => e.Id == id);
        //}
        public Course GetByIdWithRelations(int id)
        {
            return _context.Courses
                .Include(c => c.GroupCourses)
                .FirstOrDefault(c => c.Id == id);
        }

        public Course GetById(int id)
        {
            return _context.Courses
                .Include(c => c.GroupCourses)
                .FirstOrDefault(c => c.Id == id);
        }

      

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Delete(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public List<Course> GetAllCoursesWithGroups()
        {
            return _context.Courses
                .Include(c => c.GroupCourses)
                    .ThenInclude(gc => gc.Group)
                .Include(c => c.Teacher)
                .ToList();
        }

    }
}
