using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dto;
using WebApi.Models.Interfaces;

namespace WebApi.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionServices _permissionServices;

        public PermissionController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }
        [HttpPost("RequestPermission")]
        public IActionResult RequestPermission(PermisionsDTO newPermission)
        {
            //Validar parametros
            //Si esta ok seguimos si no devlovemos un bad request
            //ahi llamamos al servicio
            var result = _permissionServices.RequestPermissionServices(newPermission);
            return Ok(result);
        }
        [HttpPut("ModifyPermission")]
        public IActionResult ModifyPermission(int id,PermisionsDTO newPermission)
        {
            var result = _permissionServices.ModifyPermissionServices(id, newPermission);
            return Ok(result);
        }
        [HttpGet("GetPermissions")]
        public IActionResult GetPermissions()
        {
            var result = _permissionServices.GetPermissionsServices();
            return Ok(result);
        }

    }
}
