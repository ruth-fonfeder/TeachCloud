using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Service
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }

}
