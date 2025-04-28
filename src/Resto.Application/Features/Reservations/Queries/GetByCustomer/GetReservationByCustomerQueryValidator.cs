using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetByCustomer
{
    class GetReservationByCustomerQueryValidator :AbstractValidator<GetReservationsByCustomerQuery>
    {
        public GetReservationByCustomerQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Id is Required");
        }
    } 
}
