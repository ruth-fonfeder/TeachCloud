using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAllAdmins();
        Admin? GetAdminById(int id);
        Admin CreateAdmin(Admin admin);
        bool UpdateAdmin(int id, Admin admin);
        bool DeleteAdmin(int id);
    }
}
