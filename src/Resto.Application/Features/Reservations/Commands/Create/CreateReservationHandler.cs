using Mapster;
using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;


namespace Resto.Application.Features.Reservations.Commands.Create
{
    public class CreateReservationHandler(IReservationService reservationService) : ICommandHandler<CreateReservationCommand, CreateReservationResult>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<CreateReservationResult> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            return await _reservationService.AddAsync(request);
        }
    }
}
