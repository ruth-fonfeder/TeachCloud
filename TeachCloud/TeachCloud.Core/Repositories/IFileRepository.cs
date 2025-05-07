using FileEntity = TeachCloud.Core.Entities.File;
namespace TeachCloud.Core.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<FileEntity> GetAll();
        FileEntity? GetById(int id);
        void Add(FileEntity file);
        void Delete(FileEntity file);
        void Save();
    }
}
