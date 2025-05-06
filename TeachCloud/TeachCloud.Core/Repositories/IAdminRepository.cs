using TeachCloud.Core.Entities;
using System.Collections.Generic;

namespace TeachCloud.Core.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAll();
        Admin? GetById(int id);
        void Add(Admin admin);
        void Delete(Admin admin);
        void Save();
    }
}


