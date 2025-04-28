using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.MenuItems.Commands.AddMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Commands.DeleteMenuItem
{
    public class DeleteMenuItemHandler(IMenuService menuService) : ICommandHandler<DeleteMenuItemCommand, DeleteMenuItemResult>
    {
        private readonly IMenuService _menuService = menuService;

        public async Task<DeleteMenuItemResult> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            return await _menuService.DeleteMenuItemAsync(request);
        }
    }
}
