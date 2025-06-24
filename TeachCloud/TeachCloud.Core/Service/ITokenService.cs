using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    // ITokenService.cs
    public interface ITokenService
    {
        string CreateToken(User user);
    }

}
