using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Interfaces.Services;
using Resto.Application.Features.Reservations.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resto.Application.Features.Customers.Queries.GetCustomerById;
using Resto.Application.Features.Reservations.Commands.Delete;
using Resto.Application.Features.Notifications.Commands.Create;
using Resto.Domain.Enums;

namespace Resto.Application.Features.Orders.Commands.Delete
{
  public  class CancelOrderHandler(IOrderService orderService,
            ICustomerService customerService,
            IReservationService reservationService
      ) : ICommandHandler<CancelOrderCommand ,CancelOrderResult>
    {
        private readonly IOrderService _orderService = orderService;
        private readonly ICustomerService _customerService = customerService;
        private readonly IReservationService _reservationService = reservationService;

        public async Task<CancelOrderResult> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetByIdAsync(new GetReservationByIdQuery(request.ReservationId));
            var customer = await _customerService.GetCustomerByIdAsync(new GetCustomerByIdQuery(reservation.Reservation.CustomerId));
            await _reservationService.DeleteByIdAsync(new DeleteReservationCommand( reservation.Reservation.ReservationId));

           return await _orderService.CancelOrderAsync(request);

        }
    } 
}
