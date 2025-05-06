using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        void Add(Student student);
        void Delete(Student student);
        void Save();
    }
}
