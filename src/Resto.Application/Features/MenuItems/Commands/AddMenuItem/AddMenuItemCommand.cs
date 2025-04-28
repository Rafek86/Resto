using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.AddMenuItem
{
    public record AddMenuItemCommand(
        string Name,
        string Description,
        decimal Price,
        string Category,
        bool IsAvailable) :ICommand<AddMenuItemResult>;

    public record AddMenuItemResult(string Id);
}
