using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }
        public Teacher? GetByEmail(string email)
        {
            return _context.Teachers.FirstOrDefault(t => t.Email == email);
        }


        public Teacher? GetById(int id)
        {
            return _context.Teachers.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
