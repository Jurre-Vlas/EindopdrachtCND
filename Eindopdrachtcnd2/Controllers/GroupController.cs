using Eindopdrachtcnd2.Models.DTO;
using Eindopdrachtcnd2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups()
        {
            var result = await _groupService.GetGroupsAsync();
            if (!result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpGet("{id:int}", Name = "GetGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupDTO>> GetGroup(int id)
        {
            var result = await _groupService.GetGroupAsync(id);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "Group not found")
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGroup([FromBody] GroupDTO groupDTO)
        {
            var result = await _groupService.CreateGroupAsync(groupDTO);
            if (!result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return CreatedAtRoute("GetGroup", new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] GroupDTO groupDTO)
        {
            var result = await _groupService.UpdateGroupAsync(id, groupDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "Group not found")
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var result = await _groupService.DeleteGroupAsync(id);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "Group not found")
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return NoContent();
        }
    }
}
