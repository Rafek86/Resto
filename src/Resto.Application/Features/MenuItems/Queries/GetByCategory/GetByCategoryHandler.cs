using Resto.Application.Common.CQRS;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.Features.MenuItems.Queries.GetByCategory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetByCategory
{
    public class GetByCategoryHandler(IMenuService menuService)
        : IQueryHandler<GetByCategoryQuery, IEnumerable<GetByCategoryResult>>
    {
        private readonly IMenuService _menuService = menuService;

        public async Task<IEnumerable<GetByCategoryResult>> Handle(
            GetByCategoryQuery request,
            CancellationToken cancellationToken)
        {
            return await _menuService.GetMenuItemsByCategoryAsync(request);
        }
    }
}
