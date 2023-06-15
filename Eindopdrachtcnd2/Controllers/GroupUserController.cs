using Eindopdrachtcnd2.Models.DTO;
using Eindopdrachtcnd2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUserController : ControllerBase
    {
        private readonly IGroupUserService _groupUserService;

        public GroupUserController(IGroupUserService groupUserService)
        {
            _groupUserService = groupUserService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUserToGroup([FromBody] GroupUserDTO groupUserDTO)
        {
            var result = await _groupUserService.AddUserToGroupAsync(groupUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "Group not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return CreatedAtRoute("GetGroupUser", new { userId = result.Data.UserId, groupId = result.Data.GroupId }, result.Data);
        }

        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveUserFromGroup([FromBody] GroupUserDTO groupUserDTO)
        {
            var result = await _groupUserService.RemoveUserFromGroupAsync(groupUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "Group not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return NoContent();
        }
    }
}
