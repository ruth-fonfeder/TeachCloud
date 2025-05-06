using TeachCloud.Core.Entities;

public interface ITeacherRepository
{
    IEnumerable<Teacher> GetAll();
    Teacher? GetById(int id);
    void Add(Teacher teacher);
    void Delete(Teacher teacher);
    void Save();
}