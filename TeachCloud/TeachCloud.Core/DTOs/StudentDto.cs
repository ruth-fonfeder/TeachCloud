using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.DTOs
{
 
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // ← הוספת שדה חסר
        public List<int> StudyGroupIds { get; set; } = new();
    }

}
