using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        void Add(Course course);
        void Delete(Course course);
        void Save();
        Course? GetByIdWithRelations(int id);

    }
}
