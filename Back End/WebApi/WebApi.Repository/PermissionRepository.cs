using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Interfaces;

namespace WebApi.Repository
{
    public class PermissionRepository : IPermissionRepository
    {

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