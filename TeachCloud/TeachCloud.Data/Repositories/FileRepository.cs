using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using FileEntity = TeachCloud.Core.Entities.File;

namespace TeachCloud.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DataContext _context;

        public FileRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<FileEntity> GetAll()
        {
            return _context.Files.ToList();
        }

        public FileEntity? GetById(int id)
        {
            return _context.Files.FirstOrDefault(f => f.Id == id);
        }

        public void Add(FileEntity file)
        {
            _context.Files.Add(file);
        }

        public void Delete(FileEntity file)
        {
            _context.Files.Remove(file);
        }

        public void Save()
        {
            //_context.SaveChanges();
        }
    }
}
