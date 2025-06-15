using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public Group? GetById(int id)
        {
            return _context.Groups.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Group group)
        {
            _context.Groups.Add(group);
        }

        public void Delete(Group group)
        {
            _context.Groups.Remove(group);
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
