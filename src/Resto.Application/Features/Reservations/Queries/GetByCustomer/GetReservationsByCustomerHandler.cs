using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Reservations.Queries.GetAllById;
using Resto.Application.Features.Reservations.Queries.GetByCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetByCustomer
{
    public class GetAllReservationsByCustomerIdHandler(IReservationService reservationService)
        : IQueryHandler<GetReservationsQuery, IEnumerable<GetReservationsResponse>>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<IEnumerable<GetReservationsResponse>> Handle(GetReservationsQuery query, CancellationToken cancellationToken)
        {
            return await _reservationService.GetByCustomerIdAsync(query);
        }
    }
}
