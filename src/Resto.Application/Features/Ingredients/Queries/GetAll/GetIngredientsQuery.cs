using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Queries.GetAll
{
    public record GetIngredientsQuery(int PageNumber,int PageSize) : IQuery<PagedResult<GetIngredientsResult>>;

    public record GetIngredientsResult(
        IngredientDto ingredient
        );
}
