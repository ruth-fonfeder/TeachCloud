﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.DTOs;

namespace TeachCloud.Core.Service
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterDto dto);
    }

}
