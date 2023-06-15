using Eindopdrachtcnd2.Data.Entities;
using Eindopdrachtcnd2.Models.DTO;
using Eindopdrachtcnd2.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eindopdrachtcnd2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        //[HttpGet("list")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<CardDTO>>> GetCards()
        //{
        //    var result = await _cardService.GetCardsAsync();
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return Ok(result.Data);
        //}

        //[HttpGet("{id:int}", Name = "GetCard")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CardDTO>> GetCard(int id)
        //{
        //    var result = await _cardService.GetCardAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "Card not found")
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
        //public async Task<IActionResult> CreateCard([FromBody] CardDTO cardDTO)
        //{
        //    var result = await _cardService.CreateCardAsync(cardDTO);
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return CreatedAtRoute("GetCard", new { id = result.Data.Id }, result.Data);
        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateCard(int id, [FromBody] CardDTO cardDTO)
        //{
        //    var result = await _cardService.UpdateCardAsync(id, cardDTO);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "Card not found")
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
        //public async Task<IActionResult> DeleteCard(int id)
        //{
        //    var result = await _cardService.DeleteCardAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "Card not found")
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return NoContent();
        //}
    }
}
