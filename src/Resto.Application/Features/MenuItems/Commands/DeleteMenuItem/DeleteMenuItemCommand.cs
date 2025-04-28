using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.DeleteMenuItem
{
    public record DeleteMenuItemCommand(
         string Id
    ) : ICommand<DeleteMenuItemResult>;

    public record DeleteMenuItemResult(bool isSuccess);
}
