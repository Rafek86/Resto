using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Common.Pagination;
using Resto.Application.Features.MenuItems.Queries.GetAll;
using System.Threading;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetAll
{
    public class GetAllMenuItemsHandler(IMenuService menuService) : IQueryHandler<GetAllMenuItemsQuery, PagedResult<GetAllMenuItemsResult>>
    {
        private readonly IMenuService _menuService = menuService;

        public async Task<PagedResult<GetAllMenuItemsResult>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            return await _menuService.GetAllMenuItemsAsync(request);
        }
    }
}
