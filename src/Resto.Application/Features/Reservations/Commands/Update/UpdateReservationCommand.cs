using Resto.Application.Common.CQRS;
using Resto.Domain.Enums;

namespace Resto.Application.Features.Reservations.Commands.Update
{
   public record UpdateReservationCommand(string ReservationId, int TableNumber, DateTime ReservationDate, int PartySize,TablesStatus TablesStatus)
        : ICommand<UpdateReservationResult>;

    public record UpdateReservationResult(bool isSuccess);
}
