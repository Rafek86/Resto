using FluentValidation;


namespace Resto.Application.Features.Reservations.Commands.Update
{
    public class UpdateReservationValidator : AbstractValidator<UpdateReservationCommand> { 
    
        public UpdateReservationValidator()
        {
            RuleFor(x => x.ReservationId)
                .NotEmpty()
                .WithMessage("Reservation Id is Required");

            RuleFor(x => x.TableNumber)
                .NotEmpty()
                .WithMessage("Table Number is Required");

            RuleFor(x => x.ReservationDate)
                .NotEmpty()
                .WithMessage("Reservation Date is Required");

            RuleFor(x => x.PartySize)
                .NotEmpty()
                .WithMessage("Party Size is Required")
                .GreaterThan(0)
                .WithMessage("Party Size must be greater than 0");
        }

    }
}
