using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetAllById
{
    public class GetReservationsQueryValidator :AbstractValidator<GetReservationsQuery>
    {
        public GetReservationsQueryValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Id is Required");
        }
    }
}
