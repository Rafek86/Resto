using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetAllCustomers
{
    public record GetCustomersQuery(int PageNumber, int PageSize) : IQuery<PagedResult<GetCustomerResponse>>;

    public record GetCustomerResponse(string Id, string Name, string Email);
}
