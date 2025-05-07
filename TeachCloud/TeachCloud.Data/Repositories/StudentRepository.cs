using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
        }

        public void Save()
        {
           // _context.SaveChanges();
        }
    }
}
