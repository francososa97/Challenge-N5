using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rebus.Messages;
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
        public IActionResult RequestPermission(AddPermisionsDTO newPermission)
        {
            try
            {
                bool requestIsOk = !newPermission.NombreEmpleado.IsNullOrEmpty()
                   && !newPermission.ApellidoEmpleado.IsNullOrEmpty()
                   && !newPermission.FechaPermiso.IsNullOrEmpty()
                   && newPermission.TipoPermiso != 0;

                if (requestIsOk)
                {
                    var result = _permissionServices.RequestPermissionServices(newPermission);
                    return Ok(result);
                }
                return BadRequest("the fields sent are empty or wrong");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("an error occurred while loading a new permit");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("ModifyPermission/{id}")]
        public async Task<IActionResult> ModifyPermission(int id, PermisionsDTO newPermission)
        {
            try
            {
                if(id != 0)
                {
                    bool requestIsOk = !newPermission.NombreEmpleado.IsNullOrEmpty()
                       && !newPermission.ApellidoEmpleado.IsNullOrEmpty()
                       && newPermission.TipoPermiso != 0
                       && !newPermission.FechaPermiso.IsNullOrEmpty();

                    if (requestIsOk)
                    {
                        var resultOk = await _permissionServices.ModifyPermissionServices(id, newPermission);
                        if (resultOk)
                            return Ok();
                        else
                            return BadRequest("an error occurred while getting all permissions");
                    }
                    return BadRequest("the fields sent are empty or wrong");

                }
                return BadRequest("the id is not correct");

            }
            catch (ArgumentException ex)
            {
                return BadRequest("an error occurred while getting all permissions");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetPermissions")]
        public IActionResult GetPermissions()
        {
            try
            {
                var result = _permissionServices.GetPermissionsServices();
                if (result.Any())
                    return Ok(result);
                else
                    return BadRequest("an error occurred while getting all permissions");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("an error occurred while getting all permissions");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
