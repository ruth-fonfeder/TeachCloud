using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using FileEntity = TeachCloud.Core.Entities.File;

namespace TeachCloud.Service
{
    public class FileService /*: IFileService*/
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public IEnumerable<FileEntity> GetAllFiles() => _fileRepository.GetAll();

        public FileEntity? GetFileById(int id) => _fileRepository.GetById(id);

        public FileEntity CreateFile(FileEntity file)
        {
            _fileRepository.Add(file);
            _fileRepository.Save();
            return file;
        }

        public bool UpdateFile(int id, FileEntity file)
        {
            var existing = _fileRepository.GetById(id);
            if (existing == null) return false;

            existing.FileName = file.FileName;
            existing.FilePath = file.FilePath;

            _fileRepository.Save();
            return true;
        }

        public bool DeleteFile(int id)
        {
            var file = _fileRepository.GetById(id);
            if (file == null) return false;

            _fileRepository.Delete(file);
            _fileRepository.Save();
            return true;
        }
    }
}
