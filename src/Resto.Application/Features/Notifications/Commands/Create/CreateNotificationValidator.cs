using FluentValidation;
using Resto.Application.Features.Notifications.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Notifications.Commands.Create
{
    public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand> { 
    
        public CreateNotificationValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("customerId is required.");

            RuleFor(x => x.message)
                .NotEmpty()
                .WithMessage("message is required.");
        }

    }
}
