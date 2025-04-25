using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Ingredients.Commands.UpdateIngredient
{
    public class UpdateIngredientHandler(IIngredientService ingredientService)
        : ICommandHandler<UpdateIngredientCommand, UpdateIngredientResult>
    {
        public async Task<UpdateIngredientResult> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            return await ingredientService.UpdateIngredientAsync(request);
        }
    }
}
