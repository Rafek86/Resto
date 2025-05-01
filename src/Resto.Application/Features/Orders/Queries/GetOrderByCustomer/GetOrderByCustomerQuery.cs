using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Orders.Queries.GetOrderByCustomer
{
    public record GetOrderByCustomerQuery(
        string CustomerId
        ) : IQuery<GetOrderByCustomerResult>;

    public record GetOrderByCustomerResult(IEnumerable<OrderDto> orders);
}
