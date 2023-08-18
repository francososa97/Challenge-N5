using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Dto;

namespace WebApi.Models.Interfaces
{
    public interface IPermissionServices
    {
        bool RequestPermissionServices(AddPermisionsDTO newPermission);
        Task<bool> ModifyPermissionServices(int id, PermisionsDTO newPermission);
        List<PermisionsDTO> GetPermissionsServices();
    }
}
