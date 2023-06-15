using Eindopdrachtcnd2.Models;
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
    public class CardTaskUserController : ControllerBase
    {
        private readonly ICardTaskUserService _cardTaskUserService;

        public CardTaskUserController(ICardTaskUserService cardTaskUserService)
        {
            _cardTaskUserService = cardTaskUserService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUserToCardTask([FromBody] CardTaskUserDTO cardTaskUserDTO)
        {
            var result = await _cardTaskUserService.AddUserToCardTaskAsync(cardTaskUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "CardTask not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return CreatedAtRoute("GetCardTaskUser", new { cardTaskId = result.Data.CardTaskId, userId = result.Data.UserId }, result.Data);
        }

        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveUserFromCardTask([FromBody] CardTaskUserDTO cardTaskUserDTO)
        {
            var result = await _cardTaskUserService.RemoveUserFromCardTaskAsync(cardTaskUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "CardTask not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return NoContent();
        }
    }
}
