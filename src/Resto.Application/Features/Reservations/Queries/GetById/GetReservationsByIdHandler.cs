using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Reservations.Queries.GetById
{
    public class GetReservationsByIdHandler(IReservationService reservationService) 
        :IQueryHandler<GetReservationByIdQuery, GetReservationByIdResponse>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdQuery query, CancellationToken cancellationToken)
        {
            return await _reservationService.GetByIdAsync(query);
        }

    }
}
