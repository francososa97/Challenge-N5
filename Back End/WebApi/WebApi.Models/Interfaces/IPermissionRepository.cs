using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;

namespace WebApi.Models.Interfaces
{
    public interface IPermissionRepository
    {
        Task<bool> RequestPermissionRepository(Permiso newPermission);
        Task<bool> ModifyPermissionRepository(int id, Permiso newPermission);
        Task<List<Permiso>> GetPermissionsRepository();
    }
}
