using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Commands.Delete
{
    public class DeleteNotificationCommandValidator :AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");
        }
    }
}
