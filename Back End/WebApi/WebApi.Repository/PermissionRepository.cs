using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Infraestructure;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;
using WebApi.Models.Interfaces;

namespace WebApi.Repository
{
    public class PermissionRepository : N5ChallengeContext, IPermissionRepository
    {
        public async Task<List<Permiso>> GetPermissionsRepository()
        {
            List<Permiso> permisos= new List<Permiso>();
            using(var context = new N5ChallengeContext())
            {
                var permisionsList = await context.Permisos.ToListAsync();
                permisos.AddRange(permisionsList);
            }

            return permisos;
        }

        public async Task<Permiso> ModifyPermissionRepository(int id, Permiso newPermission)
        {
            int result = 0;
            using (var context = new N5ChallengeContext())
            {
                var permision = context.Permisos.Where(p => p.Id == id).ToList().FirstOrDefault();

                permision.FechaPermiso = newPermission.FechaPermiso;
                permision.TipoPermiso = newPermission.TipoPermiso;
                permision.NombreEmpleado = newPermission.NombreEmpleado;
                permision.ApellidoEmpleado = newPermission.ApellidoEmpleado;

                result = await context.SaveChangesAsync();
            }
            return newPermission;
        }

        public async Task<Permiso> RequestPermissionRepository(Permiso newPermission)
        {
            int result = 0;
            using (var context = new N5ChallengeContext())
            {
                var permisionsList = context.Permisos.Add(newPermission);
                result = await context.SaveChangesAsync();
            }
            return newPermission;
        }
    }
}