using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Reservations.Commands.Update;

public class UpdateReservationRequestHandler : ICommandHandler<UpdateReservationCommand, UpdateReservationResult>
{
    private readonly IReservationService _reservationService;

    public UpdateReservationRequestHandler(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public async Task<UpdateReservationResult> Handle(UpdateReservationCommand command, CancellationToken cancellationToken)
    {
        var result = await _reservationService.UpdateByIdAsync(command.ReservationId, command);
        return result;
    }
}
