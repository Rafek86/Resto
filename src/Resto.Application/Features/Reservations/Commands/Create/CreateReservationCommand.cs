using Resto.Application.Common.CQRS;

namespace Resto.Application.Features.Reservations.Commands.Create
{
   public record CreateReservationCommand(string customerId, int TableNumber ,DateTime ReservationDate,int PartySize)
        : ICommand<CreateReservationResult>;

    public record CreateReservationResult(string Id);
}
