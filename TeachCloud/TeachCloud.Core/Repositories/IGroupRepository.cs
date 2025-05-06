using TeachCloud.Core.Entities;

public interface IGroupRepository
{
    IEnumerable<Group> GetAll();
    Group? GetById(int id);
    void Add(Group group);
    void Delete(Group group);
    void Save();
}