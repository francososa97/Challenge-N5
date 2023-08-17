using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Interfaces;

namespace WebApi.Services
{
    public class PermissionServices : IPermissionServices
    {
        private IPermissionRepository permissionRepository;

        public PermissionServices(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public Task<ActionResult> GetPermissionsServices()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> ModifyPermissionServices()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> RequestPermissionServices()
        {
            throw new NotImplementedException();
        }
    }
}