using Resto.Application.Common.CQRS;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler(ICustomerService customerService) : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
    {
        private readonly ICustomerService _customerService = customerService;

        public Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
           return _customerService.GetCustomerByIdAsync(request);
        }
    }
}
