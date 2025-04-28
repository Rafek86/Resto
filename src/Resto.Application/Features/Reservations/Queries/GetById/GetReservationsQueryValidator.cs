using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Reservations.Queries.GetById
{
    public class GetReservationsQueryValidator :AbstractValidator<GetReservationByIdQuery>
    {
        public GetReservationsQueryValidator()
        {
            RuleFor(x => x.reservationId)
                .NotEmpty()
                .WithMessage("Reservation Id is Required");
        }
    }
}
