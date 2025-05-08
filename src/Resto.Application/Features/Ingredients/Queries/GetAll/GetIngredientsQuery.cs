using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;

namespace Resto.Application.Features.Ingredients.Queries.GetAll
{
    public record GetIngredientsQuery(int PageNumber,int PageSize) : IQuery<PagedResult<GetIngredientsResult>>;

    public record GetIngredientsResult(
        IngredientDto ingredient
        );
}
