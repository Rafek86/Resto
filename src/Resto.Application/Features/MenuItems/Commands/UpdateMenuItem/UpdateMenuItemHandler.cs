using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.MenuItems.Commands.AddMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.UpdateMenuItem
{
    public class UpdateMenuItemHandler(IMenuService menuService) : ICommandHandler<UpdateMenuItemcommand, UpdateMenuItemResult>
    {
        private readonly IMenuService _menuService = menuService;

        public async Task<UpdateMenuItemResult> Handle(UpdateMenuItemcommand request, CancellationToken cancellationToken)
        {
            return await _menuService.UpdateMenuItemAsync(request);
        }
    }
}
