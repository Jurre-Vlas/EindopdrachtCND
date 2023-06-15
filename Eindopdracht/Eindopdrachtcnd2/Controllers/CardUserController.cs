﻿using CampaingControlCenterAPI.Services;
using Eindopdrachtcnd2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost("{cardId:int}/users/{userId}")]
        [Authorize(Roles = "Admin, User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> CreateCardUser(int cardId, string userId)
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            var serviceResult = await _cardUserService.CreateCardUserAsync(cardId, userId, user);
            switch (serviceResult.ErrorCode)
            {
                case ErrorCodeEnum.Success:
                    return Ok();
                case ErrorCodeEnum.BadRequest:
                    return Problem(serviceResult.ErrorMessage, statusCode: StatusCodes.Status400BadRequest);
                default:
                    return Problem(serviceResult.ErrorMessage, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{cardId:int}/users/{userId}")]
        [Authorize(Roles = "Admin, User")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> RemoveCardUser(int cardId, string userId)
        {
            var user = User.FindFirstValue(ClaimTypes.Name);
            var serviceResult = await _cardUserService.RemoveCardUserAsync(cardId, userId, user);
            switch (serviceResult.ErrorCode)
            {
                case ErrorCodeEnum.Success:
                    return Ok();
                case ErrorCodeEnum.NotFound:
                    return Problem(serviceResult.ErrorMessage, statusCode: StatusCodes.Status404NotFound);
                default:
                    return Problem(serviceResult.ErrorMessage, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
