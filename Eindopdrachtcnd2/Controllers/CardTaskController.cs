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
    public class CardTaskController : ControllerBase
    {
        private readonly ICardTaskService _cardTaskService;

        public CardTaskController(ICardTaskService cardTaskService)
        {
            _cardTaskService = cardTaskService;
        }

        //[HttpGet("list")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IEnumerable<CardTaskDTO>>> GetCardTasks()
        //{
        //    var result = await _cardTaskService.GetCardTasksAsync();
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return Ok(result.Data);
        //}

        //[HttpGet("{id:int}", Name = "GetCardTask")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CardTaskDTO>> GetCardTask(int id)
        //{
        //    var result = await _cardTaskService.GetCardTaskAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "CardTask not found")
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
        //public async Task<IActionResult> CreateCardTask([FromBody] CardTaskDTO cardTaskDTO)
        //{
        //    var result = await _cardTaskService.CreateCardTaskAsync(cardTaskDTO);
        //    if (!result.IsSuccess)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return CreatedAtRoute("GetCardTask", new { id = result.Data.Id }, result.Data);
        //}

        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateCardTask(int id, [FromBody] CardTaskDTO cardTaskDTO)
        //{
        //    var result = await _cardTaskService.UpdateCardTaskAsync(id, cardTaskDTO);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "CardTask not found")
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
        //public async Task<IActionResult> DeleteCardTask(int id)
        //{
        //    var result = await _cardTaskService.DeleteCardTaskAsync(id);
        //    if (!result.IsSuccess)
        //    {
        //        if (result.ErrorMessage == "CardTask not found")
        //        {
        //            return NotFound();
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.ErrorMessage });
        //    }

        //    return NoContent();
        //}
    }
}
