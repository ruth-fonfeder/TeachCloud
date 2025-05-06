using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Data;
public class CourseRepository : ICourseRepository
{
    private readonly DataContext _context;

    public CourseRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Course> GetAll() => _context.Courses.ToList();
    public Course? GetById(int id) => _context.Courses.FirstOrDefault(c => c.Id == id);
    public void Add(Course course) => _context.Courses.Add(course);
    public void Delete(Course course) => _context.Courses.Remove(course);
   // public void Save() => _context.SaveChanges();
}
