using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Infraestructure;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Interfaces;

namespace WebApi.Repository
{
    public class PermissionRepository : IPermissionRepository
    {

        public List<Permiso> GetPermissionsServices()
        {
            List<Permiso> permisos= new List<Permiso>();
            using(var context = new N5ChallengeContext())
            {
                var permisionsList = context.Permisos.ToList();
                permisos.AddRange(permisionsList);
            }
            return permisos;
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