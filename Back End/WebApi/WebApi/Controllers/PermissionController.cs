using Microsoft.AspNetCore.Mvc;
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

        public IActionResult RequestPermission()
        {
            //Validar parametros
            //Si esta ok seguimos si no devlovemos un bad request
            //ahi llamamos al servicio
            _permissionServices.RequestPermissionServices();
            return Ok();
        }

        public IActionResult ModifyPermission()
        {
            _permissionServices.ModifyPermissionServices();
            return Ok();
        }

        public IActionResult GetPermissions()
        {
            _permissionServices.GetPermissionsServices();
            return Ok();
        }
    }
}
