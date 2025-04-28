using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Reservations.Queries.GetAllById
{
    public class GetAllReservationsByCustomerIdHandler(IReservationService reservationService) 
        :IQueryHandler<GetReservationsQuery, IEnumerable<GetReservationsResponse>>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<IEnumerable<GetReservationsResponse>> Handle(GetReservationsQuery query, CancellationToken cancellationToken)
        {
          return await _reservationService.GetAllAsync(query);
        }
    }
}
