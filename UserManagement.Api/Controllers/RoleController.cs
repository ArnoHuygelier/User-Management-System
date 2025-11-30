using Microsoft.AspNetCore.Mvc;
using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Services;
using UserManagement.Services.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(RoleService roleService) : ControllerBase
    {
        //Get
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<RoleResult>>> Get([FromRoute] int id)
        {
            var result = await roleService.Get(id);

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
        public async Task<ActionResult<ServiceResult<RoleResult>>> Find()
        {
            var result = await roleService.Find();

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
        public async Task<ActionResult<ServiceResult<RoleResult>>> Create([FromBody] RoleRequest request)
        {
            var result = await roleService.Create(request);

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
        public async Task<ActionResult<ServiceResult<RoleResult>>> Update([FromRoute] int id, [FromBody] RoleRequest request)
        {
            var result = await roleService.Update(id, request);

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
            var result = await roleService.Delete(id);

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
