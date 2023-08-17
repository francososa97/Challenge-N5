using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Infraestructure.Domain;

namespace WebApi.Models.Interfaces
{
    public interface IPermissionRepository
    {
        Task<ActionResult> RequestPermissionServices();
        Task<ActionResult> ModifyPermissionServices();
        List<Permiso> GetPermissionsServices();
    }
}
