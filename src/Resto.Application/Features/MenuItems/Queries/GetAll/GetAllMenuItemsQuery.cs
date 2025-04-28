using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetAll
{
    public record GetAllMenuItemsQuery(
      int PageNumber,
      int PageSize
        ) :IQuery<PagedResult<GetAllMenuItemsResult>>;

    public record GetAllMenuItemsResult(MenuDto MenuDto);
}
