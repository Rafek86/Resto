using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Queries.GetById
{
   public class GetIngredientByIdValidator : AbstractValidator<GetIngredientByIdQuery>
    {
        public GetIngredientByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id cannot be empty.");
        }
    }   
 
}
