using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
//using TeachCloud.Data.Repositories;

namespace TeachCloud.Service
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return _adminRepository.GetAll();
        }

        public Admin? GetAdminById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public Admin CreateAdmin(Admin admin)
        {
            _adminRepository.Add(admin);
            _adminRepository.Save(); // שמירה למסד הנתונים
            return admin;
        }

        public bool UpdateAdmin(int id, Admin admin)
        {
            var existing = _adminRepository.GetById(id);
            if (existing == null)
                return false;

            existing.FullName = admin.FullName;
            existing.Email = admin.Email;
            existing.PasswordHash = admin.PasswordHash;

            _adminRepository.Save(); // שמירה אחרי עדכון
            return true;
        }

        public bool DeleteAdmin(int id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin == null)
                return false;

            _adminRepository.Delete(admin);
            _adminRepository.Save(); // שמירה אחרי מחיקה
            return true;
        }
    }
}
