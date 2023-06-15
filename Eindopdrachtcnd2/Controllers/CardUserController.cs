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
    public class CardUserController : ControllerBase
    {
        private readonly ICardUserService _cardUserService;

        public CardUserController(ICardUserService cardUserService)
        {
            _cardUserService = cardUserService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUserToCard([FromBody] CardUserDTO cardUserDTO)
        {
            var result = await _cardUserService.AddUserToCardAsync(cardUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "Card not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return CreatedAtRoute("GetCardUser", new { cardId = result.Data.CardId, userId = result.Data.UserId }, result.Data);
        }

        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveUserFromCard([FromBody] CardUserDTO cardUserDTO)
        {
            var result = await _cardUserService.RemoveUserFromCardAsync(cardUserDTO);
            if (!result.IsSuccess)
            {
                if (result.ErrorMessage == "User not found" || result.ErrorMessage == "Card not found")
                {
                    return BadRequest(result.ErrorMessage);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
            }

            return NoContent();
        }
    }
}
