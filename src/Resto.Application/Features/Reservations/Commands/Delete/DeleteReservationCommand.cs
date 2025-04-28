using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Commands.Delete
{
    public record DeleteReservationCommand(string Id):ICommand<DeleteReservationResult>;

   
    public record DeleteReservationResult(bool isSuccess);
}
