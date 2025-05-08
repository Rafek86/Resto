using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resto.Application.Authentication;
using Resto.Application.Features.Reservations.Commands.Create;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Features.Reservations.Commands.Update;
using Resto.Application.Features.Reservations.Queries.GetAllById;
using Resto.Application.Features.Reservations.Queries.GetById;
using Resto.Domain.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HasPermission(Permissions.ReservationsRead)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetReservationByIdResponse>> GetById(string id)
        {
            var query = new GetReservationByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.ReservationsRead)]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetReservationsResponse>>> GetAll([FromBody] string customerId)
        {
            var query = new GetReservationsQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.ReservationsRead)]
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetReservationsResponse>>> GetByCustomerId(string customerId)
        {
            var query = new GetReservationsQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HasPermission(Permissions.ReservationsCreate)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateReservationResult>> Create(CreateReservationCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        //[HasPermission(Permissions.ReservationsUpdate)]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateReservationResult>> Update(string id, UpdateReservationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HasPermission(Permissions.ReservationsDelete)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeleteReservationResult>> Delete(string id)
        {
            var command = new DeleteReservationCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}