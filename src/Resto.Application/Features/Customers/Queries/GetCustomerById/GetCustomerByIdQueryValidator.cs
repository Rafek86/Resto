using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetCustomerById
{
   public class GetCustomerByIdQueryValidator:AbstractValidator<GetCustomerByIdQuery>
    {
        public GetCustomerByIdQueryValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Customer ID is required.");
        }
    }
}
