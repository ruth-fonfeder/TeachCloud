using TeachCloud.Core.Entities;


namespace TeachCloud.Core.Repositories
{
public interface ILessonRepository
{
    IEnumerable<Lesson> GetAll();
    Lesson? GetById(int id);
    void Add(Lesson lesson);
    void Delete(Lesson lesson);
    void Save();
}
}

