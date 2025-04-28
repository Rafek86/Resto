using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.Notifications.Commands.Delete;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Commands.Delete
{
    public class DeleteReservationHandler(IReservationService reservationService) : ICommandHandler<DeleteReservationCommand, DeleteReservationResult>
    {
        private readonly IReservationService _reservationService = reservationService;

        public async Task<DeleteReservationResult> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {        
            await _reservationService.DeleteByIdAsync(request);

            return new DeleteReservationResult(true);
        }
    }
}
