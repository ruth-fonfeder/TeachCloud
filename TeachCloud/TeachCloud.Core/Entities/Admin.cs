using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Admin : User
    {
        public Admin() : base(UserRole.Admin) { }
        // רשימת מורים שמנוהלים על ידי המנהל
        public List<Teacher> Teachers { get; set; } = new();

        // רשימת קבוצות לימוד שמנוהלות על ידי המנהל
        public List<Group> Groups { get; set; } = new();
    }

}
