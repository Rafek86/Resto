using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Commands.CreateIngredient
{
    public record CreateIngredientCommand(
        string Name ,
        int Unit,
        int RecordThreshold
        ) :ICommand<CreateIngredientResult>;

    public record CreateIngredientResult(string Id);
}
