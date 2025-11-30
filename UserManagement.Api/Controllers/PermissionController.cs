using Microsoft.AspNetCore.Mvc;
using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Services;
using UserManagement.Services.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController(PermissionService permissionService) : ControllerBase
    {
        //Get
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<PermissionResult>>> Get([FromRoute] int id)
        {
            var result = await permissionService.Get(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        //Find
        [HttpGet]
        public async Task<ActionResult<ServiceResult<PermissionResult>>> Find()
        {
            var result = await permissionService.Find();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        //Create
        [HttpPost]
        public async Task<ActionResult<ServiceResult<PermissionResult>>> Create([FromBody] PermissionRequest request)
        {
            var result = await permissionService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<PermissionResult>>> Update([FromRoute] int id, [FromBody] PermissionRequest request)
        {
            var result = await permissionService.Update(id, request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<bool>>> Delete([FromRoute] int id)
        {
            var result = await permissionService.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
