﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Interfaces
{
    public interface IUnitOfWork
    {
        IPermissionRepository PermissionRepository { get; }
    }
}
