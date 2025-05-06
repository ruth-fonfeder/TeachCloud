using FileEntity = TeachCloud.Core.Entities.File;

public interface IFileRepository
{
    IEnumerable<FileEntity> GetAll();
    FileEntity? GetById(int id);
    void Add(FileEntity file);
    void Delete(FileEntity file);
    void Save();
}