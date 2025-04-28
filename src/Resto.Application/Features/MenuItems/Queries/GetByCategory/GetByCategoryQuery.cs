using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.MenuItems.Queries.GetByCategory
{
    public record GetByCategoryQuery(
        string Category
        ) : IQuery<IEnumerable<GetByCategoryResult>>;

    public record GetByCategoryResult(MenuDto MenuDto);
}
