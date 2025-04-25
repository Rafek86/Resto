using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
    {
        public UpdateIngredientCommandValidator() {

            RuleFor(x => x.Name)
                  .NotEmpty()
                  .WithMessage("Name is required.");

            RuleFor(x => x.Unit)
                .NotEmpty()
                .WithMessage("Unit is required.")
                .GreaterThan(0)
                .WithMessage("Unit must be greater than 0.");

            RuleFor(x => x.RecordThreshold)
                .NotEmpty()
                .WithMessage("RecordThreshold is required.")
                .GreaterThan(0)
                .WithMessage("RecordThreshold must be greater than 0.");
        }
    }
}
