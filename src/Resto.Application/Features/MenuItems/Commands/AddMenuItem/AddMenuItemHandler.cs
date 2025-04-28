using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.AddMenuItem
{
   public class AddMenuItemHandler(IMenuService menuService) : ICommandHandler<AddMenuItemCommand, AddMenuItemResult>
    {
        private readonly IMenuService _menuService = menuService;

        public async Task<AddMenuItemResult> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
        {
           return await _menuService.AddMenuItemAsync(request);
        }
    }
}
