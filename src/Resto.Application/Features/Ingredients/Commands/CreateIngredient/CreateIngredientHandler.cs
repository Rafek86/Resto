using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Commands.CreateIngredient
{
  public  class CreateIngredientHandler(IIngredientService ingredientService) : ICommandHandler<CreateIngredientCommand, CreateIngredientResult>
    {
        public async Task<CreateIngredientResult> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            return await ingredientService.AddIngredientAsync(request);
        }
    }
}
