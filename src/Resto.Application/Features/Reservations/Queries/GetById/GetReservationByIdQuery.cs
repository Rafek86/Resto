using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetById
{
    public record GetReservationByIdQuery(string reservationId) : IQuery<GetReservationByIdResponse>;

    public record GetReservationByIdResponse(ReservationDto Reservation);
}
