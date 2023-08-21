using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Rebus.Messages;
using WebApi.Infraestructure.Domain;
using WebApi.Models.Dto;
using WebApi.Models.Interfaces;

namespace WebApi.Services
{
    public class PermissionServices : IPermissionServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GeneralDTOResponse> GetPermissionsServices()
        {
            var permisions = await _unitOfWork.PermissionRepository.GetPermissionsRepository();
            if (permisions.Any())
            {
                var PermisionsDTO = BuildPermisionsDto(permisions);
                return BuildResponseDto(true, "successful Get all permissions", PermisionsDTO, new PermisionsDTO());
            }
            else
                return BuildResponseDto(false, "an error occurred while Get all the permission", new List<PermisionsDTO>(), new PermisionsDTO());

        }

        public async Task<GeneralDTOResponse> ModifyPermissionServices(int id,PermisionsDTO newPermission)
        {
            var permiso = BuildPermisions(newPermission);
            var newPermissionResponse = await _unitOfWork.PermissionRepository.ModifyPermissionRepository(id, permiso);
            string mensagge = newPermissionResponse == permiso ? "successful edit permission" : "an error occurred while edit the permission";
            return BuildResponseDto(newPermissionResponse == permiso, mensagge, new List<PermisionsDTO>(), newPermission);
        }

        public async Task<GeneralDTOResponse> RequestPermissionServices(AddPermisionsDTO newPermission)
        {
            var permiso = BuildAddPermisions(newPermission);
            Permiso newPermissionCreated = await _unitOfWork.PermissionRepository.RequestPermissionRepository(permiso);
            string mensagge = newPermissionCreated == permiso ? "successful create permission" : "an error occurred while create the permission";
            return BuildResponseDto(newPermissionCreated == permiso, mensagge, new List<PermisionsDTO>(), new PermisionsDTO());
        }


        #region Private Methods

        private static GeneralDTOResponse BuildResponseDto(bool isOk,string mensagge, List<PermisionsDTO> Results, PermisionsDTO Result)
        {
            GeneralDTOResponse result = new Models.Dto.GeneralDTOResponse()
            { 
                IsOk = isOk,
                Message= mensagge,
                Results= Results,
                Result= Result
            };

            return result;
        }
        private static List<PermisionsDTO> BuildPermisionsDto(List<Permiso> permisions)
        {
            List<PermisionsDTO> permisosDTO = new List<PermisionsDTO>();
            permisions.ForEach(permiso =>
            {
                PermisionsDTO permisoDTO = new PermisionsDTO()
                {
                    Id = permiso.Id,
                    NombreEmpleado = permiso.NombreEmpleado,
                    ApellidoEmpleado = permiso.ApellidoEmpleado,
                    FechaPermiso = permiso.FechaPermiso.ToString("dd-MM-yyyy"),
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
                FechaPermiso = DateTime.Parse(permisoDTO.FechaPermiso),
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
                FechaPermiso = DateTime.Parse(permisoDTO.FechaPermiso),
                TipoPermiso = (int)permisoDTO.TipoPermiso,
            };
            return permiso;
        }
        #endregion
    }
}