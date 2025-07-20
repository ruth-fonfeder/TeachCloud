using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DataContext _context;

        public LessonRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _context.Lessons.ToList();
        }

        public Lesson? GetById(int id)
        {
            return _context.Lessons.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
        }

        public void Delete(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        //public IEnumerable<Lesson> GetLessonsByCourseId(int courseId)
        //{
        //    return _context.Lessons
        //        .Where(lesson =>
        //            lesson.StudyGroup.GroupCourses.Any(gc => gc.CourseId == courseId))
        //        .ToList();
        //}

        public IEnumerable<Lesson> GetLessonsByCourseId(int courseId)
        {
            // במידה ושיעור מקושר לקורס דרך StudyGroup -> GroupCourses -> Course
            return _context.Lessons
                .Include(l => l.StudyGroup)
                .ThenInclude(g => g.GroupCourses)
                .Where(l => l.StudyGroup.GroupCourses.Any(gc => gc.CourseId == courseId))
                .ToList();
        }
    }
}
