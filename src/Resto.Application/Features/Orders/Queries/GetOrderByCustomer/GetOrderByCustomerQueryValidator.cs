using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetOrderByCustomer
{
    public class GetOrderByCustomerQueryValidator :AbstractValidator<GetOrderByCustomerQuery>
    {
        public GetOrderByCustomerQueryValidator() {
            
               RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer ID is required.");
        }
    }
}
