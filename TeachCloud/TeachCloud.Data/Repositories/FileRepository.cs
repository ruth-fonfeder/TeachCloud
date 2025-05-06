using TeachCloud.Data;
using FileEntity = TeachCloud.Core.Entities.File;


public class FileRepository /*: IFileRepository*/
{
    private readonly DataContext _context;

    public FileRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<FileEntity> GetAll() => _context.Files.ToList();
    public FileEntity? GetById(int id) => _context.Files.FirstOrDefault(f => f.Id == id);
    public void Add(FileEntity file) => _context.Files.Add(file);
    public void Delete(FileEntity file) => _context.Files.Remove(file);
   // public void Save() => _context.SaveChanges();
}