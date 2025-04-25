using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Common.Pagination;

namespace Resto.Application.Features.Ingredients.Queries.GetAll
{
    public class GetIngredientsHandler(IIngredientService ingredientService)
        : IQueryHandler<GetIngredientsQuery, PagedResult<GetIngredientsResult>>
    {
        public async Task<PagedResult<GetIngredientsResult>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await ingredientService.GetAllIngredientsAsync(request);
        }
    }
}
