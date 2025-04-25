using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;

namespace Resto.Application.Features.Ingredients.Queries.GetById
{
    public class GetIngredientByIdHandler(IIngredientService ingredientService)
        : IQueryHandler<GetIngredientByIdQuery, GetIngredientByIdResult>
    {
        public async Task<GetIngredientByIdResult> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            return await ingredientService.GetIngredientByIdAsync(request);
        }
    }
}
