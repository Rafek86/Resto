using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Ingredients.Commands.UpdateIngredient
{
  public record UpdateIngredientCommand(
        string Id,
        string Name,
        int Unit,
        int RecordThreshold
        ) : ICommand<UpdateIngredientResult>;

   public record UpdateIngredientResult(bool isSuccess);
}
