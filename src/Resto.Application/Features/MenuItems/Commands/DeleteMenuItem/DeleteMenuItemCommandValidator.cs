using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.DeleteMenuItem
{
  public class DeleteMenuItemCommandValidator : AbstractValidator<DeleteMenuItemCommand>
    {
        public DeleteMenuItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
