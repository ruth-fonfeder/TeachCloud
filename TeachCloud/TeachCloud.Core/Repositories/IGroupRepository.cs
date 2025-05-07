using TeachCloud.Core.Entities;


namespace TeachCloud.Core.Repositories
{
public interface IGroupRepository
{
    IEnumerable<Group> GetAll();
    Group? GetById(int id);
    void Add(Group group);
    void Delete(Group group);
    void Save();
}
}
