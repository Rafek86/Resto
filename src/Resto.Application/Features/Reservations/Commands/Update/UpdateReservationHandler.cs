using Mapster;
using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Services;


namespace Resto.Application.Features.Reservations.Commands.Update
{
    public class UpdateReservationHandler(IReservationService reservationService) : ICommandHandler<UpdateReservationCommand, UpdateReservationResult>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<UpdateReservationResult> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            await _reservationService.UpdateByIdAsync(request);

            return new UpdateReservationResult(true);
        }
    }
}
