using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Commands.Add
{
    public class PlaceOrderCommandValidator :AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderCommandValidator() { 
            
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");

            RuleFor(x => x.TableNumber)
                .GreaterThan(0)
                .WithMessage("Table number must be greater than 0.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Order items are required.");
        }
    }
}
