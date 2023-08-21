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
        Task<GeneralDTOResponse> RequestPermissionServices(AddPermisionsDTO newPermission);
        Task<GeneralDTOResponse> ModifyPermissionServices(int id, PermisionsDTO newPermission);
        Task<GeneralDTOResponse> GetPermissionsServices();
    }
}
