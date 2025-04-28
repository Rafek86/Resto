using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.UpdateMenuItem
{
    public record UpdateMenuItemcommand(
       string Id,
       string Name,
       string Description,
       decimal Price,
       string Category,
       bool IsAvailable
   ) : ICommand<UpdateMenuItemResult>;
    
    public record UpdateMenuItemResult(bool isSuccess);
}
