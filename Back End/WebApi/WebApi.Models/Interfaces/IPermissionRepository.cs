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
        Task<Permiso> RequestPermissionRepository(Permiso newPermission);
        Task<Permiso> ModifyPermissionRepository(int id, Permiso newPermission);
        Task<List<Permiso>> GetPermissionsRepository();
    }
}
