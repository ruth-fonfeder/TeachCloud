using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // שם המוסד

        
        // מערך של מנהלים
        public List<Admin> SystemLogs { get; set; } = new();
    }
}
