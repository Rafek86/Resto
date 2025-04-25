using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery(string Id) : IQuery<GetCustomerByIdResponse>;

    public record GetCustomerByIdResponse(CustomerDto Customer);
}
