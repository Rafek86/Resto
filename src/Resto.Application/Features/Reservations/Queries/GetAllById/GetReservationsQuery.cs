using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetAllById
{
    public record GetReservationsQuery(string CustomerId) : IQuery<IEnumerable<GetReservationsResponse>>;

    public record GetReservationsResponse(ReservationDto Reservation);
}
