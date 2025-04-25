using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientHandler(IIngredientService ingredientService)
        : ICommandHandler<DeleteIngredientCommand, DeleteIngredientResult>
    {
        public async Task<DeleteIngredientResult> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            return await ingredientService.DeleteIngredientAsync(request);
        }
    }
}
