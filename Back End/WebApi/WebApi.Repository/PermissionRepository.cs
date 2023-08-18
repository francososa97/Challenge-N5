using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Infraestructure;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;
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

        public async Task<bool> ModifyPermissionServices(int id, Permiso newPermission)
        {
            int result = 0;
            using (var context = new N5ChallengeContext())
            {
                var permisionsList = context.Permisos.AddAsync(newPermission);
                result = await context.SaveChangesAsync();
            }
            return result != -1;
        }

        public async Task<bool> RequestPermissionServices(Permiso newPermission)
        {
            int result = 0;
            using (var context = new N5ChallengeContext())
            {
                var permision = context.Permisos.Where(p => p.Id == newPermission.Id).ToList().FirstOrDefault();
                permision.FechaPermiso = newPermission.FechaPermiso;
                permision.TipoPermiso = newPermission.TipoPermiso;
                permision.NombreEmpleado = newPermission.NombreEmpleado;
                permision.ApellidoEmpleado = newPermission.ApellidoEmpleado;
                result = await context.SaveChangesAsync();
            }
            //To do Devolver dtos con respuesta no solo bools
            return result != -1;
        }
    }
}