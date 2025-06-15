using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;


namespace TeachCloud.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }

        public Admin? GetById(int id)
        {
            return _context.Admins.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Admin admin)
        {
            _context.Admins.Add(admin);
        }

        public void Update(Admin admin)// צריך לסדר את זה אחר כך
        {
            _context.Admins.Update(admin); // או לעדכן שדות כמו בקודם
        }

    public void Delete(Admin admin)
        {
            _context.Admins.Remove(admin);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
