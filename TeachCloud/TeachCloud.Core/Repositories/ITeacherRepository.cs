using TeachCloud.Core.Entities;



namespace TeachCloud.Core.Repositories
{
    public interface ITeacherRepository
    {
        Teacher? GetByEmail(string email);

        IEnumerable<Teacher> GetAll();
        Teacher? GetById(int id);
        void Add(Teacher teacher);
        void Delete(Teacher teacher);
        void Save();
    }
}
