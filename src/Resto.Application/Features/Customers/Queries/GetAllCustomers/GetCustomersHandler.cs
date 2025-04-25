using Resto.Application.Common.CQRS;
using Resto.Application.Common.Pagination;
using Resto.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IQueryHandler<GetCustomersQuery, PagedResult<GetCustomerResponse>>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomersQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<PagedResult<GetCustomerResponse>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
        {
            return await _customerService.GetPagedCustomersAsync(query);
        }
    }
}
