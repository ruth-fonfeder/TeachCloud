using TeachCloud.Core.Entities;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetAll();
    Lesson? GetById(int id);
    void Add(Lesson lesson);
    void Delete(Lesson lesson);
    void Save();
}
