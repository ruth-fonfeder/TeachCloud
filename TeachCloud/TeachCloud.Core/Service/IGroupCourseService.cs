using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface IGroupCourseService
    {
        void Create(GroupCourse groupCourse);
        // אפשר להוסיף עוד מתודות אם תצטרכי בהמשך
    }
}
