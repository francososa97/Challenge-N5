using Microsoft.AspNetCore.Mvc;
using WebApi.Infraestructure;
using WebApi.Models.Interfaces;

namespace WebApi.Repository
{
    public class PermissionRepository : IPermissionRepository
    {

        public Task<ActionResult> GetPermissionsServices()
        {
            using(var context = new N5ChallengeContext())
            {

            }
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