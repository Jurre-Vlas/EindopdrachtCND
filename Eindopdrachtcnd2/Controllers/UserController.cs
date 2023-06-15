using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("list")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        //{
        //    var result = await _userService.GetUsersAsync();
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return Ok(result.Data);
        //}

        //[HttpGet("{id:int}", Name = "GetUser")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<UserDTO>> GetUser(int id)
        //{
        //    var result = await _userService.GetUserAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "User not found")
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return Ok(result.Data);
        //}

        //[HttpPost("add")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        //{
        //    var result = await _userService.CreateUserAsync(userDTO);
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return CreatedAtRoute("GetUser", new { id = result.Data.Id }, result.Data);
        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        //{
        //    var result = await _userService.UpdateUserAsync(id, userDTO);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "User not found")
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var result = await _userService.DeleteUserAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "User not found")
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return NoContent();
        //}
    }
}
