using TeachCloud.Core.Entities;
using TeachCloud.Data;

public class TeacherRepository /*: ITeacherRepository*/
{
    private readonly DataContext _context;

    public TeacherRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Teacher> GetAll() => _context.Teachers.ToList();
    public Teacher? GetById(int id) => _context.Teachers.FirstOrDefault(t => t.Id == id);
    public void Add(Teacher teacher) => _context.Teachers.Add(teacher);
    public void Delete(Teacher teacher) => _context.Teachers.Remove(teacher);
   //public void Save() => _context.SaveChanges();
}