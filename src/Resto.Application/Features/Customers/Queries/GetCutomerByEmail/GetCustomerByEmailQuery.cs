using Resto.Application.Common.CQRS;
using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetCutomerByEmail
{
    public record GetCustomerByEmailQuery(string Email) : IQuery<GetCustomerByEmailResponse>;

    public record GetCustomerByEmailResponse(CustomerDto Customer);
}
