using TeachCloud.Core.Entities;
using TeachCloud.Data;

public class LessonRepository /*: ILessonRepository*/
{
    private readonly DataContext _context;

    public LessonRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Lesson> GetAll() => _context.Lessons.ToList();
    public Lesson? GetById(int id) => _context.Lessons.FirstOrDefault(l => l.Id == id);
    public void Add(Lesson lesson) => _context.Lessons.Add(lesson);
    public void Delete(Lesson lesson) => _context.Lessons.Remove(lesson);
    //public void Save() => _context.SaveChanges();
}