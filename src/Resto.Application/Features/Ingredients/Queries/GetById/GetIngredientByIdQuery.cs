using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Queries.GetById
{
    public record GetIngredientByIdQuery(string Id) :IQuery<GetIngredientByIdResult>;

    public record GetIngredientByIdResult(
        IngredientDto Ingredient
        );
}
