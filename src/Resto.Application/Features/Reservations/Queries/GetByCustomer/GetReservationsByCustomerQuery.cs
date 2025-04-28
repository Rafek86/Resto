using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetByCustomer
{
    public record GetReservationsByCustomerQuery(string CustomerId) : IQuery<IEnumerable<GetReservationsByCustomerResponse>>;

    public record GetReservationsByCustomerResponse(ReservationDto Reservation);
}
