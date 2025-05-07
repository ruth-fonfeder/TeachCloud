using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using FileEntity = TeachCloud.Core.Entities.File;

namespace TeachCloud.Core.Service
{
    public interface IFileService
    {
        IEnumerable<FileEntity> GetAllFiles();
        FileEntity? GetFileById(int id);
        FileEntity CreateFile(FileEntity file);
        bool UpdateFile(int id, FileEntity file);
        bool DeleteFile(int id);
    }
}