using FluentValidation;
using Resto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Update
{
  public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() {
        
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Order ID is required.");

            RuleFor(x => x.OrderStatus)
                .IsInEnum()
                .WithMessage($"Invalid order status. Allowed values: {string.Join(", ", Enum.GetNames(typeof(OrderStatus)))}");
        }
    }
}
