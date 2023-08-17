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
            var PermisionsDTO = BuildPermisionsDto(permisions);
            return PermisionsDTO;
        }



        public Task<ActionResult> ModifyPermissionServices()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> RequestPermissionServices()
        {
            throw new NotImplementedException();
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
        #endregion
    }
}