using Microsoft.AspNetCore.Mvc;
using UserManagement.Dto.Request;
using UserManagement.Dto.Result;
using UserManagement.Services;
using UserManagement.Services.Models;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        //Get
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<UserResult>>> Get([FromRoute] int id)
        {
            var result = await userService.Get(id);

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
        public async Task<ActionResult<ServiceResult<UserResult>>> Find()
        {
            var result = await userService.Find();

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
        public async Task<ActionResult<ServiceResult<UserResult>>> Create([FromBody] UserRequest request)
        {
            var result = await userService.Create(request);

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
        public async Task<ActionResult<ServiceResult<UserResult>>> Update([FromRoute] int id, [FromBody] UserRequest request)
        {
            var result = await userService.Update(id, request);

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
            var result = await userService.Delete(id);

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
