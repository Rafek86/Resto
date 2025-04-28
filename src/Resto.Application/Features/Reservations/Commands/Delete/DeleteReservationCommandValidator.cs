using FluentValidation;

namespace Resto.Application.Features.Reservations.Commands.Delete
{
    public class DeleteReservationCommandValidator :AbstractValidator<DeleteReservationCommand>
    {
        public DeleteReservationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");
        }
    }
}
