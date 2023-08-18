using Microsoft.AspNetCore.Mvc;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;
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

        public List<PermisionsDTO> GetPermissionsServices()
        {
            var permisions = permissionRepository.GetPermissionsServices();
            if (permisions.Any())
            {
                var PermisionsDTO = BuildPermisionsDto(permisions);
                return PermisionsDTO;
            }
            else
                return new List<PermisionsDTO>();

        }

        public async Task<bool> ModifyPermissionServices(int id,PermisionsDTO newPermission)
        {
            var permiso = BuildPermisions(newPermission);
            bool isOk = await permissionRepository.ModifyPermissionServices(id, permiso);
            return isOk;
        }

        public bool RequestPermissionServices(AddPermisionsDTO newPermission)
        {
            var permiso = BuildAddPermisions(newPermission);
            bool isOk = permissionRepository.RequestPermissionServices(permiso);

            //Devolver un dto armado lindo y no un task bool
            return isOk;
        }


        #region Private Methods
        private static List<PermisionsDTO> BuildPermisionsDto(List<Permiso> permisions)
        {
            List<PermisionsDTO> permisosDTO = new List<PermisionsDTO>();
            permisions.ForEach(permiso =>
            {
                PermisionsDTO permisoDTO = new PermisionsDTO()
                {
                    NombreEmpleado = permiso.NombreEmpleado,
                    ApellidoEmpleado = permiso.ApellidoEmpleado,
                    FechaPermiso = permiso.FechaPermiso,
                    TipoPermiso = permiso.TipoPermiso,
                };
                permisosDTO.Add(permisoDTO);
            });
            return permisosDTO;
        }

        private static Permiso BuildPermisions(PermisionsDTO permisoDTO)
        {
            Permiso permiso = new Permiso()
            {
                Id = permisoDTO.Id,
                NombreEmpleado = permisoDTO.NombreEmpleado,
                ApellidoEmpleado = permisoDTO.ApellidoEmpleado,
                FechaPermiso = permisoDTO.FechaPermiso,
                TipoPermiso = permisoDTO.TipoPermiso,
            };
            return permiso;
        }

        private static Permiso BuildAddPermisions(AddPermisionsDTO permisoDTO)
        {
            Permiso permiso = new Permiso()
            {
                NombreEmpleado = permisoDTO.NombreEmpleado,
                ApellidoEmpleado = permisoDTO.ApellidoEmpleado,
                FechaPermiso = permisoDTO.FechaPermiso,
                TipoPermiso = permisoDTO.TipoPermiso,
            };
            return permiso;
        }
        #endregion
    }
}