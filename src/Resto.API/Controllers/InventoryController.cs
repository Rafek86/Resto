using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resto.Application.Features.Ingredients.Commands.CreateIngredient;
using Resto.Application.Features.Ingredients.Commands.DeleteIngredient;
using Resto.Application.Features.Ingredients.Commands.UpdateIngredient;
using Resto.Application.Features.Ingredients.Queries.GetAll;
using Resto.Application.Features.Ingredients.Queries.GetById;
using MediatR;
using Resto.Application.Authentication;
using Resto.Domain.Authorization;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HasPermission(Permissions.IngredientsRead)]
        [HttpGet("ingredients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetIngredients([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetIngredientsQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.IngredientsRead)]
        [HttpGet("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIngredientById(string id)
        {
            var query = new GetIngredientByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.IngredientsCreate)]
        [HttpPost("ingredients")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetIngredientById), new { id = result.Id }, result);
        }

        //[HasPermission(Permissions.IngredientsUpdate)]
        [HttpPut("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIngredient(string id, [FromBody] UpdateIngredientCommand command)
        {
            if (id != command.Id)
                return BadRequest("The ID in the URL must match the ID in the request body");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.IngredientsDelete)]
        [HttpDelete("ingredients/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            var command = new DeleteIngredientCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}