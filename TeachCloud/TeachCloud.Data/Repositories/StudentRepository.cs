using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class StudentRepository /*: IStudentRepository*/
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll() => _context.Students.ToList();
        public Student? GetById(int id) => _context.Students.FirstOrDefault(s => s.Id == id);
        public void Add(Student student) => _context.Students.Add(student);
        public void Delete(Student student) => _context.Students.Remove(student);
        //public void Save() => _context.SaveChanges(); // או תשאירי ריק אם זה עדיין מנוהל ממקום אחר
    }
}
