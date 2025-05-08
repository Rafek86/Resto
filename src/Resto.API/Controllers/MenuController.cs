using Microsoft.AspNetCore.Mvc;
using Resto.Application.Authentication;
using Resto.Application.Common.Pagination;
using Resto.Application.Features.MenuItems.Commands.AddMenuItem;
using Resto.Application.Features.MenuItems.Commands.DeleteMenuItem;
using Resto.Application.Features.MenuItems.Commands.UpdateMenuItem;
using Resto.Application.Features.MenuItems.Queries.GetAll;
using Resto.Application.Features.MenuItems.Queries.GetByCategory;
using Resto.Domain.Authorization; 
using MediatR;
namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HasPermission(Permissions.MenuItemsRead)]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<GetAllMenuItemsResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllMenuItemsQuery(pageNumber, pageSize);
            var result = await _mediator.Send(query);
            if (result?.Items == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        //[HasPermission(Permissions.MenuItemsRead)]
        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<GetByCategoryResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var query = new GetByCategoryQuery(category);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.MenuItemsCreate)]
        [HttpPost]
        [ProducesResponseType(typeof(AddMenuItemResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] AddMenuItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.MenuItemsUpdate)]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateMenuItemResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateMenuItemcommand command)
        {
            if (id != command.Id)
                return BadRequest("ID in route must match ID in request body");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.MenuItemsDelete)]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteMenuItemResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteMenuItemCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}